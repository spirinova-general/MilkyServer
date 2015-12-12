using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blogger.Web.Framework.Mvc
{
    public interface IDependencyResolver
        {
            // Summary:
            //     Resolves singly registered services that support arbitrary object creation.
            //
            // Parameters:
            //   serviceType:
            //     The type of the requested service or object.
            //
            // Returns:
            //     The requested service or object.
            object GetService(Type serviceType);
            //
            // Summary:
            //     Resolves multiply registered services.
            //
            // Parameters:
            //   serviceType:
            //     The type of the requested services.
            //
            // Returns:
            //     The requested services.
            IEnumerable<object> GetServices(Type serviceType);
        }
    
}

