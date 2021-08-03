// ***********************************************************************
// Assembly         : BAP.BL
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="LookupBL.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;

using PagedList;

using BAP.Common;
using BAP.DAL.Entities;
using System;
using System.Threading.Tasks;

namespace BAP.BL
{
    /// <summary>
    /// Interface ILookupBL
    /// </summary>
    public interface ILookupBL
    {
        /// <summary>
        /// Gets all lookups.
        /// </summary>
        /// <returns>IList&lt;Lookup&gt;.</returns>
        IList<Lookup> GetAllLookups();
        /// <summary>
        /// Gets all lookups asynchronous.
        /// </summary>
        /// <returns>Task&lt;IList&lt;Lookup&gt;&gt;.</returns>
        Task<IList<Lookup>> GetAllLookupsAsync();

        /// <summary>
        /// Searches the lookups.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;Lookup&gt;.</returns>
        IPagedList<Lookup> SearchLookups(string where, string sort, int page, int pageSize = 20);
        /// <summary>
        /// Searches the lookups asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IPagedList&lt;Lookup&gt;&gt;.</returns>
        Task<IPagedList<Lookup>> SearchLookupsAsync(string where, string sort, int page, int pageSize = 20);

        /// <summary>
        /// Gets the lookup by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Lookup.</returns>
        Lookup GetLookupById(int id);
        /// <summary>
        /// Gets the lookup by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;Lookup&gt;.</returns>
        Task<Lookup> GetLookupByIdAsync(int id);

        /// <summary>
        /// Gets the name of the lookup by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Lookup.</returns>
        Lookup GetLookupByName(string name);
        /// <summary>
        /// Gets the lookup by name asynchronous.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Task&lt;Lookup&gt;.</returns>
        Task<Lookup> GetLookupByNameAsync(string name);

        /// <summary>
        /// Adds the lookup.
        /// </summary>
        /// <param name="lookups">The lookups.</param>
        void AddLookup(params Lookup[] lookups);
        /// <summary>
        /// Adds the lookup asynchronous.
        /// </summary>
        /// <param name="lookups">The lookups.</param>
        /// <returns>Task.</returns>
        Task AddLookupAsync(params Lookup[] lookups);

        /// <summary>
        /// Updates the lookup.
        /// </summary>
        /// <param name="lookups">The lookups.</param>
        void UpdateLookup(params Lookup[] lookups);
        /// <summary>
        /// Updates the lookup asynchronous.
        /// </summary>
        /// <param name="lookups">The lookups.</param>
        /// <returns>Task.</returns>
        Task UpdateLookupAsync(params Lookup[] lookups);

        /// <summary>
        /// Removes the lookup.
        /// </summary>
        /// <param name="lookups">The lookups.</param>
        void RemoveLookup(params Lookup[] lookups);
        /// <summary>
        /// Removes the lookup asynchronous.
        /// </summary>
        /// <param name="lookups">The lookups.</param>
        /// <returns>Task.</returns>
        Task RemoveLookupAsync(params Lookup[] lookups);
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
    public partial class BusinessLayer : ILookupBL, ILocalizedBL<Lookup>
    {
        /// <summary>
        /// Gets all lookups.
        /// </summary>
        /// <returns>IList&lt;Lookup&gt;.</returns>
        public IList<Lookup> GetAllLookups()
        {
            return _unitOfWork.LookupRepository.GetAll();
        }

        /// <summary>
        /// get all lookups as an asynchronous operation.
        /// </summary>
        /// <returns>IList&lt;Lookup&gt;.</returns>
        public async Task<IList<Lookup>> GetAllLookupsAsync()
        {
            return await _unitOfWork.LookupRepository.GetAllAsync();
        }

        /// <summary>
        /// Searches the lookups.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;Lookup&gt;.</returns>
        public IPagedList<Lookup> SearchLookups(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<Lookup>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return _unitOfWork.LookupRepository.GetPagedList(page, pageSize, ParseJSONSearchString<Lookup>(where), sortExpression);
        }

