using System;
using WhereToEat.MVC.Data;

namespace WhereToEat.MVC.Models.Connections
{
    public class ConnectionViewModel
    {
        public Guid ConnectionId { get; set; }
        public ApplicationUser ConnectedUser { get; set; }
    }
}