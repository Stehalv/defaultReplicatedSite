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
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Replicated",
                url: "{webalias}/{controller}/{action}/{id}",
                defaults: new { webalias = Settings.Site.DefaultWebalias, controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
