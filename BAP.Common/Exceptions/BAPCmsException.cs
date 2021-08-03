// ***********************************************************************
// Assembly         : BAP.Common
// Author           : Victor Mamray
// Created          : 05-29-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-17-2020
// ***********************************************************************
// <copyright file="BAPCmsException.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace BAP.Common.Exceptions
{
    /// <summary>
    /// Exception can be raised by CMS engine in case of the any kind of issue.
    /// </summary>
    public class BAPCmsException : BAPException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BAPCmsException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public BAPCmsException(string message) : base(message)
        {            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BAPCmsException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public BAPCmsException(string message, Exception exception) : base(message, exception)
        {

        }
    }
}
