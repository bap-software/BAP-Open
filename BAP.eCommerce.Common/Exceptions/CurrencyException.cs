// ***********************************************************************
// Assembly         : BAP.eCommerce.Common
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="CurrencyException.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAP.eCommerce.Common.Exceptions
{
    /// <summary>
    /// Class CurrencyException.
    /// Implements the <see cref="BAP.Common.Exceptions.BAPException" />
    /// </summary>
    /// <seealso cref="BAP.Common.Exceptions.BAPException" />
    public class CurrencyException : BAP.Common.Exceptions.BAPException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyException"/> class.
        /// </summary>
        public CurrencyException() : base()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public CurrencyException(string message) : base(message)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public CurrencyException(string message, Exception exception) : base(message, exception)
        {

        }
    }
}
