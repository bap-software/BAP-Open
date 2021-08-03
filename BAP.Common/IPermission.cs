// ***********************************************************************
// Assembly         : BAP.Common
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="IPermission.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.Common
{
    /// <summary>
    /// Enum BapPermissionType
    /// </summary>
    public enum BapPermissionType
    {
        /// <summary>
        /// The read
        /// </summary>
        Read = 1,
        /// <summary>
        /// The write
        /// </summary>
        Write,
        /// <summary>
        /// The delete
        /// </summary>
        Delete
    }

    /// <summary>
    /// Interface IBapPermission
    /// </summary>
    public interface IBapPermission
    {
        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        BapPermissionType Type { get; }
        /// <summary>
        /// Gets the role.
        /// </summary>
        /// <value>The role.</value>
        IBapRole Role { get; }
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        int Id { get; }
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        string Name { get; }
    }
}
