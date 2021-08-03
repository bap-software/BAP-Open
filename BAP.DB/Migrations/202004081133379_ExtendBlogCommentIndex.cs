// ***********************************************************************
// Assembly         : BAP.DB.eCommerce
// Author           : Victor Mamray
// Created          : 04-08-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="202004081133379_ExtendBlogCommentIndex.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.DB.eCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Class ExtendBlogCommentIndex.
    /// Implements the <see cref="System.Data.Entity.Migrations.DbMigration" />
    /// Implements the <see cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    /// </summary>
    /// <seealso cref="System.Data.Entity.Migrations.DbMigration" />
    /// <seealso cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    public partial class ExtendBlogCommentIndex : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            DropIndex("dbo.BlogComment", "IX_BlogComment");
            DropIndex("dbo.BlogComment", new[] { "BlogId" });
            CreateIndex("dbo.BlogComment", new[] { "Title", "Author", "BlogId" }, unique: true, name: "IX_BlogComment");
        }

        /// <summary>
        /// Downs this instance.
        /// </summary>
        public override void Down()
        {
            DropIndex("dbo.BlogComment", "IX_BlogComment");
            CreateIndex("dbo.BlogComment", "BlogId");
            CreateIndex("dbo.BlogComment", new[] { "Title", "Author" }, unique: true, name: "IX_BlogComment");
        }
    }
}
