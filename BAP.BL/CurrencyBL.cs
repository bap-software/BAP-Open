// ***********************************************************************
// Assembly         : BAP.BL
// Author           : Victor Mamray
// Created          : 05-24-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="CurrencyBL.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Threading.Tasks;
using PagedList;

using BAP.Common;
using BAP.DAL.Entities;
using BAP.DAL;
using BAP.Log;

namespace BAP.BL
{
    /// <summary>
    /// Interface ICurrencyBL
    /// </summary>
    public interface ICurrencyBL
    {
        /// <summary>
        /// Gets all currencies.
        /// </summary>
        /// <returns>IList&lt;Currency&gt;.</returns>
        IList<Currency> GetAllCurrencies();
        /// <summary>
        /// Gets all currencies asynchronous.
        /// </summary>
        /// <returns>Task&lt;IList&lt;Currency&gt;&gt;.</returns>
        Task<IList<Currency>> GetAllCurrenciesAsync();

        /// <summary>
        /// Searches the currencies.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;Currency&gt;.</returns>
        IPagedList<Currency> SearchCurrencies(string where, string sort, int page, int pageSize = 20);
        /// <summary>
        /// Searches the currencies asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IPagedList&lt;Currency&gt;&gt;.</returns>
        Task<IPagedList<Currency>> SearchCurrenciesAsync(string where, string sort, int page, int pageSize = 20);

        /// <summary>
        /// Searches the currencies.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>IList&lt;Currency&gt;.</returns>
        IList<Currency> SearchCurrencies(string where, string sort);
        /// <summary>
        /// Searches the currencies asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>Task&lt;IList&lt;Currency&gt;&gt;.</returns>
        Task<IList<Currency>> SearchCurrenciesAsync(string where, string sort);

        /// <summary>
        /// Gets the currency by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Currency.</returns>
        Currency GetCurrencyById(int id);
        /// <summary>
        /// Gets the currency by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;Currency&gt;.</returns>
        Task<Currency> GetCurrencyByIdAsync(int id);

        /// <summary>
        /// Gets the main currency.
        /// </summary>
        /// <returns>Currency.</returns>
        Currency GetMainCurrency();
        /// <summary>
        /// Gets the main currency asynchronous.
        /// </summary>
        /// <returns>Task&lt;Currency&gt;.</returns>
        Task<Currency> GetMainCurrencyAsync();

        /// <summary>
        /// Adds the currency.
        /// </summary>
        /// <param name="currencies">The currencies.</param>
        void AddCurrency(params Currency[] currencies);
        /// <summary>
        /// Adds the currency asynchronous.
        /// </summary>
        /// <param name="currencies">The currencies.</param>
        /// <returns>Task.</returns>
        Task AddCurrencyAsync(params Currency[] currencies);

        /// <summary>
        /// Updates the currency.
        /// </summary>
        /// <param name="currencies">The currencies.</param>
        void UpdateCurrency(params Currency[] currencies);
        /// <summary>
        /// Updates the currency asynchronous.
        /// </summary>
        /// <param name="currencies">The currencies.</param>
        /// <returns>Task.</returns>
        Task UpdateCurrencyAsync(params Currency[] currencies);

        /// <summary>
        /// Removes the currency.
        /// </summary>
        /// <param name="currencies">The currencies.</param>
        void RemoveCurrency(params Currency[] currencies);
        /// <summary>
        /// Removes the currency asynchronous.
        /// </summary>
        /// <param name="currencies">The currencies.</param>
        /// <returns>Task.</returns>
        Task RemoveCurrencyAsync(params Currency[] currencies);
    }

