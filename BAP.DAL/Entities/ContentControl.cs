// ***********************************************************************
// Assembly         : BAP.DAL
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="ContentControl.cs" company="BAP Software Ltd.">
//     Copyright © 2015 BAP Software Ltd.
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
using BAP.Common;

namespace BAP.DAL.Entities
{
    /// <summary>
    /// Class ContentControl.
    /// Implements the <see cref="BAP.Common.IBapEntity" />
    /// Implements the <see cref="BAP.Common.IBapEntityWithState" />
    /// Implements the <see cref="BAP.Common.IContentComponent" />
    /// Implements the <see cref="BAP.Common.ISupportLocalization" />
    /// </summary>
    /// <seealso cref="BAP.Common.IBapEntity" />
    /// <seealso cref="BAP.Common.IBapEntityWithState" />
    /// <seealso cref="BAP.Common.IContentComponent" />
    /// <seealso cref="BAP.Common.ISupportLocalization" />
    [EntityPaging]
    [Table("ContentControl")]
    public partial class ContentControl : IBapEntity, IBapEntityWithState, IContentComponent, ISupportLocalization
    {
        /// <summary>
        /// To identify culture neutral entity and to gather identical but different by language entities
        /// </summary>
        /// <value>The localized properties.</value>
        [NotMapped]
        public string[] LocalizedProperties => new string[] { "Name", "DisplayName", "Description" };

        /// <summary>
        /// Initializes a new instance of the <see cref="ContentControl"/> class.
        /// </summary>
        public ContentControl()
        {
            Name = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContentControl"/> class.
        /// </summary>
        /// <param name="copy">The copy.</param>
        public ContentControl(ContentControl copy)
        {
            Copy(copy);
        }

        /// <summary>
        /// Copies the specified copy.
        /// </summary>
        /// <param name="copy">The copy.</param>
        public void Copy(ContentControl copy)
        {
            this.Name = copy.Name;
            this.Description = copy.Description;
            this.IsEnabled = copy.IsEnabled;
            this.OwnerGroup = copy.OwnerGroup;
            this.OwnerPermissions = copy.OwnerPermissions;
            this.TenantUnit = copy.TenantUnit;
            this.TenantUnitId = copy.TenantUnitId;

            this.DisplayName = copy.DisplayName;
            this.HasDialog = copy.HasDialog;
            this.HasCKEditor = copy.HasCKEditor;
            this.ContentBefore = copy.ContentBefore;
            this.ContentAfter = copy.ContentAfter;
            this.MainCss = copy.MainCss;
            this.IconCss = copy.IconCss;
            this.ContainerTag = copy.ContainerTag;
            this.DialogContent = copy.DialogContent;
            this.ContentHolderFieldId = copy.ContentHolderFieldId;
            this.JavaScriptContent = copy.JavaScriptContent;
        }

        /// <summary>
        /// Determines whether this instance is empty.
        /// </summary>
        /// <returns><c>true</c> if this instance is empty; otherwise, <c>false</c>.</returns>
        public bool IsEmpty()
        {
            return Name.IsNullOrEmpty() && !IsEnabled;
        }

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
        [Index("IX_ContentControlTypeName", 1, IsUnique = true)]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Generic_Name")]
        [StringLength(80)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Description of the component
        /// </summary>
        /// <value>The description.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Generic_Description")]
        [StringLength(1024)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is enabled.
        /// </summary>
        /// <value><c>true</c> if this instance is enabled; otherwise, <c>false</c>.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Generic_IsEnabled")]
        [Required]
        public bool IsEnabled { get; set; }

        /// <summary>
        /// Gets or sets the content control type identifier.
        /// </summary>
        /// <value>The content control type identifier.</value>
        public int? ContentControlTypeId { get; set; }
        /// <summary>
        /// Gets or sets the type of the content control.
        /// </summary>
        /// <value>The type of the content control.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_ContentControl_Type")]
        public virtual ContentControlType ContentControlType { get; set; }


        /// <summary>
        /// Short name shown on design panel
        /// </summary>
        /// <value>The display name.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Generic_DisplayName")]
        [StringLength(50)]
        public string DisplayName { get; set; }

        /// <summary>
        /// If True, designed will show additonal popup to configure inserted content
        /// </summary>
        /// <value><c>true</c> if this instance has dialog; otherwise, <c>false</c>.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_ContentControl_HasDialog")]
        public bool HasDialog { get; set; }

        /// <summary>
        /// If True, dialog uses CKEditor control for the main input control
        /// </summary>
        /// <value><c>true</c> if this instance has ck editor; otherwise, <c>false</c>.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_ContentControl_HasCKEditor")]
        public bool HasCKEditor { get; set; }

        /// <summary>
        /// If specified, will be placed before main content on the page
        /// </summary>
        /// <value>The content before.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_ContentControl_ContentBefore")]
        [StringLength(1024)]
        public string ContentBefore { get; set; }

        /// <summary>
        /// If specified, will be placed after the main content on the page
        /// </summary>
        /// <value>The content after.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_ContentControl_ContentAfter")]
        [StringLength(1024)]
        public string ContentAfter { get; set; }

        /// <summary>
        /// In container tag is specified, this will be added as class to that
        /// </summary>
        /// <value>The main CSS.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_ContentControl_MainCss")]
        [StringLength(50)]
        public string MainCss { get; set; }

        /// <summary>
        /// Icon to be used on design panel
        /// </summary>
        /// <value>The icon CSS.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_ContentControl_IconCss")]
        [StringLength(50)]
        public string IconCss { get; set; }

        /// <summary>
        /// If specified main content will wrapped with this tag
        /// </summary>
        /// <value>The container tag.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_ContentControl_ContainerTag")]
        [StringLength(20)]
        public string ContainerTag { get; set; }

        /// <summary>
        /// If has dialog, this will shown inside dialog, otherwise will be just placed on the page
        /// </summary>
        /// <value>The content of the dialog.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_ContentControl_DialogContent")]
        [StringLength(1024)]
        public string DialogContent { get; set; }

        /// <summary>
        /// Input control (can be hidden) used by dialog to store content to be placed on the page
        /// </summary>
        /// <value>The content holder field identifier.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_ContentControl_ContentHolderFieldId")]
        [StringLength(50)]
        public string ContentHolderFieldId { get; set; }

        /// <summary>
        /// JavaScript to be used by dialog box, can be anything, but mainly manipulation and transformation of the content to be placed on the page
        /// </summary>
        /// <value>The content of the java script.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_ContentControl_JavaScriptContent")]
        [StringLength(1024)]
        public string JavaScriptContent { get; set; }

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
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Generic_CreateDate")]
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
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Generic_LastModifiedDate")]
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
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Generic_CreatedByUserName")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]//[dbo].[ufnGetUserName]([CreatedBy])
        public string CreatedByUserName { get; private set; }

        /// <summary>
        /// Gets the last name of the modified by user.
        /// </summary>
        /// <value>The last name of the modified by user.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Generic_LastModifiedByUserName")]
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
        [DefaultValue(1843151)]
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
