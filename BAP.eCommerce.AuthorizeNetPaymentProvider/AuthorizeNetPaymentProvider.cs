// ***********************************************************************
// Assembly         : BAP.eCommerce.AuthorizeNetPaymentProvider
// Author           : Victor Mamray
// Created          : 06-26-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-26-2020
// ***********************************************************************
// <copyright file="AuthorizeNetPaymentProvider.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Net;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Specialized;

using AuthorizeNet.Api.Contracts.V1;
using AuthorizeNet.Api.Controllers;
using AuthorizeNet.Api.Controllers.Bases;

using BAP.Common;
using BAP.Log;
using BAP.eCommerce.BL;
using BAP.eCommerce.DAL.Entities;
using BAP.eCommerce.Common.Exceptions;
using Newtonsoft.Json;
using BAP.BL;
using BAP.DAL.Entities;

namespace BAP.eCommerce.AuthorizeNetPaymentProvider
{
    /// <summary>
    /// Class AuthorizeNetPaymentProvider.
    /// Implements the <see cref="BAP.Common.BAPBaseClassWithLogging" />
    /// Implements the <see cref="BAP.eCommerce.BL.IPaymentOptionProvider" />
    /// Implements the <see cref="BAP.Common.ISupportCustomConfig" />
    /// </summary>
    /// <seealso cref="BAP.Common.BAPBaseClassWithLogging" />
    /// <seealso cref="BAP.eCommerce.BL.IPaymentOptionProvider" />
    /// <seealso cref="BAP.Common.ISupportCustomConfig" />
    public class AuthorizeNetPaymentProvider : BAPBaseClassWithLogging, IPaymentOptionProvider, ISupportCustomConfig
    {
        /// <summary>
        /// The configuration
        /// </summary>
        private readonly AuthorizeNetConfig _config;
        /// <summary>
        /// The bl
        /// </summary>
        private readonly ICustomConfigurationBL _bl;
        /// <summary>
        /// The custom configuration
        /// </summary>
        private CustomConfiguration _customConfiguration;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizeNetPaymentProvider"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="config">The configuration.</param>
        /// <param name="bl">The bl.</param>
        public AuthorizeNetPaymentProvider(ILogger logger, string config, BusinessLayer bl) : base(logger)
        {
            try
            {
                _bl = bl;
                var type = typeof(AuthorizeNetPaymentProvider);
                _customConfiguration = _bl.GetCustomConfigurationByName($"{type.Assembly.GetName().Name}_{type.Name}");
                if (_customConfiguration != null && !string.IsNullOrWhiteSpace(_customConfiguration.CurrentConfiguration))
                    _config = JsonConvert.DeserializeObject<AuthorizeNetConfig>(_customConfiguration.CurrentConfiguration);
                if (_config == null)
                    _config = JsonConvert.DeserializeObject<AuthorizeNetConfig>(config);
            }
            catch (Exception exc)
            {
                LogException(new ShippingException("Could not read provided configuration from JSON text to Object", exc));
                _config = new AuthorizeNetConfig();
            }
        }

        /// <summary>
        /// Returns account information
        /// </summary>
        /// <param name="accountRefId">account reference id</param>
        /// <returns>AccountInfo.</returns>
        public AccountInfo GetAccountInfo(string accountRefId)
        {
            return null;
        }

