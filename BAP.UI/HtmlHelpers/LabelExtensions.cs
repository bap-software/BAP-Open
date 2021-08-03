// ***********************************************************************
// Assembly         : BAP.UI
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="LabelExtensions.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Web.Mvc;

namespace BAP.UI.HtmlHelpers
{
    /// <summary>
    /// Class LabelExtensions.
    /// </summary>
    public static class LabelExtensions
    {
        /// <summary>
        /// Labels the specified expression.
        /// </summary>
        /// <param name="html">The HTML.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="generatedId">if set to <c>true</c> [generated identifier].</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString Label(this HtmlHelper html, string expression, string id = "", bool generatedId = false)
        {
            return LabelHelper(html,
                               ModelMetadata.FromStringExpression(expression, html.ViewData),
                               expression, DisplayOptions.None, null, "", id, generatedId);
        }

        /// <summary>
        /// Labels for.
        /// </summary>
        /// <typeparam name="TModel">The type of the t model.</typeparam>
        /// <typeparam name="TValue">The type of the t value.</typeparam>
        /// <param name="html">The HTML.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="displayOptions">The display options.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <param name="extraText">The extra text.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="generatedId">if set to <c>true</c> [generated identifier].</param>
        /// <returns>MvcHtmlString.</returns>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]
        public static MvcHtmlString LabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, DisplayOptions displayOptions, Object htmlAttributes = null, string extraText = "", string id = "", bool generatedId = false)
        {
            return LabelHelper(html,
                               ModelMetadata.FromLambdaExpression(expression, html.ViewData),
                               ExpressionHelper.GetExpressionText(expression), displayOptions, htmlAttributes, extraText, id, generatedId);
        }

        /// <summary>
        /// Labels the helper.
        /// </summary>
        /// <param name="html">The HTML.</param>
        /// <param name="metadata">The metadata.</param>
        /// <param name="htmlFieldName">Name of the HTML field.</param>
        /// <param name="displayOptions">The display options.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <param name="extraText">The extra text.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="generatedId">if set to <c>true</c> [generated identifier].</param>
        /// <returns>MvcHtmlString.</returns>
        internal static MvcHtmlString LabelHelper(HtmlHelper html, ModelMetadata metadata, string htmlFieldName, DisplayOptions displayOptions, Object htmlAttributes, string extraText, string id, bool generatedId)
        {
            string labelText = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            if (String.IsNullOrEmpty(labelText))
            {
                return MvcHtmlString.Empty;
            }
            var sb = new StringBuilder();
            sb.Append(labelText);           
            sb.Append(extraText);
            if (displayOptions == DisplayOptions.HumanizeAndColon && labelText.Substring(labelText.Length - 1) != ":")
            {
                sb.Append(":");
            }

            var tag = new TagBuilder("label");
            var idAdded = false;
            if (!string.IsNullOrWhiteSpace(id))
            {
                tag.Attributes.Add("id", id);
                idAdded = true;
            }
            else if (generatedId)
            {
                tag.Attributes.Add("id", html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName) + "_Label");
                idAdded = true;
            }

            tag.Attributes.Add("for", html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName));

            if (htmlAttributes != null)
            {
                var props = htmlAttributes.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
                foreach (var prop in props)
                {
                    var propName = prop.Name.Replace("@", "");
                    var propValue = prop.GetValue(htmlAttributes, null);
                    if (propName.ToLower() == "for")
                        continue;
                    if (idAdded && propName.ToLower() == "id")
                        continue;

                    tag.Attributes.Add(propName, propValue.ToString());
                }
            }

            tag.SetInnerText(sb.ToString());
            tag.InnerHtml = sb.ToString();
            if (metadata.IsRequired)
                tag.InnerHtml += "<span style='color:red;' title='"+Resources.Resources.UIText_RequiredField+"'>*<span>";

            return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal));
        }        

    }
    /// <summary>
    /// Enum DisplayOptions
    /// </summary>
    public enum DisplayOptions
    {
        /// <summary>
        /// The humanize
        /// </summary>
        Humanize,
        /// <summary>
        /// The humanize and colon
        /// </summary>
        HumanizeAndColon,
        /// <summary>
        /// The none
        /// </summary>
        None
    }
}