// ***********************************************************************
// Assembly         : BAP.BL
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="BlogBL.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq;
using System.Collections.Generic;
using PagedList;
using BAP.Common;
using BAP.DAL.Entities;
using System.Threading.Tasks;
using System.Web.Mvc;
using BAP.Email;

namespace BAP.BL
{
    /// <summary>
    /// Class GenericPost.
    /// </summary>
    public class GenericPost
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the create date.
        /// </summary>
        /// <value>The create date.</value>
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the main image URL.
        /// </summary>
        /// <value>The main image URL.</value>
        public string MainImageUrl { get; set; }
        /// <summary>
        /// Gets or sets the blog author.
        /// </summary>
        /// <value>The blog author.</value>
        public string BlogAuthor { get; set; }
        /// <summary>
        /// Gets or sets the public blog identifier.
        /// </summary>
        /// <value>The public blog identifier.</value>
        public string PublicBlogId { get; set; }
        /// <summary>
        /// Gets or sets the public post identifier.
        /// </summary>
        /// <value>The public post identifier.</value>
        public string PublicPostId { get; set; }
    }

    /// <summary>
    /// Interface IBlogBL
    /// </summary>
    public interface IBlogBL
    {
        /// <summary>
        /// Gets all blogs.
        /// </summary>
        /// <returns>IList&lt;Blog&gt;.</returns>
        IList<Blog> GetAllBlogs();
        /// <summary>
        /// Gets all blogs asynchronous.
        /// </summary>
        /// <returns>Task&lt;IList&lt;Blog&gt;&gt;.</returns>
        Task<IList<Blog>> GetAllBlogsAsync();

        /// <summary>
        /// Gets the top generic posts.
        /// </summary>
        /// <param name="top">The top.</param>
        /// <returns>IList&lt;GenericPost&gt;.</returns>
        IList<GenericPost> GetTopGenericPosts(int top = 3);
        /// <summary>
        /// Gets the top generic posts asynchronous.
        /// </summary>
        /// <param name="top">The top.</param>
        /// <returns>Task&lt;IList&lt;GenericPost&gt;&gt;.</returns>
        Task<IList<GenericPost>> GetTopGenericPostsAsync(int top = 3);

        /// <summary>
        /// Gets the top recent blogs.
        /// </summary>
        /// <param name="top">The top.</param>
        /// <returns>IList&lt;Blog&gt;.</returns>
        IList<Blog> GetTopRecentBlogs(int top = 3);
        /// <summary>
        /// Gets the top recent blogs asynchronous.
        /// </summary>
        /// <param name="top">The top.</param>
        /// <returns>Task&lt;IList&lt;Blog&gt;&gt;.</returns>
        Task<IList<Blog>> GetTopRecentBlogsAsync(int top = 3);

        /// <summary>
        /// Searches the blogs.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;Blog&gt;.</returns>
        IPagedList<Blog> SearchBlogs(string where, string sort, int page, int pageSize = 20);
        /// <summary>
        /// Searches the blogs asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IPagedList&lt;Blog&gt;&gt;.</returns>
        Task<IPagedList<Blog>> SearchBlogsAsync(string where, string sort, int page, int pageSize = 20);

        /// <summary>
        /// Gets the blog by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Blog.</returns>
        Blog GetBlogById(int id);
        /// <summary>
        /// Gets the blog by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;Blog&gt;.</returns>
        Task<Blog> GetBlogByIdAsync(int id);

        /// <summary>
        /// Gets the blog by public identifier.
        /// </summary>
        /// <param name="pid">The pid.</param>
        /// <returns>Blog.</returns>
        Blog GetBlogByPublicId(string pid);
        /// <summary>
        /// Gets the blog by public identifier asynchronous.
        /// </summary>
        /// <param name="pid">The pid.</param>
        /// <returns>Task&lt;Blog&gt;.</returns>
        Task<Blog> GetBlogByPublicIdAsync(string pid);

        /// <summary>
        /// Adds the blog.
        /// </summary>
        /// <param name="blogs">The blogs.</param>
        void AddBlog(params Blog[] blogs);
        /// <summary>
        /// Adds the blog asynchronous.
        /// </summary>
        /// <param name="blogs">The blogs.</param>
        /// <returns>Task.</returns>
        Task AddBlogAsync(params Blog[] blogs);


        /// <summary>
        /// Updates the blog.
        /// </summary>
        /// <param name="blogs">The blogs.</param>
        void UpdateBlog(params Blog[] blogs);
        /// <summary>
        /// Updates the blog asynchronous.
        /// </summary>
        /// <param name="blogs">The blogs.</param>
        /// <returns>Task.</returns>
        Task UpdateBlogAsync(params Blog[] blogs);

        /// <summary>
        /// Removes the blog.
        /// </summary>
        /// <param name="blogs">The blogs.</param>
        void RemoveBlog(params Blog[] blogs);
        /// <summary>
        /// Removes the blog asynchronous.
        /// </summary>
        /// <param name="blogs">The blogs.</param>
        /// <returns>Task.</returns>
        Task RemoveBlogAsync(params Blog[] blogs);

        /// <summary>
        /// Sends the notification email.
        /// </summary>
        /// <param name="blogComment">The blog comment.</param>
        /// <param name="email">The email.</param>
        /// <returns>Task.</returns>
        Task SendNotificationEmail(BlogComment blogComment, string email);
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
    public partial class BusinessLayer : IBlogBL, ILocalizedBL<Blog>
    {
        /// <summary>
        /// The comment notification template
        /// </summary>
        const string COMMENT_NOTIFICATION_TEMPLATE = "CommentNotificationTemplate";

        /// <summary>
        /// The comment notification subject
        /// </summary>
        const string COMMENT_NOTIFICATION_SUBJECT = "You get new comment on your {Blog.Name}";

        /// <summary>
        /// The comment notification body
        /// </summary>
        const string COMMENT_NOTIFICATION_BODY = "{BlogComment.Author} just add new comment \"{BlogComment.Title}\" under your blog post \"{Blog.Name}\" with the following content: {BlogComment.Text}";

        #region blogs

        /// <summary>
        /// Gets all blogs.
        /// </summary>
        /// <returns>IList&lt;Blog&gt;.</returns>
        public IList<Blog> GetAllBlogs()
        {
            return _unitOfWork.BlogRepository.GetAll(b => b.BlogAuthor);
        }

        /// <summary>
        /// get all blogs as an asynchronous operation.
        /// </summary>
        /// <returns>IList&lt;Blog&gt;.</returns>
        public async Task<IList<Blog>> GetAllBlogsAsync()
        {
            return await _unitOfWork.BlogRepository.GetAllAsync(b => b.BlogAuthor);
        }

        /// <summary>
        /// Gets the top generic posts.
        /// </summary>
        /// <param name="top">The top.</param>
        /// <returns>IList&lt;GenericPost&gt;.</returns>
        public IList<GenericPost> GetTopGenericPosts(int top = 3)
        {
            var recentPosts = this.GetTopRecentBlogPosts(top);
            if (recentPosts != null)
            {
                var result = recentPosts.Select(a => new GenericPost { 
                    Title = a.Title, 
                    CreateDate = a.CreateDate,
                    Description = a.Text,
                    MainImageUrl = a.MainImageUrl,
                    BlogAuthor = a.Blog.BlogAuthor?.FullName,
                    PublicBlogId = a.Blog.GetPublicId(), 
                    PublicPostId = a.GetPublicId() 
                }).ToList();
                if (result.Count < top)
                {
                    var blogs = this.GetTopRecentBlogs(top);
                    if (blogs != null && blogs.Count > 0)
                    {
                        for (int i = 0; i < blogs.Count; i++)
                        {
                            var blog = blogs[i];
                            result.Add(new GenericPost { 
                                PublicBlogId = blog.GetPublicId(), 
                                Title = blog.Name,
                                CreateDate = blog.CreateDate,
                                Description = blog.Description,
                                MainImageUrl = blog.MainImageUrl,
                                BlogAuthor = blog.BlogAuthor?.FullName,
                            });
                            if (result.Count == top)
                                break;
                        }
                    }
                }
                return result;

            }

            var recentBlogs = this.GetTopRecentBlogs(top);
            if (recentBlogs != null)
            {
                return recentBlogs.Select(a => new GenericPost { 
                    Title = a.Name, 
                    PublicBlogId = a.GetPublicId(),
                    CreateDate = a.CreateDate,
                    Description = a.Description,
                    MainImageUrl = a.MainImageUrl,
                    BlogAuthor = a.BlogAuthor?.FullName
                }).ToList();
            }

            return null;
        }

        /// <summary>
        /// get top generic posts as an asynchronous operation.
        /// </summary>
        /// <param name="top">The top.</param>
        /// <returns>IList&lt;GenericPost&gt;.</returns>
        public async Task<IList<GenericPost>> GetTopGenericPostsAsync(int top = 3)
        {
            var recentPosts = await this.GetTopRecentBlogPostsAsync(top);
            if (recentPosts != null)
            {
                var result = recentPosts.Select(a => new GenericPost
                {
                    Title = a.Title,
                    CreateDate = a.CreateDate,
                    Description = a.Text,
                    MainImageUrl = a.MainImageUrl,
                    BlogAuthor = a.Blog.BlogAuthor?.FullName,
                    PublicBlogId = a.Blog.GetPublicId(),
                    PublicPostId = a.GetPublicId()
                }).ToList();
                if (result.Count < top)
                {
                    var blogs = await this.GetTopRecentBlogsAsync(top);
                    if (blogs != null && blogs.Count > 0)
                    {
                        for (int i = 0; i < blogs.Count; i++)
                        {
                            var blog = blogs[i];
                            result.Add(new GenericPost
                            {
                                PublicBlogId = blog.GetPublicId(),
                                Title = blog.Name,
                                CreateDate = blog.CreateDate,
                                Description = blog.Description,
                                MainImageUrl = blog.MainImageUrl,
                                BlogAuthor = blog.BlogAuthor?.FullName,
                            });
                            if (result.Count == top)
                                break;
                        }
                    }
                }
                return result;

            }

            var recentBlogs = await this.GetTopRecentBlogsAsync(top);
            if (recentBlogs != null)
            {
                return recentBlogs.Select(a => new GenericPost
                {
                    Title = a.Name,
                    PublicBlogId = a.GetPublicId(),
                    CreateDate = a.CreateDate,
                    Description = a.Description,
                    MainImageUrl = a.MainImageUrl,
                    BlogAuthor = a.BlogAuthor?.FullName
                }).ToList();
            }

            return null;
        }

        /// <summary>
        /// Gets the top recent blogs.
        /// </summary>
        /// <param name="top">The top.</param>
        /// <returns>IList&lt;Blog&gt;.</returns>
        public IList<Blog> GetTopRecentBlogs(int top = 3)
        {
            return _unitOfWork.BlogRepository.GetList(null, "CreateDate DESC", b => b.BlogAuthor).Take(top).ToList();
        }

        /// <summary>
        /// get top recent blogs as an asynchronous operation.
        /// </summary>
        /// <param name="top">The top.</param>
        /// <returns>IList&lt;Blog&gt;.</returns>
        public async Task<IList<Blog>> GetTopRecentBlogsAsync(int top = 3)
        {
            return await _unitOfWork.BlogRepository.GetListAsync(null, "CreateDate DESC", top, b => b.BlogAuthor);
        }

        /// <summary>
        /// Searches the blogs.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;Blog&gt;.</returns>
        public IPagedList<Blog> SearchBlogs(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<Blog>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return _unitOfWork.BlogRepository.GetPagedList(page, pageSize, ParseJSONSearchString<Blog>(where), sortExpression, b => b.BlogAuthor, b => b.BlogPosts, b => b.BlogComments);
        }

        /// <summary>
        /// search blogs as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;Blog&gt;.</returns>
        public async Task<IPagedList<Blog>> SearchBlogsAsync(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<Blog>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return await _unitOfWork.BlogRepository.GetPagedListAsync(page, pageSize, ParseJSONSearchString<Blog>(where), sortExpression, b => b.BlogAuthor, b => b.BlogPosts, b => b.BlogComments);
        }

        /// <summary>
        /// Gets the blog by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Blog.</returns>
        public Blog GetBlogById(int id)
        {
            return _unitOfWork.BlogRepository.GetSingle(a => a.Id == id, a => a.BlogPosts, a => a.BlogComments, a => a.BlogAuthor);
        }

        /// <summary>
        /// get blog by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Blog.</returns>
        public async Task<Blog> GetBlogByIdAsync(int id)
        {
            return await _unitOfWork.BlogRepository.GetSingleAsync(a => a.Id == id, a => a.BlogPosts, a => a.BlogComments, a => a.BlogAuthor);
        }

        /// <summary>
        /// Gets the blog by public identifier.
        /// </summary>
        /// <param name="pid">The pid.</param>
        /// <returns>Blog.</returns>
        public Blog GetBlogByPublicId(string pid)
        {
            ISEOFriendly<Blog> seoBlog = new Blog();
            return _unitOfWork.BlogRepository.GetSingle(seoBlog.ByPublicIdExpression(pid), a => a.BlogPosts, a => a.BlogComments, a => a.BlogAuthor);
        }

        /// <summary>
        /// get blog by public identifier as an asynchronous operation.
        /// </summary>
        /// <param name="pid">The pid.</param>
        /// <returns>Blog.</returns>
        public async Task<Blog> GetBlogByPublicIdAsync(string pid)
        {
            ISEOFriendly<Blog> seoBlog = new Blog();
            return await _unitOfWork.BlogRepository.GetSingleAsync(seoBlog.ByPublicIdExpression(pid), a => a.BlogPosts, a => a.BlogComments, a => a.BlogAuthor);
        }

        /// <summary>
        /// Adds the blog.
        /// </summary>
        /// <param name="blogs">The blogs.</param>
        public void AddBlog(params Blog[] blogs)
        {
            _unitOfWork.BlogRepository.Add(blogs);
            _unitOfWork.Save();
        }

        /// <summary>
        /// add blog as an asynchronous operation.
        /// </summary>
        /// <param name="blogs">The blogs.</param>
        public async Task AddBlogAsync(params Blog[] blogs)
        {
            _unitOfWork.BlogRepository.Add(blogs);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Updates the blog.
        /// </summary>
        /// <param name="blogs">The blogs.</param>
        public void UpdateBlog(params Blog[] blogs)
        {
            foreach (var blog in blogs)
            {
                var author = _unitOfWork.BlogAuthorRepository.GetSingle(a => a.FirstName == blog.BlogAuthor.FirstName && a.LastName == blog.BlogAuthor.LastName) ?? blog.BlogAuthor;
                if (author.Id > 0)
                {
                    blog.BlogAuthor = author;
                    blog.BlogAuthorId = author.Id;
                    if (blog.BlogAuthor.EntityState != BAPEntityState.Modified)
                        _unitOfWork.BlogAuthorRepository.Update(author);
                }
                else
                    _unitOfWork.BlogAuthorRepository.Add(author);
            }
            _unitOfWork.BlogRepository.Update(blogs);
            _unitOfWork.Save();
        }

        /// <summary>
        /// update blog as an asynchronous operation.
        /// </summary>
        /// <param name="blogs">The blogs.</param>
        public async Task UpdateBlogAsync(params Blog[] blogs)
        {
            foreach (var blog in blogs)
            {
                var author = await _unitOfWork.BlogAuthorRepository.GetSingleAsync(a => a.FirstName == blog.BlogAuthor.FirstName && a.LastName == blog.BlogAuthor.LastName) ?? blog.BlogAuthor;
                if (author.Id > 0)
                {
                    blog.BlogAuthor = author;
                    blog.BlogAuthorId = author.Id;
                    if (blog.BlogAuthor.EntityState != BAPEntityState.Modified)
                        _unitOfWork.BlogAuthorRepository.Update(author);
                }
                else
                    _unitOfWork.BlogAuthorRepository.Add(author);
            }
            _unitOfWork.BlogRepository.Update(blogs);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Removes the blog.
        /// </summary>
        /// <param name="blogs">The blogs.</param>
        public void RemoveBlog(params Blog[] blogs)
        {
            foreach (var blog in blogs)
            {
                if (blog.BlogAuthor != null && _unitOfWork.BlogRepository.GetList(b => b.BlogAuthorId == blog.BlogAuthorId).Count == 1)
                    _unitOfWork.BlogAuthorRepository.Remove(blog.BlogAuthor);
                _unitOfWork.BlogPostRepository.Remove(blog.BlogPosts.ToArray());
                _unitOfWork.BlogCommentRepository.Remove(blog.BlogComments.ToArray());
            }
            _unitOfWork.BlogRepository.Remove(blogs);
            _unitOfWork.Save();
        }

        /// <summary>
        /// remove blog as an asynchronous operation.
        /// </summary>
        /// <param name="blogs">The blogs.</param>
        public async Task RemoveBlogAsync(params Blog[] blogs)
        {
            foreach (var blog in blogs)
            {
                if (blog.BlogAuthor != null && _unitOfWork.BlogRepository.GetList(b => b.BlogAuthorId == blog.BlogAuthorId).Count == 1)
                    _unitOfWork.BlogAuthorRepository.Remove(blog.BlogAuthor);
                _unitOfWork.BlogPostRepository.Remove(blog.BlogPosts.ToArray());
                _unitOfWork.BlogCommentRepository.Remove(blog.BlogComments.ToArray());
            }
            _unitOfWork.BlogRepository.Remove(blogs);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Sends the notification email.
        /// </summary>
        /// <param name="blogComment">The blog comment.</param>
        /// <param name="email">The email.</param>
        /// <exception cref="NullReferenceException">Mailer cannot be null, it has to be properly configured</exception>
        public async Task SendNotificationEmail(BlogComment blogComment, string email)
        {
            var mailer = DependencyResolver.Current.GetService<IMailer>();
            if (mailer == null)
                throw new NullReferenceException("Mailer cannot be null, it has to be properly configured");
            var subject = COMMENT_NOTIFICATION_SUBJECT.Replace("{Blog.Name}", blogComment.Blog.Name);
            var body = GetCommentNotificationBody(blogComment);
            await mailer.SendEmailAsync(mailer.DefaultFromAddress, email, subject, body);
        }

        /// <summary>
        /// Gets the comment notification body.
        /// </summary>
        /// <param name="blogComment">The blog comment.</param>
        /// <returns>System.String.</returns>
        private string GetCommentNotificationBody(BlogComment blogComment)
        {
            var notificationTemplate = string.Empty;
            var template = GetDocumentTemplateByName(COMMENT_NOTIFICATION_TEMPLATE);
            if (template != null)
                notificationTemplate = template.TemplateBody;

            if (string.IsNullOrWhiteSpace(notificationTemplate))
                notificationTemplate = COMMENT_NOTIFICATION_BODY;

            notificationTemplate = notificationTemplate.Replace("{BlogComment.Author}", blogComment.Author);
            notificationTemplate = notificationTemplate.Replace("{BlogComment.Title}", blogComment.Title);
            notificationTemplate = notificationTemplate.Replace("{Blog.Name}", blogComment.Blog.Name);
            notificationTemplate = notificationTemplate.Replace("{BlogComment.Text}", blogComment.Text);

            return notificationTemplate;
        }

        #region ILocalizedBL
        /// <summary>
        /// Get full details of the single entity
        /// </summary>
        /// <param name="ofEntity">Passed entity is used as filter, method implementing ths feature should treat this oject apropriatly to call some method of BL class to read full details.</param>
        /// <returns>Entity instance</returns>
        public Blog GetDetails(Blog ofEntity)
        {
            if (ofEntity == null)
                return null;

            if (ofEntity.Id > 0)
                return GetBlogById(ofEntity.Id);            

            return null;
        }

        /// <summary>
        /// Adds the single entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void AddSingleEntity(Blog entity)
        {
            _unitOfWork.BlogRepository.Add(entity);
            _unitOfWork.Save();
        }
        #endregion

        #endregion
    }
}
