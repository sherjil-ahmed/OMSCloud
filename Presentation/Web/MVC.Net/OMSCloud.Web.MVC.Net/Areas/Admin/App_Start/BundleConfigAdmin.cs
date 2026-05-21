using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace OMSCloud.Web.MVC.Net.Areas.Admin
{
    public class BundleConfigAdmin
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/Admin/jquery").Include(
                "~/Areas/admin/Contents/assets/vendor/jquery/jquery.js",
                "~/Areas/admin/Contents/assets/vendor/jquery-browser-mobile/jquery.browser.mobile.js",
                "~/Areas/admin/Contents/assets/vendor/jquery-cookie/jquery-cookie.js",
                "~/Areas/admin/Contents/assets/vendor/style-switcher/style.switcher.js",
                "~/Areas/admin/Contents/assets/vendor/nanoscroller/nanoscroller.js",
                "~/Areas/admin/Contents/assets/vendor/magnific-popup/jquery.magnific-popup.js",
                "~/Areas/admin/Contents/assets/vendor/jquery-placeholder/jquery-placeholder.js",
                "~/Areas/admin/Contents/assets/vendor/jquery-ui/jquery-ui.js",
                "~/Areas/admin/Contents/assets/vendor/jqueryui-touch-punch/jqueryui-touch-punch.js",
                "~/Areas/admin/Contents/assets/vendor/jquery-appear/jquery-appear.js",
                "~/Areas/admin/Contents/assets/vendor/jquery.easy-pie-chart/jquery.easy-pie-chart.js",
                "~/Areas/admin/Contents/assets/vendor/raphael/raphael.js",
                "~/Areas/admin/Contents/assets/vendor/morris.js/morris.js",
                "~/Areas/admin/Contents/assets/vendor/gauge/gauge.js",
                "~/Areas/admin/Contents/assets/vendor/snap.svg/snap.svg.js",
                "~/Areas/admin/Contents/assets/vendor/liquid-meter/liquid.meter.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/Admin/flot/jquery").Include(

                "~/Areas/admin/Contents/assets/vendor/flot/jquery.flot.js",
                "~/Areas/admin/Contents/assets/vendor/flot.tooltip/flot.tooltip.js",
                "~/Areas/admin/Contents/assets/vendor/flot/jquery.flot.pie.js",
                "~/Areas/admin/Contents/assets/vendor/flot/jquery.flot.categories.js",
                "~/Areas/admin/Contents/assets/vendor/flot/jquery.flot.resize.js"
                ));


            bundles.Add(new ScriptBundle("~/bundles/Admin/jqvmap/jquery").Include(
                "~/Areas/admin/Contents/assets/vendor/jqvmap/jquery.vmap.js",
                "~/Areas/admin/Contents/assets/vendor/jqvmap/data/jquery.vmap.sampledata.js",
                "~/Areas/admin/Contents/assets/vendor/jqvmap/maps/jquery.vmap.world.js",
                "~/Areas/admin/Contents/assets/vendor/jqvmap/maps/continents/jquery.vmap.africa.js",
                "~/Areas/admin/Contents/assets/vendor/jqvmap/maps/continents/jquery.vmap.asia.js",
                "~/Areas/admin/Contents/assets/vendor/jqvmap/maps/continents/jquery.vmap.australia.js",
                "~/Areas/admin/Contents/assets/vendor/jqvmap/maps/continents/jquery.vmap.europe.js",
                "~/Areas/admin/Contents/assets/vendor/jqvmap/maps/continents/jquery.vmap.north-america.js",
                "~/Areas/admin/Contents/assets/vendor/jqvmap/maps/continents/jquery.vmap.south-america.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/Admin/bootstrap/jquery").Include(
                "~/Areas/admin/Contents/assets/vendor/bootstrap/js/bootstrap.js",
                "~/Areas/admin/Contents/assets/vendor/bootstrap-datepicker/js/bootstrap-datepicker.js",
                "~/Areas/admin/Contents/assets/vendor/bootstrap-multiselect/bootstrap-multiselect.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/Admin/theme/javascripts").Include(
                "~/Areas/admin/Contents/assets/javascripts/theme.js",
                "~/Areas/admin/Contents/assets/javascripts/theme.custom.js",
                 "~/Areas/admin/Contents/assets/javascripts/theme.init.js",
                 "~/Areas/admin/Contents/assets/javascripts/dashboard/examples.dashboard.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/Admin/Mics").Include(
                //"~/Areas/admin/Contents/assets/Mics/jquery-3.1.1.min.js", 
                "~/Areas/admin/Contents/assets/Mics/ImageDisplay.js",
                "~/Scripts/jquery.validate*"
                ));
        }
    }
}