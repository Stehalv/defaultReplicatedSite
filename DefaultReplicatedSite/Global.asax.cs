using DefaultReplicatedSite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity.Mvc5;

namespace DefaultReplicatedSite
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            UnityConfig.RegisterComponents();
        }
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            //if (Request.IsSecureConnection)
            //{
            //    Response.AddHeader("Strict-Transport-Security", "max-age=31536000");
            //}

            //// Get the route data
            //var routeData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(HttpContext.Current));

            //// Account for attribute routing and null routeData
            //if (routeData != null && routeData.Values.ContainsKey("MS_DirectRouteMatches"))
            //{
            //    routeData = ((List<RouteData>)routeData.Values["MS_DirectRouteMatches"]).First();
            //}

            //// If we have an identity and the current identity matches the web alias in the routes, stop here.
            //var identity = HttpContext.Current.Items["OwnerWebIdentity"] as UserIdentity;

            //if (!Request.IsLocal && Request.Url.Host != "aregoreplicatedsite.azurewebsites.net" && Request.Url.Host != "repsitedevelopment.azurewebsites.net")
            //{
            //    if (!HttpContext.Current.Request.Url.AbsoluteUri.Contains(".axd") &&
            //        !HttpContext.Current.Request.Url.AbsoluteUri.ToLower().Contains("bundles"))
            //    {
            //        if (routeData != null)
            //        {
            //            var host = HttpContext.Current.Request.Url.Host.Split('.');
            //            if (HttpContext.Current.Request.Url.Host == GlobalSettings.Company.ReplicatedHost)
            //            {
            //                routeData.Values["webalias"] = Settings.Site.DefaultWebalias;
            //            }
            //            else
            //            {
            //                routeData.Values["webalias"] = HttpContext.Current.Request.Url.Host.Split('.')[0];
            //            }
            //        }
            //    }
            //}

            //if (routeData == null
            //    || routeData.Values["webalias"] == null
            //    || (identity != null && identity.WebAlias.Equals(routeData.Values["webalias"].ToString(), StringComparison.InvariantCultureIgnoreCase)))
            //{
            //    return;
            //}


            //// Determine some web alias data
            //var urlHelper = new UrlHelper(new RequestContext(new HttpContextWrapper(HttpContext.Current), RouteTable.Routes.GetRouteData(new HttpContextWrapper(HttpContext.Current))));
            //var currentWebAlias = routeData.Values["webalias"].ToString();
            //var defaultWebAlias = Settings.Site.DefaultWebalias;
            //var defaultPage = urlHelper.Action(routeData.Values["action"].ToString(), routeData.Values["controller"].ToString(), new { webalias = lastWebAlias });


            //// This ensures that if the page is redirected because of web alias switching, that athe querystring params are passed as well
            //if (currentWebAlias.ToLower() == Settings.Site.DefaultWebalias.ToLower())
            //{
            //    // Create new route value dictionary
            //    var newList = new RouteValueDictionary();

            //    // Pull in all values that are not the controller,action or webalias
            //    foreach (var routeValue in routeData.Values.Where(c => c.Key != "action" && c.Key != "controller" && c.Key != "webalias"))
            //    {
            //        // Add all values that arent empty to the route data.
            //        if (routeValue.Value.ToString().IsNotNullOrEmpty())
            //        {
            //            newList.Add(routeValue.Key, routeValue.Value);
            //        }
            //    }
            //    // Grab query in case there are any pieces being sent in with ?example=value
            //    var query = Request.Url.Query;

            //    // create new url using new route values and add the query at the end.
            //    defaultPage = urlHelper.Action(routeData.Values["action"].ToString(), routeData.Values["controller"].ToString(), newList) + query;
            //}


            //// If we are an orphan and we don't allow them, redirect to a capture page.
            //if (!Settings.Site.AllowOrphans && currentWebAlias.Equals(defaultWebAlias, StringComparison.InvariantCultureIgnoreCase))
            //{
            //    HttpContext.Current.Response.Redirect(urlHelper.Action("webaliasrequired", "error"));
            //}




            //// Attempt to authenticate the web alias
            //var identityService = new IdentityService();
            //HttpContext.Current.Items["OwnerWebIdentity"] = identityService.GetIdentity(currentWebAlias);
            //if (HttpContext.Current.Items["OwnerWebIdentity"] == null)
            //{ 
            //    HttpContext.Current.Response.Redirect(urlHelper.Action("invalidwebalias", "error"));
            //}
        }
    }
}
