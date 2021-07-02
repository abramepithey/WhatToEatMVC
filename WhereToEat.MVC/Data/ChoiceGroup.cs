using System;
using System.Collections.Generic;

namespace WhereToEat.MVC.Data
{
    public class ChoiceGroup
    {
        public Guid ChoiceGroupId { get; set; }
        
        public ICollection<Restaurant> PotentialRestaurants { get; set; }
        
        public IEnumerable<ChoiceMember> ChoiceMembers { get; set; }
    }
}