// ***********************************************************************
// Assembly         : BAP.BL
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="LookupValueBL.cs" company="BAP Software Ltd.">
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
    /// Interface ILookupValueBL
    /// </summary>
    public interface ILookupValueBL
    {
        /// <summary>
        /// Gets all lookup values.
        /// </summary>
        /// <returns>IList&lt;LookupValue&gt;.</returns>
        IList<LookupValue> GetAllLookupValues();
        /// <summary>
        /// Gets all lookup values asynchronous.
        /// </summary>
        /// <returns>Task&lt;IList&lt;LookupValue&gt;&gt;.</returns>
        Task<IList<LookupValue>> GetAllLookupValuesAsync();

        /// <summary>
        /// Searches the lookup values.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;LookupValue&gt;.</returns>
        IPagedList<LookupValue> SearchLookupValues(string where, string sort, int page, int pageSize = 20);
        /// <summary>
        /// Searches the lookup values asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IPagedList&lt;LookupValue&gt;&gt;.</returns>
        Task<IPagedList<LookupValue>> SearchLookupValuesAsync(string where, string sort, int page, int pageSize = 20);

        /// <summary>
        /// Gets the lookup value by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>LookupValue.</returns>
        LookupValue GetLookupValueById(int id);
        /// <summary>
        /// Gets the lookup value by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;LookupValue&gt;.</returns>
        Task<LookupValue> GetLookupValueByIdAsync(int id);

        /// <summary>
        /// Adds the lookup value.
        /// </summary>
        /// <param name="lookupValues">The lookup values.</param>
        void AddLookupValue(params LookupValue[] lookupValues);
        /// <summary>
        /// Adds the lookup value asynchronous.
        /// </summary>
        /// <param name="lookupValues">The lookup values.</param>
        /// <returns>Task.</returns>
        Task AddLookupValueAsync(params LookupValue[] lookupValues);

        /// <summary>
        /// Updates the lookup value.
        /// </summary>
        /// <param name="lookupValues">The lookup values.</param>
        void UpdateLookupValue(params LookupValue[] lookupValues);
        /// <summary>
        /// Updates the lookup value asynchronous.
        /// </summary>
        /// <param name="lookupValues">The lookup values.</param>
        /// <returns>Task.</returns>
        Task UpdateLookupValueAsync(params LookupValue[] lookupValues);

        /// <summary>
        /// Removes the lookup value.
        /// </summary>
        /// <param name="lookupValues">The lookup values.</param>
        void RemoveLookupValue(params LookupValue[] lookupValues);
        /// <summary>
        /// Removes the lookup value asynchronous.
        /// </summary>
        /// <param name="lookupValues">The lookup values.</param>
        /// <returns>Task.</returns>
        Task RemoveLookupValueAsync(params LookupValue[] lookupValues);
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
    public partial class BusinessLayer : ILookupValueBL, ILocalizedBL<LookupValue>
    {
        /// <summary>
        /// Gets all lookup values.
        /// </summary>
        /// <returns>IList&lt;LookupValue&gt;.</returns>
        public IList<LookupValue> GetAllLookupValues()
        {
            return _unitOfWork.LookupValueRepository.GetAll();
        }

        /// <summary>
        /// get all lookup values as an asynchronous operation.
        /// </summary>
        /// <returns>IList&lt;LookupValue&gt;.</returns>
        public async Task<IList<LookupValue>> GetAllLookupValuesAsync()
        {
            return await _unitOfWork.LookupValueRepository.GetAllAsync();
        }

        /// <summary>
        /// Searches the lookup values.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;LookupValue&gt;.</returns>
        public IPagedList<LookupValue> SearchLookupValues(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<LookupValue>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return _unitOfWork.LookupValueRepository.GetPagedList(page, pageSize, ParseJSONSearchString<LookupValue>(where), sortExpression);
        }

        /// <summary>
        /// search lookup values as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;LookupValue&gt;.</returns>
        public async Task<IPagedList<LookupValue>> SearchLookupValuesAsync(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<LookupValue>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return await _unitOfWork.LookupValueRepository.GetPagedListAsync(page, pageSize, ParseJSONSearchString<LookupValue>(where), sortExpression);
        }

        /// <summary>
        /// Gets the lookup value by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>LookupValue.</returns>
        public LookupValue GetLookupValueById(int id)
        {
            return _unitOfWork.LookupValueRepository.GetSingle(c => c.Id == id, c => c.Parent);
        }

        /// <summary>
        /// get lookup value by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>LookupValue.</returns>
        public async Task<LookupValue> GetLookupValueByIdAsync(int id)
        {
            return await _unitOfWork.LookupValueRepository.GetSingleAsync(c => c.Id == id, c => c.Parent);
        }

        /// <summary>
        /// Adds the lookup value.
        /// </summary>
        /// <param name="lookupValues">The lookup values.</param>
        public void AddLookupValue(params LookupValue[] lookupValues)
        {
            foreach(var value in lookupValues)
            {
                //Just in order to attach to context
                if(value.Parent != null)
                {
                    _unitOfWork.LookupRepository.Update(value.Parent);
                }
            }
            _unitOfWork.LookupValueRepository.Add(lookupValues);
            _unitOfWork.Save();
        }

        /// <summary>
        /// add lookup value as an asynchronous operation.
        /// </summary>
        /// <param name="lookupValues">The lookup values.</param>
        public async Task AddLookupValueAsync(params LookupValue[] lookupValues)
        {
            foreach (var value in lookupValues)
            {
                //Just in order to attach to context
                if (value.Parent != null)
                {
                    _unitOfWork.LookupRepository.Update(value.Parent);
                }
            }
            _unitOfWork.LookupValueRepository.Add(lookupValues);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Updates the lookup value.
        /// </summary>
        /// <param name="lookupValues">The lookup values.</param>
        public void UpdateLookupValue(params LookupValue[] lookupValues)
        {
            _unitOfWork.LookupValueRepository.Update(lookupValues);
            _unitOfWork.Save();
        }

        /// <summary>
        /// update lookup value as an asynchronous operation.
        /// </summary>
        /// <param name="lookupValues">The lookup values.</param>
        public async Task UpdateLookupValueAsync(params LookupValue[] lookupValues)
        {
            _unitOfWork.LookupValueRepository.Update(lookupValues);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Removes the lookup value.
        /// </summary>
        /// <param name="lookupValues">The lookup values.</param>
        public void RemoveLookupValue(params LookupValue[] lookupValues)
        {
            _unitOfWork.LookupValueRepository.Remove(lookupValues);
            _unitOfWork.Save();
        }

        /// <summary>
        /// remove lookup value as an asynchronous operation.
        /// </summary>
        /// <param name="lookupValues">The lookup values.</param>
        public async Task RemoveLookupValueAsync(params LookupValue[] lookupValues)
        {
            _unitOfWork.LookupValueRepository.Remove(lookupValues);
            await _unitOfWork.SaveAsync();
        }

        #region ILocalizedBL
        /// <summary>
        /// Get full details of the single entity
        /// </summary>
        /// <param name="ofEntity">Passed entity is used as filter, method implementing ths feature should treat this oject apropriatly to call some method of BL class to read full details.</param>
        /// <returns>Entity instance</returns>
        public LookupValue GetDetails(LookupValue ofEntity)
        {
            if (ofEntity == null)
                return null;

            if (ofEntity.Id > 0)
                return GetLookupValueById(ofEntity.Id);
            
            return null;
        }

        /// <summary>
        /// Adds the single entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void AddSingleEntity(LookupValue entity)
        {
            _unitOfWork.LookupValueRepository.Add(entity);
            _unitOfWork.Save();
        }
        #endregion
    }
}
