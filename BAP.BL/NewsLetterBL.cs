// ***********************************************************************
// Assembly         : BAP.BL
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="NewsLetterBL.cs" company="BAP Software Ltd.">
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
    /// Interface INewsLetterBL
    /// </summary>
    public interface INewsLetterBL
    {
        /// <summary>
        /// Gets all news letters.
        /// </summary>
        /// <returns>IList&lt;NewsLetter&gt;.</returns>
        IList<NewsLetter> GetAllNewsLetters();
        /// <summary>
        /// Gets all news letters asynchronous.
        /// </summary>
        /// <returns>Task&lt;IList&lt;NewsLetter&gt;&gt;.</returns>
        Task<IList<NewsLetter>> GetAllNewsLettersAsync();

        /// <summary>
        /// Gets the recent news letters.
        /// </summary>
        /// <returns>IList&lt;NewsLetter&gt;.</returns>
        IList<NewsLetter> GetRecentNewsLetters();
        /// <summary>
        /// Gets the recent news letters asynchronous.
        /// </summary>
        /// <returns>Task&lt;IList&lt;NewsLetter&gt;&gt;.</returns>
        Task<IList<NewsLetter>> GetRecentNewsLettersAsync();

        /// <summary>
        /// Searches the news letters.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;NewsLetter&gt;.</returns>
        IPagedList<NewsLetter> SearchNewsLetters(string where, string sort, int page, int pageSize = 20);
        /// <summary>
        /// Searches the news letters asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IPagedList&lt;NewsLetter&gt;&gt;.</returns>
        Task<IPagedList<NewsLetter>> SearchNewsLettersAsync(string where, string sort, int page, int pageSize = 20);

        /// <summary>
        /// Gets the news letter by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>NewsLetter.</returns>
        NewsLetter GetNewsLetterById(int id);
        /// <summary>
        /// Gets the news letter by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;NewsLetter&gt;.</returns>
        Task<NewsLetter> GetNewsLetterByIdAsync(int id);

        /// <summary>
        /// Adds the news letter.
        /// </summary>
        /// <param name="newsLetters">The news letters.</param>
        void AddNewsLetter(params NewsLetter[] newsLetters);
        /// <summary>
        /// Adds the news letter asynchronous.
        /// </summary>
        /// <param name="newsLetters">The news letters.</param>
        /// <returns>Task.</returns>
        Task AddNewsLetterAsync(params NewsLetter[] newsLetters);

        /// <summary>
        /// Updates the news letter.
        /// </summary>
        /// <param name="newsLetters">The news letters.</param>
        void UpdateNewsLetter(params NewsLetter[] newsLetters);
        /// <summary>
        /// Updates the news letter asynchronous.
        /// </summary>
        /// <param name="newsLetters">The news letters.</param>
        /// <returns>Task.</returns>
        Task UpdateNewsLetterAsync(params NewsLetter[] newsLetters);

        /// <summary>
        /// Removes the news letter.
        /// </summary>
        /// <param name="newsLetters">The news letters.</param>
        void RemoveNewsLetter(params NewsLetter[] newsLetters);
        /// <summary>
        /// Removes the news letter asynchronous.
        /// </summary>
        /// <param name="newsLetters">The news letters.</param>
        /// <returns>Task.</returns>
        Task RemoveNewsLetterAsync(params NewsLetter[] newsLetters);
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
    public partial class BusinessLayer : INewsLetterBL, ILocalizedBL<NewsLetter>
    {

        #region newsLetters

        /// <summary>
        /// Gets all news letters.
        /// </summary>
        /// <returns>IList&lt;NewsLetter&gt;.</returns>
        public IList<NewsLetter> GetAllNewsLetters()
        {
            return _unitOfWork.NewsLetterRepository.GetAll();
        }

        /// <summary>
        /// get all news letters as an asynchronous operation.
        /// </summary>
        /// <returns>IList&lt;NewsLetter&gt;.</returns>
        public async Task<IList<NewsLetter>> GetAllNewsLettersAsync()
        {
            return await _unitOfWork.NewsLetterRepository.GetAllAsync();
        }

        /// <summary>
        /// Gets the recent news letters.
        /// </summary>
        /// <returns>IList&lt;NewsLetter&gt;.</returns>
        public IList<NewsLetter> GetRecentNewsLetters()
        {
            Func<IQueryable<NewsLetter>, IOrderedQueryable<NewsLetter>> orderBy = q => q.OrderBy(a => a.CreateDate);
            return _unitOfWork.NewsLetterRepository.GetList(a => !a.Published, orderBy);
        }

        /// <summary>
        /// get recent news letters as an asynchronous operation.
        /// </summary>
        /// <returns>IList&lt;NewsLetter&gt;.</returns>
        public async Task<IList<NewsLetter>> GetRecentNewsLettersAsync()
        {
            Func<IQueryable<NewsLetter>, IOrderedQueryable<NewsLetter>> orderBy = q => q.OrderBy(a => a.CreateDate);
            return await _unitOfWork.NewsLetterRepository.GetListAsync(a => !a.Published, orderBy);
        }

        /// <summary>
        /// Searches the news letters.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;NewsLetter&gt;.</returns>
        public IPagedList<NewsLetter> SearchNewsLetters(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<NewsLetter>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            return _unitOfWork.NewsLetterRepository.GetPagedList(page, pageSize, ParseJSONSearchString<NewsLetter>(where), sortExpression);
        }

        /// <summary>
        /// search news letters as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;NewsLetter&gt;.</returns>
        public async Task<IPagedList<NewsLetter>> SearchNewsLettersAsync(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<NewsLetter>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            return await _unitOfWork.NewsLetterRepository.GetPagedListAsync(page, pageSize, ParseJSONSearchString<NewsLetter>(where), sortExpression);
        }

        /// <summary>
        /// Gets the news letter by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>NewsLetter.</returns>
        public NewsLetter GetNewsLetterById(int id)
        {
            return _unitOfWork.NewsLetterRepository.GetSingle(a => a.Id == id);
        }

        /// <summary>
        /// get news letter by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>NewsLetter.</returns>
        public async Task<NewsLetter> GetNewsLetterByIdAsync(int id)
        {
            return await _unitOfWork.NewsLetterRepository.GetSingleAsync(a => a.Id == id);
        }

        /// <summary>
        /// Adds the news letter.
        /// </summary>
        /// <param name="newsLetters">The news letters.</param>
        public void AddNewsLetter(params NewsLetter[] newsLetters)
        {
            _unitOfWork.NewsLetterRepository.Add(newsLetters);
            _unitOfWork.Save();
        }

        /// <summary>
        /// add news letter as an asynchronous operation.
        /// </summary>
        /// <param name="newsLetters">The news letters.</param>
        public async Task AddNewsLetterAsync(params NewsLetter[] newsLetters)
        {
            _unitOfWork.NewsLetterRepository.Add(newsLetters);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Updates the news letter.
        /// </summary>
        /// <param name="newsLetters">The news letters.</param>
        public void UpdateNewsLetter(params NewsLetter[] newsLetters)
        {
            _unitOfWork.NewsLetterRepository.Update(newsLetters);
            _unitOfWork.Save();
        }

        /// <summary>
        /// update news letter as an asynchronous operation.
        /// </summary>
        /// <param name="newsLetters">The news letters.</param>
        public async Task UpdateNewsLetterAsync(params NewsLetter[] newsLetters)
        {
            _unitOfWork.NewsLetterRepository.Update(newsLetters);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Removes the news letter.
        /// </summary>
        /// <param name="newsLetters">The news letters.</param>
        public void RemoveNewsLetter(params NewsLetter[] newsLetters)
        {
            _unitOfWork.NewsLetterRepository.Remove(newsLetters);
            _unitOfWork.Save();
        }

        /// <summary>
        /// remove news letter as an asynchronous operation.
        /// </summary>
        /// <param name="newsLetters">The news letters.</param>
        public async Task RemoveNewsLetterAsync(params NewsLetter[] newsLetters)
        {
            _unitOfWork.NewsLetterRepository.Remove(newsLetters);
            await _unitOfWork.SaveAsync();
        }

        #region ILocalizedBL
        /// <summary>
        /// Get full details of the single entity
        /// </summary>
        /// <param name="ofEntity">Passed entity is used as filter, method implementing ths feature should treat this oject apropriatly to call some method of BL class to read full details.</param>
        /// <returns>Entity instance</returns>
        public NewsLetter GetDetails(NewsLetter ofEntity)
        {
            if (ofEntity == null)
                return null;

            if (ofEntity.Id > 0)
                return GetNewsLetterById(ofEntity.Id);            

            return null;
        }

        /// <summary>
        /// Adds the single entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void AddSingleEntity(NewsLetter entity)
        {
            _unitOfWork.NewsLetterRepository.Add(entity);
            _unitOfWork.Save();
        }
        #endregion

        #endregion
    }
}
