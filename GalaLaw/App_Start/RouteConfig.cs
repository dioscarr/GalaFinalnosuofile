using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GalaLaw
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {






            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

      

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }, namespaces: new string[] { "GalaLaw.Controllers" }
            );

            routes.MapRoute(
    name: "MembersDef",
    url: "{controller}/{action}/{id}/{FID}/{Country}",
    defaults: new { controller = "Members", action = "member", id = UrlParameter.Optional, FID = UrlParameter.Optional, Country= UrlParameter.Optional }, namespaces: new string[] { "GalaLaw.Controllers" }
);




        }
    }
}
