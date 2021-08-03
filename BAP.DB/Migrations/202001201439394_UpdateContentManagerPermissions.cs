// ***********************************************************************
// Assembly         : BAP.DB.eCommerce
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="202001201439394_UpdateContentManagerPermissions.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.DB.eCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Class UpdateContentManagerPermissions.
    /// Implements the <see cref="System.Data.Entity.Migrations.DbMigration" />
    /// Implements the <see cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    /// </summary>
    /// <seealso cref="System.Data.Entity.Migrations.DbMigration" />
    /// <seealso cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    public partial class UpdateContentManagerPermissions : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            Sql(@"
update [dbo].[ContentControlType] set [OwnerGroup]=31,[OwnerPermissions]=8143
update [dbo].[ContentControl] set [OwnerGroup]=31,[OwnerPermissions]=8143
update [dbo].[Lookup] set [OwnerGroup]=127,[OwnerPermissions]=302799
update [dbo].[LookupValue] set [OwnerGroup]=127,[OwnerPermissions]=302799
update [dbo].[NewsLetter] set [OwnerGroup]=29,[OwnerPermissions]=11975
update [dbo].[Currency] set [OwnerGroup]=127,[OwnerPermissions]=1875535
update [dbo].[Product] set [OwnerGroup]=31,[OwnerPermissions]=7759
update [dbo].[Manufacturer] set [OwnerGroup]=31,[OwnerPermissions]=7695
update [dbo].[Supplier] set [OwnerGroup]=31,[OwnerPermissions]=7695
update [dbo].[ProductCategory] set [OwnerGroup]=31,[OwnerPermissions]=7759
update [dbo].[ProductOption] set [OwnerGroup]=31,[OwnerPermissions]=7759
update [dbo].[ProductOptionItem] set [OwnerGroup]=31,[OwnerPermissions]=7759
update [dbo].[ShoppingCart] set [OwnerGroup]=31,[OwnerPermissions]=32767
update [dbo].[ShoppingCartProduct] set [OwnerGroup]=31,[OwnerPermissions]=32767
update [dbo].[Address] set [OwnerGroup]=31,[OwnerPermissions]=15967
update [dbo].[DiscountCoupon] set [OwnerGroup]=31,[OwnerPermissions]=7759
update [dbo].[PaymentOption] set [OwnerGroup]=31,[OwnerPermissions]=7759
update [dbo].[ShippingCarrier] set [OwnerGroup]=31,[OwnerPermissions]=7759
update [dbo].[ShippingOption] set [OwnerGroup]=31,[OwnerPermissions]=7759
update [dbo].[Customer] set [OwnerGroup]=31,[OwnerPermissions]=15999
update [dbo].[CustomerPayment] set [OwnerGroup]=31,[OwnerPermissions]=15999
update [dbo].[CustomerOrder] set [OwnerGroup]=31,[OwnerPermissions]=15999
update [dbo].[CustomerOrderPayment] set [OwnerGroup]=31,[OwnerPermissions]=15999
update [dbo].[OrderItem] set [OwnerGroup]=31,[OwnerPermissions]=15999
");
        }

        /// <summary>
        /// Downs this instance.
        /// </summary>
        public override void Down()
        {
        }
    }
}
