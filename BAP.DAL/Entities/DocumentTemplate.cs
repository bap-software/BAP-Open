// ***********************************************************************
// Assembly         : BAP.DAL
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="DocumentTemplate.cs" company="BAP Software Ltd.">
//     Copyright © 2015 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
/************************************************************************************************************
Blog BAP data model entity
Create Date: 1/13/2017 3:09:01 PM
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
    /// Class DocumentTemplate.
    /// Implements the <see cref="BAP.Common.IBapEntity" />
    /// Implements the <see cref="BAP.Common.IBapEntityWithState" />
    /// Implements the <see cref="BAP.Common.IFullTextSearchable" />
    /// Implements the <see cref="BAP.Common.ISupportLocalization" />
    /// </summary>
    /// <seealso cref="BAP.Common.IBapEntity" />
    /// <seealso cref="BAP.Common.IBapEntityWithState" />
    /// <seealso cref="BAP.Common.IFullTextSearchable" />
    /// <seealso cref="BAP.Common.ISupportLocalization" />
    [EntityPaging]
    [Table("DocumentTemplate")]
    public partial class DocumentTemplate : IBapEntity, IBapEntityWithState, IFullTextSearchable, ISupportLocalization
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
        public string[] LocalizedProperties => new string[] { "Name", "ShortDescription", "Description", "TemplateBody", "TemplateType" };


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
        [Index("IX_DocumentTemplateName", 1, IsUnique = true)]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_DocumentTemplate_Name")]
        [StringLength(80)]
        [Required]
        [SortingField]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the short description.
        /// </summary>
        /// <value>The short description.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_DocumentTemplate_ShortDescription")]
        [StringLength(255)]
        [Required]
        [SortingField]
        public string ShortDescription { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_DocumentTemplate_Description")]
        [StringLength(4000)]
        [SortingField]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the template body.
        /// </summary>
        /// <value>The template body.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_DocumentTemplate_TemplateBody")]
        public string TemplateBody { get; set; }

        /// <summary>
        /// Gets or sets the template body URL.
        /// </summary>
        /// <value>The template body URL.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_DocumentTemplate_TemplateBodyUrl")]
        [StringLength(1024)]
        public string TemplateBodyUrl { get; set; }

        /// <summary>
        /// Gets or sets the template body text.
        /// </summary>
        /// <value>The template body text.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_DocumentTemplate_TemplateBodyText")]
        [NotMapped]
        public string TemplateBodyText { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is enabled.
        /// </summary>
        /// <value><c>true</c> if this instance is enabled; otherwise, <c>false</c>.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_DocumentTemplate_IsEnabled")]
        [SortingField]
        [Required]
        public bool IsEnabled { get; set; }

        /// <summary>
        /// Gets or sets the type of the template.
        /// </summary>
        /// <value>The type of the template.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_DocumentTemplate_TemplateType")]
        [StringLength(64)]
        [SortingField]
        public string TemplateType { get; set; }

        /// <summary>
        /// Type of tenant, currently only Organization is supported.
        /// </summary>
        /// <value>The tenant unit.</value>
        [StringLength(50)]
        [Index("IX_Tenant", 1)]
        [Index("IX_DocumentTemplateName", 2, IsUnique = true)]
        public string TenantUnit { get; set; }

        /// <summary>
        /// Tenant identifier, in fact Organization Id for a moment.
        /// </summary>
        /// <value>The tenant unit identifier.</value>
        [Index("IX_Tenant", 2)]
        [Index("IX_DocumentTemplateName", 3, IsUnique = true)]
        public int? TenantUnitId { get; set; }

        /// <summary>
        /// Date and time when entity was first inserted into system's DB.
        /// </summary>
        /// <value>The create date.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_DocumentTemplate_CreateDate")]
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
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_DocumentTemplate_LastModifiedDate")]
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
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_DocumentTemplate_CreatedByUserName")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string CreatedByUserName { get; private set; }

        /// <summary>
        /// Gets the last name of the modified by user.
        /// </summary>
        /// <value>The last name of the modified by user.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_DocumentTemplate_LastModifiedByUserName")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string LastModifiedByUserName { get; private set; }

        /// <summary>
        /// Function to return WHERE expression to search for an entity using part of the text specified.
        /// </summary>
        /// <param name="searchValue">Text to search for</param>
        /// <returns>Linq2Sql expression text to search for a given part of text.</returns>
        public string FullTextSearchExpression(string searchValue)
        {
            return string.Format("(Name.Contains(\"{0}\") OR ShortDescription.Contains(\"{0}\") OR Description.Contains(\"{0}\"))", searchValue);
        }

        /// <summary>
        /// Bitmask holding data what roles are allowed to access this type of entity.
        /// </summary>
        /// <value>The owner group.</value>
        [Index]
        [DefaultValue(123)]
        public int OwnerGroup { get; set; }

        /// <summary>
        /// Gets or sets the owner permissions.
        /// </summary>
        /// <value>The owner permissions.</value>
        [Index]
        [DefaultValue(2072079)]
        public int OwnerPermissions { get; set; }
    }
}
