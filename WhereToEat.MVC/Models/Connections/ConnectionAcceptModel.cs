using System;

namespace WhereToEat.MVC.Models.Connections
{
    public class ConnectionAcceptModel
    {
        public Guid ConnectionId { get; set; }

        public string SenderEmail { get; set; }
        
        public bool IsAccepted { get; set; }
    }
}