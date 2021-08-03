// ***********************************************************************
// Assembly         : BAP.BL
// Author           : Victor Mamray
// Created          : 06-22-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-22-2020
// ***********************************************************************
// <copyright file="AttachmentBL.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Security.Cryptography;

using PagedList;

using BAP.Common;
using BAP.DAL;
using BAP.DAL.Entities;

namespace BAP.BL
{
    /// <summary>
    /// Interface IAttachmentBL
    /// </summary>
    public interface IAttachmentBL
    {
        /// <summary>
        /// Searches the attachments.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;Attachment&gt;.</returns>
        IPagedList<Attachment> SearchAttachments(string where, string sort, int page, int pageSize = 20);
        /// <summary>
        /// Searches the attachments asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Task&lt;IPagedList&lt;Attachment&gt;&gt;.</returns>
        Task<IPagedList<Attachment>> SearchAttachmentsAsync(string where, string sort, int page, int pageSize = 20);

        /// <summary>
        /// Gets the attachment by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Attachment.</returns>
        Attachment GetAttachmentById(int id);
        /// <summary>
        /// Gets the attachment by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;Attachment&gt;.</returns>
        Task<Attachment> GetAttachmentByIdAsync(int id);

        /// <summary>
        /// Gets the attachment by URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>Attachment.</returns>
        Attachment GetAttachmentByUrl(string url);
        /// <summary>
        /// Gets the attachment by URL asynchronous.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>Task&lt;Attachment&gt;.</returns>
        Task<Attachment> GetAttachmentByUrlAsync(string url);

        /// <summary>
        /// Gets the attachments by entity identifier.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>IList&lt;Attachment&gt;.</returns>
        IList<Attachment> GetAttachmentsByEntityId(string entity, int id);
        /// <summary>
        /// Gets the attachments by entity identifier asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;IList&lt;Attachment&gt;&gt;.</returns>
        Task<IList<Attachment>> GetAttachmentsByEntityIdAsync(string entity, int id);

        /// <summary>
        /// Adds the attachment.
        /// </summary>
        /// <param name="attachments">The attachments.</param>
        void AddAttachment(params Attachment[] attachments);
        /// <summary>
        /// Adds the attachment asynchronous.
        /// </summary>
        /// <param name="attachments">The attachments.</param>
        /// <returns>Task.</returns>
        Task AddAttachmentAsync(params Attachment[] attachments);

        /// <summary>
        /// Updates the attachment.
        /// </summary>
        /// <param name="attachments">The attachments.</param>
        void UpdateAttachment(params Attachment[] attachments);
        /// <summary>
        /// Updates the attachment asynchronous.
        /// </summary>
        /// <param name="attachments">The attachments.</param>
        /// <returns>Task.</returns>
        Task UpdateAttachmentAsync(params Attachment[] attachments);

        /// <summary>
        /// Removes the attachment.
        /// </summary>
        /// <param name="attachments">The attachments.</param>
        void RemoveAttachment(params Attachment[] attachments);
        /// <summary>
        /// Removes the attachment asynchronous.
        /// </summary>
        /// <param name="attachments">The attachments.</param>
        /// <returns>Task.</returns>
        Task RemoveAttachmentAsync(params Attachment[] attachments);

        /// <summary>
        /// Gets the attachment type by extension.
        /// </summary>
        /// <param name="extension">The extension.</param>
        /// <returns>System.String.</returns>
        string GetAttachmentTypeByExtension(string extension);

        /// <summary>
        /// Makes the attachment secured.
        /// </summary>
        /// <param name="attachmentId">The attachment identifier.</param>
        /// <param name="rolesAllowed">The roles allowed.</param>
        void MakeAttachmentSecured(int attachmentId, params string[] rolesAllowed);
        /// <summary>
        /// Makes the attachment unsecured.
        /// </summary>
        /// <param name="attachmentId">The attachment identifier.</param>
        void MakeAttachmentUnsecured(int attachmentId);
        /// <summary>
        /// Provisions the secured attachment.
        /// </summary>
        /// <param name="attachmentId">The attachment identifier.</param>
        /// <param name="forMinutes">For minutes.</param>
        /// <returns>System.String.</returns>
        string ProvisionSecuredAttachment(int attachmentId, int forMinutes);
        /// <summary>
        /// Stops the provisioning attachment.
        /// </summary>
        /// <param name="attachmentId">The attachment identifier.</param>
        void StopProvisioningAttachment(int attachmentId);

