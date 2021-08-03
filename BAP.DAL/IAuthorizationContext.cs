// ***********************************************************************
// Assembly         : BAP.DAL
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="IAuthorizationContext.cs" company="BAP Software Ltd.">
//     Copyright © 2015 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using BAP.Common;
using BAP.DAL.Entities;

namespace BAP.DAL
{
    /// <summary>
    /// Interface IAuthorizationContext
    /// </summary>
    public interface IAuthorizationContext
    {
        /// <summary>
        /// Gets the name of the host.
        /// </summary>
        /// <value>The name of the host.</value>
        string HostName { get; }
        /// <summary>
        /// Logins the built in user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool LoginBuiltInUser(string userName);
        /// <summary>
        /// Logoffs the built in user.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool LogoffBuiltInUser();
        /// <summary>
        /// Gets a value indicating whether this instance is authenticated.
        /// </summary>
        /// <value><c>true</c> if this instance is authenticated; otherwise, <c>false</c>.</value>
        bool IsAuthenticated { get; }
        /// <summary>
        /// Determines whether [is current user in role] [the specified role name].
        /// </summary>
        /// <param name="roleName">Name of the role.</param>
        /// <returns><c>true</c> if [is current user in role] [the specified role name]; otherwise, <c>false</c>.</returns>
        bool IsCurrentUserInRole(string roleName);
        /// <summary>
        /// Gets the current user identifier.
        /// </summary>
        /// <returns>System.String.</returns>
        string GetCurrentUserId();
        /// <summary>
        /// Gets the name of the current user.
        /// </summary>
        /// <returns>System.String.</returns>
        string GetCurrentUserName();
        /// <summary>
        /// Gets the full name of the current user.
        /// </summary>
        /// <returns>System.String.</returns>
        string GetCurrentUserFullName();
        /// <summary>
        /// Gets the current organization identifier.
        /// </summary>
        /// <param name="configHelper">The configuration helper.</param>
        /// <returns>System.Int32.</returns>
        int GetCurrentOrganizationId(IConfigHelper configHelper);
        /// <summary>
        /// Gets the current organization.
        /// </summary>
        /// <param name="configHelper">The configuration helper.</param>
        /// <returns>Organization.</returns>
        Organization GetCurrentOrganization(IConfigHelper configHelper);
        /// <summary>
        /// Gets the current roles.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="configHelper">The configuration helper.</param>
        /// <param name="entity">The entity.</param>
        /// <returns>System.Int32.</returns>
        int GetCurrentRoles(string userId, IConfigHelper configHelper, IBapEntity entity = null);
        /// <summary>
        /// Gets the current role names.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="configHelper">The configuration helper.</param>
        /// <param name="entity">The entity.</param>
        /// <returns>System.String[].</returns>
        string[] GetCurrentRoleNames(string userId, IConfigHelper configHelper, IBapEntity entity = null);
        /// <summary>
        /// Gets the current user read permissions.
        /// </summary>
        /// <param name="userRoles">The user roles.</param>
        /// <param name="allPermissions">All permissions.</param>
        /// <returns>System.Int32.</returns>
        int GetCurrentUserReadPermissions(int userRoles, int allPermissions);
        /// <summary>
        /// Reads the cookie.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>System.String.</returns>
        string ReadCookie(string name);
        /// <summary>
        /// Saves the cookie.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        void SaveCookie(string name, string value);
        /// <summary>
        /// Removes the cookie.
        /// </summary>
        /// <param name="name">The name.</param>
        void RemoveCookie(string name);

        /// <summary>
        /// Requests the bearrer token.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        void RequestBearrerToken(string userName, string password);
        /// <summary>
        /// Gets the bearrer token.
        /// </summary>
        /// <value>The bearrer token.</value>
        string BearrerToken { get; }

        /// <summary>
        /// Gets or sets the repository filter.
        /// </summary>
        /// <value>The repository filter.</value>
        IRepositoryFilter RepositoryFilter { get; set; }
    }
}
