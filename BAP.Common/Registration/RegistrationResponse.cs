// ***********************************************************************
// Assembly         : BAP.Common
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-17-2020
// ***********************************************************************
// <copyright file="RegistrationResponse.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace BAP.Common.Registration
{
    /// <summary>
    /// Describes response of the user or organization registration operation, returned by registration engines supporting IRegistrationEngine interface.
    /// </summary>
    public class RegistrationResponse
    {
        /// <summary>
        /// True if all went fine
        /// </summary>
        /// <value><c>true</c> if success; otherwise, <c>false</c>.</value>
        public bool Success { get; set; }
        /// <summary>
        /// Error code if something went wrong
        /// </summary>
        /// <value>The error code.</value>
        public int ErrorCode { get; set; }
        /// <summary>
        /// [Optional]Extra message can be returned here
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; set; }
        /// <summary>
        /// If Exception occured and available, returned here
        /// </summary>
        /// <value>The exception.</value>
        public Exception Exception { get; set; }
        /// <summary>
        /// If sucessfull and type of user registration, array of assigned roles is given here
        /// </summary>
        /// <value>The user roles.</value>
        public string[] UserRoles { get; set; }
    }
}