    /// <summary>
    /// Class BusinessLayer.
    /// Implements the <see cref="BAP.BL.ISubscriberBL" />
    /// Implements the <see cref="BAP.BL.IDocumentTemplateBL" />
    /// Implements the <see cref="BAP.BL.IContentControlParameterBL" />
    /// Implements the <see cref="BAP.BL.IBlogAuthorBL" />
    /// Implements the <see cref="BAP.Common.ILocalizedBL{BAP.DAL.Entities.BlogAuthor}" />
    /// Implements the <see cref="BAP.BL.IBlogCommentUserBL" />
    /// Implements the <see cref="BAP.BL.IAttachmentHistBL" />
    /// Implements the <see cref="BAP.BL.IStateBL" />
    /// Implements the <see cref="BAP.BL.IOrganizationUserBL" />
    /// Implements the <see cref="BAP.BL.ISubscriptionBL" />
    /// Implements the <see cref="BAP.BL.IModuleBL" />
    /// Implements the <see cref="BAP.BL.IMessageBL" />
    /// Implements the <see cref="BAP.BL.IContentViewControlBL" />
    /// Implements the <see cref="BAP.Common.ILocalizedBL{BAP.DAL.Entities.ContentViewControl}" />
    /// Implements the <see cref="BAP.BL.IEventLogBL" />
    /// Implements the <see cref="BAP.BL.INewsLetterBL" />
    /// Implements the <see cref="BAP.Common.ILocalizedBL{BAP.DAL.Entities.NewsLetter}" />
    /// Implements the <see cref="BAP.BL.ILocalizationBL" />
    /// Implements the <see cref="BAP.BL.IWorkflowStageTransitionBL" />
    /// Implements the <see cref="BAP.BL.IScheduledTaskBL" />
    /// Implements the <see cref="BAP.BL.ILookupBL" />
    /// Implements the <see cref="BAP.Common.ILocalizedBL{BAP.DAL.Entities.Lookup}" />
    /// Implements the <see cref="BAP.BL.IWorkflowClassBL" />
    /// Implements the <see cref="BAP.BL.ICustomConfigurationBL" />
    /// Implements the <see cref="BAP.BL.ILookupValueBL" />
    /// Implements the <see cref="BAP.Common.ILocalizedBL{BAP.DAL.Entities.LookupValue}" />
    /// Implements the <see cref="System.IDisposable" />
    /// Implements the <see cref="BAP.BL.IBlogPostBL" />
    /// Implements the <see cref="BAP.Common.ILocalizedBL{BAP.DAL.Entities.BlogPost}" />
    /// Implements the <see cref="BAP.BL.ICurrencyBL" />
    /// Implements the <see cref="BAP.BL.IContentControlBL" />
    /// Implements the <see cref="BAP.Common.ILocalizedBL{BAP.DAL.Entities.ContentControl}" />
    /// Implements the <see cref="BAP.BL.IAttachmentBL" />
    /// Implements the <see cref="BAP.BL.IWorkflowObjectBL" />
    /// Implements the <see cref="BAP.BL.IContentNodeRouteBL" />
    /// Implements the <see cref="BAP.BL.IOrganizationBL" />
    /// Implements the <see cref="BAP.BL.IBlogBL" />
    /// Implements the <see cref="BAP.Common.ILocalizedBL{BAP.DAL.Entities.Blog}" />
    /// Implements the <see cref="BAP.BL.IWorkflowActionBL" />
    /// Implements the <see cref="BAP.BL.IWorkflowActionAttributeBL" />
    /// Implements the <see cref="BAP.BL.IStagingEntityBL" />
    /// Implements the <see cref="BAP.BL.IContentNodeBL" />
    /// Implements the <see cref="BAP.Common.ILocalizedBL{BAP.DAL.Entities.ContentNode}" />
    /// Implements the <see cref="BAP.BL.IWorkflowStageBL" />
    /// Implements the <see cref="BAP.BL.IOrganizationServiceBL" />
    /// Implements the <see cref="BAP.Common.ILocalizedBL{BAP.DAL.Entities.OrganizationService}" />
    /// Implements the <see cref="BAP.BL.ICountryBL" />
    /// Implements the <see cref="BAP.BL.IBlogCommentBL" />
    /// Implements the <see cref="BAP.BL.IContentViewBL" />
    /// Implements the <see cref="BAP.Common.ILocalizedBL{BAP.DAL.Entities.ContentView}" />
    /// Implements the <see cref="BAP.BL.IContentControlTypeBL" />
    /// Implements the <see cref="BAP.Common.ILocalizedBL{BAP.DAL.Entities.ContentControlType}" />
    /// Implements the <see cref="BAP.BL.IContentLocalizationBL" />
    /// </summary>
    /// <seealso cref="BAP.BL.ISubscriberBL" />
    /// <seealso cref="BAP.BL.IDocumentTemplateBL" />
    /// <seealso cref="BAP.BL.IContentControlParameterBL" />
    /// <seealso cref="BAP.BL.IBlogAuthorBL" />
    /// <seealso cref="BAP.Common.ILocalizedBL{BAP.DAL.Entities.BlogAuthor}" />
    /// <seealso cref="BAP.BL.IBlogCommentUserBL" />
    /// <seealso cref="BAP.BL.IAttachmentHistBL" />
    /// <seealso cref="BAP.BL.IStateBL" />
    /// <seealso cref="BAP.BL.IOrganizationUserBL" />
    /// <seealso cref="BAP.BL.ISubscriptionBL" />
    /// <seealso cref="BAP.BL.IModuleBL" />
    /// <seealso cref="BAP.BL.IMessageBL" />
    /// <seealso cref="BAP.BL.IContentViewControlBL" />
    /// <seealso cref="BAP.Common.ILocalizedBL{BAP.DAL.Entities.ContentViewControl}" />
    /// <seealso cref="BAP.BL.IEventLogBL" />
    /// <seealso cref="BAP.BL.INewsLetterBL" />
    /// <seealso cref="BAP.Common.ILocalizedBL{BAP.DAL.Entities.NewsLetter}" />
    /// <seealso cref="BAP.BL.ILocalizationBL" />
    /// <seealso cref="BAP.BL.IWorkflowStageTransitionBL" />
    /// <seealso cref="BAP.BL.IScheduledTaskBL" />
    /// <seealso cref="BAP.BL.ILookupBL" />
    /// <seealso cref="BAP.Common.ILocalizedBL{BAP.DAL.Entities.Lookup}" />
    /// <seealso cref="BAP.BL.IWorkflowClassBL" />
    /// <seealso cref="BAP.BL.ICustomConfigurationBL" />
    /// <seealso cref="BAP.BL.ILookupValueBL" />
    /// <seealso cref="BAP.Common.ILocalizedBL{BAP.DAL.Entities.LookupValue}" />
    /// <seealso cref="System.IDisposable" />
    /// <seealso cref="BAP.BL.IBlogPostBL" />
    /// <seealso cref="BAP.Common.ILocalizedBL{BAP.DAL.Entities.BlogPost}" />
    /// <seealso cref="BAP.BL.ICurrencyBL" />
    /// <seealso cref="BAP.BL.IContentControlBL" />
    /// <seealso cref="BAP.Common.ILocalizedBL{BAP.DAL.Entities.ContentControl}" />
    /// <seealso cref="BAP.BL.IAttachmentBL" />
    /// <seealso cref="BAP.BL.IWorkflowObjectBL" />
    /// <seealso cref="BAP.BL.IContentNodeRouteBL" />
    /// <seealso cref="BAP.BL.IOrganizationBL" />
    /// <seealso cref="BAP.BL.IBlogBL" />
    /// <seealso cref="BAP.Common.ILocalizedBL{BAP.DAL.Entities.Blog}" />
    /// <seealso cref="BAP.BL.IWorkflowActionBL" />
    /// <seealso cref="BAP.BL.IWorkflowActionAttributeBL" />
    /// <seealso cref="BAP.BL.IStagingEntityBL" />
    /// <seealso cref="BAP.BL.IContentNodeBL" />
    /// <seealso cref="BAP.Common.ILocalizedBL{BAP.DAL.Entities.ContentNode}" />
    /// <seealso cref="BAP.BL.IWorkflowStageBL" />
    /// <seealso cref="BAP.BL.IOrganizationServiceBL" />
    /// <seealso cref="BAP.Common.ILocalizedBL{BAP.DAL.Entities.OrganizationService}" />
    /// <seealso cref="BAP.BL.ICountryBL" />
    /// <seealso cref="BAP.BL.IBlogCommentBL" />
    /// <seealso cref="BAP.BL.IContentViewBL" />
    /// <seealso cref="BAP.Common.ILocalizedBL{BAP.DAL.Entities.ContentView}" />
    /// <seealso cref="BAP.BL.IContentControlTypeBL" />
    /// <seealso cref="BAP.Common.ILocalizedBL{BAP.DAL.Entities.ContentControlType}" />
    /// <seealso cref="BAP.BL.IContentLocalizationBL" />
    public partial class BusinessLayer : ICurrencyBL
    {
        /// <summary>
        /// Gets all currencies.
        /// </summary>
        /// <returns>IList&lt;Currency&gt;.</returns>
        public IList<Currency> GetAllCurrencies()
        {
            return _unitOfWork.CurrencyRepository.GetAll();
        }

