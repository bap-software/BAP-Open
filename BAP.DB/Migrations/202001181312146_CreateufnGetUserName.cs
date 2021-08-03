// ***********************************************************************
// Assembly         : BAP.DB.eCommerce
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="202001181312146_CreateufnGetUserName.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.DB.eCommerce.Migrations
{
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Class CreateufnGetUserName.
    /// Implements the <see cref="System.Data.Entity.Migrations.DbMigration" />
    /// Implements the <see cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    /// </summary>
    /// <seealso cref="System.Data.Entity.Migrations.DbMigration" />
    /// <seealso cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    public partial class CreateufnGetUserName : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            Sql(@"
IF OBJECT_ID('dbo.ufnGetUserName') IS NULL
BEGIN
EXEC dbo.sp_executesql @statement =  N'CREATE FUNCTION [dbo].[ufnGetUserName] (@UserId nvarchar(128)) RETURNS nvarchar(256) AS BEGIN DECLARE @result nvarchar(256); SELECT @result = UserName FROM [dbo].[AspNetUsers] WHERE Id = @UserId; RETURN @result; END'
END
GO
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