        /// <summary>
        /// Give information about payment page to be shown. It can be either embedded html/javascript content, our internal page or exaternal page.
        /// If external or internal page is given application does redirect to it.
        /// </summary>
        /// <param name="order">Instance of CustomerOrder class</param>
        /// <param name="callBackUrl">URL to be called back by payment gateway when payment is processed</param>
        /// <param name="containerCss">Master CSS class name to be applied if html content is returned</param>
        /// <param name="accountRefId">Account reference id, optional, only if account is registered and reference is available on eCommerce side</param>
        /// <param name="iFrameCallbackUrl">The i frame callback URL.</param>
        /// <returns>PaymentPageInfo class instance</returns>
        /// <exception cref="PaymentException"></exception>
        public PaymentPageInfo GetPaymentPage(CustomerOrder order, string callBackUrl, string containerCss = "", string accountRefId = "", string iFrameCallbackUrl = "")
        {
            PaymentPageInfo result;
            var apiLoginId = _config.ApiLoginId;
            var apiTransactionKey = _config.ApiTransactionKey;
            var apiUrl = _config.ANetFormUrl;
            var response = GetPaymentPageLink(apiLoginId, apiTransactionKey, order, callBackUrl, iFrameCallbackUrl);

            if (response.messages.resultCode == messageTypeEnum.Ok)
            {
                var data = new HtmlData
                {
                    OrderId = order.Id,
                    ContainerCss = containerCss ?? "",
                    SessionToken = ((dynamic)response).token,
                    ANetFormUrl = apiUrl,
                    ReturnUrl = callBackUrl,
                    CancelUrl = callBackUrl + "?orderId=" + order.Id + "&cancel=true"
                };

                // generate payment form content
                HtmlContent htmlTemplate = new HtmlContent(data);
                result = new PaymentPageInfo
                {
                    PaymentPageContentType = PaymentPageContentType.Html,
                    HtmlContent = htmlTemplate.TransformText()
                };
            }
            else
            {
                var errorMessage = "Error(s) occured during calling payment page from Authorize.Net";
                foreach (var msg in response.messages.message)
                {
                    errorMessage += $"\r\nError: {msg.code} {msg.text}";
                }
                throw new PaymentException(errorMessage);
            }

            return result;
        }

        /// <summary>
        /// Method to be called by the callback page on our side. This method is responsible to parse/process data returned by payment gateway via
        /// call back url parameters or possibly via form data if gateway does POST call.
        /// </summary>
        /// <param name="callBackUrl">Optional. We may pass this if callback page is called with extra parameters in url</param>
        /// <returns>PaymentPassInfo.</returns>
        public PaymentPassInfo PaymentCallBack(string callBackUrl = "")
        {
            var result = new PaymentPassInfo
            {
                IsError = true,
                ErrorCode = "0",
                ErrorDescription = "Callback returned no information about payment",
                PaymentId = (new Guid()).ToString(),
                PaymentStatus = PaymentStatus.none,
                TotalPaid = 0,
                StartDateTime = DateTime.Now,
                ProcessDateTime = DateTime.Now
            };

            NameValueCollection parameters = null;
            if (!string.IsNullOrEmpty(callBackUrl))
            {
                parameters = HttpUtility.ParseQueryString(callBackUrl);
            }
            else if (HttpContext.Current != null && HttpContext.Current.Request != null)
            {
                parameters = HttpContext.Current.Request.QueryString;
            }

            if (parameters != null && parameters.Count > 0)
            {
                result.IsError = false;
                result.ErrorCode = "";
                result.ErrorDescription = "";

                if (parameters.AllKeys.Any(a => a == "cancel") && !string.IsNullOrEmpty(parameters["cancel"]) && parameters["cancel"].ToLower() == "true")
                {
                    result.PaymentStatus = PaymentStatus.failed;
                    result.IsError = true;
                    result.ErrorCode = "TRAN_CANCELLED";
                    result.ErrorDescription = "Payment failed to be processed due to payment transaction was cancelled";
                }

                if (parameters.AllKeys.Any(a => a == "orderid"))
                {
                    int i = -1;
                    if (Int32.TryParse(parameters["orderid"], out i))
                        result.OrderId = i;
                }

                if (parameters.AllKeys.Any(a => a == "refid"))
                {
                    result.PaymentId = parameters["refid"];
                }

                if (parameters.AllKeys.Any(a => a == "notes"))
                {
                    result.Notes = parameters["notes"];
                }

                if (parameters.AllKeys.Any(a => a == "createtime"))
                {
                    DateTime t;
                    if (DateTime.TryParse(parameters["createtime"], out t))
                        result.StartDateTime = t;
                    else
                        result.StartDateTime = DateTime.Now;
                }
                if (parameters.AllKeys.Any(a => a == "updatetime"))
                {
                    DateTime t;
                    if (DateTime.TryParse(parameters["updatetime"], out t))
                        result.ProcessDateTime = t;
                    else
                        result.ProcessDateTime = DateTime.Now;
                }
            }

            return result;
        }

