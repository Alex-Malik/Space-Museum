using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SpaceMuseum
{
    using Data;

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            DatabaseConfigurator.Configure();

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
