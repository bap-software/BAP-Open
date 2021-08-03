// ***********************************************************************
// Assembly         : BAP.Common
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="OrganizationStatus.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.Common
{
    /// <summary>
    /// Enum OrganizationStatus
    /// </summary>
    public enum OrganizationStatus
    {
        /// <summary>
        /// The new
        /// </summary>
        New = 1,
        /// <summary>
        /// The pending approval
        /// </summary>
        PendingApproval = 2,
        /// <summary>
        /// The suspended
        /// </summary>
        Suspended = 3,
        /// <summary>
        /// The final
        /// </summary>
        Final = 99
    }
}
