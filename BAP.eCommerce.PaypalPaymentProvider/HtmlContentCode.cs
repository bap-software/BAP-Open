// ***********************************************************************
// Assembly         : BAP.eCommerce.PaypalPaymentProvider
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="HtmlContentCode.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAP.eCommerce.PaypalPaymentProvider
{
    /// <summary>
    /// Class HtmlData.
    /// </summary>
    public class HtmlData
    {
        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>The order identifier.</value>
        public int OrderId { get; set; }
        /// <summary>
        /// Gets or sets the container CSS.
        /// </summary>
        /// <value>The container CSS.</value>
        public string ContainerCss { get; set; }
        /// <summary>
        /// Gets or sets the environment.
        /// </summary>
        /// <value>The environment.</value>
        public string Environment { get; set; }
        /// <summary>
        /// Gets or sets the sandbox client identifier.
        /// </summary>
        /// <value>The sandbox client identifier.</value>
        public string SandboxClientId { get; set; }
        /// <summary>
        /// Gets or sets the production client identifier.
        /// </summary>
        /// <value>The production client identifier.</value>
        public string ProductionClientId { get; set; }
        /// <summary>
        /// Gets or sets the order total.
        /// </summary>
        /// <value>The order total.</value>
        public decimal OrderTotal { get; set; }
        /// <summary>
        /// Gets or sets the order currency.
        /// </summary>
        /// <value>The order currency.</value>
        public string OrderCurrency { get; set; }
        /// <summary>
        /// Gets or sets the payment complete alert.
        /// </summary>
        /// <value>The payment complete alert.</value>
        public string PaymentCompleteAlert { get; set; }
        /// <summary>
        /// Gets or sets the call back URL.
        /// </summary>
        /// <value>The call back URL.</value>
        public string CallBackUrl { get; set; }
    }

    /// <summary>
    /// Class HtmlContent.
    /// Implements the <see cref="BAP.eCommerce.PaypalPaymentProvider.HtmlContentBase" />
    /// </summary>
    /// <seealso cref="BAP.eCommerce.PaypalPaymentProvider.HtmlContentBase" />
    public partial class HtmlContent
    {
        /// <summary>
        /// The data
        /// </summary>
        protected HtmlData _data;
        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlContent"/> class.
        /// </summary>
        /// <param name="data">The data.</param>
        public HtmlContent(HtmlData data)
        {
            _data = data;
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <value>The data.</value>
        public HtmlData Data
        {
            get
            {
                return _data;
            }
        }
    }
}
