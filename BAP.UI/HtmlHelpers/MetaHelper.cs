// ***********************************************************************
// Assembly         : BAP.UI
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="MetaHelper.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Text;
using System.Web.Mvc;

using BAP.DAL;
using BAP.Log;
using BAP.Common;
using BAP.ContentManagement;

namespace BAP.UI.HtmlHelpers
{
    /// <summary>
    /// Class MetaHelper.
    /// </summary>
    public static class MetaHelper
    {
        /// <summary>
        /// Metas the specified master template name.
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <param name="masterTemplateName">Name of the master template.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString Meta(this HtmlHelper helper, string masterTemplateName = "BAPMenuHelperModel")
        {
            var sbResult = new StringBuilder();
            var controllerContext = helper.ViewContext.Controller.ControllerContext;
            var area = "";
            var controller = "Home";
            var action = "Index";
            var url = "";

            sbResult.Append("<!-- BAP adding custom meta tags here -->\r\n");

            if (controllerContext.RouteData.DataTokens.ContainsKey("area"))
                area = controllerContext.RouteData.DataTokens["area"].ToString();
            if (controllerContext.RouteData.Values.ContainsKey("controller"))
                controller = controllerContext.RouteData.Values["controller"].ToString();
            if (controllerContext.RouteData.Values.ContainsKey("action"))
                action = controllerContext.RouteData.Values["action"].ToString();
            if (controllerContext.RouteData.Values.ContainsKey("url"))
                url = controllerContext.RouteData.Values["url"].ToString();

            var configHelper = DependencyResolver.Current.GetService<IConfigHelper>();
            var authContext = DependencyResolver.Current.GetService<IAuthorizationContext>();
            var logger = DependencyResolver.Current.GetService<ILogger>();
            using (var cmsEngine = new CMSEngine(configHelper, authContext, logger))
            {
                var currentContentNode = cmsEngine.GetContentNode(area, controller, action, url);
                if (currentContentNode == null)
                    currentContentNode = cmsEngine.GetContentNodeByUrl(controllerContext.HttpContext.Request.FilePath);
                if (currentContentNode != null)
                {
                    if (!string.IsNullOrWhiteSpace(currentContentNode.ContentTitle))
                        sbResult.AppendFormat("\t<meta name=\"title\" content=\"{0}\">\r\n", currentContentNode.ContentTitle);
                    if (!string.IsNullOrWhiteSpace(currentContentNode.ContentAuthor))
                        sbResult.AppendFormat("\t<meta name=\"author\" content=\"{0}\">\r\n", currentContentNode.ContentAuthor);
                    if (!string.IsNullOrWhiteSpace(currentContentNode.ContentDescription))
                        sbResult.AppendFormat("\t<meta name=\"description\" content=\"{0}\">\r\n", currentContentNode.ContentDescription);
                    if (!string.IsNullOrWhiteSpace(currentContentNode.ContentKeywords))
                        sbResult.AppendFormat("\t<meta name=\"keywords\" content=\"{0}\">\r\n", currentContentNode.ContentKeywords);
                }
            }
            return MvcHtmlString.Create(sbResult.ToString());
        }
    }
}
