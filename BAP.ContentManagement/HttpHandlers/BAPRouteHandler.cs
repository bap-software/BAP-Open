// ***********************************************************************
// Assembly         : BAP.ContentManagement
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="BAPRouteHandler.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BAP.ContentManagement.HttpHandlers
{
    /// <summary>
    /// Class BAPRouteHandler.
    /// Implements the <see cref="System.Web.Routing.IRouteHandler" />
    /// </summary>
    /// <seealso cref="System.Web.Routing.IRouteHandler" />
    public class BAPRouteHandler : IRouteHandler
    {
        /// <summary>
        /// Provides the object that processes the request.
        /// </summary>
        /// <param name="requestContext">An object that encapsulates information about the request.</param>
        /// <returns>An object that processes the request.</returns>
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new BAPHttpHandler(requestContext);
        }        
    }

    /// <summary>
    /// Class BAPHttpHandler.
    /// Implements the <see cref="System.Web.IHttpHandler" />
    /// </summary>
    /// <seealso cref="System.Web.IHttpHandler" />
    public class BAPHttpHandler : IHttpHandler
    {
        /// <summary>
        /// The local request context
        /// </summary>
        private RequestContext _localRequestContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="BAPHttpHandler"/> class.
        /// </summary>
        /// <param name="requestContext">The request context.</param>
        public BAPHttpHandler(RequestContext requestContext)
        {
            _localRequestContext = requestContext;
        }

        /// <summary>
        /// Enables processing of HTTP Web requests by a custom <see langword="HttpHandler" /> that implements the <see cref="T:System.Web.IHttpHandler" /> interface.
        /// </summary>
        /// <param name="context">An <see cref="T:System.Web.HttpContext" /> object that provides references to the intrinsic server objects (for example, <see langword="Request" />, <see langword="Response" />, <see langword="Session" />, and <see langword="Server" />) used to service HTTP requests.</param>
        public void ProcessRequest(HttpContext context)
        {            
            try
            {
                var controllerName = _localRequestContext.RouteData.GetRequiredString("controller");
                var controller = ControllerBuilder.Current.GetControllerFactory().
                CreateController(_localRequestContext, controllerName);
                if (controller != null)
                {
                    controller.Execute(_localRequestContext);
                }
            }
            catch
            {
                _localRequestContext.HttpContext.Response.StatusCode = 404;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is reusable.
        /// </summary>
        /// <value><c>true</c> if this instance is reusable; otherwise, <c>false</c>.</value>
        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
}
