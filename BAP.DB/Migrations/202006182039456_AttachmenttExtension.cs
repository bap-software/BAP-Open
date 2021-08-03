// ***********************************************************************
// Assembly         : BAP.DB.eCommerce
// Author           : Victor Mamray
// Created          : 06-19-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-19-2020
// ***********************************************************************
// <copyright file="202006182039456_AttachmenttExtension.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.DB.eCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Class AttachmenttExtension.
    /// Implements the <see cref="System.Data.Entity.Migrations.DbMigration" />
    /// Implements the <see cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    /// </summary>
    /// <seealso cref="System.Data.Entity.Migrations.DbMigration" />
    /// <seealso cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    public partial class AttachmenttExtension : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            CreateTable(
                "dbo.AttachmentAccess",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        AttachmentId = c.Int(),
                        PublicAccessToken = c.String(maxLength: 1024),
                        AccessTokenExpiresAt = c.DateTime(),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                        EntityState = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Attachment", t => t.AttachmentId)
                .Index(t => t.AttachmentId)
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_Tenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
            DropColumn("dbo.Attachment", "PublicAccessToken");
            DropColumn("dbo.Attachment", "AccessTokenExpiresAt");
        }

        /// <summary>
        /// Downs this instance.
        /// </summary>
        public override void Down()
        {
            AddColumn("dbo.Attachment", "AccessTokenExpiresAt", c => c.DateTime());
            AddColumn("dbo.Attachment", "PublicAccessToken", c => c.String(maxLength: 1024));
            DropForeignKey("dbo.AttachmentAccess", "AttachmentId", "dbo.Attachment");
            DropIndex("dbo.AttachmentAccess", new[] { "OwnerPermissions" });
            DropIndex("dbo.AttachmentAccess", new[] { "OwnerGroup" });
            DropIndex("dbo.AttachmentAccess", "IX_Tenant");
            DropIndex("dbo.AttachmentAccess", new[] { "AttachmentId" });
            DropTable("dbo.AttachmentAccess");
        }
    }
}
