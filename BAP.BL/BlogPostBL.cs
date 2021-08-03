// ***********************************************************************
// Assembly         : BAP.BL
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="BlogPostBL.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;

using PagedList;

using BAP.Common;
using BAP.DAL.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BAP.BL
{
    /// <summary>
    /// Interface IBlogPostBL
    /// </summary>
    public interface IBlogPostBL
    {
        /// <summary>
        /// Gets all blog posts.
        /// </summary>
        /// <returns>IList&lt;BlogPost&gt;.</returns>
        IList<BlogPost> GetAllBlogPosts();
        /// <summary>
        /// Gets all blog posts asynchronous.
        /// </summary>
        /// <returns>Task&lt;IList&lt;BlogPost&gt;&gt;.</returns>
        Task<IList<BlogPost>> GetAllBlogPostsAsync();

        /// <summary>
        /// Gets the top recent blog posts.
        /// </summary>
        /// <param name="top">The top.</param>
        /// <returns>IList&lt;BlogPost&gt;.</returns>
        IList<BlogPost> GetTopRecentBlogPosts(int top = 3);
        /// <summary>
        /// Gets the top recent blog posts asynchronous.
        /// </summary>
        /// <param name="top">The top.</param>
        /// <returns>Task&lt;IList&lt;BlogPost&gt;&gt;.</returns>
        Task<IList<BlogPost>> GetTopRecentBlogPostsAsync(int top = 3);

        /// <summary>
        /// Searches the blog posts.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;BlogPost&gt;.</returns>
        IPagedList<BlogPost> SearchBlogPosts(string where, string sort, int page, int pageSize = 20);
        /// <summary>
        /// Searches the blog posts asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IPagedList&lt;BlogPost&gt;&gt;.</returns>
        Task<IPagedList<BlogPost>> SearchBlogPostsAsync(string where, string sort, int page, int pageSize = 20);

        /// <summary>
        /// Gets the blog post by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>BlogPost.</returns>
        BlogPost GetBlogPostById(int id);
        /// <summary>
        /// Gets the blog post by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;BlogPost&gt;.</returns>
        Task<BlogPost> GetBlogPostByIdAsync(int id);

        /// <summary>
        /// Gets the blog post by public identifier.
        /// </summary>
        /// <param name="pid">The pid.</param>
        /// <returns>BlogPost.</returns>
        BlogPost GetBlogPostByPublicId(string pid);
        /// <summary>
        /// Gets the blog post by public identifier asynchronous.
        /// </summary>
        /// <param name="pid">The pid.</param>
        /// <returns>Task&lt;BlogPost&gt;.</returns>
        Task<BlogPost> GetBlogPostByPublicIdAsync(string pid);

        /// <summary>
        /// Adds the blog post.
        /// </summary>
        /// <param name="blogPosts">The blog posts.</param>
        void AddBlogPost(params BlogPost[] blogPosts);
        /// <summary>
        /// Adds the blog post asynchronous.
        /// </summary>
        /// <param name="blogPosts">The blog posts.</param>
        /// <returns>Task.</returns>
        Task AddBlogPostAsync(params BlogPost[] blogPosts);

        /// <summary>
        /// Updates the blog post.
        /// </summary>
        /// <param name="blogPosts">The blog posts.</param>
        void UpdateBlogPost(params BlogPost[] blogPosts);
        /// <summary>
        /// Updates the blog post asynchronous.
        /// </summary>
        /// <param name="blogPosts">The blog posts.</param>
        /// <returns>Task.</returns>
        Task UpdateBlogPostAsync(params BlogPost[] blogPosts);

        /// <summary>
        /// Removes the blog post.
        /// </summary>
        /// <param name="blogPosts">The blog posts.</param>
        void RemoveBlogPost(params BlogPost[] blogPosts);
        /// <summary>
        /// Removes the blog post asynchronous.
        /// </summary>
        /// <param name="blogPosts">The blog posts.</param>
        /// <returns>Task.</returns>
        Task RemoveBlogPostAsync(params BlogPost[] blogPosts);
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
    public partial class BusinessLayer : IBlogPostBL, ILocalizedBL<BlogPost>
    {
        #region blogPosts

        /// <summary>
        /// Gets all blog posts.
        /// </summary>
        /// <returns>IList&lt;BlogPost&gt;.</returns>
        public IList<BlogPost> GetAllBlogPosts()
        {
            return _unitOfWork.BlogPostRepository.GetAll();
        }

        /// <summary>
        /// get all blog posts as an asynchronous operation.
        /// </summary>
        /// <returns>IList&lt;BlogPost&gt;.</returns>
        public async Task<IList<BlogPost>> GetAllBlogPostsAsync()
        {
            return await _unitOfWork.BlogPostRepository.GetAllAsync();
        }

        /// <summary>
        /// Gets the top recent blog posts.
        /// </summary>
        /// <param name="top">The top.</param>
        /// <returns>IList&lt;BlogPost&gt;.</returns>
        public IList<BlogPost> GetTopRecentBlogPosts(int top = 3)
        {
            return _unitOfWork.BlogPostRepository.GetList(null, "CreateDate DESC", a => a.Blog, a => a.Blog.BlogAuthor).Take(top).ToList();
        }

        /// <summary>
        /// get top recent blog posts as an asynchronous operation.
        /// </summary>
        /// <param name="top">The top.</param>
        /// <returns>IList&lt;BlogPost&gt;.</returns>
        public async Task<IList<BlogPost>> GetTopRecentBlogPostsAsync(int top = 3)
        {
            return await _unitOfWork.BlogPostRepository.GetListAsync(null, "CreateDate DESC", top, a => a.Blog, a => a.Blog.BlogAuthor);
        }

        /// <summary>
        /// Searches the blog posts.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;BlogPost&gt;.</returns>
        public IPagedList<BlogPost> SearchBlogPosts(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<BlogPost>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return _unitOfWork.BlogPostRepository.GetPagedList(page, pageSize, ParseJSONSearchString<BlogPost>(where), sortExpression, p => p.Blog);
        }

        /// <summary>
        /// search blog posts as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;BlogPost&gt;.</returns>
        public async Task<IPagedList<BlogPost>> SearchBlogPostsAsync(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<BlogPost>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return await _unitOfWork.BlogPostRepository.GetPagedListAsync(page, pageSize, ParseJSONSearchString<BlogPost>(where), sortExpression, p => p.Blog);
        }

        /// <summary>
        /// Gets the blog post by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>BlogPost.</returns>
        public BlogPost GetBlogPostById(int id)
        {
            return _unitOfWork.BlogPostRepository.GetSingle(a => a.Id == id, a => a.Blog, a => a.BlogComments, a => a.Blog.BlogAuthor);
        }

        /// <summary>
        /// get blog post by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>BlogPost.</returns>
        public async Task<BlogPost> GetBlogPostByIdAsync(int id)
        {
            return await _unitOfWork.BlogPostRepository.GetSingleAsync(a => a.Id == id, a => a.Blog, a => a.BlogComments, a => a.Blog.BlogAuthor);
        }

        /// <summary>
        /// Gets the blog post by public identifier.
        /// </summary>
        /// <param name="pid">The pid.</param>
        /// <returns>BlogPost.</returns>
        public BlogPost GetBlogPostByPublicId(string pid)
        {
            ISEOFriendly<BlogPost> seoBlogPost = new BlogPost();
            return _unitOfWork.BlogPostRepository.GetSingle(seoBlogPost.ByPublicIdExpression(pid), a => a.Blog, a => a.BlogComments, a => a.Blog.BlogAuthor);
        }

        /// <summary>
        /// get blog post by public identifier as an asynchronous operation.
        /// </summary>
        /// <param name="pid">The pid.</param>
        /// <returns>BlogPost.</returns>
        public async Task<BlogPost> GetBlogPostByPublicIdAsync(string pid)
        {
            ISEOFriendly<BlogPost> seoBlogPost = new BlogPost();
            return await _unitOfWork.BlogPostRepository.GetSingleAsync(seoBlogPost.ByPublicIdExpression(pid), a => a.Blog, a => a.BlogComments, a => a.Blog.BlogAuthor);
        }

        /// <summary>
        /// Adds the blog post.
        /// </summary>
        /// <param name="blogPosts">The blog posts.</param>
        public void AddBlogPost(params BlogPost[] blogPosts)
        {            
            _unitOfWork.BlogPostRepository.Add(blogPosts);            
            _unitOfWork.Save();
        }

        /// <summary>
        /// add blog post as an asynchronous operation.
        /// </summary>
        /// <param name="blogPosts">The blog posts.</param>
        public async Task AddBlogPostAsync(params BlogPost[] blogPosts)
        {
            _unitOfWork.BlogPostRepository.Add(blogPosts);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Updates the blog post.
        /// </summary>
        /// <param name="blogPosts">The blog posts.</param>
        public void UpdateBlogPost(params BlogPost[] blogPosts)
        {            
            _unitOfWork.BlogPostRepository.Update(blogPosts);            
            _unitOfWork.Save();
        }

        /// <summary>
        /// update blog post as an asynchronous operation.
        /// </summary>
        /// <param name="blogPosts">The blog posts.</param>
        public async Task UpdateBlogPostAsync(params BlogPost[] blogPosts)
        {
            _unitOfWork.BlogPostRepository.Update(blogPosts);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Removes the blog post.
        /// </summary>
        /// <param name="blogPosts">The blog posts.</param>
        public void RemoveBlogPost(params BlogPost[] blogPosts)
        {
            _unitOfWork.BlogPostRepository.Remove(blogPosts);
            _unitOfWork.Save();
        }

        /// <summary>
        /// remove blog post as an asynchronous operation.
        /// </summary>
        /// <param name="blogPosts">The blog posts.</param>
        public async Task RemoveBlogPostAsync(params BlogPost[] blogPosts)
        {
            _unitOfWork.BlogPostRepository.Remove(blogPosts);
            await _unitOfWork.SaveAsync();
        }

        #region ILocalizedBL
        /// <summary>
        /// Get full details of the single entity
        /// </summary>
        /// <param name="ofEntity">Passed entity is used as filter, method implementing ths feature should treat this oject apropriatly to call some method of BL class to read full details.</param>
        /// <returns>Entity instance</returns>
        public BlogPost GetDetails(BlogPost ofEntity)
        {
            if (ofEntity == null)
                return null;

            if (ofEntity.Id > 0)
                return GetBlogPostById(ofEntity.Id);
            
            return null;
        }

        /// <summary>
        /// Adds the single entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void AddSingleEntity(BlogPost entity)
        {
            _unitOfWork.BlogPostRepository.Add(entity);
            _unitOfWork.Save();
        }
        #endregion

        #endregion
    }
}
