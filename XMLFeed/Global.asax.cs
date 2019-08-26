using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using XMLFeed.App_Start;

namespace XMLFeed
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutofacConfig.RegisterAutofac();
        }
    }
}
