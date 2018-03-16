using System.Web;
using System.Web.Optimization;

namespace WebApplication1
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/Js").Include(
                     "~/Content/bower_components/jquery/dist/jquery.min.js",
                     "~/Content/bower_components/bootstrap/dist/js/bootstrap.min.js",
                     "~/Content/bower_components/jquery-slimscroll/jquery.slimscroll.min.js",
                     "~/Content/bower_components/fastclick/lib/fastclick.js",
                     "~/Content/dist/js/adminlte.min.js",
                     "~/Content/bower_components/fastclick/lib/fastclick.js",
                      "~/Content/dist/js/demo.js"));


            bundles.Add(new StyleBundle("~/bundles/Css").Include(
                        "~/Content/bower_components/bootstrap/dist/css/bootstrap.min.css",
                        "~/Content/bower_components/font-awesome/css/font-awesome.min.css",
                        "~/Content/bower_components/Ionicons/css/ionicons.min.css",
                        "~/Content/dist/css/AdminLTE.min.css",
                        "~/Content/dist/css/skins/_all-skins.min.css",
                        "~/Content/Fondos/fondo_css.css",
                        "~/Content/dist/css/banner.css",
                        "~/Content/dist/css/horarios.css",
                        "~/Content/dist/css/info.css",
                        "~/Content/dist/css/quienes_somos.css",
                        "~/Content/dist/css/styles_ico.css"));

            BundleTable.EnableOptimizations = false;
        }

    }
}
