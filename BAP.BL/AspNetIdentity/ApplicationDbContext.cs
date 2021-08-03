// ***********************************************************************
// Assembly         : BAP.BL
// Author           : Victor Mamray
// Created          : 06-26-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-26-2020
// ***********************************************************************
// <copyright file="ApplicationDbContext.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using BAP.Common;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Mvc;

namespace BAP.BL.AspNetIdentity
{
    /// <summary>
    /// Class ApplicationDbContext.
    /// Implements the <see cref="Microsoft.AspNet.Identity.EntityFramework.IdentityDbContext{BAP.BL.AspNetIdentity.ApplicationUser}" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNet.Identity.EntityFramework.IdentityDbContext{BAP.BL.AspNetIdentity.ApplicationUser}" />
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        /// <param name="dbConnName">Name of the database connection.</param>
        public ApplicationDbContext(string dbConnName)
            : base(dbConnName, throwIfV1Schema: false)
        {
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>ApplicationDbContext.</returns>
        public static ApplicationDbContext Create()
        {
            var config = DependencyResolver.Current.GetService<IConfigHelper>();
            return new ApplicationDbContext(config.BapDbConnName);
        }
    }
}
