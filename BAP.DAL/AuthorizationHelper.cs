// ***********************************************************************
// Assembly         : BAP.DAL
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="AuthorizationHelper.cs" company="BAP Software Ltd.">
//     Copyright © 2015 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

using BAP.Common;
using BAP.Common.Exceptions;
using BAP.DAL.Entities;


namespace BAP.DAL
{
    /// <summary>
    /// Class AuthorizationHelper.
    /// Implements the <see cref="BAP.Common.IAuthorizationHelper{T}" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="BAP.Common.IAuthorizationHelper{T}" />
    public class AuthorizationHelper<T> : IAuthorizationHelper<T> where T : class, IBapEntity
    {
        #region variables & constants       
        /// <summary>
        /// The settings
        /// </summary>
        protected IConfigHelper _settings;
        /// <summary>
        /// The authentication context
        /// </summary>
        protected IAuthorizationContext _authContext;
        #endregion

        #region properties
        /// <summary>
        /// Gets the type of the entity.
        /// </summary>
        /// <value>The type of the entity.</value>
        protected Type EntityType { get { return typeof(T); } }
        #endregion

        /// <summary>
        /// Gets the name of the public user.
        /// </summary>
        /// <value>The name of the public user.</value>
        public virtual string PublicUserName { get { return _settings.ReadString("BAP.Common.SmtpUserName.PublicUserName", "Public"); } }

        /// <summary>
        /// Gets the name of the bap admin role.
        /// </summary>
        /// <value>The name of the bap admin role.</value>
        public virtual string BapAdminRoleName { get { return _settings.ReadString("BAP.Common.SmtpUserName.BapAdminRoleName", "Administrator"); } }

        /// <summary>
        /// Gets the name of the bap user role.
        /// </summary>
        /// <value>The name of the bap user role.</value>
        public virtual string BapUserRoleName { get { return _settings.ReadString("BAP.Common.SmtpUserName.BapUserRoleName", "User"); } }


        /// <summary>
        /// Gets the name of the bap public role.
        /// </summary>
        /// <value>The name of the bap public role.</value>
        public virtual string BapPublicRoleName { get { return _settings.ReadString("BAP.Common.SmtpUserName.BapPublicRoleName", "Public"); } }

        /// <summary>
        /// Gets the name of the bap content manager role.
        /// </summary>
        /// <value>The name of the bap content manager role.</value>
        public virtual string BapContentManagerRoleName { get { return _settings.ReadString("BAP.Common.SmtpUserName.BapContentManagerRoleName", "ContentManager"); } }

        /// <summary>
        /// Gets the name of the bap owner role.
        /// </summary>
        /// <value>The name of the bap owner role.</value>
        public virtual string BapOwnerRoleName { get { return _settings.ReadString("BAP.Common.SmtpUserName.BapOwnerRoleName", "Owner"); } }

        //Authorization matrix
        /// <summary>
        /// Class AuthItem.
        /// </summary>
        protected class AuthItem
        {
            /// <summary>
            /// Gets or sets the name of the entity.
            /// </summary>
            /// <value>The name of the entity.</value>
            public string EntityName { get; set; }
            /// <summary>
            /// Gets or sets the roles.
            /// </summary>
            /// <value>The roles.</value>
            public int Roles { get; set; }
            /// <summary>
            /// Gets or sets the permissions.
            /// </summary>
            /// <value>The permissions.</value>
            public int Permissions { get; set; }
        }
        /// <summary>
        /// The authentication matrix
        /// </summary>
        protected List<AuthItem> AuthMatrix;

