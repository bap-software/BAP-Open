// ***********************************************************************
// Assembly         : BAP.eCommerce.Common
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="ProductOptionException.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace BAP.eCommerce.Common.Exceptions
{
    /// <summary>
    /// Class ProductOptionException.
    /// Implements the <see cref="BAP.Common.Exceptions.BAPException" />
    /// </summary>
    /// <seealso cref="BAP.Common.Exceptions.BAPException" />
    public class ProductOptionException : BAP.Common.Exceptions.BAPException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductOptionException"/> class.
        /// </summary>
        public ProductOptionException() : base()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductOptionException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ProductOptionException(string message) : base(message)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductOptionException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public ProductOptionException(string message, Exception exception) : base(message, exception)
        {

        }
    }
}
