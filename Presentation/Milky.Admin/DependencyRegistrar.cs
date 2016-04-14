using Autofac;
using Autofac.Integration.Mvc;
using Blogger.Core.Infrastructures;
using Blogger.Data;
using Blogger.Services;
using System.Web;

namespace Milky.Admin
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
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            //Register DbContext
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerHttpRequest();
            builder.Register<ObjectContext>(c => new ObjectContext()).InstancePerHttpRequest();

            //Register Services
            builder.RegisterType<AccountService>().As<IAccountService>().InstancePerHttpRequest();
            builder.RegisterType<SmsService>().As<ISmsService>().InstancePerHttpRequest();
            builder.RegisterType<AccountAreaMappingService>().As<IAccountAreaMappingService>().InstancePerHttpRequest();
            builder.RegisterType<AreaService>().As<IAreaService>().InstancePerHttpRequest();
            builder.RegisterType<CityService>().As<ICityService>().InstancePerHttpRequest();
            builder.RegisterType<BillService>().As<IBillService>().InstancePerHttpRequest();
            builder.RegisterType<CustomerService>().As<ICustomerService>().InstancePerHttpRequest();
            builder.RegisterType<CustomerSettingService>().As<ICustomerSettingService>().InstancePerHttpRequest();
            builder.RegisterType<DeliveryService>().As<IDeliveryService>().InstancePerHttpRequest();
            builder.RegisterType<GlobalSettingService>().As<IGlobalSettingService>().InstancePerHttpRequest();
            builder.RegisterType<FormsAuthenticationService>().As<IAuthenticationService>().InstancePerRequest();
            builder.RegisterType<WebWorkContext>().As<IWorkContext>().InstancePerRequest();

            //builder.RegisterModule<ValidationModule>();
            IContainer container = builder.Build();
            System.Web.Mvc.DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
           // GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

        }
    }
}