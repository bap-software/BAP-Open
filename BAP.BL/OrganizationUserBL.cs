// ***********************************************************************
// Assembly         : BAP.BL
// Author           : Victor Mamray
// Created          : 05-24-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="OrganizationUserBL.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;

using PagedList;

using BAP.Common;
using BAP.DAL.Entities;
using BAP.DAL;
using BAP.Log;
using System.Web;
using BAP.BL.AspNetIdentity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace BAP.BL
{
    /// <summary>
    /// Interface IOrganizationUserBL
    /// </summary>
    public interface IOrganizationUserBL
    {
        /// <summary>
        /// Gets all organization users.
        /// </summary>
        /// <returns>IList&lt;OrganizationUser&gt;.</returns>
        IList<OrganizationUser> GetAllOrganizationUsers();
        /// <summary>
        /// Gets all organization users asynchronous.
        /// </summary>
        /// <returns>Task&lt;IList&lt;OrganizationUser&gt;&gt;.</returns>
        Task<IList<OrganizationUser>> GetAllOrganizationUsersAsync();

        /// <summary>
        /// Searches the organization users.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;OrganizationUser&gt;.</returns>
        IPagedList<OrganizationUser> SearchOrganizationUsers(string where, string sort, int page, int pageSize = 20);
        /// <summary>
        /// Searches the organization users asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IPagedList&lt;OrganizationUser&gt;&gt;.</returns>
        Task<IPagedList<OrganizationUser>> SearchOrganizationUsersAsync(string where, string sort, int page, int pageSize = 20);

        /// <summary>
        /// Searches the organization users.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>IList&lt;OrganizationUser&gt;.</returns>
        IList<OrganizationUser> SearchOrganizationUsers(string where, string sort);
        /// <summary>
        /// Searches the organization users asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>Task&lt;IList&lt;OrganizationUser&gt;&gt;.</returns>
        Task<IList<OrganizationUser>> SearchOrganizationUsersAsync(string where, string sort);

        /// <summary>
        /// Lists the built in org users.
        /// </summary>
        /// <returns>IList&lt;OrganizationUser&gt;.</returns>
        IList<OrganizationUser> ListBuiltInOrgUsers();
        /// <summary>
        /// Lists the built in org users asynchronous.
        /// </summary>
        /// <returns>Task&lt;IList&lt;OrganizationUser&gt;&gt;.</returns>
        Task<IList<OrganizationUser>> ListBuiltInOrgUsersAsync();

        /// <summary>
        /// Gets the organization user by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>OrganizationUser.</returns>
        OrganizationUser GetOrganizationUserById(int id);
        /// <summary>
        /// Gets the organization user by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;OrganizationUser&gt;.</returns>
        Task<OrganizationUser> GetOrganizationUserByIdAsync(int id);

        /// <summary>
        /// Gets the organization user by ASP net identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>OrganizationUser.</returns>
        OrganizationUser GetOrganizationUserByAspNetId(string id);
        /// <summary>
        /// Gets the organization user by ASP net identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;OrganizationUser&gt;.</returns>
        Task<OrganizationUser> GetOrganizationUserByAspNetIdAsync(string id);

        /// <summary>
        /// Adds the organization user.
        /// </summary>
        /// <param name="organizationUsers">The organization users.</param>
        void AddOrganizationUser(params OrganizationUser[] organizationUsers);
        /// <summary>
        /// Adds the organization user asynchronous.
        /// </summary>
        /// <param name="organizationUsers">The organization users.</param>
        /// <returns>Task.</returns>
        Task AddOrganizationUserAsync(params OrganizationUser[] organizationUsers);

        /// <summary>
        /// Updates the organization user.
        /// </summary>
        /// <param name="organizationUsers">The organization users.</param>
        void UpdateOrganizationUser(params OrganizationUser[] organizationUsers);
        /// <summary>
        /// Updates the organization user asynchronous.
        /// </summary>
        /// <param name="organizationUsers">The organization users.</param>
        /// <returns>Task.</returns>
        Task UpdateOrganizationUserAsync(params OrganizationUser[] organizationUsers);

        /// <summary>
        /// Removes the organization user.
        /// </summary>
        /// <param name="organizationUsers">The organization users.</param>
        void RemoveOrganizationUser(params OrganizationUser[] organizationUsers);
        /// <summary>
        /// Removes the organization user asynchronous.
        /// </summary>
        /// <param name="organizationUsers">The organization users.</param>
        /// <returns>Task.</returns>
        Task RemoveOrganizationUserAsync(params OrganizationUser[] organizationUsers);

        /// <summary>
        /// Determines whether this instance can read the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns><c>true</c> if this instance can read the specified user; otherwise, <c>false</c>.</returns>
        bool CanRead(OrganizationUser user = null);
        /// <summary>
        /// Determines whether this instance can write the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns><c>true</c> if this instance can write the specified user; otherwise, <c>false</c>.</returns>
        bool CanWrite(OrganizationUser user = null);
        /// <summary>
        /// Determines whether this instance can delete the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns><c>true</c> if this instance can delete the specified user; otherwise, <c>false</c>.</returns>
        bool CanDelete(OrganizationUser user = null);
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
    public partial class BusinessLayer : IOrganizationUserBL
    {
        /// <summary>
        /// Gets all organization users.
        /// </summary>
        /// <returns>IList&lt;OrganizationUser&gt;.</returns>
        public IList<OrganizationUser> GetAllOrganizationUsers()
        {
            return _unitOfWork.OrganizationUserRepository.GetAll();
        }

        /// <summary>
        /// get all organization users as an asynchronous operation.
        /// </summary>
        /// <returns>IList&lt;OrganizationUser&gt;.</returns>
        public async Task<IList<OrganizationUser>> GetAllOrganizationUsersAsync()
        {
            return await _unitOfWork.OrganizationUserRepository.GetAllAsync();
        }

        /// <summary>
        /// Searches the organization users.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;OrganizationUser&gt;.</returns>
        public IPagedList<OrganizationUser> SearchOrganizationUsers(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<OrganizationUser>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return _unitOfWork.OrganizationUserRepository.GetPagedList(page, pageSize, ParseJSONSearchString<OrganizationUser>(where), sortExpression);
        }

        /// <summary>
        /// search organization users as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;OrganizationUser&gt;.</returns>
        public async Task<IPagedList<OrganizationUser>> SearchOrganizationUsersAsync(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<OrganizationUser>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return await _unitOfWork.OrganizationUserRepository.GetPagedListAsync(page, pageSize, ParseJSONSearchString<OrganizationUser>(where), sortExpression);
        }

        /// <summary>
        /// Gets the organization user by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>OrganizationUser.</returns>
        public OrganizationUser GetOrganizationUserById(int id)
        {
            return _unitOfWork.OrganizationUserRepository.GetSingle(c => c.Id == id);
        }

        /// <summary>
        /// get organization user by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>OrganizationUser.</returns>
        public async Task<OrganizationUser> GetOrganizationUserByIdAsync(int id)
        {
            return await _unitOfWork.OrganizationUserRepository.GetSingleAsync(c => c.Id == id);
        }

        /// <summary>
        /// Searches the organization users.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>IList&lt;OrganizationUser&gt;.</returns>
        public IList<OrganizationUser> SearchOrganizationUsers(string where, string sort)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<OrganizationUser>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }
            return _unitOfWork.OrganizationUserRepository.GetList(ParseJSONSearchString<OrganizationUser>(where), sortExpression);
        }

        /// <summary>
        /// search organization users as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>IList&lt;OrganizationUser&gt;.</returns>
        public async Task<IList<OrganizationUser>> SearchOrganizationUsersAsync(string where, string sort)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<OrganizationUser>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }
            return await _unitOfWork.OrganizationUserRepository.GetListAsync(ParseJSONSearchString<OrganizationUser>(where), sortExpression);
        }

        /// <summary>
        /// Lists the built in org users.
        /// </summary>
        /// <returns>IList&lt;OrganizationUser&gt;.</returns>
        public IList<OrganizationUser> ListBuiltInOrgUsers()
        {
            return _unitOfWork.OrganizationUserRepository.GetList(a => a.IsBuiltIn);
        }

        /// <summary>
        /// list built in org users as an asynchronous operation.
        /// </summary>
        /// <returns>IList&lt;OrganizationUser&gt;.</returns>
        public async Task<IList<OrganizationUser>> ListBuiltInOrgUsersAsync()
        {
            return await _unitOfWork.OrganizationUserRepository.GetListAsync(a => a.IsBuiltIn);
        }

        /// <summary>
        /// Gets the organization user by ASP net identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>OrganizationUser.</returns>
        public OrganizationUser GetOrganizationUserByAspNetId(string id)
        {
            return _unitOfWork.OrganizationUserRepository.GetSingle(c => c.AspNetUserId == id, i => i.Organization);
        }

        /// <summary>
        /// get organization user by ASP net identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>OrganizationUser.</returns>
        public async Task<OrganizationUser> GetOrganizationUserByAspNetIdAsync(string id)
        {
            return await _unitOfWork.OrganizationUserRepository.GetSingleAsync(c => c.AspNetUserId == id, i => i.Organization);
        }

        /// <summary>
        /// Adds the organization user.
        /// </summary>
        /// <param name="organizationUsers">The organization users.</param>
        public void AddOrganizationUser(params OrganizationUser[] organizationUsers)
        {
            foreach (var user in organizationUsers)
            {
                if (user.Organization != null)
                {
                    _unitOfWork.OrganizationRepository.AttachIfDetached(user.Organization);
                    if (string.IsNullOrEmpty(user.TenantUnit) || user.TenantUnitId < 1)
                    {
                        user.TenantUnit = "Organization";
                        user.TenantUnitId = user.Organization.Id;
                    }
                }
            }
            _unitOfWork.OrganizationUserRepository.Add(organizationUsers);
            _unitOfWork.Save();
        }

        /// <summary>
        /// add organization user as an asynchronous operation.
        /// </summary>
        /// <param name="organizationUsers">The organization users.</param>
        public async Task AddOrganizationUserAsync(params OrganizationUser[] organizationUsers)
        {
            foreach (var user in organizationUsers)
            {
                if (user.Organization != null)
                {
                    _unitOfWork.OrganizationRepository.AttachIfDetached(user.Organization);
                    if (string.IsNullOrEmpty(user.TenantUnit) || user.TenantUnitId < 1)
                    {
                        user.TenantUnit = "Organization";
                        user.TenantUnitId = user.Organization.Id;
                    }
                }
            }
            _unitOfWork.OrganizationUserRepository.Add(organizationUsers);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Updates the organization user.
        /// </summary>
        /// <param name="organizationUsers">The organization users.</param>
        public void UpdateOrganizationUser(params OrganizationUser[] organizationUsers)
        {
            foreach (var user in organizationUsers)
            {
                if (user.Organization != null)
                {
                    _unitOfWork.OrganizationRepository.AttachIfDetached(user.Organization);
                    if (string.IsNullOrEmpty(user.TenantUnit) || user.TenantUnitId < 1)
                    {
                        user.TenantUnit = "Organization";
                        user.TenantUnitId = user.Organization.Id;
                    }
                }
            }
            _unitOfWork.OrganizationUserRepository.Update(organizationUsers);
            _unitOfWork.Save();
        }

        /// <summary>
        /// update organization user as an asynchronous operation.
        /// </summary>
        /// <param name="organizationUsers">The organization users.</param>
        public async Task UpdateOrganizationUserAsync(params OrganizationUser[] organizationUsers)
        {
            foreach (var user in organizationUsers)
            {
                if (user.Organization != null)
                {
                    _unitOfWork.OrganizationRepository.AttachIfDetached(user.Organization);
                    if (string.IsNullOrEmpty(user.TenantUnit) || user.TenantUnitId < 1)
                    {
                        user.TenantUnit = "Organization";
                        user.TenantUnitId = user.Organization.Id;
                    }
                }
            }
            _unitOfWork.OrganizationUserRepository.Update(organizationUsers);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Removes the organization user.
        /// </summary>
        /// <param name="organizationUsers">The organization users.</param>
        public void RemoveOrganizationUser(params OrganizationUser[] organizationUsers)
        {
            foreach (var user in organizationUsers)
            {
                _unitOfWork.OrganizationUserRepository.AttachIfDetached(user);
                var subscriptionBL = (ISubscriptionBL)this;
                var subscription = subscriptionBL.GetSubscriptionByUserId(user.Id);
                if (subscription != null)
                {
                    subscription.User = user;
                    _unitOfWork.SubscriptionRepository.Remove(subscription);
                }

            }

            _unitOfWork.OrganizationUserRepository.Remove(organizationUsers);
            _unitOfWork.Save();
        }

        /// <summary>
        /// remove organization user as an asynchronous operation.
        /// </summary>
        /// <param name="organizationUsers">The organization users.</param>
        public async Task RemoveOrganizationUserAsync(params OrganizationUser[] organizationUsers)
        {
            foreach (var user in organizationUsers)
            {
                _unitOfWork.OrganizationUserRepository.AttachIfDetached(user);
                var subscriptionBL = (ISubscriptionBL)this;
                var subscription = subscriptionBL.GetSubscriptionByUserId(user.Id);
                if (subscription != null)
                {
                    subscription.User = user;
                    _unitOfWork.SubscriptionRepository.Remove(subscription);
                }

            }

            _unitOfWork.OrganizationUserRepository.Remove(organizationUsers);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Determines whether this instance can read the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns><c>true</c> if this instance can read the specified user; otherwise, <c>false</c>.</returns>
        public bool CanRead(OrganizationUser user = null)
        {
            return _unitOfWork.OrganizationUserRepository.IsAllowedToRead();
        }

        /// <summary>
        /// Determines whether this instance can write the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns><c>true</c> if this instance can write the specified user; otherwise, <c>false</c>.</returns>
        public bool CanWrite(OrganizationUser user = null)
        {
            return _unitOfWork.OrganizationUserRepository.IsAllowedToWrite(user);
        }

        /// <summary>
        /// Determines whether this instance can delete the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns><c>true</c> if this instance can delete the specified user; otherwise, <c>false</c>.</returns>
        public bool CanDelete(OrganizationUser user = null)
        {
            return _unitOfWork.OrganizationUserRepository.IsAllowedToDelete(user);
        }
    }

    /// <summary>
    /// Class OrganizationUserBL.
    /// Implements the <see cref="BAP.BL.BusinessLayer" />
    /// Implements the <see cref="BAP.Common.ISupportLookup" />
    /// </summary>
    /// <seealso cref="BAP.BL.BusinessLayer" />
    /// <seealso cref="BAP.Common.ISupportLookup" />
    public class OrganizationUserBL : BusinessLayer, ISupportLookup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrganizationUserBL"/> class.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        public OrganizationUserBL(IConfigHelper settings, IAuthorizationContext context, ILogger logger) : base(settings, context, logger)
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
        /// <returns>IList&lt;LookupItem&gt;.</returns>
        public IList<LookupItem> GetLookupItems(string valueField, string textField, string descriptionField, string extraFilter, string orderBy)
        {
            List<LookupItem> result = new List<LookupItem>();
            var organizationUsers = SearchOrganizationUsers(extraFilter, orderBy);
            foreach (var organizationUser in organizationUsers)
            {
                var val = organizationUser.GetType().GetProperty(valueField).GetValue(organizationUser, null);
                var text = organizationUser.GetType().GetProperty(textField).GetValue(organizationUser, null);
                if (text == null)
                    text = "";
                var descr = text;
                if (!string.IsNullOrEmpty(descriptionField))
                {
                    descr = organizationUser.GetType().GetProperty(descriptionField).GetValue(organizationUser, null);
                    if (descr == null)
                        descr = "";
                }
                result.Add(new LookupItem { Key = val.ToString(), Text = text.ToString(), Description = descr.ToString() });
            }

            return result;
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
            var organizationUsers = SearchOrganizationUsers(extraFilter, orderBy);
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            foreach (var organizationUser in organizationUsers)
            {
                if (roles != null)
                {
                    var rls = userManager.GetRoles(organizationUser.AspNetUserId);
                    if (!rls.Intersect(roles).Any())
                        continue;
                }
                var val = organizationUser.GetType().GetProperty(valueField).GetValue(organizationUser, null);
                var text = organizationUser.GetType().GetProperty(textField).GetValue(organizationUser, null) ?? "";
                var descr = text;
                if (!string.IsNullOrEmpty(descriptionField))
                {
                    descr = organizationUser.GetType().GetProperty(descriptionField).GetValue(organizationUser, null) ??
                            "";
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
            var organizationUsers = await SearchOrganizationUsersAsync(extraFilter, orderBy);
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            foreach (var organizationUser in organizationUsers)
            {
                if (roles != null)
                {
                    var rls = userManager.GetRoles(organizationUser.AspNetUserId);
                    if (!rls.Intersect(roles).Any())
                        continue;
                }
                var val = organizationUser.GetType().GetProperty(valueField).GetValue(organizationUser, null);
                var text = organizationUser.GetType().GetProperty(textField).GetValue(organizationUser, null) ?? "";
                var descr = text;
                if (!string.IsNullOrEmpty(descriptionField))
                {
                    descr = organizationUser.GetType().GetProperty(descriptionField).GetValue(organizationUser, null) ??
                            "";
                }
                result.Add(new LookupItem { Key = val.ToString(), Text = text.ToString(), Description = descr.ToString() });
            }

            return result;
        }

        #endregion
    }
}
