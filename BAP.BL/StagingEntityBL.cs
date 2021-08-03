// ***********************************************************************
// Assembly         : BAP.BL
// Author           : Victor Mamray
// Created          : 07-26-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 07-26-2020
// ***********************************************************************
// <copyright file="StagingEntityBL.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;

using PagedList;

using BAP.Common;
using BAP.DAL.Entities;
using System.Threading.Tasks;

namespace BAP.BL
{
    /// <summary>
    /// Interface IStagingEntityBL
    /// </summary>
    public interface IStagingEntityBL
    {
        /// <summary>
        /// Gets all staging entitys.
        /// </summary>
        /// <returns>IList&lt;StagingEntity&gt;.</returns>
        IList<StagingEntity> GetAllStagingEntitys();
        /// <summary>
        /// Gets all staging entitys asynchronous.
        /// </summary>
        /// <returns>Task&lt;IList&lt;StagingEntity&gt;&gt;.</returns>
        Task<IList<StagingEntity>> GetAllStagingEntitysAsync();

        /// <summary>
        /// Searches the staging entitys.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;StagingEntity&gt;.</returns>
        IPagedList<StagingEntity> SearchStagingEntitys(string where, string sort, int page, int pageSize = 20);
        /// <summary>
        /// Searches the staging entitys asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IPagedList&lt;StagingEntity&gt;&gt;.</returns>
        Task<IPagedList<StagingEntity>> SearchStagingEntitysAsync(string where, string sort, int page, int pageSize = 20);

        /// <summary>
        /// Gets the staging entity by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>StagingEntity.</returns>
        StagingEntity GetStagingEntityById(int id);
        /// <summary>
        /// Gets the staging entity by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;StagingEntity&gt;.</returns>
        Task<StagingEntity> GetStagingEntityByIdAsync(int id);

        /// <summary>
        /// Adds the staging entity.
        /// </summary>
        /// <param name="StagingEntitys">The staging entitys.</param>
        void AddStagingEntity(params StagingEntity[] StagingEntitys);
        /// <summary>
        /// Adds the staging entity asynchronous.
        /// </summary>
        /// <param name="StagingEntitys">The staging entitys.</param>
        /// <returns>Task.</returns>
        Task AddStagingEntityAsync(params StagingEntity[] StagingEntitys);

        /// <summary>
        /// Updates the staging entity.
        /// </summary>
        /// <param name="StagingEntitys">The staging entitys.</param>
        void UpdateStagingEntity(params StagingEntity[] StagingEntitys);
        /// <summary>
        /// Updates the staging entity asynchronous.
        /// </summary>
        /// <param name="StagingEntitys">The staging entitys.</param>
        /// <returns>Task.</returns>
        Task UpdateStagingEntityAsync(params StagingEntity[] StagingEntitys);

        /// <summary>
        /// Removes the staging entity.
        /// </summary>
        /// <param name="StagingEntitys">The staging entitys.</param>
        void RemoveStagingEntity(params StagingEntity[] StagingEntitys);
        /// <summary>
        /// Removes the staging entity asynchronous.
        /// </summary>
        /// <param name="StagingEntitys">The staging entitys.</param>
        /// <returns>Task.</returns>
        Task RemoveStagingEntityAsync(params StagingEntity[] StagingEntitys);
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
    public partial class BusinessLayer : IStagingEntityBL
    {
        #region StagingEntitys

        /// <summary>
        /// Gets all staging entitys.
        /// </summary>
        /// <returns>IList&lt;StagingEntity&gt;.</returns>
        public IList<StagingEntity> GetAllStagingEntitys()
        {
            return _unitOfWork.StagingEntityRepository.GetAll();
        }

        /// <summary>
        /// get all staging entitys as an asynchronous operation.
        /// </summary>
        /// <returns>IList&lt;StagingEntity&gt;.</returns>
        public async Task<IList<StagingEntity>> GetAllStagingEntitysAsync()
        {
            return await _unitOfWork.StagingEntityRepository.GetAllAsync();
        }

        /// <summary>
        /// Searches the staging entitys.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;StagingEntity&gt;.</returns>
        public IPagedList<StagingEntity> SearchStagingEntitys(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<StagingEntity>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            return _unitOfWork.StagingEntityRepository.GetPagedList(page, pageSize, ParseJSONSearchString<StagingEntity>(where), sortExpression);
        }

        /// <summary>
        /// search staging entitys as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;StagingEntity&gt;.</returns>
        public async Task<IPagedList<StagingEntity>> SearchStagingEntitysAsync(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<StagingEntity>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            return await _unitOfWork.StagingEntityRepository.GetPagedListAsync(page, pageSize, ParseJSONSearchString<StagingEntity>(where), sortExpression);
        }

        /// <summary>
        /// Gets the staging entity by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>StagingEntity.</returns>
        public StagingEntity GetStagingEntityById(int id)
        {
            return _unitOfWork.StagingEntityRepository.GetSingle(a => a.Id == id);
        }

        /// <summary>
        /// get staging entity by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>StagingEntity.</returns>
        public async Task<StagingEntity> GetStagingEntityByIdAsync(int id)
        {
            return await _unitOfWork.StagingEntityRepository.GetSingleAsync(a => a.Id == id);
        }

        /// <summary>
        /// Adds the staging entity.
        /// </summary>
        /// <param name="StagingEntitys">The staging entitys.</param>
        public void AddStagingEntity(params StagingEntity[] StagingEntitys)
        {            
            _unitOfWork.StagingEntityRepository.Add(StagingEntitys);
            _unitOfWork.Save();
        }

        /// <summary>
        /// add staging entity as an asynchronous operation.
        /// </summary>
        /// <param name="StagingEntitys">The staging entitys.</param>
        public async Task AddStagingEntityAsync(params StagingEntity[] StagingEntitys)
        {            
            _unitOfWork.StagingEntityRepository.Add(StagingEntitys);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Updates the staging entity.
        /// </summary>
        /// <param name="StagingEntitys">The staging entitys.</param>
        public void UpdateStagingEntity(params StagingEntity[] StagingEntitys)
        {
            _unitOfWork.StagingEntityRepository.Update(StagingEntitys);
            _unitOfWork.Save();
        }

        /// <summary>
        /// update staging entity as an asynchronous operation.
        /// </summary>
        /// <param name="StagingEntitys">The staging entitys.</param>
        public async Task UpdateStagingEntityAsync(params StagingEntity[] StagingEntitys)
        {
            _unitOfWork.StagingEntityRepository.Update(StagingEntitys);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Removes the staging entity.
        /// </summary>
        /// <param name="StagingEntitys">The staging entitys.</param>
        public void RemoveStagingEntity(params StagingEntity[] StagingEntitys)
        {
            _unitOfWork.StagingEntityRepository.Remove(StagingEntitys);
            _unitOfWork.Save();
        }

        /// <summary>
        /// remove staging entity as an asynchronous operation.
        /// </summary>
        /// <param name="StagingEntitys">The staging entitys.</param>
        public async Task RemoveStagingEntityAsync(params StagingEntity[] StagingEntitys)
        {
            _unitOfWork.StagingEntityRepository.Remove(StagingEntitys);
            await _unitOfWork.SaveAsync();
        }

        #endregion
    }
}