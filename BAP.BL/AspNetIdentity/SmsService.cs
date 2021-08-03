// ***********************************************************************
// Assembly         : BAP.BL
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="SmsService.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace BAP.BL.AspNetIdentity
{
    /// <summary>
    /// Class SmsService.
    /// Implements the <see cref="Microsoft.AspNet.Identity.IIdentityMessageService" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNet.Identity.IIdentityMessageService" />
    public class SmsService : IIdentityMessageService
    {
        /// <summary>
        /// Sends the asynchronous.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>Task.</returns>
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }

}
