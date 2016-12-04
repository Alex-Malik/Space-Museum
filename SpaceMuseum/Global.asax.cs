using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;

namespace SpaceMuseum
{
    using Autofac.Integration.Mvc;
    using Data;
    using Services;

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            //
            // First we neet to register all server stuff, configure DB and routing
            //
            DatabaseConfigurator.Configure();

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //
            // Second we need to setup AutoFac container and types resolver
            //
            ContainerBuilder builder = new ContainerBuilder();
            
            // Register controllers
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // Register database context
            builder.RegisterType<DatabaseContext>().AsSelf().CacheInSession();

            // Register services
            builder.RegisterType<EventsService>().AsSelf().InstancePerDependency();
            builder.RegisterType<ExhibitsService>().AsSelf().InstancePerDependency();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
