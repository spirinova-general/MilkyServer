using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogger.Core.Domain
{
    public class Account_Area_Mapping : BaseEntity
    {
        public int AccountId { get; set; }
        public int AreaId { get; set; }
        public int Dirty { get; set; }
        public DateTime DateModified { get; set; }
        public virtual Account Account { get; set; }
        public virtual Area Area { get; set; }
    }
}

