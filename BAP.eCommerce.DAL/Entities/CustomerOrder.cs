// ***********************************************************************
// Assembly         : BAP.eCommerce.DAL
// Author           : Victor Mamray
// Created          : 07-15-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 07-15-2020
// ***********************************************************************
// <copyright file="CustomerOrder.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using BAP.Common;
using BAP.DAL.Entities;
using BAP.eCommerce.Resources;

namespace BAP.eCommerce.DAL.Entities
{
    /// <summary>
    /// Class CustomerOrder.
    /// Implements the <see cref="BAP.Common.IBapEntity" />
    /// Implements the <see cref="BAP.Common.IFullTextSearchable" />
    /// Implements the <see cref="BAP.Common.IBapEntityWithState" />
    /// Implements the <see cref="BAP.Common.ISupportsAttachments" />
    /// </summary>
    /// <seealso cref="BAP.Common.IBapEntity" />
    /// <seealso cref="BAP.Common.IFullTextSearchable" />
    /// <seealso cref="BAP.Common.IBapEntityWithState" />
    /// <seealso cref="BAP.Common.ISupportsAttachments" />
    [EntityPaging]
    [Table("CustomerOrder")]
    public partial class CustomerOrder : IBapEntity, IFullTextSearchable, IBapEntityWithState, ISupportsAttachments
    {
        /// <summary>
        /// Gets or sets the attachments.
        /// </summary>
        /// <value>The attachments.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Generic_Attachments")]
        [NotMapped]
        public IList<Attachment> Attachments { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerOrder"/> class.
        /// </summary>
        public CustomerOrder()
        {
        }

        /// <summary>
        /// Copy constructor - can be used by ancestors
        /// </summary>
        /// <param name="order">The order.</param>
        protected CustomerOrder(CustomerOrder order)
        {
            this.BillingAddress = order.BillingAddress;
            this.BillingAddressId = order.BillingAddressId;
            this.Coupon = order.Coupon;
            this.CreateDate = order.CreateDate;
            this.CreatedBy = order.CreatedBy;
            this.Currency = order.Currency;
            this.CurrencyId = order.CurrencyId;
            this.CustomData = order.CustomData;
            this.Customer = order.Customer;
            this.CustomerId = order.CustomerId;
            this.CustomerPayment = order.CustomerPayment;
            this.CustomerPaymentId = order.CustomerPaymentId;
            this.Description = order.Description;
            this.DiscountCoupon = order.DiscountCoupon;
            this.DiscountCouponId = order.DiscountCouponId;
            this.DiscountsTotal = order.DiscountsTotal;
            this.Id = order.Id;
            this.Items = order.Items;
            this.LastModifiedBy = order.LastModifiedBy;
            this.LastModifiedDate = order.LastModifiedDate;
            this.Name = order.Name;
            this.Notes = order.Notes;
            this.OwnerGroup = order.OwnerGroup;
            this.OwnerPermissions = order.OwnerPermissions;
            this.PaymentOption = order.PaymentOption;
            this.PaymentOptionId = order.PaymentOptionId;
            this.ShippingAddress = order.ShippingAddress;
            this.ShippingAddressId = order.ShippingAddressId;
            this.ShippingCost = order.ShippingCost;
            this.ShippingOption = order.ShippingOption;
            this.ShippingOptionId = order.ShippingOptionId;
            this.ShippingReferenceId = order.ShippingReferenceId;
            this.OrderDeliveredAt = order.OrderDeliveredAt;
            this.ShipmentInitiatedAt = order.ShipmentInitiatedAt;
            this.ShipmentDeclined = order.ShipmentDeclined;
            this.ShipmentDeclinedAt = order.ShipmentDeclinedAt;
            this.ShortDescription = order.ShortDescription;
            this.Subtotal = order.Subtotal;
            this.TaxTotal = order.TaxTotal;
            this.TenantUnit = order.TenantUnit;
            this.TenantUnitId = order.TenantUnitId;
            this.TimeStamp = order.TimeStamp;
            this.Total = order.Total;
            this.User = order.User;
            this.UserId = order.UserId;
            this.CreatedByUserName = order.CreatedByUserName;
            this.LastModifiedByUserName = order.LastModifiedByUserName;
        }

        /// <summary>
        /// Internal identifier of the entity, also identity field in DB.
        /// </summary>
        /// <value>The identifier.</value>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "E{0:D10}")]
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_CustomerOrder_PublicId")]
        [SortingField(true, true, false, false)]
        public int Id { get; set; }


        /// <summary>
        /// Name of the entity, in most of the cases it has to be unique within given tenant scope.
        /// </summary>
        /// <value>The name.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_CustomerOrder_Name")]
        [Index("IX_CustomerOrderName", 1, IsUnique = true)]
        [StringLength(80)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the short description.
        /// </summary>
        /// <value>The short description.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_CustomerOrder_ShortDescription")]
        [StringLength(256)]
        public string ShortDescription { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_CustomerOrder_Description")]
        public string Description { get; set; }

        //Your custom fields are added here
        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>The customer identifier.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_CustomerOrder_CustomerId")]        
        public int? CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the customer.
        /// </summary>
        /// <value>The customer.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_CustomerOrder_Customer")]
        [SortingField(true, true, false, false, childFieldName: "Name")]
        public Customer Customer { get; set; }

        /// <summary>
        /// Gets or sets the customer payment identifier.
        /// </summary>
        /// <value>The customer payment identifier.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_CustomerOrder_CustomerPaymentId")]
        public int? CustomerPaymentId { get; set; }

        /// <summary>
        /// Gets or sets the customer payment.
        /// </summary>
        /// <value>The customer payment.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_CustomerOrder_CustomerPayment")]
        public CustomerPayment CustomerPayment { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_CustomerOrder_UserId")]
        public int? UserId { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>The user.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_CustomerOrder_User")]
        public OrganizationUser User { get; set; }

        /// <summary>
        /// Gets or sets the currency identifier.
        /// </summary>
        /// <value>The currency identifier.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_CustomerOrder_CurrencyId")]
        [Required]
        public int? CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        /// <value>The currency.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_CustomerOrder_Currency")]
        public Currency Currency { get; set; }

        /// <summary>
        /// Gets or sets the shipping option identifier.
        /// </summary>
        /// <value>The shipping option identifier.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_CustomerOrder_ShippingOptionId")]
        public int? ShippingOptionId { get; set; }

        /// <summary>
        /// Gets or sets the shipping reference identifier.
        /// </summary>
        /// <value>The shipping reference identifier.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_CustomerOrder_ShippingReferenceId")]
        public string ShippingReferenceId { get; set; }

        /// <summary>
        /// Gets or sets the shipment initiated at.
        /// </summary>
        /// <value>The shipment initiated at.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_CustomerOrder_ShipmentInitiatedAt")]
        public DateTime? ShipmentInitiatedAt { get; set; }

        /// <summary>
        /// Gets or sets the order delivered at.
        /// </summary>
        /// <value>The order delivered at.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_CustomerOrder_OrderDeliveredAt")]
        public DateTime? OrderDeliveredAt { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [shipment declined].
        /// </summary>
        /// <value><c>null</c> if [shipment declined] contains no value, <c>true</c> if [shipment declined]; otherwise, <c>false</c>.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_CustomerOrder_ShipmentDeclined")]
        public bool? ShipmentDeclined { get; set; }

        /// <summary>
        /// Gets or sets the shipment declined at.
        /// </summary>
        /// <value>The shipment declined at.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_CustomerOrder_ShipmentDeclinedAt")]
        public DateTime? ShipmentDeclinedAt { get; set; }

        /// <summary>
        /// Gets or sets the shipping option.
        /// </summary>
        /// <value>The shipping option.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_CustomerOrder_ShippingOption")]
        public ShippingOption ShippingOption { get; set; }

        /// <summary>
        /// Gets or sets the payment option identifier.
        /// </summary>
        /// <value>The payment option identifier.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_CustomerOrder_PaymentOptionId")]
        public int? PaymentOptionId { get; set; }

        /// <summary>
        /// Gets or sets the payment option.
        /// </summary>
        /// <value>The payment option.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_CustomerOrder_PaymentOption")]
        [SortingField(true, true, false, false, childFieldName: "Name")]
        public PaymentOption PaymentOption { get; set; }

        /// <summary>
        /// Gets or sets the discount coupon identifier.
        /// </summary>
        /// <value>The discount coupon identifier.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_CustomerOrder_DiscountCouponId")]
        public int? DiscountCouponId { get; set; }

        /// <summary>
        /// Gets or sets the discount coupon.
        /// </summary>
        /// <value>The discount coupon.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_CustomerOrder_DiscountCoupon")]
        public DiscountCoupon DiscountCoupon { get; set; }

        /// <summary>
        /// Gets or sets the billing address identifier.
        /// </summary>
        /// <value>The billing address identifier.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_CustomerOrder_BillingAddressId")]
        public int? BillingAddressId { get; set; }

        /// <summary>
        /// Gets or sets the billing address.
        /// </summary>
        /// <value>The billing address.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_CustomerOrder_BillingAddress")]
        public Address BillingAddress { get; set; }

        /// <summary>
        /// Gets or sets the shipping address identifier.
        /// </summary>
        /// <value>The shipping address identifier.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_CustomerOrder_ShippingAddressId")]
        public int? ShippingAddressId { get; set; }

        /// <summary>
        /// Gets or sets the shipping address.
        /// </summary>
        /// <value>The shipping address.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_CustomerOrder_ShippingAddress")]
        public Address ShippingAddress { get; set; }

        /// <summary>
        /// Gets or sets the coupon.
        /// </summary>
        /// <value>The coupon.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_CustomerOrder_Coupon")]
        [StringLength(200)]
        public string Coupon { get; set; }

        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>The notes.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_CustomerOrder_Notes")]
        [StringLength(1024)]
        public string Notes { get; set; }

        /// <summary>
        /// Gets or sets the custom data.
        /// </summary>
        /// <value>The custom data.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_CustomerOrder_CustomData")]
        [StringLength(1024)]
        public string CustomData { get; set; }

        /// <summary>
        /// Gets or sets the subtotal.
        /// </summary>
        /// <value>The subtotal.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_CustomerOrder_Subtotal")]
        [SortingField(true, true, false, false)]
        [Required]
        public decimal Subtotal { get; set; }

        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        /// <value>The total.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_CustomerOrder_Total")]
        [SortingField(true, true, false, false)]
        [Required]
        public decimal Total { get; set; }

        /// <summary>
        /// Gets or sets the discounts total.
        /// </summary>
        /// <value>The discounts total.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_CustomerOrder_DiscountsTotal")]
        [SortingField(true, true, false, false)]
        public decimal DiscountsTotal { get; set; }

        /// <summary>
        /// Gets or sets the shipping cost.
        /// </summary>
        /// <value>The shipping cost.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_CustomerOrder_ShippingCost")]
        [SortingField(true, true, false, false)]
        public decimal ShippingCost { get; set; }

        /// <summary>
        /// Gets or sets the tax total.
        /// </summary>
        /// <value>The tax total.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_CustomerOrder_TaxTotal")]
        [SortingField(true, true, false, false)]
        public decimal TaxTotal { get; set; }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>The items.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_CustomerOrder_Items")]
        public List<OrderItem> Items { get; set; }



        //System fields
        /// <summary>
        /// Type of tenant, currently only Organization is supported.
        /// </summary>
        /// <value>The tenant unit.</value>
        [StringLength(50)]
        [Index("IX_CustomerOrderTenant", 1)]
        public string TenantUnit { get; set; }

        /// <summary>
        /// Tenant identifier, in fact Organization Id for a moment.
        /// </summary>
        /// <value>The tenant unit identifier.</value>
        [Index("IX_CustomerOrderTenant", 2)]
        public int? TenantUnitId { get; set; }

        /// <summary>
        /// Date and time when entity was first inserted into system's DB.
        /// </summary>
        /// <value>The create date.</value>
        [SortingField(true, true, true, true)]
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_CustomerOrder_CreateDate")]
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
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_CustomerOrder_LastModifiedDate")]
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
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_CustomerOrder_CreatedByUserName")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]//[dbo].[ufnGetUserName]([CreatedBy])
        public string CreatedByUserName { get; private set; }

        /// <summary>
        /// Gets the last name of the modified by user.
        /// </summary>
        /// <value>The last name of the modified by user.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_CustomerOrder_LastModifiedByUserName")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]//[dbo].[ufnGetUserName]([LastModifiedBy])
        public string LastModifiedByUserName { get; private set; }
        /// <summary>
        /// Function to return WHERE expression to search for an entity using part of the text specified.
        /// </summary>
        /// <param name="searchValue">Text to search for</param>
        /// <returns>Linq2Sql expression text to search for a given part of text.</returns>
        public string FullTextSearchExpression(string searchValue)
        {
            return string.Format("(Name.Contains(\"{0}\") OR Customer.Name.Contains(\"{0}\") OR Notes.Contains(\"{0}\") OR User.FirstName.Contains(\"{0}\") OR User.LastName.Contains(\"{0}\") OR BillingAddress.AddressLine1.Contains(\"{0}\") OR BillingAddress.AddressLine2.Contains(\"{0}\") OR BillingAddress.City.Contains(\"{0}\") OR BillingAddress.State.Contains(\"{0}\") OR BillingAddress.County.Contains(\"{0}\") OR BillingAddress.Country.Contains(\"{0}\") OR BillingAddress.Zip.Contains(\"{0}\") OR PaymentOption.Name.Contains(\"{0}\"))", searchValue);
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
        [DefaultValue(1851007)]
        [Required]
        public int OwnerPermissions { get; set; }

        /// <summary>
        /// Gets or sets the payments.
        /// </summary>
        /// <value>The payments.</value>
        [NotMapped]
        public List<CustomerOrderPayment> Payments { get; set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="CustomerOrder"/> is paid.
        /// </summary>
        /// <value><c>null</c> if [paid] contains no value, <c>true</c> if [paid]; otherwise, <c>false</c>.</value>
        [NotMapped]
        public bool? Paid
        {
            get
            {
                bool? result = null;
                if(Payments != null && Payments.Any())
                {
                    result = Payments.Sum(a => a.Total) == Total;
                }
                return result;
            }
        }
        /// <summary>
        /// Gets or sets the state of the entity.
        /// </summary>
        /// <value>The state of the entity.</value>
        [NotMapped]
        public BAPEntityState EntityState { get; set; }
    }
}

