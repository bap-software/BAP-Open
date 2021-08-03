// ***********************************************************************
// Assembly         : BAP.Common
// Author           : Victor Mamray
// Created          : 05-30-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="BAPException.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace BAP.Common.Exceptions
{
    /// <summary>
    /// Base BAP exception, used to identify BAP native exceptions and distinguish them from other types of exceptions.
    /// </summary>
    public class BAPException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BAPException" /> class.
        /// </summary>
        public BAPException()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BAPException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public BAPException(string message) : base(message)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BAPException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public BAPException(string message, Exception exception) : base(message, exception)
        {

        }
    }
}
