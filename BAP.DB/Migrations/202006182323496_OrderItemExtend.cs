// ***********************************************************************
// Assembly         : BAP.DB.eCommerce
// Author           : Victor Mamray
// Created          : 06-19-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-19-2020
// ***********************************************************************
// <copyright file="202006182323496_OrderItemExtend.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.DB.eCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Class OrderItemExtend.
    /// Implements the <see cref="System.Data.Entity.Migrations.DbMigration" />
    /// Implements the <see cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    /// </summary>
    /// <seealso cref="System.Data.Entity.Migrations.DbMigration" />
    /// <seealso cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    public partial class OrderItemExtend : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            AddColumn("dbo.OrderItem", "DownloadUrl", c => c.String(maxLength: 1024));
            AddColumn("dbo.OrderItem", "OnlineProductUrl", c => c.String(maxLength: 1024));

        }

        /// <summary>
        /// Downs this instance.
        /// </summary>
        public override void Down()
        {
            DropColumn("dbo.OrderItem", "DownloadUrl");
            DropColumn("dbo.OrderItem", "OnlineProductUrl");
        }
    }
}
