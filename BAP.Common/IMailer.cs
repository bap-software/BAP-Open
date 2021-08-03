// ***********************************************************************
// Assembly         : BAP.Common
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="IMailer.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Threading.Tasks;

namespace BAP.Email
{
    /// <summary>
    /// Interface IMailer
    /// </summary>
    public interface IMailer
    {
        /// <summary>
        /// Gets the default from address.
        /// </summary>
        /// <value>The default from address.</value>
        string DefaultFromAddress { get; }
        /// <summary>
        /// Sends the email.
        /// </summary>
        /// <param name="fromAddress">From address.</param>
        /// <param name="toAddress">To address.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="body">The body.</param>
        /// <param name="isHtmlBody">if set to <c>true</c> [is HTML body].</param>
        void SendEmail(string fromAddress, string toAddress, string subject, string body, bool isHtmlBody = true);
        /// <summary>
        /// Sends the email asynchronous.
        /// </summary>
        /// <param name="fromAddress">From address.</param>
        /// <param name="toAddress">To address.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="body">The body.</param>
        /// <param name="isHtmlBody">if set to <c>true</c> [is HTML body].</param>
        /// <returns>Task.</returns>
        Task SendEmailAsync(string fromAddress, string toAddress, string subject, string body, bool isHtmlBody = true);
    }
}
