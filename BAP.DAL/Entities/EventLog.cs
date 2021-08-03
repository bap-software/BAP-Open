// ***********************************************************************
// Assembly         : BAP.DAL
// Author           : Victor Mamray
// Created          : 04-26-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="EventLog.cs" company="BAP Software Ltd.">
//     Copyright © 2015 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
/************************************************************************************************************
EventLog - data model entity writing event into DB
Create Date: 4/19/2016 4:11:55 PM
Template Author: Victor Mamray (C) 2016
************************************************************************************************************/
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BAP.Common;
using System.ComponentModel;

namespace BAP.DAL.Entities
{
    /// <summary>
    /// Class EventLog.
    /// Implements the <see cref="BAP.Common.IBapEntity" />
    /// Implements the <see cref="BAP.Common.IFullTextSearchable" />
    /// Implements the <see cref="BAP.Common.IBapEntityWithState" />
    /// </summary>
    /// <seealso cref="BAP.Common.IBapEntity" />
    /// <seealso cref="BAP.Common.IFullTextSearchable" />
    /// <seealso cref="BAP.Common.IBapEntityWithState" />
    [EntityPaging]    
    [Table("EventLog")]
    public partial class EventLog : IBapEntity, IFullTextSearchable, IBapEntityWithState
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
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_EventLog_Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the type of the event.
        /// </summary>
        /// <value>The type of the event.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_EventLog_EventType")]
        [StringLength(10)]
        [SortingField(true, true, false, false)]
        public string EventType { get; set; }

        /// <summary>
        /// Gets or sets the event time.
        /// </summary>
        /// <value>The event time.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_EventLog_EventTime")]
        [SortingField(isDefault: true, isDefaultDesc: true)]
        public DateTime EventTime { get; set; }


        /// <summary>
        /// Gets or sets the event source.
        /// </summary>
        /// <value>The event source.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_EventLog_EventSource")]
        [StringLength(100)]
        [SortingField(true, true, false, false)]
        public string EventSource { get; set; }


        /// <summary>
        /// Gets or sets the event code.
        /// </summary>
        /// <value>The event code.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_EventLog_EventCode")]
        [StringLength(100)]
        [SortingField(true, true, false, false)]
        public string EventCode { get; set; }

        /// <summary>
        /// Gets or sets the ip address.
        /// </summary>
        /// <value>The ip address.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_EventLog_IpAddress")]
        [StringLength(100)]
        public string IpAddress { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_EventLog_Description")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the event URL.
        /// </summary>
        /// <value>The event URL.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_EventLog_EventUrl")]
        [StringLength(2000)]
        [SortingField(true, true, false, false)]
        public string EventUrl { get; set; }

        /// <summary>
        /// Gets or sets the name of the event machine.
        /// </summary>
        /// <value>The name of the event machine.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_EventLog_EventMachineName")]
        [StringLength(100)]
        public string EventMachineName { get; set; }

        /// <summary>
        /// Gets or sets the event user agent.
        /// </summary>
        /// <value>The event user agent.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_EventLog_EventUserAgent")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string EventUserAgent { get; set; }

        /// <summary>
        /// Gets or sets the event URL referrer.
        /// </summary>
        /// <value>The event URL referrer.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_EventLog_EventUrlReferrer")]
        [StringLength(2000)]
        public string EventUrlReferrer { get; set; }

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
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_EventLog_CreateDate")]
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
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_EventLog_LastModifiedDate")]
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
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_EventLog_CreatedByUserName")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]//[dbo].[ufnGetUserName]([CreatedBy])
        public string CreatedByUserName { get; private set; }

        /// <summary>
        /// Gets the last name of the modified by user.
        /// </summary>
        /// <value>The last name of the modified by user.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_EventLog_LastModifiedByUserName")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]//[dbo].[ufnGetUserName]([LastModifiedBy])
        public string LastModifiedByUserName { get; private set; }

        /// <summary>
        /// Function to return WHERE expression to search for an entity using part of the text specified.
        /// </summary>
        /// <param name="searchValue">Text to search for</param>
        /// <returns>Linq2Sql expression text to search for a given part of text.</returns>
        public string FullTextSearchExpression(string searchValue)
        {
            return string.Format("(EventSource.Contains(\"{0}\") OR EventCode.Contains(\"{0}\") OR Description.Contains(\"{0}\") OR EventUrl.Contains(\"{0}\") OR EventUrlReferrer.Contains(\"{0}\") OR CreatedByUserName.Contains(\"{0}\"))", searchValue);
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
        [DefaultValue(1944095)]
        public int OwnerPermissions { get; set; }
    }
}
