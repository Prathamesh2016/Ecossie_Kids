using System.Web;
using System.Web.Optimization;

namespace EcossieBank_IT1
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
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            #region Template Design

            bundles.Add(new ScriptBundle("~/template/js").Include(
                       "~/Scripts/jquery-3.3.1.min.js",
                      "~/Scripts/jquery-migrate-3.0.1.min.js",
                      "~/Scripts/popper.min.js",
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/owl.carousel.min.js",
                      "~/Scripts/jquery.sticky.js",
                      "~/Scripts/jquery.waypoints.min.js",
                      "~/Scripts/jquery.animateNumber.min.js",
                      "~/Scripts/jquery.fancybox.min.js",
                      "~/Scripts/jquery.stellar.min.js",
                      "~/Scripts/jquery.easing.1.3.js",
                      "~/Scripts/bootstrap-datepicker.min.js",
                      "~/Scripts/aos.js",
                      "~/Scripts/main.js"
                       ));


            bundles.Add(new StyleBundle("~/template/css").Include(
               
                   "~/fonts/icomoon/style.css",
                      "~/Content/css/bootstrap.min.css",
                       "~/Content/css/bootstrap-datepicker.css",
                        "~/Content/css/jquery.fancybox.min.css",
                         "~/Content/css/owl.carousel.min.css",
                          "~/Content/css/owl.theme.default.min.css",
                           "~/Content/css/aos.css",
                           "~/fonts/flaticon/font/flaticon.css",
                           "~/Content/dist/index.min.js",
                            "~/Content/css/jquery-ui.min.css",
                           
                            //Main css
                           "~/Content/css/style.css",
                           "~/Content/Tips.css"



                            ));


            #endregion
        }
    }
}
