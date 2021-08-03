// ***********************************************************************
// Assembly         : BAP.eCommerce.USPSShippingProvider
// Author           : Victor Mamray
// Created          : 05-30-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="AccessRequest.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace BAP.eCommerce.USPSShippingProvider.Request
{
    /// <summary>
    /// Class AccessRequest.
    /// </summary>
    [Serializable]
    public class AccessRequest
    {

        /// <summary>
        /// The m access license number
        /// </summary>
        private string _mAccessLicenseNumber;
        /// <summary>
        /// The m user identifier
        /// </summary>
        private string _mUserId;
        /// <summary>
        /// The m password
        /// </summary>
        private string _mPassword;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccessRequest"/> class.
        /// </summary>
        public AccessRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccessRequest"/> class.
        /// </summary>
        /// <param name="accessLicenseNumber">The access license number.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="password">The password.</param>
        public AccessRequest(string accessLicenseNumber, string userId, string password)
        {
            _mAccessLicenseNumber = accessLicenseNumber;
            _mUserId = userId;
            _mPassword = password;
        }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        public string Password
        {
            get => _mPassword;
            set => _mPassword = value;
        }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        public string UserId
        {
            get => _mUserId;
            set => _mUserId = value;
        }

        /// <summary>
        /// Gets or sets the access license number.
        /// </summary>
        /// <value>The access license number.</value>
        public string AccessLicenseNumber
        {
            get => _mAccessLicenseNumber; 
            set => _mAccessLicenseNumber = value;
        }
    }
}
