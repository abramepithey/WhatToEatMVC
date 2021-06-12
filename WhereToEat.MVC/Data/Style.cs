using System;
using System.Collections.Generic;

namespace WhereToEat.MVC.Data
{
    public class Style
    {
        public Guid StyleId { get; set; }
        public string Name { get; set; }

        public IEnumerable<Restaurant> Restaurants { get; set; }
    }
}