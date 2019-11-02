using System.Web.Mvc;

namespace DefaultReplicatedSite.Areas.Luxxium
{
    public class LuxxiumAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Luxxium";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Luxxium_default",
                "Luxxium/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}