// ***********************************************************************
// Assembly         : BAP.eCommerce.DAL
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="Product.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
/************************************************************************************************************
Product BAP data model entity
Create Date: 1/3/2017 10:03:25 PM
Template Author: Victor (C) 2017
************************************************************************************************************/
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

using BAP.Common;
using BAP.eCommerce.Resources;
using BAP.DAL.Entities;

namespace BAP.eCommerce.DAL.Entities
{
    /// <summary>
    /// Class Product.
    /// Implements the <see cref="BAP.Common.BaseSEOFriendlyEntity{BAP.eCommerce.DAL.Entities.Product}" />
    /// Implements the <see cref="BAP.Common.IBapEntity" />
    /// Implements the <see cref="BAP.Common.ISupportsAttachments" />
    /// Implements the <see cref="BAP.Common.ISEOFriendly{BAP.eCommerce.DAL.Entities.Product}" />
    /// Implements the <see cref="BAP.Common.IEntityContent" />
    /// Implements the <see cref="BAP.Common.IFullTextSearchable" />
    /// Implements the <see cref="BAP.Common.IBapEntityWithState" />
    /// Implements the <see cref="BAP.Common.ISupportLocalization" />
    /// </summary>
    /// <seealso cref="BAP.Common.BaseSEOFriendlyEntity{BAP.eCommerce.DAL.Entities.Product}" />
    /// <seealso cref="BAP.Common.IBapEntity" />
    /// <seealso cref="BAP.Common.ISupportsAttachments" />
    /// <seealso cref="BAP.Common.ISEOFriendly{BAP.eCommerce.DAL.Entities.Product}" />
    /// <seealso cref="BAP.Common.IEntityContent" />
    /// <seealso cref="BAP.Common.IFullTextSearchable" />
    /// <seealso cref="BAP.Common.IBapEntityWithState" />
    /// <seealso cref="BAP.Common.ISupportLocalization" />
    [EntityPaging]
    [Table("Product")]
    public partial class Product : BaseSEOFriendlyEntity<Product>, IBapEntity, ISupportsAttachments, ISEOFriendly<Product>, IEntityContent, IFullTextSearchable, IBapEntityWithState, ISupportLocalization
    {
        /// <summary>
        /// Gets or sets the internal identifier.
        /// </summary>
        /// <value>The internal identifier.</value>
        [NotMapped]
        public Guid InternalId { get; set; } = Guid.NewGuid();

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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [NotMapped]
        public string[] LocalizedProperties => new string[] { "Name", "ShortDescription", "Description" };


        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public override int Id { get; set; }

