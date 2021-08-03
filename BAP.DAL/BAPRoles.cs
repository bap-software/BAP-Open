// ***********************************************************************
// Assembly         : BAP.DAL
// Author           : Victor Mamray
// Created          : 04-23-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="BAPRoles.cs" company="BAP Software Ltd.">
//     Copyright © 2015 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;

using BAP.Common;

namespace BAP.DAL
{
    /// <summary>
    /// Class BAPRoles.
    /// Implements the <see cref="BAP.Common.IRolePermissionProvider" />
    /// </summary>
    /// <seealso cref="BAP.Common.IRolePermissionProvider" />
    public class BAPRoles : IRolePermissionProvider
    {
        /// <summary>
        /// Gets the permissions.
        /// </summary>
        /// <value>The permissions.</value>
        public IList<IBapPermission> Permissions
        {
            get
            {
                return new List<IBapPermission>()
                {
                    new AdminReadPermission(), new AdminWritePermission(), new AdminDeletePermission(),
                    new UserReadPermission(), new UserWritePermission(), new UserDeletePermission(),
                    new ContentManagerReadPermission(), new ContentManagerWritePermission(), new ContentManagerDeletePermission(),
                    new OwnerReadPermission(), new OwnerWritePermission(), new OwnerDeletePermission(),
                    new PublicReadPermission(), new PublicWritePermission(), new PublicDeletePermission(),
                    new SupervisorReadPermission(), new SupervisorWritePermission(), new SupervisorDeletePermission(),
                };
            }
        }

        /// <summary>
        /// Gets the roles.
        /// </summary>
        /// <value>The roles.</value>
        public IList<IBapRole> Roles
        {
            get
            {
                return new List<IBapRole>() { new AdministratorRole(), new UserRole(), new ContentManagerRole(), new OwnerRole(), new PublicRole(), new SupervisorRole() };                
            }
        }
    }

    // Built-in BAP roles
    /// <summary>
    /// Class AdministratorRole.
    /// Implements the <see cref="BAP.Common.IBapRole" />
    /// </summary>
    /// <seealso cref="BAP.Common.IBapRole" />
    public class AdministratorRole : IBapRole
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id
        {
            get
            {
                return 1;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is public.
        /// </summary>
        /// <value><c>true</c> if this instance is public; otherwise, <c>false</c>.</value>
        public bool IsPublic
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get
            {
                return "Administrator";
            }
        }
    }

