// ***********************************************************************
// Assembly         : BAP.eCommerce.DAL
// Author           : Victor Mamray
// Created          : 04-24-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="CustomerOrderPayment.cs" company="BAP Software Ltd.">
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
    /// Enum PaymentStatus
    /// </summary>
    public enum PaymentStatus
    {
        /// <summary>
        /// The none
        /// </summary>
        none = 0,
        /// <summary>
        /// The created
        /// </summary>
        created,
        /// <summary>
        /// The approved
        /// </summary>
        approved,
        /// <summary>
        /// The failed
        /// </summary>
        failed
    }

    /// <summary>
    /// Enum PaymentIntent
    /// </summary>
    public enum PaymentIntent
    {
        /// <summary>
        /// The none
        /// </summary>
        none = 0,
        /// <summary>
        /// The sale
        /// </summary>
        sale,
        /// <summary>
        /// The authorize
        /// </summary>
        authorize,
        /// <summary>
        /// The order
        /// </summary>
        order,
        /// <summary>
        /// The retry
        /// </summary>
        retry
    }

    /// <summary>
    /// Class CustomerOrderPayment.
    /// Implements the <see cref="BAP.Common.IBapEntity" />
    /// Implements the <see cref="BAP.Common.IBapEntityWithState" />
    /// </summary>
    /// <seealso cref="BAP.Common.IBapEntity" />
    /// <seealso cref="BAP.Common.IBapEntityWithState" />
    [EntityPaging]
    [Table("CustomerOrderPayment")]
    public partial class CustomerOrderPayment : IBapEntity, IBapEntityWithState
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
        /// Gets or sets the reference identifier.
        /// </summary>
        /// <value>The reference identifier.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_CustomerOrderPayment_ReferenceId")]
        [StringLength(512)]
        public string ReferenceId { get; set; }

        /// <summary>
        /// Gets or sets the customer order identifier.
        /// </summary>
        /// <value>The customer order identifier.</value>
        public int? CustomerOrderId { get; set; }

        /// <summary>
        /// Gets or sets the customer order.
        /// </summary>
        /// <value>The customer order.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_CustomerOrderPayment_CustomerOrder")]
        public CustomerOrder CustomerOrder { get; set; }

        /// <summary>
        /// Gets or sets the payment option identifier.
        /// </summary>
        /// <value>The payment option identifier.</value>
        [Required]
        public int? PaymentOptionId { get; set; }

        /// <summary>
        /// Gets or sets the payment option.
        /// </summary>
        /// <value>The payment option.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_CustomerOrderPayment_PaymentOption")]
        public PaymentOption PaymentOption { get; set; }

        /// <summary>
        /// Gets or sets the customer payment identifier.
        /// </summary>
        /// <value>The customer payment identifier.</value>
        public int? CustomerPaymentId { get; set; }

        /// <summary>
        /// Gets or sets the customer payment.
        /// </summary>
        /// <value>The customer payment.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_CustomerOrderPayment_CustomerPayment")]
        public CustomerPayment CustomerPayment { get; set; }

        /// <summary>
        /// Gets or sets the payment status.
        /// </summary>
        /// <value>The payment status.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_CustomerOrderPayment_PaymentStatus")]
        [Required]
        public PaymentStatus PaymentStatus { get; set; }

        /// <summary>
        /// Gets or sets the attempt no.
        /// </summary>
        /// <value>The attempt no.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_CustomerOrderPayment_AttemptNo")]
        public int AttemptNo { get; set; }

        /// <summary>
        /// Gets or sets the started.
        /// </summary>
        /// <value>The started.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_CustomerOrderPayment_Started")]
        [Required]
        public DateTime Started { get; set; }

        /// <summary>
        /// Gets or sets the finished.
        /// </summary>
        /// <value>The finished.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_CustomerOrderPayment_Finished")]
        [Required]
        public DateTime Finished { get; set; }

        /// <summary>
        /// Gets or sets the payment intent.
        /// </summary>
        /// <value>The payment intent.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_CustomerOrderPayment_PaymentIntent")]
        public PaymentIntent PaymentIntent { get; set; }

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
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_CustomerOrderPayment_Currency")]
        public Currency Currency { get; set; }

        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        /// <value>The total.</value>
        [Required]
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_CustomerOrderPayment_Total")]
        public decimal Total { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is error.
        /// </summary>
        /// <value><c>true</c> if this instance is error; otherwise, <c>false</c>.</value>
        [Required]
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_CustomerOrderPayment_IsError")]
        public bool IsError { get; set; }

        /// <summary>
        /// Gets or sets the error code.
        /// </summary>
        /// <value>The error code.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_CustomerOrderPayment_ErrorCode")]
        [StringLength(40)]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Gets or sets the error description.
        /// </summary>
        /// <value>The error description.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_CustomerOrderPayment_ErrorDescription")]
        [StringLength(512)]
        public string ErrorDescription { get; set; }

        /// <summary>
        /// Gets or sets the payment notes.
        /// </summary>
        /// <value>The payment notes.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_CustomerOrderPayment_PaymentNotes")]
        [StringLength(256)]
        public string PaymentNotes { get; set; }

        //System fields
        /// <summary>
        /// Type of tenant, currently only Organization is supported.
        /// </summary>
        /// <value>The tenant unit.</value>
        [StringLength(50)]
        [Index("IX_CustomerOrderPaymentTenant", 1)]
        public string TenantUnit { get; set; }

        /// <summary>
        /// Tenant identifier, in fact Organization Id for a moment.
        /// </summary>
        /// <value>The tenant unit identifier.</value>
        [Index("IX_CustomerOrderPaymentTenant", 2)]
        public int? TenantUnitId { get; set; }

        /// <summary>
        /// Date and time when entity was first inserted into system's DB.
        /// </summary>
        /// <value>The create date.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_CustomerOrderPayment_CreateDate")]
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
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_CustomerOrderPayment_LastModifiedDate")]
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
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_CustomerOrderPayment_CreatedByUserName")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]//[dbo].[ufnGetUserName]([CreatedBy])
        public string CreatedByUserName { get; private set; }

        /// <summary>
        /// Gets the last name of the modified by user.
        /// </summary>
        /// <value>The last name of the modified by user.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_CustomerOrderPayment_LastModifiedByUserName")]
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
        [DefaultValue(1851007)]
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
