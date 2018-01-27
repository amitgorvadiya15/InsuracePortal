using System.Web;
using System.Web.Optimization;

namespace InsurancePortal.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Content/DataTables/datatables.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/default.css",
                      "~/Content/DataTables/datatables.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/Admin/css").Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/Admin/Theme/base/css").Include(
                        "~/Content/Admin/Theme/base/jquery.ui.core.css",
                        "~/Content/Admin/Theme/base/jquery.ui.resizable.css",
                        "~/Content/Admin/Theme/base/jquery.ui.selectable.css",
                        "~/Content/Admin/Theme/base/jquery.ui.accordion.css",
                        "~/Content/Admin/Theme/base/jquery.ui.autocomplete.css",
                        "~/Content/Admin/Theme/base/jquery.ui.button.css",
                        "~/Content/Admin/Theme/base/jquery.ui.dialog.css",
                        "~/Content/Admin/Theme/base/jquery.ui.slider.css",
                        "~/Content/Admin/Theme/base/jquery.ui.tabs.css",
                        "~/Content/Admin/Theme/base/jquery.ui.datepicker.css",
                        "~/Content/Admin/Theme/base/jquery.ui.progressbar.css",
                        "~/Content/Admin/Theme/base/jquery.ui.theme.css"));
            bundles.Add(new ScriptBundle("~/bundles/Admin/vendors").Include(
                "~/Content/Admin/Theme/vendors/uniform/jquery.uniform.js"
                , "~/Content/Admin/Theme/vendors/chosen.jquery.js"
                , "~/Content/Admin/Theme/vendors/bootstrap-datepicker/js/bootstrap-datepicker.js"
                , "~/Content/Admin/Theme/vendors/bootstrap-wysihtml5-rails-b3/vendor/assets/javascripts/bootstrap-wysihtml5/wysihtml5.js"
                , "~/Content/Admin/Theme/vendors/bootstrap-wysihtml5-rails-b3/vendor/assets/javascripts/bootstrap-wysihtml5/core-b3.js"
                , "~/Content/Admin/Theme/vendors/twitter-bootstrap-wizard/jquery.bootstrap.wizard-for.bootstrap3.js"
                , "~/Content/Admin/Theme/vendors/boostrap3-typeahead/bootstrap3-typeahead.js"
                , "~/Content/Admin/Theme/vendors/easypiechart/jquery.easy-pie-chart.js"
                , "~/Content/Admin/Theme/vendors/ckeditor/ckeditor.js"
                , "~/Content/Admin/Theme/vendors/tinymce/js/tinymce/tinymce.js"
                , "~/Content/Admin/Theme/vendors/bootstrap-wysihtml5-rails-b3/vendor/assets/javascripts/bootstrap-wysihtml5/wysihtml5.js"
                , "~/Content/Admin/Theme/vendors/bootstrap-wysihtml5-rails-b3/vendor/assets/javascripts/bootstrap-wysihtml5/core-b3.js"
                , "~/Content/Admin/Theme/vendors/jGrowl/jquery.jgrowl.js"
                , "~/Content/Admin/Theme/vendors/bootstrap-datepicker/js/bootstrap-datepicker.js"
                , "~/Content/Admin/Theme/vendors/sparkline/jquery.sparkline.js"
                , "~/Content/Admin/Theme/vendors/tablesorter/js/jquery.tablesorter.js"
                , "~/Content/Admin/Theme/vendors/flot/jquery.flot.js"
                , "~/Content/Admin/Theme/vendors/flot/jquery.flot.selection.js"
                , "~/Content/Admin/Theme/vendors/flot/jquery.flot.resize.js"
                , "~/Content/Admin/Theme/vendors/fullcalendar/fullcalendar.js"
                               ));

            bundles.Add(new StyleBundle("~/Content/Admin/Theme").Include(
          "~/Content/Admin/bootstrap.css",
          "~/Content/Admin/bootstrap-theme.css",
          "~/Content/Admin/Theme/css/bootstrap-admin-theme.css",
           "~/Content/Admin/Theme/css/site.css"));

            bundles.Add(new StyleBundle("~/Content/Admin/Vendors").Include(
                "~/Content/Admin/Theme/vendors/bootstrap-datepicker/css/datepicker.css"
   , "~/Content/Admin/Theme/css/datepicker.fixes.css"
   , "~/Content/Admin/Theme/vendors/uniform/themes/default/css/uniform.default.min.css"
   , "~/Content/Admin/Theme/css/uniform.default.fixes.css"
   , "~/Content/Admin/Theme/vendors/chosen.min.css"
   , "~/Content/Admin/Theme/vendors/bootstrap-wysihtml5-rails-b3/vendor/assets/stylesheets/bootstrap-wysihtml5/core-b3.css"
   , "~/Content/Admin/Theme/vendors/easypiechart/jquery.easy-pie-chart.css"
   , "~/Content/Admin/Theme/vendors/easypiechart/jquery.easy-pie-chart_custom.css"
   , "~/Content/Admin/Theme/vendors/bootstrap-wysihtml5-rails-b3/vendor/assets/stylesheets/bootstrap-wysihtml5/core-b3.css"
   , "~/Content/Admin/Theme/vendors/jGrowl/jquery.jgrowl.css"
   , "~/Content/Admin/Theme/vendors/bootstrap-datepicker/css/datepicker.css"
    , "~/Content/Admin/Theme/vendors/fullcalendar/fullcalendar.css"));

            bundles.Add(new StyleBundle("~/Content/Admin/Theme/Default").Include(
                      "~/Content/DataTables/datatables.css",
                      "~/Content/Admin/bower_components/bootstrap/dist/css/bootstrap.min.css", //Bootstrap 3.3.7
                      "~/Content/Admin/bower_components/font-awesome/css/font-awesome.min.css", //Font Awesome
                      "~/Content/Admin/bower_components/Ionicons/css/ionicons.min.css", //Ionicons
                      "~/Content/Admin/dist/css/AdminLTE.min.css", //Theme style
                      "~/Content/Admin/dist/css/skins/_all-skins.min.css", //AdminLTE Skins. Choose a skin from the css/skins folder instead of downloading all of them to reduce the load.
                      "~/Content/Admin/bower_components/jvectormap/jquery-jvectormap.css", //jvectormap
                      "~/Content/Admin/bower_components/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css", //Date Picker
                      "~/Content/Admin/bower_components/bootstrap-daterangepicker/daterangepicker.css", //Daterange picker
                      "~/Content/Admin/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css ")); //bootstrap wysihtml5 - text editor

            bundles.Add(new ScriptBundle("~/bundles/Admin/Jquery").Include(
                "~/Content/Admin/bower_components/jquery-ui/jquery-ui.min.js", //jQuery UI 1.11.4+632
                "~/Content/Admin/bower_components/bootstrap/dist/js/bootstrap.min.js", //Bootstrap 3.3.7
                "~/Content/Admin/bower_components/jquery-sparkline/dist/jquery.sparkline.min.js",//Sparkline
                "~/Content/Admin/plugins/jvectormap/jquery-jvectormap-1.2.2.min.js",//jvectormap
                "~/Content/Admin/plugins/jvectormap/jquery-jvectormap-world-mill-en.js",
                "~/Content/Admin/bower_components/jquery-knob/dist/jquery.knob.min.js",//jQuery Knob Chart
                "~/Content/Admin/bower_components/moment/min/moment.min.js",//daterangepicker
                "~/Content/Admin/bower_components/bootstrap-daterangepicker/daterangepicker.js",
                "~/Content/Admin/bower_components/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js",//datepicker
                "~/Content/Admin/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js",//Bootstrap WYSIHTML5
                "~/Content/Admin/bower_components/jquery-slimscroll/jquery.slimscroll.min.js",//Slimscroll
                "~/Content/Admin/bower_components/fastclick/lib/fastclick.js",//FastClick
                "~/Content/Admin/dist/js/adminlte.min.js",//AdminLTE App
                "~/Content/Admin/dist/js/pages/dashboard.js",//AdminLTE dashboard demo (This is only for demo purposes)
                "~/Content/Admin/dist/js/demo.js"//AdminLTE for demo purposes
                ));
        }
    }
}
