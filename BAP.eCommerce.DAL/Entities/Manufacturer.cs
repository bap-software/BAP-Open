// ***********************************************************************
// Assembly         : BAP.eCommerce.DAL
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="Manufacturer.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
/************************************************************************************************************
Manufacturer BAP data model entity
Create Date: 1/5/2017 10:18:48 PM
Template Author: Victor (C) 2017
************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using BAP.Common;
using BAP.DAL.Entities;
using BAP.eCommerce.Resources;

namespace BAP.eCommerce.DAL.Entities
{
    /// <summary>
    /// Class Manufacturer.
    /// Implements the <see cref="BAP.Common.IBapEntity" />
    /// Implements the <see cref="BAP.Common.IBapEntityWithState" />
    /// Implements the <see cref="BAP.Common.ISupportsAttachments" />
    /// Implements the <see cref="BAP.Common.ISupportLocalization" />
    /// </summary>
    /// <seealso cref="BAP.Common.IBapEntity" />
    /// <seealso cref="BAP.Common.IBapEntityWithState" />
    /// <seealso cref="BAP.Common.ISupportsAttachments" />
    /// <seealso cref="BAP.Common.ISupportLocalization" />
    [EntityPaging]   
    [Table("Manufacturer")]
    public partial class Manufacturer : IBapEntity, IBapEntityWithState, ISupportsAttachments, ISupportLocalization
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
        [Index("IX_ManufacturerName", 1, IsUnique = true)]
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Manufacturer_Name")]
        [StringLength(80)]
        [Required]
        [SortingField(true, true, true, false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the short description.
        /// </summary>
        /// <value>The short description.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Manufacturer_ShortDescription")]
        [StringLength(256)]
        [SortingField(true, true, true, false)]
        public string ShortDescription { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Manufacturer_Description")]
        [StringLength(1024)]
        [SortingField(true, true, true, false)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the logo image.
        /// </summary>
        /// <value>The logo image.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Manufacturer_LogoImage")]
        [StringLength(1024)]
        public string LogoImage { get; set; }

        /// <summary>
        /// Gets or sets the file.
        /// </summary>
        /// <value>The file.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Manufacturer_File")]
        [NotMapped]
        public HttpPostedFileBase File { get; set; }

        /// <summary>
        /// Gets or sets the slogan.
        /// </summary>
        /// <value>The slogan.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Manufacturer_Slogan")]
        [StringLength(80)]
        [SortingField]
        public string Slogan { get; set; }

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
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Manufacturer_CreateDate")]
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
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Manufacturer_LastModifiedDate")]
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
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Manufacturer_CreatedByUserName")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]//[dbo].[ufnGetUserName]([CreatedBy])
        public string CreatedByUserName { get; private set; }

        /// <summary>
        /// Gets the last name of the modified by user.
        /// </summary>
        /// <value>The last name of the modified by user.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Manufacturer_LastModifiedByUserName")]
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
        /// Gets or sets the owner permissions.
        /// </summary>
        /// <value>The owner permissions.</value>
        [Index]
        [DefaultValue(1842895)]
        [Required]
        public int OwnerPermissions { get; set; }
        /// <summary>
        /// Show if no products in the category
        /// </summary>
        /// <value>The owner group.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Manufacturer_ShowIfEmpty")]
        [DefaultValue(false)]
        [Required]
        public bool ShowIfEmpty { get; set; }
        /// <summary>
        /// Show external reference id
        /// </summary>
        /// <value>The show external reference id.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Manufacturer_ExternalReferenceId")]
        public string ExternalReferenceId { get; set; }
    }
}
