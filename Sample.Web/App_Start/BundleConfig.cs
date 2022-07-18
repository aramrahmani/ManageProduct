using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Sample.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/css/main").Include(
                "~/Content/css/site.css"));

            bundles.Add(new StyleBundle("~/css/plugin").Include(
                "~/Content/plugin/bootstrap/css/bootstrap.min.css",
                "~/Content/plugin/font-awesome/css/font-awesome.min.css",
                "~/Content/plugin/DataTables/datatables.min.css" ));

            bundles.Add(new ScriptBundle("~/js/all").Include(
              "~/Content/plugin/jquery/dist/jquery.js",
              "~/Content/plugin/bootstrap/js/bootstrap.bundle.min.js",
              "~/Content/plugin/DataTables/datatables.min.js",
              "~/Content/js/product.js",
              "~/Content/js/site.js"));

            BundleTable.EnableOptimizations = false;
        }
    }
}