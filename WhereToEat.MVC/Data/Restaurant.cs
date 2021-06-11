using System;
using System.ComponentModel.DataAnnotations;

namespace WhereToEat.MVC.Data
{
    public class Restaurant
    {
        public Guid RestaurantId { get; set; }
        public string Name { get; set; }
        
        [Range(1, 5, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Price { get; set; }

        public Guid StyleId { get; set; }
        public Style Style { get; set; }
        
        public Guid CuisineId { get; set; }
        public Cuisine Cuisine { get; set; }
    }
}