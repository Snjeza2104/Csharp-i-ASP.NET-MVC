using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCRute
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("Home/DefaultnaRuta");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "DefaultnaRuta", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "VisestrukiParametriRuta",
                url: "{controller}/{action}/{param1}/{param2}",
                defaults: new {controller="Home", action="VisestrukiParametri", param1=UrlParameter.Optional, param2=UrlParameter.Optional}
                );
        }
    }
}
