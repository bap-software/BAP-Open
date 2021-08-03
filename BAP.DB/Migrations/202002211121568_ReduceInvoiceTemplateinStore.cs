// ***********************************************************************
// Assembly         : BAP.DB.eCommerce
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="202002211121568_ReduceInvoiceTemplateinStore.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.DB.eCommerce.Migrations
{
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Class ReduceInvoiceTemplateinStore.
    /// Implements the <see cref="System.Data.Entity.Migrations.DbMigration" />
    /// Implements the <see cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    /// </summary>
    /// <seealso cref="System.Data.Entity.Migrations.DbMigration" />
    /// <seealso cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    public partial class ReduceInvoiceTemplateinStore : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            Sql("update dbo.Store set InvoiceTemplate = null");
            AlterColumn("dbo.Store", "InvoiceTemplate", c => c.String(maxLength: 80));
        }

        /// <summary>
        /// Downs this instance.
        /// </summary>
        public override void Down()
        {
            AlterColumn("dbo.Store", "InvoiceTemplate", c => c.String());
        }
    }
}
