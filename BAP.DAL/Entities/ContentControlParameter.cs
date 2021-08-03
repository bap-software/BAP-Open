// ***********************************************************************
// Assembly         : BAP.DAL
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="ContentControlParameter.cs" company="BAP Software Ltd.">
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
    /// Class ContentControlParameter.
    /// Implements the <see cref="BAP.Common.IBapEntity" />
    /// Implements the <see cref="BAP.Common.IBapEntityWithState" />
    /// </summary>
    /// <seealso cref="BAP.Common.IBapEntity" />
    /// <seealso cref="BAP.Common.IBapEntityWithState" />
    [EntityPaging]
    [Table("ContentControlParameter")]
    public partial class ContentControlParameter : IBapEntity, IBapEntityWithState
    {
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
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentControlParameter_Name")]
        [Index("IX_ContentControlParameterName")]
        [StringLength(80)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the short description.
        /// </summary>
        /// <value>The short description.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentControlParameter_ShortDescription")]
        [StringLength(256)]
        public string ShortDescription { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentControlParameter_Description")]
        public string Description { get; set; }

        //Your custom fields are added here
        /// <summary>
        /// Gets or sets the content view control identifier.
        /// </summary>
        /// <value>The content view control identifier.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentControlParameter_ContentViewControlId")]
        public int? ContentViewControlId { get; set; }

        /// <summary>
        /// Gets or sets the content view control.
        /// </summary>
        /// <value>The content view control.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentControlParameter_ContentViewControl")]
        public ContentViewControl ContentViewControl { get; set; }

        /// <summary>
        /// Gets or sets the name of the parameter.
        /// </summary>
        /// <value>The name of the parameter.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentControlParameter_ParameterName")]
        [StringLength(40)]
        public string ParameterName { get; set; }

        /// <summary>
        /// Gets or sets the type of the data.
        /// </summary>
        /// <value>The type of the data.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentControlParameter_DataType")]
        [StringLength(40)]
        public string DataType { get; set; }

        /// <summary>
        /// Gets or sets the data source.
        /// </summary>
        /// <value>The data source.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentControlParameter_DataSource")]
        [StringLength(512)]
        public string DataSource { get; set; }

        /// <summary>
        /// Gets or sets the default value.
        /// </summary>
        /// <value>The default value.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentControlParameter_DefaultValue")]
        [StringLength(1024)]
        public string DefaultValue { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is required.
        /// </summary>
        /// <value><c>true</c> if this instance is required; otherwise, <c>false</c>.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentControlParameter_IsRequired")]
        public bool IsRequired { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is read only.
        /// </summary>
        /// <value><c>true</c> if this instance is read only; otherwise, <c>false</c>.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentControlParameter_IsReadOnly")]
        public bool IsReadOnly { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is visible.
        /// </summary>
        /// <value><c>true</c> if this instance is visible; otherwise, <c>false</c>.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentControlParameter_IsVisible")]
        public bool IsVisible { get; set; }

        /// <summary>
        /// Gets or sets the place holder.
        /// </summary>
        /// <value>The place holder.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentControlParameter_PlaceHolder")]
        [StringLength(80)]
        public string PlaceHolder { get; set; }

        /// <summary>
        /// Gets or sets the caption.
        /// </summary>
        /// <value>The caption.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentControlParameter_Caption")]
        [StringLength(40)]
        public string Caption { get; set; }

        /// <summary>
        /// Gets or sets the form control.
        /// </summary>
        /// <value>The form control.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentControlParameter_FormControl")]
        [StringLength(80)]
        public string FormControl { get; set; }

        /// <summary>
        /// Gets or sets the default error message.
        /// </summary>
        /// <value>The default error message.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentControlParameter_DefaultErrorMessage")]
        [StringLength(256)]
        public string DefaultErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets the CSS class.
        /// </summary>
        /// <value>The CSS class.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentControlParameter_CssClass")]
        [StringLength(80)]
        public string CssClass { get; set; }



        //System fields
        /// <summary>
        /// Type of tenant, currently only Organization is supported.
        /// </summary>
        /// <value>The tenant unit.</value>
        [StringLength(50)]
        [Index("IX_ContentControlParameterTenant", 1)]
        public string TenantUnit { get; set; }

        /// <summary>
        /// Tenant identifier, in fact Organization Id for a moment.
        /// </summary>
        /// <value>The tenant unit identifier.</value>
        [Index("IX_ContentControlParameterTenant", 2)]
        public int? TenantUnitId { get; set; }

        /// <summary>
        /// Date and time when entity was first inserted into system's DB.
        /// </summary>
        /// <value>The create date.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentControlParameter_CreateDate")]
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
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentControlParameter_LastModifiedDate")]
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
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentControlParameter_CreatedByUserName")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]//[dbo].[ufnGetUserName]([CreatedBy])
        public string CreatedByUserName { get; private set; }

        /// <summary>
        /// Gets the last name of the modified by user.
        /// </summary>
        /// <value>The last name of the modified by user.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentControlParameter_LastModifiedByUserName")]
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