        /// <summary>
        /// Prevents a default instance of the <see cref="AuthorizationHelper{T}"/> class from being created.
        /// </summary>
        private AuthorizationHelper()
        {
            _settings = null;
            _authContext = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationHelper{T}"/> class.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="context">The context.</param>
        public AuthorizationHelper(IConfigHelper settings, IAuthorizationContext context)
        {
            _settings = settings;
            _authContext = context;
            InitAuthMatrix();
        }

        /// <summary>
        /// Initializes the authentication matrix.
        /// </summary>
        protected virtual void InitAuthMatrix()
        {
            AuthMatrix = new List<AuthItem>
            {
                new AuthItem { EntityName = "Attachment", Roles = 127, Permissions = 2072079 },
                new AuthItem { EntityName = "AttachmentAccess", Roles = 127, Permissions = 2072079 },
                new AuthItem { EntityName = "AttachmentHistory", Roles = 127, Permissions = 1843151 },
                new AuthItem { EntityName = "Country", Roles = 127, Permissions = 1875471},
                new AuthItem { EntityName = "State", Roles = 127, Permissions = 1875471},
                new AuthItem { EntityName = "Currency", Roles = 127, Permissions = 1875535},

                new AuthItem { EntityName = "ContentNode", Roles = 127, Permissions = 1875919 },
                new AuthItem { EntityName = "ContentView", Roles = 127, Permissions = 1875919 },
                new AuthItem { EntityName = "ContentViewControl", Roles = 127, Permissions = 1875919 },
                new AuthItem { EntityName = "ContentControlParameter", Roles = 127, Permissions = 1875919 },
                new AuthItem { EntityName = "ContentNodeRoute", Roles = 127, Permissions = 1875919 },
                new AuthItem { EntityName = "ContentLocalization", Roles = 127, Permissions = 1875919 },
                new AuthItem { EntityName = "ContentControl", Roles = 127, Permissions = 1875919 },
                new AuthItem { EntityName = "ContentControlType", Roles = 127, Permissions = 1875535 },
                new AuthItem { EntityName = "CustomConfiguration", Roles = 127, Permissions = 2072079 },
                new AuthItem { EntityName = "DocumentTemplate", Roles = 123, Permissions = 2072079 },

                new AuthItem { EntityName = "Localization", Roles = 127, Permissions = 302799 },
                new AuthItem { EntityName = "Lookup", Roles = 127, Permissions = 302799},
                new AuthItem { EntityName = "LookupValue", Roles = 127, Permissions = 302799},
                new AuthItem { EntityName = "EventLog", Roles = 127, Permissions = 1944095},
                new AuthItem { EntityName = "Organization", Roles = 127, Permissions = 310991},
                new AuthItem { EntityName = "OrganizationModule", Roles = 127, Permissions = 299599},
                new AuthItem { EntityName = "OrganizationService", Roles = 127, Permissions = 302799 },
                new AuthItem { EntityName = "OrganizationUser", Roles = 127, Permissions = 310991},
                new AuthItem { EntityName = "Subscription", Roles = 25, Permissions = 11975},
                new AuthItem { EntityName = "Subscriber", Roles = 31, Permissions = 12255},
                new AuthItem { EntityName = "NewsLetter", Roles = 123, Permissions = 2072079},
                new AuthItem { EntityName = "Message", Roles = 127, Permissions = 896991},
                new AuthItem { EntityName = "Module", Roles = 127, Permissions = 299599},

                new AuthItem { EntityName = "Blog", Roles = 127, Permissions = 1843151 },
                new AuthItem { EntityName = "BlogAuthor", Roles = 127, Permissions = 1843151 },
                new AuthItem { EntityName = "BlogPost", Roles = 127, Permissions = 1843151 },
                new AuthItem { EntityName = "BlogComment", Roles = 127, Permissions = 1843151 },
                new AuthItem { EntityName = "BlogCommentUser", Roles = 127, Permissions = 1843151 },

                new AuthItem { EntityName = "WorkflowClass", Roles = 127, Permissions = 2072079 },
                new AuthItem { EntityName = "WorkflowAction", Roles = 127, Permissions = 2072079 },
                new AuthItem { EntityName = "WorkflowActionAttribute", Roles = 127, Permissions = 2072079 },
                new AuthItem { EntityName = "WorkflowStage", Roles = 127, Permissions = 2072079 },
                new AuthItem { EntityName = "WorkflowStageTransition", Roles = 127, Permissions = 2072079 },
                new AuthItem { EntityName = "WorkflowObject", Roles = 127, Permissions = 2072079 },

                new AuthItem { EntityName = "ScheduledTask", Roles = 127, Permissions = 599775},
                new AuthItem { EntityName = "StagingEntity", Roles = 127, Permissions = 802527 }
            };
        }

        /// <summary>
        /// Gets the type of the bap organization.
        /// </summary>
        /// <value>The type of the bap organization.</value>
        public int BAPOrganizationType
        {
            get
            {
                return AuthorizationConstants.ApplicationOwnerOrganization;
            }
        }

        /// <summary>
        /// Gets the allowed roles.
        /// </summary>
        /// <returns>IList&lt;System.String&gt;.</returns>
        public virtual IList<string> GetAllowedRoles()
        {
            var org = GetCurrentOrganization();
            var result = new List<string>();
            if (org != null && (org.OrganizationType & AuthorizationConstants.ApplicationOwnerOrganization) == AuthorizationConstants.ApplicationOwnerOrganization)
            {
                var userId = GetCurrentUserId();
                var roles = GetCurrentRoles(userId);
                if ((roles & AuthorizationConstants.AdminRole) == AuthorizationConstants.AdminRole)
                    result.Add(BapAdminRoleName);
            }

            result.Add(BapUserRoleName);
            return result;
        }

        /// <summary>
        /// Gets the public roles.
        /// </summary>
        /// <returns>IList&lt;System.String&gt;.</returns>
        public virtual IList<string> GetPublicRoles()
        {
            var result = new List<string>();
            result.Add(BapAdminRoleName);
            result.Add(BapUserRoleName);
            return result;
        }

        /// <summary>
        /// Gets the default roles.
        /// </summary>
        /// <returns>System.Int32.</returns>
        /// <exception cref="BAPAuthorizationException">Given entity is not configured for authorization.</exception>
        public virtual int GetDefaultRoles()
        {
            var authItem = AuthMatrix.SingleOrDefault(i => i.EntityName == EntityType.Name);

            if (authItem == null)
                throw new BAPAuthorizationException("Given entity is not configured for authorization.");

            return authItem.Roles;
        }

        /// <summary>
        /// Gets the default permissions.
        /// </summary>
        /// <returns>System.Int32.</returns>
        /// <exception cref="BAPAuthorizationException">Given entity is not configured for authorization.</exception>
        public virtual int GetDefaultPermissions()
        {
            var authItem = AuthMatrix.SingleOrDefault(i => i.EntityName == EntityType.Name);

            if (authItem == null)
                throw new BAPAuthorizationException("Given entity is not configured for authorization.");

            return authItem.Permissions;
        }

        /// <summary>
        /// Gets the current organization identifier.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public virtual int GetCurrentOrganizationId()
        {
            return _authContext.GetCurrentOrganizationId(_settings);
        }

        /// <summary>
        /// Gets the current organization.
        /// </summary>
        /// <returns>Organization.</returns>
        public virtual Organization GetCurrentOrganization()
        {
            return _authContext.GetCurrentOrganization(_settings);
        }

        /// <summary>
        /// Gets the current roles.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="entity">The entity.</param>
        /// <returns>System.Int32.</returns>
        protected int GetCurrentRoles(string userId, IBapEntity entity = null)
        {
            return _authContext.GetCurrentRoles(userId, _settings, entity);
        }

        /// <summary>
        /// Gets a value indicating whether this instance is user in admin role.
        /// </summary>
        /// <value><c>true</c> if this instance is user in admin role; otherwise, <c>false</c>.</value>
        public bool IsUserInAdminRole
        {
            get
            {
                return _authContext.IsCurrentUserInRole(BapAdminRoleName);
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is user in content manager role.
        /// </summary>
        /// <value><c>true</c> if this instance is user in content manager role; otherwise, <c>false</c>.</value>
        public bool IsUserInContentManagerRole
        {
            get
            {
                return _authContext.IsCurrentUserInRole(BapContentManagerRoleName);
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is user in user role.
        /// </summary>
        /// <value><c>true</c> if this instance is user in user role; otherwise, <c>false</c>.</value>
        public bool IsUserInUserRole
        {
            get
            {
                return _authContext.IsCurrentUserInRole(BapUserRoleName);
            }
        }

        /// <summary>
        /// Gets the repository filter.
        /// </summary>
        /// <value>The repository filter.</value>
        public IRepositoryFilter RepositoryFilter => _authContext.RepositoryFilter;

        /// <summary>
        /// Gets the current user identifier.
        /// </summary>
        /// <returns>System.String.</returns>
        public virtual string GetCurrentUserId()
        {
            return _authContext.GetCurrentUserId();
        }

        /// <summary>
        /// Gets the tenancy filter.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>Expression&lt;Func&lt;T, System.Boolean&gt;&gt;.</returns>
        /// <exception cref="BAPAuthorizationException">Given entity is not configured for authorization.</exception>
        /// <exception cref="BAPAuthorizationException">One or several current user roles do not have access to the given entity.</exception>
        public virtual Expression<Func<T, bool>> GetTenancyFilter(DbContext context)
        {
            var userId = GetCurrentUserId();
            var orgId = GetCurrentOrganizationId();

            // Authenticated user
            if (!string.IsNullOrEmpty(userId))
            {
                var entityType = typeof(T);
                var roles = GetCurrentRoles(userId);
                var authItem = AuthMatrix.SingleOrDefault(i => i.EntityName == entityType.Name);

                if (authItem == null)
                    throw new BAPAuthorizationException("Given entity is not configured for authorization.");

                if ((authItem.Roles & roles) != roles)
                    throw new BAPAuthorizationException("One or several current user roles do not have access to the given entity.");

                int userPermissions = _authContext.GetCurrentUserReadPermissions(roles, authItem.Permissions);


                return (a => (a.TenantUnit == "Organization" && a.TenantUnitId == orgId)
                && ((a.OwnerGroup & roles) == roles)
                && ((userPermissions > 0 && a.OwnerPermissions > 0 && (a.OwnerPermissions & userPermissions) == userPermissions) || (a.CreatedBy == userId && a.OwnerPermissions > 0 && (a.OwnerPermissions & AuthorizationConstants.OwnerReadPermission) == AuthorizationConstants.OwnerReadPermission)));
            }
            else // Public user
            {
                return (a => (a.TenantUnit == "Organization" && a.TenantUnitId == orgId) && (a.OwnerGroup & AuthorizationConstants.PublicRole) == AuthorizationConstants.PublicRole && (a.OwnerPermissions & AuthorizationConstants.PublicReadPermission) == AuthorizationConstants.PublicReadPermission);
            }
        }

        /// <summary>
        /// Determines whether [is in bit map] [the specified bitmap].
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if [is in bit map] [the specified bitmap]; otherwise, <c>false</c>.</returns>
        protected bool IsInBitMap(int bitmap, int value)
        {
            return (bitmap & value) == value;
        }

        /// <summary>
        /// Determines whether [is allowed to read] [the specified entity].
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if [is allowed to read] [the specified entity]; otherwise, <c>false</c>.</returns>
        /// <exception cref="BAPAuthorizationException">Given entity is not configured for authorization.</exception>
        public virtual bool IsAllowedToRead(IBapEntity entity = null)
        {
            bool result = true;
            var authItem = AuthMatrix.SingleOrDefault(i => i.EntityName == EntityType.Name);
            if (authItem == null)
                throw new BAPAuthorizationException("Given entity is not configured for authorization.");
            int permissionsToCheck = authItem.Permissions;

            if (entity != null)
            {
                permissionsToCheck = entity.OwnerPermissions;
            }

            string userId = GetCurrentUserId();
            if (!string.IsNullOrEmpty(userId))
            {
                var roles = GetCurrentRoles(userId);

                if ((roles & AuthorizationConstants.AdminRole) == AuthorizationConstants.AdminRole)
                    result = (permissionsToCheck & AuthorizationConstants.AdminReadPermission) == AuthorizationConstants.AdminReadPermission;
                if (result && (roles & AuthorizationConstants.UserRole) == AuthorizationConstants.UserRole)
                    result = (permissionsToCheck & AuthorizationConstants.UserReadPermission) == AuthorizationConstants.UserReadPermission;
                if (result && (roles & AuthorizationConstants.OwnerRole) == AuthorizationConstants.OwnerRole)
                    result = (permissionsToCheck & AuthorizationConstants.OwnerReadPermission) == AuthorizationConstants.OwnerReadPermission;
                if (result && (roles & AuthorizationConstants.ContentManagerRole) == AuthorizationConstants.ContentManagerRole)
                    result = (permissionsToCheck & AuthorizationConstants.ContentManagerReadPermission) == AuthorizationConstants.ContentManagerReadPermission;
                if (result && (roles & AuthorizationConstants.SupervisorRole) == AuthorizationConstants.SupervisorRole)
                    result = (permissionsToCheck & AuthorizationConstants.SupervisorReadPermission) == AuthorizationConstants.SupervisorReadPermission;
            }
            else
            {
                result = (authItem.Permissions & AuthorizationConstants.PublicReadPermission) == AuthorizationConstants.PublicReadPermission;
            }

            return result;
        }

        /// <summary>
        /// Determines whether [is allowed to write] [the specified entity].
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if [is allowed to write] [the specified entity]; otherwise, <c>false</c>.</returns>
        /// <exception cref="BAPAuthorizationException">Given entity is not configured for authorization.</exception>
        public virtual bool IsAllowedToWrite(IBapEntity entity = null)
        {
            bool result = true;
            var authItem = AuthMatrix.SingleOrDefault(i => i.EntityName == EntityType.Name);
            if (authItem == null)
                throw new BAPAuthorizationException("Given entity is not configured for authorization.");
            int permissionsToCheck = authItem.Permissions;

            if (entity != null)
            {
                permissionsToCheck = entity.OwnerPermissions;
            }

            string userId = GetCurrentUserId();
            if (!string.IsNullOrEmpty(userId))
            {
                var roles = GetCurrentRoles(userId, entity);

                if ((roles & AuthorizationConstants.AdminRole) == AuthorizationConstants.AdminRole)
                    result = (permissionsToCheck & AuthorizationConstants.AdminWritePermission) == AuthorizationConstants.AdminWritePermission;
                if (result && (roles & AuthorizationConstants.UserRole) == AuthorizationConstants.UserRole)
                    result = (permissionsToCheck & AuthorizationConstants.UserWritePermission) == AuthorizationConstants.UserWritePermission;
                if (result && (roles & AuthorizationConstants.OwnerRole) == AuthorizationConstants.OwnerRole)
                    result = (permissionsToCheck & AuthorizationConstants.OwnerWritePermission) == AuthorizationConstants.OwnerWritePermission;
                if (result && (roles & AuthorizationConstants.ContentManagerRole) == AuthorizationConstants.ContentManagerRole)
                    result = (permissionsToCheck & AuthorizationConstants.ContentManagerWritePermission) == AuthorizationConstants.ContentManagerWritePermission;
                if (result && (roles & AuthorizationConstants.SupervisorRole) == AuthorizationConstants.SupervisorRole)
                    result = (permissionsToCheck & AuthorizationConstants.SupervisorWritePermission) == AuthorizationConstants.SupervisorWritePermission;
            }
            else
            {
                result = (permissionsToCheck & AuthorizationConstants.PublicWritePermission) == AuthorizationConstants.PublicWritePermission;
            }

            return result;
        }

        /// <summary>
        /// Determines whether [is allowed to delete] [the specified entity].
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if [is allowed to delete] [the specified entity]; otherwise, <c>false</c>.</returns>
        /// <exception cref="BAPAuthorizationException">Given entity is not configured for authorization.</exception>
        public virtual bool IsAllowedToDelete(IBapEntity entity)
        {
            bool result = true;
            var authItem = AuthMatrix.SingleOrDefault(i => i.EntityName == EntityType.Name);
            if (authItem == null)
                throw new BAPAuthorizationException("Given entity is not configured for authorization.");
            int permissionsToCheck = authItem.Permissions;

            if (entity != null)
            {
                permissionsToCheck = entity.OwnerPermissions;
            }

            string userId = GetCurrentUserId();
            if (!string.IsNullOrEmpty(userId))
            {
                var roles = GetCurrentRoles(userId, entity);

                if ((roles & AuthorizationConstants.AdminRole) == AuthorizationConstants.AdminRole)
                    result = (permissionsToCheck & AuthorizationConstants.AdminDeletePermission) == AuthorizationConstants.AdminDeletePermission;
                if (result && (roles & AuthorizationConstants.UserRole) == AuthorizationConstants.UserRole)
                    result = (permissionsToCheck & AuthorizationConstants.UserDeletePermission) == AuthorizationConstants.UserDeletePermission;
                if (result && (roles & AuthorizationConstants.OwnerRole) == AuthorizationConstants.OwnerRole)
                    result = (permissionsToCheck & AuthorizationConstants.OwnerDeletePermission) == AuthorizationConstants.OwnerDeletePermission;
                if (result && (roles & AuthorizationConstants.ContentManagerRole) == AuthorizationConstants.ContentManagerRole)
                    result = (permissionsToCheck & AuthorizationConstants.ContentManagerDeletePermission) == AuthorizationConstants.ContentManagerDeletePermission;
                if (result && (roles & AuthorizationConstants.SupervisorRole) == AuthorizationConstants.SupervisorRole)
                    result = (permissionsToCheck & AuthorizationConstants.SupervisorDeletePermission) == AuthorizationConstants.SupervisorDeletePermission;
            }
            else
            {
                result = (permissionsToCheck & AuthorizationConstants.PublicDeletePermission) == AuthorizationConstants.PublicDeletePermission;
            }

            return result;
        }

        /// <summary>
        /// Publics the can read.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool PublicCanRead(IBapEntity entity)
        {
            if (entity != null)
            {
                return ((entity.OwnerPermissions & AuthorizationConstants.PublicReadPermission) == AuthorizationConstants.PublicReadPermission);
            }

            return false;
        }

        /// <summary>
        /// Sets the public read.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="value">if set to <c>true</c> [value].</param>
        public void SetPublicRead(IBapEntity entity, bool value)
        {
            if (entity == null)
                return;
            if (PublicCanRead(entity) && !value)
                entity.OwnerPermissions -= AuthorizationConstants.PublicReadPermission;

            if (!PublicCanRead(entity) && value)
                entity.OwnerPermissions += AuthorizationConstants.PublicReadPermission;
        }

        /// <summary>
        /// Permissions the appplied.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="flag">The flag.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool PermissionAppplied(IBapEntity entity, int flag)
        {
            return (entity != null && (entity.OwnerPermissions & flag) == flag);
        }

        /// <summary>
        /// Sets the permission.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="flag">The flag.</param>
        public void SetPermission(IBapEntity entity, int flag)
        {
            if (entity != null && !PermissionAppplied(entity, flag))
                entity.OwnerPermissions += flag;
        }

        /// <summary>
        /// Unsets the permission.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="flag">The flag.</param>
        public void UnsetPermission(IBapEntity entity, int flag)
        {
            if (entity != null && PermissionAppplied(entity, flag))
                entity.OwnerPermissions -= flag;
        }
    }
}
