// ***********************************************************************
// Assembly         : BAP.DB.eCommerce
// Author           : Victor Mamray
// Created          : 06-08-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="202006071418124_UpdateCustomerOrder.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.DB.eCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Class UpdateCustomerOrder.
    /// Implements the <see cref="System.Data.Entity.Migrations.DbMigration" />
    /// Implements the <see cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    /// </summary>
    /// <seealso cref="System.Data.Entity.Migrations.DbMigration" />
    /// <seealso cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    public partial class UpdateCustomerOrder : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            DropForeignKey("dbo.CustomerOrder", "PaymentOptionId", "dbo.PaymentOption");
            DropForeignKey("dbo.CustomerOrder", "ShippingOptionId", "dbo.ShippingOption");
            DropIndex("dbo.CustomerOrder", new[] { "ShippingOptionId" });
            DropIndex("dbo.CustomerOrder", new[] { "PaymentOptionId" });
            AlterColumn("dbo.CustomerOrder", "ShippingOptionId", c => c.Int());
            AlterColumn("dbo.CustomerOrder", "PaymentOptionId", c => c.Int());
            CreateIndex("dbo.CustomerOrder", "ShippingOptionId");
            CreateIndex("dbo.CustomerOrder", "PaymentOptionId");
            AddForeignKey("dbo.CustomerOrder", "PaymentOptionId", "dbo.PaymentOption", "Id");
            AddForeignKey("dbo.CustomerOrder", "ShippingOptionId", "dbo.ShippingOption", "Id");
        }

        /// <summary>
        /// Downs this instance.
        /// </summary>
        public override void Down()
        {
            DropForeignKey("dbo.CustomerOrder", "ShippingOptionId", "dbo.ShippingOption");
            DropForeignKey("dbo.CustomerOrder", "PaymentOptionId", "dbo.PaymentOption");
            DropIndex("dbo.CustomerOrder", new[] { "PaymentOptionId" });
            DropIndex("dbo.CustomerOrder", new[] { "ShippingOptionId" });
            AlterColumn("dbo.CustomerOrder", "PaymentOptionId", c => c.Int(nullable: false));
            AlterColumn("dbo.CustomerOrder", "ShippingOptionId", c => c.Int(nullable: false));
            CreateIndex("dbo.CustomerOrder", "PaymentOptionId");
            CreateIndex("dbo.CustomerOrder", "ShippingOptionId");
            AddForeignKey("dbo.CustomerOrder", "ShippingOptionId", "dbo.ShippingOption", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CustomerOrder", "PaymentOptionId", "dbo.PaymentOption", "Id", cascadeDelete: true);
        }
    }
}
