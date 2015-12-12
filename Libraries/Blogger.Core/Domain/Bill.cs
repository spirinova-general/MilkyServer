using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogger.Core.Domain
{
    public class Bill : BaseEntity
    {
        public int AccountId { get; set; }
        public int CustomerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Quantity { get; set; }
        public double Balance { get; set; }
        public double Adjustment { get; set; }
        public double TotalAmount { get; set; }
        public double Tax { get; set; }
        public bool IsCleared { get; set; }
        public double PaymentMade { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateModified { get; set; }
        public int Dirty { get; set; }
        public virtual Account Account { get; set; }
        public virtual Customer Customer { get; set; }
    }
}


