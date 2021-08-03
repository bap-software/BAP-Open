// ***********************************************************************
// Assembly         : BAP.BL
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="OrganizationServiceBL.cs" company="BAP Software Ltd.">
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
    /// Interface IOrganizationServiceBL
    /// </summary>
    public interface IOrganizationServiceBL
    {
        /// <summary>
        /// Gets all organization services.
        /// </summary>
        /// <returns>IList&lt;OrganizationService&gt;.</returns>
        IList<OrganizationService> GetAllOrganizationServices();
        /// <summary>
        /// Gets all organization services asynchronous.
        /// </summary>
        /// <returns>Task&lt;IList&lt;OrganizationService&gt;&gt;.</returns>
        Task<IList<OrganizationService>> GetAllOrganizationServicesAsync();

        /// <summary>
        /// Searches the organization services.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;OrganizationService&gt;.</returns>
        IPagedList<OrganizationService> SearchOrganizationServices(string where, string sort, int page, int pageSize = 20);
        /// <summary>
        /// Searches the organization services asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IPagedList&lt;OrganizationService&gt;&gt;.</returns>
        Task<IPagedList<OrganizationService>> SearchOrganizationServicesAsync(string where, string sort, int page, int pageSize = 20);

        /// <summary>
        /// Gets the organization service by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>OrganizationService.</returns>
        OrganizationService GetOrganizationServiceById(int id);
        /// <summary>
        /// Gets the organization service by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;OrganizationService&gt;.</returns>
        Task<OrganizationService> GetOrganizationServiceByIdAsync(int id);

        /// <summary>
        /// Adds the organization service.
        /// </summary>
        /// <param name="organizationServices">The organization services.</param>
        void AddOrganizationService(params OrganizationService[] organizationServices);
        /// <summary>
        /// Adds the organization service asynchronous.
        /// </summary>
        /// <param name="organizationServices">The organization services.</param>
        /// <returns>Task.</returns>
        Task AddOrganizationServiceAsync(params OrganizationService[] organizationServices);

        /// <summary>
        /// Updates the organization service.
        /// </summary>
        /// <param name="organizationServices">The organization services.</param>
        void UpdateOrganizationService(params OrganizationService[] organizationServices);
        /// <summary>
        /// Updates the organization service asynchronous.
        /// </summary>
        /// <param name="organizationServices">The organization services.</param>
        /// <returns>Task.</returns>
        Task UpdateOrganizationServiceAsync(params OrganizationService[] organizationServices);

        /// <summary>
        /// Removes the organization service.
        /// </summary>
        /// <param name="organizationServices">The organization services.</param>
        void RemoveOrganizationService(params OrganizationService[] organizationServices);
        /// <summary>
        /// Removes the organization service asynchronous.
        /// </summary>
        /// <param name="organizationServices">The organization services.</param>
        /// <returns>Task.</returns>
        Task RemoveOrganizationServiceAsync(params OrganizationService[] organizationServices);
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
    public partial class BusinessLayer : IOrganizationServiceBL, ILocalizedBL<OrganizationService>
    {
        #region organizationServices
        /// <summary>
        /// Gets all organization services.
        /// </summary>
        /// <returns>IList&lt;OrganizationService&gt;.</returns>
        public IList<OrganizationService> GetAllOrganizationServices()
        {
            return _unitOfWork.OrganizationServiceRepository.GetAll();
        }

        /// <summary>
        /// get all organization services as an asynchronous operation.
        /// </summary>
        /// <returns>IList&lt;OrganizationService&gt;.</returns>
        public async Task<IList<OrganizationService>> GetAllOrganizationServicesAsync()
        {
            return await _unitOfWork.OrganizationServiceRepository.GetAllAsync();
        }

        /// <summary>
        /// Searches the organization services.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;OrganizationService&gt;.</returns>
        public IPagedList<OrganizationService> SearchOrganizationServices(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<OrganizationService>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            return _unitOfWork.OrganizationServiceRepository.GetPagedList(page, pageSize, ParseJSONSearchString<OrganizationService>(where), sortExpression);
        }

        /// <summary>
        /// search organization services as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;OrganizationService&gt;.</returns>
        public async Task<IPagedList<OrganizationService>> SearchOrganizationServicesAsync(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<OrganizationService>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            return await _unitOfWork.OrganizationServiceRepository.GetPagedListAsync(page, pageSize, ParseJSONSearchString<OrganizationService>(where), sortExpression);
        }

        /// <summary>
        /// Gets the organization service by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>OrganizationService.</returns>
        public OrganizationService GetOrganizationServiceById(int id)
        {
            return _unitOfWork.OrganizationServiceRepository.GetSingle(a => a.Id == id);
        }

        /// <summary>
        /// get organization service by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>OrganizationService.</returns>
        public async Task<OrganizationService> GetOrganizationServiceByIdAsync(int id)
        {
            return await _unitOfWork.OrganizationServiceRepository.GetSingleAsync(a => a.Id == id);
        }

        /// <summary>
        /// Adds the organization service.
        /// </summary>
        /// <param name="organizationServices">The organization services.</param>
        public void AddOrganizationService(params OrganizationService[] organizationServices)
        {
            _unitOfWork.OrganizationServiceRepository.Add(organizationServices);
            _unitOfWork.Save();
        }

        /// <summary>
        /// add organization service as an asynchronous operation.
        /// </summary>
        /// <param name="organizationServices">The organization services.</param>
        public async Task AddOrganizationServiceAsync(params OrganizationService[] organizationServices)
        {
            _unitOfWork.OrganizationServiceRepository.Add(organizationServices);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Updates the organization service.
        /// </summary>
        /// <param name="organizationServices">The organization services.</param>
        public void UpdateOrganizationService(params OrganizationService[] organizationServices)
        {
            _unitOfWork.OrganizationServiceRepository.Update(organizationServices);
            _unitOfWork.Save();
        }

        /// <summary>
        /// update organization service as an asynchronous operation.
        /// </summary>
        /// <param name="organizationServices">The organization services.</param>
        public async Task UpdateOrganizationServiceAsync(params OrganizationService[] organizationServices)
        {
            _unitOfWork.OrganizationServiceRepository.Update(organizationServices);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Removes the organization service.
        /// </summary>
        /// <param name="organizationServices">The organization services.</param>
        public void RemoveOrganizationService(params OrganizationService[] organizationServices)
        {
            _unitOfWork.OrganizationServiceRepository.Remove(organizationServices);
            _unitOfWork.Save();
        }

        /// <summary>
        /// remove organization service as an asynchronous operation.
        /// </summary>
        /// <param name="organizationServices">The organization services.</param>
        public async Task RemoveOrganizationServiceAsync(params OrganizationService[] organizationServices)
        {
            _unitOfWork.OrganizationServiceRepository.Remove(organizationServices);
            await _unitOfWork.SaveAsync();
        }

        #region ILocalizedBL
        /// <summary>
        /// Get full details of the single entity
        /// </summary>
        /// <param name="ofEntity">Passed entity is used as filter, method implementing ths feature should treat this oject apropriatly to call some method of BL class to read full details.</param>
        /// <returns>Entity instance</returns>
        public OrganizationService GetDetails(OrganizationService ofEntity)
        {
            if (ofEntity == null)
                return null;

            if (ofEntity.Id > 0)
                return GetOrganizationServiceById(ofEntity.Id);
            
            return null;
        }

        /// <summary>
        /// Adds the single entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void AddSingleEntity(OrganizationService entity)
        {
            _unitOfWork.OrganizationServiceRepository.Add(entity);
            _unitOfWork.Save();
        }
        #endregion

        #endregion
    }
}
