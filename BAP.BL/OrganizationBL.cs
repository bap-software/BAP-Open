// ***********************************************************************
// Assembly         : BAP.BL
// Author           : Victor Mamray
// Created          : 05-24-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="OrganizationBL.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;

using PagedList;

using BAP.Common;
using BAP.DAL.Entities;
using BAP.DAL;
using BAP.Log;
using System.Linq;
using System.Threading.Tasks;

namespace BAP.BL
{
    /// <summary>
    /// Interface IOrganizationBL
    /// </summary>
    public interface IOrganizationBL
    {
        /// <summary>
        /// Gets all organizations.
        /// </summary>
        /// <returns>IList&lt;Organization&gt;.</returns>
        IList<Organization> GetAllOrganizations();
        /// <summary>
        /// Gets all organizations asynchronous.
        /// </summary>
        /// <returns>Task&lt;IList&lt;Organization&gt;&gt;.</returns>
        Task<IList<Organization>> GetAllOrganizationsAsync();

        /// <summary>
        /// Searches the organizations.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;Organization&gt;.</returns>
        IPagedList<Organization> SearchOrganizations(string where, string sort, int page, int pageSize = 20);
        /// <summary>
        /// Searches the organizations asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IPagedList&lt;Organization&gt;&gt;.</returns>
        Task<IPagedList<Organization>> SearchOrganizationsAsync(string where, string sort, int page, int pageSize = 20);

        /// <summary>
        /// Searches the organizations.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>IList&lt;Organization&gt;.</returns>
        IList<Organization> SearchOrganizations(string where, string sort);
        /// <summary>
        /// Searches the organizations asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>Task&lt;IList&lt;Organization&gt;&gt;.</returns>
        Task<IList<Organization>> SearchOrganizationsAsync(string where, string sort);

        /// <summary>
        /// Gets the organization by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Organization.</returns>
        Organization GetOrganizationById(int id);
        /// <summary>
        /// Gets the organization by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;Organization&gt;.</returns>
        Task<Organization> GetOrganizationByIdAsync(int id);

        /// <summary>
        /// Currents the organzation.
        /// </summary>
        /// <returns>Organization.</returns>
        Organization CurrentOrganzation();
        /// <summary>
        /// Currents the organzation asynchronous.
        /// </summary>
        /// <returns>Task&lt;Organization&gt;.</returns>
        Task<Organization> CurrentOrganzationAsync();

        /// <summary>
        /// Adds the organization.
        /// </summary>
        /// <param name="organizations">The organizations.</param>
        void AddOrganization(params Organization[] organizations);
        /// <summary>
        /// Adds the organization asynchronous.
        /// </summary>
        /// <param name="organizations">The organizations.</param>
        /// <returns>Task.</returns>
        Task AddOrganizationAsync(params Organization[] organizations);

        /// <summary>
        /// Updates the organization.
        /// </summary>
        /// <param name="organizations">The organizations.</param>
        void UpdateOrganization(params Organization[] organizations);
        /// <summary>
        /// Updates the organization asynchronous.
        /// </summary>
        /// <param name="organizations">The organizations.</param>
        /// <returns>Task.</returns>
        Task UpdateOrganizationAsync(params Organization[] organizations);

        /// <summary>
        /// Removes the organization.
        /// </summary>
        /// <param name="organizations">The organizations.</param>
        void RemoveOrganization(params Organization[] organizations);
        /// <summary>
        /// Removes the organization asynchronous.
        /// </summary>
        /// <param name="organizations">The organizations.</param>
        /// <returns>Task.</returns>
        Task RemoveOrganizationAsync(params Organization[] organizations);

        /// <summary>
        /// Determines whether this instance can read the specified org.
        /// </summary>
        /// <param name="org">The org.</param>
        /// <returns><c>true</c> if this instance can read the specified org; otherwise, <c>false</c>.</returns>
        bool CanRead(Organization org = null);
        /// <summary>
        /// Determines whether this instance can write the specified org.
        /// </summary>
        /// <param name="org">The org.</param>
        /// <returns><c>true</c> if this instance can write the specified org; otherwise, <c>false</c>.</returns>
        bool CanWrite(Organization org = null);
        /// <summary>
        /// Determines whether this instance can delete the specified org.
        /// </summary>
        /// <param name="org">The org.</param>
        /// <returns><c>true</c> if this instance can delete the specified org; otherwise, <c>false</c>.</returns>
        bool CanDelete(Organization org = null);

