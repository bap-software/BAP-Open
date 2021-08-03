// ***********************************************************************
// Assembly         : BAP.DB.eCommerce
// Author           : Victor Mamray
// Created          : 07-22-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 07-22-2020
// ***********************************************************************
// <copyright file="202007212233514_ProductExtend2.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.DB.eCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Class ProductExtend2.
    /// Implements the <see cref="System.Data.Entity.Migrations.DbMigration" />
    /// Implements the <see cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    /// </summary>
    /// <seealso cref="System.Data.Entity.Migrations.DbMigration" />
    /// <seealso cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    public partial class ProductExtend2 : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            AddColumn("dbo.Product", "InitialTermTicks", c => c.Long(nullable: false));
            AddColumn("dbo.Product", "FreeTrialTermTicks", c => c.Long(nullable: false));
            AddColumn("dbo.Product", "RenewalTermTicks", c => c.Long(nullable: false));
            DropColumn("dbo.Product", "InitialTerm");
            DropColumn("dbo.Product", "FreeTrialTerm");
            DropColumn("dbo.Product", "RenewalTerm");
        }

        /// <summary>
        /// Downs this instance.
        /// </summary>
        public override void Down()
        {
            AddColumn("dbo.Product", "RenewalTerm", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.Product", "FreeTrialTerm", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.Product", "InitialTerm", c => c.Time(nullable: false, precision: 7));
            DropColumn("dbo.Product", "RenewalTermTicks");
            DropColumn("dbo.Product", "FreeTrialTermTicks");
            DropColumn("dbo.Product", "InitialTermTicks");
        }
    }
}
