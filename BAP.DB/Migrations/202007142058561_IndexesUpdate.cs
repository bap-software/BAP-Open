// ***********************************************************************
// Assembly         : BAP.DB.eCommerce
// Author           : Victor Mamray
// Created          : 07-15-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 07-15-2020
// ***********************************************************************
// <copyright file="202007142058561_IndexesUpdate.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.DB.eCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Class IndexesUpdate.
    /// Implements the <see cref="System.Data.Entity.Migrations.DbMigration" />
    /// Implements the <see cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    /// </summary>
    /// <seealso cref="System.Data.Entity.Migrations.DbMigration" />
    /// <seealso cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    public partial class IndexesUpdate : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            DropIndex("dbo.WorkflowAction", "IX_WorkflowActionName");
            DropIndex("dbo.WorkflowAction", new[] { "WorkflowId" });
            DropIndex("dbo.WorkflowStageTransition", "IX_WorkflowTransitionName");
            DropIndex("dbo.WorkflowStageTransition", new[] { "WorkflowId" });
            DropIndex("dbo.WorkflowStage", "IX_WorkflowStageName");
            DropIndex("dbo.WorkflowStage", new[] { "WorkflowId" });
            DropIndex("dbo.WorkflowClass", "IX_WorkflowClassName");
            DropIndex("dbo.WorkflowObject", "IX_WorkflowObjectName");
            DropIndex("dbo.WorkflowObject", new[] { "WorkflowId" });
            CreateIndex("dbo.WorkflowAction", new[] { "Name", "WorkflowId" }, unique: true, name: "IX_WorkflowActionName");
            CreateIndex("dbo.WorkflowStageTransition", new[] { "Name", "WorkflowId" }, unique: true, name: "IX_WorkflowTransitionName");
            CreateIndex("dbo.WorkflowStage", new[] { "Name", "WorkflowId" }, unique: true, name: "IX_WorkflowStageName");
            CreateIndex("dbo.WorkflowClass", new[] { "Name", "TenantUnit", "TenantUnitId" }, unique: true, name: "IX_WorkflowClassName");
            CreateIndex("dbo.WorkflowObject", new[] { "Name", "WorkflowId" }, unique: true, name: "IX_WorkflowObjectName");
        }

        /// <summary>
        /// Downs this instance.
        /// </summary>
        public override void Down()
        {
            DropIndex("dbo.WorkflowObject", "IX_WorkflowObjectName");
            DropIndex("dbo.WorkflowClass", "IX_WorkflowClassName");
            DropIndex("dbo.WorkflowStage", "IX_WorkflowStageName");
            DropIndex("dbo.WorkflowStageTransition", "IX_WorkflowTransitionName");
            DropIndex("dbo.WorkflowAction", "IX_WorkflowActionName");
            CreateIndex("dbo.WorkflowObject", "WorkflowId");
            CreateIndex("dbo.WorkflowObject", "Name", unique: true, name: "IX_WorkflowObjectName");
            CreateIndex("dbo.WorkflowClass", "Name", unique: true, name: "IX_WorkflowClassName");
            CreateIndex("dbo.WorkflowStage", "WorkflowId");
            CreateIndex("dbo.WorkflowStage", "Name", unique: true, name: "IX_WorkflowStageName");
            CreateIndex("dbo.WorkflowStageTransition", "WorkflowId");
            CreateIndex("dbo.WorkflowStageTransition", "Name", unique: true, name: "IX_WorkflowTransitionName");
            CreateIndex("dbo.WorkflowAction", "WorkflowId");
            CreateIndex("dbo.WorkflowAction", "Name", unique: true, name: "IX_WorkflowActionName");
        }
    }
}
