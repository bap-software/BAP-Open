// ***********************************************************************
// Assembly         : BAP.UI
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="Extensions.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Web;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

using BAP.Common;
using BAP.DAL;
using BAP.DAL.Entities;
using BAP.Lookups;
using BAP.BL;
using BAP.Log;
using System.Text;

namespace BAP.UI.HtmlHelpers
{
    /// <summary>
    /// Enum StartDate
    /// </summary>
    public enum StartDate
    {
        /// <summary>
        /// The none
        /// </summary>
        None = 0,
        /// <summary>
        /// The today
        /// </summary>
        Today,
        /// <summary>
        /// The this week
        /// </summary>
        ThisWeek,
        /// <summary>
        /// The this month
        /// </summary>
        ThisMonth,
        /// <summary>
        /// The this year
        /// </summary>
        ThisYear,
        /// <summary>
        /// The yesterday
        /// </summary>
        Yesterday,
        /// <summary>
        /// The previous week
        /// </summary>
        PreviousWeek,
        /// <summary>
        /// The previous month
        /// </summary>
        PreviousMonth,
        /// <summary>
        /// The previous year
        /// </summary>
        PreviousYear,
        /// <summary>
        /// The tomorrow
        /// </summary>
        Tomorrow,
        /// <summary>
        /// The next week
        /// </summary>
        NextWeek,
        /// <summary>
        /// The next month
        /// </summary>
        NextMonth,
        /// <summary>
        /// The next year
        /// </summary>
        NextYear
    }

    /// <summary>
    /// Class Extensions.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// The countries
        /// </summary>
        public static IList<Country> Countries;
        /// <summary>
        /// The currencies
        /// </summary>
        public static IList<Currency> Currencies;
        /// <summary>
        /// The states
        /// </summary>
        public static IList<State> States;

        /// <summary>
        /// Initializes static members of the <see cref="Extensions"/> class.
        /// </summary>
        static Extensions()
        {
            var configHelper = DependencyResolver.Current.GetService<IConfigHelper>();
            var authContext = DependencyResolver.Current.GetService<IAuthorizationContext>();
            var logger = DependencyResolver.Current.GetService<ILogger>();
            BusinessLayer bl = new BusinessLayer(configHelper, authContext, logger);
            Countries = bl.GetAllCountries().OrderBy(c => c.Name).ToList();
            Currencies = bl.GetAllCurrencies().OrderBy(c => c.Name).ToList();
            States = bl.GetAllStates().OrderBy(s => s.Name).ToList();
        }

        /// <summary>
        /// Quick html wrapper over resource manager in order to get localized string.
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <param name="resourceName">Name of the resource.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static MvcHtmlString R(this HtmlHelper helper, string resourceName, string defaultValue = "")
        {
            var result = Resources.Resources.GetString(resourceName, defaultValue);
            return MvcHtmlString.Create(result);
        }

        /// <summary>
        /// Baps the display enum.
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <param name="e">The e.</param>
        /// <param name="envelopTag">The envelop tag.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString BapDisplayEnum(this HtmlHelper helper, Enum e, string envelopTag = "span", object htmlAttributes = null)
        {
            string result = e.ToString();
            var attributes = BaseHtmlExtensionUtils.AssemblyHtmlAttributes(htmlAttributes);

            var display = e.GetType()
                       .GetMember(e.ToString()).First()
                       .GetCustomAttributes(false)
                       .OfType<DisplayAttribute>()
                       .LastOrDefault();

            if (display != null)
            {
                result = display.GetName();
            }

            if (!envelopTag.IsNullOrEmpty())
            {
                result = string.Format("<{0} {1}>{2}</{0}>", envelopTag, attributes, result);
            }

            return MvcHtmlString.Create(result);
        }

        /// <summary>
        /// Baps the date for.
        /// </summary>
        /// <typeparam name="TModel">The type of the t model.</typeparam>
        /// <typeparam name="TProperty">The type of the t property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <param name="startDate">The start date.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString BapDateFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes = null, StartDate startDate = StartDate.Today)
        {
            var name = ExpressionHelper.GetExpressionText(expression);
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            string value = "";
            if (metadata.Model != null && ((DateTime)metadata.Model) != DateTime.MinValue)
            {
                var date = (DateTime)metadata.Model;
                value = date.ToShortDateString();
            }

            return BapDate(htmlHelper, name, value, htmlAttributes, startDate);
        }

