// ***********************************************************************
// Assembly         : BAP.Common
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="IRolePermissionProvider.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAP.Common
{
    /// <summary>
    /// Interface IRolePermissionProvider
    /// </summary>
    public interface IRolePermissionProvider
    {
        /// <summary>
        /// Gets the roles.
        /// </summary>
        /// <value>The roles.</value>
        IList<IBapRole> Roles { get; }
        /// <summary>
        /// Gets the permissions.
        /// </summary>
        /// <value>The permissions.</value>
        IList<IBapPermission> Permissions { get; }
    }
}
