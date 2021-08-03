// ***********************************************************************
// Assembly         : BAP.DB.eCommerce
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="201912180844501_FixMenu.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.DB.eCommerce.Migrations
{
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Class FixMenu.
    /// Implements the <see cref="System.Data.Entity.Migrations.DbMigration" />
    /// Implements the <see cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    /// </summary>
    /// <seealso cref="System.Data.Entity.Migrations.DbMigration" />
    /// <seealso cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    public partial class FixMenu : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            Sql(@"
                DECLARE @parentNodeId int;
                SELECT TOP 1 @parentNodeId = Id FROM [dbo].[ContentNode] WHERE [Name] = 'Shop';
                UPDATE [dbo].[ContentNode] SET [MenuSortOrder] = 12 WHERE [Name] = 'Stores';
                UPDATE [dbo].[ContentNode] SET [ParentNodeId] = @parentNodeId WHERE [Name] = 'Customers';
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
