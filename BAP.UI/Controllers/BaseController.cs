// ***********************************************************************
// Assembly         : BAP.UI
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="BaseController.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Collections.Generic;

using PagedList;
using Newtonsoft.Json.Linq;

using BAP.Common;
using BAP.Common.Exceptions;
using BAP.Lookups;
using BAP.Log;
using BAP.DAL;

using BAP.UI.Models;
using BAP.ContentManagement;
using BAP.DAL.Entities;
using BAP.Email;
using BAP.FileSystem;
using BAP.BL;
using System.IO;

namespace BAP.UI.Controllers
{
    /// <summary>
    /// Class MessageToHome.
    /// </summary>
    public class MessageToHome
    {
        /// <summary>
        /// Gets or sets the recaptcha response.
        /// </summary>
        /// <value>The recaptcha response.</value>
        public string RecaptchaResponse { get; set; }
        /// <summary>
        /// Gets or sets from name.
        /// </summary>
        /// <value>From name.</value>
        public string FromName { get; set; }
        /// <summary>
        /// Gets or sets from phone.
        /// </summary>
        /// <value>From phone.</value>
        public string FromPhone { get; set; }
        /// <summary>
        /// Gets or sets from email.
        /// </summary>
        /// <value>From email.</value>
        public string FromEmail { get; set; }
        /// <summary>
        /// Gets or sets from MSG.
        /// </summary>
        /// <value>From MSG.</value>
        public string FromMsg { get; set; }
    }

