// ***********************************************************************
// Assembly         : BAP.DAL
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="Blog.cs" company="BAP Software Ltd.">
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
using System.Web;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using BAP.Common;

namespace BAP.DAL.Entities
{
    /// <summary>
    /// Class Blog.
    /// Implements the <see cref="BAP.Common.BaseSEOFriendlyEntity{BAP.DAL.Entities.Blog}" />
    /// Implements the <see cref="BAP.Common.IBapEntity" />
    /// Implements the <see cref="BAP.Common.IBapEntityWithState" />
    /// Implements the <see cref="BAP.Common.IFullTextSearchable" />
    /// Implements the <see cref="BAP.Common.ISEOFriendly{BAP.DAL.Entities.Blog}" />
    /// </summary>
    /// <seealso cref="BAP.Common.BaseSEOFriendlyEntity{BAP.DAL.Entities.Blog}" />
    /// <seealso cref="BAP.Common.IBapEntity" />
    /// <seealso cref="BAP.Common.IBapEntityWithState" />
    /// <seealso cref="BAP.Common.IFullTextSearchable" />
    /// <seealso cref="BAP.Common.ISEOFriendly{BAP.DAL.Entities.Blog}" />
    [EntityPaging]
    [Table("Blog")]
    public partial class Blog : BaseSEOFriendlyEntity<Blog>, IBapEntity, IBapEntityWithState, IFullTextSearchable, ISEOFriendly<Blog>
    {
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
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [Index("IX_BlogName", 1, IsUnique = true)]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Blog_Name")]
        [StringLength(80)]
        [SortingField]
        public override string Name { get; set; }

        /// <summary>
        /// Gets or sets the short description.
        /// </summary>
        /// <value>The short description.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Blog_ShortDescription")]
        [StringLength(256)]
        [SortingField]
        public string ShortDescription { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Blog_Description")]
        [StringLength(4000)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the main image URL.
        /// </summary>
        /// <value>The main image URL.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Blog_MainImageUrl")]
        [StringLength(1024)]
        [SortingField]
        public string MainImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the file.
        /// </summary>
        /// <value>The file.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Attachment_File")]
        [NotMapped]
        public HttpPostedFileBase File { get; set; }

        /// <summary>
        /// Gets or sets the blog author identifier.
        /// </summary>
        /// <value>The blog author identifier.</value>
        public int? BlogAuthorId { get; set; }
        /// <summary>
        /// Gets or sets the blog author.
        /// </summary>
        /// <value>The blog author.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Blog_BlogAuthor")]
        [SortingField]
        public BlogAuthor BlogAuthor { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        /// <value>The tags.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Blog_Tags")]
        [StringLength(256)]
        [SortingField]
        public string Tags { get; set; }

        /// <summary>
        /// Gets or sets the category code.
        /// </summary>
        /// <value>The category code.</value>
        [Index("IX_CategoryCode")]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Generic_CategoryCode")]
        [StringLength(10)]
        public string CategoryCode { get; set; }

        /// <summary>
        /// Gets or sets the facebook URL.
        /// </summary>
        /// <value>The facebook URL.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_FacebookUrl")]
        [StringLength(255)]
        public string FacebookUrl { get; set; }

        /// <summary>
        /// Gets or sets the twitter URL.
        /// </summary>
        /// <value>The twitter URL.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_TwitterUrl")]
        [StringLength(255)]
        public string TwitterUrl { get; set; }

        /// <summary>
        /// Gets or sets the linkedin URL.
        /// </summary>
        /// <value>The linkedin URL.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_LinkedinUrl")]
        [StringLength(255)]
        public string LinkedinUrl { get; set; }

        /// <summary>
        /// Gets or sets the googleplus URL.
        /// </summary>
        /// <value>The googleplus URL.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_GoogleplusUrl")]
        [StringLength(255)]
        public string GoogleplusUrl { get; set; }

        /// <summary>
        /// Gets or sets the instagram URL.
        /// </summary>
        /// <value>The instagram URL.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_InstagramUrl")]
        [StringLength(255)]
        public string InstagramUrl { get; set; }

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
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Blog_CreateDate")]
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
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Blog_LastModifiedDate")]
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
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Blog_CreatedByUserName")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]//[dbo].[ufnGetUserName]([CreatedBy])
        public string CreatedByUserName { get; private set; }

        /// <summary>
        /// Gets the last name of the modified by user.
        /// </summary>
        /// <value>The last name of the modified by user.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Blog_LastModifiedByUserName")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]//[dbo].[ufnGetUserName]([LastModifiedBy])
        public string LastModifiedByUserName { get; private set; }

        /// <summary>
        /// Function to return WHERE expression to search for an entity using part of the text specified.
        /// </summary>
        /// <param name="searchValue">Text to search for</param>
        /// <returns>Linq2Sql expression text to search for a given part of text.</returns>
        public string FullTextSearchExpression(string searchValue)
        {
            return string.Format("(Name.Contains(\"{0}\") OR ShortDescription.Contains(\"{0}\") OR Description.Contains(\"{0}\") OR Tags.Contains(\"{0}\") OR CategoryCode.Contains(\"{0}\"))", searchValue);
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
        /// Gets or sets the blog posts.
        /// </summary>
        /// <value>The blog posts.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Blog_BlogPosts")]
        public List<BlogPost> BlogPosts { get; set; }

        /// <summary>
        /// Gets or sets the blog comments.
        /// </summary>
        /// <value>The blog comments.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Blog_BlogComments")]
        public List<BlogComment> BlogComments { get; set; }

    }
}
