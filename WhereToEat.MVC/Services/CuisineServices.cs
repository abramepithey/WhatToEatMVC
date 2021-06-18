using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WhereToEat.MVC.Contracts;
using WhereToEat.MVC.Data;
using WhereToEat.MVC.Models.Cuisines;

namespace WhereToEat.MVC.Services
{
    public class CuisineServices : ICuisineServices
    {
        private readonly ApplicationDbContext _context;
        public CuisineServices(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<IList<CuisineViewModel>> ListCuisines()
        {
            List<CuisineViewModel> cuisines = await _context.Cuisines.Select(c => 
                new CuisineViewModel()
                {
                    CuisineId = c.CuisineId,
                    Name = c.Name
                }).ToListAsync();
            return cuisines;
        }

        public async Task<bool> CreateCuisine(CuisineViewModel newCuisine)
        {
            Cuisine cuisine = new Cuisine {CuisineId = Guid.NewGuid(), Name = newCuisine.Name};
            _context.Cuisines.Add(cuisine);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<CuisineViewModel> GetCuisineById(Guid? cuisineId)
        {
            if (cuisineId == null)
            {
                return null;
            }
            var cuisine = await _context.Cuisines.FindAsync(cuisineId);
            if (cuisine == null)
            {
                return null;
            }
            var model = new CuisineViewModel { CuisineId = cuisine.CuisineId, Name = cuisine.Name };
            return model;
        }

        public async Task<bool> UpdateCuisine(CuisineViewModel updatedCuisine)
        {
            var cuisineToUpdate = new Cuisine {CuisineId = updatedCuisine.CuisineId, Name = updatedCuisine.Name};
            try
            {
                _context.Update(cuisineToUpdate);
                return await _context.SaveChangesAsync() == 1;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CuisineExists(updatedCuisine.CuisineId))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<bool> DeleteCuisine(Guid cuisineId)
        {
            var cuisine = await _context.Cuisines.FindAsync(cuisineId);
            _context.Cuisines.Remove(cuisine);
            return await _context.SaveChangesAsync() == 1;
        }
        
        private bool CuisineExists(Guid id)
        {
            return _context.Cuisines.Any(e => e.CuisineId == id);
        }
    }
}