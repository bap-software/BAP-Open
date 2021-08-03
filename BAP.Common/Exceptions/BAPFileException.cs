// ***********************************************************************
// Assembly         : BAP.Common
// Author           : Victor Mamray
// Created          : 08-17-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-17-2020
// ***********************************************************************
// <copyright file="BAPFileException.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace BAP.Common.Exceptions
{
    /// <summary>
    /// BAP Exception which may be raised out of File System module.
    /// </summary>
    public class BAPFileException : BAPException
    {
        /// <summary>
        /// The file name
        /// </summary>
        private string _fileName = string.Empty;
        /// <summary>
        /// Initializes a new instance of the <see cref="BAPFileException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public BAPFileException(string message) : base(message)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BAPFileException"/> class.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="message">The message.</param>
        public BAPFileException(string fileName, string message) : base(message)
        {
            _fileName = fileName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BAPFileException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public BAPFileException(string message, Exception exception) : base(message, exception)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BAPFileException"/> class.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public BAPFileException(string fileName, string message, Exception exception) : base(message, exception)
        {
            _fileName = fileName;
        }

        /// <summary>
        /// Name of the file assosiated with the exception.
        /// </summary>
        /// <value>The name of the file.</value>
        public string FileName
        {
            get
            {
                return _fileName;
            }

            private set
            {
                _fileName = value;
            }
        }
    }
}
