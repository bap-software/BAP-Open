// ***********************************************************************
// Assembly         : BAP.eCommerce.DAL
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="Store.cs" company="BAP Software Ltd.">
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
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using BAP.Common;
using BAP.DAL.Entities;
using BAP.eCommerce.Resources;

namespace BAP.eCommerce.DAL.Entities
{
    /// <summary>
    /// Class Store.
    /// Implements the <see cref="BAP.Common.IBapEntity" />
    /// Implements the <see cref="BAP.Common.IBapEntityWithState" />
    /// Implements the <see cref="BAP.Common.ISupportLocalization" />
    /// </summary>
    /// <seealso cref="BAP.Common.IBapEntity" />
    /// <seealso cref="BAP.Common.IBapEntityWithState" />
    /// <seealso cref="BAP.Common.ISupportLocalization" />
    [EntityPaging]
    [Table("Store")]
    public partial class Store : IBapEntity, IBapEntityWithState, ISupportLocalization
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
        [SortingField(true, true, true, false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the short description.
        /// </summary>
        /// <value>The short description.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_DiscountCoupon_ShortDescription")]
        [StringLength(256)]
        [SortingField]
        public string ShortDescription { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_DiscountCoupon_Description")]
        [StringLength(1024)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the invoice template instance.
        /// </summary>
        /// <value>The invoice template instance.</value>
        [NotMapped]
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Store_InvoiceTemplate")]
        public virtual DocumentTemplate InvoiceTemplateInstance { get; set; }

        /// <summary>
        /// Gets or sets the invoice template.
        /// </summary>
        /// <value>The invoice template.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Store_InvoiceTemplate")]
        [StringLength(80)]
        [SortingField]
        public string InvoiceTemplate { get; set; }

        /// <summary>
        /// Gets or sets the organization identifier.
        /// </summary>
        /// <value>The organization identifier.</value>
        [Required]
        public int? OrganizationId { get; set; }
        /// <summary>
        /// Gets or sets the organization.
        /// </summary>
        /// <value>The organization.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Store_Organization")]
        [SortingField(true, true, false, false, childFieldName: "Name")]
        public virtual Organization Organization { get; set; }

        /// <summary>
        /// Gets or sets the admin user identifier.
        /// </summary>
        /// <value>The admin user identifier.</value>
        [Required]
        public int? AdminUserId { get; set; }
        /// <summary>
        /// Gets or sets the admin user.
        /// </summary>
        /// <value>The admin user.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Store_AdminUser")]
        [SortingField(true, true, false, false, childFieldName: "FirstName")]
        public virtual OrganizationUser AdminUser { get; set; }

        /// <summary>
        /// Gets or sets the billing address identifier.
        /// </summary>
        /// <value>The billing address identifier.</value>
        public int? BillingAddressId { get; set; }
        /// <summary>
        /// Gets or sets the billing address.
        /// </summary>
        /// <value>The billing address.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Store_BillingAddress")]
        public virtual Address BillingAddress { get; set; }

        /// <summary>
        /// Gets or sets the shipping address identifier.
        /// </summary>
        /// <value>The shipping address identifier.</value>
        public int? ShippingAddressId { get; set; }
        /// <summary>
        /// Gets or sets the shipping address.
        /// </summary>
        /// <value>The shipping address.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Store_ShippingAddress")]
        public virtual Address ShippingAddress { get; set; }

        /// <summary>
        /// Gets or sets the store payment options.
        /// </summary>
        /// <value>The store payment options.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Store_StorePaymentOptions")]
        public List<PaymentOption> StorePaymentOptions { get; set; }

        /// <summary>
        /// Gets or sets the store shipping options.
        /// </summary>
        /// <value>The store shipping options.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Store_StoreShippingOptions")]
        public List<ShippingOption> StoreShippingOptions { get; set; }

        /// <summary>
        /// Gets or sets the store product categories.
        /// </summary>
        /// <value>The store product categories.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Store_StoreProductCategories")]
        public List<ProductCategory> StoreProductCategories { get; set; }

        /// <summary>
        /// Gets or sets the store discount coupons.
        /// </summary>
        /// <value>The store discount coupons.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Store_StoreDiscountCoupons")]
        public List<DiscountCoupon> StoreDiscountCoupons { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is default.
        /// </summary>
        /// <value><c>true</c> if this instance is default; otherwise, <c>false</c>.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_DiscountCoupon_IsDefault")]
        [SortingField]
        public bool IsDefault { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is unregistered checkout allowed.
        /// </summary>
        /// <value><c>true</c> if this instance is unregistered checkout allowed; otherwise, <c>false</c>.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Store_IsUnregisteredCheckoutAllowed")]
        [SortingField]
        public bool IsUnregisteredCheckoutAllowed { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [quick shopping cart].
        /// </summary>
        /// <value><c>true</c> if [quick shopping cart]; otherwise, <c>false</c>.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Store_QuickShoppingCart")]
        public bool QuickShoppingCart { get; set; }

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
        /// Gets or sets the state of the entity.
        /// </summary>
        /// <value>The state of the entity.</value>
        [NotMapped]
        public BAPEntityState EntityState { get; set; }
    }
}
