// ***********************************************************************
// Assembly         : BAP.Lookups
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="LookupEngine.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;

using BAP.Common;
using BAP.DAL;
using BAP.DAL.Entities;
using BAP.Log;


namespace BAP.Lookups
{
    /// <summary>
    /// Class LookupEngine. This class cannot be inherited.
    /// Implements the <see cref="BAP.Lookups.ILookupEngine" />
    /// </summary>
    /// <seealso cref="BAP.Lookups.ILookupEngine" />
    public sealed class LookupEngine : ILookupEngine
    {
        /// <summary>
        /// The logger
        /// </summary>
        private ILogger _logger;
        /// <summary>
        /// The settings
        /// </summary>
        private IConfigHelper _settings;
        /// <summary>
        /// The authentication context
        /// </summary>
        private IAuthorizationContext _authContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="LookupEngine"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="context">The context.</param>
        public LookupEngine(ILogger logger, IConfigHelper settings, IAuthorizationContext context)
        {
            _logger = logger;
            _settings = settings;
            _authContext = context;
        }

        /// <summary>
        /// Method to give lookup values array of the given BAP entity type. Method is to be used to get list of parent items mainly.
        /// </summary>
        /// <param name="entityType">Type of the entity.</param>
        /// <param name="idField">The identifier field.</param>
        /// <param name="nameField">The name field.</param>
        /// <param name="descriptionField">The description field.</param>
        /// <param name="required">indicates whether field is required, if not, shows empty option on te top</param>
        /// <param name="roles">roles list</param>
        /// <param name="setCurrentUserAsSelected">set current user as selected</param>
        /// <returns>generic list of LookupItem instances, if nothing found returns empty list</returns>
        public List<LookupItem> GetLookup(Type entityType, string idField, string nameField, string descriptionField, bool required = true, List<string> roles = null, bool setCurrentUserAsSelected = false)
        {
            List<LookupItem> ret = null;
            var type = typeof(ISupportLookup);
            var types = AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.Contains("BAP")).SelectMany(s => s.GetTypes())
              .Where(p => type.IsAssignableFrom(p) && p.Name == entityType.Name + "BL");

            if (types != null && types.Any())
            {
                ISupportLookup classInstance = (ISupportLookup)Activator.CreateInstance(types.First(), _settings, _authContext, _logger);
                if (classInstance != null)
                {
                    var list = classInstance.GetLookupItems(idField, nameField, descriptionField, "", "", roles, setCurrentUserAsSelected);
                    ret = new List<LookupItem>();
                    ret.AddRange(list);
                }
            }

            if (ret == null)
                ret = new List<LookupItem>();

            if (!required)
                ret.Insert(0, new LookupItem() { Key = "", Text = Resources.Resources.UIText_DropDown_SelectOption, Description = Resources.Resources.UIText_DropDown_SelectOption });

            return ret;
        }


