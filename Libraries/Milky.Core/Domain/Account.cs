using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogger.Core.Domain
{
    public partial class Account : BaseEntity
    {
        public string FarmerCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public bool Validated { get; set; }
        public int Dirty { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UsedSms { get; set; }
        public int TotalSms { get; set; }
    }
}