        /// <summary>
        /// Makes the attachment secured asynchronous.
        /// </summary>
        /// <param name="attachmentId">The attachment identifier.</param>
        /// <param name="rolesAllowed">The roles allowed.</param>
        /// <returns>Task.</returns>
        Task MakeAttachmentSecuredAsync(int attachmentId, params string[] rolesAllowed);
        /// <summary>
        /// Makes the attachment unsecured asynchronous.
        /// </summary>
        /// <param name="attachmentId">The attachment identifier.</param>
        /// <returns>Task.</returns>
        Task MakeAttachmentUnsecuredAsync(int attachmentId);
        /// <summary>
        /// Provisions the secured attachment asynchronous.
        /// </summary>
        /// <param name="attachmentId">The attachment identifier.</param>
        /// <param name="forMinutes">For minutes.</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        Task<string> ProvisionSecuredAttachmentAsync(int attachmentId, int forMinutes);
        /// <summary>
        /// Stops the provisioning attachment asynchronous.
        /// </summary>
        /// <param name="attachmentId">The attachment identifier.</param>
        /// <returns>Task.</returns>
        Task StopProvisioningAttachmentAsync(int attachmentId);
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
    public partial class BusinessLayer : IAttachmentBL
    {

        #region service methods
        /// <summary>
        /// Adds the secured filter.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <returns>System.String.</returns>
        private string AddSecuredFilter(string where)
        {
            var authHelper = new AuthorizationHelper<Attachment>(_configHelper, _authContext);
            var currRoles = _authContext.GetCurrentRoleNames(_authContext.GetCurrentUserId(), _configHelper);
            if (currRoles.Any(a => a == authHelper.BapAdminRoleName))
                return where;

            string rolesWhere = "";
            foreach(var role in currRoles)
            {
                rolesWhere += $" OR AllowedToRoles.Contains('{role}') ";
            }
            
            string result = where;
            if (!string.IsNullOrEmpty(result))
                result += " AND ";
            result += $" (!IsSecured.HasValue OR !IsSecured.Value {rolesWhere}) ";
            return result;
        }

        /// <summary>
        /// Adjusts the sort expression.
        /// </summary>
        /// <param name="sort">The sort.</param>
        /// <returns>System.String.</returns>
        private string AdjustSortExpression(string sort)
        {
            string sortExpression = sort;
            if (string.IsNullOrEmpty(sortExpression) || sortExpression.ToLower() == "default")
            {
                var entityHelper = new EntityHelper<Attachment>();
                sortExpression = entityHelper.GetDefaultSortExpression();
            }
            else
            {
                sortExpression = sortExpression.Replace("-", " ");
            }

            return sortExpression;
        }

        /// <summary>
        /// Validates the security.
        /// </summary>
        /// <param name="attachment">The attachment.</param>
        /// <param name="requestUrl">The request URL.</param>
        /// <returns>Attachment.</returns>
        private Attachment ValidateSecurity(Attachment attachment, string requestUrl = "")
        {
            if (attachment == null || !attachment.IsSecured.HasValue || !attachment.IsSecured.Value)
                return attachment;

            Attachment result = null;            
            var authHelper = new AuthorizationHelper<Attachment>(_configHelper, _authContext);
            var currRoles = _authContext.GetCurrentRoleNames(_authContext.GetCurrentUserId(), _configHelper);
            if(currRoles != null && currRoles.Any(a => a == authHelper.BapAdminRoleName) 
                || (!string.IsNullOrEmpty(attachment.AllowedToRoles) && attachment.AllowedToRoles.Split(",".ToCharArray()).Any(a => currRoles.Any(b => b == a))))
            {
                result = attachment;
            }
            else if (!string.IsNullOrEmpty(requestUrl) && requestUrl.ToLower().Contains("sid"))
            {
                var sid = GetParamValue(requestUrl, "sid");
                var accessTokens = _unitOfWork.AttachmentAccessRepository.GetList(a => a.AttachmentId == attachment.Id && a.AccessTokenExpiresAt > DateTime.Now.AddSeconds(15)).ToList();
                if(accessTokens.Any(a => GenerateSaltedHash(a.PublicAccessToken, a.AccessTokenExpiresAt.ToString()) == sid))
                {
                    result = attachment;
                }                
            }
            return result;
        }
        #endregion

