// ***********************************************************************
// Assembly         : BAP.eCommerce.DAL
// Author           : Victor Mamray
// Created          : 04-24-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="ShoppingCartProduct.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
/************************************************************************************************************
ShoppingCartProduct BAP data model entity
Create Date: 1/3/2017 10:13:08 PM
Template Author: Victor (C) 2017
************************************************************************************************************/
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using BAP.Common;

using BAP.eCommerce.Resources;

namespace BAP.eCommerce.DAL.Entities
{
    /// <summary>
    /// Class ShoppingCartProduct.
    /// Implements the <see cref="BAP.Common.IBapEntity" />
    /// Implements the <see cref="BAP.Common.IBapEntityWithState" />
    /// </summary>
    /// <seealso cref="BAP.Common.IBapEntity" />
    /// <seealso cref="BAP.Common.IBapEntityWithState" />
    [EntityPaging]
    [Table("ShoppingCartProduct")]
    public partial class ShoppingCartProduct : IBapEntity, IBapEntityWithState
    {
        /// <summary>
        /// Name of the entity, in most of the cases it has to be unique within given tenant scope.
        /// </summary>
        /// <value>The name.</value>
        [NotMapped]
        public string Name { get; set; }


        /// <summary>
        /// Internal identifier of the entity, also identity field in DB.
        /// </summary>
        /// <value>The identifier.</value>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the count.
        /// </summary>
        /// <value>The count.</value>
        [Required]
        [CriteriaField]
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ShoppingCartProduct_Count")]
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>The price.</value>
        [Required]
        [CriteriaField]
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ShoppingCartProduct_Price")]
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the subtotal.
        /// </summary>
        /// <value>The subtotal.</value>
        [Required]
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ShoppingCartProduct_Subtotal")]
        public decimal Subtotal { get; set; }

        /// <summary>
        /// Gets or sets the total discount.
        /// </summary>
        /// <value>The total discount.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ShoppingCartProduct_TotalDiscount")]
        public decimal TotalDiscount { get; set; }

        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>The product identifier.</value>
        [Required]
        public int? ProductId { get; set; }
        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        /// <value>The product.</value>
        [CriteriaField(isClass:true)]
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ShoppingCartProduct_Product")]
        public Product Product { get; set; }

        /// <summary>
        /// Gets or sets the discount coupon identifier.
        /// </summary>
        /// <value>The discount coupon identifier.</value>
        public int? DiscountCouponId { get; set; }
        /// <summary>
        /// Gets or sets the discount coupon.
        /// </summary>
        /// <value>The discount coupon.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ShoppingCartDiscountCoupon_DiscountCoupon")]
        public DiscountCoupon DiscountCoupon { get; set; }

        /// <summary>
        /// Gets or sets the coupon.
        /// </summary>
        /// <value>The coupon.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ShoppingCartProduct_Coupon")]
        [StringLength(200)]
        public string Coupon { get; set; }

        /// <summary>
        /// Gets or sets the shopping cart identifier.
        /// </summary>
        /// <value>The shopping cart identifier.</value>
        public int? ShoppingCartId { get; set; }
        /// <summary>
        /// Gets or sets the shopping cart.
        /// </summary>
        /// <value>The shopping cart.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ShoppingCartProduct_ShoppingCart")]
        public ShoppingCart ShoppingCart { get; set; }

        /// <summary>
        /// Gets or sets the custom data.
        /// </summary>
        /// <value>The custom data.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ShoppingCartProduct_CustomData")]
        [StringLength(1024)]
        public string CustomData { get; set; }

        /// <summary>
        /// Gets or sets the options data.
        /// </summary>
        /// <value>The options data.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ShoppingCartProduct_OptionsData")]
        [StringLength(1024)]
        public string OptionsData { get; set; }

        /// <summary>
        /// Gets or sets the options added price.
        /// </summary>
        /// <value>The options added price.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ShoppingCartProduct_OptionsAddedPrice")]
        public decimal OptionsAddedPrice { get; set; }

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
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ShoppingCartProduct_CreateDate")]
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
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ShoppingCartProduct_LastModifiedDate")]
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
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ShoppingCartProduct_CreatedByUserName")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]//[dbo].[ufnGetUserName]([CreatedBy])
        public string CreatedByUserName { get; private set; }

        /// <summary>
        /// Gets the last name of the modified by user.
        /// </summary>
        /// <value>The last name of the modified by user.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ShoppingCartProduct_LastModifiedByUserName")]
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
        [DefaultValue(1867775)]
        [Required]
        public int OwnerPermissions { get; set; }

        /// <summary>
        /// Gets or sets the state of the entity.
        /// </summary>
        /// <value>The state of the entity.</value>
        [NotMapped]
        public BAPEntityState EntityState { get; set; }
    }
}
