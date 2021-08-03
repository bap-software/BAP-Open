// ***********************************************************************
// Assembly         : BAP.BL
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="BusinessLayer.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

using Newtonsoft.Json;

using BAP.Common;
using BAP.DAL;
using BAP.Lookups;
using BAP.Log;
using BAP.Common.Exceptions;
using BAP.FileSystem;

namespace BAP.BL
{
    /// <summary>
    /// Class SearchStruct.
    /// </summary>
    public class SearchStruct
    {
        /// <summary>
        /// Gets or sets the field.
        /// </summary>
        /// <value>The field.</value>
        public string field { get; set; }
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public string value { get; set; }
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
    public partial class BusinessLayer : IDisposable
    {
        /// <summary>
        /// The configuration helper
        /// </summary>
        protected readonly IConfigHelper _configHelper;
        /// <summary>
        /// The unit of work
        /// </summary>
        protected IUnitOfWork _unitOfWork;
        /// <summary>
        /// The authentication context
        /// </summary>
        protected readonly IAuthorizationContext _authContext;
        /// <summary>
        /// The lookup engine
        /// </summary>
        protected readonly ILookupEngine _lookupEngine;
        /// <summary>
        /// The logger
        /// </summary>
        protected readonly ILogger _logger;
        /// <summary>
        /// The file processor
        /// </summary>
        protected readonly IFileProcessor _fileProcessor;

        protected ApplicationCache _cache;

