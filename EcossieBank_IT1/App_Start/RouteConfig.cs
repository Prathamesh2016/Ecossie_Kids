using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EcossieBank_IT1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "About",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "About", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "Contact",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Contact", id = UrlParameter.Optional }
           );
            routes.MapRoute(
              name: "PlayGame",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Home", action = "ImageGame", id = UrlParameter.Optional }
          );
        }
    }
}