        /// <summary>
        /// Searches the attachments.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;Attachment&gt;.</returns>
        public IPagedList<Attachment> SearchAttachments(string where, string sort, int page, int pageSize = 20)
        {
            var parsedWhere = AddSecuredFilter(ParseJSONSearchString<Attachment>(where));
            return _unitOfWork.AttachmentRepository.GetPagedList(page, pageSize, parsedWhere, AdjustSortExpression(sort));
        }

        /// <summary>
        /// search attachments as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sort">The sort.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>IPagedList&lt;Attachment&gt;.</returns>
        public async Task<IPagedList<Attachment>> SearchAttachmentsAsync(string where, string sort, int page, int pageSize = 20)
        {
            return await _unitOfWork.AttachmentRepository.GetPagedListAsync(page, pageSize, AddSecuredFilter(ParseJSONSearchString<Attachment>(where)), AdjustSortExpression(sort));
        }

        /// <summary>
        /// Gets the attachment by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Attachment.</returns>
        public Attachment GetAttachmentById(int id)
        {            
            return ValidateSecurity(_unitOfWork.AttachmentRepository.GetSingle(a => a.Id == id, a => a.History));
        }
        /// <summary>
        /// get attachment by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Attachment.</returns>
        public async Task<Attachment> GetAttachmentByIdAsync(int id)
        {
            return ValidateSecurity(await _unitOfWork.AttachmentRepository.GetSingleAsync(a => a.Id == id, a => a.History));
        }

        /// <summary>
        /// Gets the attachment by URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>Attachment.</returns>
        public Attachment GetAttachmentByUrl(string url)
        {            
            var plainUrl = DelParamFromUrl(url, "sid");
            var result = _unitOfWork.AttachmentRepository.GetSingle(a => a.PathUrl == url, a => a.History);
            if (result != null && !result.IsSecured.GetValueOrDefault())
                return result;

            return ValidateSecurity(result, url);
        }
        /// <summary>
        /// get attachment by URL as an asynchronous operation.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>Attachment.</returns>
        public async Task<Attachment> GetAttachmentByUrlAsync(string url)
        {
            var plainUrl = DelParamFromUrl(url, "sid");
            var result = await _unitOfWork.AttachmentRepository.GetSingleAsync(a => a.PathUrl == url, a => a.History);
            if (!result.IsSecured.GetValueOrDefault())
                return result;

            return ValidateSecurity(result, url);
        }

        /// <summary>
        /// Gets the attachments by entity identifier.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>IList&lt;Attachment&gt;.</returns>
        public IList<Attachment> GetAttachmentsByEntityId(string entity, int id)
        {
            var tmp = _unitOfWork.AttachmentRepository.GetList(a => a.Object == entity && a.ObjectId == id, a => a.History);
            return tmp.Select(a => ValidateSecurity(a)).Where(a => a != null).ToList();
        }
        /// <summary>
        /// get attachments by entity identifier as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="id">The identifier.</param>
        /// <returns>IList&lt;Attachment&gt;.</returns>
        public async Task<IList<Attachment>> GetAttachmentsByEntityIdAsync(string entity, int id)
        {
            var tmp = await _unitOfWork.AttachmentRepository.GetListAsync(a => a.Object == entity && a.ObjectId == id, a => a.History);
            return tmp.Select(a => ValidateSecurity(a)).Where(a => a != null).ToList();
        }

        /// <summary>
        /// Adds the attachment.
        /// </summary>
        /// <param name="attachments">The attachments.</param>
        public void AddAttachment(params Attachment[] attachments)
        {
            PrepareToAdd(attachments);
            _unitOfWork.Save();
        }

