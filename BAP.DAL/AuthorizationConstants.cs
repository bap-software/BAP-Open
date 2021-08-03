// ***********************************************************************
// Assembly         : BAP.DAL
// Author           : Victor Mamray
// Created          : 04-23-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="AuthorizationConstants.cs" company="BAP Software Ltd.">
//     Copyright © 2015 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.DAL
{
    /// <summary>
    /// Class AuthorizationConstants.
    /// </summary>
    public class AuthorizationConstants
    {
        //Organization Types
        //Primary organization, when running on cloud it represents BAP-Software itself
        /// <summary>
        /// The application owner organization
        /// </summary>
        public static readonly int ApplicationOwnerOrganization = 1;
        //Any child organization/tenant consuming BAP services. Can be also subdivision of 3rd-party corporation when running on-prem.
        /// <summary>
        /// The child tenant organization
        /// </summary>
        public static readonly int ChildTenantOrganization = 2;

        //Roles
        /// <summary>
        /// The admin role
        /// </summary>
        public static readonly int AdminRole = 1;
        /// <summary>
        /// The user role
        /// </summary>
        public static readonly int UserRole = 2;
        /// <summary>
        /// The content manager role
        /// </summary>
        public static readonly int ContentManagerRole = 4;
        /// <summary>
        /// The owner role
        /// </summary>
        public static readonly int OwnerRole = 8;
        /// <summary>
        /// The public role
        /// </summary>
        public static readonly int PublicRole = 16;
        /// <summary>
        /// The supervisor role
        /// </summary>
        public static readonly int SupervisorRole = 32;

        //Permissions
        /// <summary>
        /// The admin read permission
        /// </summary>
        public static readonly int AdminReadPermission = 1;
        /// <summary>
        /// The admin write permission
        /// </summary>
        public static readonly int AdminWritePermission = 2;
        /// <summary>
        /// The admin delete permission
        /// </summary>
        public static readonly int AdminDeletePermission = 4;
        /// <summary>
        /// The user read permission
        /// </summary>
        public static readonly int UserReadPermission = 8;
        /// <summary>
        /// The user write permission
        /// </summary>
        public static readonly int UserWritePermission = 16;
        /// <summary>
        /// The user delete permission
        /// </summary>
        public static readonly int UserDeletePermission = 32;
        /// <summary>
        /// The content manager read permission
        /// </summary>
        public static readonly int ContentManagerReadPermission = 64;
        /// <summary>
        /// The content manager write permission
        /// </summary>
        public static readonly int ContentManagerWritePermission = 128;
        /// <summary>
        /// The content manager delete permission
        /// </summary>
        public static readonly int ContentManagerDeletePermission = 256;
        /// <summary>
        /// The owner read permission
        /// </summary>
        public static readonly int OwnerReadPermission = 512;
        /// <summary>
        /// The owner write permission
        /// </summary>
        public static readonly int OwnerWritePermission = 1024;
        /// <summary>
        /// The owner delete permission
        /// </summary>
        public static readonly int OwnerDeletePermission = 2048;
        /// <summary>
        /// The public read permission
        /// </summary>
        public static readonly int PublicReadPermission = 4096;
        /// <summary>
        /// The public write permission
        /// </summary>
        public static readonly int PublicWritePermission = 8192;
        /// <summary>
        /// The public delete permission
        /// </summary>
        public static readonly int PublicDeletePermission = 16384;
        /// <summary>
        /// The agent read permission
        /// </summary>
        public static readonly int AgentReadPermission = 32768;
        /// <summary>
        /// The agent write permission
        /// </summary>
        public static readonly int AgentWritePermission = 65536;
        /// <summary>
        /// The agent delete permission
        /// </summary>
        public static readonly int AgentDeletePermission = 131072;
        /// <summary>
        /// The supervisor read permission
        /// </summary>
        public static readonly int SupervisorReadPermission = 262144;
        /// <summary>
        /// The supervisor write permission
        /// </summary>
        public static readonly int SupervisorWritePermission = 524288;
        /// <summary>
        /// The supervisor delete permission
        /// </summary>
        public static readonly int SupervisorDeletePermission = 1048576;
    }
}
