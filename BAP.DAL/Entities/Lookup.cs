// ***********************************************************************
// Assembly         : BAP.DAL
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="Lookup.cs" company="BAP Software Ltd.">
//     Copyright © 2015 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using BAP.Common;
using System.ComponentModel;

namespace BAP.DAL.Entities
{
    /// <summary>
    /// Enum LookupType
    /// </summary>
    public enum LookupType
    {
        /// <summary>
        /// The option list
        /// </summary>
        OptionList = 1,
        /// <summary>
        /// The int range
        /// </summary>
        IntRange,
        /// <summary>
        /// The decimal range
        /// </summary>
        FloatRange,
        /// <summary>
        /// The date range
        /// </summary>
        DateRange,
        /// <summary>
        /// The entity
        /// </summary>
        Entity
    }

    /// <summary>
    /// Class Lookup.
    /// Implements the <see cref="BAP.Common.IBapEntity" />
    /// Implements the <see cref="BAP.Common.IFullTextSearchable" />
    /// Implements the <see cref="BAP.Common.IBapEntityWithState" />
    /// Implements the <see cref="BAP.Common.ISupportLocalization" />
    /// </summary>
    /// <seealso cref="BAP.Common.IBapEntity" />
    /// <seealso cref="BAP.Common.IFullTextSearchable" />
    /// <seealso cref="BAP.Common.IBapEntityWithState" />
    /// <seealso cref="BAP.Common.ISupportLocalization" />
    [Table("Lookup")]    
    public class Lookup : IBapEntity, IFullTextSearchable, IBapEntityWithState, ISupportLocalization
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
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Lookup_Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Name of the entity, in most of the cases it has to be unique within given tenant scope.
        /// </summary>
        /// <value>The name.</value>
        [Index("IX_LookupName", 1, IsUnique = true)]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Lookup_Name")]
        [StringLength(80)]
        [SortingField(true, true, true)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Lookup_Description")]
        [StringLength(255)]
        [SortingField]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the type of the lookup.
        /// </summary>
        /// <value>The type of the lookup.</value>
        [Display(ResourceType = typeof (Resources.Resources), Name = "FieldLabel_Lookup_Type")]
        [SortingField]
        public LookupType LookupType { get; set; }

        /// <summary>
        /// Gets or sets the int range from.
        /// </summary>
        /// <value>The int range from.</value>
        [Display(ResourceType = typeof (Resources.Resources), Name = "FieldLabel_Lookup_IntRangeFrom")]
        public int? IntRangeFrom { get; set; }

        /// <summary>
        /// Gets or sets the int range to.
        /// </summary>
        /// <value>The int range to.</value>
        [Display(ResourceType = typeof (Resources.Resources), Name = "FieldLabel_Lookup_IntRangeTo")]
        public int? IntRangeTo { get; set; }

        /// <summary>
        /// Gets or sets the decimal range from.
        /// </summary>
        /// <value>The decimal range from.</value>
        [Display(ResourceType = typeof (Resources.Resources), Name = "FieldLabel_Lookup_FloatRangeFrom")]
        public float? FloatRangeFrom { get; set; }

        /// <summary>
        /// Gets or sets the decimal range to.
        /// </summary>
        /// <value>The decimal range to.</value>
        [Display(ResourceType = typeof (Resources.Resources), Name = "FieldLabel_Lookup_FloatRangeTo")]
        public float? FloatRangeTo { get; set; }

        /// <summary>
        /// Gets or sets the decimal range step.
        /// </summary>
        /// <value>The decimal range step.</value>
        [Display(ResourceType = typeof (Resources.Resources), Name = "FieldLabel_Lookup_FloatRangeStep")]
        public float? FloatRangeStep { get; set; }

        /// <summary>
        /// Gets or sets the date range from.
        /// </summary>
        /// <value>The date range from.</value>
        [Display(ResourceType = typeof (Resources.Resources), Name = "FieldLabel_Lookup_DateRangeFrom")]
        public DateTime? DateRangeFrom { get; set; }

        /// <summary>
        /// Gets or sets the date range to.
        /// </summary>
        /// <value>The date range to.</value>
        [Display(ResourceType = typeof (Resources.Resources), Name = "FieldLabel_Lookup_DateRangeTo")]
        public DateTime? DateRangeTo { get; set; }

        /// <summary>
        /// Gets or sets the range prefix.
        /// </summary>
        /// <value>The range prefix.</value>
        [Display(ResourceType = typeof (Resources.Resources), Name = "FieldLabel_Lookup_RangePrefix")]
        [StringLength(10)]
        public string RangePrefix { get; set; }

        /// <summary>
        /// Gets or sets the name of the entity.
        /// </summary>
        /// <value>The name of the entity.</value>
        [Display(ResourceType = typeof (Resources.Resources), Name = "FieldLabel_Lookup_EntityName")]
        [StringLength(255)]
        public string EntityName { get; set; }

        /// <summary>
        /// Gets or sets the entity value field.
        /// </summary>
        /// <value>The entity value field.</value>
        [Display(ResourceType = typeof (Resources.Resources), Name = "FieldLabel_Lookup_EntityValueField")]
        [StringLength(80)]
        public string EntityValueField { get; set; }

        /// <summary>
        /// Gets or sets the entity name field.
        /// </summary>
        /// <value>The entity name field.</value>
        [Display(ResourceType = typeof (Resources.Resources), Name = "FieldLabel_Lookup_EntityNameField")]
        [StringLength(80)]
        public string EntityNameField { get; set; }

        /// <summary>
        /// Gets or sets the entity filter.
        /// </summary>
        /// <value>The entity filter.</value>
        [Display(ResourceType = typeof (Resources.Resources), Name = "FieldLabel_Lookup_EntityFilter")]
        [StringLength(1024)]
        public string EntityFilter { get; set; }

        /// <summary>
        /// Gets or sets the entity order by.
        /// </summary>
        /// <value>The entity order by.</value>
        [Display(ResourceType = typeof (Resources.Resources), Name = "FieldLabel_Lookup_EntityOrderBy")]
        [StringLength(512)]
        public string EntityOrderBy { get; set; }

        /// <summary>
        /// Gets or sets the parent lookup.
        /// </summary>
        /// <value>The parent lookup.</value>
        [Display(ResourceType = typeof (Resources.Resources), Name = "FieldLabel_Lookup_ParentLookup")]        
        public Lookup ParentLookup { get; set; }

        /// <summary>
        /// Gets or sets the values.
        /// </summary>
        /// <value>The values.</value>
        public List<LookupValue> Values { get; set; }

        /// <summary>
        /// Type of tenant, currently only Organization is supported.
        /// </summary>
        /// <value>The tenant unit.</value>
        [StringLength(50)]
        [Index("IX_Tenant", 1)]
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
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Lookup_CreateDate")]
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
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Lookup_LastModifiedDate")]
        [SortingField]
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
        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }

