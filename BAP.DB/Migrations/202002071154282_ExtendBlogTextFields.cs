// ***********************************************************************
// Assembly         : BAP.DB.eCommerce
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="202002071154282_ExtendBlogTextFields.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.DB.eCommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Class ExtendBlogTextFields.
    /// Implements the <see cref="System.Data.Entity.Migrations.DbMigration" />
    /// Implements the <see cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    /// </summary>
    /// <seealso cref="System.Data.Entity.Migrations.DbMigration" />
    /// <seealso cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    public partial class ExtendBlogTextFields : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            AlterColumn("dbo.Blog", "Description", c => c.String(maxLength: 4000));
            AlterColumn("dbo.BlogComment", "Text", c => c.String(maxLength: 4000));
            AlterColumn("dbo.BlogPost", "Text", c => c.String(maxLength: 4000));
        }

        /// <summary>
        /// Downs this instance.
        /// </summary>
        public override void Down()
        {
            AlterColumn("dbo.BlogPost", "Text", c => c.String(maxLength: 2048));
            AlterColumn("dbo.BlogComment", "Text", c => c.String(maxLength: 512));
            AlterColumn("dbo.Blog", "Description", c => c.String(maxLength: 1024));
        }
    }
}
