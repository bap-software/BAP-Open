// ***********************************************************************
// Assembly         : BAP.BL
// Author           : Victor Mamray
// Created          : 06-11-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="DocumentTemplateBL.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Text.RegularExpressions;
using System.Linq;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Threading.Tasks;

using PagedList;

using BAP.Common;
using BAP.DAL.Entities;
using BAP.DAL;
using BAP.Log;
using System.IO;

namespace BAP.BL
{
    /// <summary>
    /// Interface IDocumentTemplateBL
    /// </summary>
    public interface IDocumentTemplateBL
    {
        /// <summary>
        /// Gets all document templates.
        /// </summary>
        /// <returns>IList&lt;DocumentTemplate&gt;.</returns>
        IList<DocumentTemplate> GetAllDocumentTemplates();
        /// <summary>
        /// Gets all document templates asynchronous.
        /// </summary>
        /// <returns>Task&lt;IList&lt;DocumentTemplate&gt;&gt;.</returns>
        Task<IList<DocumentTemplate>> GetAllDocumentTemplatesAsync();

        /// <summary>
        /// Searches the document templates.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;DocumentTemplate&gt;.</returns>
        IPagedList<DocumentTemplate> SearchDocumentTemplates(string where, string sort, int page, int pageSize = 20);
        /// <summary>
        /// Searches the document templates asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IPagedList&lt;DocumentTemplate&gt;&gt;.</returns>
        Task<IPagedList<DocumentTemplate>> SearchDocumentTemplatesAsync(string where, string sort, int page, int pageSize = 20);

        /// <summary>
        /// Searches the document templates.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>IList&lt;DocumentTemplate&gt;.</returns>
        IList<DocumentTemplate> SearchDocumentTemplates(string where, string sort);
        /// <summary>
        /// Searches the document templates asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>Task&lt;IList&lt;DocumentTemplate&gt;&gt;.</returns>
        Task<IList<DocumentTemplate>> SearchDocumentTemplatesAsync(string where, string sort);

        /// <summary>
        /// Gets the document template by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>DocumentTemplate.</returns>
        DocumentTemplate GetDocumentTemplateById(int id);
        /// <summary>
        /// Gets the document template by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;DocumentTemplate&gt;.</returns>
        Task<DocumentTemplate> GetDocumentTemplateByIdAsync(int id);

        /// <summary>
        /// Gets the name of the document template by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>DocumentTemplate.</returns>
        DocumentTemplate GetDocumentTemplateByName(string name);
        /// <summary>
        /// Gets the document template by name asynchronous.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Task&lt;DocumentTemplate&gt;.</returns>
        Task<DocumentTemplate> GetDocumentTemplateByNameAsync(string name);

        /// <summary>
        /// Adds the document template.
        /// </summary>
        /// <param name="documentTemplates">The document templates.</param>
        void AddDocumentTemplate(params DocumentTemplate[] documentTemplates);
        /// <summary>
        /// Adds the document template asynchronous.
        /// </summary>
        /// <param name="documentTemplates">The document templates.</param>
        /// <returns>Task.</returns>
        Task AddDocumentTemplateAsync(params DocumentTemplate[] documentTemplates);

        /// <summary>
        /// Updates the document template.
        /// </summary>
        /// <param name="documentTemplates">The document templates.</param>
        void UpdateDocumentTemplate(params DocumentTemplate[] documentTemplates);
        /// <summary>
        /// Updates the document template asynchronous.
        /// </summary>
        /// <param name="documentTemplates">The document templates.</param>
        /// <returns>Task.</returns>
        Task UpdateDocumentTemplateAsync(params DocumentTemplate[] documentTemplates);

        /// <summary>
        /// Removes the document template.
        /// </summary>
        /// <param name="documentTemplates">The document templates.</param>
        void RemoveDocumentTemplate(params DocumentTemplate[] documentTemplates);
        /// <summary>
        /// Removes the document template asynchronous.
        /// </summary>
        /// <param name="documentTemplates">The document templates.</param>
        /// <returns>Task.</returns>
        Task RemoveDocumentTemplateAsync(params DocumentTemplate[] documentTemplates);

        /// <summary>
        /// Enumerates the template parameters.
        /// </summary>
        /// <param name="templateText">The template text.</param>
        /// <returns>List&lt;System.String&gt;.</returns>
        List<string> EnumerateTemplateParameters(string templateText);
        /// <summary>
        /// Transforms the template.
        /// </summary>
        /// <param name="templateText">The template text.</param>
        /// <param name="entity">The entity.</param>
        /// <param name="removeEmptyValues">if set to <c>true</c> [remove empty values].</param>
        /// <returns>System.String.</returns>
        string TransformTemplate(string templateText, IBapEntity entity, bool removeEmptyValues = true);
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
    public partial class BusinessLayer : IDocumentTemplateBL
    {
        /// <summary>
        /// Gets all document templates.
        /// </summary>
        /// <returns>IList&lt;DocumentTemplate&gt;.</returns>
        public IList<DocumentTemplate> GetAllDocumentTemplates()
        {
            return _unitOfWork.DocumentTemplateRepository.GetAll().Select(a => ProcessOnSelect(a)).ToList();
        }

