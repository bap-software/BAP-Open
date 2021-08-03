// ***********************************************************************
// Assembly         : BAP.DAL
// Author           : Victor Mamray
// Created          : 06-19-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-19-2020
// ***********************************************************************
// <copyright file="Attachment.cs" company="BAP Software Ltd.">
//     Copyright © 2015 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
/************************************************************************************************************
Attachment - data model entity for the given project BAP
Create Date: 6/6/2016 11:33:57 AM
Template Author: Victor Mamray (C) 2016
************************************************************************************************************/
using System;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using BAP.Common;

namespace BAP.DAL.Entities
{
    /// <summary>
    /// Enum AttachmentType
    /// </summary>
    public enum AttachmentType
    {
        /// <summary>
        /// The none
        /// </summary>
        None = 0,
        /// <summary>
        /// The photo
        /// </summary>
        Photo,
        /// <summary>
        /// The picture
        /// </summary>
        Picture,
        /// <summary>
        /// The PDF
        /// </summary>
        Pdf,
        /// <summary>
        /// The json
        /// </summary>
        Json,
        /// <summary>
        /// The word
        /// </summary>
        Word,
        /// <summary>
        /// The excel
        /// </summary>
        Excel,
        /// <summary>
        /// The text
        /// </summary>
        Text,
        /// <summary>
        /// The archive
        /// </summary>
        Archive,
        /// <summary>
        /// The icon
        /// </summary>
        Icon,
        /// <summary>
        /// The executable
        /// </summary>
        Executable,
        /// <summary>
        /// The installation
        /// </summary>
        Installation,
        /// <summary>
        /// The file
        /// </summary>
        File
    }