        /// <summary>
        /// Gets the name of the created by user.
        /// </summary>
        /// <value>The name of the created by user.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Lookup_CreatedByUserName")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]//[dbo].[ufnGetUserName]([CreatedBy])
        public string CreatedByUserName { get; private set; }

        /// <summary>
        /// Gets the last name of the modified by user.
        /// </summary>
        /// <value>The last name of the modified by user.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Lookup_LastModifiedByUserName")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]//[dbo].[ufnGetUserName]([LastModifiedBy])
        public string LastModifiedByUserName { get; private set; }

        /// <summary>
        /// Gets or sets the entity assembly.
        /// </summary>
        /// <value>The entity assembly.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Lookup_EntityAssembly")]
        [StringLength(512)]
        public string EntityAssembly { get; set; }

        /// <summary>
        /// Gets or sets the entity class.
        /// </summary>
        /// <value>The entity class.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Lookup_EntityClass")]
        [StringLength(512)]
        public string EntityClass { get; set; }

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
        [DefaultValue(302799)]
        public int OwnerPermissions { get; set; }

        /// <summary>
        /// Fulls the text search expression.
        /// </summary>
        /// <param name="searchValue">The search value.</param>
        /// <returns>System.String.</returns>
        public string FullTextSearchExpression(string searchValue)
        {
            return string.Format("(Name.Contains(\"{0}\") OR EntityName.Contains(\"{0}\") OR Description.Contains(\"{0}\"))", searchValue);
        }
    }
}