        /// <summary>
        /// Register payment account on the gateway based on the customer info given and internal login of the given gateway
        /// </summary>
        /// <param name="customer">customer object</param>
        /// <returns>Account reference id</returns>
        public string RegisterAccount(Customer customer)
        {
            return string.Empty;
        }

        /// <summary>
        /// Identify is account registration is supportable
        /// </summary>
        /// <returns>boolean, true is supported</returns>
        public bool SupportRegister()
        {
            return false;
        }

        /// <summary>
        /// Gets the payment page link.
        /// </summary>
        /// <param name="apiLoginID">The API login identifier.</param>
        /// <param name="apiTransactionKey">The API transaction key.</param>
        /// <param name="order">The order.</param>
        /// <param name="callBackUrl">The call back URL.</param>
        /// <param name="iFrameCallbackUrl">The i frame callback URL.</param>
        /// <returns>ANetApiResponse.</returns>
        private ANetApiResponse GetPaymentPageLink(string apiLoginID, string apiTransactionKey, CustomerOrder order, string callBackUrl, string iFrameCallbackUrl)
        {
            var environment = _config.Environment;
            switch (environment)
            {
                case "sandbox":
                    ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = AuthorizeNet.Environment.SANDBOX;
                    break;
                case "live":
                    ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = AuthorizeNet.Environment.PRODUCTION;
                    break;
            }

            ApiOperationBase<ANetApiRequest, ANetApiResponse>.MerchantAuthentication = new merchantAuthenticationType()
            {
                name = apiLoginID,
                ItemElementName = ItemChoiceType.transactionKey,
                Item = apiTransactionKey
            };

            var settings = new List<settingType>
            {
                new settingType
                {
                    settingName = settingNameEnum.hostedPaymentBillingAddressOptions.ToString(),
                    settingValue = "{\"show\": true, \"required\":true}"
                },
                new settingType
                {
                    settingName = settingNameEnum.hostedPaymentButtonOptions.ToString(),
                    settingValue = "{\"text\": \"Pay\"}"
                },
                new settingType
                {
                    settingName = settingNameEnum.hostedPaymentCustomerOptions.ToString(),
                    settingValue = "{\"showEmail\":true,\"requiredEmail\":true}"
                },
                new settingType
                {
                    settingName = settingNameEnum.hostedPaymentPaymentOptions.ToString(),
                    settingValue = "{\"cardCodeRequired\":true}"
                },
                new settingType
                {
                    settingName = settingNameEnum.hostedPaymentIFrameCommunicatorUrl.ToString(),
                    settingValue = "{\"url\":\"" + iFrameCallbackUrl + "\"}"
                },
                new settingType
                {
                    settingName = settingNameEnum.hostedPaymentReturnOptions.ToString(),
                    settingValue = "{\"showReceipt\":false,\"url\":\"" + callBackUrl + "\",\"urlText\":\"Continue\",\"cancelUrl\":\"" + callBackUrl + "\",\"cancelUrlText\":\"Cancel\"}" /*,\"url\":\"" + callBackUrl + "\",\"urlText\":\"Continue\",\"cancelUrl\":\"" + callBackUrl + "\",\"cancelUrlText\":\"Cancel\"*/

                },
                new settingType
                {
                    settingName = settingNameEnum.hostedPaymentSecurityOptions.ToString(),
                    settingValue = "{\"captcha\": false}"
                },
                new settingType
                {
                    settingName = settingNameEnum.hostedPaymentShippingAddressOptions.ToString(),
                    settingValue = "{\"show\":false,\"required\":true}"
                }
            };

            var transactionRequest = new transactionRequestType
            {
                transactionType = transactionTypeEnum.authCaptureTransaction.ToString(),    // authorize capture only
                amount = (decimal)order.Total,
                customer = new customerDataType
                {
                    email = order.Customer != null ? order.Customer.Email : order.BillingAddress.ContactEmail
                },
                billTo = new customerAddressType
                {
                    firstName = order.BillingAddress.FirstName,
                    lastName = order.BillingAddress.LastName,
                    company = order.BillingAddress.CompanyName,
                    address = order.BillingAddress.AddressLine1 + ((!string.IsNullOrEmpty(order.BillingAddress.AddressLine2)) ? (" " + order.BillingAddress.AddressLine2) : ""),
                    city = order.BillingAddress.City,
                    state = order.BillingAddress.State,
                    country = order.BillingAddress.Country,
                    zip = order.BillingAddress.Zip,
                    email = order.BillingAddress.ContactEmail,
                    phoneNumber = order.BillingAddress.PhoneNumber + ((!string.IsNullOrEmpty(order.BillingAddress.PhoneExtension)) ? (" #" + order.BillingAddress.PhoneExtension) : ""),
                    faxNumber = order.BillingAddress.FaxNumber
                }
            };

            var request = new getHostedPaymentPageRequest();
            request.transactionRequest = transactionRequest;
            request.hostedPaymentSettings = settings.ToArray();

            // instantiate the controller that will call the service
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var controller = new getHostedPaymentPageController(request);
            controller.Execute();

            // get the response from the service (errors contained if any)
            var response = controller.GetApiResponse();

            return response;
        }

