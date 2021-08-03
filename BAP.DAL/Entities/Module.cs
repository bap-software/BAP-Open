// ***********************************************************************
// Assembly         : BAP.DAL
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="Module.cs" company="BAP Software Ltd.">
//     Copyright © 2015 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
/************************************************************************************************************
Message BAP data model entity
Create Date: 12/11/2016 9:13:44 PM
Template Author: Victor (C) 2016
************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using BAP.Common;

namespace BAP.DAL.Entities
{
    /// <summary>
    /// Class Module.
    /// Implements the <see cref="BAP.Common.IBapEntity" />
    /// Implements the <see cref="BAP.Common.IBapEntityWithState" />
    /// Implements the <see cref="BAP.Common.ISupportLocalization" />
    /// </summary>
    /// <seealso cref="BAP.Common.IBapEntity" />
    /// <seealso cref="BAP.Common.IBapEntityWithState" />
    /// <seealso cref="BAP.Common.ISupportLocalization" />
    [EntityPaging]
    [Table("Module")]
    public partial class Module : IBapEntity, IBapEntityWithState, ISupportLocalization
    {
        /// <summary>
        /// State of the BAP entity in terms of EF context.
        /// </summary>
        /// <value>The state of the entity.</value>
        [NotMapped]
        public BAPEntityState EntityState { get; set; }

        /// <summary>
        /// To identify culture neutral entity and to gather identical but different by language entities
        /// </summary>
        /// <value>The localized properties.</value>
        [NotMapped]
        public string[] LocalizedProperties => new string[] { "Name", "ShortDescription", "Description" };


        /// <summary>
        /// Internal identifier of the entity, also identity field in DB.
        /// </summary>
        /// <value>The identifier.</value>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Name of the entity, in most of the cases it has to be unique within given tenant scope.
        /// </summary>
        /// <value>The name.</value>
        [Index("IX_Module", 1, IsUnique = true)]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Module_Name")]
        [StringLength(80)]
        [SortingField]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the short description.
        /// </summary>
        /// <value>The short description.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Module_ShortDescription")]
        [StringLength(256)]
        [SortingField]
        public string ShortDescription { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Module_Description")]
        [StringLength(4000)]
        [SortingField]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Module"/> is enabled.
        /// </summary>
        /// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Module_Enabled")]
        [DefaultValue(true)]
        [SortingField]
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets the global identifier.
        /// </summary>
        /// <value>The global identifier.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Module_GlobalId")]
        [SortingField]
        public Guid GlobalId { get; set; }

        /// <summary>
        /// Gets or sets the roles.
        /// </summary>
        /// <value>The roles.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Module_Roles")]
        [StringLength(200)]
        [SortingField]
        public string Roles { get; set; }

        /// <summary>
        /// Gets or sets the bit mask.
        /// </summary>
        /// <value>The bit mask.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Module_BitMask")]
        [SortingField]
        public int BitMask { get; set; }

        /// <summary>
        /// Type of tenant, currently only Organization is supported.
        /// </summary>
        /// <value>The tenant unit.</value>
        [Index("IX_Tenant", 1)]
        [StringLength(50)]
        public string TenantUnit { get; set; }

        /// <summary>
        /// Tenant identifier, in fact Organization Id for a moment.
        /// </summary>
        /// <value>The tenant unit identifier.</value>
        [Index("IX_Tenant", 2)]
        public int? TenantUnitId { get; set; }

        /// <summary>
        /// Date and time when entity was first inserted into system's DB.
        /// </summary>
        /// <value>The create date.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Module_CreateDate")]
        [SortingField]
        public DateTime? CreateDate { get; set; }

        /// <summary>
        /// Identifier of the user wh created an entity.
        /// </summary>
        /// <value>The created by.</value>
        [StringLength(128)]
        public string CreatedBy { get; set; }

        /// <summary>
        /// Date and time when entity was last modified.
        /// </summary>
        /// <value>The last modified date.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Module_LastModifiedDate")]
        public DateTime? LastModifiedDate { get; set; }

        /// <summary>
        /// Identifier of the user who modified entity last time.
        /// </summary>
        /// <value>The last modified by.</value>
        [StringLength(128)]
        public string LastModifiedBy { get; set; }

        /// <summary>
        /// Timestamp assigned when entity was last modified, concurrency identificator.
        /// </summary>
        /// <value>The time stamp.</value>
        [Timestamp]
        public byte[] TimeStamp { get; set; }

        /// <summary>
        /// Gets the name of the created by user.
        /// </summary>
        /// <value>The name of the created by user.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Module_CreatedByUserName")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string CreatedByUserName { get; private set; }

        /// <summary>
        /// Gets the last name of the modified by user.
        /// </summary>
        /// <value>The last name of the modified by user.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Module_LastModifiedByUserName")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string LastModifiedByUserName { get; private set; }

        /// <summary>
        /// Fulls the text search expression.
        /// </summary>
        /// <param name="searchValue">The search value.</param>
        /// <returns>System.String.</returns>
        public string FullTextSearchExpression(string searchValue)
        {
            return " 1 = 1 ";
        }

        /// <summary>
        /// Bitmask holding data what roles are allowed to access this type of entity.
        /// </summary>
        /// <value>The owner group.</value>
        [Index]
        [DefaultValue(127)]
        public int OwnerGroup { get; set; }
        /// <summary>
        /// Bitmask holding data what types of permissions are allowed over this types of entity.
        /// </summary>
        /// <value>The owner permissions.</value>
        [Index]
        [DefaultValue(299599)]
        public int OwnerPermissions { get; set; }

        /// <summary>
        /// Gets or sets the organization modules.
        /// </summary>
        /// <value>The organization modules.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_OrganizationModules")]
        public virtual List<OrganizationModule> OrganizationModules { get; set; }
    }
}
