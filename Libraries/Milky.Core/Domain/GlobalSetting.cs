using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogger.Core.Domain
{
    public class GlobalSetting : BaseEntity
    {
        public double DefaultRate { get; set; }
        public DateTime DateModified { get; set; }
        public int Dirty { get; set; }
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
    }
}

