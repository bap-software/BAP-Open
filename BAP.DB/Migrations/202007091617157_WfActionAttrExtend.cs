// ***********************************************************************
// Assembly         : BAP.DB.eCommerce
// Author           : Victor Mamray
// Created          : 07-09-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 07-09-2020
// ***********************************************************************
// <copyright file="202007091617157_WfActionAttrExtend.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.DB.eCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Class WfActionAttrExtend.
    /// Implements the <see cref="System.Data.Entity.Migrations.DbMigration" />
    /// Implements the <see cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    /// </summary>
    /// <seealso cref="System.Data.Entity.Migrations.DbMigration" />
    /// <seealso cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    public partial class WfActionAttrExtend : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            DropIndex("dbo.WorkflowActionAttribute", "IX_WorkflowActionAttributeName");
            DropIndex("dbo.WorkflowActionAttribute", new[] { "WorkflowActionId" });
            CreateIndex("dbo.WorkflowActionAttribute", new[] { "Name", "WorkflowActionId" }, unique: true, name: "IX_WorkflowActionAttributeName");
        }

        /// <summary>
        /// Downs this instance.
        /// </summary>
        public override void Down()
        {
            DropIndex("dbo.WorkflowActionAttribute", "IX_WorkflowActionAttributeName");
            CreateIndex("dbo.WorkflowActionAttribute", "WorkflowActionId");
            CreateIndex("dbo.WorkflowActionAttribute", "Name", unique: true, name: "IX_WorkflowActionAttributeName");
        }
    }
}
