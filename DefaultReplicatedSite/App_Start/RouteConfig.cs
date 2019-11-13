using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DefaultReplicatedSite
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapMvcAttributeRoutes();
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("fonts/{*pathInfo}");
            routes.IgnoreRoute("content/{*pathInfo}");
            routes.IgnoreRoute("scripts/{*pathInfo}");

            // Standard routing
            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { action = "index", id = UrlParameter.Optional },
            //    constraints: new { controller = @"(app|account|dev|error)" }
            //);
            routes.MapRoute(
                name: "Replicated",
                url: "{webalias}/{controller}/{action}/{id}",
                defaults: new { webalias = Settings.Site.DefaultWebalias, controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
