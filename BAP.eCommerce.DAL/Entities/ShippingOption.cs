// ***********************************************************************
// Assembly         : BAP.eCommerce.DAL
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="ShippingOption.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
/************************************************************************************************************
ShippingOption BAP data model entity
Create Date: 1/12/2017 5:37:09 PM
Template Author: Victor (C) 2017
************************************************************************************************************/
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using BAP.Common;

using BAP.eCommerce.Resources;
using System.Collections.Generic;

namespace BAP.eCommerce.DAL.Entities
{
    /// <summary>
    /// Class ShippingOption.
    /// Implements the <see cref="BAP.Common.IBapEntity" />
    /// Implements the <see cref="BAP.Common.IBapEntityWithState" />
    /// Implements the <see cref="BAP.Common.ISupportLocalization" />
    /// </summary>
    /// <seealso cref="BAP.Common.IBapEntity" />
    /// <seealso cref="BAP.Common.IBapEntityWithState" />
    /// <seealso cref="BAP.Common.ISupportLocalization" />
    [EntityPaging]
    [Table("ShippingOption")]
    public partial class ShippingOption : IBapEntity, IBapEntityWithState, ISupportLocalization
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
        [Index("IX_ShippingOptionName", 1, IsUnique = true)]
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ShippingOption_Name")]
        [StringLength(80)]
        [Required]
        [CriteriaField]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the short description.
        /// </summary>
        /// <value>The short description.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ShippingOption_ShortDescription")]
        [StringLength(256)]
        public string ShortDescription { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ShippingOption_Description")]
        [StringLength(1024)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ShippingOption"/> is enabled.
        /// </summary>
        /// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ShippingOption_Enabled")]
        [Required]
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets the custom configuration json.
        /// </summary>
        /// <value>The custom configuration json.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_General_CustomConfigJson")]
        public string CustomConfigJson { get; set; }

        /// <summary>
        /// Gets or sets the maximum price.
        /// </summary>
        /// <value>The maximum price.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ShippingOption_MaxPrice")]
        public decimal? MaxPrice { get; set; }

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
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ShippingOption_CreateDate")]
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
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ShippingOption_LastModifiedDate")]
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
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ShippingOption_CreatedByUserName")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]//[dbo].[ufnGetUserName]([CreatedBy])
        public string CreatedByUserName { get; private set; }

        /// <summary>
        /// Gets the last name of the modified by user.
        /// </summary>
        /// <value>The last name of the modified by user.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ShippingOption_LastModifiedByUserName")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]//[dbo].[ufnGetUserName]([LastModifiedBy])
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
        [Required]
        public int OwnerGroup { get; set; }

        /// <summary>
        /// Bitmask holding data what types of permissions are allowed over this types of entity.
        /// </summary>
        /// <value>The owner permissions.</value>
        [Index]
        [DefaultValue(1875535)]
        [Required]
        public int OwnerPermissions { get; set; }

        /// <summary>
        /// Gets or sets the shipping carrier identifier.
        /// </summary>
        /// <value>The shipping carrier identifier.</value>
        [Required]
        public int? ShippingCarrierId { get; set; }

        /// <summary>
        /// Gets or sets the shipping carrier.
        /// </summary>
        /// <value>The shipping carrier.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ShippingOption_ShippingCarrier")]
        public ShippingCarrier ShippingCarrier { get; set; }

        /// <summary>
        /// Gets or sets the teaser image.
        /// </summary>
        /// <value>The teaser image.</value>
        [StringLength(256)]
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ShippingOption_TeaserImage")]
        [FileField]
        public string TeaserImage { get; set; }

        /// <summary>
        /// Gets or sets the option code.
        /// </summary>
        /// <value>The option code.</value>
        [StringLength(40)]
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ShippingOption_OptionCode")]
        [Required]
        public string OptionCode { get; set; }

        /// <summary>
        /// Gets or sets the allowed payment options.
        /// </summary>
        /// <value>The allowed payment options.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ShippingOption_AllowedPaymentOption")]
        public List<PaymentOption> AllowedPaymentOptions { get; set; }

        /// <summary>
        /// Gets or sets the stores.
        /// </summary>
        /// <value>The stores.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ShippingOption_Stores")]
        public List<Store> Stores { get; set; }
    }
}
