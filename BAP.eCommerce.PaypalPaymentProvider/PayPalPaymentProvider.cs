// ***********************************************************************
// Assembly         : BAP.eCommerce.PaypalPaymentProvider
// Author           : Victor Mamray
// Created          : 06-26-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-26-2020
// ***********************************************************************
// <copyright file="PayPalPaymentProvider.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Web;
using System.Linq;
using System.Collections.Specialized;

using BAP.eCommerce.BL;
using BAP.eCommerce.DAL.Entities;
using BAP.Common;
using BAP.eCommerce.Common.Exceptions;
using BAP.Log;
using Newtonsoft.Json;
using BAP.BL;
using BAP.DAL.Entities;

namespace BAP.eCommerce.PaypalPaymentProvider
{
    /// <summary>
    /// Class PayPalPaymentProvider.
    /// Implements the <see cref="BAP.Common.BAPBaseClassWithLogging" />
    /// Implements the <see cref="BAP.eCommerce.BL.IPaymentOptionProvider" />
    /// Implements the <see cref="BAP.Common.ISupportCustomConfig" />
    /// </summary>
    /// <seealso cref="BAP.Common.BAPBaseClassWithLogging" />
    /// <seealso cref="BAP.eCommerce.BL.IPaymentOptionProvider" />
    /// <seealso cref="BAP.Common.ISupportCustomConfig" />
    public class PayPalPaymentProvider : BAPBaseClassWithLogging, IPaymentOptionProvider, ISupportCustomConfig
    {
        /// <summary>
        /// The configuration
        /// </summary>
        private readonly PayPalConfig _config;
        /// <summary>
        /// The bl
        /// </summary>
        private readonly ICustomConfigurationBL _bl;
        /// <summary>
        /// The custom configuration
        /// </summary>
        private CustomConfiguration _customConfiguration;

        /// <summary>
        /// Initializes a new instance of the <see cref="PayPalPaymentProvider"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="config">The configuration.</param>
        /// <param name="bl">The bl.</param>
        public PayPalPaymentProvider(ILogger logger, string config, BusinessLayer bl) : base(logger)
        {
            try
            {
                _bl = bl;
                var type = typeof(PayPalPaymentProvider);
                _customConfiguration = _bl.GetCustomConfigurationByName($"{type.Assembly.GetName().Name}_{type.Name}");
                if (_customConfiguration != null && !string.IsNullOrWhiteSpace(_customConfiguration.CurrentConfiguration))
                    _config = JsonConvert.DeserializeObject<PayPalConfig>(_customConfiguration.CurrentConfiguration);
                if (_config == null)
                    _config = JsonConvert.DeserializeObject<PayPalConfig>(config);
            }
            catch (Exception exc)
            {
                LogException(new ShippingException("Could not read provided configuration from JSON text to Object", exc));
                _config = new PayPalConfig();
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
        public PaymentPageInfo GetPaymentPage(CustomerOrder order, string callBackUrl, string containerCss = "", string accountRefId = "", string iFrameCallbackUrl = "")
        {
            // initialize data
            var environment = _config.Environment;
            var productionClientId = _config.ProductionClientId;
            var sandboxClientId = _config.SandboxClientId;
            var javaScriptUrl = _config.JavaScriptUrl;
            
            var data = new HtmlData
            {
                OrderId = order.Id,
                CallBackUrl = callBackUrl ?? "",
                ContainerCss = containerCss ?? "",
                Environment = environment,
                OrderCurrency = order.Currency.ThreeLetterCode,
                OrderTotal = order.Total,
                PaymentCompleteAlert = "Payment complete!",
                ProductionClientId = productionClientId,
                SandboxClientId = sandboxClientId
            };

            // generate payment form content
            HtmlContent htmlTemplate = new HtmlContent(data);
            var result = new PaymentPageInfo
            {
                PaymentPageContentType = PaymentPageContentType.Html,
                HeadContent = "<script src='" + javaScriptUrl + "'></script>",
                HtmlContent = htmlTemplate.TransformText()
            };

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
            // default return result
            var result = new PaymentPassInfo
            {
                IsError = true,
                ErrorCode = "0",
                ErrorDescription = "Callback returned no information about payment",
                PaymentId = Guid.NewGuid().ToString(),
                PaymentStatus = PaymentStatus.none,
                TotalPaid = 0,
                StartDateTime = DateTime.Now,
                ProcessDateTime = DateTime.Now
            };

            // try to get call back parameters
            NameValueCollection parameters = null;
            if (!string.IsNullOrEmpty(callBackUrl))
            {
                parameters = HttpUtility.ParseQueryString(callBackUrl);
            }
            else if (HttpContext.Current != null && HttpContext.Current.Request != null)
            {
                parameters = HttpContext.Current.Request.QueryString;
            }

            // process callback parameters if any
            if (parameters != null && parameters.Count > 0)
            {
                result.IsError = false;
                result.ErrorCode = "";
                result.ErrorDescription = "";

                if (parameters.AllKeys.Any(a => a == "failurereason") && !string.IsNullOrEmpty(parameters["failurereason"]))
                {
                    result.PaymentStatus = PaymentStatus.failed;
                    result.IsError = true;
                    result.ErrorCode = parameters["failurereason"];
                    result.ErrorDescription = "Payment failed to be processed with the following code given: " + result.ErrorCode;
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
                    if (DateTime.TryParse(parameters["updatetime"], out t))
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

                if (parameters.AllKeys.Any(a => a == "state"))
                {
                    PaymentStatus st = PaymentStatus.none;
                    if (Enum.TryParse<PaymentStatus>(parameters["state"], out st))
                        result.PaymentStatus = st;
                }

                if (parameters.AllKeys.Any(a => a == "intent"))
                {
                    PaymentIntent t = PaymentIntent.none;
                    if (Enum.TryParse<PaymentIntent>(parameters["intent"], out t))
                        result.PaymentIntent = t;
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
        /// Method to return HTML content of the communication page used by iFrame of some of the payment providers in order to send data back to the
        /// parent page
        /// </summary>
        /// <param name="order">Instance of CustomerOrder class</param>
        /// <returns>HTML content text</returns>
        public string GetiFrameCallbackHtml(CustomerOrder order)
        {
            return string.Empty;
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
        public string CustomConfigJsonExample => JsonConvert.SerializeObject(new PayPalConfig());

        /// <summary>
        /// Gets the type of the custom configuration.
        /// </summary>
        /// <value>The type of the custom configuration.</value>
        public Type CustomConfigType => typeof(PayPalConfig);

        /// <summary>
        /// Gets the current custom configuration json.
        /// </summary>
        /// <value>The current custom configuration json.</value>
        public string CurrentCustomConfigJson => _customConfiguration.CurrentConfiguration;
    }
}
