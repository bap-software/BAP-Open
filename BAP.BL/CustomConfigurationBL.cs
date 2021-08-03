// ***********************************************************************
// Assembly         : BAP.BL
// Author           : Victor Mamray
// Created          : 05-24-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="CustomConfigurationBL.cs" company="BAP Software Ltd.">
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
using System.Reflection;
using BAP.BL.CustomConfigurationNodes;
using System.Linq;
using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace BAP.BL
{
    /// <summary>
    /// Interface ICustomConfigurationBL
    /// </summary>
    public interface ICustomConfigurationBL
    {
        /// <summary>
        /// Gets all custom configurations.
        /// </summary>
        /// <returns>IList&lt;CustomConfiguration&gt;.</returns>
        IList<CustomConfiguration> GetAllCustomConfigurations();
        /// <summary>
        /// Gets all custom configurations asynchronous.
        /// </summary>
        /// <returns>Task&lt;IList&lt;CustomConfiguration&gt;&gt;.</returns>
        Task<IList<CustomConfiguration>> GetAllCustomConfigurationsAsync();

        /// <summary>
        /// Searches the custom configurations.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;CustomConfiguration&gt;.</returns>
        IPagedList<CustomConfiguration> SearchCustomConfigurations(string where, string sort, int page, int pageSize = 20);
        /// <summary>
        /// Searches the custom configurations asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IPagedList&lt;CustomConfiguration&gt;&gt;.</returns>
        Task<IPagedList<CustomConfiguration>> SearchCustomConfigurationsAsync(string where, string sort, int page, int pageSize = 20);

        /// <summary>
        /// Searches the custom configurations.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>IList&lt;CustomConfiguration&gt;.</returns>
        IList<CustomConfiguration> SearchCustomConfigurations(string where, string sort);
        /// <summary>
        /// Searches the custom configurations asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>Task&lt;IList&lt;CustomConfiguration&gt;&gt;.</returns>
        Task<IList<CustomConfiguration>> SearchCustomConfigurationsAsync(string where, string sort);

        /// <summary>
        /// Gets the custom configuration by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>CustomConfiguration.</returns>
        CustomConfiguration GetCustomConfigurationById(int id);
        /// <summary>
        /// Gets the custom configuration by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;CustomConfiguration&gt;.</returns>
        Task<CustomConfiguration> GetCustomConfigurationByIdAsync(int id);

        /// <summary>
        /// Gets the name of the custom configuration by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>CustomConfiguration.</returns>
        CustomConfiguration GetCustomConfigurationByName(string name);
        /// <summary>
        /// Gets the custom configuration by name asynchronous.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Task&lt;CustomConfiguration&gt;.</returns>
        Task<CustomConfiguration> GetCustomConfigurationByNameAsync(string name);

        /// <summary>
        /// Adds the custom configuration.
        /// </summary>
        /// <param name="customConfigurations">The custom configurations.</param>
        void AddCustomConfiguration(params CustomConfiguration[] customConfigurations);
        /// <summary>
        /// Adds the custom configuration asynchronous.
        /// </summary>
        /// <param name="customConfigurations">The custom configurations.</param>
        /// <returns>Task.</returns>
        Task AddCustomConfigurationAsync(params CustomConfiguration[] customConfigurations);


        /// <summary>
        /// Updates the custom configuration.
        /// </summary>
        /// <param name="customConfigurations">The custom configurations.</param>
        void UpdateCustomConfiguration(params CustomConfiguration[] customConfigurations);
        /// <summary>
        /// Updates the custom configuration asynchronous.
        /// </summary>
        /// <param name="customConfigurations">The custom configurations.</param>
        /// <returns>Task.</returns>
        Task UpdateCustomConfigurationAsync(params CustomConfiguration[] customConfigurations);

        /// <summary>
        /// Removes the custom configuration.
        /// </summary>
        /// <param name="customConfigurations">The custom configurations.</param>
        void RemoveCustomConfiguration(params CustomConfiguration[] customConfigurations);
        /// <summary>
        /// Removes the custom configuration asynchronous.
        /// </summary>
        /// <param name="customConfigurations">The custom configurations.</param>
        /// <returns>Task.</returns>
        Task RemoveCustomConfigurationAsync(params CustomConfiguration[] customConfigurations);

        /// <summary>
        /// Gets the custom configuration tree.
        /// </summary>
        /// <returns>CustomConfigurationNode.</returns>
        CustomConfigurationNode GetCustomConfigurationTree();
        /// <summary>
        /// Gets the custom configuration tree asynchronous.
        /// </summary>
        /// <returns>Task&lt;CustomConfigurationNode&gt;.</returns>
        Task<CustomConfigurationNode> GetCustomConfigurationTreeAsync();
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
    public partial class BusinessLayer : ICustomConfigurationBL
    {
        /// <summary>
        /// Gets all custom configurations.
        /// </summary>
        /// <returns>IList&lt;CustomConfiguration&gt;.</returns>
        public IList<CustomConfiguration> GetAllCustomConfigurations()
        {
            return _unitOfWork.CustomConfigurationRepository.GetAll();
        }

        /// <summary>
        /// get all custom configurations as an asynchronous operation.
        /// </summary>
        /// <returns>IList&lt;CustomConfiguration&gt;.</returns>
        public async Task<IList<CustomConfiguration>> GetAllCustomConfigurationsAsync()
        {
            return await _unitOfWork.CustomConfigurationRepository.GetAllAsync();
        }

        /// <summary>
        /// Searches the custom configurations.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;CustomConfiguration&gt;.</returns>
        public IPagedList<CustomConfiguration> SearchCustomConfigurations(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<CustomConfiguration>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            return _unitOfWork.CustomConfigurationRepository.GetPagedList(page, pageSize, ParseJSONSearchString<CustomConfiguration>(where), sortExpression);
        }

        /// <summary>
        /// search custom configurations as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;CustomConfiguration&gt;.</returns>
        public async Task<IPagedList<CustomConfiguration>> SearchCustomConfigurationsAsync(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<CustomConfiguration>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            return await _unitOfWork.CustomConfigurationRepository.GetPagedListAsync(page, pageSize, ParseJSONSearchString<CustomConfiguration>(where), sortExpression);
        }

        /// <summary>
        /// Searches the custom configurations.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>IList&lt;CustomConfiguration&gt;.</returns>
        public IList<CustomConfiguration> SearchCustomConfigurations(string where, string sort)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<CustomConfiguration>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            return _unitOfWork.CustomConfigurationRepository.GetList(ParseJSONSearchString<CustomConfiguration>(where), sortExpression);
        }

        /// <summary>
        /// search custom configurations as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>IList&lt;CustomConfiguration&gt;.</returns>
        public async Task<IList<CustomConfiguration>> SearchCustomConfigurationsAsync(string where, string sort)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<CustomConfiguration>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            return await _unitOfWork.CustomConfigurationRepository.GetListAsync(ParseJSONSearchString<CustomConfiguration>(where), sortExpression);

        }

        /// <summary>
        /// Gets the custom configuration by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>CustomConfiguration.</returns>
        public CustomConfiguration GetCustomConfigurationById(int id)
        {
            return _unitOfWork.CustomConfigurationRepository.GetSingle(c => c.Id == id);
        }

        /// <summary>
        /// get custom configuration by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>CustomConfiguration.</returns>
        public async Task<CustomConfiguration> GetCustomConfigurationByIdAsync(int id)
        {
            return await _unitOfWork.CustomConfigurationRepository.GetSingleAsync(c => c.Id == id);
        }



        /// <summary>
        /// Gets the name of the custom configuration by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>CustomConfiguration.</returns>
        public CustomConfiguration GetCustomConfigurationByName(string name)
        {
            string key = "CUSTOM_CONFIG_BY_NAME_" + name;
            CustomConfiguration result = (CustomConfiguration)_cache[key];
            if(result == null)
            {
                result = _unitOfWork.CustomConfigurationRepository.GetSingle(c => c.Name == name);
                _cache[key] = result; ;
            }
            return result;
        }

        /// <summary>
        /// get custom configuration by name as an asynchronous operation.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>CustomConfiguration.</returns>
        public async Task<CustomConfiguration> GetCustomConfigurationByNameAsync(string name)
        {
            string key = "CUSTOM_CONFIG_BY_NAME_" + name;            
            CustomConfiguration result = (CustomConfiguration)_cache[key];
            if (result == null)
            {
                result = await _unitOfWork.CustomConfigurationRepository.GetSingleAsync(c => c.Name == name);
                _cache[key] = result; ;
            }
            return result;
        }

        /// <summary>
        /// Adds the custom configuration.
        /// </summary>
        /// <param name="customConfigurations">The custom configurations.</param>
        public void AddCustomConfiguration(params CustomConfiguration[] customConfigurations)
        {
            _unitOfWork.CustomConfigurationRepository.Add(customConfigurations);
            _unitOfWork.Save();
        }

        /// <summary>
        /// add custom configuration as an asynchronous operation.
        /// </summary>
        /// <param name="customConfigurations">The custom configurations.</param>
        public async Task AddCustomConfigurationAsync(params CustomConfiguration[] customConfigurations)
        {
            _unitOfWork.CustomConfigurationRepository.Add(customConfigurations);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Updates the custom configuration.
        /// </summary>
        /// <param name="customConfigurations">The custom configurations.</param>
        public void UpdateCustomConfiguration(params CustomConfiguration[] customConfigurations)
        {
            _unitOfWork.CustomConfigurationRepository.Update(customConfigurations);
            _unitOfWork.Save();
        }

        /// <summary>
        /// update custom configuration as an asynchronous operation.
        /// </summary>
        /// <param name="customConfigurations">The custom configurations.</param>
        public async Task UpdateCustomConfigurationAsync(params CustomConfiguration[] customConfigurations)
        {
            _unitOfWork.CustomConfigurationRepository.Update(customConfigurations);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Removes the custom configuration.
        /// </summary>
        /// <param name="customConfigurations">The custom configurations.</param>
        public void RemoveCustomConfiguration(params CustomConfiguration[] customConfigurations)
        {
            _unitOfWork.CustomConfigurationRepository.Remove(customConfigurations);
            _unitOfWork.Save();
        }

        /// <summary>
        /// remove custom configuration as an asynchronous operation.
        /// </summary>
        /// <param name="customConfigurations">The custom configurations.</param>
        public async Task RemoveCustomConfigurationAsync(params CustomConfiguration[] customConfigurations)
        {
            _unitOfWork.CustomConfigurationRepository.Remove(customConfigurations);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Gets the custom configuration tree.
        /// </summary>
        /// <returns>CustomConfigurationNode.</returns>
        public CustomConfigurationNode GetCustomConfigurationTree()
        {
            // create root node
            var rootNode = new CustomConfigurationNode
            {
                NodeId = -1,
                IsRoot = true,
                Title = Resources.Resources.UIText_Assemblies,
                Children = new List<CustomConfigurationNode>()
            };

            var customConfigurations = GetAllCustomConfigurations();
            var assemblies = new List<Assembly>();
            Type interfaceType = typeof(ISupportCustomConfig);
            IEnumerable<Type> types = null;
            try
            {
                types = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(s => s.GetTypes())
                    .Where(p => interfaceType.IsAssignableFrom(p) && !p.IsInterface)
                    .ToList();
            }
            catch {
                //Do nothing - if cannot read assemblies that we do not search over them
            }
            if (types != null && types.Any())
                assemblies.AddRange(types.Select(t => t.Assembly).Distinct());

            foreach (var assembly in assemblies)
            {                
                var assemblyNode = new CustomConfigurationNode
                {
                    NodeId = -1,
                    IsRoot = false,
                    Title = assembly.GetName().Name,
                    Children = new List<CustomConfigurationNode>()
                };
                foreach (var cls in types.Where(t => t.Assembly.FullName == assembly.FullName))
                {
                    var tempEntity = FormatterServices.GetUninitializedObject(cls);
                    if (!((ISupportCustomConfig)tempEntity).SupportsCustomConfig)
                        continue;
                    var customConfiguration = customConfigurations.FirstOrDefault(cc => cc.AssemblyName.StartsWith(assembly.GetName().Name) && cc.ClassName == cls.FullName);
                    var classNode = new CustomConfigurationNode
                    {
                        NodeId = -1,
                        IsRoot = false,
                        Title = cls.Name,
                        IsLeaf = true
                    };
                    if (customConfiguration == null)
                    {
                        var configuration = ((ISupportCustomConfig)tempEntity).CustomConfigJsonExample;
                        customConfiguration = new CustomConfiguration
                        {
                            Name = $"{assemblyNode.Title}_{classNode.Title}",
                            AssemblyName = assembly.FullName,
                            ClassName = cls.FullName,
                            CurrentConfiguration = configuration,
                            DefaultConfiguration = configuration
                        };
                        AddCustomConfiguration(customConfiguration);
                    }
                    else if (customConfiguration.AssemblyName != assembly.FullName)
                    {
                        customConfiguration.AssemblyName = assembly.FullName;
                        UpdateCustomConfiguration(customConfiguration);
                    }
                    classNode.NodeId = customConfiguration.Id;
                    classNode.CurrentConfiguration = customConfiguration.CurrentConfiguration;
                    classNode.DefaultConfiguration = customConfiguration.DefaultConfiguration;
                    assemblyNode.Children.Add(classNode);
                }
                if (assemblyNode.Children.Any())
                    rootNode.Children.Add(assemblyNode);
            }

            return rootNode;
        }

        /// <summary>
        /// get custom configuration tree as an asynchronous operation.
        /// </summary>
        /// <returns>CustomConfigurationNode.</returns>
        public async Task<CustomConfigurationNode> GetCustomConfigurationTreeAsync()
        {
            // create root node
            var rootNode = new CustomConfigurationNode
            {
                NodeId = -1,
                IsRoot = true,
                Title = Resources.Resources.UIText_Assemblies,
                Children = new List<CustomConfigurationNode>()
            };

            var customConfigurations = await GetAllCustomConfigurationsAsync();

            var assemblies = new List<Assembly>();
            Type interfaceType = typeof(ISupportCustomConfig);
            IEnumerable<Type> types = null;
            try
            {
                types = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(s => s.GetTypes())
                    .Where(p => interfaceType.IsAssignableFrom(p) && !p.IsInterface)
                    .ToList();
            }
            catch {
                //Do nothing - if cannot read assemblies that we do not search over them
            }
            if (types != null && types.Any())
                assemblies.AddRange(types.Select(t => t.Assembly).Distinct());

            foreach (var assembly in assemblies)
            {
                var assemblyNode = new CustomConfigurationNode
                {
                    NodeId = -1,
                    IsRoot = false,
                    Title = assembly.GetName().Name,
                    Children = new List<CustomConfigurationNode>()
                };
                foreach (var cls in types.Where(t => t.Assembly.FullName == assembly.FullName))
                {
                    var tempEntity = FormatterServices.GetUninitializedObject(cls);
                    if (!((ISupportCustomConfig)tempEntity).SupportsCustomConfig)
                        continue;
                    var customConfiguration = customConfigurations.FirstOrDefault(cc => cc.AssemblyName.StartsWith(assembly.GetName().Name) && cc.ClassName == cls.FullName);
                    var classNode = new CustomConfigurationNode
                    {
                        NodeId = -1,
                        IsRoot = false,
                        Title = cls.Name,
                        IsLeaf = true
                    };
                    if (customConfiguration == null)
                    {
                        var configuration = ((ISupportCustomConfig)tempEntity).CustomConfigJsonExample;
                        customConfiguration = new CustomConfiguration
                        {
                            Name = $"{assemblyNode.Title}_{classNode.Title}",
                            AssemblyName = assembly.FullName,
                            ClassName = cls.FullName,
                            CurrentConfiguration = configuration,
                            DefaultConfiguration = configuration
                        };
                        await AddCustomConfigurationAsync(customConfiguration);
                    }
                    else if (customConfiguration.AssemblyName != assembly.FullName)
                    {
                        customConfiguration.AssemblyName = assembly.FullName;
                        await UpdateCustomConfigurationAsync(customConfiguration);
                    }
                    classNode.NodeId = customConfiguration.Id;
                    classNode.CurrentConfiguration = customConfiguration.CurrentConfiguration;
                    classNode.DefaultConfiguration = customConfiguration.DefaultConfiguration;
                    assemblyNode.Children.Add(classNode);
                }
                if (assemblyNode.Children.Any())
                    rootNode.Children.Add(assemblyNode);
            }

            return rootNode;
        }
    }

    /// <summary>
    /// Class CustomConfigurationBL.
    /// Implements the <see cref="BAP.BL.BusinessLayer" />
    /// Implements the <see cref="BAP.Common.ISupportLookup" />
    /// </summary>
    /// <seealso cref="BAP.BL.BusinessLayer" />
    /// <seealso cref="BAP.Common.ISupportLookup" />
    public class CustomConfigurationBL : BusinessLayer, ISupportLookup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomConfigurationBL"/> class.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        public CustomConfigurationBL(IConfigHelper settings, IAuthorizationContext context, ILogger logger) : base(settings, context, logger)
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
            if (string.IsNullOrWhiteSpace(extraFilter))
                extraFilter = "[{\"field\":\"TemplateType\",\"value\":\"financial\"}]";
            var customConfigurations = SearchCustomConfigurations(extraFilter, orderBy);
            foreach (var documentTemplate in customConfigurations)
            {
                var val = documentTemplate.GetType().GetProperty(valueField).GetValue(documentTemplate, null);
                var text = documentTemplate.GetType().GetProperty(textField).GetValue(documentTemplate, null);
                var descr = text;
                if (!string.IsNullOrEmpty(descriptionField))
                {
                    descr = documentTemplate.GetType().GetProperty(descriptionField).GetValue(documentTemplate, null);
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
            if (string.IsNullOrWhiteSpace(extraFilter))
                extraFilter = "[{\"field\":\"TemplateType\",\"value\":\"financial\"}]";
            var customConfigurations = await SearchCustomConfigurationsAsync(extraFilter, orderBy);
            foreach (var documentTemplate in customConfigurations)
            {
                var val = documentTemplate.GetType().GetProperty(valueField).GetValue(documentTemplate, null);
                var text = documentTemplate.GetType().GetProperty(textField).GetValue(documentTemplate, null);
                var descr = text;
                if (!string.IsNullOrEmpty(descriptionField))
                {
                    descr = documentTemplate.GetType().GetProperty(descriptionField).GetValue(documentTemplate, null);
                }
                result.Add(new LookupItem { Key = val.ToString(), Text = text.ToString(), Description = descr.ToString() });
            }

            return result;
        }
    }
}
