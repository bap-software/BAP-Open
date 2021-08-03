// ***********************************************************************
// Assembly         : BAP.eCommerce.DAL
// Author           : Victor Mamray
// Created          : 05-01-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="ShoppingCart.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
/************************************************************************************************************
ShoppingCart BAP data model entity
Create Date: 1/3/2017 10:12:08 PM
Template Author: Victor (C) 2017
************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using BAP.Common;

using BAP.eCommerce.Resources;
using BAP.DAL.Entities;

namespace BAP.eCommerce.DAL.Entities
{
    /// <summary>
    /// Base class to keep some custom data for the shopping cart and order, can be extended further viia nesting.
    /// </summary>
    public class ShoppingCartCustomData
    {
        /// <summary>
        /// Gets or sets the ship to branch code.
        /// </summary>
        /// <value>
        /// The ship to branch code.
        /// </value>
        public string ShipToBranchCode { get; set; }
        
        /// <summary>
        /// Gets or sets the ship to branch Reference ID.
        /// </summary>
        /// <value>
        /// The ship to branch reference ID (similar to PublicID).
        /// </value>
        public string ShipToBranchReferenceId { get; set; }

        /// <summary>
        /// Gets or sets the ship reference identifier (TTN).
        /// </summary>
        /// <value>
        /// The ship reference identifier.
        /// </value>
        public string ShipReferenceId { get; set; }
    }

    /// <summary>
    /// Class ShoppingCart.
    /// Implements the <see cref="BAP.Common.IBapEntity" />
    /// Implements the <see cref="BAP.Common.IFullTextSearchable" />
    /// Implements the <see cref="BAP.Common.IBapEntityWithState" />
    /// Implements the <see cref="BAP.Common.ITalkingEntity" />
    /// </summary>
    /// <seealso cref="BAP.Common.IBapEntity" />
    /// <seealso cref="BAP.Common.IFullTextSearchable" />
    /// <seealso cref="BAP.Common.IBapEntityWithState" />
    /// <seealso cref="BAP.Common.ITalkingEntity" />
    [EntityPaging]    
    [Table("ShoppingCart")]
    public partial class ShoppingCart : IBapEntity, IFullTextSearchable, IBapEntityWithState, ITalkingEntity, ISupportLocalization
    {
        [NotMapped]
        public string[] LocalizedProperties => new string[] { "PaymentOption", "ShippingOption" };

        /// <summary>
        /// Gets or sets the internal identifier.
        /// </summary>
        /// <value>The internal identifier.</value>
        [NotMapped]
        public Guid InternalId { get; set; } = Guid.NewGuid();

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
        [NotMapped]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        public int? UserId { get; set; }
        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>The user.</value>
        [CriteriaField(isClass: true)]
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ShoppingCart_User")]
        [SortingField(true, true, false, false, childFieldName: "FullName")]
        public OrganizationUser User { get; set; }

        /// <summary>
        /// Gets or sets the currency identifier.
        /// </summary>
        /// <value>The currency identifier.</value>
        [Required]        
        public int? CurrencyId { get; set; }
        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        /// <value>The currency.</value>
        [CriteriaField(isClass:true)]
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ShoppingCart_Currency")]        
        public Currency Currency { get; set;}

        /// <summary>
        /// Gets or sets the shipping option identifier.
        /// </summary>
        /// <value>The shipping option identifier.</value>
        public int? ShippingOptionId { get; set; }
        /// <summary>
        /// Gets or sets the shipping option.
        /// </summary>
        /// <value>The shipping option.</value>
        [CriteriaField(isClass: true)]
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ShoppingCart_ShippingOption")]        
        public ShippingOption ShippingOption { get; set; }

        /// <summary>
        /// Gets or sets the payment option identifier.
        /// </summary>
        /// <value>The payment option identifier.</value>
        public int? PaymentOptionId { get; set; }
        /// <summary>
        /// Gets or sets the payment option.
        /// </summary>
        /// <value>The payment option.</value>
        [CriteriaField(isClass: true)]
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ShoppingCart_PaymentOption")]        
        public PaymentOption PaymentOption { get; set; }

        /// <summary>
        /// Gets or sets the discount coupon identifier.
        /// </summary>
        /// <value>The discount coupon identifier.</value>
        public int? DiscountCouponId { get; set; }
        /// <summary>
        /// Gets or sets the discount coupon.
        /// </summary>
        /// <value>The discount coupon.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ShoppingCart_DscountCoupon")]
        public DiscountCoupon DiscountCoupon { get; set; }

        /// <summary>
        /// Gets or sets the billing address identifier.
        /// </summary>
        /// <value>The billing address identifier.</value>
        public int? BillingAddressId { get; set; }
        /// <summary>
        /// Gets or sets the billing address.
        /// </summary>
        /// <value>The billing address.</value>
        [CriteriaField(isClass: true)]
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ShoppingCart_BillingAddress")]
        [ForeignKey("BillingAddressId")]
        public Address BillingAddress { get; set; }

        /// <summary>
        /// Gets or sets the shipping address identifier.
        /// </summary>
        /// <value>The shipping address identifier.</value>
        public int? ShippingAddressId { get; set; }
        /// <summary>
        /// Gets or sets the shipping address.
        /// </summary>
        /// <value>The shipping address.</value>
        [CriteriaField(isClass: true)]
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ShoppingCart_ShippingAddress")]
        [ForeignKey("ShippingAddressId")]
        public Address ShippingAddress { get; set; }

        /// <summary>
        /// Gets or sets the coupon.
        /// </summary>
        /// <value>The coupon.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ShoppingCart_Coupon")]
        [StringLength(200)]
        public string Coupon { get; set; }

        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>The notes.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ShoppingCart_Notes")]
        [StringLength(1024)]
        public string Notes { get; set; }

        /// <summary>
        /// Gets or sets the custom data.
        /// </summary>
        /// <value>The custom data.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ShoppingCart_CustomData")]
        [StringLength(1024)]
        public string CustomData { get; set; }

        /// <summary>
        /// Gets or sets the subtotal.
        /// </summary>
        /// <value>The subtotal.</value>
        [Required]
        [SortingField]
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ShoppingCart_Subtotal")]        
        public decimal? Subtotal { get; set; }

        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        /// <value>The total.</value>
        [Required]
        [SortingField]
        [CriteriaField]
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ShoppingCart_Total")]
        public decimal? Total { get; set; }

        /// <summary>
        /// Gets or sets the shipping cost.
        /// </summary>
        /// <value>The shipping cost.</value>
        [SortingField]
        [CriteriaField]
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ShoppingCart_ShippingCost")]
        public decimal? ShippingCost { get; set; }

        /// <summary>
        /// Gets or sets the total discounts.
        /// </summary>
        /// <value>The total discounts.</value>
        [SortingField]
        [CriteriaField]
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ShoppingCart_TotalDiscounts")]
        public decimal? TotalDiscounts { get; set; }

        /// <summary>
        /// Gets or sets the tax total.
        /// </summary>
        /// <value>The tax total.</value>
        [SortingField]
        [CriteriaField]
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ShoppingCart_TaxTotal")]
        public decimal? TaxTotal { get; set; }

        /// <summary>
        /// Gets the total weight.
        /// </summary>
        /// <value>The total weight.</value>
        [NotMapped]
        [CriteriaField]
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ShoppingCart_TotalWeight")]
        public decimal TotalWeight
        {
            get
            {
                decimal result = 0;
                if(ShoppingCartProducts != null && ShoppingCartProducts.Count > 0)
                {
                    foreach(var cartProduct in ShoppingCartProducts)
                    {
                        if (cartProduct.Product != null)
                            result += cartProduct.Product.Weight;
                    }
                }
                return result;
            }
        }

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
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ShoppingCart_CreateDate")]
        [SortingField(isDefault: true, isDefaultDesc: true)]
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
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ShoppingCart_LastModifiedDate")]
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
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ShoppingCart_CreatedByUserName")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]//[dbo].[ufnGetUserName]([CreatedBy])
        public string CreatedByUserName { get; private set; }

        /// <summary>
        /// Gets the last name of the modified by user.
        /// </summary>
        /// <value>The last name of the modified by user.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ShoppingCart_LastModifiedByUserName")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]//[dbo].[ufnGetUserName]([LastModifiedBy])
        public string LastModifiedByUserName { get; private set; }
        /// <summary>
        /// Function to return WHERE expression to search for an entity using part of the text specified.
        /// </summary>
        /// <param name="searchValue">Text to search for</param>
        /// <returns>Linq2Sql expression text to search for a given part of text.</returns>
        public string FullTextSearchExpression(string searchValue)
        {
            return string.Format("(User.FirstName.Contains(\"{0}\") OR User.LastName.Contains(\"{0}\") OR User.UserName.Contains(\"{0}\"))", searchValue);
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
        /// Gets or sets the shopping cart products.
        /// </summary>
        /// <value>The shopping cart products.</value>
        [CriteriaField(isArray:true, arrayMemberType:typeof(ShoppingCartProduct))]
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ShoppingCart_ShoppingCartProducts")]
        public List<ShoppingCartProduct> ShoppingCartProducts { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [shipping as billing].
        /// </summary>
        /// <value><c>true</c> if [shipping as billing]; otherwise, <c>false</c>.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ShoppingCart_ShippingAsBilling")]        
        public bool ShippingAsBilling { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [terms and conditions].
        /// </summary>
        /// <value><c>true</c> if [terms and conditions]; otherwise, <c>false</c>.</value>
        [NotMapped]
        public bool TermsAndConditions { get; set; }

        /// <summary>
        /// State of the BAP entity in terms of EF context.
        /// </summary>
        /// <value>The state of the entity.</value>
        [NotMapped]
        public BAPEntityState EntityState { get; set; }

        /// <summary>
        /// The notification message
        /// </summary>
        private string _notificationMessage = "";
        /// <summary>
        /// The message added at
        /// </summary>
        private DateTime _messageAddedAt;
        /// <summary>
        /// Gets a value indicating whether this instance has message.
        /// </summary>
        /// <value><c>true</c> if this instance has message; otherwise, <c>false</c>.</value>
        [NotMapped]
        public bool HasMessage
        {
            get
            {
                return !_notificationMessage.IsNullOrEmpty();
            }
        }

        /// <summary>
        /// Gets the message added at.
        /// </summary>
        /// <value>The message added at.</value>
        [NotMapped]
        public DateTime MessageAddedAt
        {
            get { return _messageAddedAt; }
        }

        /// <summary>
        /// Gets the notification message.
        /// </summary>
        /// <value>The notification message.</value>
        [NotMapped]
        public string NotificationMessage
        {
            get
            {
                return _notificationMessage;
            }
        }

        /// <summary>
        /// Adds the message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void AddMessage(string message)
        {
            _notificationMessage = message;
            _messageAddedAt = DateTime.Now;
        }
    }
}