        /// <summary>
        /// get all currencies as an asynchronous operation.
        /// </summary>
        /// <returns>IList&lt;Currency&gt;.</returns>
        public async Task<IList<Currency>> GetAllCurrenciesAsync()
        {
            return await _unitOfWork.CurrencyRepository.GetAllAsync();
        }

        /// <summary>
        /// Searches the currencies.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;Currency&gt;.</returns>
        public IPagedList<Currency> SearchCurrencies(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<Currency>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {                
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            return _unitOfWork.CurrencyRepository.GetPagedList(page, pageSize, ParseJSONSearchString<Currency>(where), sortExpression);
        }

        /// <summary>
        /// search currencies as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;Currency&gt;.</returns>
        public async Task<IPagedList<Currency>> SearchCurrenciesAsync(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<Currency>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            return await _unitOfWork.CurrencyRepository.GetPagedListAsync(page, pageSize, ParseJSONSearchString<Currency>(where), sortExpression);
        }

        /// <summary>
        /// Searches the currencies.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>IList&lt;Currency&gt;.</returns>
        public IList<Currency> SearchCurrencies(string where, string sort)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<Currency>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            return _unitOfWork.CurrencyRepository.GetList(ParseJSONSearchString<Currency>(where), sortExpression);
        }

        /// <summary>
        /// search currencies as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>IList&lt;Currency&gt;.</returns>
        public async Task<IList<Currency>> SearchCurrenciesAsync(string where, string sort)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<Currency>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            return await _unitOfWork.CurrencyRepository.GetListAsync(ParseJSONSearchString<Currency>(where), sortExpression);
        }

