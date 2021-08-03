// ***********************************************************************
// Assembly         : BAP.Common
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="IAuthorizationHelper.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;

namespace BAP.Common
{
    /// <summary>
    /// Interface IAuthorizationHelper
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IAuthorizationHelper<T> where T : class, IBapEntity
    {
        /// <summary>
        /// Gets the name of the public user.
        /// </summary>
        /// <value>The name of the public user.</value>
        string PublicUserName { get; }
        /// <summary>
        /// Gets the name of the bap admin role.
        /// </summary>
        /// <value>The name of the bap admin role.</value>
        string BapAdminRoleName { get; }
        /// <summary>
        /// Gets the name of the bap user role.
        /// </summary>
        /// <value>The name of the bap user role.</value>
        string BapUserRoleName { get; }
        /// <summary>
        /// Gets the name of the bap public role.
        /// </summary>
        /// <value>The name of the bap public role.</value>
        string BapPublicRoleName { get; }
        /// <summary>
        /// Gets the name of the bap content manager role.
        /// </summary>
        /// <value>The name of the bap content manager role.</value>
        string BapContentManagerRoleName { get; }
        /// <summary>
        /// Gets the name of the bap owner role.
        /// </summary>
        /// <value>The name of the bap owner role.</value>
        string BapOwnerRoleName { get; }

        /// <summary>
        /// Gets the allowed roles.
        /// </summary>
        /// <returns>IList&lt;System.String&gt;.</returns>
        IList<string> GetAllowedRoles();
        /// <summary>
        /// Gets the public roles.
        /// </summary>
        /// <returns>IList&lt;System.String&gt;.</returns>
        IList<string> GetPublicRoles();
        /// <summary>
        /// Gets the default roles.
        /// </summary>
        /// <returns>System.Int32.</returns>
        int GetDefaultRoles();
        /// <summary>
        /// Gets the default permissions.
        /// </summary>
        /// <returns>System.Int32.</returns>
        int GetDefaultPermissions();
        /// <summary>
        /// Gets the current organization identifier.
        /// </summary>
        /// <returns>System.Int32.</returns>
        int GetCurrentOrganizationId();
        /// <summary>
        /// Gets a value indicating whether this instance is user in admin role.
        /// </summary>
        /// <value><c>true</c> if this instance is user in admin role; otherwise, <c>false</c>.</value>
        bool IsUserInAdminRole { get; }
        /// <summary>
        /// Gets a value indicating whether this instance is user in user role.
        /// </summary>
        /// <value><c>true</c> if this instance is user in user role; otherwise, <c>false</c>.</value>
        bool IsUserInUserRole { get; }
        /// <summary>
        /// Gets the current user identifier.
        /// </summary>
        /// <returns>System.String.</returns>
        string GetCurrentUserId();
        /// <summary>
        /// Gets the tenancy filter.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>Expression&lt;Func&lt;T, System.Boolean&gt;&gt;.</returns>
        Expression<Func<T, bool>> GetTenancyFilter(DbContext context);
        /// <summary>
        /// Determines whether [is allowed to read] [the specified entity].
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if [is allowed to read] [the specified entity]; otherwise, <c>false</c>.</returns>
        bool IsAllowedToRead(IBapEntity entity = null);
        /// <summary>
        /// Determines whether [is allowed to write] [the specified entity].
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if [is allowed to write] [the specified entity]; otherwise, <c>false</c>.</returns>
        bool IsAllowedToWrite(IBapEntity entity = null);
        /// <summary>
        /// Determines whether [is allowed to delete] [the specified entity].
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if [is allowed to delete] [the specified entity]; otherwise, <c>false</c>.</returns>
        bool IsAllowedToDelete(IBapEntity entity = null);
        /// <summary>
        /// Publics the can read.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool PublicCanRead(IBapEntity entity);
        /// <summary>
        /// Sets the public read.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="value">if set to <c>true</c> [value].</param>
        void SetPublicRead(IBapEntity entity, bool value);
        /// <summary>
        /// Permissions the appplied.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="flag">The flag.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool PermissionAppplied(IBapEntity entity, int flag);
        /// <summary>
        /// Sets the permission.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="flag">The flag.</param>
        void SetPermission(IBapEntity entity, int flag);
        /// <summary>
        /// Unsets the permission.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="flag">The flag.</param>
        void UnsetPermission(IBapEntity entity, int flag);

        /// <summary>
        /// Gets the repository filter.
        /// </summary>
        /// <value>The repository filter.</value>
        IRepositoryFilter RepositoryFilter { get; }
    }
}
