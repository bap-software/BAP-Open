// ***********************************************************************
// Assembly         : BAP.DAL
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="NewsLetter.cs" company="BAP Software Ltd.">
//     Copyright © 2015 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
/************************************************************************************************************
NewsLetter BAP data model entity
Create Date: 12/11/2016 9:05:16 PM
Template Author: Victor (C) 2016
************************************************************************************************************/
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using BAP.Common;
using System.Web;

namespace BAP.DAL.Entities
{
    /// <summary>
    /// Class NewsLetter.
    /// Implements the <see cref="BAP.Common.IBapEntity" />
    /// Implements the <see cref="BAP.Common.IBapEntityWithState" />
    /// Implements the <see cref="BAP.Common.ISupportLocalization" />
    /// </summary>
    /// <seealso cref="BAP.Common.IBapEntity" />
    /// <seealso cref="BAP.Common.IBapEntityWithState" />
    /// <seealso cref="BAP.Common.ISupportLocalization" />
    [EntityPaging]
    [Table("NewsLetter")]
    public partial class NewsLetter : IBapEntity, IBapEntityWithState, ISupportLocalization
    {
        /// <summary>
        /// Name of the entity, in most of the cases it has to be unique within given tenant scope.
        /// </summary>
        /// <value>The name.</value>
        [NotMapped]
        public string Name { get; set; }

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
        public string[] LocalizedProperties => new string[] { "Title", "Subtitle", "TextHtml" };


        /// <summary>
        /// Internal identifier of the entity, also identity field in DB.
        /// </summary>
        /// <value>The identifier.</value>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        [Index("IX_NewsLetterName", 1, IsUnique = true)]
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_NewsLetter_Title")]
        [StringLength(50)]
        [SortingField]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the subtitle.
        /// </summary>
        /// <value>The subtitle.</value>
        [Index("IX_NewsLetterName", 2, IsUnique = true)]
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_NewsLetter_Subtitle")]
        [StringLength(80)]
        [SortingField]
        public string Subtitle { get; set; }

        /// <summary>
        /// Gets or sets the text HTML.
        /// </summary>
        /// <value>The text HTML.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_NewsLetter_TextHtml")]
        [StringLength(2000)]
        [SortingField]
        public string TextHtml { get; set; }

        /// <summary>
        /// Gets or sets the image path.
        /// </summary>
        /// <value>The image path.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_NewsLetter_ImagePath")]
        [StringLength(255)]
        [SortingField]
        public string ImagePath { get; set; }

        /// <summary>
        /// Gets or sets the image file.
        /// </summary>
        /// <value>The image file.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_NewsLetter_UploadImage")]
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        /// <summary>
        /// Gets or sets the publish date.
        /// </summary>
        /// <value>The publish date.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_NewsLetter_PublishDate")]
        [SortingField]
        public DateTime PublishDate { get; set; }

        /// <summary>
        /// Gets or sets the published.
        /// </summary>
        /// <value>The published.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_NewsLetter_Published")]
        [SortingField]
        public Boolean Published { get; set; }

        /// <summary>
        /// Type of tenant, currently only Organization is supported.
        /// </summary>
        /// <value>The tenant unit.</value>
        [Index("IX_Tenant", 1)]
        [StringLength(50)]
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
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_NewsLetter_CreateDate")]
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
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_NewsLetter_LastModifiedDate")]
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
        [Timestamp]
        public byte[] TimeStamp { get; set; }

        /// <summary>
        /// Gets the name of the created by user.
        /// </summary>
        /// <value>The name of the created by user.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_NewsLetter_CreatedByUserName")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]//[dbo].[ufnGetUserName]([CreatedBy])
        public string CreatedByUserName { get; private set; }

        /// <summary>
        /// Gets the last name of the modified by user.
        /// </summary>
        /// <value>The last name of the modified by user.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_NewsLetter_LastModifiedByUserName")]
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
