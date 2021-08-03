// ***********************************************************************
// Assembly         : BAP.BL
// Author           : Victor Mamray
// Created          : 05-17-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="AttachmentHistBL.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Threading.Tasks;
using BAP.DAL.Entities;
using PagedList;

namespace BAP.BL
{
    /// <summary>
    /// Interface IAttachmentHistBL
    /// </summary>
    public interface IAttachmentHistBL
    {
        /// <summary>
        /// Gets all attachment histories.
        /// </summary>
        /// <returns>IList&lt;AttachmentHistory&gt;.</returns>
        IList<AttachmentHistory> GetAllAttachmentHistories();
        /// <summary>
        /// Gets all attachment histories asynchronous.
        /// </summary>
        /// <returns>Task&lt;IList&lt;AttachmentHistory&gt;&gt;.</returns>
        Task<IList<AttachmentHistory>> GetAllAttachmentHistoriesAsync();

        /// <summary>
        /// Searches the attachment histories.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;AttachmentHistory&gt;.</returns>
        IPagedList<AttachmentHistory> SearchAttachmentHistories(string where, string sort, int page, int pageSize = 20);
        /// <summary>
        /// Searches the attachment histories asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IPagedList&lt;AttachmentHistory&gt;&gt;.</returns>
        Task<IPagedList<AttachmentHistory>> SearchAttachmentHistoriesAsync(string where, string sort, int page, int pageSize = 20);

        /// <summary>
        /// Gets the attachment hist by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>AttachmentHistory.</returns>
        AttachmentHistory GetAttachmentHistById(int id);
        /// <summary>
        /// Gets the attachment hist by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;AttachmentHistory&gt;.</returns>
        Task<AttachmentHistory> GetAttachmentHistByIdAsync(int id);

        /// <summary>
        /// Gets the attachment history by path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>AttachmentHistory.</returns>
        AttachmentHistory GetAttachmentHistByPath(string path);
        /// <summary>
        /// Gets the attachment history by path asynchronous.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>Task&lt;AttachmentHistory&gt;.</returns>
        Task<AttachmentHistory> GetAttachmentHistByPathAsync(string path);

        /// <summary>
        /// Adds the attachment history.
        /// </summary>
        /// <param name="attachments">The attachments.</param>
        void AddAttachmentHistory(params AttachmentHistory[] attachments);
        /// <summary>
        /// Adds the attachment history asynchronous.
        /// </summary>
        /// <param name="attachments">The attachments.</param>
        /// <returns>Task.</returns>
        Task AddAttachmentHistoryAsync(params AttachmentHistory[] attachments);

        /// <summary>
        /// Updates the attachment history.
        /// </summary>
        /// <param name="attachments">The attachments.</param>
        void UpdateAttachmentHistory(params AttachmentHistory[] attachments);
        /// <summary>
        /// Updates the attachment history asynchronous.
        /// </summary>
        /// <param name="attachments">The attachments.</param>
        /// <returns>Task.</returns>
        Task UpdateAttachmentHistoryAsync(params AttachmentHistory[] attachments);

        /// <summary>
        /// Removes the attachment history.
        /// </summary>
        /// <param name="attachments">The attachments.</param>
        void RemoveAttachmentHistory(params AttachmentHistory[] attachments);
        /// <summary>
        /// Removes the attachment history asynchronous.
        /// </summary>
        /// <param name="attachments">The attachments.</param>
        /// <returns>Task.</returns>
        Task RemoveAttachmentHistoryAsync(params AttachmentHistory[] attachments);
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
    public partial class BusinessLayer : IAttachmentHistBL
    {
        /// <summary>
        /// Gets all attachment histories.
        /// </summary>
        /// <returns>IList&lt;AttachmentHistory&gt;.</returns>
        public IList<AttachmentHistory> GetAllAttachmentHistories()
        {
            return _unitOfWork.AttachmentHistRepository.GetAll();
        }

        /// <summary>
        /// get all attachment histories as an asynchronous operation.
        /// </summary>
        /// <returns>IList&lt;AttachmentHistory&gt;.</returns>
        public async Task<IList<AttachmentHistory>> GetAllAttachmentHistoriesAsync()
        {
            return await _unitOfWork.AttachmentHistRepository.GetAllAsync();
        }

