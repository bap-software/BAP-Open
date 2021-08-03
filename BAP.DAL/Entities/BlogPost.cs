// ***********************************************************************
// Assembly         : BAP.DAL
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="BlogPost.cs" company="BAP Software Ltd.">
//     Copyright © 2015 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
/************************************************************************************************************
BlogPost BAP data model entity
Create Date: 1/13/2017 3:09:52 PM
Template Author: Victor (C) 2017
************************************************************************************************************/
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using BAP.Common;
using System.Collections.Generic;
using System.Web;

namespace BAP.DAL.Entities
{
    /// <summary>
    /// Class BlogPost.
    /// Implements the <see cref="BAP.Common.BaseSEOFriendlyEntity{BAP.DAL.Entities.BlogPost}" />
    /// Implements the <see cref="BAP.Common.IBapEntity" />
    /// Implements the <see cref="BAP.Common.IBapEntityWithState" />
    /// Implements the <see cref="BAP.Common.IFullTextSearchable" />
    /// Implements the <see cref="BAP.Common.ISEOFriendly{BAP.DAL.Entities.BlogPost}" />
    /// </summary>
    /// <seealso cref="BAP.Common.BaseSEOFriendlyEntity{BAP.DAL.Entities.BlogPost}" />
    /// <seealso cref="BAP.Common.IBapEntity" />
    /// <seealso cref="BAP.Common.IBapEntityWithState" />
    /// <seealso cref="BAP.Common.IFullTextSearchable" />
    /// <seealso cref="BAP.Common.ISEOFriendly{BAP.DAL.Entities.BlogPost}" />
    [EntityPaging]
    [Table("BlogPost")]
    public partial class BlogPost : BaseSEOFriendlyEntity<BlogPost>, IBapEntity, IBapEntityWithState, IFullTextSearchable, ISEOFriendly<BlogPost>
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [NotMapped]
        public override string Name { get; set; }

        /// <summary>
        /// Gets the public identifier.
        /// </summary>
        /// <returns>System.String.</returns>
        public override string GetPublicId()
        {
            return GenerateSlug(Id, Title);
        }

        /// <summary>
        /// State of the BAP entity in terms of EF context.
        /// </summary>
        /// <value>The state of the entity.</value>
        [NotMapped]
        public BAPEntityState EntityState { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        [Index("IX_BlogPost", 1, IsUnique = true)]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_BlogPost_Title")]
        [StringLength(80)]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the short description.
        /// </summary>
        /// <value>The short description.</value>
        [Index("IX_BlogPost", 2, IsUnique = true)]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_BlogPost_ShortDescription")]
        [StringLength(256)]
        public string ShortDescription { get; set; }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_BlogPost_Text")]
        [StringLength(4000)]
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the main image URL.
        /// </summary>
        /// <value>The main image URL.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_BlogPost_MainImageUrl")]
        [StringLength(1024)]
        public string MainImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the file.
        /// </summary>
        /// <value>The file.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Attachment_File")]
        [NotMapped]
        public HttpPostedFileBase File { get; set; }

        /// <summary>
        /// Gets or sets the blog identifier.
        /// </summary>
        /// <value>The blog identifier.</value>
        public int? BlogId { get; set; }
        /// <summary>
        /// Gets or sets the blog.
        /// </summary>
        /// <value>The blog.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_BlogPost_Blog")]
        public Blog Blog { get; set; }

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
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_BlogPost_CreateDate")]
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
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_BlogPost_LastModifiedDate")]
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
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_BlogPost_CreatedByUserName")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]//[dbo].[ufnGetUserName]([CreatedBy])
        public string CreatedByUserName { get; private set; }

        /// <summary>
        /// Gets the last name of the modified by user.
        /// </summary>
        /// <value>The last name of the modified by user.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_BlogPost_LastModifiedByUserName")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]//[dbo].[ufnGetUserName]([LastModifiedBy])
        public string LastModifiedByUserName { get; private set; }

        /// <summary>
        /// Function to return WHERE expression to search for an entity using part of the text specified.
        /// </summary>
        /// <param name="searchValue">Text to search for</param>
        /// <returns>Linq2Sql expression text to search for a given part of text.</returns>
        public string FullTextSearchExpression(string searchValue)
        {
            return string.Format("(Title.Contains(\"{0}\") OR ShortDescription.Contains(\"{0}\") OR Text.Contains(\"{0}\"))", searchValue);
        }

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
        [DefaultValue(1843151)]
        public int OwnerPermissions { get; set; }

        /// <summary>
        /// Gets or sets the blog comments.
        /// </summary>
        /// <value>The blog comments.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_BlogPost_BlogComments")]
        public List<BlogComment> BlogComments { get; set; }

        /// <summary>
        /// Gets or sets the post images.
        /// </summary>
        /// <value>The post images.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_BlogPost_PostImages")]
        [NotMapped]
        public List<Attachment> PostImages { get; set; }
    }
}
