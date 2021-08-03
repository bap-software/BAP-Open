// ***********************************************************************
// Assembly         : BAP.DB.eCommerce
// Author           : Victor Mamray
// Created          : 07-24-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 07-24-2020
// ***********************************************************************
// <copyright file="202007241347401_Contentindexes.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.DB.eCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Class Contentindexes.
    /// Implements the <see cref="System.Data.Entity.Migrations.DbMigration" />
    /// Implements the <see cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    /// </summary>
    /// <seealso cref="System.Data.Entity.Migrations.DbMigration" />
    /// <seealso cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    public partial class Contentindexes : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            DropIndex("dbo.ContentNode", "IX_ContentNodeName");
            DropIndex("dbo.ContentNode", "IX_ContentNodeRoute");
            DropIndex("dbo.ContentView", "IX_ContentViewName");
            CreateIndex("dbo.ContentNode", new[] { "Name", "TenantUnit", "TenantUnitId" }, unique: true, name: "IX_ContentNodeName");
            CreateIndex("dbo.ContentNode", new[] { "Area", "Controller", "Action", "View", "TenantUnit", "TenantUnitId" }, unique: true, name: "IX_ContentNodeRoute");
            CreateIndex("dbo.ContentView", new[] { "Name", "TenantUnit", "TenantUnitId" }, unique: true, name: "IX_ContentViewName");
        }

        /// <summary>
        /// Downs this instance.
        /// </summary>
        public override void Down()
        {
            DropIndex("dbo.ContentView", "IX_ContentViewName");
            DropIndex("dbo.ContentNode", "IX_ContentNodeRoute");
            DropIndex("dbo.ContentNode", "IX_ContentNodeName");
            CreateIndex("dbo.ContentView", "Name", unique: true, name: "IX_ContentViewName");
            CreateIndex("dbo.ContentNode", new[] { "Area", "Controller", "Action", "View" }, unique: true, name: "IX_ContentNodeRoute");
            CreateIndex("dbo.ContentNode", "Name", unique: true, name: "IX_ContentNodeName");
        }
    }
}
