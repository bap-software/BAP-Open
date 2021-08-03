// ***********************************************************************
// Assembly         : BAP.DB.eCommerce
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="201912180821333_ReorderMenu.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.DB.eCommerce.Migrations
{
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Class ReorderMenu.
    /// Implements the <see cref="System.Data.Entity.Migrations.DbMigration" />
    /// Implements the <see cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    /// </summary>
    /// <seealso cref="System.Data.Entity.Migrations.DbMigration" />
    /// <seealso cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    public partial class ReorderMenu : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            Sql(@"
                UPDATE [dbo].[ContentNode]
                SET [MenuSortOrder] = 
                CASE [Name]
                WHEN 'Addresses' THEN 1
                WHEN 'Customers' THEN 2
                WHEN 'CustomerOrders' THEN 3
                WHEN 'DiscountCoupons' THEN 4
                WHEN 'Products' THEN 5
                WHEN 'ProductCategories' THEN 6
                WHEN 'ProductOptions' THEN 7
                WHEN 'PaymentOptions' THEN 8
                WHEN 'ShoppingCarts' THEN 9
                WHEN 'ShippingCarriers' THEN 10
                WHEN 'ShippingOptions' THEN 11
                WHEN 'Stores' THEN 12

                ELSE [MenuSortOrder]
                END;
            ");
        }

        /// <summary>
        /// Downs this instance.
        /// </summary>
        public override void Down()
        {
            Sql(@"
                UPDATE [dbo].[ContentNode]
                SET [MenuSortOrder] = 
                CASE [Name]
                WHEN 'Products' THEN 4
                WHEN 'ProductCategories' THEN 3
                WHEN 'ProductOptions' THEN 5
                WHEN 'DiscountCoupons' THEN 6
                WHEN 'ShoppingCarts' THEN 7
                WHEN 'ShippingCarriers' THEN 8
                WHEN 'ShippingOptions' THEN 9
                WHEN 'PaymentOptions' THEN 10
                WHEN 'CustomerOrders' THEN 11
                WHEN 'Stores' THEN 2
                WHEN 'Addresses' THEN 1
                WHEN 'Customers' THEN 11
                ELSE [MenuSortOrder]
                END;
            ");
        }
    }
}
