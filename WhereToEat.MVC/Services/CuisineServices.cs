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
                new CuisineViewModel
                {
                    Name = c.Name
                }).ToListAsync();
            return cuisines;
        }

        public async Task<bool> CreateCuisine(CuisineViewModel newCuisine)
        {
            Cuisine cuisine = new Cuisine {Name = newCuisine.Name};
            _context.Cuisines.Add(cuisine);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<CuisineViewModel> GetCuisineById(Guid cuisineId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateCuisine(Guid cuisineId, CuisineDetailsModel updatedCuisine)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteCuisine(Guid cuisineId)
        {
            throw new NotImplementedException();
        }
    }
}