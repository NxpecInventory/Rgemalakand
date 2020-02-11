using System.Web;
using System.Web.Optimization;

namespace RGECMS
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                     "~/Content/style.min.css", "~/Content/themify-icons.css", "~/Content/materialdesignicons.min.css", "~/Content/Site.css", "~/Content/bootstrap-grid.min.css", "~/Content/material-design-iconic-font.min.css"));
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
     

            bundles.Add(new ScriptBundle("~/bundles/Scripts1").Include(
                //first scripts 
  "~/Scripts/jquery.min.js", "~/Scripts/popper.min.js", "~/Scripts/custom.min.js"));
            //second scripts 
            bundles.Add(new ScriptBundle("~/bundles/Scripts2").Include(

 "~/Scripts/bootstrap.min.js", "~/Scripts/perfect-scrollbar.jquery.min.js", "~/Scripts/waves.js", "~/Scripts/sidebarmenu.js"));
           

           
        }
    }
}
