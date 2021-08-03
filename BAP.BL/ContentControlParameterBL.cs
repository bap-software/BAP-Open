// ***********************************************************************
// Assembly         : BAP.BL
// Author           : Victor Mamray
// Created          : 05-20-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="ContentControlParameterBL.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Threading.Tasks;
using PagedList;

using BAP.Common;
using BAP.DAL.Entities;

namespace BAP.BL
{
    /// <summary>
    /// Interface IContentControlParameterBL
    /// </summary>
    public interface IContentControlParameterBL
    {
        /// <summary>
        /// Gets all content control parameters.
        /// </summary>
        /// <returns>IList&lt;ContentControlParameter&gt;.</returns>
        IList<ContentControlParameter> GetAllContentControlParameters();
        /// <summary>
        /// Gets all content control parameters asynchronous.
        /// </summary>
        /// <returns>Task&lt;IList&lt;ContentControlParameter&gt;&gt;.</returns>
        Task<IList<ContentControlParameter>> GetAllContentControlParametersAsync();

        /// <summary>
        /// Searches the content control parameters.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;ContentControlParameter&gt;.</returns>
        IPagedList<ContentControlParameter> SearchContentControlParameters(string where, string sort, int page, int pageSize = 20);
        /// <summary>
        /// Searches the content control parameters asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IPagedList&lt;ContentControlParameter&gt;&gt;.</returns>
        Task<IPagedList<ContentControlParameter>> SearchContentControlParametersAsync(string where, string sort, int page, int pageSize = 20);

        /// <summary>
        /// Gets the content control parameter by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ContentControlParameter.</returns>
        ContentControlParameter GetContentControlParameterById(int id);
        /// <summary>
        /// Gets the content control parameter by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;ContentControlParameter&gt;.</returns>
        Task<ContentControlParameter> GetContentControlParameterByIdAsync(int id);

        /// <summary>
        /// Adds the content control parameter.
        /// </summary>
        /// <param name="contentControlParameters">The content control parameters.</param>
        void AddContentControlParameter(params ContentControlParameter[] contentControlParameters);
        /// <summary>
        /// Adds the content control parameter asynchronous.
        /// </summary>
        /// <param name="contentControlParameters">The content control parameters.</param>
        /// <returns>Task.</returns>
        Task AddContentControlParameterAsync(params ContentControlParameter[] contentControlParameters);

        /// <summary>
        /// Updates the content control parameter.
        /// </summary>
        /// <param name="contentControlParameters">The content control parameters.</param>
        void UpdateContentControlParameter(params ContentControlParameter[] contentControlParameters);
        /// <summary>
        /// Updates the content control parameter asynchronous.
        /// </summary>
        /// <param name="contentControlParameters">The content control parameters.</param>
        /// <returns>Task.</returns>
        Task UpdateContentControlParameterAsync(params ContentControlParameter[] contentControlParameters);

        /// <summary>
        /// Removes the content control parameter.
        /// </summary>
        /// <param name="contentControlParameters">The content control parameters.</param>
        void RemoveContentControlParameter(params ContentControlParameter[] contentControlParameters);
        /// <summary>
        /// Removes the content control parameter asynchronous.
        /// </summary>
        /// <param name="contentControlParameters">The content control parameters.</param>
        /// <returns>Task.</returns>
        Task RemoveContentControlParameterAsync(params ContentControlParameter[] contentControlParameters);
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
    public partial class BusinessLayer : IContentControlParameterBL
    {

        #region ContentControlParameters

        /// <summary>
        /// Gets all content control parameters.
        /// </summary>
        /// <returns>IList&lt;ContentControlParameter&gt;.</returns>
        public IList<ContentControlParameter> GetAllContentControlParameters()
        {
            return _unitOfWork.ContentControlParameterRepository.GetAll();
        }

