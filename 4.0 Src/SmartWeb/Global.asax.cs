using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SmartWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           );
        }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Application["OnLine"] = 0;
            Application["Count"] = 0;
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Application.Lock();
            Application["OnLine"] = (int)Application["OnLine"] + 1;
            Application["Count"] = (int)Application["Count"] + 1;
            var t = Request.Url.ToString();
            Application.UnLock();

        }

        protected void Session_End(object sender, EventArgs e)
        {
            Application.Lock();
            if (Convert.ToInt32(Application["OnLine"]) > 0)
            {
                Application["OnLine"] = Convert.ToInt32(Application["OnLine"]) - 1;
            }
            Application.UnLock();
        }
    }
}