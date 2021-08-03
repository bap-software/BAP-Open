// ***********************************************************************
// Assembly         : BAP.DB.eCommerce
// Author           : Victor Mamray
// Created          : 07-22-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 07-22-2020
// ***********************************************************************
// <copyright file="202007221654281_ExtendSubscriptions.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.DB.eCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Class ExtendSubscriptions.
    /// Implements the <see cref="System.Data.Entity.Migrations.DbMigration" />
    /// Implements the <see cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    /// </summary>
    /// <seealso cref="System.Data.Entity.Migrations.DbMigration" />
    /// <seealso cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    public partial class ExtendSubscriptions : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            AddColumn("dbo.Subscription", "Object", c => c.String(maxLength: 255));
            AddColumn("dbo.Subscription", "ObjectId", c => c.Int(nullable: false));
            AddColumn("dbo.OrderItem", "SubscriptionId", c => c.Int());
            CreateIndex("dbo.OrderItem", "SubscriptionId");
            AddForeignKey("dbo.OrderItem", "SubscriptionId", "dbo.Subscription", "Id");
        }

        /// <summary>
        /// Downs this instance.
        /// </summary>
        public override void Down()
        {
            DropForeignKey("dbo.OrderItem", "SubscriptionId", "dbo.Subscription");
            DropIndex("dbo.OrderItem", new[] { "SubscriptionId" });
            DropColumn("dbo.OrderItem", "SubscriptionId");
            DropColumn("dbo.Subscription", "ObjectId");
            DropColumn("dbo.Subscription", "Object");
        }
    }
}
