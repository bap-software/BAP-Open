// ***********************************************************************
// Assembly         : BAP.DB.eCommerce
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="202003051315598_AddOrganizationModule.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.DB.eCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Class AddOrganizationModule.
    /// Implements the <see cref="System.Data.Entity.Migrations.DbMigration" />
    /// Implements the <see cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    /// </summary>
    /// <seealso cref="System.Data.Entity.Migrations.DbMigration" />
    /// <seealso cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    public partial class AddOrganizationModule : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            CreateTable(
                "dbo.OrganizationModule",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 80),
                        ModuleId = c.Int(),
                        OrganizationId = c.Int(),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Module", t => t.ModuleId)
                .ForeignKey("dbo.Organization", t => t.OrganizationId)
                .Index(t => t.Name, unique: true, name: "IX_Module")
                .Index(t => t.ModuleId)
                .Index(t => t.OrganizationId)
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_Tenant")
                .Index(t => t.CreateDate, unique: true, name: "IX_MessageUnique")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
        }

        /// <summary>
        /// Downs this instance.
        /// </summary>
        public override void Down()
        {
            DropForeignKey("dbo.OrganizationModule", "OrganizationId", "dbo.Organization");
            DropForeignKey("dbo.OrganizationModule", "ModuleId", "dbo.Module");
            DropIndex("dbo.OrganizationModule", new[] { "OwnerPermissions" });
            DropIndex("dbo.OrganizationModule", new[] { "OwnerGroup" });
            DropIndex("dbo.OrganizationModule", "IX_MessageUnique");
            DropIndex("dbo.OrganizationModule", "IX_Tenant");
            DropIndex("dbo.OrganizationModule", new[] { "OrganizationId" });
            DropIndex("dbo.OrganizationModule", new[] { "ModuleId" });
            DropIndex("dbo.OrganizationModule", "IX_Module");
            DropTable("dbo.OrganizationModule");
        }
    }
}
