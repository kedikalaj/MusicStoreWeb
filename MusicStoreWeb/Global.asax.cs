using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MusicStore.Domain.Entities;
using MusicStoreWeb.Infrastructure.Binders;
using System.Web.Optimization;
using MusicStoreWeb.App_Start;

namespace MusicStoreWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());

            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