        /// <summary>
        /// Baps the date.
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <param name="startDate">The start date.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString BapDate(this HtmlHelper helper, string name, string value, object htmlAttributes = null, StartDate startDate = StartDate.Today)
        {
            var attributes = BaseHtmlExtensionUtils.AssemblyHtmlAttributes(htmlAttributes);
            if (value.IsNullOrEmpty())
            {
                switch (startDate)
                {
                    case StartDate.Today: value = DateTime.Now.ToShortDateString(); break;
                    case StartDate.Yesterday: value = DateTime.Now.AddDays(-1).ToShortDateString(); break;
                    case StartDate.Tomorrow: value = DateTime.Now.AddDays(1).ToShortDateString(); break;
                    case StartDate.ThisWeek: value = DateTime.Now.StartOfWeek(DayOfWeek.Sunday).ToShortDateString(); break;
                    case StartDate.ThisMonth: value = DateTime.Now.StartOfMonth().ToShortDateString(); break;
                    case StartDate.ThisYear: value = DateTime.Now.StartOfYear().ToShortDateString(); break;
                    case StartDate.PreviousWeek: value = DateTime.Now.StartOfWeek(DayOfWeek.Sunday).AddDays(-7).ToShortDateString(); break;
                    case StartDate.PreviousMonth: value = DateTime.Now.StartOfMonth().AddMonths(-1).ToShortDateString(); break;
                    case StartDate.PreviousYear: value = DateTime.Now.StartOfYear().AddYears(-1).ToShortDateString(); break;
                    case StartDate.NextWeek: value = DateTime.Now.StartOfWeek(DayOfWeek.Sunday).AddDays(7).ToShortDateString(); break;
                    case StartDate.NextMonth: value = DateTime.Now.StartOfMonth().AddMonths(1).ToShortDateString(); break;
                    case StartDate.NextYear: value = DateTime.Now.StartOfYear().AddYears(1).ToShortDateString(); break;
                    default: value = ""; break;
                }
            }

            var result = string.Format("<div class=\"input-group date\" data-provide=\"datepicker\"><input type=\"text\" id=\"{0}\" name=\"{1}\" value=\"{2}\" {3}/><span class=\"input-group-addon\"><span class=\"glyphicon glyphicon-calendar\"></span></span></div>", name.Replace(".", "_"), name, value, attributes);
            return MvcHtmlString.Create(result);
        }

        /// <summary>
        /// Baps the drop down for.
        /// </summary>
        /// <typeparam name="TModel">The type of the t model.</typeparam>
        /// <typeparam name="TProperty">The type of the t property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="lookupEngine">The lookup engine.</param>
        /// <param name="lookup">The lookup.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString BapDropDownFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, ILookupEngine lookupEngine, string lookup, object htmlAttributes = null)
        {
            var name = ExpressionHelper.GetExpressionText(expression);
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            List<LookupItem> items = null;
            string value = "";
            if (metadata.Model != null)
                value = metadata.Model.ToString();

            if (lookupEngine != null)
            {
                items = lookupEngine.GetLookup(lookup, metadata.IsRequired);
            }

            return BapDropDown(htmlHelper, items, name, value, htmlAttributes, metadata.IsRequired);
        }

        /// <summary>
        /// Baps the drop down.
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <param name="lookupEngine">The lookup engine.</param>
        /// <param name="lookup">The lookup.</param>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <param name="required">if set to <c>true</c> [required].</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString BapDropDown(this HtmlHelper helper, ILookupEngine lookupEngine, string lookup, string name, string value, object htmlAttributes = null, bool required = false)
        {
            List<LookupItem> items = null;
            if (lookupEngine != null)
            {
                items = lookupEngine.GetLookup(lookup, required);
            }
            return BapDropDown(helper, items, name, value, htmlAttributes, required);
        }

        /// <summary>
        /// Baps the drop down.
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <param name="items">The items.</param>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <param name="required">if set to <c>true</c> [required].</param>
        /// <param name="parentControlId">The parent control identifier.</param>
        /// <returns>MvcHtmlString.</returns>
        private static MvcHtmlString BapDropDown(this HtmlHelper helper, List<LookupItem> items, string name, string value, object htmlAttributes = null, bool required = false, string parentControlId = "")
        {
            var attributes = BaseHtmlExtensionUtils.AssemblyHtmlAttributes(htmlAttributes);
            if (value == null)
                value = "";

            var id = name.Replace(".", "_");
            var result = string.Format("<select id=\"{0}\" name=\"{1}\" {2} {3}>", id, name, attributes, !string.IsNullOrEmpty(parentControlId) ? $" data-parent-id=\"{parentControlId}\"" : "");

            //If null, will create it anyway as default value may be inserted in it
            if (items == null)
                items = new List<LookupItem>();

            //if no such value - insert it, but not inserting empty value if fied is required
            if (!items.Any(i => i.Key == value) && !(string.IsNullOrEmpty(value) && required))
            {
                var item = new LookupItem
                {
                    Key = value,
                    Text = value
                };
                int val = 0;
                var index = -1;
                if (Int32.TryParse(value, out val))
                {
                    for (int i = 0; i < items.Count; i++)
                    {
                        int v1 = 0;
                        if (Int32.TryParse(items[i].Key, out v1) && v1 >= val)
                        {
                            index = i;
                            break;
                        }
                    }
                }

                if (index == -1)
                    items.Add(item);
                else
                    items.Insert(index, item);
            }

            result = items.Aggregate(result, (current, item) => current + string.Format("<option value=\"{0}\" {3} {2}>{1}</option>",
                item.Key, item.Text, ((!string.IsNullOrEmpty(value) && value == item.Key) ? "selected" : ""), !string.IsNullOrEmpty(parentControlId) ? $"data-parent-value=\"{item.ParentKey}\"" : ""));

            result += "</select>";            
            return MvcHtmlString.Create(result);
        }

