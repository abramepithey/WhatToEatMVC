using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace WhereToEat.MVC.Data
{
    public class ApplicationUser : IdentityUser
    {
        public virtual IEnumerable<ApplicationUser> Connections { get; set; }
    }
}