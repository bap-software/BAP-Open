// ***********************************************************************
// Assembly         : BAP.DB.eCommerce
// Author           : Victor Mamray
// Created          : 06-15-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="202006151728315_AttachmentExtend.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.DB.eCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Class AttachmentExtend.
    /// Implements the <see cref="System.Data.Entity.Migrations.DbMigration" />
    /// Implements the <see cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    /// </summary>
    /// <seealso cref="System.Data.Entity.Migrations.DbMigration" />
    /// <seealso cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    public partial class AttachmentExtend : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            DropIndex("dbo.Attachment", "IX_AttachmentNameObect");
            AddColumn("dbo.Attachment", "IsSecured", c => c.Boolean());
            AddColumn("dbo.Attachment", "AllowedToRoles", c => c.String(maxLength: 1024));
            AddColumn("dbo.Attachment", "PublicAccessToken", c => c.String(maxLength: 1024));
            AddColumn("dbo.Attachment", "AccessTokenExpiresAt", c => c.DateTime());
            CreateIndex("dbo.Attachment", new[] { "Name", "AttachmentType", "Object", "ObjectId", "TenantUnit", "TenantUnitId" }, unique: true, name: "IX_AttachmentNameObect");
        }

        /// <summary>
        /// Downs this instance.
        /// </summary>
        public override void Down()
        {
            DropIndex("dbo.Attachment", "IX_AttachmentNameObect");
            DropColumn("dbo.Attachment", "AccessTokenExpiresAt");
            DropColumn("dbo.Attachment", "PublicAccessToken");
            DropColumn("dbo.Attachment", "AllowedToRoles");
            DropColumn("dbo.Attachment", "IsSecured");
            CreateIndex("dbo.Attachment", new[] { "Name", "AttachmentType", "Object", "ObjectId" }, unique: true, name: "IX_AttachmentNameObect");
        }
    }
}
