// ***********************************************************************
// Assembly         : BAP.DB.eCommerce
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="202001180817437_Localization2.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.DB.eCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Class Localization2.
    /// Implements the <see cref="System.Data.Entity.Migrations.DbMigration" />
    /// Implements the <see cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    /// </summary>
    /// <seealso cref="System.Data.Entity.Migrations.DbMigration" />
    /// <seealso cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    public partial class Localization2 : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            AddColumn("dbo.BlogAuthor", "LocalizationId", c => c.Guid(nullable: false));
            AddColumn("dbo.Blog", "LocalizationId", c => c.Guid(nullable: false));
            AddColumn("dbo.BlogPost", "LocalizationId", c => c.Guid(nullable: false));
            AddColumn("dbo.ContentViewControl", "LocalizationId", c => c.Guid(nullable: false));
            AddColumn("dbo.ContentControl", "LocalizationId", c => c.Guid(nullable: false));
            AddColumn("dbo.ContentControlType", "LocalizationId", c => c.Guid(nullable: false));
            AddColumn("dbo.ContentNode", "LocalizationId", c => c.Guid(nullable: false));
            AddColumn("dbo.ContentView", "LocalizationId", c => c.Guid(nullable: false));
            AddColumn("dbo.ContentLocalization", "LocalizationId", c => c.Guid(nullable: false));
            AddColumn("dbo.PaymentOption", "LocalizationId", c => c.Guid(nullable: false));
            AddColumn("dbo.ShippingOption", "LocalizationId", c => c.Guid(nullable: false));
            AddColumn("dbo.ShippingCarrier", "LocalizationId", c => c.Guid(nullable: false));
            AddColumn("dbo.DiscountCoupon", "LocalizationId", c => c.Guid(nullable: false));
            AddColumn("dbo.Product", "LocalizationId", c => c.Guid(nullable: false));
            AddColumn("dbo.Manufacturer", "LocalizationId", c => c.Guid(nullable: false));
            AddColumn("dbo.ProductOption", "LocalizationId", c => c.Guid(nullable: false));
            AddColumn("dbo.ProductOptionItem", "LocalizationId", c => c.Guid(nullable: false));
            AddColumn("dbo.ProductCategory", "LocalizationId", c => c.Guid(nullable: false));
            AddColumn("dbo.Supplier", "LocalizationId", c => c.Guid(nullable: false));
            AddColumn("dbo.Lookup", "LocalizationId", c => c.Guid(nullable: false));
            AddColumn("dbo.LookupValue", "LocalizationId", c => c.Guid(nullable: false));
            AddColumn("dbo.NewsLetter", "LocalizationId", c => c.Guid(nullable: false));
            AddColumn("dbo.OrganizationService", "LocalizationId", c => c.Guid(nullable: false));
            CreateIndex("dbo.BlogAuthor", "LocalizationId");
            CreateIndex("dbo.Blog", "LocalizationId");
            CreateIndex("dbo.BlogPost", "LocalizationId");
            CreateIndex("dbo.ContentViewControl", "LocalizationId");
            CreateIndex("dbo.ContentControl", "LocalizationId");
            CreateIndex("dbo.ContentControlType", "LocalizationId");
            CreateIndex("dbo.ContentNode", "LocalizationId");
            CreateIndex("dbo.ContentView", "LocalizationId");
            CreateIndex("dbo.ContentLocalization", "LocalizationId");
            CreateIndex("dbo.PaymentOption", "LocalizationId");
            CreateIndex("dbo.ShippingOption", "LocalizationId");
            CreateIndex("dbo.ShippingCarrier", "LocalizationId");
            CreateIndex("dbo.DiscountCoupon", "LocalizationId");
            CreateIndex("dbo.Product", "LocalizationId");
            CreateIndex("dbo.Manufacturer", "LocalizationId");
            CreateIndex("dbo.ProductOption", "LocalizationId");
            CreateIndex("dbo.ProductOptionItem", "LocalizationId");
            CreateIndex("dbo.ProductCategory", "LocalizationId");
            CreateIndex("dbo.Supplier", "LocalizationId");
            CreateIndex("dbo.Lookup", "LocalizationId");
            CreateIndex("dbo.LookupValue", "LocalizationId");
            CreateIndex("dbo.NewsLetter", "LocalizationId");
            CreateIndex("dbo.OrganizationService", "LocalizationId");            
        }

        /// <summary>
        /// Downs this instance.
        /// </summary>
        public override void Down()
        {
            DropIndex("dbo.OrganizationService", new[] { "LocalizationId" });
            DropIndex("dbo.NewsLetter", new[] { "LocalizationId" });
            DropIndex("dbo.LookupValue", new[] { "LocalizationId" });
            DropIndex("dbo.Lookup", new[] { "LocalizationId" });
            DropIndex("dbo.Supplier", new[] { "LocalizationId" });
            DropIndex("dbo.ProductCategory", new[] { "LocalizationId" });
            DropIndex("dbo.ProductOptionItem", new[] { "LocalizationId" });
            DropIndex("dbo.ProductOption", new[] { "LocalizationId" });
            DropIndex("dbo.Manufacturer", new[] { "LocalizationId" });
            DropIndex("dbo.Product", new[] { "LocalizationId" });
            DropIndex("dbo.DiscountCoupon", new[] { "LocalizationId" });
            DropIndex("dbo.ShippingCarrier", new[] { "LocalizationId" });
            DropIndex("dbo.ShippingOption", new[] { "LocalizationId" });
            DropIndex("dbo.PaymentOption", new[] { "LocalizationId" });
            DropIndex("dbo.ContentLocalization", new[] { "LocalizationId" });
            DropIndex("dbo.ContentView", new[] { "LocalizationId" });
            DropIndex("dbo.ContentNode", new[] { "LocalizationId" });
            DropIndex("dbo.ContentControlType", new[] { "LocalizationId" });
            DropIndex("dbo.ContentControl", new[] { "LocalizationId" });
            DropIndex("dbo.ContentViewControl", new[] { "LocalizationId" });
            DropIndex("dbo.BlogPost", new[] { "LocalizationId" });
            DropIndex("dbo.Blog", new[] { "LocalizationId" });
            DropIndex("dbo.BlogAuthor", new[] { "LocalizationId" });
            DropColumn("dbo.OrganizationService", "LocalizationId");
            DropColumn("dbo.NewsLetter", "LocalizationId");
            DropColumn("dbo.LookupValue", "LocalizationId");
            DropColumn("dbo.Lookup", "LocalizationId");
            DropColumn("dbo.Supplier", "LocalizationId");
            DropColumn("dbo.ProductCategory", "LocalizationId");
            DropColumn("dbo.ProductOptionItem", "LocalizationId");
            DropColumn("dbo.ProductOption", "LocalizationId");
            DropColumn("dbo.Manufacturer", "LocalizationId");
            DropColumn("dbo.Product", "LocalizationId");
            DropColumn("dbo.DiscountCoupon", "LocalizationId");
            DropColumn("dbo.ShippingCarrier", "LocalizationId");
            DropColumn("dbo.ShippingOption", "LocalizationId");
            DropColumn("dbo.PaymentOption", "LocalizationId");
            DropColumn("dbo.ContentLocalization", "LocalizationId");
            DropColumn("dbo.ContentView", "LocalizationId");
            DropColumn("dbo.ContentNode", "LocalizationId");
            DropColumn("dbo.ContentControlType", "LocalizationId");
            DropColumn("dbo.ContentControl", "LocalizationId");
            DropColumn("dbo.ContentViewControl", "LocalizationId");
            DropColumn("dbo.BlogPost", "LocalizationId");
            DropColumn("dbo.Blog", "LocalizationId");
            DropColumn("dbo.BlogAuthor", "LocalizationId");
        }
    }
}
