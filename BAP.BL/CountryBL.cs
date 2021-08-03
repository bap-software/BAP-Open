// ***********************************************************************
// Assembly         : BAP.BL
// Author           : Victor Mamray
// Created          : 05-24-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="CountryBL.cs" company="BAP Software Ltd.">
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
    /// Interface ICountryBL
    /// </summary>
    public interface ICountryBL
    {
        /// <summary>
        /// Gets all countries.
        /// </summary>
        /// <returns>IList&lt;Country&gt;.</returns>
        IList<Country> GetAllCountries();
        /// <summary>
        /// Gets all countries asynchronous.
        /// </summary>
        /// <returns>Task&lt;IList&lt;Country&gt;&gt;.</returns>
        Task<IList<Country>> GetAllCountriesAsync();

        /// <summary>
        /// Searches the countries.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;Country&gt;.</returns>
        IPagedList<Country> SearchCountries(string where, string sort, int page, int pageSize = 20);
        /// <summary>
        /// Searches the countries asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IPagedList&lt;Country&gt;&gt;.</returns>
        Task<IPagedList<Country>> SearchCountriesAsync(string where, string sort, int page, int pageSize = 20);

        /// <summary>
        /// Searches the countries.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>IList&lt;Country&gt;.</returns>
        IList<Country> SearchCountries(string where, string sort);
        /// <summary>
        /// Searches the countries asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>Task&lt;IList&lt;Country&gt;&gt;.</returns>
        Task<IList<Country>> SearchCountriesAsync(string where, string sort);

        /// <summary>
        /// Gets the country by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Country.</returns>
        Country GetCountryById(int id);
        /// <summary>
        /// Gets the country by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;Country&gt;.</returns>
        Task<Country> GetCountryByIdAsync(int id);

        /// <summary>
        /// Adds the country.
        /// </summary>
        /// <param name="countries">The countries.</param>
        void AddCountry(params Country[] countries);
        /// <summary>
        /// Adds the country asynchronous.
        /// </summary>
        /// <param name="countries">The countries.</param>
        /// <returns>Task.</returns>
        Task AddCountryAsync(params Country[] countries);

        /// <summary>
        /// Updates the country.
        /// </summary>
        /// <param name="countries">The countries.</param>
        void UpdateCountry(params Country[] countries);
        /// <summary>
        /// Updates the country asynchronous.
        /// </summary>
        /// <param name="countries">The countries.</param>
        /// <returns>Task.</returns>
        Task UpdateCountryAsync(params Country[] countries);

        /// <summary>
        /// Removes the country.
        /// </summary>
        /// <param name="countries">The countries.</param>
        void RemoveCountry(params Country[] countries);
        /// <summary>
        /// Removes the country asynchronous.
        /// </summary>
        /// <param name="countries">The countries.</param>
        /// <returns>Task.</returns>
        Task RemoveCountryAsync(params Country[] countries);
    }

    public partial class BusinessLayer : ICountryBL
    {
        /// <summary>
        /// Gets all countries.
        /// </summary>
        /// <returns>IList&lt;Country&gt;.</returns>
        public IList<Country> GetAllCountries()
        {
            return _unitOfWork.CountryRepository.GetAll();
        }

        /// <summary>
        /// get all countries as an asynchronous operation.
        /// </summary>
        /// <returns>IList&lt;Country&gt;.</returns>
        public async Task<IList<Country>> GetAllCountriesAsync()
        {
            return await _unitOfWork.CountryRepository.GetAllAsync();
        }

        /// <summary>
        /// Searches the countries.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;Country&gt;.</returns>
        public IPagedList<Country> SearchCountries(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<Country>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {                
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            return _unitOfWork.CountryRepository.GetPagedList(page, pageSize, ParseJSONSearchString<Country>(where), sortExpression);
        }

        /// <summary>
        /// search countries as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;Country&gt;.</returns>
        public async Task<IPagedList<Country>> SearchCountriesAsync(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<Country>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            return await _unitOfWork.CountryRepository.GetPagedListAsync(page, pageSize, ParseJSONSearchString<Country>(where), sortExpression);
        }

        /// <summary>
        /// Searches the countries.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>IList&lt;Country&gt;.</returns>
        public IList<Country> SearchCountries(string where, string sort)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<Country>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            return _unitOfWork.CountryRepository.GetList(ParseJSONSearchString<Country>(where), sortExpression);
        }

        /// <summary>
        /// search countries as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>IList&lt;Country&gt;.</returns>
        public async Task<IList<Country>> SearchCountriesAsync(string where, string sort)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<Country>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            return await _unitOfWork.CountryRepository.GetListAsync(ParseJSONSearchString<Country>(where), sortExpression);
        }

        /// <summary>
        /// Gets the country by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Country.</returns>
        public Country GetCountryById(int id)
        {
            return _unitOfWork.CountryRepository.GetSingle(c => c.Id == id, c => c.States);
        }

        /// <summary>
        /// get country by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Country.</returns>
        public async Task<Country> GetCountryByIdAsync(int id)
        {
            return await _unitOfWork.CountryRepository.GetSingleAsync(c => c.Id == id, c => c.States);
        }

        /// <summary>
        /// Adds the country.
        /// </summary>
        /// <param name="countries">The countries.</param>
        public void AddCountry(params Country[] countries)
        {
            _unitOfWork.CountryRepository.Add(countries);
            _unitOfWork.Save();
        }

        /// <summary>
        /// add country as an asynchronous operation.
        /// </summary>
        /// <param name="countries">The countries.</param>
        public async Task AddCountryAsync(params Country[] countries)
        {
            _unitOfWork.CountryRepository.Add(countries);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Updates the country.
        /// </summary>
        /// <param name="countries">The countries.</param>
        public void UpdateCountry(params Country[] countries)
        {
            _unitOfWork.CountryRepository.Update(countries);
            _unitOfWork.Save();
        }

        /// <summary>
        /// update country as an asynchronous operation.
        /// </summary>
        /// <param name="countries">The countries.</param>
        public async Task UpdateCountryAsync(params Country[] countries)
        {
            _unitOfWork.CountryRepository.Update(countries);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Removes the country.
        /// </summary>
        /// <param name="countries">The countries.</param>
        public void RemoveCountry(params Country[] countries)
        {
            _unitOfWork.CountryRepository.Remove(countries);
            _unitOfWork.Save();
        }

        /// <summary>
        /// remove country as an asynchronous operation.
        /// </summary>
        /// <param name="countries">The countries.</param>
        public async Task RemoveCountryAsync(params Country[] countries)
        {
            _unitOfWork.CountryRepository.Remove(countries);
            await _unitOfWork.SaveAsync();
        }
    }

    /// <summary>
    /// Class CountryBL.
    /// Implements the <see cref="BAP.BL.BusinessLayer" />
    /// Implements the <see cref="BAP.Common.ISupportLookup" />
    /// </summary>
    /// <seealso cref="BAP.BL.BusinessLayer" />
    /// <seealso cref="BAP.Common.ISupportLookup" />
    public class CountryBL : BusinessLayer, ISupportLookup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CountryBL"/> class.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        public CountryBL(IConfigHelper settings, IAuthorizationContext context, ILogger logger) : base(settings, context, logger)
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
            var countries = SearchCountries(extraFilter, orderBy);
            foreach (var country in countries)
            {
                var val = country.GetType().GetProperty(valueField).GetValue(country, null);
                var text = country.GetType().GetProperty(textField).GetValue(country, null);                
                var descr = text;
                if (!string.IsNullOrEmpty(descriptionField))
                {
                    descr = country.GetType().GetProperty(descriptionField).GetValue(country, null);
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
            var countries = await SearchCountriesAsync(extraFilter, orderBy);
            foreach (var country in countries)
            {
                var val = country.GetType().GetProperty(valueField).GetValue(country, null);
                var text = country.GetType().GetProperty(textField).GetValue(country, null);
                var descr = text;
                if (!string.IsNullOrEmpty(descriptionField))
                {
                    descr = country.GetType().GetProperty(descriptionField).GetValue(country, null);
                }
                result.Add(new LookupItem { Key = val.ToString(), Text = text.ToString(), Description = descr.ToString() });
            }

            return result;
        }
    }
}
