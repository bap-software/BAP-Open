// ***********************************************************************
// Assembly         : BAP.BL
// Author           : Victor Mamray
// Created          : 05-24-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="BlogCommentBL.cs" company="BAP Software Ltd.">
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
    /// Interface IBlogCommentBL
    /// </summary>
    public interface IBlogCommentBL
    {
        /// <summary>
        /// Gets all blog comments.
        /// </summary>
        /// <returns>IList&lt;BlogComment&gt;.</returns>
        IList<BlogComment> GetAllBlogComments();
        /// <summary>
        /// Gets all blog comments asynchronous.
        /// </summary>
        /// <returns>Task&lt;IList&lt;BlogComment&gt;&gt;.</returns>
        Task<IList<BlogComment>> GetAllBlogCommentsAsync();

        /// <summary>
        /// Searches the blog comments.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;BlogComment&gt;.</returns>
        IPagedList<BlogComment> SearchBlogComments(string where, string sort, int page, int pageSize = 20);
        /// <summary>
        /// Searches the blog comments asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IPagedList&lt;BlogComment&gt;&gt;.</returns>
        Task<IPagedList<BlogComment>> SearchBlogCommentsAsync(string where, string sort, int page, int pageSize = 20);

        /// <summary>
        /// Gets the blog comment by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>BlogComment.</returns>
        BlogComment GetBlogCommentById(int id);
        /// <summary>
        /// Gets the blog comment by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;BlogComment&gt;.</returns>
        Task<BlogComment> GetBlogCommentByIdAsync(int id);

        /// <summary>
        /// Adds the blog comment.
        /// </summary>
        /// <param name="blogComments">The blog comments.</param>
        void AddBlogComment(params BlogComment[] blogComments);
        /// <summary>
        /// Adds the blog comment asynchronous.
        /// </summary>
        /// <param name="blogComments">The blog comments.</param>
        /// <returns>Task.</returns>
        Task AddBlogCommentAsync(params BlogComment[] blogComments);

        /// <summary>
        /// Updates the blog comment.
        /// </summary>
        /// <param name="blogComments">The blog comments.</param>
        void UpdateBlogComment(params BlogComment[] blogComments);
        /// <summary>
        /// Updates the blog comment asynchronous.
        /// </summary>
        /// <param name="blogComments">The blog comments.</param>
        /// <returns>Task.</returns>
        Task UpdateBlogCommentAsync(params BlogComment[] blogComments);

        /// <summary>
        /// Removes the blog comment.
        /// </summary>
        /// <param name="blogComments">The blog comments.</param>
        void RemoveBlogComment(params BlogComment[] blogComments);
        /// <summary>
        /// Removes the blog comment asynchronous.
        /// </summary>
        /// <param name="blogComments">The blog comments.</param>
        /// <returns>Task.</returns>
        Task RemoveBlogCommentAsync(params BlogComment[] blogComments);
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
    public partial class BusinessLayer : IBlogCommentBL
    {

        #region blogComments

        /// <summary>
        /// Gets all blog comments.
        /// </summary>
        /// <returns>IList&lt;BlogComment&gt;.</returns>
        public IList<BlogComment> GetAllBlogComments()
        {
            return _unitOfWork.BlogCommentRepository.GetAll();
        }

        /// <summary>
        /// get all blog comments as an asynchronous operation.
        /// </summary>
        /// <returns>IList&lt;BlogComment&gt;.</returns>
        public async Task<IList<BlogComment>> GetAllBlogCommentsAsync()
        {
            return await _unitOfWork.BlogCommentRepository.GetAllAsync();
        }

        /// <summary>
        /// Searches the blog comments.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;BlogComment&gt;.</returns>
        public IPagedList<BlogComment> SearchBlogComments(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<BlogComment>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return _unitOfWork.BlogCommentRepository.GetPagedList(page, pageSize, ParseJSONSearchString<BlogComment>(where), sortExpression, c => c.Blog);
        }

        /// <summary>
        /// search blog comments as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;BlogComment&gt;.</returns>
        public async Task<IPagedList<BlogComment>> SearchBlogCommentsAsync(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<BlogComment>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return await _unitOfWork.BlogCommentRepository.GetPagedListAsync(page, pageSize, ParseJSONSearchString<BlogComment>(where), sortExpression, c => c.Blog);
        }

        /// <summary>
        /// Gets the blog comment by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>BlogComment.</returns>
        public BlogComment GetBlogCommentById(int id)
        {
            return _unitOfWork.BlogCommentRepository.GetSingle(a => a.Id == id, a => a.Blog, a => a.BlogPost, a => a.ParentComment, a => a.BlogComments);
        }

        /// <summary>
        /// get blog comment by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>BlogComment.</returns>
        public async Task<BlogComment> GetBlogCommentByIdAsync(int id)
        {
            return await _unitOfWork.BlogCommentRepository.GetSingleAsync(a => a.Id == id, a => a.Blog, a => a.BlogPost, a => a.ParentComment, a => a.BlogComments);
        }

        /// <summary>
        /// Adds the blog comment.
        /// </summary>
        /// <param name="blogComments">The blog comments.</param>
        public void AddBlogComment(params BlogComment[] blogComments)
        {            
            _unitOfWork.BlogCommentRepository.Add(blogComments);            
            _unitOfWork.Save();
        }

        /// <summary>
        /// add blog comment as an asynchronous operation.
        /// </summary>
        /// <param name="blogComments">The blog comments.</param>
        public async Task AddBlogCommentAsync(params BlogComment[] blogComments)
        {
            _unitOfWork.BlogCommentRepository.Add(blogComments);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Updates the blog comment.
        /// </summary>
        /// <param name="blogComments">The blog comments.</param>
        public void UpdateBlogComment(params BlogComment[] blogComments)
        {            
            _unitOfWork.BlogCommentRepository.Update(blogComments);            
            _unitOfWork.Save();
        }

        /// <summary>
        /// update blog comment as an asynchronous operation.
        /// </summary>
        /// <param name="blogComments">The blog comments.</param>
        public async Task UpdateBlogCommentAsync(params BlogComment[] blogComments)
        {
            _unitOfWork.BlogCommentRepository.Update(blogComments);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Removes the blog comment.
        /// </summary>
        /// <param name="blogComments">The blog comments.</param>
        public void RemoveBlogComment(params BlogComment[] blogComments)
        {
            _unitOfWork.BlogCommentRepository.Remove(blogComments);
            _unitOfWork.Save();
        }

        /// <summary>
        /// remove blog comment as an asynchronous operation.
        /// </summary>
        /// <param name="blogComments">The blog comments.</param>
        public async Task RemoveBlogCommentAsync(params BlogComment[] blogComments)
        {
            _unitOfWork.BlogCommentRepository.Remove(blogComments);
            await _unitOfWork.SaveAsync();
        }

        #endregion
    }
}
