using System.Web.Optimization;

namespace BAP.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Site JavaScripts
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/themes/base/js/jquery-1.10.2.min.js"));
			
			bundles.Add(new ScriptBundle("~/bundles/intense").Include(
					  "~/Content/themes/base/js/core.min.js",
					  "~/Content/themes/base/js/script.js"));

			// Site Styles 
			bundles.Add(new StyleBundle("~/Content/css").Include(
					  "~/Content/Themes/Base/css/style.css",
					  "~/Content/Themes/Base/css/site.css"));
			           
        }
    }
}