        /// <summary>
        /// add attachment as an asynchronous operation.
        /// </summary>
        /// <param name="attachments">The attachments.</param>
        public async Task AddAttachmentAsync(params Attachment[] attachments)
        {
            PrepareToAdd(attachments);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Prepares to add.
        /// </summary>
        /// <param name="attachments">The attachments.</param>
        private void PrepareToAdd(params Attachment[] attachments)
        {
            List<AttachmentHistory> hist = new List<AttachmentHistory>();
            foreach (var attachment in attachments)
            {
                if (attachment.File != null)
                {
                    attachment.Length = attachment.File.ContentLength;
                    attachment.History = new List<AttachmentHistory>
                    {
                        new AttachmentHistory()
                        {
                            Attachment = attachment,
                            FileName = (attachment.File != null) ? attachment.File.FileName : string.Empty,
                            FilePath = attachment.PathUrl
                        }
                    };
                    _unitOfWork.AttachmentHistRepository.InitEntityData(attachment.History[0]);
                    hist.Add(attachment.History[0]);
                }

                attachment.StatusDate = DateTime.Now;
            }

            _unitOfWork.AttachmentRepository.Add(attachments);

            if (hist.Count > 0)
            {
                _unitOfWork.AttachmentHistRepository.Add(hist.ToArray());
            }
        }

        /// <summary>
        /// Updates the attachment.
        /// </summary>
        /// <param name="attachments">The attachments.</param>
        public void UpdateAttachment(params Attachment[] attachments)
        {
            PrepareToUpdate(attachments);
            _unitOfWork.Save();
        }

        /// <summary>
        /// update attachment as an asynchronous operation.
        /// </summary>
        /// <param name="attachments">The attachments.</param>
        public async Task UpdateAttachmentAsync(params Attachment[] attachments)
        {
            PrepareToUpdate(attachments);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Prepares to update.
        /// </summary>
        /// <param name="attachments">The attachments.</param>
        private void PrepareToUpdate(params Attachment[] attachments)
        {
            foreach (var attachment in attachments)
            {
                if (attachment.File != null)
                {
                    attachment.Length = attachment.File.ContentLength;
                    var histItem = new AttachmentHistory()
                    {
                        Attachment = attachment,
                        FileName = attachment.File.FileName,
                        FilePath = attachment.PathUrl
                    };
                    if (attachment.History == null)
                        attachment.History = new List<AttachmentHistory>();
                    attachment.History.Add(histItem);
                    _unitOfWork.AttachmentHistRepository.Add(histItem);
                }
            }
            _unitOfWork.AttachmentRepository.Update(attachments);
        }

        /// <summary>
        /// Removes the attachment.
        /// </summary>
        /// <param name="attachments">The attachments.</param>
        public void RemoveAttachment(params Attachment[] attachments)
        {
            PrepareToRemove(attachments);
            _unitOfWork.Save();
        }

        /// <summary>
        /// remove attachment as an asynchronous operation.
        /// </summary>
        /// <param name="attachments">The attachments.</param>
        public async Task RemoveAttachmentAsync(params Attachment[] attachments)
        {
            await PrepareToRemoveAsync(attachments);
            await _unitOfWork.SaveAsync();
        }

        /// <summary>
        /// Prepares to remove.
        /// </summary>
        /// <param name="attachments">The attachments.</param>
        private void PrepareToRemove(params Attachment[] attachments)
        {
            foreach (var attachment in attachments)
            {
                if (attachment != null && attachment.History != null && attachment.History.Count > 0)
                {
                    _unitOfWork.AttachmentHistRepository.Remove(attachment.History.ToArray());
                }
                var accessList = _unitOfWork.AttachmentAccessRepository.GetList(a => a.AttachmentId == attachment.Id);
                if(accessList != null && accessList.Any())
                    _unitOfWork.AttachmentAccessRepository.Remove(accessList.ToArray());
            }
            _unitOfWork.AttachmentRepository.Remove(attachments);
        }

        /// <summary>
        /// prepare to remove as an asynchronous operation.
        /// </summary>
        /// <param name="attachments">The attachments.</param>
        private async Task PrepareToRemoveAsync(params Attachment[] attachments)
        {
            foreach (var attachment in attachments)
            {
                if (attachment != null && attachment.History != null && attachment.History.Count > 0)
                {
                    _unitOfWork.AttachmentHistRepository.Remove(attachment.History.ToArray());
                }
                var accessList = await _unitOfWork.AttachmentAccessRepository.GetListAsync(a => a.AttachmentId == attachment.Id);
                if (accessList != null && accessList.Any())
                    _unitOfWork.AttachmentAccessRepository.Remove(accessList.ToArray());
            }
            _unitOfWork.AttachmentRepository.Remove(attachments);
        }

        /// <summary>
        /// Gets the attachment type by extension.
        /// </summary>
        /// <param name="extension">The extension.</param>
        /// <returns>System.String.</returns>
        public string GetAttachmentTypeByExtension(string extension)
        {
            var result = "None";
            if (string.IsNullOrEmpty(extension))
                return result;


            var ext = extension.ToLower();
            if (ext.StartsWith("."))
                ext = ext.Substring(1);

            switch (ext)
            {
                case "jpg":
                case "png":
                case "ico":
                case "bmp":
                case "gif":
                case "jpe":
                    result = "Photo";
                    break;
                case "mpeg":
                case "mp4":
                case "mov":
                    result = "Video";
                    break;
                case "txt":
                    result = "Text";
                    break;
                case "pdf":
                    result = "PDF";
                    break;
                default:
                    result = "File";
                    break;
            }
            return result;
        }

        /// <summary>
        /// Makes the attachment secured.
        /// </summary>
        /// <param name="attachmentId">The attachment identifier.</param>
        /// <param name="rollesAllowed">The rolles allowed.</param>
        public void MakeAttachmentSecured(int attachmentId, params string[] rollesAllowed)
        {
            var attachment = GetAttachmentById(attachmentId);
            if(attachment != null && (!attachment.IsSecured.HasValue || !attachment.IsSecured.Value))
            {
                attachment.IsSecured = true;
                if (rollesAllowed != null)
                    attachment.AllowedToRoles = string.Join(",", rollesAllowed);                
                _unitOfWork.AttachmentRepository.Update(attachment);
                _unitOfWork.Save();
            }
        }

        /// <summary>
        /// Makes the attachment unsecured.
        /// </summary>
        /// <param name="attachmentId">The attachment identifier.</param>
        public void MakeAttachmentUnsecured(int attachmentId)
        {
            var attachment = GetAttachmentById(attachmentId);
            if (attachment != null && attachment.IsSecured.HasValue && attachment.IsSecured.Value)
            {
                attachment.IsSecured = false;
                attachment.AllowedToRoles = null;                
                _unitOfWork.AttachmentRepository.Update(attachment);
                _unitOfWork.Save();
            }
        }

        /// <summary>
        /// Provisions the secured attachment.
        /// </summary>
        /// <param name="attachmentId">The attachment identifier.</param>
        /// <param name="forMinutes">For minutes.</param>
        /// <returns>System.String.</returns>
        public string ProvisionSecuredAttachment(int attachmentId, int forMinutes)
        {
            var result = string.Empty;
            var attachment = GetAttachmentById(attachmentId);
            if (attachment != null && attachment.IsSecured.HasValue && attachment.IsSecured.Value
                && (_unitOfWork.AttachmentAccessRepository.Count(a => a.AttachmentId == attachmentId && a.AccessTokenExpiresAt.HasValue && a.AccessTokenExpiresAt > DateTime.Now) == 0 ))
            {
                var access = new AttachmentAccess
                {
                    AttachmentId = attachmentId,
                    Name = "Access to attachment Id: " + attachmentId.ToString(),
                    PublicAccessToken = Guid.NewGuid().ToString(),
                    AccessTokenExpiresAt = DateTime.Now.AddMinutes(forMinutes),
                    EntityState = BAPEntityState.Added
                };
                _unitOfWork.AttachmentAccessRepository.Add(access);

                var sid = GenerateSaltedHash(access.PublicAccessToken, access.AccessTokenExpiresAt?.ToString());
                result = AddParamToUrl(attachment.PathUrl, "sid", sid);
                _unitOfWork.Save();
            }

            return result;
        }

        /// <summary>
        /// Stops the provisioning attachment.
        /// </summary>
        /// <param name="attachmentId">The attachment identifier.</param>
        public void StopProvisioningAttachment(int attachmentId)
        {
            var attachment = GetAttachmentById(attachmentId);
            if (attachment != null && attachment.IsSecured.HasValue && attachment.IsSecured.Value
                && (_unitOfWork.AttachmentAccessRepository.Count(a => a.AttachmentId == attachmentId && a.AccessTokenExpiresAt.HasValue && a.AccessTokenExpiresAt > DateTime.Now) > 0))
            {
                var accessList = _unitOfWork.AttachmentAccessRepository.GetList(a => a.AttachmentId == attachmentId && a.AccessTokenExpiresAt.HasValue && a.AccessTokenExpiresAt > DateTime.Now);
                if(accessList != null && accessList.Any())
                {
                    _unitOfWork.AttachmentAccessRepository.Remove(accessList.ToArray());
                    _unitOfWork.Save();
                }                
            }
        }

        /// <summary>
        /// make attachment secured as an asynchronous operation.
        /// </summary>
        /// <param name="attachmentId">The attachment identifier.</param>
        /// <param name="rollesAllowed">The rolles allowed.</param>
        public async Task MakeAttachmentSecuredAsync(int attachmentId, params string[] rollesAllowed)
        {
            var attachment = await GetAttachmentByIdAsync(attachmentId);
            if (attachment != null && (!attachment.IsSecured.HasValue || !attachment.IsSecured.Value))
            {
                attachment.IsSecured = true;
                if (rollesAllowed != null)
                    attachment.AllowedToRoles = string.Join(",", rollesAllowed);
                
                _unitOfWork.AttachmentRepository.Update(attachment);
                await _unitOfWork.SaveAsync();
            }
        }

        /// <summary>
        /// make attachment unsecured as an asynchronous operation.
        /// </summary>
        /// <param name="attachmentId">The attachment identifier.</param>
        public async Task MakeAttachmentUnsecuredAsync(int attachmentId)
        {
            var attachment = await GetAttachmentByIdAsync(attachmentId);
            if (attachment != null && attachment.IsSecured.HasValue && attachment.IsSecured.Value)
            {
                attachment.IsSecured = false;
                attachment.AllowedToRoles = null;                
                _unitOfWork.AttachmentRepository.Update(attachment);
                await _unitOfWork.SaveAsync();
            }
        }

        /// <summary>
        /// provision secured attachment as an asynchronous operation.
        /// </summary>
        /// <param name="attachmentId">The attachment identifier.</param>
        /// <param name="forMinutes">For minutes.</param>
        /// <returns>System.String.</returns>
        public async Task<string> ProvisionSecuredAttachmentAsync(int attachmentId, int forMinutes)
        {
            string result = string.Empty;
            var attachment = await GetAttachmentByIdAsync(attachmentId);
            if (attachment != null && attachment.IsSecured.HasValue && attachment.IsSecured.Value
                && (await _unitOfWork.AttachmentAccessRepository.CountAsync(a => a.AttachmentId == attachmentId && a.AccessTokenExpiresAt.HasValue && a.AccessTokenExpiresAt > DateTime.Now) == 0))
            {
                var access = new AttachmentAccess
                {
                    AttachmentId = attachmentId,
                    Name = "Access to attachment Id: " + attachmentId.ToString(),
                    PublicAccessToken = Guid.NewGuid().ToString(),
                    AccessTokenExpiresAt = DateTime.Now.AddMinutes(forMinutes),
                    EntityState = BAPEntityState.Added
                };
                _unitOfWork.AttachmentAccessRepository.Add(access);

                var sid = GenerateSaltedHash(access.PublicAccessToken, access.AccessTokenExpiresAt?.ToString());
                result = AddParamToUrl(attachment.PathUrl, "sid", sid);
                await _unitOfWork.SaveAsync();
            }

            return result;
        }

        /// <summary>
        /// stop provisioning attachment as an asynchronous operation.
        /// </summary>
        /// <param name="attachmentId">The attachment identifier.</param>
        public async Task StopProvisioningAttachmentAsync(int attachmentId)
        {
            var attachment = await GetAttachmentByIdAsync(attachmentId);
            if (attachment != null && attachment.IsSecured.HasValue && attachment.IsSecured.Value
                && (await _unitOfWork.AttachmentAccessRepository.CountAsync(a => a.AttachmentId == attachmentId && a.AccessTokenExpiresAt.HasValue && a.AccessTokenExpiresAt > DateTime.Now) > 0))
            {
                var accessList = await _unitOfWork.AttachmentAccessRepository.GetListAsync(a => a.AttachmentId == attachmentId && a.AccessTokenExpiresAt.HasValue && a.AccessTokenExpiresAt > DateTime.Now);
                if (accessList != null && accessList.Any())
                {
                    _unitOfWork.AttachmentAccessRepository.Remove(accessList.ToArray());
                    await _unitOfWork.SaveAsync();
                }
            }
        }

        /// <summary>
        /// Generates the salted hash.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="salt">The salt.</param>
        /// <returns>System.String.</returns>
        private string GenerateSaltedHash(string text, string salt)
        {
            byte[] byteText = Encoding.UTF8.GetBytes(text);
            byte[] byteSalt = Encoding.UTF8.GetBytes(salt);
            HashAlgorithm algorithm = new SHA256Managed();

            byte[] plainTextWithSaltBytes =
              new byte[byteText.Length + byteSalt.Length];

            for (int i = 0; i < byteText.Length; i++)
            {
                plainTextWithSaltBytes[i] = byteText[i];
            }
            for (int i = 0; i < byteSalt.Length; i++)
            {
                plainTextWithSaltBytes[byteText.Length + i] = byteSalt[i];
            }

            var byteHash = algorithm.ComputeHash(plainTextWithSaltBytes);
            return Convert.ToBase64String(byteHash);
        }

        /// <summary>
        /// Adds the parameter to URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="param">The parameter.</param>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        private string AddParamToUrl(string url, string param, string value)
        {
            if (string.IsNullOrEmpty(url) || string.IsNullOrEmpty(param) || string.IsNullOrEmpty(value) || url.Contains("?" + param + "=") || url.Contains("&" + param + "="))
                return url;

            var result = url;
            if (result.Contains("?") && result.IndexOf("?") != (result.Length - 1))
                result += "&";
            else if (!result.Contains("?"))
                result += "?";
            result += $"{param}={value}";
            return result;
        }
        /// <summary>
        /// Deletes the parameter from URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="param">The parameter.</param>
        /// <returns>System.String.</returns>
        private string DelParamFromUrl(string url, string param)
        {
            if (string.IsNullOrEmpty(url) || string.IsNullOrEmpty(param) || (!url.Contains("?" + param + "=") && !url.Contains("&" + param + "=")))
                return url;

            var startIndex = url.IndexOf("?" + param + "=");
            if(startIndex == -1)
                startIndex = url.IndexOf("&" + param + "=");
            var nextIndex = url.IndexOf("&", startIndex + 1);
            if (nextIndex > 0)
                url = url.Remove(startIndex, nextIndex - startIndex);
            else
                url = url.Substring(0, startIndex);
            return url;
        }

        /// <summary>
        /// Gets the parameter value.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="param">The parameter.</param>
        /// <returns>System.String.</returns>
        private string GetParamValue(string url, string param)
        {
            if (string.IsNullOrEmpty(url) || string.IsNullOrEmpty(param) || (!url.Contains("?" + param + "=") && !url.Contains("&" + param + "=")))
                return null;

            var result = "";
            var startIndex = url.IndexOf("?" + param + "=");
            if (startIndex == -1)
                startIndex = url.IndexOf("&" + param + "=");

            var nextIndex = url.IndexOf("&", startIndex + 1);
            if (nextIndex > 0)
                result = url.Substring(startIndex + ("?" + param + "=").Length, nextIndex - startIndex);
            else
                result = url.Substring(startIndex + ("?" + param + "=").Length);
            return result;
        }
    }
}
