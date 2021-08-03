// ***********************************************************************
// Assembly         : BAP.Email
// Author           : Victor Mamray
// Created          : 04-20-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="MailerConfig.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.Common
{
    /// <summary>
    /// Class MailerConfig.
    /// </summary>
    public class MailerConfig
    {
        /// <summary>
        /// Gets or sets the name of the SMTP user.
        /// </summary>
        /// <value>The name of the SMTP user.</value>
        public string SmtpUserName { get; set; } = "support@bap-software.com";

        /// <summary>
        /// Gets or sets the SMTP password.
        /// </summary>
        /// <value>The SMTP password.</value>
        public string SmtpPassword { get; set; } = "Test$123";

        /// <summary>
        /// Gets or sets the SMTP host.
        /// </summary>
        /// <value>The SMTP host.</value>
        public string SmtpHost { get; set; } = "mail.bap-software.com";

        /// <summary>
        /// Gets or sets the default from email.
        /// </summary>
        /// <value>The default from email.</value>
        public string DefaultFromEmail { get; set; } = "support@yako-paddle.com";

        /// <summary>
        /// Gets or sets the SMTP port.
        /// </summary>
        /// <value>The SMTP port.</value>
        public int SmtpPort { get; set; } = 8889;

        /// <summary>
        /// Gets or sets a value indicating whether [SMTP use SSL].
        /// </summary>
        /// <value><c>true</c> if [SMTP use SSL]; otherwise, <c>false</c>.</value>
        public bool SmtpUseSSL { get; set; } = false;
    }
}
