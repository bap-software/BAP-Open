// ***********************************************************************
// Assembly         : BAP.DB.eCommerce
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="201911250928045_StoreUpdate.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.DB.eCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Class StoreUpdate.
    /// Implements the <see cref="System.Data.Entity.Migrations.DbMigration" />
    /// Implements the <see cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    /// </summary>
    /// <seealso cref="System.Data.Entity.Migrations.DbMigration" />
    /// <seealso cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    public partial class StoreUpdate : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            DropForeignKey("dbo.Store", "AdminUserId", "dbo.OrganizationUser");
            DropForeignKey("dbo.Store", "OrganizationId", "dbo.Organization");
            DropIndex("dbo.Store", new[] { "OrganizationId" });
            DropIndex("dbo.Store", new[] { "AdminUserId" });
            AlterColumn("dbo.Store", "OrganizationId", c => c.Int(nullable: false));
            AlterColumn("dbo.Store", "AdminUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Store", "OrganizationId");
            CreateIndex("dbo.Store", "AdminUserId");
            AddForeignKey("dbo.Store", "AdminUserId", "dbo.OrganizationUser", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Store", "OrganizationId", "dbo.Organization", "Id", cascadeDelete: true);
        }

        /// <summary>
        /// Downs this instance.
        /// </summary>
        public override void Down()
        {
            DropForeignKey("dbo.Store", "OrganizationId", "dbo.Organization");
            DropForeignKey("dbo.Store", "AdminUserId", "dbo.OrganizationUser");
            DropIndex("dbo.Store", new[] { "AdminUserId" });
            DropIndex("dbo.Store", new[] { "OrganizationId" });
            AlterColumn("dbo.Store", "AdminUserId", c => c.Int());
            AlterColumn("dbo.Store", "OrganizationId", c => c.Int());
            CreateIndex("dbo.Store", "AdminUserId");
            CreateIndex("dbo.Store", "OrganizationId");
            AddForeignKey("dbo.Store", "OrganizationId", "dbo.Organization", "Id");
            AddForeignKey("dbo.Store", "AdminUserId", "dbo.OrganizationUser", "Id");
        }
    }
}
