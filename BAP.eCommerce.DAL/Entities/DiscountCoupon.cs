// ***********************************************************************
// Assembly         : BAP.eCommerce.DAL
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="DiscountCoupon.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
/************************************************************************************************************
DiscountCoupon BAP data model entity
Create Date: 1/12/2017 5:37:58 PM
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
    /// Enum DiscountType
    /// </summary>
    public enum DiscountType
    {
        /// <summary>
        /// The none
        /// </summary>
        None = 0,
        /// <summary>
        /// The product coupon
        /// </summary>
        ProductCoupon,
        /// <summary>
        /// The order discount
        /// </summary>
        OrderDiscount,
        /// <summary>
        /// The buy x get y
        /// </summary>
        BuyXGetY,
        /// <summary>
        /// The free shipping
        /// </summary>
        FreeShipping,
        /// <summary>
        /// The volume discount
        /// </summary>
        VolumeDiscount
    }

    /// <summary>
    /// Class DiscountCoupon.
    /// Implements the <see cref="BAP.Common.IBapEntity" />
    /// Implements the <see cref="BAP.Common.IBapEntityWithState" />
    /// Implements the <see cref="BAP.Common.ISupportLocalization" />
    /// </summary>
    /// <seealso cref="BAP.Common.IBapEntity" />
    /// <seealso cref="BAP.Common.IBapEntityWithState" />
    /// <seealso cref="BAP.Common.ISupportLocalization" />
    [EntityPaging]
    [Table("DiscountCoupon")]
    public partial class DiscountCoupon : IBapEntity, IBapEntityWithState, ISupportLocalization
    {

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
        [Index("IX_DiscountCouponName", 1, IsUnique = true)]
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_DiscountCoupon_Name")]
        [StringLength(80)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the short description.
        /// </summary>
        /// <value>The short description.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_DiscountCoupon_ShortDescription")]
        [StringLength(256)]
        public string ShortDescription { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_DiscountCoupon_Description")]
        [StringLength(1024)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="DiscountCoupon"/> is enabled.
        /// </summary>
        /// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_DiscountCoupon_Enabled")]
        [Required]
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is percent.
        /// </summary>
        /// <value><c>true</c> if this instance is percent; otherwise, <c>false</c>.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_DiscountCoupon_IsPercent")]
        public bool IsPercent { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>The amount.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_DiscountCoupon_Amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_DiscountCoupon_Code")]
        [StringLength(200)]        
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the extra codes text.
        /// </summary>
        /// <value>The extra codes text.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_DiscountCoupon_ExtraCodesText")]        
        public string ExtraCodesText { get; set; }

        /// <summary>
        /// Gets the extra codes.
        /// </summary>
        /// <value>The extra codes.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_DiscountCoupon_ExtraCodes")]
        [NotMapped]
        public string[] ExtraCodes
        {
            get
            {
                if (!string.IsNullOrEmpty(ExtraCodesText))
                    return ExtraCodesText.Split(",".ToCharArray());

                return null;
            }
        }

        /// <summary>
        /// Gets or sets the custom data.
        /// </summary>
        /// <value>The custom data.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_DiscountCoupon_CustomData")]        
        public string CustomData { get; set; }

        /// <summary>
        /// Gets or sets the type of the discount.
        /// </summary>
        /// <value>The type of the discount.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_DiscountCoupon_DiscountType")]
        public DiscountType DiscountType { get; set; }

        /// <summary>
        /// Gets or sets the products applied.
        /// </summary>
        /// <value>The products applied.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_DiscountCoupon_ProductsAppied")]
        public List<Product> ProductsApplied { get; set; }

        /// <summary>
        /// Gets or sets the product applied ids.
        /// </summary>
        /// <value>The product applied ids.</value>
        [NotMapped]
        public List<int> ProductAppliedIds { get; set; }

        /// <summary>
        /// Gets or sets the valid from.
        /// </summary>
        /// <value>The valid from.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_DiscountCoupon_ValidFrom")]
        public DateTime ValidFrom { get; set; }

        /// <summary>
        /// Gets or sets the valid to.
        /// </summary>
        /// <value>The valid to.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_DiscountCoupon_ValidTo")]
        public DateTime ValidTo { get; set; }

        /// <summary>
        /// Gets or sets the priority.
        /// </summary>
        /// <value>The priority.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_DiscountCoupon_Priority")]
        public int Priority { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [allow lower priority].
        /// </summary>
        /// <value><c>true</c> if [allow lower priority]; otherwise, <c>false</c>.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_DiscountCoupon_AllowLowerPriority")]
        public bool AllowLowerPriority { get; set; }

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
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_DiscountCoupon_CreateDate")]
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
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_DiscountCoupon_LastModifiedDate")]
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
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_DiscountCoupon_CreatedByUserName")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]//[dbo].[ufnGetUserName]([CreatedBy])
        public string CreatedByUserName { get; private set; }

        /// <summary>
        /// Gets the last name of the modified by user.
        /// </summary>
        /// <value>The last name of the modified by user.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_DiscountCoupon_LastModifiedByUserName")]
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
        [DefaultValue(1842703)]
        [Required]
        public int OwnerPermissions { get; set; }
        /// <summary>
        /// State of the BAP entity in terms of EF context.
        /// </summary>
        /// <value>The state of the entity.</value>
        [NotMapped]
        public BAPEntityState EntityState { get; set; }

        /// <summary>
        /// Gets or sets the apply criteria.
        /// </summary>
        /// <value>The apply criteria.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_DiscountCoupon_ApplyCriteria")]
        [NotMapped]
        public ICriteria<ShoppingCart> ApplyCriteria { get; set; }

        /// <summary>
        /// Gets or sets the buy x amount.
        /// </summary>
        /// <value>The buy x amount.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_DiscountCoupon_BuyXAmount")]
        public int? BuyXAmount { get; set; }

        /// <summary>
        /// Gets or sets the get y amount.
        /// </summary>
        /// <value>The get y amount.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_DiscountCoupon_GetYAmount")]
        public int? GetYAmount { get; set; }

        /// <summary>
        /// Gets or sets the stores.
        /// </summary>
        /// <value>The stores.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_DiscountCoupon_Stores")]
        public List<Store> Stores { get; set; }
    }
}
