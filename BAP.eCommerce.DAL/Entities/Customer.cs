// ***********************************************************************
// Assembly         : BAP.eCommerce.DAL
// Author           : Victor Mamray
// Created          : 04-24-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 07-22-2020
// ***********************************************************************
// <copyright file="Customer.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq;
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
    /// Class Customer.
    /// Implements the <see cref="BAP.Common.IBapEntity" />
    /// Implements the <see cref="BAP.Common.IBapEntityWithState" />
    /// Implements the <see cref="BAP.Common.ISupportsAttachments" />
    /// </summary>
    /// <seealso cref="BAP.Common.IBapEntity" />
    /// <seealso cref="BAP.Common.IBapEntityWithState" />
    /// <seealso cref="BAP.Common.ISupportsAttachments" />
    [EntityPaging]
    [Table("Customer")]
    public partial class Customer : IBapEntity, IBapEntityWithState, ISupportsAttachments
    {
        /// <summary>
        /// Gets or sets the attachments.
        /// </summary>
        /// <value>The attachments.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Generic_Attachments")]
        [NotMapped]
        public IList<Attachment> Attachments { get; set; }

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
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_Customer_Name")]
        [Index("IX_CustomerName", 1, IsUnique = true)]
        [StringLength(80)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the short description.
        /// </summary>
        /// <value>The short description.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_Customer_ShortDescription")]
        [StringLength(256)]
        public string ShortDescription { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_Customer_Description")]
        public string Description { get; set; }

        //Your custom fields are added here
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_Customer_FirstName")]
        [StringLength(50)]
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_Customer_LastName")]
        [StringLength(50)]
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the name of the middle.
        /// </summary>
        /// <value>The name of the middle.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_Customer_MiddleName")]
        [StringLength(50)]
        public string MiddleName { get; set; }


        /// <summary>
        /// Gets or sets the billing address identifier.
        /// </summary>
        /// <value>The billing address identifier.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_Customer_BillingAddressId")]
        public int? BillingAddressId { get; set; }

        /// <summary>
        /// Gets or sets the billing address.
        /// </summary>
        /// <value>The billing address.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_Customer_BillingAddress")]
        [SortingField(true, true, false, false, childFieldName: "Name")]
        public virtual Address BillingAddress { get; set; }

        /// <summary>
        /// Gets or sets the shipping address identifier.
        /// </summary>
        /// <value>The shipping address identifier.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_Customer_ShippingAddressId")]
        public int? ShippingAddressId { get; set; }

        /// <summary>
        /// Gets or sets the shipping address.
        /// </summary>
        /// <value>The shipping address.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_Customer_ShippingAddress")]
        [SortingField(true, true, false, false, childFieldName: "Name")]
        public virtual Address ShippingAddress { get; set; }

        /// <summary>
        /// Gets or sets the company address identifier.
        /// </summary>
        /// <value>The company address identifier.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_Customer_CompanyAddressId")]
        public int? CompanyAddressId { get; set; }
        /// <summary>
        /// Gets or sets the company address.
        /// </summary>
        /// <value>The company address.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_Customer_CompanyAddress")]
        [SortingField(true, true, false, false, childFieldName: "Name")]
        public virtual Address CompanyAddress { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_Customer_Email")]
        [StringLength(200)]
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>The phone number.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_Customer_PhoneNumber")]
        [StringLength(200)]
        [Required]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the phone extension.
        /// </summary>
        /// <value>The phone extension.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_Customer_PhoneExtension")]
        [StringLength(5)]
        public string PhoneExtension { get; set; }

        /// <summary>
        /// Gets or sets the cell number.
        /// </summary>
        /// <value>The cell number.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_Customer_CellNumber")]
        [StringLength(20)]
        public string CellNumber { get; set; }

        /// <summary>
        /// Gets or sets the fax number.
        /// </summary>
        /// <value>The fax number.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_Customer_FaxNumber")]
        [StringLength(20)]
        public string FaxNumber { get; set; }

        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        /// <value>The name of the company.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_Customer_CompanyName")]
        [StringLength(50)]
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the login user identifier.
        /// </summary>
        /// <value>The login user identifier.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_Customer_LoginUserId")]
        public int? LoginUserId { get; set; }

        /// <summary>
        /// Gets or sets the login user.
        /// </summary>
        /// <value>The login user.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_Customer_LoginUser")]
        [SortingField(true, true, false, false, childFieldName: "FullName")]
        public OrganizationUser LoginUser { get; set; }

        /// <summary>
        /// Gets or sets the custom data.
        /// </summary>
        /// <value>The custom data.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_Customer_CustomData")]
        [StringLength(1024)]
        public string CustomData { get; set; }

        /// <summary>
        /// Gets or sets the rating. This is just a number to be saved to DB. Business logic will define its calculation.
        /// </summary>
        /// <value>
        /// The rating.
        /// </value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_Common_Rating")]
        public int Rating { get; set; }

        /// <summary>
        /// Gets the registered days ago.
        /// </summary>
        /// <value>The registered days ago.</value>
        [NotMapped]
        [CriteriaField]
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_Customer_RegisteredDaysAgo")]
        public decimal RegisteredDaysAgo
        {
            get
            {
                if (CreateDate.HasValue)
                    return (decimal)(DateTime.Now - CreateDate.Value).TotalDays;
                else
                    return 0;
            }
        }

        //System fields
        /// <summary>
        /// Type of tenant, currently only Organization is supported.
        /// </summary>
        /// <value>The tenant unit.</value>
        [StringLength(50)]
        [Index("IX_CustomerTenant", 1)]
        public string TenantUnit { get; set; }

        /// <summary>
        /// Tenant identifier, in fact Organization Id for a moment.
        /// </summary>
        /// <value>The tenant unit identifier.</value>
        [Index("IX_CustomerTenant", 2)]
        public int? TenantUnitId { get; set; }

        /// <summary>
        /// Date and time when entity was first inserted into system's DB.
        /// </summary>
        /// <value>The create date.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_Customer_CreateDate")]
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
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_Customer_LastModifiedDate")]
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
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_Customer_CreatedByUserName")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]//[dbo].[ufnGetUserName]([CreatedBy])
        public string CreatedByUserName { get; private set; }

        /// <summary>
        /// Gets the last name of the modified by user.
        /// </summary>
        /// <value>The last name of the modified by user.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_Customer_LastModifiedByUserName")]
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
        /// Gets or sets the customer payments.
        /// </summary>
        /// <value>The customer payments.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Customer_CustomerPayments")]
        public List<CustomerPayment> CustomerPayments { get; set; }

        /// <summary>
        /// Gets or sets the preffered shipping option identifier.
        /// </summary>
        /// <value>The preffered shipping option identifier.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Customer_PrefferedShippingOptionId")]
        public int? PrefferedShippingOptionId { get; set; }
        /// <summary>
        /// Gets or sets the preffered shipping option.
        /// </summary>
        /// <value>The preffered shipping option.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Customer_PrefferedShippingOption")]
        [SortingField(true, true, false, false, childFieldName: "Name")]
        public virtual ShippingOption PrefferedShippingOption { get; set; }

        /// <summary>
        /// Gets or sets the preffered currency identifier.
        /// </summary>
        /// <value>The preffered currency identifier.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_Customer_PrefferedCurrencyId")]
        public int? PrefferedCurrencyId { get; set; }
        /// <summary>
        /// Gets or sets the preffered currency.
        /// </summary>
        /// <value>The preffered currency.</value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_Customer_PrefferedCurrency")]
        [SortingField(true, true, false, false, childFieldName: "Name")]
        public virtual Currency PrefferedCurrency { get; set; }

        /// <summary>
        /// Gets the current payment.
        /// </summary>
        /// <value>The current payment.</value>
        [NotMapped]
        public CustomerPayment CurrentPayment
        {
            get
            {

                if (CustomerPayments == null || CustomerPayments.Count == 0)
                    return null;

                return CustomerPayments.OrderByDescending(a => a.LastUsed).First();
            }
        }
    }
}