        /// <summary>
        /// Registers the newsletter subscriber.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>Guid.</returns>
        Guid RegisterNewsletterSubscriber(string email);
        /// <summary>
        /// Registers the newsletter subscriber asynchronous.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>Task&lt;Guid&gt;.</returns>
        Task<Guid> RegisterNewsletterSubscriberAsync(string email);

        /// <summary>
        /// Unsubscribes the news letter.
        /// </summary>
        /// <param name="subscriberId">The subscriber identifier.</param>
        void UnsubscribeNewsLetter(string subscriberId);
        /// <summary>
        /// Unsubscribes the news letter asynchronous.
        /// </summary>
        /// <param name="subscriberId">The subscriber identifier.</param>
        /// <returns>Task.</returns>
        Task UnsubscribeNewsLetterAsync(string subscriberId);

        /// <summary>
        /// Adds the organization module.
        /// </summary>
        /// <param name="organization">The organization.</param>
        /// <param name="module">The module.</param>
        void AddOrganizationModule(Organization organization, Module module);
        /// <summary>
        /// Adds the organization module asynchronous.
        /// </summary>
        /// <param name="organization">The organization.</param>
        /// <param name="module">The module.</param>
        /// <returns>Task.</returns>
        Task AddOrganizationModuleAsync(Organization organization, Module module);

        /// <summary>
        /// Updates the organization module.
        /// </summary>
        /// <param name="module">The module.</param>
        void UpdateOrganizationModule(OrganizationModule module);
        /// <summary>
        /// Updates the organization module asynchronous.
        /// </summary>
        /// <param name="module">The module.</param>
        /// <returns>Task.</returns>
        Task UpdateOrganizationModuleAsync(OrganizationModule module);

        /// <summary>
        /// Removes the organization module.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void RemoveOrganizationModule(int id);
        /// <summary>
        /// Removes the organization module asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task.</returns>
        Task RemoveOrganizationModuleAsync(int id);
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
    public partial class BusinessLayer : IOrganizationBL
    {
        /// <summary>
        /// Gets all organizations.
        /// </summary>
        /// <returns>IList&lt;Organization&gt;.</returns>
        public IList<Organization> GetAllOrganizations()
        {
            return _unitOfWork.OrganizationRepository.GetAll();
        }

        /// <summary>
        /// get all organizations as an asynchronous operation.
        /// </summary>
        /// <returns>IList&lt;Organization&gt;.</returns>
        public async Task<IList<Organization>> GetAllOrganizationsAsync()
        {
            return await _unitOfWork.OrganizationRepository.GetAllAsync();
        }

        /// <summary>
        /// Searches the organizations.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;Organization&gt;.</returns>
        public IPagedList<Organization> SearchOrganizations(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<Organization>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return _unitOfWork.OrganizationRepository.GetPagedList(page, pageSize, ParseJSONSearchString<Organization>(where), sortExpression);
        }

        /// <summary>
        /// search organizations as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;Organization&gt;.</returns>
        public async Task<IPagedList<Organization>> SearchOrganizationsAsync(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<Organization>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return await _unitOfWork.OrganizationRepository.GetPagedListAsync(page, pageSize, ParseJSONSearchString<Organization>(where), sortExpression);
        }

        /// <summary>
        /// Searches the organizations.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>IList&lt;Organization&gt;.</returns>
        public IList<Organization> SearchOrganizations(string where, string sort)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<Organization>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }
            return _unitOfWork.OrganizationRepository.GetList(ParseJSONSearchString<Organization>(where), sortExpression);
        }