    /// <summary>
    /// Class BaseController.
    /// Implements the <see cref="System.Web.Mvc.Controller" />
    /// Implements the <see cref="BAP.ContentManagement.IContentExtendable" />
    /// Implements the <see cref="BAP.ContentManagement.IContentManagable" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="System.Web.Mvc.Controller" />
    /// <seealso cref="BAP.ContentManagement.IContentExtendable" />
    /// <seealso cref="BAP.ContentManagement.IContentManagable" />
    public class BaseController<T> : Controller, IContentExtendable, IContentManagable where T : class, IBapEntity
    {
        /// <summary>
        /// The logger
        /// </summary>
        protected readonly ILogger _logger;
        /// <summary>
        /// The configuration helper
        /// </summary>
        protected readonly IConfigHelper _configHelper;
        /// <summary>
        /// The lookup engine
        /// </summary>
        protected readonly ILookupEngine _lookupEngine;
        /// <summary>
        /// The authentication context
        /// </summary>
        protected readonly IAuthorizationContext _authContext;
        /// <summary>
        /// The authentication helper
        /// </summary>
        protected readonly IAuthorizationHelper<T> _authHelper;
        /// <summary>
        /// The current organization
        /// </summary>
        protected readonly Organization _currentOrganization;
        /// <summary>
        /// The CMS engine
        /// </summary>
        protected readonly CMSEngine _cmsEngine;
        /// <summary>
        /// The mailer
        /// </summary>
        protected readonly IMailer _mailer;
        /// <summary>
        /// The file processor
        /// </summary>
        protected readonly IFileProcessor _fileProcessor;
        /// <summary>
        /// The bl
        /// </summary>
        protected BusinessLayer _bl;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseController{T}"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="configHelper">The configuration helper.</param>
        /// <param name="lookupEngine">The lookup engine.</param>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        public BaseController(ILogger logger, IConfigHelper configHelper, ILookupEngine lookupEngine, IAuthorizationContext context, IAuthorizationHelper<T> authHelper)
            : this(logger, configHelper, lookupEngine, context, authHelper, new BusinessLayer(configHelper, context, logger))
        {        
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseController{T}"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="configHelper">The configuration helper.</param>
        /// <param name="lookupEngine">The lookup engine.</param>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="bl">The bl.</param>
        public BaseController(ILogger logger, IConfigHelper configHelper, ILookupEngine lookupEngine, IAuthorizationContext context, IAuthorizationHelper<T> authHelper, BusinessLayer bl)
        {
            _logger = logger;
            _configHelper = configHelper;
            _lookupEngine = lookupEngine;
            _authContext = context;
            _authHelper = authHelper;
            _currentOrganization = _authContext.GetCurrentOrganization(_configHelper);
            _cmsEngine = new CMSEngine(configHelper, context, logger);
            _bl = bl;

            ViewBag.LookupEngineInstance = lookupEngine;
            ViewBag.ConfigHelperInstance = configHelper;
            ViewBag.AuthContextInstance = context;
            ViewBag.CmsContextInstance = _cmsEngine;
            ViewBag.DefaultPageSize = _configHelper.DefaultPageSize;
            ViewBag.BusinessLayer = _bl;            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseController{T}"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="configHelper">The configuration helper.</param>
        /// <param name="lookupEngine">The lookup engine.</param>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="mailer">The mailer.</param>
        /// <param name="fileProcessor">The file processor.</param>
        /// <param name="bl">The bl.</param>
        public BaseController(ILogger logger, IConfigHelper configHelper, ILookupEngine lookupEngine, IAuthorizationContext context, IAuthorizationHelper<T> authHelper,
          IMailer mailer, IFileProcessor fileProcessor, BusinessLayer bl = null) 
          : this(logger, configHelper, lookupEngine, context, authHelper, bl)
        {
            if (bl == null)
                _bl = new BusinessLayer(configHelper, context, logger);

            _mailer = mailer;
            _fileProcessor = fileProcessor;
        }

        /// <summary>
        /// Indexes all.
        /// </summary>
        /// <param name="sort">The sort.</param>
        /// <param name="filter">The filter.</param>
        /// <returns>ActionResult.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual ActionResult IndexAll(string sort = "", string filter = "")
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Serves custom content returned by any controller derived from this basic one.
        /// It also returns virtual static files content as is.
        /// </summary>
        /// <param name="view">[Optional]If provided, this particular view will be used.</param>
        /// <param name="parameters">[Optional]Set of extra parameters which may be used by the view code. Passed as ViewBag dynamic.</param>
        /// <returns>ActionResult.</returns>
        public virtual ActionResult Content(string view = "", object[] parameters = null)
        {
            var node = CMSContext.FindNodeByAlias(this.Request.Path);
            if(node != null)
            {
                if(node.NavigationType == NavigationType.StaticHtml)
                {
                    var viewObj = node.Views.FirstOrDefault();
                    if (viewObj != null)
                    {
                        var fileInfo = new FileInfo(this.Request.Path);
                        var stream = new MemoryStream();
                        var writer = new StreamWriter(stream);
                        writer.Write(viewObj.ViewContent);
                        writer.Flush();
                        stream.Position = 0;
                        return new FileStreamResult(stream, FileProcessorBase.GetMimeType(fileInfo.Extension));
                    }
                } 
                else if(node.NavigationType == NavigationType.MvcRoute && (node.Views == null || !node.Views.Any()))
                {
                    return View(node.View);
                }                
            }

            ViewBag.Parameters = parameters;                
            return View(view);
        }

        /// <summary>
        /// Gets the size of the real page.
        /// </summary>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>System.Int32.</returns>
        protected int GetRealPageSize(int? pageSize)
        {
            if (pageSize == null || pageSize.Value < 1)
            {
                pageSize = _configHelper.FakeMaxPageSize;
                EntityPagingAttribute pageAttr = (EntityPagingAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(EntityPagingAttribute));
                if (pageAttr != null && pageAttr.Applied && pageAttr.PageSize > 0)
                {
                    pageSize = pageAttr.PageSize;
                }

            }

            return pageSize.Value;
        }

        /// <summary>
        /// Gets the CMS context.
        /// </summary>
        /// <value>The CMS context.</value>
        public CMSEngine CMSContext
        {
            get
            {
                return _cmsEngine;
            }
        }

        /// <summary>
        /// Registers the subscriber.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterSubscriber(string email)
        {
            ISubscriberBL subscriberBL = (ISubscriberBL)_bl;
            var subscriber = new Subscriber
            {
                Email = email,
                RegisterDate = DateTime.Now,
                Enabled = true,
                PublicId = Guid.NewGuid()
            };
            subscriberBL.AddSubscriber(subscriber);
            ClientNotify(string.Format(Resources.Resources.UIText_ThanksRegisteringNewsletters, email), Resources.Resources.EntityLabel_NewsLetter);
            if (Request.UrlReferrer != null)
                return Redirect(Request.UrlReferrer.AbsolutePath);
            return View("Index");
        }

        /// <summary>
        /// Sends the email.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        [AllowAnonymous]
        public ActionResult SendEmail(MessageToHome message)
        {
            string error = string.Empty;
            if (message == null)
            {
                error = Resources.Resources.ErrorText_NoEmailRequest;
            }
            else if (_mailer == null)
            {
                error = Resources.Resources.ErrorText_NoMailServiceConfigured;
            }
            else
            {
                try
                {
                    //send email
                    var subject = Resources.Resources.CodeText_ContactVia + " " + _authContext.GetCurrentOrganization(_configHelper).Name + @" " + Resources.Resources.CodeText_From + @" " + message.FromName + " (" + message.FromEmail + ", " + message.FromPhone + ")";
                    ValidateReCaptcha(message.RecaptchaResponse);
                    _mailer.SendEmail(message.FromEmail, Resources.Resources.UIText_ContactEmail, subject, message.FromMsg);
                    
                    //save message to db
                    var messageBl = (IMessageBL)_bl;
                    messageBl.AddMessage(new Message { 
                        FromAddress = message.FromEmail,
                        ToAddress = Resources.Resources.UIText_ContactEmail,
                        Subject = subject,
                        Body = message.FromMsg,
                        Object = "Organization",
                        ObjectId = _currentOrganization.Id,
                        Sent = true,
                        SentDate = DateTime.Now
                    });
                }
                catch (Exception exc)
                {
                    _logger.LogException(@"Home", @"SendEmail", exc);
                    error = Resources.Resources.ErrorText_GeneralCannotSendEmail;
                }
            }

            if (!string.IsNullOrEmpty(error))
                _logger.LogError(@"Home", @"SendEmail", error);

            return Json(new { success = string.IsNullOrEmpty(error), error });
        }

        /// <summary>
        /// Files the specified path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="isAdmin">if set to <c>true</c> [is admin].</param>
        /// <returns>FileStreamResult.</returns>
        /// <exception cref="HttpException"></exception>
        [AllowAnonymous]
        public FileStreamResult File(string path, bool isAdmin = false)
        {
            if (_fileProcessor == null)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, Resources.Resources.UIText_FileSystemNotConfigured);
            }

            var fs = _fileProcessor.GetFile(path, isAdmin);
            if (fs.FileStream != null)
            {
                Response.AddHeader("Content-Disposition", "inline; filename=" + fs.FileName);
                return File(fs.FileStream, fs.MimeType);
            }
            else
            {
#if !DEBUG
                throw new HttpException((int)HttpStatusCode.NotFound, string.Format(Resources.Resources.UIText_FilePathNotFound, path));
#else
                return null;
#endif
            }
        }

