// ***********************************************************************
// Assembly         : BAP.DB.eCommerce
// Author           : Victor Mamray
// Created          : 04-22-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="202004201252409_RemoveIndexFromOrganizationModules.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.DB.eCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Class RemoveIndexFromOrganizationModules.
    /// Implements the <see cref="System.Data.Entity.Migrations.DbMigration" />
    /// Implements the <see cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    /// </summary>
    /// <seealso cref="System.Data.Entity.Migrations.DbMigration" />
    /// <seealso cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    public partial class RemoveIndexFromOrganizationModules : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            DropIndex("dbo.OrganizationModule", "IX_MessageUnique");
            DropIndex("dbo.Module", "IX_MessageUnique");
        }

        /// <summary>
        /// Downs this instance.
        /// </summary>
        public override void Down()
        {
            CreateIndex("dbo.Module", "CreateDate", unique: true, name: "IX_MessageUnique");
            CreateIndex("dbo.OrganizationModule", "CreateDate", unique: true, name: "IX_MessageUnique");
        }
    }
}
