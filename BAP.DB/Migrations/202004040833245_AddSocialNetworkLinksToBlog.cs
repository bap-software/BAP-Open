// ***********************************************************************
// Assembly         : BAP.DB.eCommerce
// Author           : Victor Mamray
// Created          : 04-05-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="202004040833245_AddSocialNetworkLinksToBlog.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.DB.eCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Class AddSocialNetworkLinksToBlog.
    /// Implements the <see cref="System.Data.Entity.Migrations.DbMigration" />
    /// Implements the <see cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    /// </summary>
    /// <seealso cref="System.Data.Entity.Migrations.DbMigration" />
    /// <seealso cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    public partial class AddSocialNetworkLinksToBlog : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            AddColumn("dbo.Blog", "FacebookUrl", c => c.String(maxLength: 255));
            AddColumn("dbo.Blog", "TwitterUrl", c => c.String(maxLength: 255));
            AddColumn("dbo.Blog", "LinkedinUrl", c => c.String(maxLength: 255));
            AddColumn("dbo.Blog", "GoogleplusUrl", c => c.String(maxLength: 255));
        }

        /// <summary>
        /// Downs this instance.
        /// </summary>
        public override void Down()
        {
            DropColumn("dbo.Blog", "GoogleplusUrl");
            DropColumn("dbo.Blog", "LinkedinUrl");
            DropColumn("dbo.Blog", "TwitterUrl");
            DropColumn("dbo.Blog", "FacebookUrl");
        }
    }
}
