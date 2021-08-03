// ***********************************************************************
// Assembly         : BAP.BL
// Author           : Victor Mamray
// Created          : 05-24-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="BlogCommentUserBL.cs" company="BAP Software Ltd.">
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
    /// Interface IBlogCommentUserBL
    /// </summary>
    public interface IBlogCommentUserBL
    {
        /// <summary>
        /// Gets all blog comment users.
        /// </summary>
        /// <returns>IList&lt;BlogCommentUser&gt;.</returns>
        IList<BlogCommentUser> GetAllBlogCommentUsers();
        /// <summary>
        /// Gets all blog comment users asynchronous.
        /// </summary>
        /// <returns>Task&lt;IList&lt;BlogCommentUser&gt;&gt;.</returns>
        Task<IList<BlogCommentUser>> GetAllBlogCommentUsersAsync();

        /// <summary>
        /// Searches the blog comment users.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;BlogCommentUser&gt;.</returns>
        IPagedList<BlogCommentUser> SearchBlogCommentUsers(string where, string sort, int page, int pageSize = 20);
        /// <summary>
        /// Searches the blog comment users asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IPagedList&lt;BlogCommentUser&gt;&gt;.</returns>
        Task<IPagedList<BlogCommentUser>> SearchBlogCommentUsersAsync(string where, string sort, int page, int pageSize = 20);

        /// <summary>
        /// Gets the blog comment user by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>BlogCommentUser.</returns>
        BlogCommentUser GetBlogCommentUserById(int id);
        /// <summary>
        /// Gets the blog comment user by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;BlogCommentUser&gt;.</returns>
        Task<BlogCommentUser> GetBlogCommentUserByIdAsync(int id);

        /// <summary>
        /// Adds the blog comment user.
        /// </summary>
        /// <param name="blogCommentUsers">The blog comment users.</param>
        void AddBlogCommentUser(params BlogCommentUser[] blogCommentUsers);
        /// <summary>
        /// Adds the blog comment user asynchronous.
        /// </summary>
        /// <param name="blogCommentUsers">The blog comment users.</param>
        /// <returns>Task.</returns>
        Task AddBlogCommentUserAsync(params BlogCommentUser[] blogCommentUsers);

        /// <summary>
        /// Updates the blog comment user.
        /// </summary>
        /// <param name="blogCommentUsers">The blog comment users.</param>
        void UpdateBlogCommentUser(params BlogCommentUser[] blogCommentUsers);
        /// <summary>
        /// Updates the blog comment user asynchronous.
        /// </summary>
        /// <param name="blogCommentUsers">The blog comment users.</param>
        /// <returns>Task.</returns>
        Task UpdateBlogCommentUserAsync(params BlogCommentUser[] blogCommentUsers);

        /// <summary>
        /// Removes the blog comment user.
        /// </summary>
        /// <param name="blogCommentUsers">The blog comment users.</param>
        void RemoveBlogCommentUser(params BlogCommentUser[] blogCommentUsers);
        /// <summary>
        /// Removes the blog comment user asynchronous.
        /// </summary>
        /// <param name="blogCommentUsers">The blog comment users.</param>
        /// <returns>Task.</returns>
        Task RemoveBlogCommentUserAsync(params BlogCommentUser[] blogCommentUsers);

        /// <summary>
        /// Likes the blog comment user.
        /// </summary>
        /// <param name="commentId">The comment identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>BlogComment.</returns>
        BlogComment LikeBlogCommentUser(int commentId, string userId);
        /// <summary>
        /// Likes the blog comment user asynchronous.
        /// </summary>
        /// <param name="commentId">The comment identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Task&lt;BlogComment&gt;.</returns>
        Task<BlogComment> LikeBlogCommentUserAsync(int commentId, string userId);

        /// <summary>
        /// Dislikes the blog comment user.
        /// </summary>
        /// <param name="commentId">The comment identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>BlogComment.</returns>
        BlogComment DislikeBlogCommentUser(int commentId, string userId);
        /// <summary>
        /// Dislikes the blog comment user asynchronous.
        /// </summary>
        /// <param name="commentId">The comment identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>Task&lt;BlogComment&gt;.</returns>
        Task<BlogComment> DislikeBlogCommentUserAsync(int commentId, string userId);
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
    public partial class BusinessLayer : IBlogCommentUserBL
    {
        #region blogCommentUsers

        /// <summary>
        /// Gets all blog comment users.
        /// </summary>
        /// <returns>IList&lt;BlogCommentUser&gt;.</returns>
        public IList<BlogCommentUser> GetAllBlogCommentUsers()
        {
            return _unitOfWork.BlogCommentUserRepository.GetAll();
        }

        /// <summary>
        /// get all blog comment users as an asynchronous operation.
        /// </summary>
        /// <returns>IList&lt;BlogCommentUser&gt;.</returns>
        public async Task<IList<BlogCommentUser>> GetAllBlogCommentUsersAsync()
        {
            return await _unitOfWork.BlogCommentUserRepository.GetAllAsync();
        }

        /// <summary>
        /// Searches the blog comment users.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;BlogCommentUser&gt;.</returns>
        public IPagedList<BlogCommentUser> SearchBlogCommentUsers(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<BlogCommentUser>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return _unitOfWork.BlogCommentUserRepository.GetPagedList(page, pageSize, ParseJSONSearchString<BlogCommentUser>(where), sortExpression, c => c.Comment);
        }

        /// <summary>
        /// search blog comment users as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;BlogCommentUser&gt;.</returns>
        public async Task<IPagedList<BlogCommentUser>> SearchBlogCommentUsersAsync(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<BlogCommentUser>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return await _unitOfWork.BlogCommentUserRepository.GetPagedListAsync(page, pageSize, ParseJSONSearchString<BlogCommentUser>(where), sortExpression, c => c.Comment);
        }

        /// <summary>
        /// Gets the blog comment user by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>BlogCommentUser.</returns>
        public BlogCommentUser GetBlogCommentUserById(int id)
        {
            return _unitOfWork.BlogCommentUserRepository.GetSingle(a => a.Id == id, a => a.Comment);
        }

        /// <summary>
        /// get blog comment user by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>BlogCommentUser.</returns>
        public async Task<BlogCommentUser> GetBlogCommentUserByIdAsync(int id)
        {
            return await _unitOfWork.BlogCommentUserRepository.GetSingleAsync(a => a.Id == id, a => a.Comment);
        }

        /// <summary>
        /// Adds the blog comment user.
        /// </summary>
        /// <param name="blogCommentUsers">The blog comment users.</param>
        public void AddBlogCommentUser(params BlogCommentUser[] blogCommentUsers)
        {
            _unitOfWork.BlogCommentUserRepository.Add(blogCommentUsers);
            _unitOfWork.Save();
        }

        /// <summary>
        /// add blog comment user as an asynchronous operation.
        /// </summary>
        /// <param name="blogCommentUsers">The blog comment users.</param>
        public async Task AddBlogCommentUserAsync(params BlogCommentUser[] blogCommentUsers)
        {
            _unitOfWork.BlogCommentUserRepository.Add(blogCommentUsers);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Updates the blog comment user.
        /// </summary>
        /// <param name="blogCommentUsers">The blog comment users.</param>
        public void UpdateBlogCommentUser(params BlogCommentUser[] blogCommentUsers)
        {
            _unitOfWork.BlogCommentUserRepository.Update(blogCommentUsers);
            _unitOfWork.Save();
        }

        /// <summary>
        /// update blog comment user as an asynchronous operation.
        /// </summary>
        /// <param name="blogCommentUsers">The blog comment users.</param>
        public async Task UpdateBlogCommentUserAsync(params BlogCommentUser[] blogCommentUsers)
        {
            _unitOfWork.BlogCommentUserRepository.Update(blogCommentUsers);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Removes the blog comment user.
        /// </summary>
        /// <param name="blogCommentUsers">The blog comment users.</param>
        public void RemoveBlogCommentUser(params BlogCommentUser[] blogCommentUsers)
        {
            _unitOfWork.BlogCommentUserRepository.Remove(blogCommentUsers);
            _unitOfWork.Save();
        }

        /// <summary>
        /// remove blog comment user as an asynchronous operation.
        /// </summary>
        /// <param name="blogCommentUsers">The blog comment users.</param>
        public async Task RemoveBlogCommentUserAsync(params BlogCommentUser[] blogCommentUsers)
        {
            _unitOfWork.BlogCommentUserRepository.Remove(blogCommentUsers);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Likes the blog comment user.
        /// </summary>
        /// <param name="commentId">The comment identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>BlogComment.</returns>
        public BlogComment LikeBlogCommentUser(int commentId, string userId)
        {
            var blogComment = _unitOfWork.BlogCommentRepository.GetById(commentId);
            var blogCommentUser = _unitOfWork.BlogCommentUserRepository.GetSingle(a => a.CommentId == commentId && a.AspNetUserId == userId);
            int blogCommentLikeNumber = blogComment.LikeNumber;
            int blogCommentDislikeNumber = blogComment.DislikeNumber;
            bool isUpdate = false;
            if (blogCommentUser == null)
            {
                blogCommentUser = new BlogCommentUser
                {
                    CommentId = commentId,
                    AspNetUserId = userId,
                    LikeNumber = 1
                };
                blogCommentLikeNumber++;
                _unitOfWork.BlogCommentUserRepository.Add(blogCommentUser);
                isUpdate = true;
            }
            else if(blogCommentUser.DislikeNumber > 0)
            {
                blogCommentUser.LikeNumber = 1;
                blogCommentUser.DislikeNumber = 0;
                _unitOfWork.BlogCommentUserRepository.Update(blogCommentUser);
                blogCommentLikeNumber++;
                blogCommentDislikeNumber--;
                isUpdate = true;
            }
                        
            if(isUpdate)
            {
                blogComment.LikeNumber = blogCommentLikeNumber;
                blogComment.DislikeNumber = blogCommentDislikeNumber;
                _unitOfWork.BlogCommentRepository.Update(blogComment);
                _unitOfWork.Save();
            }            
            
            return blogComment;
        }

        /// <summary>
        /// like blog comment user as an asynchronous operation.
        /// </summary>
        /// <param name="commentId">The comment identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>BlogComment.</returns>
        public async Task<BlogComment> LikeBlogCommentUserAsync(int commentId, string userId)
        {
            var blogComment = await _unitOfWork.BlogCommentRepository.GetByIdAsync(commentId);
            var blogCommentUser = await _unitOfWork.BlogCommentUserRepository.GetSingleAsync(a => a.CommentId == commentId && a.AspNetUserId == userId);
            int blogCommentLikeNumber = blogComment.LikeNumber;
            int blogCommentDislikeNumber = blogComment.DislikeNumber;
            bool isUpdate = false;
            if (blogCommentUser == null)
            {
                blogCommentUser = new BlogCommentUser
                {
                    CommentId = commentId,
                    AspNetUserId = userId,
                    LikeNumber = 1
                };
                blogCommentLikeNumber++;
                _unitOfWork.BlogCommentUserRepository.Add(blogCommentUser);
                isUpdate = true;
            }
            else if (blogCommentUser.DislikeNumber > 0)
            {
                blogCommentUser.LikeNumber = 1;
                blogCommentUser.DislikeNumber = 0;
                _unitOfWork.BlogCommentUserRepository.Update(blogCommentUser);
                blogCommentLikeNumber++;
                blogCommentDislikeNumber--;
                isUpdate = true;
            }

            if (isUpdate)
            {
                blogComment.LikeNumber = blogCommentLikeNumber;
                blogComment.DislikeNumber = blogCommentDislikeNumber;
                _unitOfWork.BlogCommentRepository.Update(blogComment);
                await _unitOfWork.SaveAsync();
            }

            return blogComment;
        }

        /// <summary>
        /// Dislikes the blog comment user.
        /// </summary>
        /// <param name="commentId">The comment identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>BlogComment.</returns>
        public BlogComment DislikeBlogCommentUser(int commentId, string userId)
        {
            var blogComment = _unitOfWork.BlogCommentRepository.GetById(commentId);
            var blogCommentUser = _unitOfWork.BlogCommentUserRepository.GetSingle(a => a.CommentId == commentId && a.AspNetUserId == userId);
            int blogCommentLikeNumber = blogComment.LikeNumber;
            int blogCommentDislikeNumber = blogComment.DislikeNumber;
            bool isUpdate = false;
            if (blogCommentUser == null)
            {
                blogCommentUser = new BlogCommentUser
                {
                    CommentId = commentId,
                    AspNetUserId = userId,
                    DislikeNumber = 1
                };
                _unitOfWork.BlogCommentUserRepository.Add(blogCommentUser);
                blogCommentDislikeNumber++;
                isUpdate = true;
            }
            else if(blogCommentUser.LikeNumber > 0)
            {
                blogCommentUser.LikeNumber = 0;
                blogCommentUser.DislikeNumber = 1;
                _unitOfWork.BlogCommentUserRepository.Update(blogCommentUser);
                blogCommentLikeNumber--;
                blogCommentDislikeNumber++;
                isUpdate = true;
            }

            if (isUpdate)
            {
                blogComment.LikeNumber = blogCommentLikeNumber;
                blogComment.DislikeNumber = blogCommentDislikeNumber;
                _unitOfWork.BlogCommentRepository.Update(blogComment);
                _unitOfWork.Save();
            }

            return blogComment;
        }

        /// <summary>
        /// dislike blog comment user as an asynchronous operation.
        /// </summary>
        /// <param name="commentId">The comment identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>BlogComment.</returns>
        public async Task<BlogComment> DislikeBlogCommentUserAsync(int commentId, string userId)
        {
            var blogComment = await _unitOfWork.BlogCommentRepository.GetByIdAsync(commentId);
            var blogCommentUser = await _unitOfWork.BlogCommentUserRepository.GetSingleAsync(a => a.CommentId == commentId && a.AspNetUserId == userId);
            int blogCommentLikeNumber = blogComment.LikeNumber;
            int blogCommentDislikeNumber = blogComment.DislikeNumber;
            bool isUpdate = false;
            if (blogCommentUser == null)
            {
                blogCommentUser = new BlogCommentUser
                {
                    CommentId = commentId,
                    AspNetUserId = userId,
                    DislikeNumber = 1
                };
                _unitOfWork.BlogCommentUserRepository.Add(blogCommentUser);
                blogCommentDislikeNumber++;
                isUpdate = true;
            }
            else if (blogCommentUser.LikeNumber > 0)
            {
                blogCommentUser.LikeNumber = 0;
                blogCommentUser.DislikeNumber = 1;
                _unitOfWork.BlogCommentUserRepository.Update(blogCommentUser);
                blogCommentLikeNumber--;
                blogCommentDislikeNumber++;
                isUpdate = true;
            }

            if (isUpdate)
            {
                blogComment.LikeNumber = blogCommentLikeNumber;
                blogComment.DislikeNumber = blogCommentDislikeNumber;
                _unitOfWork.BlogCommentRepository.Update(blogComment);
                await _unitOfWork.SaveAsync();
            }

            return blogComment;
        }

        #endregion
    }
}