        /// <summary>
        /// get all content control parameters as an asynchronous operation.
        /// </summary>
        /// <returns>IList&lt;ContentControlParameter&gt;.</returns>
        public async Task<IList<ContentControlParameter>> GetAllContentControlParametersAsync()
        {
            return await _unitOfWork.ContentControlParameterRepository.GetAllAsync();
        }

        /// <summary>
        /// Searches the content control parameters.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;ContentControlParameter&gt;.</returns>
        public IPagedList<ContentControlParameter> SearchContentControlParameters(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<ContentControlParameter>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return _unitOfWork.ContentControlParameterRepository.GetPagedList(page, pageSize, ParseJSONSearchString<ContentControlParameter>(where), sortExpression, a => a.ContentViewControl);
        }

        /// <summary>
        /// search content control parameters as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;ContentControlParameter&gt;.</returns>
        public async Task<IPagedList<ContentControlParameter>> SearchContentControlParametersAsync(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<ContentControlParameter>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return await _unitOfWork.ContentControlParameterRepository.GetPagedListAsync(page, pageSize, ParseJSONSearchString<ContentControlParameter>(where), sortExpression, a => a.ContentViewControl);
        }

        /// <summary>
        /// Gets the content control parameter by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ContentControlParameter.</returns>
        public ContentControlParameter GetContentControlParameterById(int id)
        {
            return _unitOfWork.ContentControlParameterRepository.GetSingle(a => a.Id == id, a => a.ContentViewControl);
        }

        /// <summary>
        /// get content control parameter by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ContentControlParameter.</returns>
        public async Task<ContentControlParameter> GetContentControlParameterByIdAsync(int id)
        {
            return await _unitOfWork.ContentControlParameterRepository.GetSingleAsync(a => a.Id == id, a => a.ContentViewControl);
        }

        /// <summary>
        /// Adds the content control parameter.
        /// </summary>
        /// <param name="contentControlParameters">The content control parameters.</param>
        public void AddContentControlParameter(params ContentControlParameter[] contentControlParameters)
        {
            _unitOfWork.ContentControlParameterRepository.Add(contentControlParameters);
            _unitOfWork.Save();
        }

        /// <summary>
        /// add content control parameter as an asynchronous operation.
        /// </summary>
        /// <param name="contentControlParameters">The content control parameters.</param>
        public async Task AddContentControlParameterAsync(params ContentControlParameter[] contentControlParameters)
        {
            _unitOfWork.ContentControlParameterRepository.Add(contentControlParameters);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Updates the content control parameter.
        /// </summary>
        /// <param name="contentControlParameters">The content control parameters.</param>
        public void UpdateContentControlParameter(params ContentControlParameter[] contentControlParameters)
        {
            _unitOfWork.ContentControlParameterRepository.Update(contentControlParameters);
            _unitOfWork.Save();
        }

        /// <summary>
        /// update content control parameter as an asynchronous operation.
        /// </summary>
        /// <param name="contentControlParameters">The content control parameters.</param>
        public async Task UpdateContentControlParameterAsync(params ContentControlParameter[] contentControlParameters)
        {
            _unitOfWork.ContentControlParameterRepository.Update(contentControlParameters);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Removes the content control parameter.
        /// </summary>
        /// <param name="contentControlParameters">The content control parameters.</param>
        public void RemoveContentControlParameter(params ContentControlParameter[] contentControlParameters)
        {
            _unitOfWork.ContentControlParameterRepository.Remove(contentControlParameters);
            _unitOfWork.Save();
        }

        /// <summary>
        /// remove content control parameter as an asynchronous operation.
        /// </summary>
        /// <param name="contentControlParameters">The content control parameters.</param>
        public async Task RemoveContentControlParameterAsync(params ContentControlParameter[] contentControlParameters)
        {
            _unitOfWork.ContentControlParameterRepository.Remove(contentControlParameters);
            await _unitOfWork.SaveAsync();
        }

        #endregion
    }
}
