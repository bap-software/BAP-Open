// ***********************************************************************
// Assembly         : BAP.DB.eCommerce
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="202007282306338_ReworkLocalization2.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.DB.eCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Class ReworkLocalization2.
    /// Implements the <see cref="System.Data.Entity.Migrations.DbMigration" />
    /// Implements the <see cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    /// </summary>
    /// <seealso cref="System.Data.Entity.Migrations.DbMigration" />
    /// <seealso cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    public partial class ReworkLocalization2 : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            DropIndex("dbo.Product", new[] { "CultureCode" });
            DropIndex("dbo.Product", new[] { "LocalizationId" });
            DropColumn("dbo.Product", "CultureCode");
            DropColumn("dbo.Product", "LocalizationId");
        }

        /// <summary>
        /// Downs this instance.
        /// </summary>
        public override void Down()
        {
            AddColumn("dbo.Product", "LocalizationId", c => c.Guid(nullable: false));
            AddColumn("dbo.Product", "CultureCode", c => c.String(maxLength: 10));
            CreateIndex("dbo.Product", "LocalizationId");
            CreateIndex("dbo.Product", "CultureCode");
        }
    }
}
