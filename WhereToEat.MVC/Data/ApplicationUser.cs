using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace WhereToEat.MVC.Data
{
    public class ApplicationUser : IdentityUser
    {
        public IEnumerable<Connection> Connections { get; set; }
        public IEnumerable<ChoiceMember> ChoiceMemberships { get; set; }
    }
}