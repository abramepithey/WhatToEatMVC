using System;
using System.Collections.Generic;

namespace WhereToEat.MVC.Data
{
    public class ChoiceMember
    {
        public IEnumerable<Restaurant> DislikedRestaurants { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public Guid ChoiceGroupId { get; set; }
        public virtual ChoiceGroup Group { get; set; }
    }
}