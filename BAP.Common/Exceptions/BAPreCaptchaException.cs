// ***********************************************************************
// Assembly         : BAP.Common
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-26-2020
// ***********************************************************************
// <copyright file="BAPreCaptchaException.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
namespace BAP.Common.Exceptions
{
    /// <summary>
    /// Exception is raised when soething wring happen validating Google reCaptcha.
    /// </summary>
    public class BAPreCaptchaException : BAPException
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="BAPreCaptchaException"/> class.
        /// </summary>
        public BAPreCaptchaException() : base("Google reCaptcha validation failed")
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BAPreCaptchaException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public BAPreCaptchaException(string message) : base(message)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BAPreCaptchaException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public BAPreCaptchaException(string message, Exception exception) : base(message, exception)
        {

        }
    }
}
