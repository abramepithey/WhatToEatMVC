using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhereToEat.MVC.Models.Cuisines;

namespace WhereToEat.MVC.Contracts
{
    public interface ICuisineServices
    {
        Task<IList<CuisineDetailsModel>> ListCuisines();
        Task<bool> CreateCuisine(CuisineViewModel newCuisine);
        Task<CuisineViewModel> GetCuisineById(Guid cuisineId);
        Task<bool> UpdateCuisine(Guid cuisineId, CuisineDetailsModel updatedCuisine);
        Task<bool> DeleteCuisine(Guid cuisineId);
    }
}