        /// <summary>
        /// Searches the attachment histories.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;AttachmentHistory&gt;.</returns>
        public IPagedList<AttachmentHistory> SearchAttachmentHistories(string where, string sort, int page, int pageSize = 20)
        {
            return _unitOfWork.AttachmentHistRepository.GetPagedList(page, pageSize, ParseJSONSearchString<AttachmentHistory>(where), AdjustSortExpression(sort));
        }

        /// <summary>
        /// search attachment histories as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;AttachmentHistory&gt;.</returns>
        public async Task<IPagedList<AttachmentHistory>> SearchAttachmentHistoriesAsync(string where, string sort, int page, int pageSize = 20)
        {
            return await _unitOfWork.AttachmentHistRepository.GetPagedListAsync(page, pageSize, ParseJSONSearchString<AttachmentHistory>(where), AdjustSortExpression(sort));
        }

        /// <summary>
        /// Gets the attachment hist by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>AttachmentHistory.</returns>
        public AttachmentHistory GetAttachmentHistById(int id)
        {
            return _unitOfWork.AttachmentHistRepository.GetSingle(a => a.Id == id, a => a.Attachment);
        }

        /// <summary>
        /// get attachment hist by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>AttachmentHistory.</returns>
        public async Task<AttachmentHistory> GetAttachmentHistByIdAsync(int id)
        {
            return await _unitOfWork.AttachmentHistRepository.GetSingleAsync(a => a.Id == id, a => a.Attachment);
        }

        /// <summary>
        /// Gets the attachment hist by path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>AttachmentHistory.</returns>
        public AttachmentHistory GetAttachmentHistByPath(string path)
        {
            return _unitOfWork.AttachmentHistRepository.GetSingle(a => a.FilePath == path, a => a.Attachment);
        }

        /// <summary>
        /// get attachment hist by path as an asynchronous operation.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>AttachmentHistory.</returns>
        public async Task<AttachmentHistory> GetAttachmentHistByPathAsync(string path)
        {
            return await _unitOfWork.AttachmentHistRepository.GetSingleAsync(a => a.FilePath == path, a => a.Attachment);
        }

        /// <summary>
        /// Adds the attachment history.
        /// </summary>
        /// <param name="attachments">The attachments.</param>
        public void AddAttachmentHistory(params AttachmentHistory[] attachments)
        {
            _unitOfWork.AttachmentHistRepository.Add(attachments);
            _unitOfWork.Save();
        }

        /// <summary>
        /// add attachment history as an asynchronous operation.
        /// </summary>
        /// <param name="attachments">The attachments.</param>
        public async Task AddAttachmentHistoryAsync(params AttachmentHistory[] attachments)
        {
            _unitOfWork.AttachmentHistRepository.Add(attachments);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Updates the attachment history.
        /// </summary>
        /// <param name="attachments">The attachments.</param>
        public void UpdateAttachmentHistory(params AttachmentHistory[] attachments)
        {
            _unitOfWork.AttachmentHistRepository.Update(attachments);
            _unitOfWork.Save();
        }

        /// <summary>
        /// update attachment history as an asynchronous operation.
        /// </summary>
        /// <param name="attachments">The attachments.</param>
        public async Task UpdateAttachmentHistoryAsync(params AttachmentHistory[] attachments)
        {
            _unitOfWork.AttachmentHistRepository.Update(attachments);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Removes the attachment history.
        /// </summary>
        /// <param name="attachments">The attachments.</param>
        public void RemoveAttachmentHistory(params AttachmentHistory[] attachments)
        {
            _unitOfWork.AttachmentHistRepository.Remove(attachments);
            _unitOfWork.Save();
        }

        /// <summary>
        /// remove attachment history as an asynchronous operation.
        /// </summary>
        /// <param name="attachments">The attachments.</param>
        public async Task RemoveAttachmentHistoryAsync(params AttachmentHistory[] attachments)
        {
            _unitOfWork.AttachmentHistRepository.Remove(attachments);
            await _unitOfWork.SaveAsync();
        }
    }
}
