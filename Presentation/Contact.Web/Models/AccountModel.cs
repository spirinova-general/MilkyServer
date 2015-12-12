using Blogger.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contacts.Web.Models
{
    public partial class AccountModel : BaseModel
    {
    
        public string CompanyName { get; set; }
        public string OwnerName { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public string EmailId { get; set; }
        public DateTime CreatedOn { get; set; }
    }
  
}