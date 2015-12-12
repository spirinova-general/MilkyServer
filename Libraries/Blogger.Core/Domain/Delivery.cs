using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogger.Core.Domain
{
    public class Delivery : BaseEntity
    {
        public int AccountId { get; set; }
        public int CustomerId { get; set; }
        public DateTime DeliveryDate { get; set; }
        public double Quantity { get; set; }
        public int Dirty { get; set; }
        public DateTime DateModified { get; set; }
        public virtual Account Account { get; set; }
        public virtual Customer Customer { get; set; }
    }
}

