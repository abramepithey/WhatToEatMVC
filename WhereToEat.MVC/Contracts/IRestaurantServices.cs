using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhereToEat.MVC.Models.Restaurants;

namespace WhereToEat.MVC.Contracts
{
    public interface IRestaurantServices
    {
        Task<IList<RestaurantViewModel>> ListRestaurants();
        Task<bool> CreateRestaurant(RestaurantViewModel newRestaurants);
        Task<RestaurantViewModel> GetRestaurantById(Guid? restaurantId);
        Task<bool> UpdateRestaurant(RestaurantDetailsModel updatedRestaurant);
        Task<bool> DeleteRestaurant(Guid restaurantId);
    }
}