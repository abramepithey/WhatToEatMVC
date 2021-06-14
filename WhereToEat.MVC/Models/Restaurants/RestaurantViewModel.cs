using System;

namespace WhereToEat.MVC.Models.Restaurants
{
    public class RestaurantViewModel
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public Guid StyleId { get; set; }
        public Guid CuisineId { get; set; }
    }
}