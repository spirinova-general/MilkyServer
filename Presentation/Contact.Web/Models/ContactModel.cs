using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contacts.Web.Models
{
    public partial class ContactModel : BaseModel
    {
        public string Name { get; set; }
        public string ContactNumber { get; set; }
    }
}