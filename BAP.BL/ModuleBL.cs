// ***********************************************************************
// Assembly         : BAP.BL
// Author           : Victor Mamray
// Created          : 05-20-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="ModuleBL.cs" company="BAP Software Ltd.">
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
    /// Interface IModuleBL
    /// </summary>
    public interface IModuleBL
    {
        /// <summary>
        /// Gets all modules.
        /// </summary>
        /// <returns>IList&lt;Module&gt;.</returns>
        IList<Module> GetAllModules();
        /// <summary>
        /// Gets all modules asynchronous.
        /// </summary>
        /// <returns>Task&lt;IList&lt;Module&gt;&gt;.</returns>
        Task<IList<Module>> GetAllModulesAsync();

        /// <summary>
        /// Searches the modules.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;Module&gt;.</returns>
        IPagedList<Module> SearchModules(string where, string sort, int page, int pageSize = 20);
        /// <summary>
        /// Searches the modules asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IPagedList&lt;Module&gt;&gt;.</returns>
        Task<IPagedList<Module>> SearchModulesAsync(string where, string sort, int page, int pageSize = 20);

        /// <summary>
        /// Gets the module by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Module.</returns>
        Module GetModuleById(int id);
        /// <summary>
        /// Gets the module by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;Module&gt;.</returns>
        Task<Module> GetModuleByIdAsync(int id);

        /// <summary>
        /// Adds the module.
        /// </summary>
        /// <param name="modules">The modules.</param>
        void AddModule(params Module[] modules);
        /// <summary>
        /// Adds the module asynchronous.
        /// </summary>
        /// <param name="modules">The modules.</param>
        /// <returns>Task.</returns>
        Task AddModuleAsync(params Module[] modules);

        /// <summary>
        /// Updates the module.
        /// </summary>
        /// <param name="modules">The modules.</param>
        void UpdateModule(params Module[] modules);
        /// <summary>
        /// Updates the module asynchronous.
        /// </summary>
        /// <param name="modules">The modules.</param>
        /// <returns>Task.</returns>
        Task UpdateModuleAsync(params Module[] modules);

        /// <summary>
        /// Removes the module.
        /// </summary>
        /// <param name="modules">The modules.</param>
        void RemoveModule(params Module[] modules);
        /// <summary>
        /// Removes the module asynchronous.
        /// </summary>
        /// <param name="modules">The modules.</param>
        /// <returns>Task.</returns>
        Task RemoveModuleAsync(params Module[] modules);
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
    public partial class BusinessLayer : IModuleBL
    {

        /// <summary>
        /// Gets all modules.
        /// </summary>
        /// <returns>IList&lt;Module&gt;.</returns>
        public IList<Module> GetAllModules()
        {
            return _unitOfWork.ModuleRepository.GetAll();
        }

        /// <summary>
        /// get all modules as an asynchronous operation.
        /// </summary>
        /// <returns>IList&lt;Module&gt;.</returns>
        public async Task<IList<Module>> GetAllModulesAsync()
        {
            return await _unitOfWork.ModuleRepository.GetAllAsync();
        }

        /// <summary>
        /// Searches the modules.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;Module&gt;.</returns>
        public IPagedList<Module> SearchModules(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<Module>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            return _unitOfWork.ModuleRepository.GetPagedList(page, pageSize, ParseJSONSearchString<Module>(where), sortExpression);
        }

        /// <summary>
        /// search modules as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;Module&gt;.</returns>
        public async Task<IPagedList<Module>> SearchModulesAsync(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<Module>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            return await _unitOfWork.ModuleRepository.GetPagedListAsync(page, pageSize, ParseJSONSearchString<Module>(where), sortExpression);
        }

        /// <summary>
        /// Gets the module by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Module.</returns>
        public Module GetModuleById(int id)
        {
            return _unitOfWork.ModuleRepository.GetSingle(a => a.Id == id);
        }

        /// <summary>
        /// get module by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Module.</returns>
        public async Task<Module> GetModuleByIdAsync(int id)
        {
            return await _unitOfWork.ModuleRepository.GetSingleAsync(a => a.Id == id);
        }

        /// <summary>
        /// Adds the module.
        /// </summary>
        /// <param name="modules">The modules.</param>
        public void AddModule(params Module[] modules)
        {
            _unitOfWork.ModuleRepository.Add(modules);
            _unitOfWork.Save();
        }

        /// <summary>
        /// add module as an asynchronous operation.
        /// </summary>
        /// <param name="modules">The modules.</param>
        public async Task AddModuleAsync(params Module[] modules)
        {
            _unitOfWork.ModuleRepository.Add(modules);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Updates the module.
        /// </summary>
        /// <param name="modules">The modules.</param>
        public void UpdateModule(params Module[] modules)
        {
            _unitOfWork.ModuleRepository.Update(modules);
            _unitOfWork.Save();
        }

        /// <summary>
        /// update module as an asynchronous operation.
        /// </summary>
        /// <param name="modules">The modules.</param>
        public async Task UpdateModuleAsync(params Module[] modules)
        {
            _unitOfWork.ModuleRepository.Update(modules);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Removes the module.
        /// </summary>
        /// <param name="modules">The modules.</param>
        public void RemoveModule(params Module[] modules)
        {
            _unitOfWork.ModuleRepository.Remove(modules);
            _unitOfWork.Save();
        }

        /// <summary>
        /// remove module as an asynchronous operation.
        /// </summary>
        /// <param name="modules">The modules.</param>
        public async Task RemoveModuleAsync(params Module[] modules)
        {
            _unitOfWork.ModuleRepository.Remove(modules);
            await _unitOfWork.SaveAsync();
        }
    }
}
