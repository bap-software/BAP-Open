// ***********************************************************************
// Assembly         : BAP.DAL
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="ContentViewControl.cs" company="BAP Software Ltd.">
//     Copyright © 2015 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using BAP.Common;

namespace BAP.DAL.Entities
{
    /// <summary>
    /// Class ContentViewControl.
    /// Implements the <see cref="BAP.Common.IBapEntity" />
    /// Implements the <see cref="BAP.Common.IBapEntityWithState" />
    /// Implements the <see cref="BAP.Common.ISupportLocalization" />
    /// </summary>
    /// <seealso cref="BAP.Common.IBapEntity" />
    /// <seealso cref="BAP.Common.IBapEntityWithState" />
    /// <seealso cref="BAP.Common.ISupportLocalization" />
    [EntityPaging]
    [Table("ContentViewControl")]
    public partial class ContentViewControl : IBapEntity, IBapEntityWithState, ISupportLocalization
    {
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
        public string[] LocalizedProperties => new string[] { "Name", "Description" };


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
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentViewControl_Name")]
        [Index("IX_ContentViewControlName")]
        [StringLength(80)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentViewControl_Description")]
        public string Description { get; set; }

        //Your custom fields are added here
        /// <summary>
        /// Gets or sets the content node identifier.
        /// </summary>
        /// <value>The content node identifier.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentViewControl_ContentNodeId")]
        public int? ContentNodeId { get; set; }

        /// <summary>
        /// Gets or sets the content node.
        /// </summary>
        /// <value>The content node.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentViewControl_ContentNode")]
        public ContentNode ContentNode { get; set; }

        /// <summary>
        /// Gets or sets the content view identifier.
        /// </summary>
        /// <value>The content view identifier.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentViewControl_ContentViewId")]
        public int? ContentViewId { get; set; }

        /// <summary>
        /// Gets or sets the content view.
        /// </summary>
        /// <value>The content view.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentViewControl_ContentView")]
        public ContentView ContentView { get; set; }

        /// <summary>
        /// Gets or sets the content control identifier.
        /// </summary>
        /// <value>The content control identifier.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentViewControl_ContentControlId")]
        public int? ContentControlId { get; set; }

        /// <summary>
        /// Gets or sets the content control.
        /// </summary>
        /// <value>The content control.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentViewControl_ContentControl")]
        public ContentControl ContentControl { get; set; }

        /// <summary>
        /// Gets or sets the type of the control.
        /// </summary>
        /// <value>The type of the control.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentViewControl_ControlType")]
        [StringLength(80)]
        public string ControlType { get; set; }

        /// <summary>
        /// Gets or sets the control identifier.
        /// </summary>
        /// <value>The control identifier.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentViewControl_ControlId")]
        [StringLength(80)]
        public string ControlId { get; set; }

        /// <summary>
        /// Gets or sets the control title.
        /// </summary>
        /// <value>The control title.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentViewControl_ControlTitle")]
        [StringLength(40)]
        public string ControlTitle { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is visible.
        /// </summary>
        /// <value><c>true</c> if this instance is visible; otherwise, <c>false</c>.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentViewControl_IsVisible")]
        public bool IsVisible { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is read only.
        /// </summary>
        /// <value><c>true</c> if this instance is read only; otherwise, <c>false</c>.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentViewControl_IsReadOnly")]
        public bool IsReadOnly { get; set; }

        /// <summary>
        /// Gets or sets the container tag.
        /// </summary>
        /// <value>The container tag.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentViewControl_ContainerTag")]
        [StringLength(20)]
        public string ContainerTag { get; set; }

        /// <summary>
        /// Gets or sets the container CSS.
        /// </summary>
        /// <value>The container CSS.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentViewControl_ContainerCss")]
        [StringLength(40)]
        public string ContainerCss { get; set; }

        /// <summary>
        /// Gets or sets the content of the container.
        /// </summary>
        /// <value>The content of the container.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentViewControl_ContainerContent")]
        [StringLength(1024)]
        public string ContainerContent { get; set; }

        /// <summary>
        /// Gets or sets the content before.
        /// </summary>
        /// <value>The content before.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentViewControl_ContentBefore")]
        [StringLength(1024)]
        public string ContentBefore { get; set; }

        /// <summary>
        /// Gets or sets the content after.
        /// </summary>
        /// <value>The content after.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentViewControl_ContentAfter")]
        [StringLength(1024)]
        public string ContentAfter { get; set; }

        /// <summary>
        /// Gets or sets the java script.
        /// </summary>
        /// <value>The java script.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentViewControl_JavaScript")]
        public string JavaScript { get; set; }

        /// <summary>
        /// Gets or sets the content of the style.
        /// </summary>
        /// <value>The content of the style.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentViewControl_StyleContent")]
        public string StyleContent { get; set; }

        //System fields
        /// <summary>
        /// Type of tenant, currently only Organization is supported.
        /// </summary>
        /// <value>The tenant unit.</value>
        [StringLength(50)]
        [Index("IX_ContentViewControlTenant", 1)]
        public string TenantUnit { get; set; }

        /// <summary>
        /// Tenant identifier, in fact Organization Id for a moment.
        /// </summary>
        /// <value>The tenant unit identifier.</value>
        [Index("IX_ContentViewControlTenant", 2)]
        public int? TenantUnitId { get; set; }

        /// <summary>
        /// Date and time when entity was first inserted into system's DB.
        /// </summary>
        /// <value>The create date.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentViewControl_CreateDate")]
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
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentViewControl_LastModifiedDate")]
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
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentViewControl_CreatedByUserName")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]//[dbo].[ufnGetUserName]([CreatedBy])
        public string CreatedByUserName { get; private set; }

        /// <summary>
        /// Gets the last name of the modified by user.
        /// </summary>
        /// <value>The last name of the modified by user.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentViewControl_LastModifiedByUserName")]
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
        public int OwnerGroup { get; set; }
        /// <summary>
        /// Gets or sets the owner permissions.
        /// </summary>
        /// <value>The owner permissions.</value>
        [Index]
        [DefaultValue(1875919)]
        public int OwnerPermissions { get; set; }
    }
}
