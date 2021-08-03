// ***********************************************************************
// Assembly         : BAP.DAL
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="WorkflowClass.cs" company="BAP Software Ltd.">
//     Copyright © 2015 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
/************************************************************************************************************
WorkflowClass BAP data model entity
Create Date: 1/13/2017 3:09:01 PM
Template Author: Victor (C) 2017
************************************************************************************************************/
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

using BAP.Common;

namespace BAP.DAL.Entities
{
    /// <summary>
    /// Class WorkflowClass.
    /// Implements the <see cref="BAP.Common.IBapEntity" />
    /// Implements the <see cref="BAP.Common.IBapEntityWithState" />
    /// Implements the <see cref="BAP.Common.ISupportLocalization" />
    /// </summary>
    /// <seealso cref="BAP.Common.IBapEntity" />
    /// <seealso cref="BAP.Common.IBapEntityWithState" />
    /// <seealso cref="BAP.Common.ISupportLocalization" />
    [EntityPaging]
    [Table("WorkflowClass")]
    public partial class WorkflowClass : IBapEntity, IBapEntityWithState, ISupportLocalization
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
        [Index("IX_WorkflowClassName", 1, IsUnique = true)]
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_WorkflowClass_Name")]
        [StringLength(80)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the short description.
        /// </summary>
        /// <value>The short description.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_WorkflowClass_ShortDescription")]
        [StringLength(256)]
        public string ShortDescription { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_WorkflowClass_Description")]
        [StringLength(1024)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the bap entity assembly.
        /// </summary>
        /// <value>The bap entity assembly.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_WorkflowClass_BapEntityAssembly")]
        [StringLength(1024)]
        public string BapEntityAssembly { get; set; }

        /// <summary>
        /// Gets or sets the bap entity class.
        /// </summary>
        /// <value>The bap entity class.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_WorkflowClass_BapEntityClass")]
        [StringLength(1024)]
        public string BapEntityClass { get; set; }

        /// <summary>
        /// Gets or sets the scheduled task identifier.
        /// </summary>
        /// <value>The scheduled task identifier.</value>
        public int? ScheduledTaskId { get; set; }

        /// <summary>
        /// Gets or sets the scheduled task.
        /// </summary>
        /// <value>The scheduled task.</value>
        [ForeignKey("ScheduledTaskId")]
        public ScheduledTask ScheduledTask { get; set; }

        /// <summary>
        /// Type of tenant, currently only Organization is supported.
        /// </summary>
        /// <value>The tenant unit.</value>
        [StringLength(50)]        
        [Index("IX_Tenant", 1)]
        [Index("IX_WorkflowClassName", 2, IsUnique = true)]
        public string TenantUnit { get; set; }

        /// <summary>
        /// Tenant identifier, in fact Organization Id for a moment.
        /// </summary>
        /// <value>The tenant unit identifier.</value>
        [Index("IX_Tenant", 2)]
        [Index("IX_WorkflowClassName", 3, IsUnique = true)]
        public int? TenantUnitId { get; set; }

        /// <summary>
        /// Date and time when entity was first inserted into system's DB.
        /// </summary>
        /// <value>The create date.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_WorkflowClass_CreateDate")]
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
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_WorkflowClass_LastModifiedDate")]
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
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_WorkflowClass_CreatedByUserName")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]//[dbo].[ufnGetUserName]([CreatedBy])
        public string CreatedByUserName { get; private set; }

        /// <summary>
        /// Gets the last name of the modified by user.
        /// </summary>
        /// <value>The last name of the modified by user.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_WorkflowClass_LastModifiedByUserName")]
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
        /// Bitmask holding data what types of permissions are allowed over this types of entity.
        /// </summary>
        /// <value>The owner permissions.</value>
        [Index]
        [DefaultValue(2072079)]
        public int OwnerPermissions { get; set; }

        /// <summary>
        /// Gets or sets the actions.
        /// </summary>
        /// <value>The actions.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_WorkflowClass_Actions")]
        public List<WorkflowAction> Actions { get; set; }

        /// <summary>
        /// Gets or sets the stages.
        /// </summary>
        /// <value>The stages.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_WorkflowClass_Stages")]
        public List<WorkflowStage> Stages { get; set; }

        /// <summary>
        /// Gets or sets the transitions.
        /// </summary>
        /// <value>The transitions.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_WorkflowClass_Transitions")]
        public List<WorkflowStageTransition> Transitions { get; set; }

        /// <summary>
        /// Gets or sets the allowed roles.
        /// </summary>
        /// <value>The allowed roles.</value>
        [Display(ResourceType = typeof(BAP.Resources.Resources), Name = "FieldLabel_WorkflowClass_AllowedRoles")]
        public string AllowedRoles { get; set; }
    }
}
