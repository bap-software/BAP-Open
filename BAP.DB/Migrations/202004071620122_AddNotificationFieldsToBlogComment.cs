// ***********************************************************************
// Assembly         : BAP.DB.eCommerce
// Author           : Victor Mamray
// Created          : 04-08-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="202004071620122_AddNotificationFieldsToBlogComment.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.DB.eCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Class AddNotificationFieldsToBlogComment.
    /// Implements the <see cref="System.Data.Entity.Migrations.DbMigration" />
    /// Implements the <see cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    /// </summary>
    /// <seealso cref="System.Data.Entity.Migrations.DbMigration" />
    /// <seealso cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    public partial class AddNotificationFieldsToBlogComment : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            AddColumn("dbo.BlogComment", "NotifyAuthorByEmail", c => c.Boolean(nullable: false));
            AddColumn("dbo.BlogComment", "CommentAuthorUserId", c => c.Int());
            CreateIndex("dbo.BlogComment", "CommentAuthorUserId");
            AddForeignKey("dbo.BlogComment", "CommentAuthorUserId", "dbo.OrganizationUser", "Id");
        }

        /// <summary>
        /// Downs this instance.
        /// </summary>
        public override void Down()
        {
            DropForeignKey("dbo.BlogComment", "CommentAuthorUserId", "dbo.OrganizationUser");
            DropIndex("dbo.BlogComment", new[] { "CommentAuthorUserId" });
            DropColumn("dbo.BlogComment", "CommentAuthorUserId");
            DropColumn("dbo.BlogComment", "NotifyAuthorByEmail");
        }
    }
}
