// ***********************************************************************
// Assembly         : BAP.DAL
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="ContentNode.cs" company="BAP Software Ltd.">
//     Copyright © 2015 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using BAP.Common;

namespace BAP.DAL.Entities
{
    /// <summary>
    /// Enum NavigationType
    /// </summary>
    public enum NavigationType
    {
        /// <summary>
        /// The static HTML
        /// </summary>
        StaticHtml = 1,
        /// <summary>
        /// The MVC route
        /// </summary>
        MvcRoute,
        /// <summary>
        /// The external URL
        /// </summary>
        ExternalUrl
    }

    /// <summary>
    /// Enum SitemapPriority
    /// </summary>
    public enum SitemapPriority
    {
        /// <summary>
        /// The none
        /// </summary>
        None = 0,
        /// <summary>
        /// The lowest
        /// </summary>
        Lowest,
        /// <summary>
        /// The very low
        /// </summary>
        VeryLow,
        /// <summary>
        /// The low
        /// </summary>
        Low,
        /// <summary>
        /// The normal
        /// </summary>
        Normal,
        /// <summary>
        /// The high
        /// </summary>
        High,
        /// <summary>
        /// The very high
        /// </summary>
        VeryHigh,
        /// <summary>
        /// The highest
        /// </summary>
        Highest
    }

    /// <summary>
    /// Enum SitemapChangeFrequency
    /// </summary>
    public enum SitemapChangeFrequency
    {
        /// <summary>
        /// The none
        /// </summary>
        None = 0,
        /// <summary>
        /// The always
        /// </summary>
        Always,
        /// <summary>
        /// The hourly
        /// </summary>
        Hourly,
        /// <summary>
        /// The daily
        /// </summary>
        Daily,
        /// <summary>
        /// The weekly
        /// </summary>
        Weekly,
        /// <summary>
        /// The be weekly
        /// </summary>
        BeWeekly,
        /// <summary>
        /// The monthly
        /// </summary>
        Monthly,
        /// <summary>
        /// The quartely
        /// </summary>
        Quartely,
        /// <summary>
        /// The yearly
        /// </summary>
        Yearly,
        /// <summary>
        /// The never
        /// </summary>
        Never
    }

