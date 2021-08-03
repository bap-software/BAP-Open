// ***********************************************************************
// Assembly         : BAP.DAL
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="ScheduledTask.cs" company="BAP Software Ltd.">
//     Copyright © 2015 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using BAP.Common;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BAP.DAL.Entities
{
    /// <summary>
    /// Class ScheduledTask.
    /// Implements the <see cref="BAP.Common.IBapEntity" />
    /// Implements the <see cref="BAP.Common.IBapEntityWithState" />
    /// </summary>
    /// <seealso cref="BAP.Common.IBapEntity" />
    /// <seealso cref="BAP.Common.IBapEntityWithState" />
    [EntityPaging]
    [Table("ScheduledTask")]
    public class ScheduledTask : IBapEntity, IBapEntityWithState
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
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_ScheduledTask_Name")]
        [StringLength(256)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the short name.
        /// </summary>
        /// <value>The short name.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_ScheduledTask_ShortName")]
        [StringLength(64)]
        [Required]
        public string ShortName { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_ScheduledTask_Description")]
        [StringLength(1024)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        /// <value>The unique identifier.</value>
        [Index("IX_ScheduledTaskUniqueId", 1, IsUnique = true)]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_ScheduledTask_UniqueId")]
        [StringLength(64)]
        public string UniqueId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ScheduledTask"/> is recurring.
        /// </summary>
        /// <value><c>true</c> if recurring; otherwise, <c>false</c>.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_ScheduledTask_Recurring")]
        public bool Recurring { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ScheduledTask"/> is running.
        /// </summary>
        /// <value><c>true</c> if running; otherwise, <c>false</c>.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_ScheduledTask_Running")]
        public bool Running { get; set; }

        /// <summary>
        /// Gets or sets the executions.
        /// </summary>
        /// <value>The executions.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_ScheduledTask_Executions")]
        public int Executions { get; set; }

        /// <summary>
        /// Gets or sets the last run.
        /// </summary>
        /// <value>The last run.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_ScheduledTask_LastRun")]
        public DateTime? LastRun { get; set; }

        /// <summary>
        /// Gets or sets the next run.
        /// </summary>
        /// <value>The next run.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_ScheduledTask_NextRun")]
        public DateTime? NextRun { get; set; }

        /// <summary>
        /// Gets or sets the interval.
        /// </summary>
        /// <value>The interval.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_ScheduledTask_Interval")]
        public string Interval { get; set; }

        /// <summary>
        /// Gets or sets the job class.
        /// </summary>
        /// <value>The job class.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_ScheduledTask_JobClass")]
        [Required]
        public string JobClass { get; set; }

        /// <summary>
        /// Gets or sets the job assembly.
        /// </summary>
        /// <value>The job assembly.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_ScheduledTask_JobAssembly")]
        [Required]
        public string JobAssembly { get; set; }

        /// <summary>
        /// Gets or sets the job data.
        /// </summary>
        /// <value>The job data.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_ScheduledTask_JobData")]
        public string JobData { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [last result].
        /// </summary>
        /// <value><c>true</c> if [last result]; otherwise, <c>false</c>.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_ScheduledTask_LastResult")]
        public bool LastResult { get; set; }

        /// <summary>
        /// Gets or sets the last message.
        /// </summary>
        /// <value>The last message.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_ScheduledTask_LastMessage")]
        public string LastMessage { get; set; }

        /// <summary>
        /// Gets or sets the enabled.
        /// </summary>
        /// <value>The enabled.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_ScheduledTask_Enabled")]
        public Boolean Enabled { get; set; }

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
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_ScheduledTask_CreateDate")]
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
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_ScheduledTask_LastModifiedDate")]
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
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_ScheduledTask_CreatedByUserName")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string CreatedByUserName { get; private set; }

        /// <summary>
        /// Gets the last name of the modified by user.
        /// </summary>
        /// <value>The last name of the modified by user.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_ScheduledTask_LastModifiedByUserName")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string LastModifiedByUserName { get; private set; }

        /// <summary>
        /// Bitmask holding data what roles are allowed to access this type of entity.
        /// </summary>
        /// <value>The owner group.</value>
        [Index]
        [DefaultValue(107)]
        public int OwnerGroup { get; set; }

        /// <summary>
        /// Gets or sets the owner permissions.
        /// </summary>
        /// <value>The owner permissions.</value>
        [Index]
        [DefaultValue(1344013)]
        public int OwnerPermissions { get; set; }
    }
}