        /// <summary>
        /// Gets the currency by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Currency.</returns>
        public Currency GetCurrencyById(int id)
        {
            return _unitOfWork.CurrencyRepository.GetSingle(c => c.Id == id);
        }

        /// <summary>
        /// get currency by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Currency.</returns>
        public async Task<Currency> GetCurrencyByIdAsync(int id)
        {
            return await _unitOfWork.CurrencyRepository.GetSingleAsync(c => c.Id == id);
        }

        /// <summary>
        /// Gets the main currency.
        /// </summary>
        /// <returns>Currency.</returns>
        public Currency GetMainCurrency()
        {
            var key = "MAIN_CURRENCY_KEY_" + _authContext.GetCurrentOrganizationId(_configHelper).ToString();
            Currency result = (Currency)_cache[key];
            if(result == null)
            {
                result = _unitOfWork.CurrencyRepository.GetSingle(c => c.IsEnabled && c.IsMain);
                _cache[key] = result;
            }
            return result;
        }

        /// <summary>
        /// get main currency as an asynchronous operation.
        /// </summary>
        /// <returns>Currency.</returns>
        public async Task<Currency> GetMainCurrencyAsync()
        {
            var key = "MAIN_CURRENCY_KEY_" + _authContext.GetCurrentOrganizationId(_configHelper).ToString();            
            Currency result = (Currency)_cache[key];
            if (result == null)
            {
                result = await _unitOfWork.CurrencyRepository.GetSingleAsync(c => c.IsEnabled && c.IsMain);
                _cache[key] = result;
            }
            return result;
        }

        /// <summary>
        /// Adds the currency.
        /// </summary>
        /// <param name="currencies">The currencies.</param>
        public void AddCurrency(params Currency[] currencies)
        {
            _unitOfWork.CurrencyRepository.Add(currencies);
            _unitOfWork.Save();
        }

