// ***********************************************************************
// Assembly         : BAP.eCommerce.DAL
// Author           : Victor Mamray
// Created          : 06-19-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 07-22-2020
// ***********************************************************************
// <copyright file="OrderItem.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using BAP.Common;
using BAP.DAL.Entities;

namespace BAP.eCommerce.DAL.Entities
{
    /// <summary>
    /// Class OrderItem.
    /// Implements the <see cref="BAP.Common.IBapEntity" />
    /// Implements the <see cref="BAP.Common.IBapEntityWithState" />
    /// </summary>
    /// <seealso cref="BAP.Common.IBapEntity" />
    /// <seealso cref="BAP.Common.IBapEntityWithState" />
    [EntityPaging]
    [Table("OrderItem")]
    public partial class OrderItem : IBapEntity, IBapEntityWithState
    {
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
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_OrderItem_Name")]
        [Index("IX_OrderItemName", 1, IsUnique = true)]
        [StringLength(80)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the short description.
        /// </summary>
        /// <value>The short description.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_OrderItem_ShortDescription")]
        [StringLength(256)]
        public string ShortDescription { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_OrderItem_Description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>The product identifier.</value>
        [Required]
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_OrderItem_ProductId")]
        public int? ProductId { get; set; }

        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        /// <value>The product.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_OrderItem_Product")]
        public Product Product { get; set; }

        /// <summary>
        /// Gets or sets the subscription identifier.
        /// </summary>
        /// <value>The subscription identifier.</value>
        public int? SubscriptionId { get; set; }
        /// <summary>
        /// Gets or sets the subscription.
        /// </summary>
        /// <value>The subscription.</value>
        public Subscription Subscription { get; set; }

        /// <summary>
        /// Gets or sets the download URL.
        /// </summary>
        /// <value>The download URL.</value>
        [StringLength(1024)]
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_OrderItem_DownloadUrl")]
        public string DownloadUrl { get; set; }

        /// <summary>
        /// Gets or sets the online product URL.
        /// </summary>
        /// <value>The online product URL.</value>
        [StringLength(1024)]
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_OrderItem_OnlineProductUrl")]
        public string OnlineProductUrl { get; set; }

        /// <summary>
        /// Gets or sets the discount coupon identifier.
        /// </summary>
        /// <value>The discount coupon identifier.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_OrderItem_DiscountCouponId")]
        public int? DiscountCouponId { get; set; }

        /// <summary>
        /// Gets or sets the discount coupon.
        /// </summary>
        /// <value>The discount coupon.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_OrderItem_DiscountCoupon")]
        public DiscountCoupon DiscountCoupon { get; set; }

        /// <summary>
        /// Gets or sets the customer order identifier.
        /// </summary>
        /// <value>The customer order identifier.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_OrderItem_CustomerOrderId")]
        public int? CustomerOrderId { get; set; }

        /// <summary>
        /// Gets or sets the customer order.
        /// </summary>
        /// <value>The customer order.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_OrderItem_CustomerOrder")]
        public CustomerOrder CustomerOrder { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>The price.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_OrderItem_Price")]
        [Required]
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the count.
        /// </summary>
        /// <value>The count.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_OrderItem_Count")]
        [Required]
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets the subtotal.
        /// </summary>
        /// <value>The subtotal.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_OrderItem_Subtotal")]
        [Required]
        public decimal Subtotal { get; set; }

        /// <summary>
        /// Gets or sets the total tax.
        /// </summary>
        /// <value>The total tax.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_OrderItem_TotalTax")]
        public decimal TotalTax { get; set; }

        /// <summary>
        /// Gets or sets the total discounts.
        /// </summary>
        /// <value>The total discounts.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_OrderItem_TotalDiscounts")]
        public decimal TotalDiscounts { get; set; }

        /// <summary>
        /// Gets or sets the custom data.
        /// </summary>
        /// <value>The custom data.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_OrderItem_CustomData")]
        [StringLength(1024)]
        public string CustomData { get; set; }

        /// <summary>
        /// Gets or sets the options data.
        /// </summary>
        /// <value>The options data.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_OrderItem_OptionsData")]
        [StringLength(1024)]
        public string OptionsData { get; set; }

        //System fields
        /// <summary>
        /// Type of tenant, currently only Organization is supported.
        /// </summary>
        /// <value>The tenant unit.</value>
        [StringLength(50)]
        [Index("IX_OrderItemTenant", 1)]
        public string TenantUnit { get; set; }

        /// <summary>
        /// Tenant identifier, in fact Organization Id for a moment.
        /// </summary>
        /// <value>The tenant unit identifier.</value>
        [Index("IX_OrderItemTenant", 2)]
        public int? TenantUnitId { get; set; }

        /// <summary>
        /// Date and time when entity was first inserted into system's DB.
        /// </summary>
        /// <value>The create date.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_OrderItem_CreateDate")]
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
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_OrderItem_LastModifiedDate")]
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
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_OrderItem_CreatedByUserName")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]//[dbo].[ufnGetUserName]([CreatedBy])
        public string CreatedByUserName { get; private set; }

        /// <summary>
        /// Gets the last name of the modified by user.
        /// </summary>
        /// <value>The last name of the modified by user.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_OrderItem_LastModifiedByUserName")]
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
        [DefaultValue(27)]
        [Required]
        public int OwnerGroup { get; set; }
        /// <summary>
        /// Gets or sets the owner permissions.
        /// </summary>
        /// <value>The owner permissions.</value>
        [Index]
        [DefaultValue(15935)]
        [Required]
        public int OwnerPermissions { get; set; }
    }
}
