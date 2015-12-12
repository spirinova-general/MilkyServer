
using Blogger.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Blogger.Services;
using Autofac.Core;
using Blogger.Core.Infrastructures;
using Autofac;
using System.Web.Routing;
namespace Blogger.Web.Framework.Security
{
    //[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class BloggerHttpsRequirementAttribute : IAuthorizationFilter
    {

        public BloggerHttpsRequirementAttribute()
        {
        }

        public virtual void OnAuthorization(AuthorizationContext filterContext)
        {
            ////Use customer Service from here
            //var customerService = EngineContext.Current.Resolve<ICustomerService>();
            //var authenticationService = EngineContext.Current.Resolve<IAuthenticationService>();
            //var registeredRole = customerService.GetCustomerRoleBySystemName(SystemCustomerRoleNames.Registered);
            //var customer = authenticationService.GetAuthenticatedCustomer();
            //if (customer == null)
            //{
            //    filterContext.Result = new HttpUnauthorizedResult();
            //}
            //else
            //{ 
            //    foreach(var customerRole in customer.CustomerRoles)
            //    {
            //        if(customerRole.Name == registeredRole.Name)
            //        {
            //            return;
            //        }
            //    }
            //}
         
        }

        
    }
}