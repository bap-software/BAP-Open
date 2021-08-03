// ***********************************************************************
// Assembly         : BAP.eCommerce.DAL
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="ProductCategory.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
/************************************************************************************************************
ProductCategory BAP data model entity
Create Date: 1/3/2017 10:08:59 PM
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
    /// Class ProductCategory.
    /// Implements the <see cref="BAP.Common.BaseSEOFriendlyEntity{BAP.eCommerce.DAL.Entities.ProductCategory}" />
    /// Implements the <see cref="BAP.Common.IBapEntity" />
    /// Implements the <see cref="BAP.Common.IBapEntityWithState" />
    /// Implements the <see cref="BAP.Common.ISupportLocalization" />
    /// </summary>
    /// <seealso cref="BAP.Common.BaseSEOFriendlyEntity{BAP.eCommerce.DAL.Entities.ProductCategory}" />
    /// <seealso cref="BAP.Common.IBapEntity" />
    /// <seealso cref="BAP.Common.IBapEntityWithState" />
    /// <seealso cref="BAP.Common.ISupportLocalization" />
    [EntityPaging]
    [Table("ProductCategory")]
    public partial class ProductCategory : BaseSEOFriendlyEntity<ProductCategory>, IBapEntity, IBapEntityWithState, ISupportLocalization
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
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        /// <summary>
        /// Gets or sets the parent category identifier.
        /// </summary>
        /// <value>The parent category identifier.</value>
        public int? ParentCategoryId { get; set; }
        /// <summary>
        /// Gets or sets the parent category.
        /// </summary>
        /// <value>The parent category.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ProductCategory_ParentCategory")]
        [SortingField(true, true, false, false, "Name")]
        public ProductCategory ParentCategory { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [Index("IX_ProductCategoryName", 1, IsUnique = true)]
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ProductCategory_Name")]
        [StringLength(80)]
        [Required]
        [SortingField(true, true, true, false)]
        public override string Name { get; set; }

        /// <summary>
        /// Gets or sets the short description.
        /// </summary>
        /// <value>The short description.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ProductCategory_ShortDescription")]
        [StringLength(256)]
        [Required]
        [SortingField]
        public string ShortDescription { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ProductCategory_Description")]
        [StringLength(1024)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        /// <value>The order.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ProductCategory_Order")]
        [SortingField]
        public int? Order { get; set; }

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
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ProductCategory_CreateDate")]
        [SortingField]
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
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ProductCategory_LastModifiedDate")]
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
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ProductCategory_CreatedByUserName")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]//[dbo].[ufnGetUserName]([CreatedBy])
        public string CreatedByUserName { get; private set; }

        /// <summary>
        /// Gets the last name of the modified by user.
        /// </summary>
        /// <value>The last name of the modified by user.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ProductCategory_LastModifiedByUserName")]
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
        [DefaultValue(1875535)]
        [Required]
        public int OwnerPermissions { get; set; }
        /// <summary>
        /// Show if no products in the category
        /// </summary>
        /// <value>The owner group.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ProductCategory_ShowIfEmpty")]
        [DefaultValue(false)]
        [Required]
        public bool ShowIfEmpty { get; set; }
        /// <summary>
        /// Show external reference id
        /// </summary>
        /// <value>The show external reference id.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ProductCategory_ExternalReferenceId")]
        public string ExternalReferenceId { get; set; }

        /// <summary>
        /// Gets or sets the child categories.
        /// </summary>
        /// <value>The child categories.</value>
        [NotMapped]
        public List<ProductCategory> ChildCategories { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ProductCategory"/> is selected.
        /// </summary>
        /// <value><c>true</c> if selected; otherwise, <c>false</c>.</value>
        [NotMapped]
        public bool Selected { get; set; }

        /// <summary>
        /// Gets or sets the product count.
        /// </summary>
        /// <value>The product count.</value>
        [NotMapped]
        public int ProductCount { get; set; }

        /// <summary>
        /// Gets or sets the stores.
        /// </summary>
        /// <value>The stores.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_ProductCategory_Stores")]
        public List<Store> Stores { get; set; }

        /// <summary>
        /// Determines whether the specified identifier is descendant.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if the specified identifier is descendant; otherwise, <c>false</c>.</returns>
        public bool IsDescendant(int? id)
        {
            if (Id == id)
                return true;
            if (ParentCategory != null)
                return ParentCategory.IsDescendant(id);
            else
                return Id == id;
        }

        /// <summary>
        /// Determines whether the specified category name is descendant.
        /// </summary>
        /// <param name="categoryName">Name of the category.</param>
        /// <returns><c>true</c> if the specified category name is descendant; otherwise, <c>false</c>.</returns>
        public bool IsDescendant(string categoryName)
        {
            if (categoryName != null && Name.ToLowerInvariant().Contains(categoryName.ToLowerInvariant()))
                return true;
            if (ParentCategory != null)
                return ParentCategory.IsDescendant(categoryName);
            else
                return categoryName != null && Name.ToLowerInvariant().Contains(categoryName.ToLowerInvariant());
        }
    }
}
