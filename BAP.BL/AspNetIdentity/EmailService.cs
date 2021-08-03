// ***********************************************************************
// Assembly         : BAP.BL
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="EmailService.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using BAP.Email;

namespace BAP.BL.AspNetIdentity
{
    /// <summary>
    /// Class EmailService.
    /// Implements the <see cref="Microsoft.AspNet.Identity.IIdentityMessageService" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNet.Identity.IIdentityMessageService" />
    public class EmailService : IIdentityMessageService
    {
        /// <summary>
        /// The mailer
        /// </summary>
        IMailer _mailer;

        /// <summary>
        /// Prevents a default instance of the <see cref="EmailService"/> class from being created.
        /// </summary>
        private EmailService()
        {
            _mailer = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailService"/> class.
        /// </summary>
        /// <param name="mailer">The mailer.</param>
        public EmailService(IMailer mailer)
        {
            _mailer = mailer;
        }

        /// <summary>
        /// Sends the asynchronous.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>Task.</returns>
        /// <exception cref="NullReferenceException">Mailer cannot be null</exception>
        /// <exception cref="NullReferenceException">Message cannot be null</exception>
        public Task SendAsync(IdentityMessage message)
        {
            if (_mailer == null)
                throw new NullReferenceException("Mailer cannot be null");
            if (message == null)
                throw new NullReferenceException("Message cannot be null");

            return _mailer.SendEmailAsync(_mailer.DefaultFromAddress, message.Destination, message.Subject, message.Body);
        }
    }

}
