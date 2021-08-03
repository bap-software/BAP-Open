// ***********************************************************************
// Assembly         : BAP.Common
// Author           : Victor Mamray
// Created          : 07-26-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-17-2020
// ***********************************************************************
// <copyright file="BAPRestClientBase.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Collections.Generic;

using RestSharp;
using Newtonsoft.Json;

using BAP.Log;

namespace BAP.Common.Rest
{
    /// <summary>
    /// Base REST client class used by BAP, RestSharp Nuget based
    /// </summary>
    public class BAPRestClientBase : BAPBaseClassWithLogging
    {
        /// <summary>
        /// The base URL
        /// </summary>
        protected string _baseUrl = "";
        /// <summary>
        /// The configuration helper
        /// </summary>
        protected readonly IConfigHelper _configHelper;


        /// <summary>
        /// Initializes a new instance of the <see cref="BAPRestClientBase"/> class.
        /// </summary>
        /// <param name="configHelper">The configuration helper.</param>
        /// <param name="logger">The logger.</param>
        public BAPRestClientBase(IConfigHelper configHelper, ILogger logger)
            : base(logger)
        {            
            _configHelper = configHelper;            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BAPRestClientBase"/> class.
        /// </summary>
        /// <param name="configHelper">The configuration helper.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="baseUrl">The base URL.</param>
        public BAPRestClientBase(IConfigHelper configHelper, ILogger logger, string baseUrl) 
            : base(logger)
        {         
            _configHelper = configHelper;
            _baseUrl = baseUrl;
        }

        /// <summary>
        /// Base URL of the REST API used
        /// </summary>
        /// <value>The base URL.</value>
        public string BaseUrl
        {
            get
            {
                return _baseUrl;
            }
            set
            {
                _baseUrl = value;
            }
        }

        /// <summary>
        /// Indicates whether to use latest version of TLS, 1.3 is max version currently applied
        /// </summary>
        /// <value><c>true</c> if [need new SSL version]; otherwise, <c>false</c>.</value>
        public bool NeedNewSSLVersion { get; set; } = false;


        /// <summary>
        /// Extra authentication activity can be performed by ancestors
        /// </summary>
        /// <param name="request">The request.</param>
        protected virtual void ApplyAutehntication(RestRequest request)
        {
        }

        /// <summary>
        /// Does the rest request.
        /// </summary>
        /// <typeparam name="TU">The type of the u.</typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestObj">The request object.</param>
        /// <param name="baseUrl">The base URL.</param>
        /// <param name="webMethod">The web method.</param>
        /// <param name="httpMethod">The HTTP method.</param>
        /// <param name="headers">The headers.</param>
        /// <param name="cookies">The cookies.</param>
        /// <param name="formData">The form data.</param>
        /// <returns>RestResponse&lt;T&gt;.</returns>
        /// <exception cref="Exception">Failed to make REST request, with code {response.StatusCode}
        /// or
        /// Server returned no response</exception>
        protected RestResponse<T> DoRestRequest<TU, T>(TU requestObj, string baseUrl, string webMethod, string httpMethod = HttpMethod.Get, IList<RestHeader> headers = null, IList<RequestCookie> cookies = null, IList<Parameter> formData = null)
            where T : new()
        {
            RestResponse<T> result = new RestResponse<T>()
            {
                Success = true
            };

            
            try
            {
                WriteRequestToLog(requestObj != null ? JsonConvert.SerializeObject(requestObj) : "", baseUrl, webMethod, httpMethod, headers, cookies);

                if (!string.IsNullOrEmpty(baseUrl) && !baseUrl.EndsWith("/"))
                    BaseUrl += "/";

                if (!string.IsNullOrEmpty(webMethod) && webMethod.StartsWith("/"))
                    webMethod = webMethod.Substring(1);

                var request = GetRestRequest(webMethod, httpMethod, headers, cookies);

                string requestString = null;
                if (requestObj != null)
                {
                    requestString = JsonConvert.SerializeObject(requestObj, Formatting.None,
                        new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                    request.AddParameter("application/json", requestString, ParameterType.RequestBody);
                }
                
                if(formData != null && formData.Any())
                {
                    var requestBody = "";
                    foreach(var p in formData)
                    {
                        if (!string.IsNullOrEmpty(requestBody))
                            requestBody = requestBody + "&";
                        requestBody += $"{p.Name}={p.Value}";                        
                    }

                    request.AddHeader("content-type", "application/x-www-form-urlencoded");
                    request.AddParameter("application/x-www-form-urlencoded", requestBody, ParameterType.RequestBody);                  
                }


                var client = GetRestClient(baseUrl);
                var response = client.Execute(request);

                PopulateHeadersToResult(response, result);
                PopulateCookiesToResult(response, result);

                var logRequest = new LogRequest
                {
                    Url = baseUrl + webMethod,
                    Cookies = cookies,
                    Headers = headers,
                    RequestBody = requestString
                };

                CheckResponse<TU, T>(logRequest, response, result);                    
            }
            catch (Exception exc)
            {
                result.Success = false;
                result.Reasons = new List<RestResponseReason>
                {
                    new RestResponseReason {Code = "0001", Message = exc.Message}
                };
                if (_logger != null)
                {
                    var errorMessage = string.Format("Error colling DoRestRequest of {0}.", baseUrl + webMethod);
                    LogException(new Exception(errorMessage, exc));
                }

            }
           
            return result;
        }

        /// <summary>
        /// Does the rest request asynchronous.
        /// </summary>
        /// <typeparam name="TU">The type of the u.</typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestObj">The request object.</param>
        /// <param name="baseUrl">The base URL.</param>
        /// <param name="webMethod">The web method.</param>
        /// <param name="httpMethod">The HTTP method.</param>
        /// <param name="headers">The headers.</param>
        /// <param name="cookies">The cookies.</param>
        /// <returns>RestResponse&lt;T&gt;.</returns>
        protected async Task<RestResponse<T>> DoRestRequestAsync<TU, T>(TU requestObj, string baseUrl, string webMethod, string httpMethod = "GET", IList<RestHeader> headers = null, IList<RequestCookie> cookies = null) where T : new()
        {
            RestResponse<T> result = new RestResponse<T>
            {
                Success = true
            };
            
            try
            {
                WriteRequestToLog(requestObj != null ? JsonConvert.SerializeObject(requestObj) : "", baseUrl, webMethod, httpMethod, headers, cookies);

                if (!string.IsNullOrEmpty(baseUrl) && !baseUrl.EndsWith("/"))
                    BaseUrl += "/";

                if (!string.IsNullOrEmpty(webMethod) && webMethod.StartsWith("/"))
                    webMethod = webMethod.Substring(1);

                var request = GetRestRequest(webMethod, httpMethod, headers, cookies);

                string requestString = null;
                if (requestObj != null)
                {
                    requestString = JsonConvert.SerializeObject(requestObj, Formatting.None,
                        new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                    request.AddParameter("application/json", requestString, ParameterType.RequestBody);
                }

                var client = GetRestClient(baseUrl);

                var response = await client.ExecuteTaskAsync(request);

                PopulateHeadersToResult(response, result);
                PopulateCookiesToResult(response, result);

                var logRequest = new LogRequest
                {
                    Url = baseUrl + webMethod,
                    Cookies = cookies,
                    Headers = headers,
                    RequestBody = requestString
                };

                CheckResponse<TU, T>(logRequest, response, result);                    
            }
            catch (Exception exc)
            {
                result.Success = false;
                result.Reasons = new List<RestResponseReason>
                {
                    new RestResponseReason {Code = "0001", Message = exc.Message}
                };
                LogException(exc);
            }           

            return result;
        }


        /// <summary>
        /// Check response of the REST API call
        /// </summary>
        /// <typeparam name="TU">The type of the tu.</typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="logRequest">Object to log</param>
        /// <param name="response">API call response object</param>
        /// <param name="result">If true, allowed to retry one more time</param>
        /// <exception cref="Exception"></exception>
        /// <exception cref="Exception">Server returned no response</exception>
        private void CheckResponse<TU, T>(LogRequest logRequest, IRestResponse response, RestResponse<T> result) where T : new()
        {            
            if (response != null)
            {                                
                switch (response.StatusCode)
                {
                    case HttpStatusCode.NoContent:
                        break;
                    case HttpStatusCode.OK:
                        result.Data = JsonConvert.DeserializeObject<T>(response.Content);
                        break;
                    default:
                        var headerText = "";
                        if (response.Headers != null && response.Headers.Any())
                        {
                            foreach (var header in response.Headers)
                            {
                                headerText += header.Name + "=" + header.Value + "\r\n";
                            }
                        }
                        var errorMessage = $"Failed to make REST request, with status: {response.StatusCode}:'{response.StatusDescription}', message: '{response.ErrorMessage}', content type: '{response.ContentType}', content: '{response.Content}'.";
                        if (!string.IsNullOrEmpty(headerText))
                            errorMessage += "\r\nResponse headers:\r\n" + headerText;
                        throw new Exception(errorMessage, response.ErrorException);
                }                
            }

            var logRequestSerialized = JsonConvert.SerializeObject(logRequest, Formatting.None,
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            LogDebug($"Server response is {logRequestSerialized}");

            if (response == null)
            {
                throw new Exception("Server returned no response");
            }            
        }

        /// <summary>
        /// Gets the rest client.
        /// </summary>
        /// <param name="baseUrl">The base URL.</param>
        /// <returns>RestClient.</returns>
        private RestClient GetRestClient(string baseUrl)
        {
            //Setting up new version of SSL
            if (NeedNewSSLVersion)
                ServicePointManager.SecurityProtocol =
                    SecurityProtocolType.Tls13 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            var client = new RestClient { BaseUrl = new Uri(baseUrl) };            
            var proxyHost = _configHelper.ReadString("RestApi.Proxy.Host");
            if (!string.IsNullOrEmpty(proxyHost))
            {
                var port = _configHelper.ReadInt("RestApi.Proxy.Port", 80);
                client.Proxy = new WebProxy(proxyHost, port);
            }

            return client;
        }

        /// <summary>
        /// Gets the rest request.
        /// </summary>
        /// <param name="webMethod">The web method.</param>
        /// <param name="httpMethod">The HTTP method.</param>
        /// <param name="headers">The headers.</param>
        /// <param name="cookies">The cookies.</param>
        /// <returns>RestRequest.</returns>
        private RestRequest GetRestRequest(string webMethod, string httpMethod, IList<RestHeader> headers, IList<RequestCookie> cookies)
        {
            var method = Method.GET;
            switch (httpMethod.ToUpper())
            {
                case "GET":
                    method = Method.GET;
                    break;
                case "POST":
                    method = Method.POST;
                    break;
                case "PUT":
                    method = Method.PUT;
                    break;
                case "DELETE":
                    method = Method.DELETE;
                    break;
            }

            var request = new RestRequest(method) { Resource = webMethod };
            ApplyAutehntication(request);

            if (headers != null && headers.Count > 0)
            {
                foreach (var header in headers)
                {
                    request.AddHeader(header.Name, header.Value.ToString());
                }
            }

            if (cookies != null && cookies.Count > 0)
            {
                foreach (var cookie in cookies)
                {
                    request.AddCookie(cookie.name, cookie.value);
                }
            }

            return request;
        }

        /// <summary>
        /// Populates the headers to result.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <param name="result">The result.</param>
        private void PopulateHeadersToResult(IRestResponse response, IRestResponseWithHeaders result)
        {
            if (response == null || result == null || response.Headers == null || response.Headers.Count == 0)
                return;

            if (result.Headers == null)
                result.Headers = new List<RestHeader>();

            foreach (var header in response.Headers)
            {
                result.Headers.Add(new RestHeader
                {
                    ContentType = header.ContentType,
                    Name = header.Name,
                    Type = (RestHeaderType)((int)header.Type), //explicit conversion via int
                    Value = header.Value
                });
            }
        }

        /// <summary>
        /// Populates the cookies to result.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <param name="result">The result.</param>
        private void PopulateCookiesToResult(IRestResponse response, IRestResponseWithCookies result)
        {
            if (response == null || result == null || response.Cookies == null || response.Cookies.Count == 0)
                return;

            if (result.Cookies == null)
                result.Cookies = new List<RestResponseCookie>();

            foreach (var cookie in response.Cookies)
            {
                result.Cookies.Add(cookie);
            }
        }

        /// <summary>
        /// Writes the request to log.
        /// </summary>
        /// <param name="requestObj">The request object.</param>
        /// <param name="baseUrl">The base URL.</param>
        /// <param name="webMethod">The web method.</param>
        /// <param name="httpMethod">The HTTP method.</param>
        /// <param name="headers">The headers.</param>
        /// <param name="cookies">The cookies.</param>
        private void WriteRequestToLog(string requestObj, string baseUrl, string webMethod, string httpMethod = "GET", IList<RestHeader> headers = null, IList<RequestCookie> cookies = null)
        {
            string message = string.Format("BAPRestClientBase received the following request: BaseUrl = '{0}', WebMethod = '{1}', HTTPMethod = '{2}'", baseUrl, webMethod, httpMethod);
            if (!string.IsNullOrEmpty(requestObj))
            {
                message += "\r\nRequest Object:\r\n" + requestObj + "\r\n";
            }

            if (headers != null && headers.Count > 0)
            {
                message += "\r\nHeaders:\r\n";
                foreach (var header in headers)
                {
                    message += string.Format("{0} = {1}\r\n", header.Name, header.Value);
                }

            }
            if (cookies != null && cookies.Count > 0)
            {
                message += "\r\nCookies:\r\n";
                foreach (var cookie in cookies)
                {
                    message += string.Format("{0} = {1}\r\n", cookie.name, cookie.value);
                }
            }
            LogDebug(message);
        }

        /// <summary>
        /// Class LogRequest.
        /// </summary>
        private class LogRequest
        {
            /// <summary>
            /// Gets or sets the URL.
            /// </summary>
            /// <value>The URL.</value>
            public string Url { get; set; }
            /// <summary>
            /// Gets or sets the headers.
            /// </summary>
            /// <value>The headers.</value>
            public IList<RestHeader> Headers { get; set; }
            /// <summary>
            /// Gets or sets the cookies.
            /// </summary>
            /// <value>The cookies.</value>
            public IList<RequestCookie> Cookies { get; set; }
            /// <summary>
            /// Gets or sets the request body.
            /// </summary>
            /// <value>The request body.</value>
            public string RequestBody { get; set; }
            /// <summary>
            /// Gets or sets the content of the response.
            /// </summary>
            /// <value>The content of the response.</value>
            public string ResponseContent { get; set; }
        }
    }
}
