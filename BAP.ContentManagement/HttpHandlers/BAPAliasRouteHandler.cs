// ***********************************************************************
// Assembly         : BAP.ContentManagement
// Author           : Victor Mamray
// Created          : 05-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="BAPAliasRouteHandler.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using BAP.Common;
using BAP.DAL;
using BAP.Log;

namespace BAP.ContentManagement.HttpHandlers
{
    /// <summary>
    /// Class BAPAliasRouteHandler.
    /// Implements the <see cref="System.Web.Routing.IRouteHandler" />
    /// </summary>
    /// <seealso cref="System.Web.Routing.IRouteHandler" />
    public class BAPAliasRouteHandler : IRouteHandler
    {
        /// <summary>
        /// The configuration helper
        /// </summary>
        IConfigHelper _configHelper;
        /// <summary>
        /// The authentication context
        /// </summary>
        IAuthorizationContext _authContext;
        /// <summary>
        /// The logger
        /// </summary>
        ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="BAPAliasRouteHandler"/> class.
        /// </summary>
        public BAPAliasRouteHandler()
        {
            _configHelper = DependencyResolver.Current.GetService<IConfigHelper>();
            _authContext = DependencyResolver.Current.GetService<IAuthorizationContext>();
            _logger = DependencyResolver.Current.GetService<ILogger>();                            
        }

        /// <summary>
        /// Provides the object that processes the request.
        /// </summary>
        /// <param name="requestContext">An object that encapsulates information about the request.</param>
        /// <returns>An object that processes the request.</returns>
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            var routeData = requestContext.RouteData.Values;
            var url = routeData["urlRouteHandler"] as string;            
            if(_configHelper != null && _authContext != null)
            {
                using (var cmsEngine = new CMSEngine(_configHelper, _authContext, _logger))
                {
                    var node = cmsEngine.FindNodeByAlias(url);
                    if (node != null && (node.NavigationType == DAL.Entities.NavigationType.MvcRoute || node.NavigationType == DAL.Entities.NavigationType.StaticHtml))
                    {
                        routeData["url"] = url;
                        routeData["controller"] = node.Controller;
                        routeData["action"] = node.Action;

                        //Simple implementation, assuming action has simple list of scalar input parameters
                        if (!string.IsNullOrEmpty(node.ActionParams))
                        {
                            var ps = JsonConvert.DeserializeObject(node.ActionParams);
                            if (ps != null && ps is JObject)
                            {
                                var jps = ps as JObject;
                                foreach (var item in jps)
                                {
                                    routeData[item.Key] = item.Value.ToString();
                                }
                            }
                        }

                        if (!node.Area.IsNullOrEmpty())
                            requestContext.RouteData.DataTokens.Add("area", node.Area);
                        if (!node.NameSpaces.IsNullOrEmpty())
                        {
                            var nss = node.NameSpaces.Split(",".ToCharArray());
                            if (requestContext.RouteData.DataTokens.ContainsKey("namespaces"))
                            {
                                var values = (string[])requestContext.RouteData.DataTokens["namespaces"];
                                if (values != null)
                                {
                                    var tmpList = new List<string>();
                                    tmpList.AddRange(values);
                                    foreach (var str in nss)
                                    {
                                        if (!tmpList.Any(a => a == str))
                                            tmpList.Add(str);
                                    }
                                    requestContext.RouteData.DataTokens["namespaces"] = tmpList.ToArray();
                                }
                                else
                                {
                                    requestContext.RouteData.DataTokens["namespaces"] = nss;
                                }
                            }
                            else
                            {
                                requestContext.RouteData.DataTokens.Add("namespaces", nss);
                            }
                        }
                    }
                }
                
            }           
            return new MvcHandler(requestContext);            
        }        
    }

    /// <summary>
    /// Class BAPAliasConstraint.
    /// Implements the <see cref="System.Web.Routing.IRouteConstraint" />
    /// </summary>
    /// <seealso cref="System.Web.Routing.IRouteConstraint" />
    public class BAPAliasConstraint : IRouteConstraint
    {
        /// <summary>
        /// The configuration helper
        /// </summary>
        IConfigHelper _configHelper;
        /// <summary>
        /// The authentication context
        /// </summary>
        IAuthorizationContext _authContext;
        /// <summary>
        /// The logger
        /// </summary>
        ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="BAPAliasConstraint"/> class.
        /// </summary>
        public BAPAliasConstraint()
        {
            _configHelper = DependencyResolver.Current.GetService<IConfigHelper>();
            _authContext = DependencyResolver.Current.GetService<IAuthorizationContext>();
            _logger = DependencyResolver.Current.GetService<ILogger>();            
        }

        /// <summary>
        /// Matches the specified HTTP context.
        /// </summary>
        /// <param name="httpContext">The HTTP context.</param>
        /// <param name="route">The route.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="values">The values.</param>
        /// <param name="routeDirection">The route direction.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (values != null && values.Keys != null && values.Keys.Contains("controller") && values["controller"] != null)
                return false;

            if(values[parameterName] != null && _configHelper != null && _authContext != null)
            {
                using (var cmsEngine = new CMSEngine(_configHelper, _authContext, _logger))
                {                    
                    var permalink = values[parameterName].ToString();
                    if (permalink == "" || permalink == "/")
                        return false;

                    return cmsEngine.AliasPresent(permalink);                    
                }                    
            }            
            return false;
        }
    }
}