    /// <summary>
    /// Class UserRole.
    /// Implements the <see cref="BAP.Common.IBapRole" />
    /// </summary>
    /// <seealso cref="BAP.Common.IBapRole" />
    public class UserRole : IBapRole
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id
        {
            get
            {
                return 2;
            }
        }
        /// <summary>
        /// Gets a value indicating whether this instance is public.
        /// </summary>
        /// <value><c>true</c> if this instance is public; otherwise, <c>false</c>.</value>
        public bool IsPublic
        {
            get
            {
                return false;
            }
        }
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get
            {
                return "User";
            }
        }
    }

    /// <summary>
    /// Class ContentManagerRole.
    /// Implements the <see cref="BAP.Common.IBapRole" />
    /// </summary>
    /// <seealso cref="BAP.Common.IBapRole" />
    public class ContentManagerRole : IBapRole
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id
        {
            get
            {
                return 4;
            }
        }
        /// <summary>
        /// Gets a value indicating whether this instance is public.
        /// </summary>
        /// <value><c>true</c> if this instance is public; otherwise, <c>false</c>.</value>
        public bool IsPublic
        {
            get
            {
                return false;
            }
        }
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get
            {
                return "ContentManager";
            }
        }
    }

    /// <summary>
    /// Class OwnerRole.
    /// Implements the <see cref="BAP.Common.IBapRole" />
    /// </summary>
    /// <seealso cref="BAP.Common.IBapRole" />
    public class OwnerRole : IBapRole
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id
        {
            get
            {
                return 8;
            }
        }
        /// <summary>
        /// Gets a value indicating whether this instance is public.
        /// </summary>
        /// <value><c>true</c> if this instance is public; otherwise, <c>false</c>.</value>
        public bool IsPublic
        {
            get
            {
                return false;
            }
        }
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get
            {
                return "Owner";
            }
        }
    }

    /// <summary>
    /// Class PublicRole.
    /// Implements the <see cref="BAP.Common.IBapRole" />
    /// </summary>
    /// <seealso cref="BAP.Common.IBapRole" />
    public class PublicRole : IBapRole
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id
        {
            get
            {
                return 16;
            }
        }
        /// <summary>
        /// Gets a value indicating whether this instance is public.
        /// </summary>
        /// <value><c>true</c> if this instance is public; otherwise, <c>false</c>.</value>
        public bool IsPublic
        {
            get
            {
                return true;
            }
        }
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get
            {
                return "Public";
            }
        }
    }

    /// <summary>
    /// Class SupervisorRole.
    /// Implements the <see cref="BAP.Common.IBapRole" />
    /// </summary>
    /// <seealso cref="BAP.Common.IBapRole" />
    public class SupervisorRole : IBapRole
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id
        {
            get
            {
                return 64;
            }
        }
        /// <summary>
        /// Gets a value indicating whether this instance is public.
        /// </summary>
        /// <value><c>true</c> if this instance is public; otherwise, <c>false</c>.</value>
        public bool IsPublic
        {
            get
            {
                return false;
            }
        }
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get
            {
                return "Supervisor";
            }
        }
    }

    // Built-in BAP role permissions
    /// <summary>
    /// Class AdminReadPermission.
    /// Implements the <see cref="BAP.Common.IBapPermission" />
    /// </summary>
    /// <seealso cref="BAP.Common.IBapPermission" />
    public class AdminReadPermission : IBapPermission
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id
        {
            get
            {
                return 1;
            }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get
            {
                return "AdminReadPermission";
            }
        }

        /// <summary>
        /// Gets the role.
        /// </summary>
        /// <value>The role.</value>
        public IBapRole Role
        {
            get
            {
                return new AdministratorRole();
            }
        }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        public BapPermissionType Type
        {
            get
            {
                return BapPermissionType.Read;
            }
        }
    }
    /// <summary>
    /// Class AdminWritePermission.
    /// Implements the <see cref="BAP.Common.IBapPermission" />
    /// </summary>
    /// <seealso cref="BAP.Common.IBapPermission" />
    public class AdminWritePermission : IBapPermission
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id
        {
            get
            {
                return 2;
            }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get
            {
                return "AdminWritePermission";
            }
        }

        /// <summary>
        /// Gets the role.
        /// </summary>
        /// <value>The role.</value>
        public IBapRole Role
        {
            get
            {
                return new AdministratorRole();
            }
        }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        public BapPermissionType Type
        {
            get
            {
                return BapPermissionType.Write;
            }
        }
    }
    /// <summary>
    /// Class AdminDeletePermission.
    /// Implements the <see cref="BAP.Common.IBapPermission" />
    /// </summary>
    /// <seealso cref="BAP.Common.IBapPermission" />
    public class AdminDeletePermission : IBapPermission
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id
        {
            get
            {
                return 4;
            }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get
            {
                return "AdminDeletePermission";
            }
        }

        /// <summary>
        /// Gets the role.
        /// </summary>
        /// <value>The role.</value>
        public IBapRole Role
        {
            get
            {
                return new AdministratorRole();
            }
        }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        public BapPermissionType Type
        {
            get
            {
                return BapPermissionType.Delete;
            }
        }
    }

    /// <summary>
    /// Class UserReadPermission.
    /// Implements the <see cref="BAP.Common.IBapPermission" />
    /// </summary>
    /// <seealso cref="BAP.Common.IBapPermission" />
    public class UserReadPermission : IBapPermission
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id
        {
            get
            {
                return 8;
            }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get
            {
                return "UserReadPermission";
            }
        }

        /// <summary>
        /// Gets the role.
        /// </summary>
        /// <value>The role.</value>
        public IBapRole Role
        {
            get
            {
                return new UserRole();
            }
        }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        public BapPermissionType Type
        {
            get
            {
                return BapPermissionType.Read;
            }
        }
    }
    /// <summary>
    /// Class UserWritePermission.
    /// Implements the <see cref="BAP.Common.IBapPermission" />
    /// </summary>
    /// <seealso cref="BAP.Common.IBapPermission" />
    public class UserWritePermission : IBapPermission
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id
        {
            get
            {
                return 16;
            }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get
            {
                return "UserWritePermission";
            }
        }

        /// <summary>
        /// Gets the role.
        /// </summary>
        /// <value>The role.</value>
        public IBapRole Role
        {
            get
            {
                return new UserRole();
            }
        }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        public BapPermissionType Type
        {
            get
            {
                return BapPermissionType.Write;
            }
        }
    }
    /// <summary>
    /// Class UserDeletePermission.
    /// Implements the <see cref="BAP.Common.IBapPermission" />
    /// </summary>
    /// <seealso cref="BAP.Common.IBapPermission" />
    public class UserDeletePermission : IBapPermission
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id
        {
            get
            {
                return 32;
            }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get
            {
                return "UserDeletePermission";
            }
        }

        /// <summary>
        /// Gets the role.
        /// </summary>
        /// <value>The role.</value>
        public IBapRole Role
        {
            get
            {
                return new UserRole();
            }
        }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        public BapPermissionType Type
        {
            get
            {
                return BapPermissionType.Delete;
            }
        }
    }

    /// <summary>
    /// Class ContentManagerReadPermission.
    /// Implements the <see cref="BAP.Common.IBapPermission" />
    /// </summary>
    /// <seealso cref="BAP.Common.IBapPermission" />
    public class ContentManagerReadPermission : IBapPermission
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id
        {
            get
            {
                return 64;
            }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get
            {
                return "ContentManagerReadPermission";
            }
        }

        /// <summary>
        /// Gets the role.
        /// </summary>
        /// <value>The role.</value>
        public IBapRole Role
        {
            get
            {
                return new ContentManagerRole();
            }
        }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        public BapPermissionType Type
        {
            get
            {
                return BapPermissionType.Read;
            }
        }
    }
    /// <summary>
    /// Class ContentManagerWritePermission.
    /// Implements the <see cref="BAP.Common.IBapPermission" />
    /// </summary>
    /// <seealso cref="BAP.Common.IBapPermission" />
    public class ContentManagerWritePermission : IBapPermission
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id
        {
            get
            {
                return 128;
            }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get
            {
                return "ContentManagerWritePermission";
            }
        }

        /// <summary>
        /// Gets the role.
        /// </summary>
        /// <value>The role.</value>
        public IBapRole Role
        {
            get
            {
                return new ContentManagerRole();
            }
        }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        public BapPermissionType Type
        {
            get
            {
                return BapPermissionType.Write;
            }
        }
    }
    /// <summary>
    /// Class ContentManagerDeletePermission.
    /// Implements the <see cref="BAP.Common.IBapPermission" />
    /// </summary>
    /// <seealso cref="BAP.Common.IBapPermission" />
    public class ContentManagerDeletePermission : IBapPermission
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id
        {
            get
            {
                return 256;
            }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get
            {
                return "ContentManagerDeletePermission";
            }
        }

        /// <summary>
        /// Gets the role.
        /// </summary>
        /// <value>The role.</value>
        public IBapRole Role
        {
            get
            {
                return new ContentManagerRole();
            }
        }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        public BapPermissionType Type
        {
            get
            {
                return BapPermissionType.Delete;
            }
        }
    }

    /// <summary>
    /// Class OwnerReadPermission.
    /// Implements the <see cref="BAP.Common.IBapPermission" />
    /// </summary>
    /// <seealso cref="BAP.Common.IBapPermission" />
    public class OwnerReadPermission : IBapPermission
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id
        {
            get
            {
                return 512;
            }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get
            {
                return "OwnerReadPermission";
            }
        }

        /// <summary>
        /// Gets the role.
        /// </summary>
        /// <value>The role.</value>
        public IBapRole Role
        {
            get
            {
                return new OwnerRole();
            }
        }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        public BapPermissionType Type
        {
            get
            {
                return BapPermissionType.Read;
            }
        }
    }
    /// <summary>
    /// Class OwnerWritePermission.
    /// Implements the <see cref="BAP.Common.IBapPermission" />
    /// </summary>
    /// <seealso cref="BAP.Common.IBapPermission" />
    public class OwnerWritePermission : IBapPermission
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id
        {
            get
            {
                return 1024;
            }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get
            {
                return "OwnerWritePermission";
            }
        }

        /// <summary>
        /// Gets the role.
        /// </summary>
        /// <value>The role.</value>
        public IBapRole Role
        {
            get
            {
                return new OwnerRole();
            }
        }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        public BapPermissionType Type
        {
            get
            {
                return BapPermissionType.Write;
            }
        }
    }
    /// <summary>
    /// Class OwnerDeletePermission.
    /// Implements the <see cref="BAP.Common.IBapPermission" />
    /// </summary>
    /// <seealso cref="BAP.Common.IBapPermission" />
    public class OwnerDeletePermission : IBapPermission
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id
        {
            get
            {
                return 2048;
            }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get
            {
                return "OwnerDeletePermission";
            }
        }

        /// <summary>
        /// Gets the role.
        /// </summary>
        /// <value>The role.</value>
        public IBapRole Role
        {
            get
            {
                return new OwnerRole();
            }
        }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        public BapPermissionType Type
        {
            get
            {
                return BapPermissionType.Delete;
            }
        }
    }

    /// <summary>
    /// Class PublicReadPermission.
    /// Implements the <see cref="BAP.Common.IBapPermission" />
    /// </summary>
    /// <seealso cref="BAP.Common.IBapPermission" />
    public class PublicReadPermission : IBapPermission
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id
        {
            get
            {
                return 4096;
            }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get
            {
                return "PublicReadPermission";
            }
        }

        /// <summary>
        /// Gets the role.
        /// </summary>
        /// <value>The role.</value>
        public IBapRole Role
        {
            get
            {
                return new PublicRole();
            }
        }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        public BapPermissionType Type
        {
            get
            {
                return BapPermissionType.Read;
            }
        }
    }
    /// <summary>
    /// Class PublicWritePermission.
    /// Implements the <see cref="BAP.Common.IBapPermission" />
    /// </summary>
    /// <seealso cref="BAP.Common.IBapPermission" />
    public class PublicWritePermission : IBapPermission
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id
        {
            get
            {
                return 8192;
            }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get
            {
                return "PublicWritePermission";
            }
        }

        /// <summary>
        /// Gets the role.
        /// </summary>
        /// <value>The role.</value>
        public IBapRole Role
        {
            get
            {
                return new PublicRole();
            }
        }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        public BapPermissionType Type
        {
            get
            {
                return BapPermissionType.Write;
            }
        }
    }
    /// <summary>
    /// Class PublicDeletePermission.
    /// Implements the <see cref="BAP.Common.IBapPermission" />
    /// </summary>
    /// <seealso cref="BAP.Common.IBapPermission" />
    public class PublicDeletePermission : IBapPermission
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id
        {
            get
            {
                return 16384;
            }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get
            {
                return "PublicDeletePermission";
            }
        }

        /// <summary>
        /// Gets the role.
        /// </summary>
        /// <value>The role.</value>
        public IBapRole Role
        {
            get
            {
                return new PublicRole();
            }
        }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        public BapPermissionType Type
        {
            get
            {
                return BapPermissionType.Delete;
            }
        }
    }

    /// <summary>
    /// Class SupervisorReadPermission.
    /// Implements the <see cref="BAP.Common.IBapPermission" />
    /// </summary>
    /// <seealso cref="BAP.Common.IBapPermission" />
    public class SupervisorReadPermission : IBapPermission
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id
        {
            get
            {
                return 262144;
            }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get
            {
                return "SupervisorReadPermission";
            }
        }

        /// <summary>
        /// Gets the role.
        /// </summary>
        /// <value>The role.</value>
        public IBapRole Role
        {
            get
            {
                return new SupervisorRole();
            }
        }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        public BapPermissionType Type
        {
            get
            {
                return BapPermissionType.Read;
            }
        }
    }
    /// <summary>
    /// Class SupervisorWritePermission.
    /// Implements the <see cref="BAP.Common.IBapPermission" />
    /// </summary>
    /// <seealso cref="BAP.Common.IBapPermission" />
    public class SupervisorWritePermission : IBapPermission
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id
        {
            get
            {
                return 524288;
            }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get
            {
                return "SupervisorWritePermission";
            }
        }

        /// <summary>
        /// Gets the role.
        /// </summary>
        /// <value>The role.</value>
        public IBapRole Role
        {
            get
            {
                return new SupervisorRole();
            }
        }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        public BapPermissionType Type
        {
            get
            {
                return BapPermissionType.Write;
            }
        }
    }
    /// <summary>
    /// Class SupervisorDeletePermission.
    /// Implements the <see cref="BAP.Common.IBapPermission" />
    /// </summary>
    /// <seealso cref="BAP.Common.IBapPermission" />
    public class SupervisorDeletePermission : IBapPermission
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id
        {
            get
            {
                return 1048576;
            }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get
            {
                return "SupervisorDeletePermission";
            }
        }

        /// <summary>
        /// Gets the role.
        /// </summary>
        /// <value>The role.</value>
        public IBapRole Role
        {
            get
            {
                return new SupervisorRole();
            }
        }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        public BapPermissionType Type
        {
            get
            {
                return BapPermissionType.Delete;
            }
        }
    }
}
