using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BAP.Common;

namespace BAP.eCommerce.DAL.Entities
{
    /// <summary>
    /// Store any info from Supplier that is related to particular Product
    /// </summary>
    [Table("ProductSupplierData")]
    [EntityPaging]
    public class ProductSupplierData : IBapEntity, IBapEntityWithState
    {
        #region Default info

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// <inheritdoc />
        /// </summary>
        [StringLength(50)]
        [Index("IX_Tenant", 1)]
        public string TenantUnit { get; set; }
        
        /// <summary>
        /// <inheritdoc />
        /// </summary>>
        [Index("IX_Tenant", 2)]
        public int? TenantUnitId { get; set; }
        
        /// <summary>
        /// <inheritdoc />
        /// </summary>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ProductSupplierData_CreateDate")]
        public DateTime? CreateDate { get; set; }
        
        /// <summary>
        /// <inheritdoc />
        /// </summary>
        [StringLength(128)]
        public string CreatedBy { get; set; }
        
        /// <summary>
        /// <inheritdoc />
        /// </summary>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ProductSupplierData_LastModifiedDate")]
        public DateTime? LastModifiedDate { get; set; }
        
        /// <summary>
        /// <inheritdoc />
        /// </summary>
        [StringLength(128)]
        public string LastModifiedBy { get; set; }
        
        /// <summary>
        /// Gets the name of the created by user.
        /// </summary>
        /// <value>The name of the created by user.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ProductSupplierData_CreatedByUserName")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]//[dbo].[ufnGetUserName]([CreatedBy])
        public string CreatedByUserName { get; private set; }

        /// <summary>
        /// Gets the last name of the modified by user.
        /// </summary>
        /// <value>The last name of the modified by user.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ProductSupplierData_LastModifiedByUserName")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]//[dbo].[ufnGetUserName]([LastModifiedBy])
        public string LastModifiedByUserName { get; private set; }
        
        /// <summary>
        /// <inheritdoc />
        /// </summary>
        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }
        
        /// <summary>
        /// <inheritdoc />
        /// </summary>
        [Index]
        [DefaultValue(127)]
        [Required]
        public int OwnerGroup { get; set; }
        
        /// <summary>
        /// <inheritdoc />
        /// </summary>
        [Index]
        [DefaultValue(1843151)]
        [Required]
        public int OwnerPermissions { get; set; }
        
        /// <summary>
        /// <inheritdoc />
        /// </summary>
        [NotMapped]
        public BAPEntityState EntityState { get; set; }

        #endregion

        /// <summary>
        /// Product ID in external Supplier's data source
        /// </summary>
        [Required]
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ProductSupplierData_ExternalProductId")]
        public int ExternalProductId { get; set; }
        
        /// <summary>
        /// Date when the product was out of stock the last time.
        /// Store info with TimeZone offset for more accuracy.
        /// </summary>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ProductSupplierData_LastOutOfStockDate")]
        public DateTime? LastOutOfStockDate { get; set; }
    }
}