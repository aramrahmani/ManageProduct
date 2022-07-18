using Sample.Data;
using Sample.Web.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Sample.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            // Init database
           // System.Data.Entity.Database.SetInitializer(new SampleSeedData());


            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // Autofac and Automapper configurations
            Bootstrapper.Run();
        }
    }
}
