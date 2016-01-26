using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogger.Core.Domain
{
    public class Customer : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public int Balance { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateModified { get; set; }
        public int AccountId { get; set; }
        public int AreaId { get; set; }
        public int Dirty { get; set; }
        public int ClientId { get; set; }
        public DateTime DeliveryStartDate { get; set; }
        public virtual Account Account { get; set; }
        public virtual Area Area { get; set; }
    }
}
