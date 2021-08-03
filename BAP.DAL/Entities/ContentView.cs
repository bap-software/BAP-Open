// ***********************************************************************
// Assembly         : BAP.DAL
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="ContentView.cs" company="BAP Software Ltd.">
//     Copyright © 2015 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Newtonsoft.Json;

using BAP.Common;

namespace BAP.DAL.Entities
{
    /// <summary>
    /// Class ContentViewDescription.
    /// </summary>
    public class ContentViewDescription
	{
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the source view path.
        /// </summary>
        /// <value>The source view path.</value>
        public string SourceViewPath { get; set; }
	}

    /// <summary>
    /// Class ContentView.
    /// Implements the <see cref="BAP.Common.IBapEntity" />
    /// Implements the <see cref="BAP.Common.IBapEntityWithState" />
    /// Implements the <see cref="BAP.Common.ISupportComplexDescription{BAP.DAL.Entities.ContentViewDescription}" />
    /// Implements the <see cref="BAP.Common.ISupportLocalization" />
    /// </summary>
    /// <seealso cref="BAP.Common.IBapEntity" />
    /// <seealso cref="BAP.Common.IBapEntityWithState" />
    /// <seealso cref="BAP.Common.ISupportComplexDescription{BAP.DAL.Entities.ContentViewDescription}" />
    /// <seealso cref="BAP.Common.ISupportLocalization" />
    [EntityPaging]
    [Table("ContentView")]
    public partial class ContentView : IBapEntity, IBapEntityWithState, ISupportComplexDescription<ContentViewDescription>, ISupportLocalization
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
        public string[] LocalizedProperties => new string[] { "Name", "ViewName", "ViewContent" };

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
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentView_Name")]
        [Index("IX_ContentViewName", 1, IsUnique = true)]
        [StringLength(80)]
        public string Name { get; set; }

        /// <summary>
        /// The description
        /// </summary>
        private string _description = "";
        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>The description.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentView_Description")]
        public string Description
		{
			get
			{
				return _description;
			}

			private set
			{
				_description = value;
			}
		}

        /// <summary>
        /// Gets or sets the content nodes.
        /// </summary>
        /// <value>The content nodes.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentView_ContentNodes")]
        public List<ContentNode> ContentNodes { get; set; }

        /// <summary>
        /// Gets or sets the name of the view.
        /// </summary>
        /// <value>The name of the view.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentView_ViewName")]
        [StringLength(80)]
        public string ViewName { get; set; }

        /// <summary>
        /// Gets or sets the view path.
        /// </summary>
        /// <value>The view path.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentView_ViewPath")]
        [StringLength(1024)]
        public string ViewPath { get; set; }

        /// <summary>
        /// Gets or sets the layout path.
        /// </summary>
        /// <value>The layout path.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentView_LayoutPath")]
        [StringLength(1024)]
        public string LayoutPath { get; set; }

        /// <summary>
        /// Gets or sets the content of the view.
        /// </summary>
        /// <value>The content of the view.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentView_ViewContent")]
        public string ViewContent { get; set; }

        /// <summary>
        /// Gets or sets the roles.
        /// </summary>
        /// <value>The roles.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentView_Roles")]
        [StringLength(80)]
        public string Roles { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is partial.
        /// </summary>
        /// <value><c>true</c> if this instance is partial; otherwise, <c>false</c>.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentView_IsPartial")]
        public bool IsPartial { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is shared.
        /// </summary>
        /// <value><c>true</c> if this instance is shared; otherwise, <c>false</c>.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentView_IsShared")]
        public bool IsShared { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is main.
        /// </summary>
        /// <value><c>true</c> if this instance is main; otherwise, <c>false</c>.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentView_IsMain")]
        public bool IsMain { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ContentView"/> is enabled.
        /// </summary>
        /// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentView_Enabled")]
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is layout.
        /// </summary>
        /// <value><c>true</c> if this instance is layout; otherwise, <c>false</c>.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentView_IsLayout")]
        public bool IsLayout { get; set; }

        //System fields
        /// <summary>
        /// Type of tenant, currently only Organization is supported.
        /// </summary>
        /// <value>The tenant unit.</value>
        [StringLength(50)]
        [Index("IX_ContentViewTenant", 1)]
        [Index("IX_ContentViewName", 2, IsUnique = true)]
        public string TenantUnit { get; set; }

        /// <summary>
        /// Tenant identifier, in fact Organization Id for a moment.
        /// </summary>
        /// <value>The tenant unit identifier.</value>
        [Index("IX_ContentViewTenant", 2)]
        [Index("IX_ContentViewName", 3, IsUnique = true)]
        public int? TenantUnitId { get; set; }

        /// <summary>
        /// Date and time when entity was first inserted into system's DB.
        /// </summary>
        /// <value>The create date.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentView_CreateDate")]
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
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentView_LastModifiedDate")]
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
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentView_CreatedByUserName")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]//[dbo].[ufnGetUserName]([CreatedBy])
        public string CreatedByUserName { get; private set; }

        /// <summary>
        /// Gets the last name of the modified by user.
        /// </summary>
        /// <value>The last name of the modified by user.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentView_LastModifiedByUserName")]
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
        /// Bitmask holding data what types of permissions are allowed over this types of entity.
        /// </summary>
        /// <value>The owner permissions.</value>
        [Index]
        [DefaultValue(1875919)]
        public int OwnerPermissions { get; set; }

        #region ISupportComplexDescription		
        /// <summary>
        /// Gets or sets the complex description.
        /// </summary>
        /// <value>The complex description.</value>
        [NotMapped]
		public ContentViewDescription ComplexDescription
		{
			get
			{
				if(!string.IsNullOrEmpty(_description))
				{
					try
					{
						return JsonConvert.DeserializeObject<ContentViewDescription>(_description);
					}
					catch
					{
						return null;
					}
				}
				return null;
			}
			set
			{
				if (value != null)
					_description = JsonConvert.SerializeObject(value);
			}			
		}
		#endregion
	}
}

