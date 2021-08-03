// ***********************************************************************
// Assembly         : BAP.Common
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-26-2020
// ***********************************************************************
// <copyright file="BAPUserException.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace BAP.Common.Exceptions
{
    /// <summary>
    /// Exception is thrown when any issue with the current user in the application.
    /// </summary>
    public class BAPUserException : BAPException
    {
        /// <summary>
        /// The user name
        /// </summary>
        private string _userName = string.Empty;
        /// <summary>
        /// Initializes a new instance of the <see cref="BAPUserException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public BAPUserException(string message) : base(message)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BAPUserException"/> class.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="message">The message.</param>
        public BAPUserException(string userName, string message) : base(message)
        {
            _userName = userName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BAPUserException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public BAPUserException(string message, Exception exception) : base(message, exception)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BAPUserException"/> class.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public BAPUserException(string userName, string message, Exception exception) : base(message, exception)
        {
            _userName = userName;
        }

        /// <summary>
        /// Name of the user assosiated with the exception.
        /// </summary>
        /// <value>The name of the user.</value>
        public string UserName
        {
            get
            {
                return _userName;
            }

            private set
            {
                _userName = value;
            }
        }
    }
}