        /// <summary>
        /// search lookups as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;Lookup&gt;.</returns>
        public async Task<IPagedList<Lookup>> SearchLookupsAsync(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<Lookup>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return await _unitOfWork.LookupRepository.GetPagedListAsync(page, pageSize, ParseJSONSearchString<Lookup>(where), sortExpression);
        }

        /// <summary>
        /// Gets the lookup by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Lookup.</returns>
        public Lookup GetLookupById(int id)
        {
            return _unitOfWork.LookupRepository.GetSingle(c => c.Id == id, c => c.Values);
        }

        /// <summary>
        /// get lookup by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Lookup.</returns>
        public async Task<Lookup> GetLookupByIdAsync(int id)
        {
            return await _unitOfWork.LookupRepository.GetSingleAsync(c => c.Id == id, c => c.Values);
        }

        /// <summary>
        /// Gets the name of the lookup by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Lookup.</returns>
        public Lookup GetLookupByName(string name)
        {
            return _unitOfWork.LookupRepository.GetSingle(c => c.Name == name, c => c.Values);
        }

        /// <summary>
        /// get lookup by name as an asynchronous operation.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Lookup.</returns>
        public async Task<Lookup> GetLookupByNameAsync(string name)
        {
            return await _unitOfWork.LookupRepository.GetSingleAsync(c => c.Name == name, c => c.Values);
        }

        /// <summary>
        /// Adds the lookup.
        /// </summary>
        /// <param name="lookups">The lookups.</param>
        public void AddLookup(params Lookup[] lookups)
        {
            _unitOfWork.LookupRepository.Add(lookups);
            _unitOfWork.Save();
        }

        /// <summary>
        /// add lookup as an asynchronous operation.
        /// </summary>
        /// <param name="lookups">The lookups.</param>
        public async Task AddLookupAsync(params Lookup[] lookups)
        {
            _unitOfWork.LookupRepository.Add(lookups);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Updates the lookup.
        /// </summary>
        /// <param name="lookups">The lookups.</param>
        public void UpdateLookup(params Lookup[] lookups)
        {
            _unitOfWork.LookupRepository.Update(lookups);
            _unitOfWork.Save();
        }

        /// <summary>
        /// update lookup as an asynchronous operation.
        /// </summary>
        /// <param name="lookups">The lookups.</param>
        public async Task UpdateLookupAsync(params Lookup[] lookups)
        {
            _unitOfWork.LookupRepository.Update(lookups);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Removes the lookup.
        /// </summary>
        /// <param name="lookups">The lookups.</param>
        public void RemoveLookup(params Lookup[] lookups)
        {
            _unitOfWork.LookupRepository.Remove(lookups);
            _unitOfWork.Save();
        }

        /// <summary>
        /// remove lookup as an asynchronous operation.
        /// </summary>
        /// <param name="lookups">The lookups.</param>
        public async Task RemoveLookupAsync(params Lookup[] lookups)
        {
            _unitOfWork.LookupRepository.Remove(lookups);
            await _unitOfWork.SaveAsync();
        }

        #region ILocalizedBL
        /// <summary>
        /// Get full details of the single entity
        /// </summary>
        /// <param name="ofEntity">Passed entity is used as filter, method implementing ths feature should treat this oject apropriatly to call some method of BL class to read full details.</param>
        /// <returns>Entity instance</returns>
        public Lookup GetDetails(Lookup ofEntity)
        {
            if (ofEntity == null)
                return null;

            if (ofEntity.Id > 0)
                return GetLookupById(ofEntity.Id);
            
            return null;
        }

        /// <summary>
        /// Adds the single entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void AddSingleEntity(Lookup entity)
        {
            _unitOfWork.LookupRepository.Add(entity);
            _unitOfWork.Save();
        }
        #endregion
    }
}
