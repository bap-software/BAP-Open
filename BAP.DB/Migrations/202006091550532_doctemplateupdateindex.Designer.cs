// ***********************************************************************
// Assembly         : BAP.DB.eCommerce
// Author           : Victor Mamray
// Created          : 06-09-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="202006091550532_doctemplateupdateindex.Designer.cs" company="BAP Software Ltd.">
//     Copyright ? 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.DB.eCommerce.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;

    /// <summary>
    /// Class doctemplateupdateindex. This class cannot be inherited.
    /// Implements the <see cref="System.Data.Entity.Migrations.DbMigration" />
    /// Implements the <see cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    /// </summary>
    /// <seealso cref="System.Data.Entity.Migrations.DbMigration" />
    /// <seealso cref="System.Data.Entity.Migrations.Infrastructure.IMigrationMetadata" />
    [GeneratedCode("EntityFramework.Migrations", "6.2.0-61023")]
    public sealed partial class doctemplateupdateindex : IMigrationMetadata
    {
        /// <summary>
        /// The resources
        /// </summary>
        private readonly ResourceManager Resources = new ResourceManager(typeof(doctemplateupdateindex));

        /// <summary>
        /// Gets the unique identifier for the migration.
        /// </summary>
        /// <value>The identifier.</value>
        string IMigrationMetadata.Id
        {
            get { return "202006091550532_doctemplateupdateindex"; }
        }

        /// <summary>
        /// Gets the state of the model before this migration is run.
        /// </summary>
        /// <value>The source.</value>
        string IMigrationMetadata.Source
        {
            get { return null; }
        }

        /// <summary>
        /// Gets the target.
        /// </summary>
        /// <value>The target.</value>
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}