        /// <summary>
        /// Method to return HTML content of the communication page used by iFrame of some of the payment providers in order to send data back to the
        /// parent page
        /// </summary>
        /// <param name="order">Instance of CustomerOrder class</param>
        /// <returns>HTML content text</returns>
        public string GetiFrameCallbackHtml(CustomerOrder order)
        {
            iFrameCallbackHtml htmlTemplate = new iFrameCallbackHtml();
            return htmlTemplate.TransformText();
        }

        /// <summary>
        /// Updates the configuration.
        /// </summary>
        /// <param name="json">The json.</param>
        public void UpdateConfig(string json)
        {
            _customConfiguration.CurrentConfiguration = json;
            _bl.UpdateCustomConfiguration(_customConfiguration);
        }

        /// <summary>
        /// Resets to default.
        /// </summary>
        public void ResetToDefault()
        {
            _customConfiguration.CurrentConfiguration = _customConfiguration.DefaultConfiguration;
            _bl.UpdateCustomConfiguration(_customConfiguration);
        }

        /// <summary>
        /// Gets a value indicating whether [supports custom configuration].
        /// </summary>
        /// <value><c>true</c> if [supports custom configuration]; otherwise, <c>false</c>.</value>
        public bool SupportsCustomConfig => true;

        /// <summary>
        /// Gets the custom configuration json example.
        /// </summary>
        /// <value>The custom configuration json example.</value>
        public string CustomConfigJsonExample => JsonConvert.SerializeObject(new AuthorizeNetConfig());

        /// <summary>
        /// Gets the type of the custom configuration.
        /// </summary>
        /// <value>The type of the custom configuration.</value>
        public Type CustomConfigType => typeof(AuthorizeNetConfig);

        /// <summary>
        /// Gets the current custom configuration json.
        /// </summary>
        /// <value>The current custom configuration json.</value>
        public string CurrentCustomConfigJson => _customConfiguration.CurrentConfiguration;
    }
}
