// ***********************************************************************
// Assembly         : BAP.Common
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-26-2020
// ***********************************************************************
// <copyright file="BAPSubscriptionException.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
namespace BAP.Common.Exceptions
{
    /// <summary>
    /// Exception is thrown when issue occurs during subscription intialization.
    /// </summary>
    public class BAPSubscriptionException : BAPException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BAPSubscriptionException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public BAPSubscriptionException(string message) : base(message)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BAPSubscriptionException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public BAPSubscriptionException(string message, Exception exception) : base(message, exception)
        {

        }
    }
}