        /// <summary>
        /// get all document templates as an asynchronous operation.
        /// </summary>
        /// <returns>IList&lt;DocumentTemplate&gt;.</returns>
        public async Task<IList<DocumentTemplate>> GetAllDocumentTemplatesAsync()
        {
            return (await _unitOfWork.DocumentTemplateRepository.GetAllAsync()).Select(a => ProcessOnSelect(a)).ToList();
        }

        /// <summary>
        /// Searches the document templates.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;DocumentTemplate&gt;.</returns>
        public IPagedList<DocumentTemplate> SearchDocumentTemplates(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<DocumentTemplate>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {                
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            return _unitOfWork.DocumentTemplateRepository.GetList(ParseJSONSearchString<DocumentTemplate>(where), sortExpression)
                .Select(a => ProcessOnSelect(a)).ToPagedList(page, pageSize);
        }

        /// <summary>
        /// search document templates as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;DocumentTemplate&gt;.</returns>
        public async Task<IPagedList<DocumentTemplate>> SearchDocumentTemplatesAsync(string where, string sort, int page, int pageSize = 20)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<DocumentTemplate>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }
            
            return (await _unitOfWork.DocumentTemplateRepository.GetListAsync(ParseJSONSearchString<DocumentTemplate>(where), sortExpression))
                .Select(a => ProcessOnSelect(a)).ToPagedList(page, pageSize);
        }

        /// <summary>
        /// Searches the document templates.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>IList&lt;DocumentTemplate&gt;.</returns>
        public IList<DocumentTemplate> SearchDocumentTemplates(string where, string sort)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<DocumentTemplate>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            return _unitOfWork.DocumentTemplateRepository.GetList(ParseJSONSearchString<DocumentTemplate>(where), sortExpression).Select(a => ProcessOnSelect(a)).ToList();
        }

        /// <summary>
        /// search document templates as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <returns>IList&lt;DocumentTemplate&gt;.</returns>
        public async Task<IList<DocumentTemplate>> SearchDocumentTemplatesAsync(string where, string sort)
        {
            string sortExpression = sort;
            var entityHelper = new EntityHelper<DocumentTemplate>();
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = entityHelper.AdjustSortExpression(sortExpression);
            }

