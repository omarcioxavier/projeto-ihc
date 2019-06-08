using System.Web.Optimization;

namespace colorcom
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery.min.js",
                "~/Scripts/jquery-{version}.min.js",
                "~/Scripts/DataTables/jquery.dataTables.js",
                "~/Scripts/DataTables/dataTables.bootstrap.js",
                "~/Scripts/dashboard.js",
                "~/Scripts/main.js",
                "~/Scripts/widget.js",
                "~/Scripts/Chart.min.js",
                "~/Scripts/popper.min.js",
                "~/Scripts/bootbox.min.js",
                "~/Scripts/bootbox.locales.min.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/chosen.css",
                "~/Content/font-awesome.min.css",
                "~/Content/bootstrap.min.css",
                "~/Content/DataTables/dataTables.bootstrap4.min.css",
                "~/Content/DataTables/buttons.bootstrap4.min.css",
                "~/Content/themify-icons/css/themify-icons.css",
                "~/Content/style.css"));

            //bundles.Add(new StyleBundle("~/Scripts/DataTables").Include(
            //    "~/Scripts/DataTables/dataTables.buttons.min.js",
            //    "~/Scripts/DataTables/jquery.dataTables.js",
            //    "~/Scripts/DataTables/buttons.bootstrap4.min.js",
            //    "~/Scripts/DataTables/buttons.html5.min.js",
            //    "~/Scripts/DataTables/buttons.print.min.js",
            //    "~/Scripts/DataTables/buttons.colVis.min.js",
            //    "~/Scripts/DataTables/datatables-init.js",
            //    "~/Scripts/DataTables/dataTables.bootstrap4.min.js"));
        }
    }
}
