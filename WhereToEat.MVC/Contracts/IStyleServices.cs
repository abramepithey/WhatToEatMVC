using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhereToEat.MVC.Models.Styles;

namespace WhereToEat.MVC.Contracts
{
    public interface IStyleServices
    {
        Task<IList<StyleViewModel>> ListCuisines();
        Task<bool> CreateCuisine(StyleViewModel newCuisine);
        Task<StyleViewModel> GetCuisineById(Guid? cuisineId);
        Task<bool> UpdateCuisine(StyleViewModel updatedCuisine);
        Task<bool> DeleteCuisine(Guid cuisineId);
    }
}