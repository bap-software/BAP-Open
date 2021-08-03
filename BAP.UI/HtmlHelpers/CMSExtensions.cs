// ***********************************************************************
// Assembly         : BAP.UI
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="CMSExtensions.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.IO;
using System.Web.Mvc;
using System.Collections.Generic;

using BAP.DAL;
using BAP.Log;
using BAP.Common;
using BAP.Common.Modules;
using BAP.ContentManagement;
using System.Linq.Expressions;
using System;

namespace BAP.UI.HtmlHelpers
{
    /// <summary>
    /// Class CMSExtensions.
    /// </summary>
    public static class CMSExtensions
    {
        /// <summary>
        /// Baps the upper menu.
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <param name="masterTemplateName">Name of the master template.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString BAPUpperMenu(this HtmlHelper helper, string masterTemplateName = "BAPMenuHelperModel")
        {
            string result = "";
            var configHelper = DependencyResolver.Current.GetService<IConfigHelper>();
            var authContext = DependencyResolver.Current.GetService<IAuthorizationContext>();
            var logger = DependencyResolver.Current.GetService<ILogger>();
            using (var cmsEngine = new CMSEngine(configHelper, authContext, logger))
            {                
                var menu = cmsEngine.GetMenu();
                if (menu != null && menu.Length > 0)
                {
                    var baseFolder = "/Views/Shared/CMSTemplates";
                    if (helper.ViewContext.RouteData.DataTokens != null && helper.ViewContext.RouteData.DataTokens.ContainsKey("area"))
                    {
                        baseFolder = "/Areas/" + helper.ViewContext.RouteData.DataTokens["area"].ToString() + baseFolder;
                    }
                    baseFolder = "~" + baseFolder;

                    var physicalPath = helper.ViewContext.RequestContext.HttpContext.Server.MapPath(baseFolder);
                    if (File.Exists(physicalPath + "\\" + masterTemplateName + ".cshtml"))
                    {
                        var controllerContext = helper.ViewContext.Controller.ControllerContext;
                        using (var stringWriter = new StringWriter())
                        {
                            var viewResult = System.Web.Mvc.ViewEngines.Engines.FindPartialView(controllerContext, baseFolder + "/" + masterTemplateName + ".cshtml");
                            if (viewResult.View != null)
                            {
                                var viewData = helper.ViewData;
                                var tempData = helper.ViewContext.TempData;
                                viewData.Model = new List<ModuleMenuNode>(menu);
                                var viewContext = new ViewContext(controllerContext, viewResult.View, viewData, tempData, stringWriter);
                                viewResult.View.Render(viewContext, stringWriter);
                                result = stringWriter.GetStringBuilder().ToString();
                            }
                        }
                    }
                }                
            }
                
            
            return MvcHtmlString.Create(result);
        }

        /// <summary>
        /// Displays the menu item for.
        /// </summary>
        /// <typeparam name="TModel">The type of the t model.</typeparam>
        /// <typeparam name="TProperty">The type of the t property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString DisplayMenuItemFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            string result = "";
            var name = ExpressionHelper.GetExpressionText(expression);
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            if(metadata.Model != null && metadata.Model is ModuleMenuNode)
            {

            }

            return MvcHtmlString.Create(result);
        }
    }
    
}
