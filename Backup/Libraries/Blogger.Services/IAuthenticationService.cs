using Blogger.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogger.Services
{
   public partial  interface IAuthenticationService
   {
       void SignIn(User user, bool createPersistentCookie);
       void SignOut();
       User GetAuthenticatedUser();
    }
}
 