        /// <summary>
        /// Method to give lookup values array by name and culture (e.g. en-US)
        /// </summary>
        /// <param name="lookup">name of the lookup</param>
        /// <param name="required">indicates whether field is required, if not, shows empty option on te top</param>
        /// <returns>generic list of LookupItem instances, if nothing found returns empty list</returns>
        public List<LookupItem> GetLookup(string lookup, bool required = true)
        {
            List<LookupItem> ret = new List<LookupItem>();
            try
            {
                Lookup item = null;
                using (var unitOfWork = new UnitOfWork(_settings, _authContext))
                {
                    item = unitOfWork.LookupRepository.GetSingle(i => i.Name == lookup, i => i.Values);
                }
                if (item != null)
                {
                    switch (item.LookupType)
                    {
                        case LookupType.OptionList:
                            if (item.Values != null && item.Values.Count > 0)
                                ret = (from v in item.Values                                       
                                       orderby v.Order
                                       select new LookupItem { Key = v.Key, Text = v.Text, Description = v.Description }).ToList();
                            break;

                        case LookupType.IntRange:
                            ret = new List<LookupItem>();
                            int fromValue = 0;
                            int toValue = 0;
                            if (item.IntRangeFrom.HasValue)
                                fromValue = item.IntRangeFrom.Value;
                            if (item.IntRangeTo.HasValue)
                                toValue = item.IntRangeTo.Value;
                            for (int i = fromValue; i <= toValue; i++)
                            {
                                ret.Add(new LookupItem { Key = i.ToString(), Text = i.ToString(), Description = i.ToString() });
                            }

                            break;
                        case LookupType.FloatRange:
                            ret = new List<LookupItem>();
                            float fromFloatValue = 0;
                            float toFloatValue = 0;
                            float step = 1;
                            if (item.FloatRangeFrom.HasValue)
                                fromFloatValue = item.FloatRangeFrom.Value;
                            if (item.FloatRangeTo.HasValue)
                                toFloatValue = item.FloatRangeTo.Value;
                            if (item.FloatRangeStep.HasValue)
                                step = item.FloatRangeStep.Value;

                            for (float i = fromFloatValue; i <= toFloatValue; i += step)
                            {
                                ret.Add(new LookupItem { Key = i.ToString(CultureInfo.InvariantCulture), Text = i.ToString(CultureInfo.CurrentCulture), Description = i.ToString(CultureInfo.CurrentCulture) });
                            }

                            break;

                        case LookupType.DateRange:
                            ret = new List<LookupItem>();
                            DateTime fromDate = DateTime.Today.AddDays(-1);
                            DateTime toDate = DateTime.Today.AddDays(1);

                            if (item.DateRangeFrom.HasValue && item.DateRangeFrom.Value < DateTime.Today)
                                fromDate = item.DateRangeFrom.Value;

                            if (item.DateRangeTo.HasValue && item.DateRangeTo.Value >= DateTime.Today)
                                toDate = item.DateRangeTo.Value;

                            var dateStep = fromDate;
                            while (dateStep <= toDate)
                            {
                                ret.Add(new LookupItem { Key = dateStep.ToString(CultureInfo.InvariantCulture), Text = dateStep.ToString(CultureInfo.CurrentCulture), Description = dateStep.ToString(CultureInfo.CurrentCulture) });
                                dateStep = dateStep.AddDays(1);
                            }

                            break;
                        case LookupType.Entity:
                            if (!string.IsNullOrEmpty(item.EntityAssembly) && !string.IsNullOrEmpty(item.EntityClass))
                            {
                                var assembly = Assembly.Load(item.EntityAssembly);
                                if (assembly != null)
                                {
                                    var type = assembly.GetType(item.EntityClass);
                                    if (type != null && typeof(ISupportLookup).IsAssignableFrom(type))
                                    {
                                        MethodInfo method = type.GetMethod("GetLookupItems");
                                        if (method != null)
                                        {
                                            object result = null;
                                            object classInstance = Activator.CreateInstance(type, _settings, _authContext, _logger);
                                            object[] parametersArray = new object[] { item.EntityValueField, item.EntityNameField, item.EntityNameField, item.EntityFilter, item.EntityOrderBy };
                                            result = method.Invoke(classInstance, parametersArray);
                                            if (result != null && result is IList<LookupItem>)
                                            {
                                                var list = (IList<LookupItem>)result;
                                                ret = new List<LookupItem>();
                                                ret.AddRange(list);
                                            }
                                        }
                                    }
                                }
                            }
                            break;

                        default:
                            ret = new List<LookupItem>();
                            break;
                    }

                }
            }
            catch (Exception exc)
            {
                _logger.LogException("LookupEngine", "GetLookup", exc);
            }

            if (ret == null)
                ret = new List<LookupItem>();

            if (!required)
                ret.Insert(0, new LookupItem() { Key = "", Text = Resources.Resources.UIText_DropDown_SelectOption, Description = Resources.Resources.UIText_DropDown_SelectOption });

            return ret;
        }

        /// <summary>
        /// Gets the first item.
        /// </summary>
        /// <param name="lookup">The lookup.</param>
        /// <returns>LookupItem.</returns>
        public LookupItem GetFirstItem(string lookup)
        {
            var list = GetLookup(lookup);
            if (list != null && list.Any())
                return list.FirstOrDefault();

            return null;
        }

        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <param name="lookup">The lookup.</param>
        /// <param name="value">The value.</param>
        /// <returns>LookupItem.</returns>
        public LookupItem GetItem(string lookup, string value)
        {
            var list = GetLookup(lookup);
            if (list != null && list.Any(p => p.Key == value))
                return list.FirstOrDefault(p => p.Key == value);

            return null;
        }

        /// <summary>
        /// Gets the item text.
        /// </summary>
        /// <param name="lookup">The lookup.</param>
        /// <param name="value">The value.</param>
        /// <param name="emptyText">The empty text.</param>
        /// <returns>System.String.</returns>
        public string GetItemText(string lookup, string value, string emptyText = "")
        {
            var item = GetItem(lookup, value);
            if (item != null)
                return item.Text;

            return emptyText;
        }

        /// <summary>
        /// Gets the currency symbol.
        /// </summary>
        /// <param name="currency">The currency.</param>
        /// <returns>System.String.</returns>
        public string GetCurrencySymbol(string currency)
        {
            var result = string.Empty;
            Currency currItem = null;
            using (var unitOfWork = new UnitOfWork(_settings, _authContext))
            {
                currItem = unitOfWork.CurrencyRepository.GetSingle(c => c.ThreeLetterCode == currency);
            }

            if (currItem != null)
                result = currItem.Symbol;

            return result;
        }

        /// <summary>
        /// Gets the lookups.
        /// </summary>
        /// <returns>List&lt;LookupItem&gt;.</returns>
        public List<LookupItem> GetLookups()
        {
            var lookupItems = new List<LookupItem>();
            using (var unitOfWork = new UnitOfWork(_settings, _authContext))
            {
                var items = unitOfWork.LookupRepository.GetAll();
                lookupItems.AddRange(items.Select(item => new LookupItem { Key = item.Name, Text = item.Description }));
            }

            return lookupItems;
        }
    }
}
