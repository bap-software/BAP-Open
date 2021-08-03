// ***********************************************************************
// Assembly         : BAP.DAL
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="ContentNodeRoute.cs" company="BAP Software Ltd.">
//     Copyright © 2015 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

using BAP.Common;

namespace BAP.DAL.Entities
{
    /// <summary>
    /// Class ContentNodeRoute.
    /// Implements the <see cref="BAP.Common.IBapEntity" />
    /// Implements the <see cref="BAP.Common.IBapEntityWithState" />
    /// </summary>
    /// <seealso cref="BAP.Common.IBapEntity" />
    /// <seealso cref="BAP.Common.IBapEntityWithState" />
    [EntityPaging]
    [Table("ContentNodeRoute")]
    public partial class ContentNodeRoute : IBapEntity, IBapEntityWithState
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
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNodeRoute_Name")]
        [Index("IX_ContentNodeRouteName")]
        [StringLength(80)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNodeRoute_Description")]
        public string Description { get; set; }

        //Your custom fields are added here
        /// <summary>
        /// Gets or sets the content node identifier.
        /// </summary>
        /// <value>The content node identifier.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNodeRoute_ContentNodeId")]
        public int? ContentNodeId { get; set; }

        /// <summary>
        /// Gets or sets the content node.
        /// </summary>
        /// <value>The content node.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNodeRoute_ContentNode")]
        public ContentNode ContentNode { get; set; }

        /// <summary>
        /// Gets or sets the name of the route.
        /// </summary>
        /// <value>The name of the route.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNodeRoute_RouteName")]
        [StringLength(80)]
        public string RouteName { get; set; }

        /// <summary>
        /// Gets or sets the controller.
        /// </summary>
        /// <value>The controller.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNodeRoute_Controller")]
        [StringLength(80)]
        public string Controller { get; set; }

        /// <summary>
        /// Gets or sets the action.
        /// </summary>
        /// <value>The action.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNodeRoute_Action")]
        [StringLength(80)]
        public string Action { get; set; }

        /// <summary>
        /// Gets or sets the area.
        /// </summary>
        /// <value>The area.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNodeRoute_Area")]
        [StringLength(80)]
        public string Area { get; set; }

        /// <summary>
        /// Gets or sets the data tokens.
        /// </summary>
        /// <value>The data tokens.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNodeRoute_DataTokens")]
        [StringLength(256)]
        public string DataTokens { get; set; }

        /// <summary>
        /// Gets or sets the route parameters.
        /// </summary>
        /// <value>The route parameters.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNodeRoute_RouteParameters")]
        [StringLength(1024)]
        public string RouteParameters { get; set; }

        /// <summary>
        /// Gets or sets the name spaces.
        /// </summary>
        /// <value>The name spaces.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNodeRoute_NameSpaces")]
        [StringLength(1024)]
        public string NameSpaces { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>The URL.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNodeRoute_Url")]
        [StringLength(1024)]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the roles.
        /// </summary>
        /// <value>The roles.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNodeRoute_Roles")]
        [StringLength(256)]
        public string Roles { get; set; }

        //System fields
        /// <summary>
        /// Type of tenant, currently only Organization is supported.
        /// </summary>
        /// <value>The tenant unit.</value>
        [StringLength(50)]
        [Index("IX_ContentNodeRouteTenant", 1)]
        public string TenantUnit { get; set; }

        /// <summary>
        /// Tenant identifier, in fact Organization Id for a moment.
        /// </summary>
        /// <value>The tenant unit identifier.</value>
        [Index("IX_ContentNodeRouteTenant", 2)]
        public int? TenantUnitId { get; set; }

        /// <summary>
        /// Date and time when entity was first inserted into system's DB.
        /// </summary>
        /// <value>The create date.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNodeRoute_CreateDate")]
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
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNodeRoute_LastModifiedDate")]
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
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNodeRoute_CreatedByUserName")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]//[dbo].[ufnGetUserName]([CreatedBy])
        public string CreatedByUserName { get; private set; }

        /// <summary>
        /// Gets the last name of the modified by user.
        /// </summary>
        /// <value>The last name of the modified by user.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNodeRoute_LastModifiedByUserName")]
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
