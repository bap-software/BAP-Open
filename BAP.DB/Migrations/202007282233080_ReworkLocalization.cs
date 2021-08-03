// ***********************************************************************
// Assembly         : BAP.DB.eCommerce
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="202007282233080_ReworkLocalization.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.DB.eCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Class ReworkLocalization.
    /// Implements the <see cref="System.Data.Entity.Migrations.DbMigration" />
    /// Implements the <see cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    /// </summary>
    /// <seealso cref="System.Data.Entity.Migrations.DbMigration" />
    /// <seealso cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    public partial class ReworkLocalization : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            DropIndex("dbo.BlogAuthor", new[] { "CultureCode" });
            DropIndex("dbo.BlogAuthor", new[] { "LocalizationId" });
            DropIndex("dbo.Blog", new[] { "CultureCode" });
            DropIndex("dbo.Blog", new[] { "LocalizationId" });
            DropIndex("dbo.BlogPost", new[] { "CultureCode" });
            DropIndex("dbo.BlogPost", new[] { "LocalizationId" });
            DropIndex("dbo.ContentViewControl", new[] { "CultureCode" });
            DropIndex("dbo.ContentViewControl", new[] { "LocalizationId" });
            DropIndex("dbo.ContentControl", new[] { "CultureCode" });
            DropIndex("dbo.ContentControl", new[] { "LocalizationId" });
            DropIndex("dbo.ContentControlType", new[] { "CultureCode" });
            DropIndex("dbo.ContentControlType", new[] { "LocalizationId" });
            DropIndex("dbo.ContentNode", new[] { "CultureCode" });
            DropIndex("dbo.ContentNode", new[] { "LocalizationId" });
            DropIndex("dbo.ContentView", new[] { "CultureCode" });
            DropIndex("dbo.ContentView", new[] { "LocalizationId" });
            DropIndex("dbo.ContentLocalization", new[] { "CultureCode" });
            DropIndex("dbo.ContentLocalization", new[] { "LocalizationId" });
            DropIndex("dbo.PaymentOption", new[] { "CultureCode" });
            DropIndex("dbo.PaymentOption", new[] { "LocalizationId" });
            DropIndex("dbo.ShippingOption", new[] { "CultureCode" });
            DropIndex("dbo.ShippingOption", new[] { "LocalizationId" });
            DropIndex("dbo.ShippingCarrier", new[] { "CultureCode" });
            DropIndex("dbo.ShippingCarrier", new[] { "LocalizationId" });
            DropIndex("dbo.DiscountCoupon", new[] { "CultureCode" });
            DropIndex("dbo.DiscountCoupon", new[] { "LocalizationId" });
            DropIndex("dbo.Manufacturer", new[] { "CultureCode" });
            DropIndex("dbo.Manufacturer", new[] { "LocalizationId" });
            DropIndex("dbo.ProductOption", new[] { "CultureCode" });
            DropIndex("dbo.ProductOption", new[] { "LocalizationId" });
            DropIndex("dbo.ProductOptionItem", new[] { "CultureCode" });
            DropIndex("dbo.ProductOptionItem", new[] { "LocalizationId" });
            DropIndex("dbo.ProductCategory", new[] { "CultureCode" });
            DropIndex("dbo.ProductCategory", new[] { "LocalizationId" });
            DropIndex("dbo.Supplier", new[] { "CultureCode" });
            DropIndex("dbo.Supplier", new[] { "LocalizationId" });
            DropIndex("dbo.DocumentTemplate", new[] { "CultureCode" });
            DropIndex("dbo.DocumentTemplate", new[] { "LocalizationId" });
            DropIndex("dbo.Lookup", new[] { "CultureCode" });
            DropIndex("dbo.Lookup", new[] { "LocalizationId" });
            DropIndex("dbo.LookupValue", new[] { "CultureCode" });
            DropIndex("dbo.LookupValue", new[] { "LocalizationId" });
            DropIndex("dbo.NewsLetter", new[] { "CultureCode" });
            DropIndex("dbo.NewsLetter", new[] { "LocalizationId" });
            DropIndex("dbo.OrganizationService", new[] { "CultureCode" });
            DropIndex("dbo.OrganizationService", new[] { "LocalizationId" });
            AddColumn("dbo.Localization", "Object", c => c.String(maxLength: 255));
            AddColumn("dbo.Localization", "ObjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.Localization", new[] { "Object", "ObjectId" }, name: "IX_LocalizationObject");
            DropColumn("dbo.BlogAuthor", "CultureCode");
            DropColumn("dbo.BlogAuthor", "LocalizationId");
            DropColumn("dbo.Blog", "CultureCode");
            DropColumn("dbo.Blog", "LocalizationId");
            DropColumn("dbo.BlogPost", "CultureCode");
            DropColumn("dbo.BlogPost", "LocalizationId");
            DropColumn("dbo.ContentViewControl", "CultureCode");
            DropColumn("dbo.ContentViewControl", "LocalizationId");
            DropColumn("dbo.ContentControl", "CultureCode");
            DropColumn("dbo.ContentControl", "LocalizationId");
            DropColumn("dbo.ContentControlType", "CultureCode");
            DropColumn("dbo.ContentControlType", "LocalizationId");
            DropColumn("dbo.ContentNode", "CultureCode");
            DropColumn("dbo.ContentNode", "LocalizationId");
            DropColumn("dbo.ContentView", "CultureCode");
            DropColumn("dbo.ContentView", "LocalizationId");
            DropColumn("dbo.ContentLocalization", "CultureCode");
            DropColumn("dbo.ContentLocalization", "LocalizationId");
            DropColumn("dbo.PaymentOption", "CultureCode");
            DropColumn("dbo.PaymentOption", "LocalizationId");
            DropColumn("dbo.ShippingOption", "CultureCode");
            DropColumn("dbo.ShippingOption", "LocalizationId");
            DropColumn("dbo.ShippingCarrier", "CultureCode");
            DropColumn("dbo.ShippingCarrier", "LocalizationId");
            DropColumn("dbo.DiscountCoupon", "CultureCode");
            DropColumn("dbo.DiscountCoupon", "LocalizationId");
            DropColumn("dbo.Manufacturer", "CultureCode");
            DropColumn("dbo.Manufacturer", "LocalizationId");
            DropColumn("dbo.ProductOption", "CultureCode");
            DropColumn("dbo.ProductOption", "LocalizationId");
            DropColumn("dbo.ProductOptionItem", "CultureCode");
            DropColumn("dbo.ProductOptionItem", "LocalizationId");
            DropColumn("dbo.ProductCategory", "CultureCode");
            DropColumn("dbo.ProductCategory", "LocalizationId");
            DropColumn("dbo.Supplier", "CultureCode");
            DropColumn("dbo.Supplier", "LocalizationId");
            DropColumn("dbo.DocumentTemplate", "CultureCode");
            DropColumn("dbo.DocumentTemplate", "LocalizationId");
            DropColumn("dbo.Lookup", "CultureCode");
            DropColumn("dbo.Lookup", "LocalizationId");
            DropColumn("dbo.LookupValue", "CultureCode");
            DropColumn("dbo.LookupValue", "LocalizationId");
            DropColumn("dbo.NewsLetter", "CultureCode");
            DropColumn("dbo.NewsLetter", "LocalizationId");
            DropColumn("dbo.OrganizationService", "CultureCode");
            DropColumn("dbo.OrganizationService", "LocalizationId");
        }

        /// <summary>
        /// Downs this instance.
        /// </summary>
        public override void Down()
        {
            AddColumn("dbo.OrganizationService", "LocalizationId", c => c.Guid(nullable: false));
            AddColumn("dbo.OrganizationService", "CultureCode", c => c.String(maxLength: 10));
            AddColumn("dbo.NewsLetter", "LocalizationId", c => c.Guid(nullable: false));
            AddColumn("dbo.NewsLetter", "CultureCode", c => c.String(maxLength: 10));
            AddColumn("dbo.LookupValue", "LocalizationId", c => c.Guid(nullable: false));
            AddColumn("dbo.LookupValue", "CultureCode", c => c.String(maxLength: 10));
            AddColumn("dbo.Lookup", "LocalizationId", c => c.Guid(nullable: false));
            AddColumn("dbo.Lookup", "CultureCode", c => c.String(maxLength: 10));
            AddColumn("dbo.DocumentTemplate", "LocalizationId", c => c.Guid(nullable: false));
            AddColumn("dbo.DocumentTemplate", "CultureCode", c => c.String(maxLength: 10));
            AddColumn("dbo.Supplier", "LocalizationId", c => c.Guid(nullable: false));
            AddColumn("dbo.Supplier", "CultureCode", c => c.String(maxLength: 10));
            AddColumn("dbo.ProductCategory", "LocalizationId", c => c.Guid(nullable: false));
            AddColumn("dbo.ProductCategory", "CultureCode", c => c.String(maxLength: 10));
            AddColumn("dbo.ProductOptionItem", "LocalizationId", c => c.Guid(nullable: false));
            AddColumn("dbo.ProductOptionItem", "CultureCode", c => c.String(maxLength: 10));
            AddColumn("dbo.ProductOption", "LocalizationId", c => c.Guid(nullable: false));
            AddColumn("dbo.ProductOption", "CultureCode", c => c.String(maxLength: 10));
            AddColumn("dbo.Manufacturer", "LocalizationId", c => c.Guid(nullable: false));
            AddColumn("dbo.Manufacturer", "CultureCode", c => c.String(maxLength: 10));
            AddColumn("dbo.DiscountCoupon", "LocalizationId", c => c.Guid(nullable: false));
            AddColumn("dbo.DiscountCoupon", "CultureCode", c => c.String(maxLength: 10));
            AddColumn("dbo.ShippingCarrier", "LocalizationId", c => c.Guid(nullable: false));
            AddColumn("dbo.ShippingCarrier", "CultureCode", c => c.String(maxLength: 10));
            AddColumn("dbo.ShippingOption", "LocalizationId", c => c.Guid(nullable: false));
            AddColumn("dbo.ShippingOption", "CultureCode", c => c.String(maxLength: 10));
            AddColumn("dbo.PaymentOption", "LocalizationId", c => c.Guid(nullable: false));
            AddColumn("dbo.PaymentOption", "CultureCode", c => c.String(maxLength: 10));
            AddColumn("dbo.ContentLocalization", "LocalizationId", c => c.Guid(nullable: false));
            AddColumn("dbo.ContentLocalization", "CultureCode", c => c.String(maxLength: 20));
            AddColumn("dbo.ContentView", "LocalizationId", c => c.Guid(nullable: false));
            AddColumn("dbo.ContentView", "CultureCode", c => c.String(maxLength: 10));
            AddColumn("dbo.ContentNode", "LocalizationId", c => c.Guid(nullable: false));
            AddColumn("dbo.ContentNode", "CultureCode", c => c.String(maxLength: 10));
            AddColumn("dbo.ContentControlType", "LocalizationId", c => c.Guid(nullable: false));
            AddColumn("dbo.ContentControlType", "CultureCode", c => c.String(maxLength: 10));
            AddColumn("dbo.ContentControl", "LocalizationId", c => c.Guid(nullable: false));
            AddColumn("dbo.ContentControl", "CultureCode", c => c.String(maxLength: 10));
            AddColumn("dbo.ContentViewControl", "LocalizationId", c => c.Guid(nullable: false));
            AddColumn("dbo.ContentViewControl", "CultureCode", c => c.String(maxLength: 10));
            AddColumn("dbo.BlogPost", "LocalizationId", c => c.Guid(nullable: false));
            AddColumn("dbo.BlogPost", "CultureCode", c => c.String(maxLength: 10));
            AddColumn("dbo.Blog", "LocalizationId", c => c.Guid(nullable: false));
            AddColumn("dbo.Blog", "CultureCode", c => c.String(maxLength: 10));
            AddColumn("dbo.BlogAuthor", "LocalizationId", c => c.Guid(nullable: false));
            AddColumn("dbo.BlogAuthor", "CultureCode", c => c.String(maxLength: 10));
            DropIndex("dbo.Localization", "IX_LocalizationObject");
            DropColumn("dbo.Localization", "ObjectId");
            DropColumn("dbo.Localization", "Object");
            CreateIndex("dbo.OrganizationService", "LocalizationId");
            CreateIndex("dbo.OrganizationService", "CultureCode");
            CreateIndex("dbo.NewsLetter", "LocalizationId");
            CreateIndex("dbo.NewsLetter", "CultureCode");
            CreateIndex("dbo.LookupValue", "LocalizationId");
            CreateIndex("dbo.LookupValue", "CultureCode");
            CreateIndex("dbo.Lookup", "LocalizationId");
            CreateIndex("dbo.Lookup", "CultureCode");
            CreateIndex("dbo.DocumentTemplate", "LocalizationId");
            CreateIndex("dbo.DocumentTemplate", "CultureCode");
            CreateIndex("dbo.Supplier", "LocalizationId");
            CreateIndex("dbo.Supplier", "CultureCode");
            CreateIndex("dbo.ProductCategory", "LocalizationId");
            CreateIndex("dbo.ProductCategory", "CultureCode");
            CreateIndex("dbo.ProductOptionItem", "LocalizationId");
            CreateIndex("dbo.ProductOptionItem", "CultureCode");
            CreateIndex("dbo.ProductOption", "LocalizationId");
            CreateIndex("dbo.ProductOption", "CultureCode");
            CreateIndex("dbo.Manufacturer", "LocalizationId");
            CreateIndex("dbo.Manufacturer", "CultureCode");
            CreateIndex("dbo.DiscountCoupon", "LocalizationId");
            CreateIndex("dbo.DiscountCoupon", "CultureCode");
            CreateIndex("dbo.ShippingCarrier", "LocalizationId");
            CreateIndex("dbo.ShippingCarrier", "CultureCode");
            CreateIndex("dbo.ShippingOption", "LocalizationId");
            CreateIndex("dbo.ShippingOption", "CultureCode");
            CreateIndex("dbo.PaymentOption", "LocalizationId");
            CreateIndex("dbo.PaymentOption", "CultureCode");
            CreateIndex("dbo.ContentLocalization", "LocalizationId");
            CreateIndex("dbo.ContentLocalization", "CultureCode");
            CreateIndex("dbo.ContentView", "LocalizationId");
            CreateIndex("dbo.ContentView", "CultureCode");
            CreateIndex("dbo.ContentNode", "LocalizationId");
            CreateIndex("dbo.ContentNode", "CultureCode");
            CreateIndex("dbo.ContentControlType", "LocalizationId");
            CreateIndex("dbo.ContentControlType", "CultureCode");
            CreateIndex("dbo.ContentControl", "LocalizationId");
            CreateIndex("dbo.ContentControl", "CultureCode");
            CreateIndex("dbo.ContentViewControl", "LocalizationId");
            CreateIndex("dbo.ContentViewControl", "CultureCode");
            CreateIndex("dbo.BlogPost", "LocalizationId");
            CreateIndex("dbo.BlogPost", "CultureCode");
            CreateIndex("dbo.Blog", "LocalizationId");
            CreateIndex("dbo.Blog", "CultureCode");
            CreateIndex("dbo.BlogAuthor", "LocalizationId");
            CreateIndex("dbo.BlogAuthor", "CultureCode");
        }
    }
}
