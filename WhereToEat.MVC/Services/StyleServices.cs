using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhereToEat.MVC.Contracts;
using WhereToEat.MVC.Models.Styles;

namespace WhereToEat.MVC.Services
{
    public class StyleServices : IStyleServices
    {
        public async Task<IList<StyleViewModel>> ListCuisines()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CreateCuisine(StyleViewModel newCuisine)
        {
            throw new NotImplementedException();
        }

        public async Task<StyleViewModel> GetCuisineById(Guid? cuisineId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateCuisine(StyleViewModel updatedCuisine)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteCuisine(Guid cuisineId)
        {
            throw new NotImplementedException();
        }
    }
}