// ***********************************************************************
// Assembly         : BAP.Common
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-17-2020
// ***********************************************************************
// <copyright file="RestResponse.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using RestSharp;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BAP.Common.Rest
{
    /// <summary>
    /// Type of REST header enum
    /// </summary>
    public enum RestHeaderType
    {
        /// <summary>
        /// The cookie
        /// </summary>
        Cookie = 0,
        /// <summary>
        /// The get or post
        /// </summary>
        GetOrPost = 1,
        /// <summary>
        /// The URL segment
        /// </summary>
        UrlSegment = 2,
        /// <summary>
        /// The HTTP header
        /// </summary>
        HttpHeader = 3,
        /// <summary>
        /// The request body
        /// </summary>
        RequestBody = 4,
        /// <summary>
        /// The query string
        /// </summary>
        QueryString = 5
    }

    /// <summary>
    /// REST header class
    /// </summary>
    public class RestHeader
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public object Value { get; set; }
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        public RestHeaderType Type { get; set; }
        /// <summary>
        /// Gets or sets the type of the content.
        /// </summary>
        /// <value>The type of the content.</value>
        public string ContentType { get; set; }
    }

    /// <summary>
    /// Interface to indicate that response object holds headers
    /// </summary>
    public interface IRestResponseWithHeaders
    {
        /// <summary>
        /// Gets or sets the headers.
        /// </summary>
        /// <value>The headers.</value>
        IList<RestHeader> Headers { get; set; }
    }

    /// <summary>
    /// Interface to indicate that response object holds cookies
    /// </summary>
    public interface IRestResponseWithCookies
    {
        /// <summary>
        /// Gets or sets the cookies.
        /// </summary>
        /// <value>The cookies.</value>
        IList<RestResponseCookie> Cookies { get; set; }
    }

    /// <summary>
    /// Generic class to describe response object
    /// </summary>
    /// <typeparam name="T">Type of the class describing actual data returned by the REST call</typeparam>
    public class RestResponse<T> : IRestResponseWithHeaders, IRestResponseWithCookies where T : new()
    {

        /// <summary>
        /// True if REST call succeded
        /// </summary>
        /// <value><c>true</c> if success; otherwise, <c>false</c>.</value>
        [JsonProperty("success")]
        public bool Success { get; set; }

        /// <summary>
        /// Can be optionally assigned by the caller to identify REST call further
        /// </summary>
        /// <value>The process identifier.</value>
        [JsonProperty("processId")]
        public string ProcessId { get; set; }

        /// <summary>
        /// If failed, list of reasons why
        /// </summary>
        /// <value>The reasons.</value>
        [JsonProperty("reasons")]
        public List<RestResponseReason> Reasons { get; set; }

        /// <summary>
        /// Actual data returned, null if failed
        /// </summary>
        /// <value>The data.</value>
        public T Data { get; set; }

        /// <summary>
        /// List of HTTP headers returned by the server
        /// </summary>
        /// <value>The headers.</value>
        public IList<RestHeader> Headers { get; set; }

        /// <summary>
        /// List of cookies returned by the HTTP server
        /// </summary>
        /// <value>The cookies.</value>
        public IList<RestResponseCookie> Cookies { get; set; }
    }
}
