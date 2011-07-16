using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Configuration;

namespace jQueryMobileTemplate
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        // Debug override option. 
        // TODO: pull from appsettings?
        private static bool? _isDebug;

        /// <summary>
        /// Value indicating whether this app should be in debug mode.
        /// NOTE: This is used in the layout to determine whether or not we reference our minified script and css.
        /// </summary>        
        public static bool IsDebug
        {
            get
            {
                // Get a value indicating whether we are built in debug or not.
                var buildIsDebug =
#if DEBUG
                       true;
#else
 false;
#endif
                // If we have an override, return it, otherwise return the build condition.
                return _isDebug.HasValue ? _isDebug.Value : buildIsDebug;
            }
        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}