        /// <summary>
        /// Gets or sets the sku.
        /// </summary>
        /// <value>The sku.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Product_SKU")]
        [StringLength(50)]
        [SortingField]
        [Required]
        public string SKU { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Product_Name")]
        [Index("IX_ProductName", 1, IsUnique = true)]
        [StringLength(256)]
        [SortingField]
        [Required]
        [CriteriaField]
        public override string Name { get; set; }

        /// <summary>
        /// Gets or sets the short description.
        /// </summary>
        /// <value>The short description.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Product_ShortDescription")]
        [StringLength(1024)]
        [Required]
        [CriteriaField]
        public string ShortDescription { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Product_Description")]        
        public string Description { get; set; }

        /// <summary>
        /// Contains incoming price of the product
        /// </summary>
        /// <summary>
        /// Gets or sets the source price.
        /// </summary>
        /// <value>The source price.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Product_SourcePrice")]        
        public decimal SourcePrice { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>The price.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Product_Price")]
        [Required]
        [CriteriaField]
        [SortingField(true, true, true, false)]
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the list price.
        /// </summary>
        /// <value>The list price.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Product_ListPrice")]
        public decimal ListPrice { get; set; }        

        /// <summary>
        /// Returns actual price product is sold
        /// </summary>
        [NotMapped]
        public decimal SalesPrice
        {
            get
            {
                if (ListPrice > 0 && ListPrice < Price)
                    return ListPrice;
                return Price;
            }
        }

        /// <summary>
        /// Indicates whether we use discounted list price
        /// </summary>
        [NotMapped]
        public bool IsDiscountedPrice
        {
            get
            {
                return ListPrice > 0 && ListPrice < Price;
            }
        }

        /// <summary>
        /// Gets or sets the MSRP price.
        /// </summary>
        /// <value>The MSRP price.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Product_MsrpPrice")]
        public decimal MsrpPrice { get; set; }

        /// <summary>
        /// Gets or sets the minimum price.
        /// </summary>
        /// <value>The minimum price.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Product_MinPrice")]
        public decimal MinPrice { get; set; }

        /// <summary>
        /// Gets or sets the maximum price.
        /// </summary>
        /// <value>The maximum price.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Product_MaxPrice")]
        public decimal MaxPrice { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Product"/> is enabled.
        /// </summary>
        /// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Product_Enabled")]
        [Required]
        [SortingField]
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets the publish from.
        /// </summary>
        /// <value>The publish from.</value>
        [CriteriaField]
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Product_PublishFrom")]
        public DateTime PublishFrom { get; set; }

        /// <summary>
        /// Gets or sets the publish to.
        /// </summary>
        /// <value>The publish to.</value>
        [CriteriaField]
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Product_PublishTo")]
        public DateTime PublishTo { get; set; }

        /// <summary>
        /// Gets or sets the in store from.
        /// </summary>
        /// <value>The in store from.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Product_InStoreFrom")]
        public DateTime InStoreFrom { get; set; }

        /// <summary>
        /// Gets or sets the public status.
        /// </summary>
        /// <value>The public status.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Product_PublicStatus")]
        [StringLength(50)]
        [SortingField]
        [CriteriaField]
        public string PublicStatus { get; set; }

        /// <summary>
        /// Gets or sets the internal status.
        /// </summary>
        /// <value>The internal status.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Product_InternalStatus")]
        [StringLength(50)]
        [CriteriaField]
        public string InternalStatus { get; set; }

        /// <summary>
        /// Gets or sets the image path.
        /// </summary>
        /// <value>The image path.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Product_ImagePath")]
        [StringLength(512)]
        [FileField]
        public string ImagePath { get; set; }

        /// <summary>
        /// Gets or sets the uid.
        /// </summary>
        /// <value>The uid.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Product_UID")]
        [Required]
        public Guid UID { get; set; }

        /// <summary>
        /// Gets or sets the weight.
        /// </summary>
        /// <value>The weight.</value>
        [CriteriaField]
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Product_Weight")]
        public decimal Weight { get; set; }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>The width.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Product_Width")]
        public decimal Width { get; set; }

        /// <summary>
        /// Gets or sets the depth.
        /// </summary>
        /// <value>The depth.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Product_Depth")]
        public decimal Depth { get; set; }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>The height.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Product_Height")]
        public decimal Height { get; set; }

        /// <summary>
        /// Gets or sets the weight measure.
        /// </summary>
        /// <value>The weight measure.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Product_WeightMeasure")]
        [StringLength(50)]
        public string WeightMeasure { get; set; }

        /// <summary>
        /// Gets or sets the size measure.
        /// </summary>
        /// <value>The size measure.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Product_SizeMeasure")]
        [StringLength(50)]
        public string SizeMeasure { get; set; }

        /// <summary>
        /// Gets or sets the available items.
        /// </summary>
        /// <value>The available items.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Product_AvailableItems")]
        public int AvailableItems { get; set; }

        /// <summary>
        /// Gets or sets the custom data.
        /// </summary>
        /// <value>The custom data.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Product_CustomData")]
        [StringLength(2048)]
        public string CustomData { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [needs shipping].
        /// </summary>
        /// <value><c>true</c> if [needs shipping]; otherwise, <c>false</c>.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Product_NeedsShipping")]
        public bool NeedsShipping { get; set; }

        /// <summary>
        /// Gets or sets the maximum downloads.
        /// </summary>
        /// <value>The maximum downloads.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Product_MaxDownloads")]
        public int MaxDownloads { get; set; }

        /// <summary>
        /// Gets or sets the type of the product.
        /// </summary>
        /// <value>The type of the product.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Product_ProductType")]
        [StringLength(50)]
        public string ProductType { get; set; }

        /// <summary>
        /// Gets or sets the parent product identifier.
        /// </summary>
        /// <value>The parent product identifier.</value>
        public int? ParentProductId { get; set; }
        /// <summary>
        /// Gets or sets the parent product.
        /// </summary>
        /// <value>The parent product.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Product_ParentProduct")]
        public virtual Product ParentProduct { get; set; }

        /// <summary>
        /// Gets or sets the reorder at.
        /// </summary>
        /// <value>The reorder at.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Product_ReorderAt")]
        public DateTime ReorderAt { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [track inventory].
        /// </summary>
        /// <value><c>true</c> if [track inventory]; otherwise, <c>false</c>.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Product_TrackInventory")]
        public bool TrackInventory { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [allow to renew].
        /// </summary>
        /// <value><c>true</c> if [allow to renew]; otherwise, <c>false</c>.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Product_AllowToRenew")]
        public bool AllowToRenew { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is trial.
        /// </summary>
        /// <value><c>true</c> if this instance is trial; otherwise, <c>false</c>.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Product_IsTrial")]
        public bool IsTrial { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is featured.
        /// </summary>
        /// <value><c>true</c> if this instance is featured; otherwise, <c>false</c>.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Product_IsFeatured")]
        public bool IsFeatured { get; set; }

        /// <summary>
        /// Indicates whether product is some online SaaS solution
        /// </summary>
        /// <value><c>true</c> if this instance is online; otherwise, <c>false</c>.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Product_IsOnline")]
        public bool IsOnline { get; set; }

        /// <summary>
        /// Base URL (home page) of the online product
        /// </summary>
        /// <value>The base online URL.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Product_BaseOnlineUrl")]
        public string BaseOnlineUrl { get; set; }

        /// <summary>
        /// Indicates whether product is software or other type of data to download. Product should have appropriate attachment(s).
        /// </summary>
        /// <value><c>true</c> if this instance is downloadable; otherwise, <c>false</c>.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Product_IsDownloadable")]
        public bool IsDownloadable { get; set; }

        /// <summary>
        /// Gets or sets the supplier identifier.
        /// </summary>
        /// <value>The supplier identifier.</value>
        public int? SupplierId { get; set; }

        /// <summary>
        /// Gets or sets the supplier.
        /// </summary>
        /// <value>The supplier.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Product_Supplier")]
        public virtual Supplier Supplier { get; set; }

        /// <summary>
        /// Gets or sets the ProductSupplierData identifier.
        /// </summary>
        /// <value>The supplier identifier.</value>
        public int? ProductSupplierDataId { get; set; }

        /// <summary>
        /// Gets or sets the ProductSupplierData.
        /// </summary>
        /// <value>The supplier.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Product_ProductSupplierData")]
        public virtual ProductSupplierData ProductSupplierData { get; set; }
        
        /// <summary>
        /// Gets or sets the manufacturer identifier.
        /// </summary>
        /// <value>The manufacturer identifier.</value>
        public int? ManufacturerId { get; set; }

        /// <summary>
        /// Gets or sets the manufacturer.
        /// </summary>
        /// <value>The manufacturer.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Product_Manufacturer")]
        public virtual Manufacturer Manufacturer { get; set; }

        /// <summary>
        /// Gets or sets the product category identifier.
        /// </summary>
        /// <value>The product category identifier.</value>
        public int? ProductCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the product category.
        /// </summary>
        /// <value>The product category.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Product_ProductCategory")]
        [SortingField]
        public virtual ProductCategory ProductCategory { get; set; }

        /// <summary>
        /// Gets or sets the rating. This is just a number to be saved to DB. Business logic will define its calculation.
        /// </summary>
        /// <value>
        /// The rating.
        /// </value>
        [Display(ResourceType = typeof(BAP.eCommerce.Resources.ResObject), Name = "FieldLabel_Common_Rating")]
        public int Rating { get; set; }

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
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Product_CreateDate")]
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
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Product_LastModifiedDate")]
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
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Product_CreatedByUserName")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]//[dbo].[ufnGetUserName]([CreatedBy])
        public string CreatedByUserName { get; private set; }

        /// <summary>
        /// Gets the last name of the modified by user.
        /// </summary>
        /// <value>The last name of the modified by user.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Product_LastModifiedByUserName")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]//[dbo].[ufnGetUserName]([LastModifiedBy])
        public string LastModifiedByUserName { get; private set; }
        /// <summary>
        /// Function to return WHERE expression to search for an entity using part of the text specified.
        /// </summary>
        /// <param name="searchValue">Text to search for</param>
        /// <returns>Linq2Sql expression text to search for a given part of text.</returns>
        public string FullTextSearchExpression(string searchValue)
        {
            return string.Format("(SKU.Contains(\"{0}\") OR Name.Contains(\"{0}\") OR Description.Contains(\"{0}\") OR ShortDescription.Contains(\"{0}\"))", searchValue);
        }

        /// <summary>
        /// Gets a value indicating whether this instance is out of stock.
        /// </summary>
        /// <value><c>true</c> if this instance is out of stock; otherwise, <c>false</c>.</value>
        [NotMapped]
        public bool IsOutOfStock => TrackInventory && AvailableItems == 0;

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
        /// Gets or sets the related products.
        /// </summary>
        /// <value>The related products.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Product_RelatedProducts")]
        public virtual List<RelatedProduct> RelatedProducts { get; set; }

        /// <summary>
        /// Gets or sets the attachments.
        /// </summary>
        /// <value>The attachments.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Product_Attachments")]
        [NotMapped]
        public IList<Attachment> Attachments { get; set; }

        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        /// <value>The currency.</value>
        [NotMapped]
        public Currency Currency { get; set; }

        /// <summary>
        /// Gets or sets the discounts.
        /// </summary>
        /// <value>The discounts.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Product_Discounts")]        
        public List<DiscountCoupon> Discounts { get; set; }

        /// <summary>
        /// Gets or sets the options.
        /// </summary>
        /// <value>The options.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Product_Options")]
        public List<ProductOption> Options { get; set; }

        /// <summary>
        /// Contains prepayment amount
        /// </summary>
        /// <summary>
        /// Gets or sets the prepayment amount.
        /// </summary>
        /// <value>The prepayment amount.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Product_PrepaymentAmount")]
        public decimal PrepaymentAmount { get; set; }

        /// <summary>
        /// List of entities customization is allowed
        /// </summary>
        /// <value><c>true</c> if [list customized]; otherwise, <c>false</c>.</value>
        [NotMapped]
        public bool ListCustomized => true;

        /// <summary>
        /// Entitty details page customization is allowed
        /// </summary>
        /// <value><c>true</c> if [details customized]; otherwise, <c>false</c>.</value>
        [NotMapped]
        public bool DetailsCustomized => true;

        /// <summary>
        /// Is product imported
        /// </summary>
        /// <value><c>true</c> if imported from job, otherwise, <c>false</c>.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Product_ProductsImported")]
        public bool ProductsImported { get; set; }

        /// <summary>
        /// Relative Url of the custom page to show entity details
        /// </summary>
        /// <value>The custom details URL.</value>
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Product_CustomDetailsUrl")]
        public string CustomDetailsUrl
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the extra images.
        /// </summary>
        /// <value>The extra images.</value>
        [NotMapped]
        public List<string> ExtraImages { get; set; }


        /// <summary>
        /// Gets or sets the initial term.
        /// </summary>
        /// <value>The initial term.</value>
        [NotMapped]
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Product_InitialTerm")]
        public TimeSpan InitialTerm { 
            get
            {
                return new TimeSpan(InitialTermTicks);
            }

            set
            {
                InitialTermTicks = value.Ticks;
            }
        }
        /// <summary>
        /// Gets or sets the initial term ticks.
        /// </summary>
        /// <value>The initial term ticks.</value>
        public long InitialTermTicks { get; set; }

        /// <summary>
        /// Gets or sets the free trial term.
        /// </summary>
        /// <value>The free trial term.</value>
        [NotMapped]
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Product_FreeTrialTerm")]
        public TimeSpan FreeTrialTerm { 
            get
            {
                return new TimeSpan(FreeTrialTermTicks);
            }
            set
            {
                FreeTrialTermTicks = value.Ticks;
            }
        }
        /// <summary>
        /// Gets or sets the free trial term ticks.
        /// </summary>
        /// <value>The free trial term ticks.</value>
        public long FreeTrialTermTicks { get; set; }

        /// <summary>
        /// Gets or sets the renewal term.
        /// </summary>
        /// <value>The renewal term.</value>
        [NotMapped]
        [Display(ResourceType = typeof(ResObject), Name = "FieldLabel_Product_RenewalTerm")]
        public TimeSpan RenewalTerm 
        { 
            get
            {
                return new TimeSpan(RenewalTermTicks);
            }
            set
            {
                RenewalTermTicks = value.Ticks;
            }
        }
        /// <summary>
        /// Gets or sets the renewal term ticks.
        /// </summary>
        /// <value>The renewal term ticks.</value>
        public long RenewalTermTicks { get; set; }

    }
}
