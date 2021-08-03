// ***********************************************************************
// Assembly         : BAP.DB.eCommerce
// Author           : Victor Mamray
// Created          : 07-09-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 07-09-2020
// ***********************************************************************
// <copyright file="202007091709264_ShipmentExtension.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.DB.eCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Class ShipmentExtension.
    /// Implements the <see cref="System.Data.Entity.Migrations.DbMigration" />
    /// Implements the <see cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    /// </summary>
    /// <seealso cref="System.Data.Entity.Migrations.DbMigration" />
    /// <seealso cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    public partial class ShipmentExtension : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            AddColumn("dbo.CustomerOrder", "ShippingReferenceId", c => c.String());
            AddColumn("dbo.CustomerOrder", "ShipmentInitiatedAt", c => c.DateTime());
            AddColumn("dbo.CustomerOrder", "OrderDeliveredAt", c => c.DateTime());
            AddColumn("dbo.CustomerOrder", "ShipmentDeclined", c => c.Boolean());
            AddColumn("dbo.CustomerOrder", "ShipmentDeclinedAt", c => c.DateTime());
        }

        /// <summary>
        /// Downs this instance.
        /// </summary>
        public override void Down()
        {
            DropColumn("dbo.CustomerOrder", "ShipmentDeclinedAt");
            DropColumn("dbo.CustomerOrder", "ShipmentDeclined");
            DropColumn("dbo.CustomerOrder", "OrderDeliveredAt");
            DropColumn("dbo.CustomerOrder", "ShipmentInitiatedAt");
            DropColumn("dbo.CustomerOrder", "ShippingReferenceId");
        }
    }
}
