// ***********************************************************************
// Assembly         : BAP.eCommerce.DAL
// Author           : Victor Mamray
// Created          : 05-10-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="Address.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
/************************************************************************************************************
Address BAP data model entity
Create Date: 1/12/2017 5:38:20 PM
Template Author: Victor (C) 2017
************************************************************************************************************/
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using BAP.Common;

using BAP.eCommerce.Resources;

namespace BAP.eCommerce.DAL.Entities
{
    /// <summary>
    /// Class Address.
    /// Implements the <see cref="BAP.Common.IBapEntity" />
    /// Implements the <see cref="BAP.Common.IBapEntityWithState" />
    /// </summary>
    /// <seealso cref="BAP.Common.IBapEntity" />
    /// <seealso cref="BAP.Common.IBapEntityWithState" />
    [EntityPaging]
    [Table("Address")]
    public partial class Address : IBapEntity, IBapEntityWithState
    {
        /// <summary>
        /// Internal identifier of the entity, also identity field in DB.
        /// </summary>
        /// <value>The identifier.</value>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Name of the entity, in most of the cases it has to be unique within given tenant scope.
        /// </summary>
        /// <value>The name.</value>
        [Index("IX_AddressName", 1, IsUnique = true)]
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Address_Name")]
        [StringLength(80)]
        [Required]
        [SortingField(true, true, true, false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        /// <value>The name of the company.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Address_CompanyName")]
        [StringLength(256)]
        [SortingField(true, true, true, false)]
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Address_Description")]
        [StringLength(1024)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Address_FirstName")]
        [StringLength(50)]
        [Required]
        [SortingField(true, true, true, false)]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the name of the middle.
        /// </summary>
        /// <value>The name of the middle.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Address_MiddleName")]
        [StringLength(50)]
        public string MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Address_LastName")]
        [StringLength(50)]
        [Required]
        [SortingField(true, true, true, false)]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the address line1.
        /// </summary>
        /// <value>The address line1.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Address_AddressLine1")]
        [StringLength(80)]
        [Required]
        [SortingField(true, true, true, false)]
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Gets or sets the address line2.
        /// </summary>
        /// <value>The address line2.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Address_AddressLine2")]
        [StringLength(80)]
        public string AddressLine2 { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>The city.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Address_City")]
        [StringLength(80)]
        [Required]
        [CriteriaField]
        [SortingField(true, true, true, false)]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the county.
        /// </summary>
        /// <value>The county.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Address_County")]
        [StringLength(80)]
        [SortingField(true, true, true, false)]
        public string County { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Address_State")]
        [StringLength(80)]
        [Required]
        [CriteriaField]
        [SortingField(true, true, true, false)]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>The country.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Address_Country")]
        [StringLength(80)]
        [Required]
        [CriteriaField]
        [SortingField(true, true, true, false)]
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the zip.
        /// </summary>
        /// <value>The zip.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Address_Zip")]
        [StringLength(5)]
        [Required]
        [CriteriaField]
        [SortingField(true, true, true, false)]
        public string Zip { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>The phone number.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Address_PhoneNumber")]
        [StringLength(20)]
        [Phone]
        [Required]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the phone extension.
        /// </summary>
        /// <value>The phone extension.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Address_PhoneExtension")]
        [StringLength(5)]
        public string PhoneExtension { get; set; }

        /// <summary>
        /// Gets or sets the fax number.
        /// </summary>
        /// <value>The fax number.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Address_FaxNumber")]
        [StringLength(20)]
        public string FaxNumber { get; set; }

        /// <summary>
        /// Gets or sets the cell number.
        /// </summary>
        /// <value>The cell number.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Address_CellNumber")]
        [StringLength(20)]
        public string CellNumber { get; set; }

        /// <summary>
        /// Gets or sets the contact email.
        /// </summary>
        /// <value>The contact email.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Address_ContactEmail")]
        [StringLength(255)]
        [Required]
        [SortingField(true, true, true, false)]
        [EmailAddress]
        public string ContactEmail { get; set; }

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
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Address_CreateDate")]
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
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Address_LastModifiedDate")]
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
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Address_CreatedByUserName")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]//[dbo].[ufnGetUserName]([CreatedBy])
        public string CreatedByUserName { get; private set; }

        /// <summary>
        /// Gets the last name of the modified by user.
        /// </summary>
        /// <value>The last name of the modified by user.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Address_LastModifiedByUserName")]
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
        /// Gets the full name.
        /// </summary>
        /// <value>The full name.</value>
        [NotMapped]
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName} {AddressLine1} {City} {State} {Zip} {Country}";
            }
        }
        
        /// <summary>
        /// Gets the full name.
        /// </summary>
        /// <value>The full name.</value>
        [NotMapped]
        public string RecipientFullName
        {
            get
            {
                var whiteSpaceRegex = new Regex("\\s{2,}");
                return whiteSpaceRegex.Replace($"{FirstName} {MiddleName} {LastName}", string.Empty);
            }
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
        [DefaultValue(1850975)]
        [Required]
        public int OwnerPermissions { get; set; }

        /// <summary>
        /// State of the BAP entity in terms of EF context.
        /// </summary>
        /// <value>The state of the entity.</value>
        [NotMapped]
        public BAPEntityState EntityState { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="Address"/> class.
        /// </summary>
        public Address()
        {
            Name = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Address"/> class.
        /// </summary>
        /// <param name="copy">The copy.</param>
        public Address(Address copy)
        {
            Copy(copy);
        }

        /// <summary>
        /// Copies the specified copy.
        /// </summary>
        /// <param name="copy">The copy.</param>
        public Address Copy(Address copy)
        {
            var uniqueSuffix = Guid.NewGuid().ToString();
            this.CompanyName = copy.CompanyName;
            this.AddressLine1 = copy.AddressLine1;
            this.AddressLine2 = copy.AddressLine2;
            this.CellNumber = copy.CellNumber;
            this.City = copy.City;
            this.ContactEmail = copy.ContactEmail;
            this.Country = copy.Country;
            this.County = copy.County;
            this.Description = copy.Description;
            this.FaxNumber = copy.FaxNumber;
            this.FirstName = copy.FirstName;
            this.LastName = copy.LastName;
            this.MiddleName = copy.MiddleName;
            this.Name = copy.FirstName + " " + copy.MiddleName + " " + copy.LastName + " " + copy.Zip + " " + uniqueSuffix;
            this.OwnerGroup = copy.OwnerGroup;
            this.OwnerPermissions = copy.OwnerPermissions;
            this.PhoneExtension = copy.PhoneExtension;
            this.PhoneNumber = copy.PhoneNumber;
            this.State = copy.State;
            this.TenantUnit = copy.TenantUnit;
            this.TenantUnitId = copy.TenantUnitId;
            this.Zip = copy.Zip;

            return this;
        }

        /// <summary>
        /// Determines whether this instance is empty.
        /// </summary>
        /// <returns><c>true</c> if this instance is empty; otherwise, <c>false</c>.</returns>
        public bool IsEmpty()
        {
            return (CompanyName.IsNullOrEmpty() && AddressLine1.IsNullOrEmpty() && AddressLine2.IsNullOrEmpty() && CellNumber.IsNullOrEmpty() && City.IsNullOrEmpty() && ContactEmail.IsNullOrEmpty()
                && Country.IsNullOrEmpty() && County.IsNullOrEmpty() && FaxNumber.IsNullOrEmpty() && FirstName.IsNullOrEmpty() && LastName.IsNullOrEmpty() && MiddleName.IsNullOrEmpty() && PhoneExtension.IsNullOrEmpty()
                && PhoneNumber.IsNullOrEmpty() && State.IsNullOrEmpty() && Zip.IsNullOrEmpty());
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (!(obj is Address))
                return false;
            Address b = (Address)obj;
            Address a = this;
            return a != null && b != null && a.AddressLine1 == b.AddressLine1 && a.AddressLine2 == b.AddressLine2 && a.CellNumber == b.CellNumber
                && a.City == b.City && a.ContactEmail == b.ContactEmail && a.Country == b.Country && a.County == b.County && a.FaxNumber == b.FaxNumber
                && a.FirstName == b.FirstName && a.LastName == b.LastName && a.MiddleName == b.MiddleName && a.PhoneExtension == b.PhoneExtension
                && a.PhoneNumber == b.PhoneNumber && a.State == b.State && a.Zip == b.Zip;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            int hash = 13;
            hash = (hash * 7) + AddressLine1.GetHashCode();
            hash = (hash * 7) + AddressLine2.GetHashCode();
            hash = (hash * 7) + City.GetHashCode();
            hash = (hash * 7) + State.GetHashCode();
            hash = (hash * 7) + County.GetHashCode();
            hash = (hash * 7) + Country.GetHashCode();
            hash = (hash * 7) + Zip.GetHashCode();
            hash = (hash * 7) + ContactEmail.GetHashCode();
            hash = (hash * 7) + CellNumber.GetHashCode();
            hash = (hash * 7) + PhoneNumber.GetHashCode();
            hash = (hash * 7) + PhoneExtension.GetHashCode();
            hash = (hash * 7) + FirstName.GetHashCode();
            hash = (hash * 7) + MiddleName.GetHashCode();
            hash = (hash * 7) + LastName.GetHashCode();
            hash = (hash * 7) + FaxNumber.GetHashCode();
            return hash;
        }
    }
}
