// ***********************************************************************
// Assembly         : BAP.eCommerce.DAL
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="ProductOption.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
/************************************************************************************************************
ProductOption BAP data model entity
Create Date: 1/3/2017 10:10:56 PM
Template Author: Victor (C) 2017
************************************************************************************************************/
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using BAP.Common;

using BAP.eCommerce.Resources;
using System.Collections.Generic;

namespace BAP.eCommerce.DAL.Entities
{
    /// <summary>
    /// Enum ProductOptionType
    /// </summary>
    public enum ProductOptionType
    {
        /// <summary>
        /// The attribute
        /// </summary>
        [Display(ResourceType = typeof(ResObject), Name = "EnumValue_ProductOptionType_Attribute")]
        Attribute = 1,
        /// <summary>
        /// The product
        /// </summary>
        [Display(ResourceType = typeof(ResObject), Name = "EnumValue_ProductOptionType_Product")]
        Product = 2,
        /// <summary>
        /// The text
        /// </summary>
        [Display(ResourceType = typeof(ResObject), Name = "EnumValue_ProductOptionType_Text")]
        Text = 3
    }

    /// <summary>
    /// Enum ProductOptionUserControl
    /// </summary>
    public enum ProductOptionUserControl
    {
        /// <summary>
        /// The text
        /// </summary>
        [Display(ResourceType = typeof(ResObject), Name = "EnumValue_ProductOptionUserControl_Text")]
        Text = 1,
        /// <summary>
        /// The text area
        /// </summary>
        [Display(ResourceType = typeof(ResObject), Name = "EnumValue_ProductOptionUserControl_TextArea")]
        TextArea,
        /// <summary>
        /// The drop down list
        /// </summary>
        [Display(ResourceType = typeof(ResObject), Name = "EnumValue_ProductOptionUserControl_DropDownList")]
        DropDownList,
        /// <summary>
        /// The radio vertical
        /// </summary>
        [Display(ResourceType = typeof(ResObject), Name = "EnumValue_ProductOptionUserControl_RadioVertical")]
        RadioVertical,
        /// <summary>
        /// The radio horizontal
        /// </summary>
        [Display(ResourceType = typeof(ResObject), Name = "EnumValue_ProductOptionUserControl_RadioHorizontal")]
        RadioHorizontal,
        /// <summary>
        /// The checkbox vertical
        /// </summary>
        [Display(ResourceType = typeof(ResObject), Name = "EnumValue_ProductOptionUserControl_CheckboxVertical")]
        CheckboxVertical,
        /// <summary>
        /// The checkbox horizontal
        /// </summary>
        [Display(ResourceType = typeof(ResObject), Name = "EnumValue_ProductOptionUserControl_CheckboxHorizontal")]
        CheckboxHorizontal
    }

    /// <summary>
    /// Class ProductOption.
    /// Implements the <see cref="BAP.Common.IBapEntity" />
    /// Implements the <see cref="BAP.Common.IBapEntityWithState" />
    /// Implements the <see cref="BAP.Common.ISupportLocalization" />
    /// </summary>
    /// <seealso cref="BAP.Common.IBapEntity" />
    /// <seealso cref="BAP.Common.IBapEntityWithState" />
    /// <seealso cref="BAP.Common.ISupportLocalization" />
    [EntityPaging]
    [Table("ProductOption")]
    public partial class ProductOption : IBapEntity, IBapEntityWithState, ISupportLocalization
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
        [Index("IX_ProductOptionName", 1, IsUnique = true)]
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ProductOption_Name")]
        [StringLength(80)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the short description.
        /// </summary>
        /// <value>The short description.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ProductOption_ShortDescription")]
        [StringLength(256)]
        [Required]
        public string ShortDescription { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ProductOption_Description")]
        [StringLength(1024)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>The type.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ProductOption_Type")]
        [Required]
        public ProductOptionType? Type { get; set; }

        /// <summary>
        /// Gets or sets the user control.
        /// </summary>
        /// <value>The user control.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ProductOption_UserControl")]
        [Required]
        public ProductOptionUserControl? UserControl { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ProductOption"/> is enabled.
        /// </summary>
        /// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ProductOption_Enabled")]
        [Required]
        public bool Enabled { get; set; }

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
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ProductOption_CreateDate")]
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
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ProductOption_LastModifiedDate")]
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
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ProductOption_CreatedByUserName")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]//[dbo].[ufnGetUserName]([CreatedBy])
        public string CreatedByUserName { get; private set; }

        /// <summary>
        /// Gets the last name of the modified by user.
        /// </summary>
        /// <value>The last name of the modified by user.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ProductOption_LastModifiedByUserName")]
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
        /// Gets or sets the product option items.
        /// </summary>
        /// <value>The product option items.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ProductOption_Items")]
        public List<ProductOptionItem> ProductOptionItems { get; set; }

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        /// <value>The products.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ProductOption_Products")]
        public List<Product> Products { get; set; }

    }
}
