// ***********************************************************************
// Assembly         : BAP.DB.eCommerce
// Author           : Victor Mamray
// Created          : 07-26-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 07-26-2020
// ***********************************************************************
// <copyright file="202007242322201_SragingEntity.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.DB.eCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Class SragingEntity.
    /// Implements the <see cref="System.Data.Entity.Migrations.DbMigration" />
    /// Implements the <see cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    /// </summary>
    /// <seealso cref="System.Data.Entity.Migrations.DbMigration" />
    /// <seealso cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    public partial class SragingEntity : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            CreateTable(
                "dbo.StagingEntity",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DescriptionClassFullyQualifiedName = c.String(maxLength: 512),
                        TargetEntityFullyQualifiedName = c.String(maxLength: 512),
                        JsonData = c.String(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_Tenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
        }

        /// <summary>
        /// Downs this instance.
        /// </summary>
        public override void Down()
        {
            DropIndex("dbo.StagingEntity", new[] { "OwnerPermissions" });
            DropIndex("dbo.StagingEntity", new[] { "OwnerGroup" });
            DropIndex("dbo.StagingEntity", "IX_Tenant");
            DropTable("dbo.StagingEntity");
        }
    }
}