        /// <summary>
        /// add currency as an asynchronous operation.
        /// </summary>
        /// <param name="currencies">The currencies.</param>
        public async Task AddCurrencyAsync(params Currency[] currencies)
        {
            _unitOfWork.CurrencyRepository.Add(currencies);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Updates the currency.
        /// </summary>
        /// <param name="currencies">The currencies.</param>
        public void UpdateCurrency(params Currency[] currencies)
        {
            _unitOfWork.CurrencyRepository.Update(currencies);
            _unitOfWork.Save();
        }

        /// <summary>
        /// update currency as an asynchronous operation.
        /// </summary>
        /// <param name="currencies">The currencies.</param>
        public async Task UpdateCurrencyAsync(params Currency[] currencies)
        {
            _unitOfWork.CurrencyRepository.Update(currencies);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Removes the currency.
        /// </summary>
        /// <param name="currencies">The currencies.</param>
        public void RemoveCurrency(params Currency[] currencies)
        {
            _unitOfWork.CurrencyRepository.Remove(currencies);
            _unitOfWork.Save();
        }

        /// <summary>
        /// remove currency as an asynchronous operation.
        /// </summary>
        /// <param name="currencies">The currencies.</param>
        public async Task RemoveCurrencyAsync(params Currency[] currencies)
        {
            _unitOfWork.CurrencyRepository.Remove(currencies);
            await _unitOfWork.SaveAsync();
        }
    }

    /// <summary>
    /// Class CurrencyBL.
    /// Implements the <see cref="BAP.BL.BusinessLayer" />
    /// Implements the <see cref="BAP.Common.ISupportLookup" />
    /// </summary>
    /// <seealso cref="BAP.BL.BusinessLayer" />
    /// <seealso cref="BAP.Common.ISupportLookup" />
    public class CurrencyBL : BusinessLayer, ISupportLookup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyBL"/> class.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        public CurrencyBL(IConfigHelper settings, IAuthorizationContext context, ILogger logger) : base(settings, context, logger)
        {

        }

        /// <summary>
        /// Gets the lookup items.
        /// </summary>
        /// <param name="valueField">The value field.</param>
        /// <param name="textField">The text field.</param>
        /// <param name="descriptionField">The description field.</param>
        /// <param name="extraFilter">The extra filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="roles">The roles.</param>
        /// <param name="setCurrentUserAsSelected">if set to <c>true</c> [set current user as selected].</param>
        /// <returns>IList&lt;LookupItem&gt;.</returns>
        public IList<LookupItem> GetLookupItems(string valueField, string textField, string descriptionField, string extraFilter, string orderBy, List<string> roles = null, bool setCurrentUserAsSelected = false)
        {
            List<LookupItem> result = new List<LookupItem>();
            var currencies = SearchCurrencies(extraFilter, orderBy);
            foreach (var currency in currencies)
            {
                var val = currency.GetType().GetProperty(valueField).GetValue(currency, null);
                var text = currency.GetType().GetProperty(textField).GetValue(currency, null);                
                var descr = text;
                if (!string.IsNullOrEmpty(descriptionField))
                {
                    descr = currency.GetType().GetProperty(descriptionField).GetValue(currency, null);
                }
                result.Add(new LookupItem { Key = val.ToString(), Text = text.ToString(), Description = descr.ToString() });
            }

            return result;
        }

        /// <summary>
        /// get lookup items as an asynchronous operation.
        /// </summary>
        /// <param name="valueField">The value field.</param>
        /// <param name="textField">The text field.</param>
        /// <param name="descriptionField">The description field.</param>
        /// <param name="extraFilter">The extra filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="roles">The roles.</param>
        /// <param name="setCurrentUserAsSelected">if set to <c>true</c> [set current user as selected].</param>
        /// <returns>IList&lt;LookupItem&gt;.</returns>
        public async Task<IList<LookupItem>> GetLookupItemsAsync(string valueField, string textField, string descriptionField = "", string extraFilter = "",
            string orderBy = "", List<string> roles = null, bool setCurrentUserAsSelected = false)
        {
            List<LookupItem> result = new List<LookupItem>();
            var currencies = await SearchCurrenciesAsync(extraFilter, orderBy);
            foreach (var currency in currencies)
            {
                var val = currency.GetType().GetProperty(valueField).GetValue(currency, null);
                var text = currency.GetType().GetProperty(textField).GetValue(currency, null);
                var descr = text;
                if (!string.IsNullOrEmpty(descriptionField))
                {
                    descr = currency.GetType().GetProperty(descriptionField).GetValue(currency, null);
                }
                result.Add(new LookupItem { Key = val.ToString(), Text = text.ToString(), Description = descr.ToString() });
            }

            return result;
        }
    }
}
