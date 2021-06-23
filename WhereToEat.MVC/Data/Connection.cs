using System;

namespace WhereToEat.MVC.Data
{
    public class Connection
    {
        public Guid ConnectionId { get; set; }
        
        public string SenderId { get; set; }
        public virtual ApplicationUser Sender { get; set; }

        public string ReceiverId { get; set; }
        public virtual ApplicationUser Receiver { get; set; }

        public bool IsAccepted { get; set; }
    }
}