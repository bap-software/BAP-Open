using System.Web.Optimization;

namespace BAP.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Web site wide bundles =========================================================================
            // Site JavaScripts
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/Themes/Base/assets/plugins/jquery/jquery-3.2.1.min.js",
                        "~/Content/themes/base/assets/plugins/jquery/jquery-migrate-1.1.0.min.js",
                        "~/Content/themes/base/assets/plugins/bootstrap/js/bootstrap.min.js",
                        "~/Content/themes/base/assets/js/site.js"));
            //Site Plugins
            bundles.Add(new ScriptBundle("~/bundles/plugins").Include(
                      "~/Content/themes/base/assets/plugins/jquery-cookie/jquery.cookie.js",
                      "~/Content/themes/base/assets/plugins/scrollMonitor/scrollMonitor.js",
                      "~/Content/themes/base/assets/plugins/select2/dist/js/select2.js",
                      "~/Content/themes/base/assets/js/apps.min.js",
                      "~/Content/themes/base/assets/js/back-to-top.js"));

            //Pace has to be separate
            bundles.Add(new ScriptBundle("~/bundles/pace").Include(
                      "~/Content/themes/base/assets/plugins/pace/pace.min.js"));
            
            // Site styles 
            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/themes/base/assets/plugins/bootstrap/css/bootstrap.min.css",
                        "~/Content/themes/base/assets/plugins/font-awesome/css/font-awesome.min.css",                       
                        "~/Content/themes/base/assets/css/animate.min.css",
                        "~/Content/themes/base/assets/css/user-login.css",
                        "~/Content/themes/base/assets/css/style.min.css",
                        "~/Content/themes/base/assets/css/style-responsive.min.css",
                        "~/Content/themes/base/assets/css/theme/default.css",
                        "~/Content/themes/base/assets/css/back-to-top.css",
                        "~/Content/flag-icon.min.css"));

            //Admin bundles =======================================================================================            
            bundles.Add(new StyleBundle("~/Admin/Plugins/css").Include(
                "~/Areas/Administration/Content/Themes/assets/plugins/jquery-ui/themes/base/minified/jquery-ui.min.css",
                "~/Areas/Administration/Content/Themes/assets/plugins/bootstrap/css/bootstrap.min.css",
                "~/Areas/Administration/Content/Themes/assets/plugins/font-awesome/css/font-awesome.min.css",
                "~/Areas/Administration/Content/Themes/assets/plugins/bootstrap/css/bootstrap-formhelpers.css",
                "~/Areas/Administration/Content/Themes/assets/plugins/jquery-jvectormap/jquery-jvectormap.css",
                "~/Areas/Administration/Content/Themes/assets/plugins/bootstrap-datepicker/css/bootstrap-datepicker.css",
                "~/Areas/Administration/Content/Themes/assets/plugins/jstree/dist/themes/default/style.min.css",
                "~/Areas/Administration/Content/Themes/assets/plugins/dropzone/min/dropzone.min.css",
                "~/Areas/Administration/Content/Themes/assets/plugins/bootstrap-datepicker/css/bootstrap-datepicker.css",
                "~/Areas/Administration/Content/Themes/assets/plugins/bootstrap-datepicker/css/bootstrap-datepicker3.css",
                "~/Areas/Administration/Content/Themes/assets/plugins/bootstrap-timepicker/css/bootstrap-timepicker.min.css",
                "~/Areas/Administration/Content/Themes/assets/plugins/bootstrap-select/bootstrap-select.min.css",
                "~/Areas/Administration/Content/Themes/assets/plugins/bootstrap-eonasdan-datetimepicker/build/css/bootstrap-datetimepicker.min.css",
                "~/Areas/Administration/Content/Themes/assets/plugins/bootstrap-daterangepicker/daterangepicker.css",
                "~/Areas/Administration/Content/Themes/assets/plugins/parsley/src/parsley.css",
                "~/Areas/Administration/Content/Themes/assets/plugins/DataTables/media/css/dataTables.bootstrap.min.css",
                "~/Content/themes/base/assets/plugins/select2/dist/css/select2.css"                
                ));

            bundles.Add(new StyleBundle("~/Admin/Themes/css").Include(
                "~/Areas/Administration/Content/Themes/assets/css/animate.min.css",
                "~/Areas/Administration/Content/Themes/assets/css/style.css",
                "~/Areas/Administration/Content/Themes/assets/css/style-responsive.min.css",
                "~/Areas/Administration/Content/Themes/assets/css/theme/default.css",
                "~/Areas/Administration/Content/themes/assets/css/DataWizardStyle.css",
                "~/Areas/Administration/Content/themes/assets/css/localization/index.css",
                "~/Areas/Administration/Content/themes/assets/css/localization/edit.css",
                "~/Content/jsoneditor/jsoneditor.min.css"
                ));

            bundles.Add(new ScriptBundle("~/Admin/top-scripts").Include(
                "~/Areas/Administration/Content/Themes/assets/plugins/jquery/jquery-1.9.1.min.js",                
                "~/Areas/Administration/Content/Themes/assets/plugins/jquery/jquery.validate.min.js",
                "~/Areas/Administration/Content/Themes/assets/plugins/jquery/jquery.validate.unobtrusive.min.js",
                "~/Areas/Administration/Content/Themes/assets/plugins/pace/pace.min.js",
                "~/Scripts/jsoneditor/jsoneditor.min.js",
                "~/Scripts/tinymce/tinymce.min.js",
                "~/Content/themes/base/assets/js/site.js"
                ));

            bundles.Add(new ScriptBundle("~/Admin/jquery").Include(
                "~/Areas/Administration/Content/Themes/assets/plugins/jquery/jquery-migrate-1.1.0.min.js",
                "~/Areas/Administration/Content/Themes/assets/plugins/jquery-ui/ui/minified/jquery-ui.min.js",
                "~/Areas/Administration/Content/Themes/assets/plugins/jquery-cookie/jquery.cookie.js",
                "~/Areas/Administration/Content/Themes/assets/plugins/jquery-jvectormap/jquery-jvectormap.min.js",
                "~/Areas/Administration/Content/Themes/assets/plugins/jquery-jvectormap/jquery-jvectormap-world-mill-en.js",
                "~/Areas/Administration/Content/Themes/assets/plugins/jquery-tag-it/js/tag-it.min.js",
                "~/Areas/Administration/Content/Themes/assets/plugins/jquery-simplecolorpicker/jquery.simplecolorpicker.js"
                ));

            bundles.Add(new ScriptBundle("~/Admin/bootstrap").Include(
                "~/Areas/Administration/Content/Themes/assets/plugins/bootstrap/js/bootstrap.min.js",
                "~/Areas/Administration/Content/Themes/assets/plugins/bootstrap/js/bootstrap-formhelpers.js",
                "~/Areas/Administration/Content/Themes/assets/plugins/bootstrap-datepicker/js/bootstrap-datepicker.js",
                "~/Areas/Administration/Content/Themes/assets/plugins/bootstrap-datepicker/js/bootstrap-datepicker.js",
                "~/Areas/Administration/Content/Themes/assets/plugins/bootstrap-colorpicker/js/bootstrap-colorpicker.min.js",
                "~/Areas/Administration/Content/Themes/assets/plugins/bootstrap-combobox/js/bootstrap-combobox.js",
                "~/Areas/Administration/Content/Themes/assets/plugins/bootstrap-select/bootstrap-select.min.js",
                "~/Areas/Administration/Content/Themes/assets/plugins/bootstrap-tagsinput/bootstrap-tagsinput.min.js",
                "~/Areas/Administration/Content/Themes/assets/plugins/bootstrap-tagsinput/bootstrap-tagsinput-typeahead.js",
                "~/Areas/Administration/Content/Themes/assets/plugins/bootstrap-daterangepicker/moment.js",
                "~/Areas/Administration/Content/Themes/assets/plugins/bootstrap-daterangepicker/daterangepicker.js",
                "~/Areas/Administration/Content/Themes/assets/plugins/bootstrap-timepicker/js/bootstrap-timepicker.min.js",
                "~/Areas/Administration/Content/Themes/assets/plugins/bootstrap-eonasdan-datetimepicker/build/js/bootstrap-datetimepicker.min.js",
                "~/Areas/Administration/Content/Themes/assets/plugins/bootstrap-show-password/bootstrap-show-password.js",
                "~/Areas/Administration/Content/Themes/assets/plugins/bootstrap-colorpalette/js/bootstrap-colorpalette.js"
                ));

            bundles.Add(new ScriptBundle("~/Admin/plugins").Include(
                "~/Areas/Administration/Content/Themes/assets/plugins/slimscroll/jquery.slimscroll.min.js",
                "~/Areas/Administration/Content/Themes/assets/plugins/flot/jquery.flot.min.js",
                "~/Areas/Administration/Content/Themes/assets/plugins/flot/jquery.flot.time.min.js",
                "~/Areas/Administration/Content/Themes/assets/plugins/flot/jquery.flot.resize.min.js",
                "~/Areas/Administration/Content/Themes/assets/plugins/flot/jquery.flot.pie.min.js",
                "~/Areas/Administration/Content/Themes/assets/plugins/sparkline/jquery.sparkline.js",
                "~/Areas/Administration/Content/Themes/assets/plugins/DataTables/media/js/jquery.dataTables.js",
                "~/Areas/Administration/Content/Themes/assets/plugins/DataTables/media/js/dataTables.bootstrap.min.js",
                "~/Areas/Administration/Content/Themes/assets/plugins/DataTables/extensions/Responsive/js/dataTables.responsive.min.js",
                "~/Areas/Administration/Content/Themes/assets/plugins/ionRangeSlider/js/ion-rangeSlider/ion.rangeSlider.min.js",
                "~/Areas/Administration/Content/Themes/assets/plugins/masked-input/masked-input.min.js",
                "~/Areas/Administration/Content/Themes/assets/plugins/password-indicator/js/password-indicator.js",
                "~/Areas/Administration/Content/Themes/assets/plugins/jstree/dist/jstree.min.js",
                "~/Areas/Administration/Content/Themes/assets/plugins/dropzone/min/dropzone.min.js",
                "~/Areas/Administration/Content/Themes/assets/plugins/parsley/dist/parsley.js",
                "~/Areas/Administration/Content/Themes/assets/plugins/savekey/savekey.js"
                ));

            bundles.Add(new ScriptBundle("~/Admin/custom-scripts").Include(
                "~/Areas/Administration/Content/Themes/assets/js/dashboard.js",
                "~/Areas/Administration/Content/Themes/assets/js/copy-to-clipboard.js",
                "~/Areas/Administration/Content/Themes/assets/js/form-plugins.init.js",
                "~/Areas/Administration/Content/Themes/assets/js/ui-tree.init.js",
                "~/Areas/Administration/Content/Themes/assets/js/apps.js",
                "~/Areas/Administration/Content/Themes/assets/js/bap-ui-extensions.js",
                "~/Areas/Administration/Content/Themes/assets/js/localization/index.js",
                "~/Content/themes/base/assets/plugins/select2/dist/js/select2.js"
                ));            
        }
    }
}
