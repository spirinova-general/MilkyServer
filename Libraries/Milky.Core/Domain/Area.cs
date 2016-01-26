using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogger.Core.Domain
{
    public class Area : BaseEntity
    {
        public string Name { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }

    }
}
