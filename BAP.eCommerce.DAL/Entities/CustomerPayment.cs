// ***********************************************************************
// Assembly         : BAP.eCommerce.DAL
// Author           : Victor Mamray
// Created          : 04-24-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="CustomerPayment.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using BAP.Common;

namespace BAP.eCommerce.DAL.Entities
{
    /// <summary>
    /// Class CustomerPayment.
    /// Implements the <see cref="BAP.Common.IBapEntity" />
    /// Implements the <see cref="BAP.Common.IBapEntityWithState" />
    /// </summary>
    /// <seealso cref="BAP.Common.IBapEntity" />
    /// <seealso cref="BAP.Common.IBapEntityWithState" />
    [EntityPaging]
    [Table("CustomerPayment")]
    public partial class CustomerPayment : IBapEntity, IBapEntityWithState
    {

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
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_CustomerPayment_Name")]
        [Index("IX_CustomerPaymentName", 1, IsUnique = true)]
        [StringLength(80)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the short description.
        /// </summary>
        /// <value>The short description.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_CustomerPayment_ShortDescription")]
        [StringLength(256)]
        public string ShortDescription { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_CustomerPayment_Description")]
        public string Description { get; set; }


        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>The customer identifier.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_CustomerPayment_CustomerId")]
        public int? CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the customer.
        /// </summary>
        /// <value>The customer.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_CustomerPayment_Customer")]
        public Customer Customer { get; set; }

        /// <summary>
        /// Gets or sets the payment option identifier.
        /// </summary>
        /// <value>The payment option identifier.</value>
        [Required]
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_CustomerPayment_PaymentOptionId")]
        public int? PaymentOptionId { get; set; }

        /// <summary>
        /// Gets or sets the payment option.
        /// </summary>
        /// <value>The payment option.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_CustomerPayment_PaymentOption")]
        public PaymentOption PaymentOption { get; set; }

        /// <summary>
        /// Gets or sets the account reference identifier.
        /// </summary>
        /// <value>The account reference identifier.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_CustomerPayment_AccountReferenceId")]
        [StringLength(512)]
        public string AccountReferenceId { get; set; }

        /// <summary>
        /// Gets or sets the last used.
        /// </summary>
        /// <value>The last used.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_CustomerPayment_LastUsed")]
        public DateTime? LastUsed { get; set; }

        //System fields
        /// <summary>
        /// Type of tenant, currently only Organization is supported.
        /// </summary>
        /// <value>The tenant unit.</value>
        [StringLength(50)]
        [Index("IX_CustomerPaymentTenant", 1)]
        public string TenantUnit { get; set; }

        /// <summary>
        /// Tenant identifier, in fact Organization Id for a moment.
        /// </summary>
        /// <value>The tenant unit identifier.</value>
        [Index("IX_CustomerPaymentTenant", 2)]
        public int? TenantUnitId { get; set; }

        /// <summary>
        /// Date and time when entity was first inserted into system's DB.
        /// </summary>
        /// <value>The create date.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_CustomerPayment_CreateDate")]
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
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_CustomerPayment_LastModifiedDate")]
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
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_CustomerPayment_CreatedByUserName")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]//[dbo].[ufnGetUserName]([CreatedBy])
        public string CreatedByUserName { get; private set; }

        /// <summary>
        /// Gets the last name of the modified by user.
        /// </summary>
        /// <value>The last name of the modified by user.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_CustomerPayment_LastModifiedByUserName")]
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

