// ***********************************************************************
// Assembly         : BAP.BL
// Author           : Victor Mamray
// Created          : 05-20-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="EventLogBL.cs" company="BAP Software Ltd.">
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
    /// Interface IEventLogBL
    /// </summary>
    public interface IEventLogBL
    {
        /// <summary>
        /// Gets all event logs.
        /// </summary>
        /// <returns>IList&lt;EventLog&gt;.</returns>
        IList<EventLog> GetAllEventLogs();
        /// <summary>
        /// Gets all event logs asynchronous.
        /// </summary>
        /// <returns>Task&lt;IList&lt;EventLog&gt;&gt;.</returns>
        Task<IList<EventLog>> GetAllEventLogsAsync();

        /// <summary>
        /// Gets all events list.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>IList&lt;EventLog&gt;.</returns>
        IList<EventLog> GetAllEventsList(string where, string sort);
        /// <summary>
        /// Gets all events list asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>Task&lt;IList&lt;EventLog&gt;&gt;.</returns>
        Task<IList<EventLog>> GetAllEventsListAsync(string where, string sort);

        /// <summary>
        /// Searches the event logs.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;EventLog&gt;.</returns>
        IPagedList<EventLog> SearchEventLogs(string where, string sort, int page, int pageSize = 20);
        /// <summary>
        /// Searches the event logs asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IPagedList&lt;EventLog&gt;&gt;.</returns>
        Task<IPagedList<EventLog>> SearchEventLogsAsync(string where, string sort, int page, int pageSize = 20);

        /// <summary>
        /// Gets the event log by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>EventLog.</returns>
        EventLog GetEventLogById(int id);
        /// <summary>
        /// Gets the event log by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;EventLog&gt;.</returns>
        Task<EventLog> GetEventLogByIdAsync(int id);

        /// <summary>
        /// Adds the event log.
        /// </summary>
        /// <param name="eventLogs">The event logs.</param>
        void AddEventLog(params EventLog[] eventLogs);
        /// <summary>
        /// Adds the event log asynchronous.
        /// </summary>
        /// <param name="eventLogs">The event logs.</param>
        /// <returns>Task.</returns>
        Task AddEventLogAsync(params EventLog[] eventLogs);

        /// <summary>
        /// Updates the event log.
        /// </summary>
        /// <param name="eventLogs">The event logs.</param>
        void UpdateEventLog(params EventLog[] eventLogs);
        /// <summary>
        /// Updates the event log asynchronous.
        /// </summary>
        /// <param name="eventLogs">The event logs.</param>
        /// <returns>Task.</returns>
        Task UpdateEventLogAsync(params EventLog[] eventLogs);

        /// <summary>
        /// Removes the event log.
        /// </summary>
        /// <param name="eventLogs">The event logs.</param>
        void RemoveEventLog(params EventLog[] eventLogs);
        /// <summary>
        /// Removes the event log asynchronous.
        /// </summary>
        /// <param name="eventLogs">The event logs.</param>
        /// <returns>Task.</returns>
        Task RemoveEventLogAsync(params EventLog[] eventLogs);
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
    public partial class BusinessLayer : IEventLogBL
    {
        /// <summary>
        /// Gets all event logs.
        /// </summary>
        /// <returns>IList&lt;EventLog&gt;.</returns>
        public IList<EventLog> GetAllEventLogs()
        {
            return _unitOfWork.EventLogRepository.GetAll();
        }

        /// <summary>
        /// get all event logs as an asynchronous operation.
        /// </summary>
        /// <returns>IList&lt;EventLog&gt;.</returns>
        public async Task<IList<EventLog>> GetAllEventLogsAsync()
        {
            return await _unitOfWork.EventLogRepository.GetAllAsync();
        }

        /// <summary>
        /// Gets all events list.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>IList&lt;EventLog&gt;.</returns>
        public IList<EventLog> GetAllEventsList(string where, string sort)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<EventLog>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return _unitOfWork.EventLogRepository.GetList(ParseJSONSearchString<EventLog>(where), sortExpression);
        }

        /// <summary>
        /// get all events list as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>IList&lt;EventLog&gt;.</returns>
        public async Task<IList<EventLog>> GetAllEventsListAsync(string where, string sort)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<EventLog>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return await _unitOfWork.EventLogRepository.GetListAsync(ParseJSONSearchString<EventLog>(where), sortExpression);
        }

        /// <summary>
        /// Searches the event logs.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;EventLog&gt;.</returns>
        public IPagedList<EventLog> SearchEventLogs(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<EventLog>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return _unitOfWork.EventLogRepository.GetPagedList(page, pageSize, ParseJSONSearchString<EventLog>(where), sortExpression);
        }

        /// <summary>
        /// search event logs as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;EventLog&gt;.</returns>
        public async Task<IPagedList<EventLog>> SearchEventLogsAsync(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<EventLog>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return await _unitOfWork.EventLogRepository.GetPagedListAsync(page, pageSize, ParseJSONSearchString<EventLog>(where), sortExpression);
        }

        /// <summary>
        /// Gets the event log by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>EventLog.</returns>
        public EventLog GetEventLogById(int id)
        {
            return _unitOfWork.EventLogRepository.GetSingle(c => c.Id == id);
        }

        /// <summary>
        /// get event log by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>EventLog.</returns>
        public async Task<EventLog> GetEventLogByIdAsync(int id)
        {
            return await _unitOfWork.EventLogRepository.GetSingleAsync(c => c.Id == id);
        }

        /// <summary>
        /// Adds the event log.
        /// </summary>
        /// <param name="eventLogs">The event logs.</param>
        public void AddEventLog(params EventLog[] eventLogs)
        {
            _unitOfWork.EventLogRepository.Add(eventLogs);
            _unitOfWork.Save();
        }

        /// <summary>
        /// add event log as an asynchronous operation.
        /// </summary>
        /// <param name="eventLogs">The event logs.</param>
        public async Task AddEventLogAsync(params EventLog[] eventLogs)
        {
            _unitOfWork.EventLogRepository.Add(eventLogs);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Updates the event log.
        /// </summary>
        /// <param name="eventLogs">The event logs.</param>
        public void UpdateEventLog(params EventLog[] eventLogs)
        {
            _unitOfWork.EventLogRepository.Update(eventLogs);
            _unitOfWork.Save();
        }

        /// <summary>
        /// update event log as an asynchronous operation.
        /// </summary>
        /// <param name="eventLogs">The event logs.</param>
        public async Task UpdateEventLogAsync(params EventLog[] eventLogs)
        {
            _unitOfWork.EventLogRepository.Update(eventLogs);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Removes the event log.
        /// </summary>
        /// <param name="eventLogs">The event logs.</param>
        public void RemoveEventLog(params EventLog[] eventLogs)
        {
            _unitOfWork.EventLogRepository.Remove(eventLogs);
            _unitOfWork.Save();
        }

        /// <summary>
        /// remove event log as an asynchronous operation.
        /// </summary>
        /// <param name="eventLogs">The event logs.</param>
        public async Task RemoveEventLogAsync(params EventLog[] eventLogs)
        {
            _unitOfWork.EventLogRepository.Remove(eventLogs);
            await _unitOfWork.SaveAsync();
        }
    }
}
