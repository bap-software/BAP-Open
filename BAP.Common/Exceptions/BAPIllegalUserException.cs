// ***********************************************************************
// Assembly         : BAP.Common
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-26-2020
// ***********************************************************************
// <copyright file="BAPIllegalUserException.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace BAP.Common.Exceptions
{
    /// <summary>
    /// Exception is raised when illegal/nonauthorized user tries to get access to some entity or module.
    /// </summary>
    public class BAPIllegalUserException : BAPException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BAPIllegalUserException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public BAPIllegalUserException(string message) : base(message)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BAPIllegalUserException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public BAPIllegalUserException(string message, Exception exception) : base(message, exception)
        {

        }
    }
}
