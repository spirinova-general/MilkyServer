using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogger.Core.Domain
{
    public class BillsLog:BaseEntity
    {
        public DateTime GeneratedOn { get; set; }
    }
}