        /// <summary>
        /// search organizations as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>IList&lt;Organization&gt;.</returns>
        public async Task<IList<Organization>> SearchOrganizationsAsync(string where, string sort)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<Organization>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }
            return await _unitOfWork.OrganizationRepository.GetListAsync(ParseJSONSearchString<Organization>(where), sortExpression);
        }

        /// <summary>
        /// Gets the organization by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Organization.</returns>
        public Organization GetOrganizationById(int id)
        {
            return _unitOfWork.OrganizationRepository.GetSingle(c => c.Id == id, c => c.Users, c => c.Subscriptions, c => c.Subscriptions.Select(u => u.User), c => c.OrganizationModules);
        }

        /// <summary>
        /// get organization by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Organization.</returns>
        public async Task<Organization> GetOrganizationByIdAsync(int id)
        {
            return await _unitOfWork.OrganizationRepository.GetSingleAsync(c => c.Id == id, c => c.Users, c => c.Subscriptions, c => c.Subscriptions.Select(u => u.User), c => c.OrganizationModules);
        }

        /// <summary>
        /// Currents the organzation.
        /// </summary>
        /// <returns>Organization.</returns>
        /// <exception cref="NullReferenceException">Configuration helper instance is not provided</exception>
        public Organization CurrentOrganzation()
        {
            if (_configHelper == null)
                throw new NullReferenceException("Configuration helper instance is not provided");
            var currOrgId = _authContext.GetCurrentOrganizationId(_configHelper);
            return _unitOfWork.OrganizationRepository.GetSingle(o => o.Id == currOrgId, o => o.Users, o => o.OrganizationModules);
        }

        /// <summary>
        /// current organzation as an asynchronous operation.
        /// </summary>
        /// <returns>Organization.</returns>
        /// <exception cref="NullReferenceException">Configuration helper instance is not provided</exception>
        public async Task<Organization> CurrentOrganzationAsync()
        {
            if (_configHelper == null)
                throw new NullReferenceException("Configuration helper instance is not provided");
            var currOrgId = _authContext.GetCurrentOrganizationId(_configHelper);
            return await _unitOfWork.OrganizationRepository.GetSingleAsync(o => o.Id == currOrgId, o => o.Users, o => o.OrganizationModules);
        }

        /// <summary>
        /// Adds the organization.
        /// </summary>
        /// <param name="organizations">The organizations.</param>
        public void AddOrganization(params Organization[] organizations)
        {
            _unitOfWork.OrganizationRepository.Add(organizations);
            _unitOfWork.Save();

            foreach (var org in organizations)
            {
                var sql = $"EXEC spCloneLookups @sourceOrgId={org.TenantUnitId}, @targetOrgId={org.Id}, @userId='{org.CreatedBy}'";
                _unitOfWork.OrganizationRepository.ExecSql(sql);
            }
        }

        /// <summary>
        /// add organization as an asynchronous operation.
        /// </summary>
        /// <param name="organizations">The organizations.</param>
        public async Task AddOrganizationAsync(params Organization[] organizations)
        {
            _unitOfWork.OrganizationRepository.Add(organizations);
            await _unitOfWork.SaveAsync();

            foreach (var org in organizations)
            {
                var sql = $"EXEC spCloneLookups @sourceOrgId={org.TenantUnitId}, @targetOrgId={org.Id}, @userId='{org.CreatedBy}'";
                await _unitOfWork.OrganizationRepository.ExecSqlAsync(sql);
            }
        }

        /// <summary>
        /// Update organization method. It works properly under correct authenticated user only.
        /// </summary>
        /// <param name="organizations">The organizations.</param>
        public void UpdateOrganization(params Organization[] organizations)
        {
            var users = new List<OrganizationUser>();
            foreach (var org in organizations)
            {
                if (org.Users != null)
                {
                    foreach (var user in org.Users)
                    {
                        if (user.Id == 0)
                        {
                            user.Organization = org;
                            users.Add(user);
                        }

                    }
                }

            }
            _unitOfWork.OrganizationRepository.Update(organizations);

            if (users.Count > 0)
            {
                _unitOfWork.OrganizationUserRepository.Add(users.ToArray());
            }

            _unitOfWork.Save();
        }

        /// <summary>
        /// update organization as an asynchronous operation.
        /// </summary>
        /// <param name="organizations">The organizations.</param>
        public async Task UpdateOrganizationAsync(params Organization[] organizations)
        {
            var users = new List<OrganizationUser>();
            foreach (var org in organizations)
            {
                if (org.Users != null)
                {
                    foreach (var user in org.Users)
                    {
                        if (user.Id == 0)
                        {
                            user.Organization = org;
                            users.Add(user);
                        }

                    }
                }

            }
            _unitOfWork.OrganizationRepository.Update(organizations);

            if (users.Count > 0)
            {
                _unitOfWork.OrganizationUserRepository.Add(users.ToArray());
            }

            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Removes the organization.
        /// </summary>
        /// <param name="organizations">The organizations.</param>
        public void RemoveOrganization(params Organization[] organizations)
        {
            _unitOfWork.OrganizationRepository.Remove(organizations);
            _unitOfWork.Save();
        }

        /// <summary>
        /// remove organization as an asynchronous operation.
        /// </summary>
        /// <param name="organizations">The organizations.</param>
        public async Task RemoveOrganizationAsync(params Organization[] organizations)
        {
            _unitOfWork.OrganizationRepository.Remove(organizations);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Determines whether this instance can read the specified org.
        /// </summary>
        /// <param name="org">The org.</param>
        /// <returns><c>true</c> if this instance can read the specified org; otherwise, <c>false</c>.</returns>
        public bool CanRead(Organization org = null)
        {
            return _unitOfWork.OrganizationRepository.IsAllowedToRead();
        }

        /// <summary>
        /// Determines whether this instance can write the specified org.
        /// </summary>
        /// <param name="org">The org.</param>
        /// <returns><c>true</c> if this instance can write the specified org; otherwise, <c>false</c>.</returns>
        public bool CanWrite(Organization org = null)
        {
            return _unitOfWork.OrganizationRepository.IsAllowedToWrite(org);
        }

        /// <summary>
        /// Determines whether this instance can delete the specified org.
        /// </summary>
        /// <param name="org">The org.</param>
        /// <returns><c>true</c> if this instance can delete the specified org; otherwise, <c>false</c>.</returns>
        public bool CanDelete(Organization org = null)
        {
            return _unitOfWork.OrganizationRepository.IsAllowedToDelete(org);
        }

        /// <summary>
        /// Registers the newsletter subscriber.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>Guid.</returns>
        public Guid RegisterNewsletterSubscriber(string email)
        {
            var publicId = Guid.NewGuid();
            var subscriber = new Subscriber
            {
                Email = email,
                RegisterDate = DateTime.Now,
                Enabled = true,
                PublicId = publicId
            };

            _unitOfWork.SubscriberRepository.Add(subscriber);
            _unitOfWork.Save();

            return publicId;
        }

        /// <summary>
        /// register newsletter subscriber as an asynchronous operation.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>Guid.</returns>
        public async Task<Guid> RegisterNewsletterSubscriberAsync(string email)
        {
            var publicId = Guid.NewGuid();
            var subscriber = new Subscriber
            {
                Email = email,
                RegisterDate = DateTime.Now,
                Enabled = true,
                PublicId = publicId
            };

            _unitOfWork.SubscriberRepository.Add(subscriber);
            await _unitOfWork.SaveAsync();

            return publicId;
        }

        /// <summary>
        /// Unsubscribes the news letter.
        /// </summary>
        /// <param name="subscriberId">The subscriber identifier.</param>
        public void UnsubscribeNewsLetter(string subscriberId)
        {
            var subscriber = _unitOfWork.SubscriberRepository.GetSingle(a => a.PublicId.ToString() == subscriberId);
            if (subscriber != null)
            {
                _unitOfWork.SubscriberRepository.Remove(subscriber);
                _unitOfWork.Save();
            }
        }

        /// <summary>
        /// unsubscribe news letter as an asynchronous operation.
        /// </summary>
        /// <param name="subscriberId">The subscriber identifier.</param>
        public async Task UnsubscribeNewsLetterAsync(string subscriberId)
        {
            var subscriber = await _unitOfWork.SubscriberRepository.GetSingleAsync(a => a.PublicId.ToString() == subscriberId);
            if (subscriber != null)
            {
                _unitOfWork.SubscriberRepository.Remove(subscriber);
                await _unitOfWork.SaveAsync();
            }
        }

        /// <summary>
        /// Adds the organization module.
        /// </summary>
        /// <param name="organization">The organization.</param>
        /// <param name="module">The module.</param>
        public void AddOrganizationModule(Organization organization, Module module)
        {
            if (organization == null || module == null)
                return;

            if (organization.OrganizationModules == null)
                organization.OrganizationModules = new List<OrganizationModule>();

            if (organization.OrganizationModules.All(a => a.ModuleId != module.Id))
            {
                var organizationModule = new OrganizationModule
                {
                    OrganizationId = organization.Id,
                    ModuleId = module.Id,
                    Name = $"{organization.Name}_{module.Name}"
                };
                _unitOfWork.OrganizationModuleRepository.Add(organizationModule);
                _unitOfWork.Save();
            }
        }

        /// <summary>
        /// add organization module as an asynchronous operation.
        /// </summary>
        /// <param name="organization">The organization.</param>
        /// <param name="module">The module.</param>
        public async Task AddOrganizationModuleAsync(Organization organization, Module module)
        {
            if (organization == null || module == null)
                return;

            if (organization.OrganizationModules == null)
                organization.OrganizationModules = new List<OrganizationModule>();

            if (organization.OrganizationModules.All(a => a.ModuleId != module.Id))
            {
                var organizationModule = new OrganizationModule
                {
                    OrganizationId = organization.Id,
                    ModuleId = module.Id,
                    Name = $"{organization.Name}_{module.Name}"
                };
                _unitOfWork.OrganizationModuleRepository.Add(organizationModule);
                await _unitOfWork.SaveAsync();
            }
        }

        /// <summary>
        /// Updates the organization module.
        /// </summary>
        /// <param name="module">The module.</param>
        public void UpdateOrganizationModule(OrganizationModule module)
        {
            if (module == null)
                return;

            module.Organization = null;
            module.Module = null;
            _unitOfWork.OrganizationModuleRepository.Update(module);
            _unitOfWork.Save();
        }
        /// <summary>
        /// update organization module as an asynchronous operation.
        /// </summary>
        /// <param name="module">The module.</param>
        public async Task UpdateOrganizationModuleAsync(OrganizationModule module)
        {
            if (module == null)
                return;

            module.Organization = null;
            module.Module = null;
            _unitOfWork.OrganizationModuleRepository.Update(module);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Removes the organization module.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void RemoveOrganizationModule(int id)
        {
            if (id == 0)
                return;

            var itemToRemove = _unitOfWork.OrganizationModuleRepository.GetSingle(a => a.Id == id);
            if (itemToRemove != null)
            {
                _unitOfWork.OrganizationModuleRepository.Remove(itemToRemove);
                _unitOfWork.Save();
            }
        }

        /// <summary>
        /// remove organization module as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public async Task RemoveOrganizationModuleAsync(int id)
        {
            if (id == 0)
                return;
            
            var itemToRemove = await _unitOfWork.OrganizationModuleRepository.GetSingleAsync(a => a.Id == id);
            if(itemToRemove != null)
            {
                _unitOfWork.OrganizationModuleRepository.Remove(itemToRemove);
                await _unitOfWork.SaveAsync();
            }            
        }
    }

    /// <summary>
    /// Class OrganizationBL.
    /// Implements the <see cref="BAP.BL.BusinessLayer" />
    /// Implements the <see cref="BAP.Common.ISupportLookup" />
    /// </summary>
    /// <seealso cref="BAP.BL.BusinessLayer" />
    /// <seealso cref="BAP.Common.ISupportLookup" />
    public class OrganizationBL : BusinessLayer, ISupportLookup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrganizationBL"/> class.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        public OrganizationBL(IConfigHelper settings, IAuthorizationContext context, ILogger logger) : base(settings, context, logger)
        {

        }

        #region ISupportLookup

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
            var organizations = SearchOrganizations(extraFilter, orderBy);
            foreach (var organization in organizations)
            {
                var val = organization.GetType().GetProperty(valueField).GetValue(organization, null);
                var text = organization.GetType().GetProperty(textField).GetValue(organization, null);
                var descr = text;
                if (!string.IsNullOrEmpty(descriptionField))
                {
                    descr = organization.GetType().GetProperty(descriptionField).GetValue(organization, null) ?? "";
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
            var organizations = await SearchOrganizationsAsync(extraFilter, orderBy);
            foreach (var organization in organizations)
            {
                var val = organization.GetType().GetProperty(valueField).GetValue(organization, null);
                var text = organization.GetType().GetProperty(textField).GetValue(organization, null);
                var descr = text;
                if (!string.IsNullOrEmpty(descriptionField))
                {
                    descr = organization.GetType().GetProperty(descriptionField).GetValue(organization, null) ?? "";
                }
                result.Add(new LookupItem { Key = val.ToString(), Text = text.ToString(), Description = descr.ToString() });
            }

            return result;
        }

        #endregion
    }
}