        /// <summary>
        /// Files for admin.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>FileStreamResult.</returns>
        /// <exception cref="HttpException"></exception>
        /// <exception cref="HttpException"></exception>
        [Authorize(Roles = "Administrator,ContentManager")]
        public FileStreamResult FileForAdmin(string path)
        {
            if (_fileProcessor == null)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, Resources.Resources.UIText_FileSystemNotConfigured);
            }

            var fs = _fileProcessor.GetFile(path, true);
            if (fs.FileStream != null)
            {
                Response.AddHeader("Content-Disposition", "inline; filename=" + fs.FileName);
                return File(fs.FileStream, fs.MimeType);
            }
            else
            {
                throw new HttpException((int)HttpStatusCode.NotFound, string.Format(Resources.Resources.UIText_FilePathNotFound, path));
            }
        }

        /// <summary>
        /// Gets the attachment by identifier.
        /// </summary>
        /// <param name="attachmentId">The attachment identifier.</param>
        /// <returns>FileStreamResult.</returns>
        /// <exception cref="HttpException"></exception>
        /// <exception cref="HttpException"></exception>
        /// <exception cref="HttpException"></exception>
        public FileStreamResult GetAttachmentById(int? attachmentId)
        {
            if (_fileProcessor == null)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, Resources.Resources.UIText_FileSystemNotConfigured);
            }
            if (attachmentId == null)
            {
                throw new HttpException((int)HttpStatusCode.NotFound, Resources.Resources.UIText_FileNotFound);
            }

            var fs = _fileProcessor.GetAttachmentFileById(attachmentId.Value);
            if (fs.FileStream != null)
            {
                return File(fs.FileStream, fs.MimeType, fs.FileName);
            }
            else
            {
                throw new HttpException((int)HttpStatusCode.NotFound, Resources.Resources.UIText_FileNotFound);
            }
        }

        /// <summary>
        /// Action method to change UI language
        /// </summary>
        /// <param name="lng">Culture name. Is not used here but used by BaseController class in order to change application current culture.</param>
        /// <returns>ActionResult.</returns>
        [AllowAnonymous]
        [ContentManagement(allowed: false)]        
        public ActionResult ChangeLanguage(string lng)
        {
            if (Request.UrlReferrer != null)
                return Redirect(Request.UrlReferrer.OriginalString);

            return View("Index");
        }

        /// <summary>
        /// Initializes the index view data.
        /// </summary>
        /// <param name="sortOrder">The sort order.</param>
        /// <param name="currentFilter">The current filter.</param>
        protected void InitIndexViewData(string sortOrder, string currentFilter)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.CurrentFilter = currentFilter;
            ViewBag.SortData = InitSortData(ViewBag.CurrentSort);
        }

        /// <summary>
        /// Gets the view model.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="dataList">The data list.</param>
        /// <param name="pagedList">The paged list.</param>
        /// <returns>BAPViewModel&lt;T&gt;.</returns>
        protected BAPViewModel<T> GetViewModel(T entity = null, IEnumerable<T> dataList = null, IPagedList<T> pagedList = null)
        {
            var viewModel = new BAPViewModel<T>();
            viewModel.AuthContext = _authContext;
            viewModel.ConfigHelper = _configHelper;
            viewModel.Logger = _logger;
            viewModel.LookupEngine = _lookupEngine;
            viewModel.AuthHelper = _authHelper;

            viewModel.Entity = entity;
            viewModel.DataList = dataList;
            viewModel.PagedList = pagedList;

            return viewModel;
        }

        /// <summary>
        /// Determines whether this instance can read the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if this instance can read the specified entity; otherwise, <c>false</c>.</returns>
        protected bool CanRead(T entity = null)
        {
            return _authHelper.IsAllowedToRead(entity);
        }

        /// <summary>
        /// Determines whether this instance can write the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if this instance can write the specified entity; otherwise, <c>false</c>.</returns>
        protected bool CanWrite(T entity = null)
        {
            return _authHelper.IsAllowedToWrite(entity);
        }

        /// <summary>
        /// Determines whether this instance can delete the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if this instance can delete the specified entity; otherwise, <c>false</c>.</returns>
        protected bool CanDelete(T entity = null)
        {
            return _authHelper.IsAllowedToDelete(entity);
        }

        /// <summary>
        /// Begins to invoke the action in the current controller context.
        /// </summary>
        /// <param name="callback">The callback.</param>
        /// <param name="state">The state.</param>
        /// <returns>Returns an IAsyncController instance.</returns>
        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {

            string[] cultures = _currentOrganization.ImplementedCultures;
            var cultureHelper = new CultureHelper(cultures);
            if (cultures != null && cultures.Length > 0)
            {
                string cultureName = null;
                if (cultures.Length == 1)
                {
                    cultureName = cultureHelper.GetImplementedCulture(cultures[0]);
                }
                else
                {
                    string cultureCookieName = _currentOrganization.Name.Replace(" ", "_") + @"_culture";
                    // Attempt to read the culture cookie from Request
                    HttpCookie cultureCookie = Request.Cookies[cultureCookieName];
                    if (!string.IsNullOrEmpty(Request[@"lng"]))
                    {
                        cultureName = cultureHelper.GetImplementedCulture(Request[@"lng"]);
                        cultureCookie = null;
                    }
                    else if (cultureCookie != null)
                        cultureName = cultureCookie.Value;
                    else
                        cultureName = Request.UserLanguages != null && Request.UserLanguages.Length > 0 ?
                                Request.UserLanguages[0] :  // obtain it from HTTP header AcceptLanguages
                                null;
                    // Validate culture name
                    cultureName = cultureHelper.GetImplementedCulture(cultureName); // This is safe

                    if (cultureCookie == null)
                    {
                        cultureCookie = new HttpCookie(cultureCookieName, cultureName);
                        Response.SetCookie(cultureCookie);
                    }
                }


                // Modify current thread's cultures            
                if (!string.IsNullOrEmpty(cultureName))
                {
                    Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultureName);
                    Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
                }
            }
            return base.BeginExecuteCore(callback, state);
        }

        /// <summary>
        /// Gets the controller by entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>System.String.</returns>
        public static string GetControllerByEntity(string entity)
        {
            string result;
            if (entity == "Property")
                result = "Property";
            else if (entity.EndsWith("y"))
                result = entity.Substring(0, entity.Length - 2) + "ies";
            else
                result = entity + "s";

            return result;
        }

        /// <summary>
        /// Called when an unhandled exception occurs in the action.
        /// </summary>
        /// <param name="filterContext">Information about the current request and action.</param>
        protected override void OnException(ExceptionContext filterContext)
        {
            if (_logger != null)
            {
                var eventId = _logger.LogException("BaseController", "OnException", filterContext.Exception);
                if(this.Session != null)
                    this.Session["LAST_EVENT_ID"] = eventId;
            }

            base.OnException(filterContext);

        }

        /// <summary>
        /// Validates the re captcha.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <exception cref="BAPreCaptchaException"></exception>
        /// <exception cref="BAPreCaptchaException"></exception>
        protected virtual void ValidateReCaptcha(string response = "")
        {
            var captchaResponse = response;
            if (string.IsNullOrEmpty(captchaResponse) && Request != null)
                captchaResponse = Request["g-recaptcha-response"];
            if (string.IsNullOrEmpty(captchaResponse))
                throw new BAPreCaptchaException();


            string secretKey = _currentOrganization.reCaptchaSecretKey;
            var client = new WebClient();
            var result = client.DownloadString(string.Format(_configHelper.reCaptchaValidateUrl, secretKey, captchaResponse));
            var obj = JObject.Parse(result);
            var status = (bool)obj.SelectToken("success");

            if (!status)
                throw new BAPreCaptchaException();
        }

        /// <summary>
        /// Clients the notify.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="title">The title.</param>
        protected virtual void ClientNotify(string message, string title = "")
        {
            TempData["NotificationMessage"] = message;
            if (!string.IsNullOrEmpty(title))
                TempData["NotificationTitle"] = title;
        }

        /// <summary>
        /// Initializes the sort data.
        /// </summary>
        /// <param name="currSortOrder">The curr sort order.</param>
        /// <returns>Dictionary&lt;System.String, System.String&gt;.</returns>
        protected virtual Dictionary<string, string> InitSortData(string currSortOrder)
        {
            var dict = new Dictionary<string, string>();
            var direction = "asc";
            var field = "";
            if (!string.IsNullOrEmpty(currSortOrder) && currSortOrder.Contains("-"))
            {
                var arr = currSortOrder.Split("-".ToCharArray());
                field = arr[0];
                direction = arr[1];
            }

            var properties = typeof(T).GetProperties().Where(prop => prop.IsDefined(typeof(SortingFieldAttribute), false));
            foreach (var property in properties)
            {
                SortingFieldAttribute sortAttr = (SortingFieldAttribute)Attribute.GetCustomAttribute(property, typeof(SortingFieldAttribute));
                if (sortAttr != null)
                {
                    if (sortAttr.AllowAscending && sortAttr.AllowDescending)
                        dict.Add(property.Name, (field == property.Name && direction == "asc") ? "desc" : "asc");
                    else if (sortAttr.AllowAscending)
                        dict.Add(property.Name, "asc");
                    else if (sortAttr.AllowDescending)
                        dict.Add(property.Name, "desc");
                }
            }

            return dict;
        }

        /// <summary>
        /// The tokens
        /// </summary>
        private static volatile Dictionary<int, List<string>> tokens;
        /// <summary>
        /// The synchronize root
        /// </summary>
        private static object syncRoot = new Object();

        /// <summary>
        /// Adds the post token.
        /// </summary>
        /// <param name="entityId">The entity identifier.</param>
        /// <param name="token">The token.</param>
        protected void AddPostToken(int entityId, string token)
        {
            if (tokens == null)
            {
                lock (syncRoot)
                {
                    if (tokens == null)
                        tokens = new Dictionary<int, List<string>>();
                }
            }

            if (!tokens.ContainsKey(entityId))
            {
                lock (syncRoot)
                {
                    if (!tokens.ContainsKey(entityId))
                    {
                        tokens.Add(entityId, new List<string>());
                    }
                }
            }

            lock (syncRoot)
            {
                tokens[entityId].Add(token);
            }
        }

        /// <summary>
        /// Determines whether [is post token present] [the specified entity identifier].
        /// </summary>
        /// <param name="entityId">The entity identifier.</param>
        /// <param name="token">The token.</param>
        /// <returns><c>true</c> if [is post token present] [the specified entity identifier]; otherwise, <c>false</c>.</returns>
        protected bool IsPostTokenPresent(int entityId, string token)
        {
            bool result = false;
            lock (syncRoot)
            {
                result = tokens != null && tokens.ContainsKey(entityId) && tokens[entityId].Any(a => a == token);
            }
            return result;
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if(_bl != null)
                    ((IDisposable)_bl).Dispose();
                if (_cmsEngine != null)
                    _cmsEngine.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}