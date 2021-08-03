// ***********************************************************************
// Assembly         : BAP.BL
// Author           : Victor Mamray
// Created          : 05-24-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="StateBL.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Threading.Tasks;
using PagedList;

using BAP.Common;
using BAP.DAL.Entities;
using BAP.DAL;
using BAP.Log;

namespace BAP.BL
{
    /// <summary>
    /// Interface IStateBL
    /// </summary>
    public interface IStateBL
    {
        /// <summary>
        /// Gets all states.
        /// </summary>
        /// <returns>IList&lt;State&gt;.</returns>
        IList<State> GetAllStates();
        /// <summary>
        /// Gets all states asynchronous.
        /// </summary>
        /// <returns>Task&lt;IList&lt;State&gt;&gt;.</returns>
        Task<IList<State>> GetAllStatesAsync();

        /// <summary>
        /// Searches the states.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;State&gt;.</returns>
        IPagedList<State> SearchStates(string where, string sort, int page, int pageSize = 20);
        /// <summary>
        /// Searches the states asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IPagedList&lt;State&gt;&gt;.</returns>
        Task<IPagedList<State>> SearchStatesAsync(string where, string sort, int page, int pageSize = 20);

        /// <summary>
        /// Searches the states.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>IList&lt;State&gt;.</returns>
        IList<State> SearchStates(string where, string sort);
        /// <summary>
        /// Searches the states asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>Task&lt;IList&lt;State&gt;&gt;.</returns>
        Task<IList<State>> SearchStatesAsync(string where, string sort);

        /// <summary>
        /// Gets the state by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>State.</returns>
        State GetStateById(int id);
        /// <summary>
        /// Gets the state by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;State&gt;.</returns>
        Task<State> GetStateByIdAsync(int id);

        /// <summary>
        /// Adds the state.
        /// </summary>
        /// <param name="states">The states.</param>
        void AddState(params State[] states);
        /// <summary>
        /// Adds the state asynchronous.
        /// </summary>
        /// <param name="states">The states.</param>
        /// <returns>Task.</returns>
        Task AddStateAsync(params State[] states);

        /// <summary>
        /// Updates the state.
        /// </summary>
        /// <param name="states">The states.</param>
        void UpdateState(params State[] states);
        /// <summary>
        /// Updates the state asynchronous.
        /// </summary>
        /// <param name="states">The states.</param>
        /// <returns>Task.</returns>
        Task UpdateStateAsync(params State[] states);

        /// <summary>
        /// Removes the state.
        /// </summary>
        /// <param name="states">The states.</param>
        void RemoveState(params State[] states);
        /// <summary>
        /// Removes the state asynchronous.
        /// </summary>
        /// <param name="states">The states.</param>
        /// <returns>Task.</returns>
        Task RemoveStateAsync(params State[] states);
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
    public partial class BusinessLayer : IStateBL
    {
        /// <summary>
        /// Gets all states.
        /// </summary>
        /// <returns>IList&lt;State&gt;.</returns>
        public IList<State> GetAllStates()
        {
            return _unitOfWork.StateRepository.GetAll(s => s.Country);
        }

        /// <summary>
        /// get all states as an asynchronous operation.
        /// </summary>
        /// <returns>IList&lt;State&gt;.</returns>
        public async Task<IList<State>> GetAllStatesAsync()
        {
            return await _unitOfWork.StateRepository.GetAllAsync(s => s.Country);
        }

        /// <summary>
        /// Searches the states.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;State&gt;.</returns>
        public IPagedList<State> SearchStates(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<State>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {                
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            return _unitOfWork.StateRepository.GetPagedList(page, pageSize, ParseJSONSearchString<State>(where), sortExpression);
        }

        /// <summary>
        /// search states as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;State&gt;.</returns>
        public async Task<IPagedList<State>> SearchStatesAsync(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<State>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            return await _unitOfWork.StateRepository.GetPagedListAsync(page, pageSize, ParseJSONSearchString<State>(where), sortExpression);
        }

        /// <summary>
        /// Searches the states.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>IList&lt;State&gt;.</returns>
        public IList<State> SearchStates(string where, string sort)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<State>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            return _unitOfWork.StateRepository.GetList(ParseJSONSearchString<State>(where), sortExpression);
        }

        /// <summary>
        /// search states as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>IList&lt;State&gt;.</returns>
        public async Task<IList<State>> SearchStatesAsync(string where, string sort)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<State>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            return await _unitOfWork.StateRepository.GetListAsync(ParseJSONSearchString<State>(where), sortExpression);
        }

        /// <summary>
        /// Gets the state by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>State.</returns>
        public State GetStateById(int id)
        {
            return _unitOfWork.StateRepository.GetSingle(c => c.Id == id);
        }

