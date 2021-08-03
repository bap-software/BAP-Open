// ***********************************************************************
// Assembly         : BAP.Common
// Author           : Victor Mamray
// Created          : 05-29-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-17-2020
// ***********************************************************************
// <copyright file="BAPAuthorizationException.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace BAP.Common.Exceptions
{
    /// <summary>
    /// Exception raised by authentication or authorization processes.
    /// </summary>
    public class BAPAuthorizationException : BAPException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BAPAuthorizationException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public BAPAuthorizationException(string message) : base(message)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BAPAuthorizationException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public BAPAuthorizationException(string message, Exception exception) : base(message, exception)
        {

        }
    }
}
