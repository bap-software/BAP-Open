// ***********************************************************************
// Assembly         : BAP.DB.eCommerce
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="201911281922572_SubscriptionUpdate.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.DB.eCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Class SubscriptionUpdate.
    /// Implements the <see cref="System.Data.Entity.Migrations.DbMigration" />
    /// Implements the <see cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    /// </summary>
    /// <seealso cref="System.Data.Entity.Migrations.DbMigration" />
    /// <seealso cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    public partial class SubscriptionUpdate : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            RenameColumn(table: "dbo.Subscription", name: "Organization_Id", newName: "OrganizationId");
            RenameColumn(table: "dbo.Subscription", name: "User_Id", newName: "UserId");
            RenameIndex(table: "dbo.Subscription", name: "IX_Organization_Id", newName: "IX_OrganizationId");
            RenameIndex(table: "dbo.Subscription", name: "IX_User_Id", newName: "IX_UserId");
        }

        /// <summary>
        /// Downs this instance.
        /// </summary>
        public override void Down()
        {
            RenameIndex(table: "dbo.Subscription", name: "IX_UserId", newName: "IX_User_Id");
            RenameIndex(table: "dbo.Subscription", name: "IX_OrganizationId", newName: "IX_Organization_Id");
            RenameColumn(table: "dbo.Subscription", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.Subscription", name: "OrganizationId", newName: "Organization_Id");
        }
    }
}
