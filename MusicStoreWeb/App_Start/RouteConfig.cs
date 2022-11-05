using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MusicStoreWeb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(null,
            "",
            new
            {
                controller = "Music",
                action = "List",
                category = (int)0, 
                page = 1
            }
            );

                routes.MapRoute(null,
                "{category}",
                new { controller = "Music", action = "List", category = (int)0 },
                new { page = @"\d+" }
 );
            routes.MapRoute(null,
            "{category}",
            new { controller = "Music", action = "List", page = 1 }
            );
            routes.MapRoute(null,
            "{category}/Page{page}",
            new { controller = "Music", action = "List" },
            new { page = @"\d+" }
            );
            routes.MapRoute(null, "{controller}/{action}");
        }
    }
}