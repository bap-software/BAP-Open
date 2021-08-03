// ***********************************************************************
// Assembly         : BAP.Workflow
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="BAPWorkflowException.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAP.Common.Exceptions
{
    /// <summary>
    /// Class BAPWorkflowException.
    /// Implements the <see cref="BAP.Common.Exceptions.BAPException" />
    /// </summary>
    /// <seealso cref="BAP.Common.Exceptions.BAPException" />
    public class BAPWorkflowException : BAPException
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="BAPWorkflowException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public BAPWorkflowException(string message) : base(message)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BAPWorkflowException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public BAPWorkflowException(string message, Exception exception) : base(message, exception)
        {

        }
        
    }
}