    /// <summary>
    /// Attachment entity, used to describe any kind of file-based attachment to any kind of BAP entity.
    /// Attachment has history, it can be published for limited amount of time (application should take care of that).
    /// AAAttachment can be also secured, where access is provided to a limited set of roles OR by public access token.
    /// </summary>
    [EntityPaging(pageSize: 10)]    
    [Table("Attachment")]
    public partial class Attachment : IBapEntity, IFullTextSearchable, IBapEntityWithState
    {
        /// <summary>
        /// Application level property, indicates whether attachment is manipulated from the parent object page.
        /// </summary>
        /// <value><c>true</c> if this instance is external update; otherwise, <c>false</c>.</value>
        [NotMapped]
        public bool IsExternalUpdate { get; set; }

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
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Attachment_Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Name of the entity, in most of the cases it has to be unique within given tenant scope.
        /// </summary>
        /// <value>The name.</value>
        [Index("IX_AttachmentNameObect", 1, IsUnique = true)]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Attachment_Name")]
        [StringLength(255)]
        [SortingField(true, true, true, false)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Attachment_Description")]
        [StringLength(1024)]
        public string Description { get; set; }


        /// <summary>
        /// Gets or sets the type of the attachment.
        /// </summary>
        /// <value>The type of the attachment.</value>
        [Index("IX_AttachmentNameObect", 2, IsUnique = true)]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Attachment_AttachmentType")]
        [StringLength(255)]
        [SortingField]
        public string AttachmentType { get; set; }

        /// <summary>
        /// Gets the attachment type classified.
        /// </summary>
        /// <value>The attachment type classified.</value>
        [NotMapped]
        public AttachmentType AttachmentTypeClassified { 
            get
            {
                AttachmentType result;
                Enum.TryParse(AttachmentType, true, out result);
                return result;
            } 
        }

        /// <summary>
        /// Gets or sets the object.
        /// </summary>
        /// <value>The object.</value>
        [Index("IX_AttachmentNameObect", 3, IsUnique = true)]
        [StringLength(255)]
        public string Object { get; set; }

        /// <summary>
        /// Gets or sets the object identifier.
        /// </summary>
        /// <value>The object identifier.</value>
        [Index("IX_AttachmentNameObect", 4, IsUnique = true)]
        public int ObjectId { get; set; }

        /// <summary>
        /// Gets or sets the path URL.
        /// </summary>
        /// <value>The path URL.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Attachment_PathUrl")]
        [StringLength(255)]
        [SortingField]
        public string PathUrl { get; set; }

        /// <summary>
        /// Gets or sets the file.
        /// </summary>
        /// <value>The file.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Attachment_File")]
        [NotMapped]        
        public HttpPostedFileBase File { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Attachment_Status")]
        [StringLength(80)]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the status date.
        /// </summary>
        /// <value>The status date.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Attachment_StatusDate")]
        public DateTime StatusDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Attachment"/> is published.
        /// </summary>
        /// <value><c>null</c> if [published] contains no value, <c>true</c> if [published]; otherwise, <c>false</c>.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Attachment_Published")]
        public bool? Published { get; set; }

        /// <summary>
        /// Gets or sets the publish from.
        /// </summary>
        /// <value>The publish from.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Attachment_PublishFrom")]
        public DateTime? PublishFrom { get; set; }

        /// <summary>
        /// Gets or sets the publish to.
        /// </summary>
        /// <value>The publish to.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Attachment_PublishTo")]
        public DateTime? PublishTo { get; set; }

        /// <summary>
        /// Gets or sets the type of the MIME.
        /// </summary>
        /// <value>The type of the MIME.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Attachment_MimeType")]
        [StringLength(255)]
        public string MimeType { get; set; }

        /// <summary>
        /// Gets or sets the path aliases.
        /// </summary>
        /// <value>The path aliases.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Attachment_PathAliases")]        
        public string PathAliases { get; set; }

        /// <summary>
        /// Gets or sets the alt text.
        /// </summary>
        /// <value>The alt text.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Attachment_AltText")]
        [StringLength(255)]
        public string AltText { get; set; }

        /// <summary>
        /// Gets or sets the title text.
        /// </summary>
        /// <value>The title text.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Attachment_TitleText")]
        [StringLength(255)]
        public string TitleText { get; set; }

        /// <summary>
        /// Gets or sets the keywords.
        /// </summary>
        /// <value>The keywords.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Attachment_Keywords")]
        [StringLength(255)]
        public string Keywords { get; set; }

        /// <summary>
        /// If set to True, attachment has limitted access, to the certain roles or by token
        /// </summary>
        /// <value><c>null</c> if [is secured] contains no value, <c>true</c> if [is secured]; otherwise, <c>false</c>.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Attachment_IsSecured")]
        public bool? IsSecured { get; set; }

        /// <summary>
        /// Coma-separated list of roles attachment is allowed to without conditions. If empty it's assumed it's allowed to Administrators only.
        /// </summary>
        /// <value>The allowed to roles.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Attachment_AllowedToRoles")]
        [StringLength(1024)]
        public string AllowedToRoles { get; set; }

        /// <summary>
        /// Type of tenant, currently only Organization is supported.
        /// </summary>
        /// <value>The tenant unit.</value>
        [StringLength(50)]
        [Index("IX_Tenant", 1)]
        [Index("IX_AttachmentNameObect", 5, IsUnique = true)]
        public string TenantUnit { get; set; }
        /// <summary>
        /// Tenant identifier, in fact Organization Id for a moment.
        /// </summary>
        /// <value>The tenant unit identifier.</value>
        [Index("IX_Tenant", 2)]
        [Index("IX_AttachmentNameObect", 6, IsUnique = true)]
        public int? TenantUnitId { get; set; }

        /// <summary>
        /// Date and time when entity was first inserted into system's DB.
        /// </summary>
        /// <value>The create date.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Attachment_CreateDate")]
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
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Attachment_LastModifiedDate")]
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
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Attachment_CreatedByUserName")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]//[dbo].[ufnGetUserName]([CreatedBy])
        public string CreatedByUserName { get; private set; }

        /// <summary>
        /// Gets the last name of the modified by user.
        /// </summary>
        /// <value>The last name of the modified by user.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Attachment_LastModifiedByUserName")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]//[dbo].[ufnGetUserName]([LastModifiedBy])
        [SortingField]
        public string LastModifiedByUserName { get; private set; }

        /// <summary>
        /// Gets or sets the history.
        /// </summary>
        /// <value>The history.</value>
        public List<AttachmentHistory> History { get; set; }

        /// <summary>
        /// Gets or sets the length.
        /// </summary>
        /// <value>The length.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Attachment_Length")]
        public Int64? Length { get; set; }

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
        [DefaultValue(2072079)]
        public int OwnerPermissions { get; set; }

        /// <summary>
        /// Fulls the text search expression.
        /// </summary>
        /// <param name="searchValue">The search value.</param>
        /// <returns>System.String.</returns>
        public string FullTextSearchExpression(string searchValue)
        {
            return string.Format("(Name.Contains(\"{0}\") OR PathUrl.Contains(\"{0}\") OR AttachmentType.Contains(\"{0}\") OR Status.Contains(\"{0}\"))", searchValue);
        }
    }
}