            return (await _unitOfWork.DocumentTemplateRepository.GetListAsync(ParseJSONSearchString<DocumentTemplate>(where), sortExpression)).Select(a => ProcessOnSelect(a)).ToList();
        }

        /// <summary>
        /// Gets the document template by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>DocumentTemplate.</returns>
        public DocumentTemplate GetDocumentTemplateById(int id)
        {
            return ProcessOnSelect(_unitOfWork.DocumentTemplateRepository.GetSingle(c => c.Id == id));
        }

        /// <summary>
        /// get document template by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>DocumentTemplate.</returns>
        public async Task<DocumentTemplate> GetDocumentTemplateByIdAsync(int id)
        {
            return ProcessOnSelect(await _unitOfWork.DocumentTemplateRepository.GetSingleAsync(c => c.Id == id));
        }

        /// <summary>
        /// Gets the name of the document template by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>DocumentTemplate.</returns>
        public DocumentTemplate GetDocumentTemplateByName(string name)
        {
            return ProcessOnSelect(_unitOfWork.DocumentTemplateRepository.GetSingle(c => c.Name == name));
        }

        /// <summary>
        /// get document template by name as an asynchronous operation.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>DocumentTemplate.</returns>
        public async Task<DocumentTemplate> GetDocumentTemplateByNameAsync(string name)
        {
            return ProcessOnSelect(await _unitOfWork.DocumentTemplateRepository.GetSingleAsync(c => c.Name == name));
        }

        /// <summary>
        /// Processes the on select.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>DocumentTemplate.</returns>
        private DocumentTemplate ProcessOnSelect(DocumentTemplate source)
        {
            if (source == null)
                return null;

            if(!string.IsNullOrEmpty(source.TemplateBody))
            {
                source.TemplateBodyText = source.TemplateBody;                
            }
            else if(!string.IsNullOrEmpty(source.TemplateBodyUrl) && _fileProcessor != null)
            {
                var file = _fileProcessor.GetFile(source.TemplateBodyUrl);

                if(file != null && file.FileStream != null)
                {                    
                    using (StreamReader sr = new StreamReader(file.FileStream))
                    {
                        source.TemplateBodyText = sr.ReadToEnd();
                    }                    
                }
            }

            return source;
        }

        /// <summary>
        /// Adds the document template.
        /// </summary>
        /// <param name="documentTemplates">The document templates.</param>
        public void AddDocumentTemplate(params DocumentTemplate[] documentTemplates)
        {
            _unitOfWork.DocumentTemplateRepository.Add(documentTemplates);
            _unitOfWork.Save();
        }

        /// <summary>
        /// add document template as an asynchronous operation.
        /// </summary>
        /// <param name="documentTemplates">The document templates.</param>
        public async Task AddDocumentTemplateAsync(params DocumentTemplate[] documentTemplates)
        {
            _unitOfWork.DocumentTemplateRepository.Add(documentTemplates);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Updates the document template.
        /// </summary>
        /// <param name="documentTemplates">The document templates.</param>
        public void UpdateDocumentTemplate(params DocumentTemplate[] documentTemplates)
        {
            _unitOfWork.DocumentTemplateRepository.Update(documentTemplates);
            _unitOfWork.Save();
        }

        /// <summary>
        /// update document template as an asynchronous operation.
        /// </summary>
        /// <param name="documentTemplates">The document templates.</param>
        public async Task UpdateDocumentTemplateAsync(params DocumentTemplate[] documentTemplates)
        {
            _unitOfWork.DocumentTemplateRepository.Update(documentTemplates);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Removes the document template.
        /// </summary>
        /// <param name="documentTemplates">The document templates.</param>
        public void RemoveDocumentTemplate(params DocumentTemplate[] documentTemplates)
        {
            _unitOfWork.DocumentTemplateRepository.Remove(documentTemplates);
            _unitOfWork.Save();
        }

        /// <summary>
        /// remove document template as an asynchronous operation.
        /// </summary>
        /// <param name="documentTemplates">The document templates.</param>
        public async Task RemoveDocumentTemplateAsync(params DocumentTemplate[] documentTemplates)
        {
            _unitOfWork.DocumentTemplateRepository.Remove(documentTemplates);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Enumerates the template parameters.
        /// </summary>
        /// <param name="templateText">The template text.</param>
        /// <returns>List&lt;System.String&gt;.</returns>
        public List<string> EnumerateTemplateParameters(string templateText)
        {
            if (string.IsNullOrEmpty(templateText))
                return null;

            var result = new List<string>();
            const string pattern = @"\{([^\}]+)\}";
            foreach (Match match in Regex.Matches(templateText, pattern))
            {
                result.Add(match.Value);
            }
            return result;
        }

        /// <summary>
        /// Transforms the template.
        /// </summary>
        /// <param name="templateText">The template text.</param>
        /// <param name="entity">The entity.</param>
        /// <param name="removeEmptyValues">if set to <c>true</c> [remove empty values].</param>
        /// <returns>System.String.</returns>
        public string TransformTemplate(string templateText, IBapEntity entity, bool removeEmptyValues = true)
        {
            if (string.IsNullOrEmpty(templateText) || entity == null)
                return null;

            var parameters = EnumerateTemplateParameters(templateText);
            if (parameters == null || !parameters.Any())
                return templateText;
            
            foreach(var prm in parameters)
            {                
                var propName = prm.TrimStart('{').TrimEnd('}');
                object val;
                if (!prm.Contains("."))
                {
                    val = entity.GetType().GetProperty(propName)?.GetValue(entity, null);                    
                }
                else
                {
                    val = GetNestedPropValue(propName, entity);
                }

                if (val != null)
                {
                    templateText = templateText.Replace(prm, val.ToString());
                }
                else if(removeEmptyValues)
                {
                    templateText = templateText.Replace(prm, "");
                }
            }

            return templateText;
        }

        /// <summary>
        /// Gets the nested property value.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="obj">The object.</param>
        /// <returns>System.Object.</returns>
        protected object GetNestedPropValue(string name, object obj)
        {
            foreach (string part in name.Split('.'))
            {
                if (obj == null) 
                { 
                    return null; 
                }

                Type type = obj.GetType();
                PropertyInfo info = type.GetProperty(part);
                if (info == null) 
                { 
                    return null; 
                }

                obj = info.GetValue(obj, null);
            }
            return obj;
        }
    }

    /// <summary>
    /// Class DocumentTemplateBL.
    /// Implements the <see cref="BAP.BL.BusinessLayer" />
    /// Implements the <see cref="BAP.Common.ISupportLookup" />
    /// </summary>
    /// <seealso cref="BAP.BL.BusinessLayer" />
    /// <seealso cref="BAP.Common.ISupportLookup" />
    public class DocumentTemplateBL : BusinessLayer, ISupportLookup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentTemplateBL"/> class.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        public DocumentTemplateBL(IConfigHelper settings, IAuthorizationContext context, ILogger logger) : base(settings, context, logger)
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
            var documentTemplates = SearchDocumentTemplates(extraFilter, orderBy);
            foreach (var documentTemplate in documentTemplates)
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
            var documentTemplates = await SearchDocumentTemplatesAsync(extraFilter, orderBy);
            foreach (var documentTemplate in documentTemplates)
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