    /// <summary>
    /// Class ContentNode.
    /// Implements the <see cref="BAP.Common.IBapEntity" />
    /// Implements the <see cref="BAP.Common.IBapEntityWithState" />
    /// Implements the <see cref="BAP.Common.ISupportLocalization" />
    /// </summary>
    /// <seealso cref="BAP.Common.IBapEntity" />
    /// <seealso cref="BAP.Common.IBapEntityWithState" />
    /// <seealso cref="BAP.Common.ISupportLocalization" />
    [EntityPaging]
    [Table("ContentNode")]
    public partial class ContentNode : IBapEntity, IBapEntityWithState, ISupportLocalization
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
        /// Internal identifier of the entity, also identity field in DB.
        /// </summary>
        /// <value>The identifier.</value>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Name of the entity, in most of the cases it has to be unique within given tenant scope.
        /// </summary>
        /// <value>The name.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNode_Name")]
        [Index("IX_ContentNodeName", 1, IsUnique = true)]
        [StringLength(80)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the short description.
        /// </summary>
        /// <value>The short description.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNode_ShortDescription")]
        [StringLength(256)]
        public string ShortDescription { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNode_Description")]
        public string Description { get; set; }

        //Your custom fields are added here
        /// <summary>
        /// Gets or sets the alias.
        /// </summary>
        /// <value>The alias.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNode_Alias")]
        [StringLength(80)]
        [Required]
        public string Alias { get; set; }

        /// <summary>
        /// Gets or sets the alias path.
        /// </summary>
        /// <value>The alias path.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNode_AliasPath")]
        [StringLength(1024)]
        [Required]
        public string AliasPath { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is home.
        /// </summary>
        /// <value><c>true</c> if this instance is home; otherwise, <c>false</c>.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNode_IsHome")]
        [DefaultValue(false)]
        public bool IsHome { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [show in menu].
        /// </summary>
        /// <value><c>true</c> if [show in menu]; otherwise, <c>false</c>.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNode_ShowInMenu")]
        [DefaultValue(true)]
        public bool ShowInMenu { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [show in sitemap].
        /// </summary>
        /// <value><c>true</c> if [show in sitemap]; otherwise, <c>false</c>.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNode_ShowInSitemap")]
        [DefaultValue(true)]
        public bool ShowInSitemap { get; set; }

        /// <summary>
        /// Gets or sets the content description.
        /// </summary>
        /// <value>The content description.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNode_ContentDescription")]
        [StringLength(256)]
        public string ContentDescription { get; set; }

        /// <summary>
        /// Gets or sets the content keywords.
        /// </summary>
        /// <value>The content keywords.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNode_ContentKeywords")]
        [StringLength(256)]
        public string ContentKeywords { get; set; }

        /// <summary>
        /// Gets or sets the content author.
        /// </summary>
        /// <value>The content author.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNode_ContentAuthor")]
        [StringLength(128)]
        public string ContentAuthor { get; set; }

        /// <summary>
        /// Gets or sets the layout path.
        /// </summary>
        /// <value>The layout path.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNode_LayoutPath")]
        [StringLength(1024)]
        public string LayoutPath { get; set; }

        /// <summary>
        /// Gets or sets the type of the navigation.
        /// </summary>
        /// <value>The type of the navigation.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNode_NavigationType")]
        [Required]
        public NavigationType NavigationType { get; set; }

        /// <summary>
        /// Gets or sets the rating.
        /// </summary>
        /// <value>The rating.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNode_Rating")]
        public int Rating { get; set; }

        /// <summary>
        /// Gets or sets the culture.
        /// </summary>
        /// <value>The culture.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNode_Culture")]
        [StringLength(20)]
        public string Culture { get; set; }

        /// <summary>
        /// Gets or sets the area.
        /// </summary>
        /// <value>The area.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNode_Area")]
        [StringLength(80)]
        [Index("IX_ContentNodeRoute", IsUnique = true, Order = 1)]
        public string Area { get; set; }

        /// <summary>
        /// Gets or sets the controller.
        /// </summary>
        /// <value>The controller.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNode_Controller")]
        [StringLength(80)]
        [Index("IX_ContentNodeRoute", IsUnique = true, Order = 2)]
        public string Controller { get; set; }

        /// <summary>
        /// Gets or sets the action.
        /// </summary>
        /// <value>The action.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNode_Action")]
        [StringLength(80)]
        [Index("IX_ContentNodeRoute", IsUnique = true, Order = 3)]
        public string Action { get; set; }

        /// <summary>
        /// Gets or sets the action parameters.
        /// </summary>
        /// <value>The action parameters.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNode_ActionParams")]
        [StringLength(256)]
        public string ActionParams { get; set; }

        /// <summary>
        /// Gets or sets the view.
        /// </summary>
        /// <value>The view.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNode_View")]
        [StringLength(80)]
        [Index("IX_ContentNodeRoute", IsUnique = true, Order = 4)]
        public string View { get; set; }

        /// <summary>
        /// Gets or sets the route URL.
        /// </summary>
        /// <value>The route URL.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNode_RouteUrl")]
        [StringLength(256)]        
        public string RouteUrl { get; set; }

        /// <summary>
        /// Gets or sets the name spaces.
        /// </summary>
        /// <value>The name spaces.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNode_NameSpaces")]
        [StringLength(256)]
        public string NameSpaces { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ContentNode"/> is enabled.
        /// </summary>
        /// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNode_Enabled")]
        [DefaultValue(true)]
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets the default CSS.
        /// </summary>
        /// <value>The default CSS.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNode_DefaultCss")]
        [StringLength(80)]
        public string DefaultCss { get; set; }

        /// <summary>
        /// Gets or sets the URL aliases.
        /// </summary>
        /// <value>The URL aliases.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNode_UrlAliases")]
        public string UrlAliases { get; set; }

        /// <summary>
        /// Gets or sets the content title.
        /// </summary>
        /// <value>The content title.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNode_ContentTitle")]
        [StringLength(80)]
        public string ContentTitle { get; set; }

        /// <summary>
        /// Gets or sets the content tag group.
        /// </summary>
        /// <value>The content tag group.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNode_ContentTagGroup")]
        [StringLength(80)]
        public string ContentTagGroup { get; set; }

        /// <summary>
        /// Gets or sets the content tags.
        /// </summary>
        /// <value>The content tags.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNode_ContentTags")]
        [StringLength(256)]
        public string ContentTags { get; set; }

        /// <summary>
        /// Gets or sets the sitemap priority.
        /// </summary>
        /// <value>The sitemap priority.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNode_SitemapPriority")]
        public SitemapPriority SitemapPriority { get; set; }

        /// <summary>
        /// Gets or sets the sitemap change frequency.
        /// </summary>
        /// <value>The sitemap change frequency.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNode_SitemapChangeFrequency")]
        public SitemapChangeFrequency SitemapChangeFrequency { get; set; }

        /// <summary>
        /// Gets or sets the menu caption.
        /// </summary>
        /// <value>The menu caption.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNode_MenuCaption")]
        [StringLength(80)]
        public string MenuCaption { get; set; }

        /// <summary>
        /// Gets or sets the roles.
        /// </summary>
        /// <value>The roles.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNode_Roles")]
        [StringLength(256)]
        public string Roles { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [allow children].
        /// </summary>
        /// <value><c>true</c> if [allow children]; otherwise, <c>false</c>.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNode_AllowChildren")]
        public bool AllowChildren { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [menu clicable].
        /// </summary>
        /// <value><c>true</c> if [menu clicable]; otherwise, <c>false</c>.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNode_MenuClicable")]
        public bool MenuClicable { get; set; }

        /// <summary>
        /// Gets or sets the menu icon.
        /// </summary>
        /// <value>The menu icon.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNode_MenuIcon")]
        [StringLength(256)]
        public string MenuIcon { get; set; }

        /// <summary>
        /// Gets or sets the URL target.
        /// </summary>
        /// <value>The URL target.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNode_UrlTarget")]
        [StringLength(40)]
        public string UrlTarget { get; set; }

        /// <summary>
        /// Gets or sets the menu extra attributes.
        /// </summary>
        /// <value>The menu extra attributes.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNode_MenuExtraAttributes")]
        [StringLength(512)]
        public string MenuExtraAttributes { get; set; }

        /// <summary>
        /// Gets or sets the HTTP method.
        /// </summary>
        /// <value>The HTTP method.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNode_HttpMethod")]
        [StringLength(10)]
        public string HttpMethod { get; set; }

        /// <summary>
        /// Gets or sets the menu sort order.
        /// </summary>
        /// <value>The menu sort order.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNode_MenuSortOrder")]        
        public int MenuSortOrder { get; set; }

        /// <summary>
        /// Gets or sets the parent node identifier.
        /// </summary>
        /// <value>The parent node identifier.</value>
        public int? ParentNodeId { get; set; }
        /// <summary>
        /// Gets or sets the parent node.
        /// </summary>
        /// <value>The parent node.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNode_ParentNode")]
        public ContentNode ParentNode { get; set; }

        /// <summary>
        /// Gets or sets the child nodes.
        /// </summary>
        /// <value>The child nodes.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNode_ChildNodes")]
        public List<ContentNode> ChildNodes { get; set; }

        /// <summary>
        /// Gets or sets the views.
        /// </summary>
        /// <value>The views.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNode_Views")]
        public List<ContentView> Views { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to [keep view file]. If true, view is saved to the file (*.cshtml), not DB.
        /// </summary>
        /// <value><c>true</c> if [keep view file]; otherwise, <c>false</c>.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNode_KeepViewFile")]
        public bool KeepViewFile { get; set; }

        //System fields
        /// <summary>
        /// Type of tenant, currently only Organization is supported.
        /// </summary>
        /// <value>The tenant unit.</value>
        [StringLength(50)]
        [Index("IX_ContentNodeTenant", 1)]
        [Index("IX_ContentNodeName", 2, IsUnique = true)]
        [Index("IX_ContentNodeRoute", IsUnique = true, Order = 5)]
        public string TenantUnit { get; set; }

        /// <summary>
        /// Tenant identifier, in fact Organization Id for a moment.
        /// </summary>
        /// <value>The tenant unit identifier.</value>
        [Index("IX_ContentNodeTenant", 2)]
        [Index("IX_ContentNodeName", 3, IsUnique = true)]
        [Index("IX_ContentNodeRoute", IsUnique = true, Order = 6)]
        public int? TenantUnitId { get; set; }

        /// <summary>
        /// Date and time when entity was first inserted into system's DB.
        /// </summary>
        /// <value>The create date.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNode_CreateDate")]
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
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNode_LastModifiedDate")]
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
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNode_CreatedByUserName")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]//[dbo].[ufnGetUserName]([CreatedBy])
        public string CreatedByUserName { get; private set; }

        /// <summary>
        /// Gets the last name of the modified by user.
        /// </summary>
        /// <value>The last name of the modified by user.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_ContentNode_LastModifiedByUserName")]
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

        /// <summary>
        /// Gets or sets the page settings json.
        /// </summary>
        /// <value>The page settings json.</value>
        [StringLength(2048)]
        public string PageSettingsJson { get; set; }
    }
}

