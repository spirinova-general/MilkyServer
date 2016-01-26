using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Blogger.Core.Infrastructures;
using Blogger.Data;
using Blogger.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Contacts.Web
{
    public class DependencyRegistrar
    {
        public static void RegisterDependencies()
        {
            EngineContext.Current.ContainerManager.UpdateContainer(x =>
            {
                Register(new ContainerBuilder());
            });
        }

        private static void Register(ContainerBuilder builder)
        {

            //HTTP context and other related stuff
            builder.RegisterModule(new AutofacWebTypesModule());

            //Register Controller
            builder.RegisterAssemblyTypes(
              typeof(WebApiApplication).Assembly
                 ).PropertiesAutowired();
            builder.RegisterControllers(typeof(WebApiApplication).Assembly);

            builder.RegisterApiControllers(typeof(WebApiApplication).Assembly);


            //Register DbContext
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerRequest();
            builder.Register<ObjectContext>(c => new ObjectContext()).InstancePerRequest();

            //Register Services
            builder.RegisterType<AccountService>().As<IAccountService>().InstancePerRequest();
            builder.RegisterType<AccountAreaMappingService>().As<IAccountAreaMappingService>().InstancePerRequest();
            builder.RegisterType<AreaService>().As<IAreaService>().InstancePerRequest();
            builder.RegisterType<CityService>().As<ICityService>().InstancePerRequest();
            builder.RegisterType<BillService>().As<IBillService>().InstancePerRequest();
            builder.RegisterType<CustomerService>().As<ICustomerService>().InstancePerRequest();
            builder.RegisterType<CustomerSettingService>().As<ICustomerSettingService>().InstancePerRequest();
            builder.RegisterType<DeliveryService>().As<IDeliveryService>().InstancePerRequest();
            builder.RegisterType<GlobalSettingService>().As<IGlobalSettingService>().InstancePerRequest();


            //builder.RegisterModule<ValidationModule>();
            IContainer container = builder.Build();
            System.Web.Mvc.DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

        }
    }
}