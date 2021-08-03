// ***********************************************************************
// Assembly         : BAP.DB.eCommerce
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="202002201115092_CreateDocumentTemplate.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.DB.eCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Class CreateDocumentTemplate.
    /// Implements the <see cref="System.Data.Entity.Migrations.DbMigration" />
    /// Implements the <see cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    /// </summary>
    /// <seealso cref="System.Data.Entity.Migrations.DbMigration" />
    /// <seealso cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    public partial class CreateDocumentTemplate : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            CreateTable(
                "dbo.DocumentTemplate",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 80),
                        ShortDescription = c.String(nullable: false, maxLength: 255),
                        Description = c.String(maxLength: 4000),
                        TemplateBody = c.String(),
                        IsEnabled = c.Boolean(nullable: false),
                        CultureCode = c.String(maxLength: 10),
                        LocalizationId = c.Guid(nullable: false),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "IX_DocumentTemplateName")
                .Index(t => t.CultureCode)
                .Index(t => t.LocalizationId)
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_Tenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
        }

        /// <summary>
        /// Downs this instance.
        /// </summary>
        public override void Down()
        {
            DropIndex("dbo.DocumentTemplate", new[] { "OwnerPermissions" });
            DropIndex("dbo.DocumentTemplate", new[] { "OwnerGroup" });
            DropIndex("dbo.DocumentTemplate", "IX_Tenant");
            DropIndex("dbo.DocumentTemplate", new[] { "LocalizationId" });
            DropIndex("dbo.DocumentTemplate", new[] { "CultureCode" });
            DropIndex("dbo.DocumentTemplate", "IX_DocumentTemplateName");
            DropTable("dbo.DocumentTemplate");
        }
    }
}
