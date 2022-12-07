using System.Web;
using System.Web.Optimization;

namespace Metalkit
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información sobre los formularios.  De esta manera estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

           

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/animate.css",
                      "~/Content/site.css"));

             bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));
            bundles.Add(new ScriptBundle("~/bundles/datatablesjs").Include(
               "~/Scripts/DataTables/jquery.dataTables.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/datatablescss").Include(
                        "~/Content/DataTables/jquery.datatables.css"));
            bundles.Add(new ScriptBundle("~/bundles/tema").Include(
                    "~/Scripts/metisMenu.min.js",
                    //"~/Scripts/plugins/pace/pace.min.js",
                    "~/Scripts/inspinia.js"));
            bundles.Add(new ScriptBundle("~/bundles/inspinia").Include(
                "~/Scripts/metisMenu.min.js",
                //"~/Scripts/plugins/pace/pace.min.js",
                "~/Scripts/inspinia.js"));

            bundles.Add(new ScriptBundle("~/bundles/skinConfig").Include(
                "~/Scripts/skin.config.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/comunes").Include(
                "~/Scripts/htmlHelper.js",
                "~/Scripts/funcionesGenerales.js"));
            BundleTable.EnableOptimizations = true;

        }
    }
}
