// ***********************************************************************
// Assembly         : BAP.DB.eCommerce
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="202001140051465_ScheduledTask.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.DB.eCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Class ScheduledTask.
    /// Implements the <see cref="System.Data.Entity.Migrations.DbMigration" />
    /// Implements the <see cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    /// </summary>
    /// <seealso cref="System.Data.Entity.Migrations.DbMigration" />
    /// <seealso cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    public partial class ScheduledTask : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            DropIndex("dbo.ScheduledTask", "IX_ScheduledTaskUniqueId");
            AddColumn("dbo.ScheduledTask", "Recurring", c => c.Boolean(nullable: false));
            AddColumn("dbo.WorkflowClass", "ScheduledTaskId", c => c.Int());
            AlterColumn("dbo.ScheduledTask", "Name", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.ScheduledTask", "ShortName", c => c.String(nullable: false, maxLength: 64));
            AlterColumn("dbo.ScheduledTask", "UniqueId", c => c.String(maxLength: 64));
            AlterColumn("dbo.ScheduledTask", "JobClass", c => c.String(nullable: false));
            AlterColumn("dbo.ScheduledTask", "JobAssembly", c => c.String(nullable: false));
            CreateIndex("dbo.ScheduledTask", "UniqueId", unique: true, name: "IX_ScheduledTaskUniqueId");
            CreateIndex("dbo.WorkflowClass", "ScheduledTaskId");
            AddForeignKey("dbo.WorkflowClass", "ScheduledTaskId", "dbo.ScheduledTask", "Id");
            DropColumn("dbo.ScheduledTask", "Reoccurring");
        }

        /// <summary>
        /// Downs this instance.
        /// </summary>
        public override void Down()
        {
            AddColumn("dbo.ScheduledTask", "Reoccurring", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.WorkflowClass", "ScheduledTaskId", "dbo.ScheduledTask");
            DropIndex("dbo.WorkflowClass", new[] { "ScheduledTaskId" });
            DropIndex("dbo.ScheduledTask", "IX_ScheduledTaskUniqueId");
            AlterColumn("dbo.ScheduledTask", "JobAssembly", c => c.String());
            AlterColumn("dbo.ScheduledTask", "JobClass", c => c.String());
            AlterColumn("dbo.ScheduledTask", "UniqueId", c => c.Guid(nullable: false));
            AlterColumn("dbo.ScheduledTask", "ShortName", c => c.String(maxLength: 64));
            AlterColumn("dbo.ScheduledTask", "Name", c => c.String(maxLength: 256));
            DropColumn("dbo.WorkflowClass", "ScheduledTaskId");
            DropColumn("dbo.ScheduledTask", "Recurring");
            CreateIndex("dbo.ScheduledTask", "UniqueId", unique: true, name: "IX_ScheduledTaskUniqueId");
        }
    }
}