        /// <summary>
        /// get state by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>State.</returns>
        public async Task<State> GetStateByIdAsync(int id)
        {
            return await _unitOfWork.StateRepository.GetSingleAsync(c => c.Id == id);
        }

        /// <summary>
        /// Adds the state.
        /// </summary>
        /// <param name="states">The states.</param>
        public void AddState(params State[] states)
        {
            _unitOfWork.StateRepository.Add(states);
            _unitOfWork.Save();
        }

        /// <summary>
        /// add state as an asynchronous operation.
        /// </summary>
        /// <param name="states">The states.</param>
        public async Task AddStateAsync(params State[] states)
        {
            _unitOfWork.StateRepository.Add(states);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Updates the state.
        /// </summary>
        /// <param name="states">The states.</param>
        public void UpdateState(params State[] states)
        {
            _unitOfWork.StateRepository.Update(states);
            _unitOfWork.Save();
        }

        /// <summary>
        /// update state as an asynchronous operation.
        /// </summary>
        /// <param name="states">The states.</param>
        public async Task UpdateStateAsync(params State[] states)
        {
            _unitOfWork.StateRepository.Update(states);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Removes the state.
        /// </summary>
        /// <param name="states">The states.</param>
        public void RemoveState(params State[] states)
        {
            _unitOfWork.StateRepository.Remove(states);
            _unitOfWork.Save();
        }

        /// <summary>
        /// remove state as an asynchronous operation.
        /// </summary>
        /// <param name="states">The states.</param>
        public async Task RemoveStateAsync(params State[] states)
        {
            _unitOfWork.StateRepository.Remove(states);
            await _unitOfWork.SaveAsync();
        }
    }

    /// <summary>
    /// Class StateBL.
    /// Implements the <see cref="BAP.BL.BusinessLayer" />
    /// Implements the <see cref="BAP.Common.ISupportLookup" />
    /// </summary>
    /// <seealso cref="BAP.BL.BusinessLayer" />
    /// <seealso cref="BAP.Common.ISupportLookup" />
    public class StateBL : BusinessLayer, ISupportLookup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StateBL"/> class.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        public StateBL(IConfigHelper settings, IAuthorizationContext context, ILogger logger) : base(settings, context, logger)
        {

        }

        /// <summary>
        /// Gets the lookup items.
        /// </summary>
        /// <param name="valueField">The value field.</param>
        /// <param name="textField">The text field.</param>
        /// <param name="descriptionField">The description field.</param>
        /// <param name="extraFilter">The extra filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="roles">The roles.</param>
        /// <param name="setCurrentUserAsSelected">if set to <c>true</c> [set current user as selected].</param>
        /// <returns>IList&lt;LookupItem&gt;.</returns>
        public IList<LookupItem> GetLookupItems(string valueField, string textField, string descriptionField, string extraFilter, string orderBy, List<string> roles = null, bool setCurrentUserAsSelected = false)
        {
            List<LookupItem> result = new List<LookupItem>();
            var states = SearchStates(extraFilter, orderBy);
            foreach (var state in states)
            {
                var val = state.GetType().GetProperty(valueField).GetValue(state, null);
                var text = state.GetType().GetProperty(textField).GetValue(state, null);                
                var descr = text;
                if (!string.IsNullOrEmpty(descriptionField))
                {
                    descr = state.GetType().GetProperty(descriptionField).GetValue(state, null);
                }
                result.Add(new LookupItem { Key = val.ToString(), Text = text.ToString(), Description = descr.ToString() });
            }

            return result;
        }

        /// <summary>
        /// get lookup items as an asynchronous operation.
        /// </summary>
        /// <param name="valueField">The value field.</param>
        /// <param name="textField">The text field.</param>
        /// <param name="descriptionField">The description field.</param>
        /// <param name="extraFilter">The extra filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="roles">The roles.</param>
        /// <param name="setCurrentUserAsSelected">if set to <c>true</c> [set current user as selected].</param>
        /// <returns>IList&lt;LookupItem&gt;.</returns>
        public async Task<IList<LookupItem>> GetLookupItemsAsync(string valueField, string textField, string descriptionField = "", string extraFilter = "",
            string orderBy = "", List<string> roles = null, bool setCurrentUserAsSelected = false)
        {
            List<LookupItem> result = new List<LookupItem>();
            var states = await SearchStatesAsync(extraFilter, orderBy);
            foreach (var state in states)
            {
                var val = state.GetType().GetProperty(valueField).GetValue(state, null);
                var text = state.GetType().GetProperty(textField).GetValue(state, null);
                var descr = text;
                if (!string.IsNullOrEmpty(descriptionField))
                {
                    descr = state.GetType().GetProperty(descriptionField).GetValue(state, null);
                }
                result.Add(new LookupItem { Key = val.ToString(), Text = text.ToString(), Description = descr.ToString() });
            }

            return result;
        }
    }
}
