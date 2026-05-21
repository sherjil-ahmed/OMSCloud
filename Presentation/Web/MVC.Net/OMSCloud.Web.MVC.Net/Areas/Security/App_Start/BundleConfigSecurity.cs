using System.Web;
using System.Web.Optimization;

namespace OMSCloud.Web.MVC.Net.Areas.Public
{
    public class BundleConfigSecurity
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/security/jquery").Include(
                        "~/Areas/Security/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/security/jqueryval").Include(
                        "~/Areas/Security/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/security/modernizr").Include(
                        "~/Areas/Security/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/security/bootstrap").Include(
                      "~/Areas/Security/Scripts/bootstrap.js",
                      "~/Areas/Security/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Areas/Security/Content/bootstrap.css",
                      "~/Areas/Security/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/security/jqueryui").Include(
                        "~/Areas/Security/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/security/jqueryui-custom").Include(
                        "~/Areas/Security/Content/ui/jquery-ui-1.10.4.custom.css"));
        }
    }
}
//sherjil ahmed