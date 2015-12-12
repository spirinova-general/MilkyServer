using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using Blogger.Services.Blog;
using System.Reflection;
namespace Blogger.Web.Framework
{
    public class DependencyRegistrar
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
           // builder.RegisterControllers(typeof(MvcApplication).Assembly);
           

            builder.RegisterType<BlogService>().As<IBlogService>().InstancePerHttpRequest();
            IContainer container = builder.Build();
            System.Web.Mvc.DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}