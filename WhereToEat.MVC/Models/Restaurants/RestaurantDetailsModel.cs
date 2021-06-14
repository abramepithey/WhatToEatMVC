using System;

namespace WhereToEat.MVC.Models.Restaurants
{
    public class RestaurantDetailsModel
    {
        public Guid RestaurantId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public Guid StyleId { get; set; }
        public Guid CuisineId { get; set; }
    }
}