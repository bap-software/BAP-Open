// ***********************************************************************
// Assembly         : BAP.UI
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="BaseHtmlExtension.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Linq;
using System.Reflection;

namespace BAP.UI.HtmlHelpers
{
    /// <summary>
    /// Class BaseHtmlExtensionUtils.
    /// </summary>
    public static class BaseHtmlExtensionUtils
    {
        /// <summary>
        /// Assemblies the HTML attributes.
        /// </summary>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <param name="excludeClass">if set to <c>true</c> [exclude class].</param>
        /// <returns>System.String.</returns>
        public static string AssemblyHtmlAttributes(object htmlAttributes, bool excludeClass = false)
        {
            var attributes = string.Empty;
            if (htmlAttributes != null)
            {
                var props = htmlAttributes.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
                if(excludeClass)
                    attributes = props.Where(p => p.Name != "class").Aggregate(attributes, (current, prop) => current + string.Format("{0}=\"{1}\"", prop.Name.Replace("@", ""), prop.GetValue(htmlAttributes, null)));
                else
                    attributes = props.Aggregate(attributes, (current, prop) => current + string.Format("{0}=\"{1}\"", prop.Name.Replace("@", ""), prop.GetValue(htmlAttributes, null)));
            }

            return attributes;
        }
    }
}
