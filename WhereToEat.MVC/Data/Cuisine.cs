using System;
using System.Collections.Generic;

namespace WhereToEat.MVC.Data
{
    public class Cuisine
    {
        public Guid CuisineId { get; set; }
        public string Name { get; set; }
        
        public IEnumerable<Restaurant> Restaurants { get; set; }
    }
}