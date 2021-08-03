// ***********************************************************************
// Assembly         : BAP.DB.eCommerce
// Author           : Victor Mamray
// Created          : 06-24-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-24-2020
// ***********************************************************************
// <copyright file="202006241708471_SystemExtension.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.DB.eCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Class SystemExtension.
    /// Implements the <see cref="System.Data.Entity.Migrations.DbMigration" />
    /// Implements the <see cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    /// </summary>
    /// <seealso cref="System.Data.Entity.Migrations.DbMigration" />
    /// <seealso cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    public partial class SystemExtension : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            AddColumn("dbo.Organization", "CookiesPopupEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Organization", "GdprPopupEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Store", "QuickShoppingCart", c => c.Boolean(nullable: false));
        }

        /// <summary>
        /// Downs this instance.
        /// </summary>
        public override void Down()
        {
            DropColumn("dbo.Store", "QuickShoppingCart");
            DropColumn("dbo.Organization", "GdprPopupEnabled");
            DropColumn("dbo.Organization", "CookiesPopupEnabled");
        }
    }
}
