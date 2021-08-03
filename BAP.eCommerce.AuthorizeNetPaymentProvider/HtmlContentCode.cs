// ***********************************************************************
// Assembly         : BAP.eCommerce.AuthorizeNetPaymentProvider
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
namespace BAP.eCommerce.AuthorizeNetPaymentProvider
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
        /// Gets or sets the session token.
        /// </summary>
        /// <value>The session token.</value>
        public string SessionToken { get; set; }
        /// <summary>
        /// Gets or sets a net form URL.
        /// </summary>
        /// <value>a net form URL.</value>
        public string ANetFormUrl { get; set; }
        /// <summary>
        /// Gets or sets the return URL.
        /// </summary>
        /// <value>The return URL.</value>
        public string ReturnUrl { get; set; }
        /// <summary>
        /// Gets or sets the cancel URL.
        /// </summary>
        /// <value>The cancel URL.</value>
        public string CancelUrl { get; set; }
    }
    /// <summary>
    /// Class HtmlContent.
    /// Implements the <see cref="BAP.eCommerce.AuthorizeNetPaymentProvider.HtmlContentBase" />
    /// </summary>
    /// <seealso cref="BAP.eCommerce.AuthorizeNetPaymentProvider.HtmlContentBase" />
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
