// ***********************************************************************
// Assembly         : BAP.DB.eCommerce
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="201912141639108_Customer_Update.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.DB.eCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Class Customer_Update.
    /// Implements the <see cref="System.Data.Entity.Migrations.DbMigration" />
    /// Implements the <see cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    /// </summary>
    /// <seealso cref="System.Data.Entity.Migrations.DbMigration" />
    /// <seealso cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    public partial class Customer_Update : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            CreateIndex("dbo.Customer", "PrefferedShippingOptionId");
            CreateIndex("dbo.Customer", "PrefferedCurrencyId");
            AddForeignKey("dbo.Customer", "PrefferedCurrencyId", "dbo.Currency", "Id");
            AddForeignKey("dbo.Customer", "PrefferedShippingOptionId", "dbo.ShippingOption", "Id");
        }

        /// <summary>
        /// Downs this instance.
        /// </summary>
        public override void Down()
        {
            DropForeignKey("dbo.Customer", "PrefferedShippingOptionId", "dbo.ShippingOption");
            DropForeignKey("dbo.Customer", "PrefferedCurrencyId", "dbo.Currency");
            DropIndex("dbo.Customer", new[] { "PrefferedCurrencyId" });
            DropIndex("dbo.Customer", new[] { "PrefferedShippingOptionId" });
        }
    }
}
