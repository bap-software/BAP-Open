// ***********************************************************************
// Assembly         : BAP.BL
// Author           : Victor Mamray
// Created          : 05-24-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="SubscriptionBL.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PagedList;

using BAP.Common;
using BAP.Common.Exceptions;
using BAP.DAL.Entities;

namespace BAP.BL
{
    /// <summary>
    /// Interface ISubscriptionBL
    /// </summary>
    public interface ISubscriptionBL
    {
        /// <summary>
        /// Initializes subscription
        /// </summary>
        /// <param name="type">Type of subscription</param>
        /// <param name="term">Textual representation of term, e.g. word containing trial, annual, monthly, weekly, etc.</param>
        /// <returns>Subscription instance</returns>
        /// <exception cref="BAPSubscriptionException">Thrown when not able to initialize subscription with term and renewal attributes</exception>
        Subscription InitSubscription(string type, string term);

        /// <summary>
        /// Gets all subscriptions.
        /// </summary>
        /// <returns>IList&lt;Subscription&gt;.</returns>
        IList<Subscription> GetAllSubscriptions();
        /// <summary>
        /// Gets all subscriptions asynchronous.
        /// </summary>
        /// <returns>Task&lt;IList&lt;Subscription&gt;&gt;.</returns>
        Task<IList<Subscription>> GetAllSubscriptionsAsync();

        /// <summary>
        /// Searches the subscriptions.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;Subscription&gt;.</returns>
        IPagedList<Subscription> SearchSubscriptions(string where, string sort, int page, int pageSize = 20);
        /// <summary>
        /// Searches the subscriptions asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IPagedList&lt;Subscription&gt;&gt;.</returns>
        Task<IPagedList<Subscription>> SearchSubscriptionsAsync(string where, string sort, int page, int pageSize = 20);

        /// <summary>
        /// Gets the subscription by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Subscription.</returns>
        Subscription GetSubscriptionById(int id);
        /// <summary>
        /// Gets the subscription by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;Subscription&gt;.</returns>
        Task<Subscription> GetSubscriptionByIdAsync(int id);

        /// <summary>
        /// Gets the subscription by user identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Subscription.</returns>
        Subscription GetSubscriptionByUserId(int id);
        /// <summary>
        /// Gets the subscription by user identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;Subscription&gt;.</returns>
        Task<Subscription> GetSubscriptionByUserIdAsync(int id);

        /// <summary>
        /// Adds the subscription.
        /// </summary>
        /// <param name="subscriptions">The subscriptions.</param>
        void AddSubscription(params Subscription[] subscriptions);
        /// <summary>
        /// Adds the subscription asynchronous.
        /// </summary>
        /// <param name="subscriptions">The subscriptions.</param>
        /// <returns>Task.</returns>
        Task AddSubscriptionAsync(params Subscription[] subscriptions);

        /// <summary>
        /// Updates the subscription.
        /// </summary>
        /// <param name="subscriptions">The subscriptions.</param>
        void UpdateSubscription(params Subscription[] subscriptions);
        /// <summary>
        /// Updates the subscription asynchronous.
        /// </summary>
        /// <param name="subscriptions">The subscriptions.</param>
        /// <returns>Task.</returns>
        Task UpdateSubscriptionAsync(params Subscription[] subscriptions);

        /// <summary>
        /// Removes the subscription.
        /// </summary>
        /// <param name="subscriptions">The subscriptions.</param>
        void RemoveSubscription(params Subscription[] subscriptions);
        /// <summary>
        /// Removes the subscription asynchronous.
        /// </summary>
        /// <param name="subscriptions">The subscriptions.</param>
        /// <returns>Task.</returns>
        Task RemoveSubscriptionAsync(params Subscription[] subscriptions);
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
    public partial class BusinessLayer : ISubscriptionBL
    {
        /// <summary>
        /// Initializes subscription
        /// </summary>
        /// <param name="type">Type of subscription</param>
        /// <param name="term">Textual representation of term, e.g. word containing trial, annual, monthly, weekly, etc.</param>
        /// <returns>Subscription instance</returns>
        /// <exception cref="BAP.Common.Exceptions.BAPSubscriptionException">Cannot initialize subscription using given type: [{type}] and term: [{term}]</exception>
        public Subscription InitSubscription(string type, string term)
        {
            var result = new Subscription
            {
                SubscriptionType = type,
                ContractDate = DateTime.Now
            };

            if(!string.IsNullOrEmpty(term))
            {
                if(term.ToLower().Contains("trial"))
                {
                    result.InitialTerm = 1;
                    result.TermStart = DateTime.Today;
                    result.TermEnd = result.TermStart.AddDays(30);
                    result.AutoRenew = false;
                    result.RenewalTerm = 0;
                }

                if (term.ToLower().Contains("week"))
                {
                    result.InitialTerm = 0;
                    result.TermStart = DateTime.Today;
                    result.TermEnd = result.TermStart.AddDays(7);
                    result.AutoRenew = false;
                    result.RenewalTerm = 0;
                }

                if (term.ToLower().Contains("month"))
                {
                    result.InitialTerm = 1;
                    result.TermStart = DateTime.Today;
                    result.TermEnd = result.TermStart.AddMonths(1);
                    result.AutoRenew = true;
                    result.RenewalTerm = 1;
                }

                if (term.ToLower().Contains("annual"))
                {
                    result.InitialTerm = 12;
                    result.TermStart = DateTime.Today;
                    result.TermEnd = result.TermStart.AddYears(1);
                    result.AutoRenew = true;
                    result.RenewalTerm = 12;
                }
            }

            //TODO: add subtotal calculation

            if(result.TermStart == DateTime.MinValue)
            {
                throw new BAPSubscriptionException($"Cannot initialize subscription using given type: [{type}] and term: [{term}]");
            }

            return result;
        }

