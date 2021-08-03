// ***********************************************************************
// Assembly         : BAP.DAL
// Author           : Victor Mamray
// Created          : 08-11-2016
//
// Last Modified By : Victor Mamray
// Last Modified On : 07-22-2020
// ***********************************************************************
// <copyright file="Subscription.cs" company="BAP Software Ltd.">
//     Copyright © 2015 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using BAP.Common;
using System.ComponentModel;

namespace BAP.DAL.Entities
{
    /// <summary>
    /// Class Subscription.
    /// Implements the <see cref="BAP.Common.IBapEntity" />
    /// Implements the <see cref="BAP.Common.IBapEntityWithState" />
    /// </summary>
    /// <seealso cref="BAP.Common.IBapEntity" />
    /// <seealso cref="BAP.Common.IBapEntityWithState" />
    [EntityPaging]
    [Table("Subscription")]
    public partial class Subscription : IBapEntity, IBapEntityWithState
    {
        /// <summary>
        /// Name of the entity, in most of the cases it has to be unique within given tenant scope.
        /// </summary>
        /// <value>The name.</value>
        [NotMapped]
        public string Name { get; set; }


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
        /// Gets or sets the type of the subscription.
        /// </summary>
        /// <value>The type of the subscription.</value>
        [StringLength(20)]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Subscription_SubscriptionType")]
        [SortingField]
        public string SubscriptionType { get; set; }

        /// <summary>
        /// Gets or sets the organization identifier.
        /// </summary>
        /// <value>The organization identifier.</value>
        public int? OrganizationId { get; set; }
        /// <summary>
        /// Gets or sets the organization.
        /// </summary>
        /// <value>The organization.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Subscription_Organization")]
        public virtual Organization Organization { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        public int? UserId { get; set; }
        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>The user.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Subscription_User")]
        [SortingField(true, true, false, false, childFieldName: "FirstName")]
        public virtual OrganizationUser User { get; set; }

        /// <summary>
        /// Gets or sets the object.
        /// </summary>
        /// <value>The object.</value>
        [StringLength(255)]
        public string Object { get; set; }

        /// <summary>
        /// Gets or sets the object identifier.
        /// </summary>
        /// <value>The object identifier.</value>
        public int ObjectId { get; set; }

        /// <summary>
        /// Gets or sets the initial term.
        /// </summary>
        /// <value>The initial term.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Subscription_InitialTerm")]
        [SortingField]
        public int InitialTerm { get; set; }

        /// <summary>
        /// Gets or sets the term start.
        /// </summary>
        /// <value>The term start.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Subscription_TermStart")]
        [SortingField]
        public DateTime TermStart { get; set; }

        /// <summary>
        /// Gets or sets the term end.
        /// </summary>
        /// <value>The term end.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Subscription_TermEnd")]
        [SortingField]
        public DateTime TermEnd { get; set; }

        /// <summary>
        /// Gets or sets the contract date.
        /// </summary>
        /// <value>The contract date.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Subscription_ContractDate")]
        [SortingField]
        public DateTime ContractDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [automatic renew].
        /// </summary>
        /// <value><c>true</c> if [automatic renew]; otherwise, <c>false</c>.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Subscription_AutoRenew")]
        public bool AutoRenew { get; set; }

        /// <summary>
        /// Gets or sets the renewal term.
        /// </summary>
        /// <value>The renewal term.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Subscription_RenewalTerm")]
        public int RenewalTerm { get; set; }

        /// <summary>
        /// Gets or sets the sub total.
        /// </summary>
        /// <value>The sub total.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Subscription_SubTotal")]
        [DataType("decimal(18,4")]
        [SortingField]
        public decimal? SubTotal { get; set; }

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
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Subscription_CreateDate")]
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
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Subscription_LastModifiedDate")]
        [SortingField]
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
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Subscription_CreatedByUserName")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]//[dbo].[ufnGetUserName]([CreatedBy])
        public string CreatedByUserName { get; private set; }

        /// <summary>
        /// Gets the last name of the modified by user.
        /// </summary>
        /// <value>The last name of the modified by user.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Subscription_LastModifiedByUserName")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]//[dbo].[ufnGetUserName]([LastModifiedBy])
        public string LastModifiedByUserName { get; private set; }

        /// <summary>
        /// Bitmask holding data what roles are allowed to access this type of entity.
        /// </summary>
        /// <value>The owner group.</value>
        [Index]
        [DefaultValue(25)]
        public int OwnerGroup { get; set; }

        /// <summary>
        /// Bitmask holding data what types of permissions are allowed over this types of entity.
        /// </summary>
        /// <value>The owner permissions.</value>
        [Index]
        [DefaultValue(11975)]
        public int OwnerPermissions { get; set; }

        /// <summary>
        /// Gets the user term range.
        /// </summary>
        /// <value>The user term range.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Subscription_TermRange")]
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]//(ISNULL([FirstName], '') + ISNULL(' ' + [MiddleName], '') + ISNULL(' ' + [LastName], ''))
        public string UserTermRange
        {
            get
            {
                return $"{User.FullName} ({TermStart:MM/dd/yyyy}-{TermEnd:MM/dd/yyyy})";
            }
        }
    }
}
