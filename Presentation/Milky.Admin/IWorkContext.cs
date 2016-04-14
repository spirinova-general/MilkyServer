using Blogger.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Milky.Admin
{
   public interface IWorkContext
    {
        Account CurrentAccount { get; set; }
    }
}
