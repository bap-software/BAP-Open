// ***********************************************************************
// Assembly         : BAP.DB.eCommerce
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="202001180824498_SetLocalizationData.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.DB.eCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Class SetLocalizationData.
    /// Implements the <see cref="System.Data.Entity.Migrations.DbMigration" />
    /// Implements the <see cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    /// </summary>
    /// <seealso cref="System.Data.Entity.Migrations.DbMigration" />
    /// <seealso cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    public partial class SetLocalizationData : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            Sql(@"
update dbo.BlogAuthor SET CultureCode = 'en-US', LocalizationId = newid() where CultureCode is null;
update dbo.BlogPost SET CultureCode = 'en-US', LocalizationId = newid() where CultureCode is null;
update dbo.ContentControl SET CultureCode = 'en-US', LocalizationId = newid() where CultureCode is null;
update dbo.ContentControlType SET CultureCode = 'en-US', LocalizationId = newid() where CultureCode is null;
update dbo.ContentLocalization SET CultureCode = 'en-US', LocalizationId = newid() where CultureCode is null;
update dbo.ContentNode SET CultureCode = 'en-US', LocalizationId = newid() where CultureCode is null;
update dbo.ContentView SET CultureCode = 'en-US', LocalizationId = newid() where CultureCode is null;
update dbo.ContentViewControl SET CultureCode = 'en-US', LocalizationId = newid() where CultureCode is null;
update dbo.Lookup SET CultureCode = 'en-US', LocalizationId = newid() where CultureCode is null;
update dbo.LookupValue SET CultureCode = 'en-US', LocalizationId = newid() where CultureCode is null;
update dbo.NewsLetter SET CultureCode = 'en-US', LocalizationId = newid() where CultureCode is null;
update dbo.OrganizationService SET CultureCode = 'en-US', LocalizationId = newid() where CultureCode is null;
update dbo.DiscountCoupon SET CultureCode = 'en-US', LocalizationId = newid() where CultureCode is null;
update dbo.Manufacturer SET CultureCode = 'en-US', LocalizationId = newid() where CultureCode is null;
update dbo.PaymentOption SET CultureCode = 'en-US', LocalizationId = newid() where CultureCode is null;
update dbo.Product SET CultureCode = 'en-US', LocalizationId = newid() where CultureCode is null;
update dbo.ProductCategory SET CultureCode = 'en-US', LocalizationId = newid() where CultureCode is null;
update dbo.ProductOption SET CultureCode = 'en-US', LocalizationId = newid() where CultureCode is null;
update dbo.ProductOptionItem SET CultureCode = 'en-US', LocalizationId = newid() where CultureCode is null;
update dbo.ShippingCarrier SET CultureCode = 'en-US', LocalizationId = newid() where CultureCode is null;
update dbo.ShippingOption SET CultureCode = 'en-US', LocalizationId = newid() where CultureCode is null;
update dbo.Supplier SET CultureCode = 'en-US', LocalizationId = newid() where CultureCode is null;
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
