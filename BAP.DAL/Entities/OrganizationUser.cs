// ***********************************************************************
// Assembly         : BAP.DAL
// Author           : Victor Mamray
// Created          : 05-01-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="OrganizationUser.cs" company="BAP Software Ltd.">
//     Copyright © 2015 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using BAP.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BAP.DAL.Entities
{
    /// <summary>
    /// Class OrganizationUser.
    /// Implements the <see cref="BAP.Common.IBapEntity" />
    /// Implements the <see cref="BAP.Common.IFullTextSearchable" />
    /// Implements the <see cref="BAP.Common.IBapEntityWithState" />
    /// </summary>
    /// <seealso cref="BAP.Common.IBapEntity" />
    /// <seealso cref="BAP.Common.IFullTextSearchable" />
    /// <seealso cref="BAP.Common.IBapEntityWithState" />
    [EntityPaging]
    [Table("OrganizationUser")]
    public class OrganizationUser : IBapEntity, IFullTextSearchable, IBapEntityWithState
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
        /// Gets or sets a value indicating whether this instance is built in.
        /// </summary>
        /// <value><c>true</c> if this instance is built in; otherwise, <c>false</c>.</value>
        public bool IsBuiltIn { get; set; } = false;

        /// <summary>
        /// Gets or sets the ASP net user identifier.
        /// </summary>
        /// <value>The ASP net user identifier.</value>
        public string AspNetUserId { get; set; }
        /// <summary>
        /// Gets or sets the organization.
        /// </summary>
        /// <value>The organization.</value>
        public Organization Organization { get; set; }

        /// <summary>
        /// Gets the registered days ago.
        /// </summary>
        /// <value>The registered days ago.</value>
        [NotMapped]
        [CriteriaField]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_OrganizationUser_RegisteredDaysAgo")]
        public double RegisteredDaysAgo
        {
            get
            {
                if (CreateDate.HasValue)
                    return (DateTime.Now - CreateDate.Value).TotalDays;
                else
                    return 0;
            }
        }

        /// <summary>
        /// Date and time when entity was first inserted into system's DB.
        /// </summary>
        /// <value>The create date.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_OrganizationUser_CreateDate")]
        public DateTime? CreateDate { get; set; }

        /// <summary>
        /// Identifier of the user wh created an entity.
        /// </summary>
        /// <value>The created by.</value>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Date and time when entity was last modified.
        /// </summary>
        /// <value>The last modified date.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_OrganizationUser_LastModifiedDate")]
        [SortingField]
        public DateTime? LastModifiedDate { get; set; }

        /// <summary>
        /// Identifier of the user who modified entity last time.
        /// </summary>
        /// <value>The last modified by.</value>
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
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        [Index("IX_OrgUserName", 1, IsUnique = true)]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_OrganizationUser_FirstName")]
        [StringLength(50)]
        [SortingField]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the name of the middle.
        /// </summary>
        /// <value>The name of the middle.</value>
        [Index("IX_OrgUserName", 2, IsUnique = true)]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_OrganizationUser_MiddleName")]
        [StringLength(50)]
        public string MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        [Index("IX_OrgUserName", 3, IsUnique = true)]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_OrganizationUser_LastName")]
        [StringLength(50)]
        [SortingField]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the address line1.
        /// </summary>
        /// <value>The address line1.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_OrganizationUser_AddressLine1")]
        [StringLength(80)]
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Gets or sets the address line2.
        /// </summary>
        /// <value>The address line2.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_OrganizationUser_AddressLine2")]
        [StringLength(80)]
        public string AddressLine2 { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>The city.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_OrganizationUser_City")]
        [StringLength(80)]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the county.
        /// </summary>
        /// <value>The county.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_OrganizationUser_County")]
        [StringLength(80)]
        public string County { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_OrganizationUser_State")]
        [StringLength(80)]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>The country.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_OrganizationUser_Country")]
        [StringLength(80)]
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the zip.
        /// </summary>
        /// <value>The zip.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_OrganizationUser_Zip")]
        [StringLength(5)]
        public string Zip { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>The phone number.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_OrganizationUser_PhoneNumber")]
        [StringLength(20)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the cell number.
        /// </summary>
        /// <value>The cell number.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_OrganizationUser_CellNumber")]
        [StringLength(20)]
        public string CellNumber { get; set; }

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
        /// Bitmask holding data what roles are allowed to access this type of entity.
        /// </summary>
        /// <value>The owner group.</value>
        [Index]
        [DefaultValue(127)]
        public int OwnerGroup { get; set; }
        /// <summary>
        /// Bitmask holding data what types of permissions are allowed over this types of entity.
        /// </summary>
        /// <value>The owner permissions.</value>
        [Index]
        [DefaultValue(310991)]
        public int OwnerPermissions { get; set; }

        /// <summary>
        /// Gets the name of the created by user.
        /// </summary>
        /// <value>The name of the created by user.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_OrganizationUser_CreatedByUserName")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]//[dbo].[ufnGetUserName]([CreatedBy])
        public string CreatedByUserName { get; private set; }

        /// <summary>
        /// Gets the last name of the modified by user.
        /// </summary>
        /// <value>The last name of the modified by user.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_OrganizationUser_LastModifiedByUserName")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]//[dbo].[ufnGetUserName]([LastModifiedBy])
        [SortingField]
        public string LastModifiedByUserName { get; private set; }

        /// <summary>
        /// Gets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_OrganizationUser_UserName")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]//([dbo].[ufnGetUserName]([AspNetUserId]))
        [SortingField(true, true, true)]
        public string UserName { get; private set; }

        /// <summary>
        /// Gets the full name.
        /// </summary>
        /// <value>The full name.</value>
        [NotMapped]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_OrganizationUser_FullName")]
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]//(ISNULL([FirstName], '') + ISNULL(' ' + [MiddleName], '') + ISNULL(' ' + [LastName], ''))
        //[SortingField(true, true, true)]
        [SortingField]
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        /// <summary>
        /// Function to return WHERE expression to search for an entity using part of the text specified.
        /// </summary>
        /// <param name="searchValue">Text to search for</param>
        /// <returns>Linq2Sql expression text to search for a given part of text.</returns>
        public string FullTextSearchExpression(string searchValue)
        {
            return string.Format("(UserName.Contains(\"{0}\") OR FirstName.Contains(\"{0}\") OR LastName.Contains(\"{0}\") OR AddressLine1.Contains(\"{0}\") OR AddressLine2.Contains(\"{0}\") OR City.Contains(\"{0}\") OR County.Contains(\"{0}\") OR State.Contains(\"{0}\") OR Country.Contains(\"{0}\") OR Zip.Contains(\"{0}\") OR PhoneNumber.Contains(\"{0}\"))", searchValue);
        }

        //ASP Net User Properties - unmapped - for runtime only

        //
        // Summary:
        //     Email
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_OrganizationUser_Email")]
        [NotMapped]
        public virtual string Email { get; set; }

        //
        // Summary:
        //     True if the email is confirmed, default is false
        /// <summary>
        /// Gets or sets a value indicating whether [email confirmed].
        /// </summary>
        /// <value><c>true</c> if [email confirmed]; otherwise, <c>false</c>.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_OrganizationUser_EmailConfirmed")]
        [NotMapped]
        public virtual bool EmailConfirmed { get; set; }

        //
        // Summary:
        //     Is two factor enabled for the user
        /// <summary>
        /// Gets or sets a value indicating whether [two factor enabled].
        /// </summary>
        /// <value><c>true</c> if [two factor enabled]; otherwise, <c>false</c>.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_OrganizationUser_TwoFactorEnabled")]
        [NotMapped]
        public virtual bool TwoFactorEnabled { get; set; }

        //
        // Summary:
        //     Is lockout enabled for this user
        /// <summary>
        /// Gets or sets a value indicating whether [lockout enabled].
        /// </summary>
        /// <value><c>true</c> if [lockout enabled]; otherwise, <c>false</c>.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_OrganizationUser_LockoutEnabled")]
        [NotMapped]
        public virtual bool LockoutEnabled { get; set; }
        //
        // Summary:
        //     DateTime in UTC when lockout ends, any time in the past is considered not locked
        //     out.
        /// <summary>
        /// Gets or sets the lockout end date UTC.
        /// </summary>
        /// <value>The lockout end date UTC.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_OrganizationUser_LockoutEndDateUtc")]
        [NotMapped]
        public virtual DateTime? LockoutEndDateUtc { get; set; }

        //
        // Summary:
        //     Used to record failures for the purposes of lockout
        /// <summary>
        /// Gets or sets the access failed count.
        /// </summary>
        /// <value>The access failed count.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_OrganizationUser_AccessFailedCount")]
        [NotMapped]
        public virtual int AccessFailedCount { get; set; }

        //
        //Summary:
        //     Used to hold list of roles user is assigned to
        /// <summary>
        /// Gets or sets the roles.
        /// </summary>
        /// <value>The roles.</value>
        [NotMapped]
        public virtual List<string> Roles { get; set; }
    }
}
