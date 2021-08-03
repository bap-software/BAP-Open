// ***********************************************************************
// Assembly         : BAP.Common
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-26-2020
// ***********************************************************************
// <copyright file="BAPRegistrationException.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
namespace BAP.Common.Exceptions
{
    /// <summary>
    /// Exception is raised in case of some issue during new user registration process.
    /// </summary>
    public class BAPRegistrationException : BAPException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BAPRegistrationException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public BAPRegistrationException(string message) : base(message)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BAPRegistrationException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public BAPRegistrationException(string message, Exception exception) : base(message, exception)
        {

        }
    }
}
