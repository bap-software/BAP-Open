// ***********************************************************************
// Assembly         : BAP.BL
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="LocalizationBL.cs" company="BAP Software Ltd.">
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
    /// Interface ILocalizationBL
    /// </summary>
    public interface ILocalizationBL
    {
        /// <summary>
        /// Gets all localizations.
        /// </summary>
        /// <returns>IList&lt;Localization&gt;.</returns>
        IList<Localization> GetAllLocalizations();
        /// <summary>
        /// Gets all localizations asynchronous.
        /// </summary>
        /// <returns>Task&lt;IList&lt;Localization&gt;&gt;.</returns>
        Task<IList<Localization>> GetAllLocalizationsAsync();

        /// <summary>
        /// Searches the localizations.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;Localization&gt;.</returns>
        IPagedList<Localization> SearchLocalizations(string where, string sort, int page, int pageSize = 20);
        /// <summary>
        /// Searches the localizations asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IPagedList&lt;Localization&gt;&gt;.</returns>
        Task<IPagedList<Localization>> SearchLocalizationsAsync(string where, string sort, int page, int pageSize = 20);

        /// <summary>
        /// Gets the localization by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Localization.</returns>
        Localization GetLocalizationById(int id);
        /// <summary>
        /// Gets the localization by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;Localization&gt;.</returns>
        Task<Localization> GetLocalizationByIdAsync(int id);

        /// <summary>
        /// Adds the localization.
        /// </summary>
        /// <param name="Localizations">The localizations.</param>
        void AddLocalization(params Localization[] Localizations);
        /// <summary>
        /// Adds the localization asynchronous.
        /// </summary>
        /// <param name="Localizations">The localizations.</param>
        /// <returns>Task.</returns>
        Task AddLocalizationAsync(params Localization[] Localizations);

        /// <summary>
        /// Updates the localization.
        /// </summary>
        /// <param name="Localizations">The localizations.</param>
        void UpdateLocalization(params Localization[] Localizations);
        /// <summary>
        /// Updates the localization asynchronous.
        /// </summary>
        /// <param name="Localizations">The localizations.</param>
        /// <returns>Task.</returns>
        Task UpdateLocalizationAsync(params Localization[] Localizations);

        /// <summary>
        /// Removes the localization.
        /// </summary>
        /// <param name="Localizations">The localizations.</param>
        void RemoveLocalization(params Localization[] Localizations);
        /// <summary>
        /// Removes the localization asynchronous.
        /// </summary>
        /// <param name="Localizations">The localizations.</param>
        /// <returns>Task.</returns>
        Task RemoveLocalizationAsync(params Localization[] Localizations);
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
    public partial class BusinessLayer : ILocalizationBL
    {
        #region Localizations
        /// <summary>
        /// Gets all localizations.
        /// </summary>
        /// <returns>IList&lt;Localization&gt;.</returns>
        public IList<Localization> GetAllLocalizations()
        {
            return _unitOfWork.LocalizationRepository.GetAll();
        }

        /// <summary>
        /// get all localizations as an asynchronous operation.
        /// </summary>
        /// <returns>IList&lt;Localization&gt;.</returns>
        public async Task<IList<Localization>> GetAllLocalizationsAsync()
        {
            return await _unitOfWork.LocalizationRepository.GetAllAsync();
        }

        /// <summary>
        /// Searches the localizations.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;Localization&gt;.</returns>
        public IPagedList<Localization> SearchLocalizations(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<Localization>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            return _unitOfWork.LocalizationRepository.GetPagedList(page, pageSize, ParseJSONSearchString<Localization>(where), sortExpression);
        }

        /// <summary>
        /// search localizations as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;Localization&gt;.</returns>
        public async Task<IPagedList<Localization>> SearchLocalizationsAsync(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<Localization>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            return await _unitOfWork.LocalizationRepository.GetPagedListAsync(page, pageSize, ParseJSONSearchString<Localization>(where), sortExpression);
        }

        /// <summary>
        /// Gets the localization by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Localization.</returns>
        public Localization GetLocalizationById(int id)
        {
            return _unitOfWork.LocalizationRepository.GetSingle(a => a.Id == id);
        }

        /// <summary>
        /// get localization by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Localization.</returns>
        public async Task<Localization> GetLocalizationByIdAsync(int id)
        {
            return await _unitOfWork.LocalizationRepository.GetSingleAsync(a => a.Id == id);
        }

        /// <summary>
        /// Adds the localization.
        /// </summary>
        /// <param name="Localizations">The localizations.</param>
        public void AddLocalization(params Localization[] Localizations)
        {
            _unitOfWork.LocalizationRepository.Add(Localizations);
            _unitOfWork.Save();
        }

        /// <summary>
        /// add localization as an asynchronous operation.
        /// </summary>
        /// <param name="Localizations">The localizations.</param>
        public async Task AddLocalizationAsync(params Localization[] Localizations)
        {
            _unitOfWork.LocalizationRepository.Add(Localizations);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Updates the localization.
        /// </summary>
        /// <param name="Localizations">The localizations.</param>
        public void UpdateLocalization(params Localization[] Localizations)
        {
            _unitOfWork.LocalizationRepository.Update(Localizations);
            _unitOfWork.Save();
        }

        /// <summary>
        /// update localization as an asynchronous operation.
        /// </summary>
        /// <param name="Localizations">The localizations.</param>
        public async Task UpdateLocalizationAsync(params Localization[] Localizations)
        {
            _unitOfWork.LocalizationRepository.Update(Localizations);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Removes the localization.
        /// </summary>
        /// <param name="Localizations">The localizations.</param>
        public void RemoveLocalization(params Localization[] Localizations)
        {
            _unitOfWork.LocalizationRepository.Remove(Localizations);
            _unitOfWork.Save();
        }

        /// <summary>
        /// remove localization as an asynchronous operation.
        /// </summary>
        /// <param name="Localizations">The localizations.</param>
        public async Task RemoveLocalizationAsync(params Localization[] Localizations)
        {
            _unitOfWork.LocalizationRepository.Remove(Localizations);
            await _unitOfWork.SaveAsync();
        }
        
        #endregion
    }
}
