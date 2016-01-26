using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogger.Core.Domain
{
    public class CustomerSetting : BaseEntity
    {
        public int AccountId { get; set; }
        public int CustomerId { get; set; }
        public double Rate { get; set; }
        public double DefaultQuantity { get; set; }
        public DateTime DateModified { get; set; }
        public int Dirty { get; set; }
        public virtual Account Account { get; set; }
        public virtual Customer Customer { get; set; }
    }
}