        /// <summary>
        /// Prevents a default instance of the <see cref="BusinessLayer"/> class from being created.
        /// </summary>
        private BusinessLayer()
        {
            _configHelper = null;            
            _unitOfWork = null;
            _authContext = null;
            _lookupEngine = null;
            _logger = null;
            _fileProcessor = null;
            _cache = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessLayer"/> class.
        /// </summary>
        /// <param name="configHelper">The configuration helper.</param>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        public BusinessLayer(IConfigHelper configHelper, IAuthorizationContext context, ILogger logger)
        {
            _logger = logger;
            _configHelper = configHelper;
            _unitOfWork = new UnitOfWork(_configHelper, context);
            _authContext = context;
            _lookupEngine = null;
            _fileProcessor = null;
            _cache = new ApplicationCache(_configHelper);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessLayer"/> class.
        /// </summary>
        /// <param name="configHelper">The configuration helper.</param>
        /// <param name="context">The context.</param>
        /// <param name="lookupEngine">The lookup engine.</param>
        /// <param name="logger">The logger.</param>
        public BusinessLayer(IConfigHelper configHelper, IAuthorizationContext context, ILookupEngine lookupEngine, ILogger logger)
        {
            _logger = logger;                       
            _configHelper = configHelper;            
            _unitOfWork = new UnitOfWork(_configHelper, context);
            _authContext = context;
            _lookupEngine = lookupEngine;
            _fileProcessor = null;
            _cache = new ApplicationCache(_configHelper);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessLayer"/> class.
        /// </summary>
        /// <param name="configHelper">The configuration helper.</param>
        /// <param name="context">The context.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="logger">The logger.</param>
        public BusinessLayer(IConfigHelper configHelper, IAuthorizationContext context, IUnitOfWork unitOfWork, ILogger logger)
        {
            _logger = logger;
            _configHelper = configHelper;            
            _unitOfWork = unitOfWork;
            _authContext = context;
            _lookupEngine = null;
            _fileProcessor = null;
            _cache = new ApplicationCache(_configHelper);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessLayer"/> class.
        /// </summary>
        /// <param name="configHelper">The configuration helper.</param>
        /// <param name="context">The context.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="lookupEngine">The lookup engine.</param>
        /// <param name="logger">The logger.</param>
        public BusinessLayer(IConfigHelper configHelper, IAuthorizationContext context, IUnitOfWork unitOfWork, ILookupEngine lookupEngine, ILogger logger)
        {
            _logger = logger;
            _configHelper = configHelper;
            _unitOfWork = unitOfWork;
            _authContext = context;
            _lookupEngine = lookupEngine;
            _fileProcessor = null;
            _cache = new ApplicationCache(_configHelper);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessLayer"/> class.
        /// </summary>
        /// <param name="configHelper">The configuration helper.</param>
        /// <param name="context">The context.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="lookupEngine">The lookup engine.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="fileProc">The file proc.</param>
        public BusinessLayer(IConfigHelper configHelper, IAuthorizationContext context, IUnitOfWork unitOfWork, ILookupEngine lookupEngine, ILogger logger, IFileProcessor fileProc)
        {
            _logger = logger;
            _configHelper = configHelper;
            _unitOfWork = unitOfWork;
            _authContext = context;
            _lookupEngine = lookupEngine;
            _fileProcessor = fileProc;
            _cache = new ApplicationCache(_configHelper);
        }

        /// <summary>
        /// The disposed
        /// </summary>
        private bool _disposed = false;
        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    if(_unitOfWork != null)
                        ((IDisposable)_unitOfWork).Dispose();
                    if(_cache != null)
                        ((IDisposable)_cache).Dispose();
                }
            }
            this._disposed = true;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Parses the json search string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonWhere">The json where.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="BAPFullTextSearchNotSupported"></exception>
        public string ParseJSONSearchString<T>(string jsonWhere) where T : class, IBapEntity, new()
        {
            var where = string.Empty;
            if (!string.IsNullOrEmpty(jsonWhere))
            {
                try
                {
                    var arr = JsonConvert.DeserializeObject<List<SearchStruct>>(jsonWhere);
                    var entityType = typeof(T);
                    var entityHelper = new EntityHelper<T>();
                    var searchFields = entityHelper.GetEntityFields();
                    foreach (var field in arr)
                    {
                        if (field.value.ToLower() == "any")
                            continue;

                        if (!string.IsNullOrEmpty(field.value))
                        {
                            if (!string.IsNullOrEmpty(where))
                                where += " AND ";
                            if (!field.field.Contains("-"))
                            {
                                var prop = searchFields.SingleOrDefault(p => p.Name.ToLower() == field.field.ToLower());
                                if (prop != null)
                                {
                                    if (prop.PropertyType.Name.ToLower().Contains("string"))
                                    {
                                        where += string.Format("{0} = \"{1}\"", field.field, field.value);
                                    }
                                    else
                                    {
                                        where += string.Format("{0} = {1}", field.field, field.value);
                                    }
                                }
                                else if (field.field.ToLower() == "fulltext")
                                {
                                    var obj = new T();
                                    if (obj is IFullTextSearchable)
                                    {
                                        where += ((IFullTextSearchable)obj).FullTextSearchExpression(field.value);
                                    }
                                    else
                                    {
                                        throw new BAPFullTextSearchNotSupported();
                                    }
                                }
                                else
                                {
                                    where += string.Format("{0} = \"{1}\"", field.field, field.value);
                                }
                            }
                            else
                            {
                                var exts = field.field.Split("-".ToCharArray());
                                switch (exts[1].ToLower())
                                {
                                    case "end": where += string.Format("{0}.EndsWith(\"{1}\")", exts[0], field.value); break;
                                    case "start": where += string.Format("{0}.StartsWith(\"{1}\")", exts[0], field.value); break;
                                    case "like": where += string.Format("{0}.Contains(\"{1}\")", exts[0], field.value); break;
                                    case "min": where += string.Format("{0} >= {1}", exts[0], field.value); break;
                                    case "max": where += string.Format("{0} <= {1}", exts[0], field.value); break;
                                    default: where += "1 = 1"; break;
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    where = " 1=1 ";
                }
            }

            return where;
        }

        /// <summary>
        /// Finds the type of the bap entity.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Type.</returns>
        protected Type FindBapEntityType(string name)
        {
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => p.GetInterfaces().Any(a => a.Name == "IBapEntity") && p.Name == name);
            return types.FirstOrDefault();
        }

        /// <summary>
        /// Sets the entity property.
        /// </summary>
        /// <param name="entityType">Type of the entity.</param>
        /// <param name="entityObject">The entity object.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="propertyValue">The property value.</param>
        protected void SetEntityProperty(Type entityType, object entityObject, string propertyName, object propertyValue)
        {
            if (entityType == null || string.IsNullOrEmpty(propertyName))
                return;
            var property = entityType.GetProperty(propertyName);
            if (property != null)
                property.SetValue(entityObject, propertyValue);
        }
    }
}
