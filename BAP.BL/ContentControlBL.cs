// ***********************************************************************
// Assembly         : BAP.BL
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="ContentControlBL.cs" company="BAP Software Ltd.">
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
    /// Interface IContentControlBL
    /// </summary>
    public interface IContentControlBL
    {
        /// <summary>
        /// Gets all content controls.
        /// </summary>
        /// <returns>IList&lt;ContentControl&gt;.</returns>
        IList<ContentControl> GetAllContentControls();
        /// <summary>
        /// Gets all content controls asynchronous.
        /// </summary>
        /// <returns>Task&lt;IList&lt;ContentControl&gt;&gt;.</returns>
        Task<IList<ContentControl>> GetAllContentControlsAsync();

        /// <summary>
        /// Searches the content controls.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;ContentControl&gt;.</returns>
        IPagedList<ContentControl> SearchContentControls(string where, string sort, int page, int pageSize = 20);
        /// <summary>
        /// Searches the content controls asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IPagedList&lt;ContentControl&gt;&gt;.</returns>
        Task<IPagedList<ContentControl>> SearchContentControlsAsync(string where, string sort, int page, int pageSize = 20);

        /// <summary>
        /// Gets the content control by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ContentControl.</returns>
        ContentControl GetContentControlById(int id);
        /// <summary>
        /// Gets the content control by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;ContentControl&gt;.</returns>
        Task<ContentControl> GetContentControlByIdAsync(int id);

        /// <summary>
        /// Adds the content control.
        /// </summary>
        /// <param name="contentControls">The content controls.</param>
        void AddContentControl(params ContentControl[] contentControls);
        /// <summary>
        /// Adds the content control asynchronous.
        /// </summary>
        /// <param name="contentControls">The content controls.</param>
        /// <returns>Task.</returns>
        Task AddContentControlAsync(params ContentControl[] contentControls);

        /// <summary>
        /// Updates the content control.
        /// </summary>
        /// <param name="contentControls">The content controls.</param>
        void UpdateContentControl(params ContentControl[] contentControls);
        /// <summary>
        /// Updates the content control asynchronous.
        /// </summary>
        /// <param name="contentControls">The content controls.</param>
        /// <returns>Task.</returns>
        Task UpdateContentControlAsync(params ContentControl[] contentControls);

        /// <summary>
        /// Removes the content control.
        /// </summary>
        /// <param name="contentControls">The content controls.</param>
        void RemoveContentControl(params ContentControl[] contentControls);
        /// <summary>
        /// Removes the content control asynchronous.
        /// </summary>
        /// <param name="contentControls">The content controls.</param>
        /// <returns>Task.</returns>
        Task RemoveContentControlAsync(params ContentControl[] contentControls);
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
    public partial class BusinessLayer : IContentControlBL, ILocalizedBL<ContentControl>
    {
        #region ContentControls

        /// <summary>
        /// Gets all content controls.
        /// </summary>
        /// <returns>IList&lt;ContentControl&gt;.</returns>
        public IList<ContentControl> GetAllContentControls()
        {
            return _unitOfWork.ContentControlRepository.GetAll();
        }

        /// <summary>
        /// get all content controls as an asynchronous operation.
        /// </summary>
        /// <returns>IList&lt;ContentControl&gt;.</returns>
        public async Task<IList<ContentControl>> GetAllContentControlsAsync()
        {
            return await _unitOfWork.ContentControlRepository.GetAllAsync();
        }

        /// <summary>
        /// Searches the content controls.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;ContentControl&gt;.</returns>
        public IPagedList<ContentControl> SearchContentControls(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<ContentControl>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return _unitOfWork.ContentControlRepository.GetPagedList(page, pageSize, ParseJSONSearchString<ContentControl>(where), sortExpression, a => a.ContentControlType);
        }

        /// <summary>
        /// search content controls as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;ContentControl&gt;.</returns>
        public async Task<IPagedList<ContentControl>> SearchContentControlsAsync(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<ContentControl>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return await _unitOfWork.ContentControlRepository.GetPagedListAsync(page, pageSize, ParseJSONSearchString<ContentControl>(where), sortExpression, a => a.ContentControlType);
        }

        /// <summary>
        /// Gets the content control by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ContentControl.</returns>
        public ContentControl GetContentControlById(int id)
        {
            return _unitOfWork.ContentControlRepository.GetSingle(a => a.Id == id, a => a.ContentControlType);
        }

        /// <summary>
        /// get content control by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ContentControl.</returns>
        public async Task<ContentControl> GetContentControlByIdAsync(int id)
        {
            return await _unitOfWork.ContentControlRepository.GetSingleAsync(a => a.Id == id, a => a.ContentControlType);
        }

        /// <summary>
        /// Adds the content control.
        /// </summary>
        /// <param name="contentControls">The content controls.</param>
        public void AddContentControl(params ContentControl[] contentControls)
        {
            _unitOfWork.ContentControlRepository.Add(contentControls);
            _unitOfWork.Save();
        }

        /// <summary>
        /// add content control as an asynchronous operation.
        /// </summary>
        /// <param name="contentControls">The content controls.</param>
        public async Task AddContentControlAsync(params ContentControl[] contentControls)
        {
            _unitOfWork.ContentControlRepository.Add(contentControls);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Updates the content control.
        /// </summary>
        /// <param name="contentControls">The content controls.</param>
        public void UpdateContentControl(params ContentControl[] contentControls)
        {
            _unitOfWork.ContentControlRepository.Update(contentControls);
            _unitOfWork.Save();
        }

        /// <summary>
        /// update content control as an asynchronous operation.
        /// </summary>
        /// <param name="contentControls">The content controls.</param>
        public async Task UpdateContentControlAsync(params ContentControl[] contentControls)
        {
            _unitOfWork.ContentControlRepository.Update(contentControls);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Removes the content control.
        /// </summary>
        /// <param name="contentControls">The content controls.</param>
        public void RemoveContentControl(params ContentControl[] contentControls)
        {
            _unitOfWork.ContentControlRepository.Remove(contentControls);
            _unitOfWork.Save();
        }

        /// <summary>
        /// remove content control as an asynchronous operation.
        /// </summary>
        /// <param name="contentControls">The content controls.</param>
        public async Task RemoveContentControlAsync(params ContentControl[] contentControls)
        {
            _unitOfWork.ContentControlRepository.Remove(contentControls);
            await _unitOfWork.SaveAsync();
        }

        #region ILocalizedBL
        /// <summary>
        /// Get full details of the single entity
        /// </summary>
        /// <param name="ofEntity">Passed entity is used as filter, method implementing ths feature should treat this oject apropriatly to call some method of BL class to read full details.</param>
        /// <returns>Entity instance</returns>
        public ContentControl GetDetails(ContentControl ofEntity)
        {
            if (ofEntity == null)
                return null;

            if (ofEntity.Id > 0)
                return GetContentControlById(ofEntity.Id);
            
            return null;
        }

        /// <summary>
        /// Adds the single entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void AddSingleEntity(ContentControl entity)
        {
            _unitOfWork.ContentControlRepository.Add(entity);
            _unitOfWork.Save();
        }
        #endregion

        #endregion
    }
}