        /// <summary>
        /// Rendres dropdown showing list of assemblies where the given interface is used
        /// </summary>
        /// <typeparam name="TModel">The type of the t model.</typeparam>
        /// <typeparam name="TProperty">The type of the t property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="interfaceType">Type of the interface.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString BapInterfaceAssembliesDropDownFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, Type interfaceType, object htmlAttributes = null)
        {
            var name = ExpressionHelper.GetExpressionText(expression);
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            List<LookupItem> items = null;
            string value = "";
            if (metadata.Model != null)
                value = metadata.Model.ToString();

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach(var asm in assemblies)
            {
                try
                {
                    var types = asm.GetTypes()
                    .Where(p => interfaceType.IsAssignableFrom(p) && !p.IsInterface);
                    if (types != null && types.Count() > 0)
                    {
                        if(items == null)
                            items = new List<LookupItem>();
                        foreach (var t in types)
                        {
                            if (!items.Any(a => a.Key == asm.FullName))
                            {
                                var parts = asm.FullName.Split(",".ToCharArray());
                                items.Add(new LookupItem() { Key = asm.FullName, Description = asm.FullName, Text = parts[0] });
                            }
                        }
                    }
                }
                catch (Exception)
                { 
                    //Do nothing if cannot load some assembly
                }
            }
            

            if (!metadata.IsRequired)
            {
                if (items == null)
                    items = new List<LookupItem>();
                items.Insert(0, new LookupItem
                {
                    Key = "",
                    Text = Resources.Resources.UIText_DropDown_SelectOption,                    
                });
            }

            var result = BapDropDown(htmlHelper, items, name, value, htmlAttributes, metadata.IsRequired);
            string tmp = result.ToHtmlString();
            if (tmp.Contains("class=\""))
                tmp = tmp.Replace("class=\"", "class=\"master-drop-down ");
            else
                tmp = tmp.Replace("select ", "select class=\"master-drop-down\"");

            return MvcHtmlString.Create(tmp);
        }

        /// <summary>
        /// Baps the interface classes drop down for.
        /// </summary>
        /// <typeparam name="TModel">The type of the t model.</typeparam>
        /// <typeparam name="TProperty">The type of the t property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="interfaceType">Type of the interface.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <param name="assemblyControlId">The assembly control identifier.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString BapInterfaceClassesDropDownFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, Type interfaceType, object htmlAttributes = null, string assemblyControlId = "")
        {
            var name = ExpressionHelper.GetExpressionText(expression);
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            List<LookupItem> items = null;
            string value = "";
            if (metadata.Model != null)
                value = metadata.Model.ToString();


            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var asm in assemblies)
            {
                try
                {
                    var types = asm.GetTypes()
                    .Where(p => interfaceType.IsAssignableFrom(p) && !p.IsInterface);
                    if (types != null && types.Count() > 0)
                    {
                        if (items == null)
                            items = new List<LookupItem>();
                        items.AddRange((from t in types
                                 select new LookupItem
                                 {
                                     Key = t.FullName,
                                     Text = t.Name,
                                     ParentKey = t.Assembly.FullName
                                 }).ToList());
                    }
                }
                catch (Exception)
                {
                    //Do nothing if cannot load some assembly
                }
            }            

            if(!metadata.IsRequired)
            {
                if (items == null)
                    items = new List<LookupItem>();
                items.Insert(0, new LookupItem
                {
                    Key = "",
                    Text = Resources.Resources.UIText_DropDown_SelectOption,
                    ParentKey = ""
                }) ;
            }

