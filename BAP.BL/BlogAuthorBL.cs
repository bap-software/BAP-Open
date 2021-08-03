// ***********************************************************************
// Assembly         : BAP.BL
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="BlogAuthorBL.cs" company="BAP Software Ltd.">
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
    /// Interface IBlogAuthorBL
    /// </summary>
    public interface IBlogAuthorBL
    {
        /// <summary>
        /// Gets all blog authors.
        /// </summary>
        /// <returns>IList&lt;BlogAuthor&gt;.</returns>
        IList<BlogAuthor> GetAllBlogAuthors();
        /// <summary>
        /// Gets all blog authors asynchronous.
        /// </summary>
        /// <returns>Task&lt;IList&lt;BlogAuthor&gt;&gt;.</returns>
        Task<IList<BlogAuthor>> GetAllBlogAuthorsAsync();

        /// <summary>
        /// Searches the blog authors.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;BlogAuthor&gt;.</returns>
        IPagedList<BlogAuthor> SearchBlogAuthors(string where, string sort, int page, int pageSize = 20);
        /// <summary>
        /// Searches the blog authors asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IPagedList&lt;BlogAuthor&gt;&gt;.</returns>
        Task<IPagedList<BlogAuthor>> SearchBlogAuthorsAsync(string where, string sort, int page, int pageSize = 20);

        /// <summary>
        /// Gets the blog author by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>BlogAuthor.</returns>
        BlogAuthor GetBlogAuthorById(int id);
        /// <summary>
        /// Gets the blog author by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;BlogAuthor&gt;.</returns>
        Task<BlogAuthor> GetBlogAuthorByIdAsync(int id);

        /// <summary>
        /// Adds the blog author.
        /// </summary>
        /// <param name="blogAuthors">The blog authors.</param>
        void AddBlogAuthor(params BlogAuthor[] blogAuthors);
        /// <summary>
        /// Adds the blog author asynchronous.
        /// </summary>
        /// <param name="blogAuthors">The blog authors.</param>
        /// <returns>Task.</returns>
        Task AddBlogAuthorAsync(params BlogAuthor[] blogAuthors);

        /// <summary>
        /// Updates the blog author.
        /// </summary>
        /// <param name="blogAuthors">The blog authors.</param>
        void UpdateBlogAuthor(params BlogAuthor[] blogAuthors);
        /// <summary>
        /// Updates the blog author asynchronous.
        /// </summary>
        /// <param name="blogAuthors">The blog authors.</param>
        /// <returns>Task.</returns>
        Task UpdateBlogAuthorAsync(params BlogAuthor[] blogAuthors);

        /// <summary>
        /// Removes the blog author.
        /// </summary>
        /// <param name="blogAuthors">The blog authors.</param>
        void RemoveBlogAuthor(params BlogAuthor[] blogAuthors);
        /// <summary>
        /// Removes the blog author asynchronous.
        /// </summary>
        /// <param name="blogAuthors">The blog authors.</param>
        /// <returns>Task.</returns>
        Task RemoveBlogAuthorAsync(params BlogAuthor[] blogAuthors);
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
    public partial class BusinessLayer : IBlogAuthorBL, ILocalizedBL<BlogAuthor>
    {
        #region blogAuthors

        /// <summary>
        /// Gets all blog authors.
        /// </summary>
        /// <returns>IList&lt;BlogAuthor&gt;.</returns>
        public IList<BlogAuthor> GetAllBlogAuthors()
        {
            return _unitOfWork.BlogAuthorRepository.GetAll();
        }

        /// <summary>
        /// get all blog authors as an asynchronous operation.
        /// </summary>
        /// <returns>IList&lt;BlogAuthor&gt;.</returns>
        public async Task<IList<BlogAuthor>> GetAllBlogAuthorsAsync()
        {
            return await _unitOfWork.BlogAuthorRepository.GetAllAsync();
        }

        /// <summary>
        /// Searches the blog authors.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;BlogAuthor&gt;.</returns>
        public IPagedList<BlogAuthor> SearchBlogAuthors(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<BlogAuthor>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return _unitOfWork.BlogAuthorRepository.GetPagedList(page, pageSize, ParseJSONSearchString<BlogAuthor>(where), sortExpression);
        }

        /// <summary>
        /// search blog authors as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;BlogAuthor&gt;.</returns>
        public async Task<IPagedList<BlogAuthor>> SearchBlogAuthorsAsync(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<BlogAuthor>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return await _unitOfWork.BlogAuthorRepository.GetPagedListAsync(page, pageSize, ParseJSONSearchString<BlogAuthor>(where), sortExpression);
        }

        /// <summary>
        /// Gets the blog author by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>BlogAuthor.</returns>
        public BlogAuthor GetBlogAuthorById(int id)
        {
            return _unitOfWork.BlogAuthorRepository.GetSingle(a => a.Id == id, a => a.Blogs, a => a.OrganizationUser);
        }

        /// <summary>
        /// get blog author by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>BlogAuthor.</returns>
        public async Task<BlogAuthor> GetBlogAuthorByIdAsync(int id)
        {
            return await _unitOfWork.BlogAuthorRepository.GetSingleAsync(a => a.Id == id, a => a.Blogs, a => a.OrganizationUser);
        }

        /// <summary>
        /// Adds the blog author.
        /// </summary>
        /// <param name="blogAuthors">The blog authors.</param>
        public void AddBlogAuthor(params BlogAuthor[] blogAuthors)
        {            
            _unitOfWork.BlogAuthorRepository.Add(blogAuthors);            
            _unitOfWork.Save();
        }

        /// <summary>
        /// add blog author as an asynchronous operation.
        /// </summary>
        /// <param name="blogAuthors">The blog authors.</param>
        public async Task AddBlogAuthorAsync(params BlogAuthor[] blogAuthors)
        {
            _unitOfWork.BlogAuthorRepository.Add(blogAuthors);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Updates the blog author.
        /// </summary>
        /// <param name="blogAuthors">The blog authors.</param>
        public void UpdateBlogAuthor(params BlogAuthor[] blogAuthors)
        {            
            _unitOfWork.BlogAuthorRepository.Update(blogAuthors);            
            _unitOfWork.Save();
        }

        /// <summary>
        /// update blog author as an asynchronous operation.
        /// </summary>
        /// <param name="blogAuthors">The blog authors.</param>
        public async Task UpdateBlogAuthorAsync(params BlogAuthor[] blogAuthors)
        {
            _unitOfWork.BlogAuthorRepository.Update(blogAuthors);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Removes the blog author.
        /// </summary>
        /// <param name="blogAuthors">The blog authors.</param>
        public void RemoveBlogAuthor(params BlogAuthor[] blogAuthors)
        {
            _unitOfWork.BlogAuthorRepository.Remove(blogAuthors);
            _unitOfWork.Save();
        }

        /// <summary>
        /// remove blog author as an asynchronous operation.
        /// </summary>
        /// <param name="blogAuthors">The blog authors.</param>
        public async Task RemoveBlogAuthorAsync(params BlogAuthor[] blogAuthors)
        {
            _unitOfWork.BlogAuthorRepository.Remove(blogAuthors);
            await _unitOfWork.SaveAsync();
        }

        #region ILocalizedBL
        /// <summary>
        /// Get full details of the single entity
        /// </summary>
        /// <param name="ofEntity">Passed entity is used as filter, method implementing ths feature should treat this oject apropriatly to call some method of BL class to read full details.</param>
        /// <returns>Entity instance</returns>
        public BlogAuthor GetDetails(BlogAuthor ofEntity)
        {
            if (ofEntity == null)
                return null;

            if (ofEntity.Id > 0)
                return GetBlogAuthorById(ofEntity.Id);
            
            return null;
        }

        /// <summary>
        /// Adds the single entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void AddSingleEntity(BlogAuthor entity)
        {
            _unitOfWork.BlogAuthorRepository.Add(entity);
            _unitOfWork.Save();
        }

        #endregion

        #endregion
    }
}
