// ***********************************************************************
// Assembly         : BAP.DB.eCommerce
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="201911251817444_StoreUpdate1.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.DB.eCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Class StoreUpdate1.
    /// Implements the <see cref="System.Data.Entity.Migrations.DbMigration" />
    /// Implements the <see cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    /// </summary>
    /// <seealso cref="System.Data.Entity.Migrations.DbMigration" />
    /// <seealso cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    public partial class StoreUpdate1 : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            RenameColumn(table: "dbo.StorePaymentOption", name: "PaymentOptionId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.StorePaymentOption", name: "StoreId", newName: "PaymentOptionId");
            RenameColumn(table: "dbo.StoreShippingOption", name: "ShippingOptionId", newName: "__mig_tmp__1");
            RenameColumn(table: "dbo.StoreShippingOption", name: "StoreId", newName: "ShippingOptionId");
            RenameColumn(table: "dbo.StoreDiscountCoupon", name: "DiscountCouponId", newName: "__mig_tmp__2");
            RenameColumn(table: "dbo.StoreDiscountCoupon", name: "StoreId", newName: "DiscountCouponId");
            RenameColumn(table: "dbo.StoreProductCategory", name: "ProductCategoryId", newName: "__mig_tmp__3");
            RenameColumn(table: "dbo.StoreProductCategory", name: "StoreId", newName: "ProductCategoryId");
            RenameColumn(table: "dbo.StorePaymentOption", name: "__mig_tmp__0", newName: "StoreId");
            RenameColumn(table: "dbo.StoreShippingOption", name: "__mig_tmp__1", newName: "StoreId");
            RenameColumn(table: "dbo.StoreDiscountCoupon", name: "__mig_tmp__2", newName: "StoreId");
            RenameColumn(table: "dbo.StoreProductCategory", name: "__mig_tmp__3", newName: "StoreId");
            RenameIndex(table: "dbo.StoreDiscountCoupon", name: "IX_DiscountCouponId", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.StoreDiscountCoupon", name: "IX_StoreId", newName: "IX_DiscountCouponId");
            RenameIndex(table: "dbo.StorePaymentOption", name: "IX_PaymentOptionId", newName: "__mig_tmp__1");
            RenameIndex(table: "dbo.StorePaymentOption", name: "IX_StoreId", newName: "IX_PaymentOptionId");
            RenameIndex(table: "dbo.StoreProductCategory", name: "IX_ProductCategoryId", newName: "__mig_tmp__2");
            RenameIndex(table: "dbo.StoreProductCategory", name: "IX_StoreId", newName: "IX_ProductCategoryId");
            RenameIndex(table: "dbo.StoreShippingOption", name: "IX_ShippingOptionId", newName: "__mig_tmp__3");
            RenameIndex(table: "dbo.StoreShippingOption", name: "IX_StoreId", newName: "IX_ShippingOptionId");
            RenameIndex(table: "dbo.StoreDiscountCoupon", name: "__mig_tmp__0", newName: "IX_StoreId");
            RenameIndex(table: "dbo.StorePaymentOption", name: "__mig_tmp__1", newName: "IX_StoreId");
            RenameIndex(table: "dbo.StoreProductCategory", name: "__mig_tmp__2", newName: "IX_StoreId");
            RenameIndex(table: "dbo.StoreShippingOption", name: "__mig_tmp__3", newName: "IX_StoreId");
        }

        /// <summary>
        /// Downs this instance.
        /// </summary>
        public override void Down()
        {
            RenameIndex(table: "dbo.StoreShippingOption", name: "IX_StoreId", newName: "__mig_tmp__3");
            RenameIndex(table: "dbo.StoreProductCategory", name: "IX_StoreId", newName: "__mig_tmp__2");
            RenameIndex(table: "dbo.StorePaymentOption", name: "IX_StoreId", newName: "__mig_tmp__1");
            RenameIndex(table: "dbo.StoreDiscountCoupon", name: "IX_StoreId", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.StoreShippingOption", name: "IX_ShippingOptionId", newName: "IX_StoreId");
            RenameIndex(table: "dbo.StoreShippingOption", name: "__mig_tmp__3", newName: "IX_ShippingOptionId");
            RenameIndex(table: "dbo.StoreProductCategory", name: "IX_ProductCategoryId", newName: "IX_StoreId");
            RenameIndex(table: "dbo.StoreProductCategory", name: "__mig_tmp__2", newName: "IX_ProductCategoryId");
            RenameIndex(table: "dbo.StorePaymentOption", name: "IX_PaymentOptionId", newName: "IX_StoreId");
            RenameIndex(table: "dbo.StorePaymentOption", name: "__mig_tmp__1", newName: "IX_PaymentOptionId");
            RenameIndex(table: "dbo.StoreDiscountCoupon", name: "IX_DiscountCouponId", newName: "IX_StoreId");
            RenameIndex(table: "dbo.StoreDiscountCoupon", name: "__mig_tmp__0", newName: "IX_DiscountCouponId");
            RenameColumn(table: "dbo.StoreProductCategory", name: "StoreId", newName: "__mig_tmp__3");
            RenameColumn(table: "dbo.StoreDiscountCoupon", name: "StoreId", newName: "__mig_tmp__2");
            RenameColumn(table: "dbo.StoreShippingOption", name: "StoreId", newName: "__mig_tmp__1");
            RenameColumn(table: "dbo.StorePaymentOption", name: "StoreId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.StoreProductCategory", name: "ProductCategoryId", newName: "StoreId");
            RenameColumn(table: "dbo.StoreProductCategory", name: "__mig_tmp__3", newName: "ProductCategoryId");
            RenameColumn(table: "dbo.StoreDiscountCoupon", name: "DiscountCouponId", newName: "StoreId");
            RenameColumn(table: "dbo.StoreDiscountCoupon", name: "__mig_tmp__2", newName: "DiscountCouponId");
            RenameColumn(table: "dbo.StoreShippingOption", name: "ShippingOptionId", newName: "StoreId");
            RenameColumn(table: "dbo.StoreShippingOption", name: "__mig_tmp__1", newName: "ShippingOptionId");
            RenameColumn(table: "dbo.StorePaymentOption", name: "PaymentOptionId", newName: "StoreId");
            RenameColumn(table: "dbo.StorePaymentOption", name: "__mig_tmp__0", newName: "PaymentOptionId");
        }
    }
}
