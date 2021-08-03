// ***********************************************************************
// Assembly         : BAP.DAL
// Author           : Victor Mamray
// Created          : 04-20-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="BlogComment.cs" company="BAP Software Ltd.">
//     Copyright © 2015 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
/************************************************************************************************************
BlogComment BAP data model entity
Create Date: 1/13/2017 3:10:30 PM
Template Author: Victor (C) 2017
************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using BAP.Common;

namespace BAP.DAL.Entities
{
    /// <summary>
    /// Class BlogComment.
    /// Implements the <see cref="BAP.Common.IBapEntity" />
    /// Implements the <see cref="BAP.Common.IFullTextSearchable" />
    /// Implements the <see cref="BAP.Common.IBapEntityWithState" />
    /// </summary>
    /// <seealso cref="BAP.Common.IBapEntity" />
    /// <seealso cref="BAP.Common.IFullTextSearchable" />
    /// <seealso cref="BAP.Common.IBapEntityWithState" />
    [EntityPaging]
    [Table("BlogComment")]
    public partial class BlogComment : IBapEntity, IFullTextSearchable, IBapEntityWithState
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
        /// Internal identifier of the entity, also identity field in DB.
        /// </summary>
        /// <value>The identifier.</value>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the parent comment identifier.
        /// </summary>
        /// <value>The parent comment identifier.</value>
        public int? ParentCommentId { get; set; }
        /// <summary>
        /// Gets or sets the parent comment.
        /// </summary>
        /// <value>The parent comment.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_BlogComment_Blog")]
        public BlogComment ParentComment { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        [Index("IX_BlogComment", 1, IsUnique = true)]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_BlogPost_Title")]
        [StringLength(80)]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        /// <value>The author.</value>
        [Index("IX_BlogComment", 2, IsUnique = true)]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_BlogComment_Author")]
        [StringLength(80)]
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_BlogComment_Text")]
        [StringLength(4000)]
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the blog identifier.
        /// </summary>
        /// <value>The blog identifier.</value>
        [Index("IX_BlogComment", 3, IsUnique = true)]
        public int? BlogId { get; set; }
        /// <summary>
        /// Gets or sets the blog.
        /// </summary>
        /// <value>The blog.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_BlogComment_Blog")]
        public Blog Blog { get; set; }

        /// <summary>
        /// Gets or sets the blog post identifier.
        /// </summary>
        /// <value>The blog post identifier.</value>
        public int? BlogPostId { get; set; }
        /// <summary>
        /// Gets or sets the blog post.
        /// </summary>
        /// <value>The blog post.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_BlogPost_BlogPost")]
        public BlogPost BlogPost { get; set; }

        /// <summary>
        /// Gets or sets the like number.
        /// </summary>
        /// <value>The like number.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_BlogComment_LikeNumber")]
        public int LikeNumber { get; set; }

        /// <summary>
        /// Gets or sets the dislike number.
        /// </summary>
        /// <value>The dislike number.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_BlogComment_DislikeNumber")]
        public int DislikeNumber { get; set; }

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
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_BlogComment_CreateDate")]
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
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_BlogComment_LastModifiedDate")]
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
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_BlogComment_CreatedByUserName")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]//[dbo].[ufnGetUserName]([CreatedBy])
        public string CreatedByUserName { get; private set; }

        /// <summary>
        /// Gets the last name of the modified by user.
        /// </summary>
        /// <value>The last name of the modified by user.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_BlogComment_LastModifiedByUserName")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]//[dbo].[ufnGetUserName]([LastModifiedBy])
        public string LastModifiedByUserName { get; private set; }

        /// <summary>
        /// Function to return WHERE expression to search for an entity using part of the text specified.
        /// </summary>
        /// <param name="searchValue">Text to search for</param>
        /// <returns>Linq2Sql expression text to search for a given part of text.</returns>
        public string FullTextSearchExpression(string searchValue)
        {
            return string.Format("(Title.Contains(\"{0}\") OR Author.Contains(\"{0}\") OR Text.Contains(\"{0}\"))", searchValue);
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
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Blog_BlogComments")]
        public List<BlogComment> BlogComments { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [notify author by email].
        /// </summary>
        /// <value><c>true</c> if [notify author by email]; otherwise, <c>false</c>.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_BlogComment_NotifyAuthorByEmail")]
        public bool NotifyAuthorByEmail { get; set; }

        /// <summary>
        /// Gets or sets the comment author user identifier.
        /// </summary>
        /// <value>The comment author user identifier.</value>
        public int? CommentAuthorUserId { get; set; }
        /// <summary>
        /// Gets or sets the comment author user.
        /// </summary>
        /// <value>The comment author user.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_BlogComment_CommentAuthorUser")]
        public OrganizationUser CommentAuthorUser { get; set; }
    }
}
