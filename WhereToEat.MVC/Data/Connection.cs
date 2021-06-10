using System;

namespace WhereToEat.MVC.Data
{
    public class Connection
    {
        public Guid ConnectionId { get; set; }
        
        public string SenderId { get; set; }
        public ApplicationUser Sender { get; set; }

        public string ReceiverId { get; set; }
        public ApplicationUser Receiver { get; set; }

        public bool IsAccepted { get; set; }
    }
}