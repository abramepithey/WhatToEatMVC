using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhereToEat.MVC.Contracts;
using WhereToEat.MVC.Models.Cuisines;

namespace WhereToEat.MVC.Services
{
    public class CuisineServices : ICuisineServices
    {
        public async Task<IList<CuisineViewModel>> ListCuisines()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CreateCuisine(CuisineViewModel newCuisine)
        {
            throw new NotImplementedException();
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