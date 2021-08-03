// ***********************************************************************
// Assembly         : BAP.DAL
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="Currency.cs" company="BAP Software Ltd.">
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
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BAP.Common;
using System.ComponentModel;

namespace BAP.DAL.Entities
{
    /// <summary>
    /// Class Currency.
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
    [Table("Currency")]
    public partial class Currency : IBapEntity, IFullTextSearchable, IBapEntityWithState, ISupportLocalization
    {
        /// <summary>
        /// Gets or sets the internal identifier.
        /// </summary>
        /// <value>The internal identifier.</value>
        [NotMapped]
        public Guid InternalId { get; set; } = Guid.NewGuid();

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
        public string[] LocalizedProperties => new string[] { "Name", "Description", "FormatString" };


        /// <summary>
        /// Internal identifier of the entity, also identity field in DB.
        /// </summary>
        /// <value>The identifier.</value>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the three letter code.
        /// </summary>
        /// <value>The three letter code.</value>
        [Index("IX_CurrencyCode", 1, IsUnique = true)]
        [Display(ResourceType = typeof (Resources.Resources), Name = "FieldLabel_Currency_ThreeLetterCode")]
        [StringLength(5)]
        [Required]
        [CriteriaField]
        public string ThreeLetterCode { get; set; }

        /// <summary>
        /// Name of the entity, in most of the cases it has to be unique within given tenant scope.
        /// </summary>
        /// <value>The name.</value>
        [Display(ResourceType = typeof (Resources.Resources), Name = "FieldLabel_Currency_Name")]
        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [Display(ResourceType = typeof (Resources.Resources), Name = "FieldLabel_Currency_Description")]
        [StringLength(255)]
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the exchange rate.
        /// </summary>
        /// <value>The exchange rate.</value>
        [Display(ResourceType = typeof (Resources.Resources), Name = "FieldLabel_Currency_ExchangeRate")]
        [DataType("decimal(18,4")]
        public decimal? ExchangeRate { get; set; }

        /// <summary>
        /// Gets or sets the symbol.
        /// </summary>
        /// <value>The symbol.</value>
        [Display(ResourceType = typeof (Resources.Resources), Name = "FieldLabel_Currency_Symbol")]
        [StringLength(5)]
        [Required]
        public string Symbol { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is main.
        /// </summary>
        /// <value><c>true</c> if this instance is main; otherwise, <c>false</c>.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Currency_IsMain")]
        public bool IsMain { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is enabled.
        /// </summary>
        /// <value><c>true</c> if this instance is enabled; otherwise, <c>false</c>.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Currency_IsEnabled")]
        public bool IsEnabled { get; set; }

        /// <summary>
        /// Gets or sets the round to.
        /// </summary>
        /// <value>The round to.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Currency_RoundTo")]
        public int RoundTo { get; set; }

        /// <summary>
        /// Gets or sets the format string.
        /// </summary>
        /// <value>The format string.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Currency_FormatString")]
        [StringLength(20)]       
        public string FormatString { get; set; }

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
        [Display(ResourceType = typeof (Resources.Resources), Name = "FieldLabel_Currency_CreateDate")]
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
        [Display(ResourceType = typeof (Resources.Resources), Name = "FieldLabel_Currency_LastModifiedDate")]
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
        [Display(ResourceType = typeof (Resources.Resources), Name = "FieldLabel_Currency_CreatedByUserName")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]//[dbo].[ufnGetUserName]([CreatedBy])
        public string CreatedByUserName { get; private set; }

        /// <summary>
        /// Gets the last name of the modified by user.
        /// </summary>
        /// <value>The last name of the modified by user.</value>
        [Display(ResourceType = typeof (Resources.Resources), Name = "FieldLabel_Currency_LastModifiedByUserName")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]//[dbo].[ufnGetUserName]([LastModifiedBy])
        public string LastModifiedByUserName { get; private set; }

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
        [DefaultValue(1875535)]
        public int OwnerPermissions { get; set; }

        /// <summary>
        /// Fulls the text search expression.
        /// </summary>
        /// <param name="searchValue">The search value.</param>
        /// <returns>System.String.</returns>
        public string FullTextSearchExpression(string searchValue)
        {
            return string.Format("(Name.Contains(\"{0}\") OR ThreeLetterCode.Contains(\"{0}\") OR Description.Contains(\"{0}\"))", searchValue);
        }
    }
}
