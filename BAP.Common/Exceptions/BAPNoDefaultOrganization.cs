// ***********************************************************************
// Assembly         : BAP.Common
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-26-2020
// ***********************************************************************
// <copyright file="BAPNoDefaultOrganization.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.Common.Exceptions
{
    /// <summary>
    /// Exception is raised when application cannot identify default organization unit.
    /// </summary>
    public class BAPNoDefaultOrganization : BAPException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BAPNoDefaultOrganization"/> class.
        /// </summary>
        public BAPNoDefaultOrganization() : base()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BAPNoDefaultOrganization"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public BAPNoDefaultOrganization(string message) : base(message)
        {

        }
    }
}
