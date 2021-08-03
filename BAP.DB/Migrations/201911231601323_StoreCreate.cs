// ***********************************************************************
// Assembly         : BAP.DB.eCommerce
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="201911231601323_StoreCreate.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.DB.eCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Class StoreCreate.
    /// Implements the <see cref="System.Data.Entity.Migrations.DbMigration" />
    /// Implements the <see cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    /// </summary>
    /// <seealso cref="System.Data.Entity.Migrations.DbMigration" />
    /// <seealso cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    public partial class StoreCreate : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            CreateTable(
                "dbo.Store",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 80),
                        ShortDescription = c.String(maxLength: 256),
                        Description = c.String(maxLength: 1024),
                        OrganizationId = c.Int(),
                        AdminUserId = c.Int(),
                        BillingAddressId = c.Int(),
                        ShippingAddressId = c.Int(),
                        IsDefault = c.Boolean(nullable: false),
                        TenantUnit = c.String(maxLength: 50),
                        TenantUnitId = c.Int(),
                        CreateDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 128),
                        TimeStamp = c.Binary(fixedLength: true, timestamp: true, storeType: "timestamp"),
                        CreatedByUserName = c.String(),
                        LastModifiedByUserName = c.String(),
                        OwnerGroup = c.Int(nullable: false),
                        OwnerPermissions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrganizationUser", t => t.AdminUserId)
                .ForeignKey("dbo.Address", t => t.BillingAddressId)
                .ForeignKey("dbo.Organization", t => t.OrganizationId)
                .ForeignKey("dbo.Address", t => t.ShippingAddressId)
                .Index(t => t.Name, unique: true, name: "IX_DiscountCouponName")
                .Index(t => t.OrganizationId)
                .Index(t => t.AdminUserId)
                .Index(t => t.BillingAddressId)
                .Index(t => t.ShippingAddressId)
                .Index(t => new { t.TenantUnit, t.TenantUnitId }, name: "IX_Tenant")
                .Index(t => t.OwnerGroup)
                .Index(t => t.OwnerPermissions);
            
            CreateTable(
                "dbo.StoreDiscountCoupon",
                c => new
                    {
                        DiscountCouponId = c.Int(nullable: false),
                        StoreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DiscountCouponId, t.StoreId })
                .ForeignKey("dbo.Store", t => t.DiscountCouponId, cascadeDelete: true)
                .ForeignKey("dbo.DiscountCoupon", t => t.StoreId, cascadeDelete: true)
                .Index(t => t.DiscountCouponId)
                .Index(t => t.StoreId);
            
            CreateTable(
                "dbo.StorePaymentOption",
                c => new
                    {
                        PaymentOptionId = c.Int(nullable: false),
                        StoreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PaymentOptionId, t.StoreId })
                .ForeignKey("dbo.Store", t => t.PaymentOptionId, cascadeDelete: true)
                .ForeignKey("dbo.PaymentOption", t => t.StoreId, cascadeDelete: true)
                .Index(t => t.PaymentOptionId)
                .Index(t => t.StoreId);
            
            CreateTable(
                "dbo.StoreProductCategory",
                c => new
                    {
                        ProductCategoryId = c.Int(nullable: false),
                        StoreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductCategoryId, t.StoreId })
                .ForeignKey("dbo.Store", t => t.ProductCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.ProductCategory", t => t.StoreId, cascadeDelete: true)
                .Index(t => t.ProductCategoryId)
                .Index(t => t.StoreId);
            
            CreateTable(
                "dbo.StoreShippingOption",
                c => new
                    {
                        ShippingOptionId = c.Int(nullable: false),
                        StoreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ShippingOptionId, t.StoreId })
                .ForeignKey("dbo.Store", t => t.ShippingOptionId, cascadeDelete: true)
                .ForeignKey("dbo.ShippingOption", t => t.StoreId, cascadeDelete: true)
                .Index(t => t.ShippingOptionId)
                .Index(t => t.StoreId);
            
            AddColumn("dbo.ContentViewControl", "ContentControlId", c => c.Int());
            CreateIndex("dbo.ContentViewControl", "ContentControlId");
            AddForeignKey("dbo.ContentViewControl", "ContentControlId", "dbo.ContentControl", "Id");
        }

        /// <summary>
        /// Downs this instance.
        /// </summary>
        public override void Down()
        {
            DropForeignKey("dbo.StoreShippingOption", "StoreId", "dbo.ShippingOption");
            DropForeignKey("dbo.StoreShippingOption", "ShippingOptionId", "dbo.Store");
            DropForeignKey("dbo.StoreProductCategory", "StoreId", "dbo.ProductCategory");
            DropForeignKey("dbo.StoreProductCategory", "ProductCategoryId", "dbo.Store");
            DropForeignKey("dbo.StorePaymentOption", "StoreId", "dbo.PaymentOption");
            DropForeignKey("dbo.StorePaymentOption", "PaymentOptionId", "dbo.Store");
            DropForeignKey("dbo.StoreDiscountCoupon", "StoreId", "dbo.DiscountCoupon");
            DropForeignKey("dbo.StoreDiscountCoupon", "DiscountCouponId", "dbo.Store");
            DropForeignKey("dbo.Store", "ShippingAddressId", "dbo.Address");
            DropForeignKey("dbo.Store", "OrganizationId", "dbo.Organization");
            DropForeignKey("dbo.Store", "BillingAddressId", "dbo.Address");
            DropForeignKey("dbo.Store", "AdminUserId", "dbo.OrganizationUser");
            DropForeignKey("dbo.ContentViewControl", "ContentControlId", "dbo.ContentControl");
            DropIndex("dbo.StoreShippingOption", new[] { "StoreId" });
            DropIndex("dbo.StoreShippingOption", new[] { "ShippingOptionId" });
            DropIndex("dbo.StoreProductCategory", new[] { "StoreId" });
            DropIndex("dbo.StoreProductCategory", new[] { "ProductCategoryId" });
            DropIndex("dbo.StorePaymentOption", new[] { "StoreId" });
            DropIndex("dbo.StorePaymentOption", new[] { "PaymentOptionId" });
            DropIndex("dbo.StoreDiscountCoupon", new[] { "StoreId" });
            DropIndex("dbo.StoreDiscountCoupon", new[] { "DiscountCouponId" });
            DropIndex("dbo.Store", new[] { "OwnerPermissions" });
            DropIndex("dbo.Store", new[] { "OwnerGroup" });
            DropIndex("dbo.Store", "IX_Tenant");
            DropIndex("dbo.Store", new[] { "ShippingAddressId" });
            DropIndex("dbo.Store", new[] { "BillingAddressId" });
            DropIndex("dbo.Store", new[] { "AdminUserId" });
            DropIndex("dbo.Store", new[] { "OrganizationId" });
            DropIndex("dbo.Store", "IX_DiscountCouponName");
            DropIndex("dbo.ContentViewControl", new[] { "ContentControlId" });
            DropColumn("dbo.ContentViewControl", "ContentControlId");
            DropTable("dbo.StoreShippingOption");
            DropTable("dbo.StoreProductCategory");
            DropTable("dbo.StorePaymentOption");
            DropTable("dbo.StoreDiscountCoupon");
            DropTable("dbo.Store");
        }
    }
}
