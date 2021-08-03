// ***********************************************************************
// Assembly         : BAP.eCommerce.UI
// Author           : Victor Mamray
// Created          : 05-30-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 07-08-2020
// ***********************************************************************
// <copyright file="BaseeCommerceController.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using BAP.BL;
using BAP.Common;
using BAP.DAL;
using BAP.eCommerce.BL.Context;
using BAP.Email;
using BAP.FileSystem;
using BAP.Log;
using BAP.Lookups;
using BAP.UI.Controllers;

namespace BAP.eCommerce.UI.Controllers
{
    /// <summary>
    /// Class BaseeCommerceController.
    /// Implements the <see cref="BAP.UI.Controllers.BaseController{T}" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="BAP.UI.Controllers.BaseController{T}" />
    public class BaseeCommerceController<T> : BaseController<T> where T : class, IBapEntity
    {
        /// <summary>
        /// The e context
        /// </summary>
        protected readonly IEcommerceContext _eContext;
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseeCommerceController{T}"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="configHelper">The configuration helper.</param>
        /// <param name="lookupEngine">The lookup engine.</param>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="mailer">The mailer.</param>
        /// <param name="fileProcessor">The file processor.</param>
        /// <param name="bl">The bl.</param>
        public BaseeCommerceController(ILogger logger,
          IConfigHelper configHelper,
          ILookupEngine lookupEngine,
          IAuthorizationContext context,
          IAuthorizationHelper<T> authHelper,
          IMailer mailer,
          IFileProcessor fileProcessor, BusinessLayer bl) 
            : base(logger, configHelper, lookupEngine, context, authHelper, mailer, fileProcessor, bl)
        {
            _eContext = new eCommerceContext(lookupEngine, fileProcessor, configHelper, context, logger);
            ViewBag.eCommerceContext = _eContext;            
        }

        /// <summary>
        /// Begins to invoke the action in the current controller context.
        /// </summary>
        /// <param name="callback">The callback.</param>
        /// <param name="state">The state.</param>
        /// <returns>Returns an IAsyncController instance.</returns>
        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            if (Session["Wishlist"] == null)
                Session["Wishlist"] = new List<int>();

            return base.BeginExecuteCore(callback, state);            
        }

        /// <summary>
        /// Action method to currently selected currency
        /// </summary>
        /// <param name="code">Currency code (e.g. EUR, USD)</param>
        /// <returns>ActionResult.</returns>
        [ContentManagement(allowed: false)]
        public ActionResult ChangeCurrency(string code)
        {
            var eContext = eCommerceContext.Instance;
            var thisCurrency = eContext?.Currencies.FirstOrDefault(a => a.ThreeLetterCode == code);
            if (thisCurrency != null)
                eContext.CurrentCurrency = thisCurrency;

            if (Request.UrlReferrer != null)
                return Redirect(Request.UrlReferrer.AbsolutePath);

            return View("Index");
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ((IDisposable)_eContext).Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
