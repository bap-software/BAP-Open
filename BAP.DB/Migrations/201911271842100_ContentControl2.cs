// ***********************************************************************
// Assembly         : BAP.DB.eCommerce
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="201911271842100_ContentControl2.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.DB.eCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Class ContentControl2.
    /// Implements the <see cref="System.Data.Entity.Migrations.DbMigration" />
    /// Implements the <see cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    /// </summary>
    /// <seealso cref="System.Data.Entity.Migrations.DbMigration" />
    /// <seealso cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    public partial class ContentControl2 : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            AddColumn("dbo.ContentControl", "DisplayName", c => c.String(maxLength: 50));
            AddColumn("dbo.ContentControl", "HasDialog", c => c.Boolean(nullable: false));
            AddColumn("dbo.ContentControl", "HasCKEditor", c => c.Boolean(nullable: false));
            AddColumn("dbo.ContentControl", "ContentBefore", c => c.String(maxLength: 1024));
            AddColumn("dbo.ContentControl", "ContentAfter", c => c.String(maxLength: 1024));
            AddColumn("dbo.ContentControl", "MainCss", c => c.String(maxLength: 50));
            AddColumn("dbo.ContentControl", "IconCss", c => c.String(maxLength: 50));
            AddColumn("dbo.ContentControl", "ContainerTag", c => c.String(maxLength: 20));
            AddColumn("dbo.ContentControl", "DialogContent", c => c.String(maxLength: 1024));
            AddColumn("dbo.ContentControl", "ContentHolderFieldId", c => c.String(maxLength: 50));
            AddColumn("dbo.ContentControl", "JavaScriptContent", c => c.String(maxLength: 1024));
        }

        /// <summary>
        /// Downs this instance.
        /// </summary>
        public override void Down()
        {
            DropColumn("dbo.ContentControl", "JavaScriptContent");
            DropColumn("dbo.ContentControl", "ContentHolderFieldId");
            DropColumn("dbo.ContentControl", "DialogContent");
            DropColumn("dbo.ContentControl", "ContainerTag");
            DropColumn("dbo.ContentControl", "IconCss");
            DropColumn("dbo.ContentControl", "MainCss");
            DropColumn("dbo.ContentControl", "ContentAfter");
            DropColumn("dbo.ContentControl", "ContentBefore");
            DropColumn("dbo.ContentControl", "HasCKEditor");
            DropColumn("dbo.ContentControl", "HasDialog");
            DropColumn("dbo.ContentControl", "DisplayName");
        }
    }
}