            return BapDropDown(htmlHelper, items, name, value, htmlAttributes, metadata.IsRequired, assemblyControlId);
        }

        /// <summary>
        /// Baps the parent drop down for.
        /// </summary>
        /// <typeparam name="TModel">The type of the t model.</typeparam>
        /// <typeparam name="TProperty">The type of the t property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="lookupEngine">The lookup engine.</param>
        /// <param name="idField">The identifier field.</param>
        /// <param name="nameField">The name field.</param>
        /// <param name="descriptionField">The description field.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <param name="foreignFieldName">Name of the foreign field.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString BapParentDropDownFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, ILookupEngine lookupEngine, string idField, string nameField, string descriptionField = "", object htmlAttributes = null, string foreignFieldName = "")
        {
            var name = ExpressionHelper.GetExpressionText(expression);
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            string value = "";
            List<LookupItem> items = null;

            if (metadata.Model != null && metadata.Model is IBapEntity)
            {
                var entity = (IBapEntity)metadata.Model;
                value = entity.Id.ToString();
                if (idField.ToLowerInvariant() == "name")
                    value = entity.Name;
            }

            if (lookupEngine != null)
            {
                items = lookupEngine.GetLookup(metadata.ModelType, idField, nameField, descriptionField, metadata.IsRequired);
            }

            var controlId = name;
            if (!string.IsNullOrEmpty(foreignFieldName))
                controlId = foreignFieldName;
            return BapDropDown(htmlHelper, items, controlId, value, htmlAttributes, metadata.IsRequired);
        }

        /// <summary>
        /// Baps the parent drop down for.
        /// </summary>
        /// <typeparam name="TModel">The type of the t model.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="propertyType">Type of the property.</param>
        /// <param name="lookupEngine">The lookup engine.</param>
        /// <param name="idField">The identifier field.</param>
        /// <param name="nameField">The name field.</param>
        /// <param name="descriptionField">The description field.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <param name="foreignFieldName">Name of the foreign field.</param>
        /// <param name="currentValue">The current value.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString BapParentDropDownFor<TModel>(this HtmlHelper<TModel> htmlHelper, Type propertyType, ILookupEngine lookupEngine, string idField, string nameField, string descriptionField = "", object htmlAttributes = null, string foreignFieldName = "", string currentValue = "")
        {
            var name = propertyType.Name;
            string value = currentValue;            
            List<LookupItem> items = null;
            if (lookupEngine != null)
            {
                items = lookupEngine.GetLookup(propertyType, idField, nameField, descriptionField, false);
            }

            var controlId = name;
            if (!string.IsNullOrEmpty(foreignFieldName))
                controlId = foreignFieldName;
            return BapDropDown(htmlHelper, items, controlId, value, htmlAttributes, false);
        }


        /// <summary>
        /// Baps the org user drop down for.
        /// </summary>
        /// <typeparam name="TModel">The type of the t model.</typeparam>
        /// <typeparam name="TProperty">The type of the t property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="lookupEngine">The lookup engine.</param>
        /// <param name="idField">The identifier field.</param>
        /// <param name="nameField">The name field.</param>
        /// <param name="descriptionField">The description field.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <param name="foreignFieldName">Name of the foreign field.</param>
        /// <param name="roles">The roles.</param>
        /// <param name="setCurrentUserAsSelected">if set to <c>true</c> [set current user as selected].</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString BapOrgUserDropDownFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, ILookupEngine lookupEngine, string idField, string nameField, string descriptionField = "", object htmlAttributes = null, string foreignFieldName = "", List<string> roles = null, bool setCurrentUserAsSelected = false)
        {
            var name = ExpressionHelper.GetExpressionText(expression);
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            string value = "";
            List<LookupItem> items = null;

            if (metadata.Model != null && metadata.Model is IBapEntity)
            {
                var entity = (IBapEntity)metadata.Model;
                value = entity.Id.ToString();
            }

            if (lookupEngine != null)
            {
                items = lookupEngine.GetLookup(metadata.ModelType, idField, nameField, descriptionField, metadata.IsRequired, roles, setCurrentUserAsSelected);
            }

            var controlId = name;
            if (!string.IsNullOrEmpty(foreignFieldName))
                controlId = foreignFieldName;
            return BapDropDown(htmlHelper, items, controlId, value, htmlAttributes, metadata.IsRequired);
        }

        /// <summary>
        /// Baps the display name.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="field">The field.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString BapDisplayName(this HtmlHelper htmlHelper, string field)
        {
            var property = FindProperty(htmlHelper.ViewData.ModelMetadata, field);
            string result;
            if (property != null)
            {
                result = property.GetDisplayName();
            }
            else
            {
                result = field;
            }

            return MvcHtmlString.Create(result);
        }

        /// <summary>
        /// Baps the display name.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="obj">The object.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString BapDisplayName(this HtmlHelper htmlHelper, object obj)
        {
            var result = "";
            if (obj != null)
            {
                var attr = obj.GetType().GetCustomAttribute<DisplayAttribute>();
                if (attr != null)
                {
                    result = attr.GetName();
                }
                else
                {
                    result = obj.ToString();
                }
            }

            return MvcHtmlString.Create(result);
        }

        /// <summary>
        /// Finds the property.
        /// </summary>
        /// <param name="modelMetaData">The model meta data.</param>
        /// <param name="property">The property.</param>
        /// <returns>ModelMetadata.</returns>
        private static ModelMetadata FindProperty(ModelMetadata modelMetaData, string property)
        {
            ModelMetadata result = null;
            if (modelMetaData != null)
            {
                foreach (var prop in modelMetaData.Properties)
                {
                    if (prop.PropertyName == property)
                    {
                        result = prop;
                        break;
                    }
                    result = FindProperty(prop, property);
                }
            }
            return result;
        }

        /// <summary>
        /// Baps the sorting header for.
        /// </summary>
        /// <typeparam name="TModel">The type of the t model.</typeparam>
        /// <typeparam name="TProperty">The type of the t property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="sortData">The sort data.</param>
        /// <param name="currentSortExpression">The current sort expression.</param>
        /// <param name="indexAction">The index action.</param>
        /// <param name="indexController">The index controller.</param>
        /// <param name="indexArea">The index area.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="currentFilter">The current filter.</param>
        /// <param name="sortingCss">The sorting CSS.</param>
        /// <param name="sortingAscCss">The sorting asc CSS.</param>
        /// <param name="sortingDescCss">The sorting desc CSS.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <param name="routeParameters">The route parameters.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString BapSortingHeaderFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, Dictionary<string, string> sortData, string currentSortExpression, string indexAction, string indexController, string indexArea = "", int pageNumber = -1, string currentFilter = "", string sortingCss = "sorting", string sortingAscCss = "sorting_asc", string sortingDescCss = "sorting_desc", int pageSize = 20, object htmlAttributes = null, object routeParameters = null)
        {
            var name = ExpressionHelper.GetExpressionText(expression);
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var labelText = metadata.GetDisplayName();

            return BapSortingHeader(htmlHelper, labelText, name, sortData, currentSortExpression, indexAction, indexController, indexArea, pageNumber, currentFilter, sortingCss, sortingAscCss, sortingDescCss, pageSize, htmlAttributes, routeParameters);
        }

        /// <summary>
        /// Baps the sorting header.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="text">The text.</param>
        /// <param name="field">The field.</param>
        /// <param name="sortData">The sort data.</param>
        /// <param name="currentSortExpression">The current sort expression.</param>
        /// <param name="indexAction">The index action.</param>
        /// <param name="indexController">The index controller.</param>
        /// <param name="indexArea">The index area.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="currentFilter">The current filter.</param>
        /// <param name="sortingCss">The sorting CSS.</param>
        /// <param name="sortingAscCss">The sorting asc CSS.</param>
        /// <param name="sortingDescCss">The sorting desc CSS.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <param name="routeParameters">The route parameters.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString BapSortingHeader(this HtmlHelper htmlHelper, string text, string field, Dictionary<string, string> sortData, string currentSortExpression, string indexAction, string indexController, string indexArea = "", int pageNumber = -1, string currentFilter = "", string sortingCss = "sorting", string sortingAscCss = "sorting_asc", string sortingDescCss = "sorting_desc", int pageSize = 20, object htmlAttributes = null, object routeParameters = null)
        {
            string attributes = BaseHtmlExtensionUtils.AssemblyHtmlAttributes(htmlAttributes);
            string result = "";
            string currentSortClass = sortingCss;
            string fieldSortDirection = "asc";
            if (!string.IsNullOrEmpty(currentSortExpression))
            {
                var arr = currentSortExpression.Split("-".ToCharArray());
                if (arr[0] == field && arr[1] == "asc")
                    currentSortClass = sortingAscCss;
                else if (arr[0] == field && arr[1] == "desc")
                    currentSortClass = sortingDescCss;
            }

            if (sortData != null && sortData.ContainsKey(field))
            {
                fieldSortDirection = sortData[field];
            }

            var sortUrl = "";
            if (!string.IsNullOrEmpty(indexArea))
                sortUrl = "/" + indexArea;
            sortUrl += string.Format("/{0}/{1}?sortOrder={2}-{3}&pageSize={4}", indexController, indexAction, field, fieldSortDirection, pageSize);
            if (pageNumber > 0)
                sortUrl += "&page=" + pageNumber.ToString();
            if (!string.IsNullOrEmpty(currentFilter))
                sortUrl += "&currentFilter=" + HttpUtility.UrlEncode(currentFilter);
            if (routeParameters != null)
            {
                var parameters = routeParameters.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
                var strParams = "";
                strParams += parameters.Aggregate(strParams, (current, param) => current + string.Format("&{0}={1}", param.Name.Replace("@", ""), HttpUtility.UrlEncode(param.GetValue(routeParameters, null).ToString())));
                sortUrl += strParams;
            }
            result = string.Format("<th class=\"{1}\" onclick=\"window.location='{2}';\" {3}>{0}</th>", text, currentSortClass, sortUrl, attributes);
            return MvcHtmlString.Create(result);
        }

        /// <summary>
        /// Baps the country list.
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <param name="required">if set to <c>true</c> [required].</param>
        /// <param name="useCurrent">if set to <c>true</c> [use current].</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString BapCountryList(this HtmlHelper helper, string name, string value, object htmlAttributes = null, bool required = false, bool useCurrent = false)
        {
            var controlCss = @"input-medium select-country ";
            if (useCurrent && string.IsNullOrEmpty(value))
            {
                var culture = CultureInfo.CurrentCulture.Name;
                if (culture.Contains(@"-"))
                {
                    var arr = culture.Split("-".ToCharArray());
                    value = arr[1];
                }
                else
                {
                    value = culture;
                }
            }
            string attributes = BaseHtmlExtensionUtils.AssemblyHtmlAttributes(htmlAttributes, true);
            if (htmlAttributes != null)
            {
                var props = htmlAttributes.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);

                if (props.Any(p => p.Name == "class"))
                {
                    var classProp = props.SingleOrDefault(p => p.Name == "class");
                    if (classProp != null)
                    {
                        controlCss += classProp.GetValue(htmlAttributes);
                    }
                }
            }
            attributes += " class=\"" + controlCss + "\" ";

            var sb = new StringBuilder();
            foreach (var country in Countries)
                sb.AppendFormat($"<option {(country.Name == value ? "selected" : "")} value=\"{country.Name}\">{country.Name}</option>");

            var result = $"<select id=\"{name.Replace(".", "_")}\" name=\"{name}\" {attributes} data-country=\"{value}\">{sb.ToString()}</select>";

            return MvcHtmlString.Create(result);
        }

        /// <summary>
        /// Baps the state list.
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <param name="country">The country.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <param name="required">if set to <c>true</c> [required].</param>
        /// <param name="useCurrent">if set to <c>true</c> [use current].</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString BapStateList(this HtmlHelper helper, string name, string value, string country, object htmlAttributes = null, bool required = false, bool useCurrent = false)
        {
            var controlCss = @"input-medium select-state ";
            if (useCurrent && string.IsNullOrEmpty(value))
            {
                var culture = CultureInfo.CurrentCulture.Name;
                if (culture.Contains(@"-"))
                {
                    var arr = culture.Split("-".ToCharArray());
                    value = arr[1];
                }
                else
                {
                    value = culture;
                }
            }
            string attributes = BaseHtmlExtensionUtils.AssemblyHtmlAttributes(htmlAttributes, true);
            if (htmlAttributes != null)
            {
                var props = htmlAttributes.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);

                if (props.Any(p => p.Name == "class"))
                {
                    var classProp = props.SingleOrDefault(p => p.Name == "class");
                    if (classProp != null)
                    {
                        controlCss += classProp.GetValue(htmlAttributes);
                    }
                }
            }
            attributes += " class=\"" + controlCss + "\" ";

            var sb = new StringBuilder();
            var states = States.Where(s => s.Country.Name == country).ToList();
            if (!states.Any())
                states.Add(new State() { Name = value });
            foreach (var state in states)
                sb.AppendFormat($"<option {(state.Name == value ? "selected" : "")} value=\"{state.Name}\">{state.Name}</option>");

            var result = $"<select id=\"{name.Replace(".", "_")}\" name=\"{name}\" {attributes} data-state=\"{value}\">{sb.ToString()}</select>";

            result += "";

            return MvcHtmlString.Create(result);
        }

        /// <summary>
        /// Baps the country list for.
        /// </summary>
        /// <typeparam name="TModel">The type of the t model.</typeparam>
        /// <typeparam name="TProperty">The type of the t property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <param name="useCurrent">if set to <c>true</c> [use current].</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString BapCountryListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes = null, bool useCurrent = false)
        {
            var name = ExpressionHelper.GetExpressionText(expression);
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

            return BapCountryList(htmlHelper, name, metadata.Model as string, htmlAttributes, metadata.IsRequired, useCurrent);
        }

        /// <summary>
        /// Baps the state list for.
        /// </summary>
        /// <typeparam name="TModel">The type of the t model.</typeparam>
        /// <typeparam name="TProperty">The type of the t property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="country">The country.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <param name="useCurrent">if set to <c>true</c> [use current].</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString BapStateListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string country, object htmlAttributes = null, bool useCurrent = false)
        {
            var name = ExpressionHelper.GetExpressionText(expression);
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

            return BapStateList(htmlHelper, name, metadata.Model as string, country, htmlAttributes, metadata.IsRequired, useCurrent);
        }

        /// <summary>
        /// Baps the country.
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <param name="required">if set to <c>true</c> [required].</param>
        /// <param name="useCurrent">if set to <c>true</c> [use current].</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString BapCountry(this HtmlHelper helper, string name, string value, Object htmlAttributes = null, bool required = false, bool useCurrent = false)
        {
            var controlCss = @"input-medium ";
            if (useCurrent || string.IsNullOrEmpty(value))
            {
                value = new RegionInfo(CultureInfo.CurrentCulture.LCID)?.EnglishName;
            }            

            var attributes = BaseHtmlExtensionUtils.AssemblyHtmlAttributes(htmlAttributes, true);
            if (htmlAttributes != null)
            {
                var props = htmlAttributes.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
                if (props.Any(p => p.Name == "class"))
                {
                    var classProp = props.SingleOrDefault(p => p.Name == "class");
                    if (classProp != null)
                    {
                        controlCss += classProp.GetValue(htmlAttributes);
                    }
                }
            }

            attributes += " class=\"" + controlCss + "\" ";
            var result = string.Format("<input type=\"text\" id=\"{0}\" name=\"{1}\" {2} value=\"{3}\">", name.Replace(".", "_"), name, attributes, value);

            return MvcHtmlString.Create(result);
        }

        /// <summary>
        /// Baps the country for.
        /// </summary>
        /// <typeparam name="TModel">The type of the t model.</typeparam>
        /// <typeparam name="TProperty">The type of the t property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <param name="useCurrent">if set to <c>true</c> [use current].</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString BapCountryFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes = null, bool useCurrent = false)
        {
            var name = ExpressionHelper.GetExpressionText(expression);
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

            return BapCountry(htmlHelper, name, metadata.Model as string, htmlAttributes, metadata.IsRequired, useCurrent);
        }

        /// <summary>
        /// Baps the currency list.
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <param name="required">if set to <c>true</c> [required].</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString BapCurrencyList(this HtmlHelper helper, string name, string value, object htmlAttributes = null, bool required = false)
        {
            var controlCss = @"input-medium bfh-currencies ";
            var attributes = BaseHtmlExtensionUtils.AssemblyHtmlAttributes(htmlAttributes, true);
            if (htmlAttributes != null)
            {
                var props = htmlAttributes.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
                if (props.Any(p => p.Name == "class"))
                {
                    var classProp = props.SingleOrDefault(p => p.Name == "class");
                    if (classProp != null)
                    {
                        controlCss += classProp.GetValue(htmlAttributes);
                    }
                }
            }
            attributes += " class=\"" + controlCss + "\" ";

            var result = string.Format("<select id=\"{0}\" name=\"{1}\" {2} data-currency=\"{3}\"></select>", name.Replace(".", "_"), name, attributes, value);

            return MvcHtmlString.Create(result);
        }

        /// <summary>
        /// Baps the public currency list for.
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <param name="required">if set to <c>true</c> [required].</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString BapPublicCurrencyListFor(this HtmlHelper helper, string name, int value, object htmlAttributes = null, bool required = false)
        {
            var controlCss = @"input-medium ";
            var attributes = BaseHtmlExtensionUtils.AssemblyHtmlAttributes(htmlAttributes, true);
            if (htmlAttributes != null)
            {
                var props = htmlAttributes.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
                if (props.Any(p => p.Name == "class"))
                {
                    var classProp = props.SingleOrDefault(p => p.Name == "class");
                    if (classProp != null)
                    {
                        controlCss += classProp.GetValue(htmlAttributes);
                    }
                }
            }
            attributes += " class=\"" + controlCss + "\" ";

            var sb = new StringBuilder();
            foreach (var currency in Currencies)
                sb.AppendFormat($"<option {(currency.Id == value ? "selected" : "")} value=\"{currency.Id}\">{currency.Name}</option>");

            var result = $"<select id=\"{name.Replace(".", "_")}\" name=\"{name}\" {attributes} data-currency=\"{value}\">{sb.ToString()}</select>";

            return MvcHtmlString.Create(result);
        }

        /// <summary>
        /// Baps the currency list for.
        /// </summary>
        /// <typeparam name="TModel">The type of the t model.</typeparam>
        /// <typeparam name="TProperty">The type of the t property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString BapCurrencyListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes = null)
        {
            var name = ExpressionHelper.GetExpressionText(expression);
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

            return BapCurrencyList(htmlHelper, name, metadata.Model as string, htmlAttributes, metadata.IsRequired);
        }

        /// <summary>
        /// Baps the public currency list for.
        /// </summary>
        /// <typeparam name="TModel">The type of the t model.</typeparam>
        /// <typeparam name="TProperty">The type of the t property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString BapPublicCurrencyListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes = null)
        {
            var name = ExpressionHelper.GetExpressionText(expression);
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

            return BapPublicCurrencyListFor(htmlHelper, name, metadata.Model != null ? (int)metadata.Model : 0, htmlAttributes, metadata.IsRequired);
        }

        /// <summary>
        /// Sortings the drop down.
        /// </summary>
        /// <typeparam name="TModel">The type of the t model.</typeparam>
        /// <typeparam name="TEntity">The type of the t entity.</typeparam>
        /// <param name="helper">The helper.</param>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString SortingDropDown<TModel, TEntity>(this HtmlHelper<TModel> helper, string name, string value, object htmlAttributes = null) where TEntity : class, IBapEntity
        {
            var entityHelper = new EntityHelper<TEntity>();
            var sortFields = entityHelper.GetSortFields();
            var attributes = BaseHtmlExtensionUtils.AssemblyHtmlAttributes(htmlAttributes);
            var result = string.Format("<select id=\"{0}\" name=\"{1}\" {2}>", name.Replace(".", "_"), name, attributes);
            result += string.Format("<option value=\"default\">{0}</option>", BAP.Resources.Resources.UIText_DefaultOrder);

            foreach (var sortField in sortFields)
            {
                var fieldName = sortField.Field.Name;
                var fieldLabel = sortField.Label;

                if (sortField.Attribute.AllowAscending)
                {
                    var key = fieldName.ToLower() + "-asc";
                    var text = fieldLabel + " Ascending";//has to be changed further to pull localized name
                    var selected = (!string.IsNullOrEmpty(value) && value == key) ? " selected " : "";
                    result += string.Format("<option value=\"{0}\" {2}>{1}</option>", key, text, selected);
                }

                if (sortField.Attribute.AllowDescending)
                {
                    var key = fieldName.ToLower() + "-desc";
                    var text = fieldLabel + " Descending";//has to be changed further to pull localized name
                    var selected = (!string.IsNullOrEmpty(value) && value == key) ? " selected " : "";
                    result += string.Format("<option value=\"{0}\" {2}>{1}</option>", key, text, selected);
                }
            }
            result += "</select>";
            return MvcHtmlString.Create(result);
        }

        /// <summary>
        /// Determines whether the specified settings is admin.
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="context">The context.</param>
        /// <returns><c>true</c> if the specified settings is admin; otherwise, <c>false</c>.</returns>
        public static bool IsAdmin(this HtmlHelper helper, IConfigHelper settings, IAuthorizationContext context)
        {
            var authHelper = new AuthorizationHelper<Organization>(settings, context);
            return authHelper.IsUserInAdminRole;
        }
        /// <summary>
        /// Determines whether [is content manager] [the specified settings].
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="context">The context.</param>
        /// <returns><c>true</c> if [is content manager] [the specified settings]; otherwise, <c>false</c>.</returns>
        public static bool IsContentManager(this HtmlHelper helper, IConfigHelper settings, IAuthorizationContext context)
        {
            var authHelper = new AuthorizationHelper<Organization>(settings, context);
            return authHelper.IsUserInContentManagerRole;
        }
        /// <summary>
        /// Determines whether the specified settings is user.
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="context">The context.</param>
        /// <returns><c>true</c> if the specified settings is user; otherwise, <c>false</c>.</returns>
        public static bool IsUser(this HtmlHelper helper, IConfigHelper settings, IAuthorizationContext context)
        {
            var authHelper = new AuthorizationHelper<Organization>(settings, context);
            return authHelper.IsUserInUserRole;
        }
        /// <summary>
        /// Displays the with identifier for.
        /// </summary>
        /// <typeparam name="TModel">The type of the t model.</typeparam>
        /// <typeparam name="TValue">The type of the t value.</typeparam>
        /// <param name="helper">The helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="wrapperTag">The wrapper tag.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString DisplayWithIdFor<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, string wrapperTag = "div")
        {
            var id = helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(ExpressionHelper.GetExpressionText(expression));
            return MvcHtmlString.Create(string.Format("<{0} id=\"{1}\">{2}</{0}>", wrapperTag, id, helper.DisplayFor(expression)));
        }

        /// <summary>
        /// Baps the text box for.
        /// </summary>
        /// <typeparam name="TModel">The type of the t model.</typeparam>
        /// <typeparam name="TProperty">The type of the t property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>MvcHtmlString.</returns>
        public static MvcHtmlString BapTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            var member = expression.Body as MemberExpression;
            var stringLength = member.Member
                .GetCustomAttributes(typeof(StringLengthAttribute), false)
                .FirstOrDefault() as StringLengthAttribute;

            IDictionary<string, object> attributes = new Dictionary<string, object>();
            if (htmlAttributes != null)
            {
                var props = htmlAttributes.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
                foreach (var prop in props)
                {
                    var propName = prop.Name.Replace("@", "");
                    var propValue = prop.GetValue(htmlAttributes, null);
                    attributes.Add(propName, propValue);
                }
            }

            if (stringLength != null)
            {
                attributes.Add("maxlength", stringLength.MaximumLength);
            }
            return htmlHelper.TextBoxFor(expression, attributes);
        }
    }
}