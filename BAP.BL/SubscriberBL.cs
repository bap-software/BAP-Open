// ***********************************************************************
// Assembly         : BAP.BL
// Author           : Victor Mamray
// Created          : 05-20-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="SubscriberBL.cs" company="BAP Software Ltd.">
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
    /// Interface ISubscriberBL
    /// </summary>
    public interface ISubscriberBL
    {
        /// <summary>
        /// Gets all subscribers.
        /// </summary>
        /// <returns>IList&lt;Subscriber&gt;.</returns>
        IList<Subscriber> GetAllSubscribers();
        /// <summary>
        /// Gets all subscribers asynchronous.
        /// </summary>
        /// <returns>Task&lt;IList&lt;Subscriber&gt;&gt;.</returns>
        Task<IList<Subscriber>> GetAllSubscribersAsync();

        /// <summary>
        /// Gets the active subscribers.
        /// </summary>
        /// <returns>IList&lt;Subscriber&gt;.</returns>
        IList<Subscriber> GetActiveSubscribers();
        /// <summary>
        /// Gets the active subscribers asynchronous.
        /// </summary>
        /// <returns>Task&lt;IList&lt;Subscriber&gt;&gt;.</returns>
        Task<IList<Subscriber>> GetActiveSubscribersAsync();

        /// <summary>
        /// Searches the subscribers.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;Subscriber&gt;.</returns>
        IPagedList<Subscriber> SearchSubscribers(string where, string sort, int page, int pageSize = 20);
        /// <summary>
        /// Searches the subscribers asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IPagedList&lt;Subscriber&gt;&gt;.</returns>
        Task<IPagedList<Subscriber>> SearchSubscribersAsync(string where, string sort, int page, int pageSize = 20);

        /// <summary>
        /// Gets the subscriber by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Subscriber.</returns>
        Subscriber GetSubscriberById(int id);
        /// <summary>
        /// Gets the subscriber by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;Subscriber&gt;.</returns>
        Task<Subscriber> GetSubscriberByIdAsync(int id);

        /// <summary>
        /// Adds the subscriber.
        /// </summary>
        /// <param name="subscribers">The subscribers.</param>
        void AddSubscriber(params Subscriber[] subscribers);
        /// <summary>
        /// Adds the subscriber asynchronous.
        /// </summary>
        /// <param name="subscribers">The subscribers.</param>
        /// <returns>Task.</returns>
        Task AddSubscriberAsync(params Subscriber[] subscribers);

        /// <summary>
        /// Updates the subscriber.
        /// </summary>
        /// <param name="subscribers">The subscribers.</param>
        void UpdateSubscriber(params Subscriber[] subscribers);
        /// <summary>
        /// Updates the subscriber asynchronous.
        /// </summary>
        /// <param name="subscribers">The subscribers.</param>
        /// <returns>Task.</returns>
        Task UpdateSubscriberAsync(params Subscriber[] subscribers);

        /// <summary>
        /// Removes the subscriber.
        /// </summary>
        /// <param name="subscribers">The subscribers.</param>
        void RemoveSubscriber(params Subscriber[] subscribers);
        /// <summary>
        /// Removes the subscriber asynchronous.
        /// </summary>
        /// <param name="subscribers">The subscribers.</param>
        /// <returns>Task.</returns>
        Task RemoveSubscriberAsync(params Subscriber[] subscribers);
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
    public partial class BusinessLayer : ISubscriberBL
    {
        #region subscribers

        /// <summary>
        /// Gets all subscribers.
        /// </summary>
        /// <returns>IList&lt;Subscriber&gt;.</returns>
        public IList<Subscriber> GetAllSubscribers()
        {
            return _unitOfWork.SubscriberRepository.GetAll();
        }

        /// <summary>
        /// get all subscribers as an asynchronous operation.
        /// </summary>
        /// <returns>IList&lt;Subscriber&gt;.</returns>
        public async Task<IList<Subscriber>> GetAllSubscribersAsync()
        {
            return await _unitOfWork.SubscriberRepository.GetAllAsync();
        }

        /// <summary>
        /// Gets the active subscribers.
        /// </summary>
        /// <returns>IList&lt;Subscriber&gt;.</returns>
        public IList<Subscriber> GetActiveSubscribers()
        {
            return _unitOfWork.SubscriberRepository.GetList(a => a.Enabled);
        }

        /// <summary>
        /// get active subscribers as an asynchronous operation.
        /// </summary>
        /// <returns>IList&lt;Subscriber&gt;.</returns>
        public async Task<IList<Subscriber>> GetActiveSubscribersAsync()
        {
            return await _unitOfWork.SubscriberRepository.GetListAsync(a => a.Enabled);
        }

        /// <summary>
        /// Searches the subscribers.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;Subscriber&gt;.</returns>
        public IPagedList<Subscriber> SearchSubscribers(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<Subscriber>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            return _unitOfWork.SubscriberRepository.GetPagedList(page, pageSize, ParseJSONSearchString<Subscriber>(where), sortExpression);
        }

        /// <summary>
        /// search subscribers as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;Subscriber&gt;.</returns>
        public async Task<IPagedList<Subscriber>> SearchSubscribersAsync(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<Subscriber>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            return await _unitOfWork.SubscriberRepository.GetPagedListAsync(page, pageSize, ParseJSONSearchString<Subscriber>(where), sortExpression);
        }

        /// <summary>
        /// Gets the subscriber by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Subscriber.</returns>
        public Subscriber GetSubscriberById(int id)
        {
            return _unitOfWork.SubscriberRepository.GetSingle(a => a.Id == id);
        }

        /// <summary>
        /// get subscriber by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Subscriber.</returns>
        public async Task<Subscriber> GetSubscriberByIdAsync(int id)
        {
            return await _unitOfWork.SubscriberRepository.GetSingleAsync(a => a.Id == id);
        }

        /// <summary>
        /// Adds the subscriber.
        /// </summary>
        /// <param name="subscribers">The subscribers.</param>
        public void AddSubscriber(params Subscriber[] subscribers)
        {
            _unitOfWork.SubscriberRepository.Add(subscribers);
            _unitOfWork.Save();
        }

        /// <summary>
        /// add subscriber as an asynchronous operation.
        /// </summary>
        /// <param name="subscribers">The subscribers.</param>
        public async Task AddSubscriberAsync(params Subscriber[] subscribers)
        {
            _unitOfWork.SubscriberRepository.Add(subscribers);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Updates the subscriber.
        /// </summary>
        /// <param name="subscribers">The subscribers.</param>
        public void UpdateSubscriber(params Subscriber[] subscribers)
        {
            _unitOfWork.SubscriberRepository.Update(subscribers);
            _unitOfWork.Save();
        }

        /// <summary>
        /// update subscriber as an asynchronous operation.
        /// </summary>
        /// <param name="subscribers">The subscribers.</param>
        public async Task UpdateSubscriberAsync(params Subscriber[] subscribers)
        {
            _unitOfWork.SubscriberRepository.Update(subscribers);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Removes the subscriber.
        /// </summary>
        /// <param name="subscribers">The subscribers.</param>
        public void RemoveSubscriber(params Subscriber[] subscribers)
        {
            _unitOfWork.SubscriberRepository.Remove(subscribers);
            _unitOfWork.Save();
        }

        /// <summary>
        /// remove subscriber as an asynchronous operation.
        /// </summary>
        /// <param name="subscribers">The subscribers.</param>
        public async Task RemoveSubscriberAsync(params Subscriber[] subscribers)
        {
            _unitOfWork.SubscriberRepository.Remove(subscribers);
            await _unitOfWork.SaveAsync();
        }

        #endregion
    }
}
