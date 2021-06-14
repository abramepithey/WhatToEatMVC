using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhereToEat.MVC.Models.Restaurants;

namespace WhereToEat.MVC.Contracts
{
    public interface IRestaurantServices
    {
        Task<IList<RestaurantViewModel>> ListCuisines();
        Task<bool> CreateCuisine(RestaurantViewModel newCuisine);
        Task<RestaurantViewModel> GetCuisineById(Guid cuisineId);
        Task<bool> UpdateCuisine(Guid cuisineId, RestaurantDetailsModel updatedCuisine);
        Task<bool> DeleteCuisine(Guid cuisineId);
    }
}