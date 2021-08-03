// ***********************************************************************
// Assembly         : BAP.DB.eCommerce
// Author           : Victor Mamray
// Created          : 07-20-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 07-20-2020
// ***********************************************************************
// <copyright file="202007191807243_Localizations.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.DB.eCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Class Localizations.
    /// Implements the <see cref="System.Data.Entity.Migrations.DbMigration" />
    /// Implements the <see cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    /// </summary>
    /// <seealso cref="System.Data.Entity.Migrations.DbMigration" />
    /// <seealso cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    public partial class Localizations : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            CreateTable(
                "dbo.Localization",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 1024),
                        ResourceSet = c.String(maxLength: 80),
                        FileName = c.String(maxLength: 512),
                        Value = c.String(),
                        CultureCode = c.String(maxLength: 10),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.CultureCode)
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_Tenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
        }

        /// <summary>
        /// Downs this instance.
        /// </summary>
        public override void Down()
        {
            DropIndex("dbo.Localization", new[] { "OwnerPermissions" });
            DropIndex("dbo.Localization", new[] { "OwnerGroup" });
            DropIndex("dbo.Localization", "IX_Tenant");
            DropIndex("dbo.Localization", new[] { "CultureCode" });
            DropTable("dbo.Localization");
        }
    }
}
