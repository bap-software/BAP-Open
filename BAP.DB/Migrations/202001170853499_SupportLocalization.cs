// ***********************************************************************
// Assembly         : BAP.DB.eCommerce
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="202001170853499_SupportLocalization.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.DB.eCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Class SupportLocalization.
    /// Implements the <see cref="System.Data.Entity.Migrations.DbMigration" />
    /// Implements the <see cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    /// </summary>
    /// <seealso cref="System.Data.Entity.Migrations.DbMigration" />
    /// <seealso cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    public partial class SupportLocalization : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            AddColumn("dbo.BlogAuthor", "CultureCode", c => c.String(maxLength: 10));
            AddColumn("dbo.Blog", "CultureCode", c => c.String(maxLength: 10));
            AddColumn("dbo.BlogPost", "CultureCode", c => c.String(maxLength: 10));
            AddColumn("dbo.ContentViewControl", "CultureCode", c => c.String(maxLength: 10));
            AddColumn("dbo.ContentControl", "CultureCode", c => c.String(maxLength: 10));
            AddColumn("dbo.ContentControlType", "CultureCode", c => c.String(maxLength: 10));
            AddColumn("dbo.ContentNode", "CultureCode", c => c.String(maxLength: 10));
            AddColumn("dbo.ContentView", "CultureCode", c => c.String(maxLength: 10));
            AddColumn("dbo.PaymentOption", "CultureCode", c => c.String(maxLength: 10));
            AddColumn("dbo.ShippingOption", "CultureCode", c => c.String(maxLength: 10));
            AddColumn("dbo.ShippingCarrier", "CultureCode", c => c.String(maxLength: 10));
            AddColumn("dbo.DiscountCoupon", "CultureCode", c => c.String(maxLength: 10));
            AddColumn("dbo.Product", "CultureCode", c => c.String(maxLength: 10));
            AddColumn("dbo.Manufacturer", "CultureCode", c => c.String(maxLength: 10));
            AddColumn("dbo.ProductOption", "CultureCode", c => c.String(maxLength: 10));
            AddColumn("dbo.ProductOptionItem", "CultureCode", c => c.String(maxLength: 10));
            AddColumn("dbo.ProductCategory", "CultureCode", c => c.String(maxLength: 10));
            AddColumn("dbo.Supplier", "CultureCode", c => c.String(maxLength: 10));
            AddColumn("dbo.Lookup", "CultureCode", c => c.String(maxLength: 10));
            AddColumn("dbo.NewsLetter", "CultureCode", c => c.String(maxLength: 10));
            AddColumn("dbo.OrganizationService", "CultureCode", c => c.String(maxLength: 10));
            CreateIndex("dbo.BlogAuthor", "CultureCode");
            CreateIndex("dbo.Blog", "CultureCode");
            CreateIndex("dbo.BlogPost", "CultureCode");
            CreateIndex("dbo.ContentViewControl", "CultureCode");
            CreateIndex("dbo.ContentControl", "CultureCode");
            CreateIndex("dbo.ContentControlType", "CultureCode");
            CreateIndex("dbo.ContentNode", "CultureCode");
            CreateIndex("dbo.ContentView", "CultureCode");
            CreateIndex("dbo.ContentLocalization", "CultureCode");
            CreateIndex("dbo.PaymentOption", "CultureCode");
            CreateIndex("dbo.ShippingOption", "CultureCode");
            CreateIndex("dbo.ShippingCarrier", "CultureCode");
            CreateIndex("dbo.DiscountCoupon", "CultureCode");
            CreateIndex("dbo.Product", "CultureCode");
            CreateIndex("dbo.Manufacturer", "CultureCode");
            CreateIndex("dbo.ProductOption", "CultureCode");
            CreateIndex("dbo.ProductOptionItem", "CultureCode");
            CreateIndex("dbo.ProductCategory", "CultureCode");
            CreateIndex("dbo.Supplier", "CultureCode");
            CreateIndex("dbo.Lookup", "CultureCode");
            CreateIndex("dbo.LookupValue", "CultureCode");
            CreateIndex("dbo.NewsLetter", "CultureCode");
            CreateIndex("dbo.OrganizationService", "CultureCode");
        }

        /// <summary>
        /// Downs this instance.
        /// </summary>
        public override void Down()
        {
            DropIndex("dbo.OrganizationService", new[] { "CultureCode" });
            DropIndex("dbo.NewsLetter", new[] { "CultureCode" });
            DropIndex("dbo.LookupValue", new[] { "CultureCode" });
            DropIndex("dbo.Lookup", new[] { "CultureCode" });
            DropIndex("dbo.Supplier", new[] { "CultureCode" });
            DropIndex("dbo.ProductCategory", new[] { "CultureCode" });
            DropIndex("dbo.ProductOptionItem", new[] { "CultureCode" });
            DropIndex("dbo.ProductOption", new[] { "CultureCode" });
            DropIndex("dbo.Manufacturer", new[] { "CultureCode" });
            DropIndex("dbo.Product", new[] { "CultureCode" });
            DropIndex("dbo.DiscountCoupon", new[] { "CultureCode" });
            DropIndex("dbo.ShippingCarrier", new[] { "CultureCode" });
            DropIndex("dbo.ShippingOption", new[] { "CultureCode" });
            DropIndex("dbo.PaymentOption", new[] { "CultureCode" });
            DropIndex("dbo.ContentLocalization", new[] { "CultureCode" });
            DropIndex("dbo.ContentView", new[] { "CultureCode" });
            DropIndex("dbo.ContentNode", new[] { "CultureCode" });
            DropIndex("dbo.ContentControlType", new[] { "CultureCode" });
            DropIndex("dbo.ContentControl", new[] { "CultureCode" });
            DropIndex("dbo.ContentViewControl", new[] { "CultureCode" });
            DropIndex("dbo.BlogPost", new[] { "CultureCode" });
            DropIndex("dbo.Blog", new[] { "CultureCode" });
            DropIndex("dbo.BlogAuthor", new[] { "CultureCode" });
            DropColumn("dbo.OrganizationService", "CultureCode");
            DropColumn("dbo.NewsLetter", "CultureCode");
            DropColumn("dbo.Lookup", "CultureCode");
            DropColumn("dbo.Supplier", "CultureCode");
            DropColumn("dbo.ProductCategory", "CultureCode");
            DropColumn("dbo.ProductOptionItem", "CultureCode");
            DropColumn("dbo.ProductOption", "CultureCode");
            DropColumn("dbo.Manufacturer", "CultureCode");
            DropColumn("dbo.Product", "CultureCode");
            DropColumn("dbo.DiscountCoupon", "CultureCode");
            DropColumn("dbo.ShippingCarrier", "CultureCode");
            DropColumn("dbo.ShippingOption", "CultureCode");
            DropColumn("dbo.PaymentOption", "CultureCode");
            DropColumn("dbo.ContentView", "CultureCode");
            DropColumn("dbo.ContentNode", "CultureCode");
            DropColumn("dbo.ContentControlType", "CultureCode");
            DropColumn("dbo.ContentControl", "CultureCode");
            DropColumn("dbo.ContentViewControl", "CultureCode");
            DropColumn("dbo.BlogPost", "CultureCode");
            DropColumn("dbo.Blog", "CultureCode");
            DropColumn("dbo.BlogAuthor", "CultureCode");
        }
    }
}
