// ***********************************************************************
// Assembly         : BAP.DB.eCommerce
// Author           : Victor Mamray
// Created          : 07-21-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 07-21-2020
// ***********************************************************************
// <copyright file="202007211521471_ExtendProduct.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.DB.eCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Class ExtendProduct.
    /// Implements the <see cref="System.Data.Entity.Migrations.DbMigration" />
    /// Implements the <see cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    /// </summary>
    /// <seealso cref="System.Data.Entity.Migrations.DbMigration" />
    /// <seealso cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    public partial class ExtendProduct : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            AddColumn("dbo.Product", "InitialTerm", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.Product", "FreeTrialTerm", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.Product", "RenewalTerm", c => c.Time(nullable: false, precision: 7));
        }

        /// <summary>
        /// Downs this instance.
        /// </summary>
        public override void Down()
        {
            DropColumn("dbo.Product", "RenewalTerm");
            DropColumn("dbo.Product", "FreeTrialTerm");
            DropColumn("dbo.Product", "InitialTerm");
        }
    }
}
