using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Nop.Web.Framework.Mvc;
using Nop.Web.Framework.Mvc.Routes;
using QuanLyKho.Core.Infrastructure;

namespace QuanLyKho.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("favicon.ico");
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //register custom routes (plugins, etc)
            var routePublisher = EngineContext.Current.Resolve<IRoutePublisher>();
            routePublisher.RegisterRoutes(routes);

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "Nop.Web.Controllers" }
            );
        }

        protected void Application_Start()
        {
            //disable "X-AspNetMvc-Version" header name
            MvcHandler.DisableMvcResponseHeader = true;

            //initialize engine context
            EngineContext.Initialize(false);

            //Registering some regular mvc stuff
            AreaRegistration.RegisterAllAreas();
            RegisterRoutes(RouteTable.Routes);
         
        }
    }
}
