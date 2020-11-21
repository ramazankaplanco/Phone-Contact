#region 

using System.Web.Mvc;
using System.Web.Routing;

#endregion

namespace PhoneContact
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new {controller = "PublicUI", action = "Index", id = UrlParameter.Optional}
            );
        }
    }
}