using System;

namespace WhereToEat.MVC.Data
{
    public class Restaurant
    {
        public Guid RestaurantId { get; set; }
        public string Name { get; set; }

        public Guid StyleId { get; set; }
        public Style Style { get; set; }
        
        public Guid CuisineId { get; set; }
        public Cuisine Cuisine { get; set; }

        public Guid PriceId { get; set; }
        public Price Price { get; set; }
    }
}