        /// <summary>
        /// Gets all subscriptions.
        /// </summary>
        /// <returns>IList&lt;Subscription&gt;.</returns>
        public IList<Subscription> GetAllSubscriptions()
        {
            return _unitOfWork.SubscriptionRepository.GetAll(c => c.User, c => c.Organization);
        }

        /// <summary>
        /// get all subscriptions as an asynchronous operation.
        /// </summary>
        /// <returns>IList&lt;Subscription&gt;.</returns>
        public async Task<IList<Subscription>> GetAllSubscriptionsAsync()
        {
            return await _unitOfWork.SubscriptionRepository.GetAllAsync(c => c.User, c => c.Organization);
        }

        /// <summary>
        /// Searches the subscriptions.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;Subscription&gt;.</returns>
        public IPagedList<Subscription> SearchSubscriptions(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<Subscription>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return _unitOfWork.SubscriptionRepository.GetPagedList(page, pageSize, ParseJSONSearchString<Subscription>(where), sortExpression, c => c.User, c => c.Organization);
        }

        /// <summary>
        /// search subscriptions as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;Subscription&gt;.</returns>
        public async Task<IPagedList<Subscription>> SearchSubscriptionsAsync(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<Subscription>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return await _unitOfWork.SubscriptionRepository.GetPagedListAsync(page, pageSize, ParseJSONSearchString<Subscription>(where), sortExpression, c => c.User, c => c.Organization);
        }

        /// <summary>
        /// Gets the subscription by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Subscription.</returns>
        public Subscription GetSubscriptionById(int id)
        {
            return _unitOfWork.SubscriptionRepository.GetSingle(c => c.Id == id, c => c.User, c => c.Organization);
        }

        /// <summary>
        /// get subscription by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Subscription.</returns>
        public async Task<Subscription> GetSubscriptionByIdAsync(int id)
        {
            return await _unitOfWork.SubscriptionRepository.GetSingleAsync(c => c.Id == id, c => c.User, c => c.Organization);
        }

        /// <summary>
        /// Gets the subscription by user identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Subscription.</returns>
        public Subscription GetSubscriptionByUserId(int id)
        {
            return _unitOfWork.SubscriptionRepository.GetSingle(c => c.User != null && c.User.Id == id, c => c.User, c => c.Organization);
        }

        /// <summary>
        /// get subscription by user identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Subscription.</returns>
        public async Task<Subscription> GetSubscriptionByUserIdAsync(int id)
        {
            return await _unitOfWork.SubscriptionRepository.GetSingleAsync(c => c.User != null && c.User.Id == id, c => c.User, c => c.Organization);
        }

        /// <summary>
        /// Adds the subscription.
        /// </summary>
        /// <param name="subscriptions">The subscriptions.</param>
        public void AddSubscription(params Subscription[] subscriptions)
        {
            _unitOfWork.SubscriptionRepository.Add(subscriptions);
            _unitOfWork.Save();
        }

        /// <summary>
        /// add subscription as an asynchronous operation.
        /// </summary>
        /// <param name="subscriptions">The subscriptions.</param>
        public async Task AddSubscriptionAsync(params Subscription[] subscriptions)
        {
            _unitOfWork.SubscriptionRepository.Add(subscriptions);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Updates the subscription.
        /// </summary>
        /// <param name="subscriptions">The subscriptions.</param>
        public void UpdateSubscription(params Subscription[] subscriptions)
        {
            _unitOfWork.SubscriptionRepository.Update(subscriptions);
            _unitOfWork.Save();
        }

        /// <summary>
        /// update subscription as an asynchronous operation.
        /// </summary>
        /// <param name="subscriptions">The subscriptions.</param>
        public async Task UpdateSubscriptionAsync(params Subscription[] subscriptions)
        {
            _unitOfWork.SubscriptionRepository.Update(subscriptions);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Removes the subscription.
        /// </summary>
        /// <param name="subscriptions">The subscriptions.</param>
        public void RemoveSubscription(params Subscription[] subscriptions)
        {
            _unitOfWork.SubscriptionRepository.Remove(subscriptions);
            _unitOfWork.Save();
        }

        /// <summary>
        /// remove subscription as an asynchronous operation.
        /// </summary>
        /// <param name="subscriptions">The subscriptions.</param>
        public async Task RemoveSubscriptionAsync(params Subscription[] subscriptions)
        {
            _unitOfWork.SubscriptionRepository.Remove(subscriptions);
            await _unitOfWork.SaveAsync();
        }
    }
}
