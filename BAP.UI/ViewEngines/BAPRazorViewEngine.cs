// ***********************************************************************
// Assembly         : BAP.UI
// Author           : Victor Mamray
// Created          : 07-06-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 07-06-2020
// ***********************************************************************
// <copyright file="BAPRazorViewEngine.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Linq;
using System.Web.Mvc;

using BAP.Common;
using BAP.ContentManagement;

namespace BAP.UI.ViewEngines
{
    /// <summary>
    /// Our custom BAP Razor view engine to return view path based on the CMS data.
    /// </summary>
    public class BAPRazorViewEngine : RazorViewEngine
    {
        /// <summary>
        /// Creates a view by using the specified controller context and the paths of the view and master view.
        /// </summary>
        /// <param name="controllerContext">The controller context.</param>
        /// <param name="viewPath">The path to the view.</param>
        /// <param name="masterPath">The path to the master view.</param>
        /// <returns>The view.</returns>
        protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
        {
            if (!IsOverridableView(controllerContext, viewPath))
                return base.CreateView(controllerContext, viewPath, masterPath);

            var overriddenViewPath = GetOverriddenViewPath(controllerContext, viewPath);
            return base.CreateView(controllerContext, overriddenViewPath, masterPath);
        }
        /// <summary>
        /// Creates a partial view using the specified controller context and partial path.
        /// </summary>
        /// <param name="controllerContext">The controller context.</param>
        /// <param name="partialPath">The path to the partial view.</param>
        /// <returns>The partial view.</returns>
        protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
        {
            if (!IsOverridableView(controllerContext, partialPath))
                return base.CreatePartialView(controllerContext, partialPath);

            var overriddenViewPath = GetOverriddenViewPath(controllerContext, partialPath, true);
            return base.CreatePartialView(controllerContext, overriddenViewPath);
        }


        /// <summary>
        /// Determines whether [is overridable view] [the specified controller context].
        /// </summary>
        /// <param name="controllerContext">The controller context.</param>
        /// <param name="viewPath">The view path.</param>
        /// <returns><c>true</c> if [is overridable view] [the specified controller context]; otherwise, <c>false</c>.</returns>
        private static bool IsOverridableView(ControllerContext controllerContext, string viewPath)
        {
            bool result = false;
            var ctrl = controllerContext.Controller.GetType();
            var ctrlAllowedAttribute = ctrl.GetCustomAttributes(typeof(ContentManagementAttribute), true).Cast<ContentManagementAttribute>().FirstOrDefault();
            if (ctrl.GetInterfaces().Any(a => a == typeof(IContentManagable)) && (ctrlAllowedAttribute == null || ctrlAllowedAttribute.Allowed))
                result = true;

            return result;
        }
        /// <summary>
        /// Gets the overridden view path.
        /// </summary>
        /// <param name="controllerContext">The controller context.</param>
        /// <param name="viewPath">The view path.</param>
        /// <param name="isPartial">if set to <c>true</c> [is partial].</param>
        /// <returns>System.String.</returns>
        private string GetOverriddenViewPath(ControllerContext controllerContext, string viewPath, bool isPartial = false)
        {
            string result = viewPath;
            if (controllerContext.Controller != null && controllerContext.Controller.GetType().GetInterfaces().Any(a => a == typeof(IContentManagable)))
            {
                IContentManagable cmsController = (IContentManagable)controllerContext.Controller;
                var cms = cmsController.CMSContext;
                var area = "";
                var controller = "";
                var action = "";
                var view = "";
                var url = "";

                if (controllerContext.RouteData.DataTokens.ContainsKey("area"))
                    area = controllerContext.RouteData.DataTokens["area"].ToString();
                if (controllerContext.RouteData.Values.ContainsKey("controller"))
                    controller = controllerContext.RouteData.Values["controller"].ToString();
                if (controllerContext.RouteData.Values.ContainsKey("action"))
                    action = controllerContext.RouteData.Values["action"].ToString();

                if (!isPartial)
                {
                    if (controllerContext.RouteData.Values.ContainsKey("url"))
                        url = controllerContext.RouteData.Values["url"].ToString();

                    if (controllerContext.HttpContext != null && controllerContext.HttpContext.Request != null)
                    {
                        var request = controllerContext.HttpContext.Request;
                        if (request.QueryString["view"] != null)
                        {
                            view = request.QueryString["view"];
                        }
                    }

                    if (view.IsNullOrEmpty() && action.ToLower() == "content" && !url.IsNullOrEmpty())
                    {
                        var urlParts = url.Split("/".ToCharArray());
                        view = urlParts[urlParts.Length - 1];
                    }

                    result = cms.GetViewPath(result, area, controller, action, view, url);
                }
                else
                {
                    result = cms.GetPartialViewPath(result);
                }
            }
            return result;
        }
    }
}
