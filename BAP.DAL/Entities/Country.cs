// ***********************************************************************
// Assembly         : BAP.DAL
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="Country.cs" company="BAP Software Ltd.">
//     Copyright © 2015 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
/************************************************************************************************************
Currency - data model entity for the given project BAP
Create Date: 6/6/2016 11:33:57 AM
Template Author: Victor Mamray (C) 2016
************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BAP.Common;
using System.ComponentModel;

namespace BAP.DAL.Entities
{
    /// <summary>
    /// Class Country.
    /// Implements the <see cref="BAP.Common.IBapEntity" />
    /// Implements the <see cref="BAP.Common.IFullTextSearchable" />
    /// Implements the <see cref="BAP.Common.IBapEntityWithState" />
    /// Implements the <see cref="BAP.Common.ISupportLocalization" />
    /// </summary>
    /// <seealso cref="BAP.Common.IBapEntity" />
    /// <seealso cref="BAP.Common.IFullTextSearchable" />
    /// <seealso cref="BAP.Common.IBapEntityWithState" />
    /// <seealso cref="BAP.Common.ISupportLocalization" />
    [EntityPaging]    
    [Table("Country")]
    public partial class Country : IBapEntity, IFullTextSearchable, IBapEntityWithState, ISupportLocalization
    {
        /// <summary>
        /// Gets or sets the internal identifier.
        /// </summary>
        /// <value>The internal identifier.</value>
        [NotMapped]
        public Guid InternalId { get; set; } = Guid.NewGuid();
        /// <summary>
        /// To identify culture neutral entity and to gather identical but different by language entities
        /// </summary>
        /// <value>The localized properties.</value>
        [NotMapped]
        public string[] LocalizedProperties => new string[] { "Name", "ShortName", "Description" };


        /// <summary>
        /// State of the BAP entity in terms of EF context.
        /// </summary>
        /// <value>The state of the entity.</value>
        [NotMapped]
        public BAPEntityState EntityState { get; set; }

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
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Common_Name")]
        [StringLength(256)]
        [SortingField]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the short name.
        /// </summary>
        /// <value>The short name.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Common_ShortName")]
        [StringLength(64)]
        [SortingField]
        [Required]
        public string ShortName { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Common_Description")]
        [StringLength(1024)]
        [SortingField]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the two letter code.
        /// </summary>
        /// <value>The two letter code.</value>
        [Index("IX_CountryTwoLetterCode", 1, IsUnique = true)]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Country_TwoLetterCode")]
        [StringLength(5)]
        [Required]
        [SortingField]
        [CriteriaField]
        public string TwoLetterCode { get; set; }

        /// <summary>
        /// Gets or sets the three letter code.
        /// </summary>
        /// <value>The three letter code.</value>
        [Index("IX_CountryThreeLetterCode", 1, IsUnique = true)]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Country_ThreeLetterCode")]
        [StringLength(5)]
        [Required]
        [SortingField]
        [CriteriaField]
        public string ThreeLetterCode { get; set; }

        /// <summary>
        /// Gets or sets the flag SVG11 path.
        /// </summary>
        /// <value>The flag SVG11 path.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Country_FlagSvg11Path")]
        [StringLength(512)]
        [FileField]
        public string FlagSvg11Path { get; set; }

        /// <summary>
        /// Gets or sets the flag SVG43 path.
        /// </summary>
        /// <value>The flag SVG43 path.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Country_FlagSvg43Path")]
        [StringLength(512)]
        [FileField]
        public string FlagSvg43Path { get; set; }

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
        [Display(ResourceType = typeof (Resources.Resources), Name = "FieldLabel_Common_CreateDate")]
        public DateTime? CreateDate { get; set; }

        /// <summary>
        /// Identifier of the user wh created an entity.
        /// </summary>
        /// <value>The created by.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Common_CreatedBy")]
        [StringLength(128)]
        public string CreatedBy { get; set; }

        /// <summary>
        /// Date and time when entity was last modified.
        /// </summary>
        /// <value>The last modified date.</value>
        [Display(ResourceType = typeof (Resources.Resources), Name = "FieldLabel_Common_LastModifiedDate")]
        public DateTime? LastModifiedDate { get; set; }

        /// <summary>
        /// Identifier of the user who modified entity last time.
        /// </summary>
        /// <value>The last modified by.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Common_LastModifiedBy")]
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
        [Display(ResourceType = typeof (Resources.Resources), Name = "FieldLabel_Common_CreatedByUserName")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string CreatedByUserName { get; private set; }

        /// <summary>
        /// Gets the last name of the modified by user.
        /// </summary>
        /// <value>The last name of the modified by user.</value>
        [Display(ResourceType = typeof (Resources.Resources), Name = "FieldLabel_Common_LastModifiedByUserName")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string LastModifiedByUserName { get; private set; }

        /// <summary>
        /// Bitmask holding data what roles are allowed to access this type of entity.
        /// </summary>
        /// <value>The owner group.</value>
        [Index]
        [DefaultValue(123)]
        public int OwnerGroup { get; set; }
        /// <summary>
        /// Bitmask holding data what types of permissions are allowed over this types of entity.
        /// </summary>
        /// <value>The owner permissions.</value>
        [Index]
        [DefaultValue(1875471)]
        public int OwnerPermissions { get; set; }

        /// <summary>
        /// Gets or sets the states.
        /// </summary>
        /// <value>The states.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Country_States")]
        public List<State> States { get; set; }

        /// <summary>
        /// Fulls the text search expression.
        /// </summary>
        /// <param name="searchValue">The search value.</param>
        /// <returns>System.String.</returns>
        public string FullTextSearchExpression(string searchValue)
        {
            return string.Format("(Name.Contains(\"{0}\") OR TwoLetterCode.Contains(\"{0}\") OR ThreeLetterCode.Contains(\"{0}\") OR Description.Contains(\"{0}\"))", searchValue);
        }
    }
}
