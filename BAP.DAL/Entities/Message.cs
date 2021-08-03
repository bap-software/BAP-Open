// ***********************************************************************
// Assembly         : BAP.DAL
// Author           : Victor Mamray
// Created          : 04-23-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 07-21-2020
// ***********************************************************************
// <copyright file="Message.cs" company="BAP Software Ltd.">
//     Copyright © 2015 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
/************************************************************************************************************
Message BAP data model entity
Create Date: 12/11/2016 9:13:44 PM
Template Author: Victor (C) 2016
************************************************************************************************************/
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using BAP.Common;

namespace BAP.DAL.Entities
{
    /// <summary>
    /// Class Message.
    /// Implements the <see cref="BAP.Common.IBapEntity" />
    /// Implements the <see cref="BAP.Common.IBapEntityWithState" />
    /// </summary>
    /// <seealso cref="BAP.Common.IBapEntity" />
    /// <seealso cref="BAP.Common.IBapEntityWithState" />
    [EntityPaging]
    [Table("Message")]
    public partial class Message : IBapEntity, IBapEntityWithState
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
        /// Gets or sets from address.
        /// </summary>
        /// <value>From address.</value>
        [Index("IX_MessageUnique", 1, IsUnique = true)]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Message_FromAddress")]
        [StringLength(255)]
        [SortingField]
        public string FromAddress { get; set; }

        /// <summary>
        /// Converts to address.
        /// </summary>
        /// <value>To address.</value>
        [Index("IX_MessageUnique", 2, IsUnique = true)]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Message_ToAddress")]
        [StringLength(255)]
        [SortingField]
        public string ToAddress { get; set; }

        /// <summary>
        /// Gets or sets the copy address.
        /// </summary>
        /// <value>The copy address.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Message_CopyAddress")]
        [StringLength(255)]
        public string CopyAddress { get; set; }

        /// <summary>
        /// Gets or sets the black copy address.
        /// </summary>
        /// <value>The black copy address.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Message_BlackCopyAddress")]
        [StringLength(255)]
        public string BlackCopyAddress { get; set; }

        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        /// <value>The subject.</value>
        [Index("IX_MessageUnique", 3, IsUnique = true)]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Message_Subject")]
        [StringLength(80)]
        [SortingField]
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>The body.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Message_Body")]
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets the news letter identifier.
        /// </summary>
        /// <value>The news letter identifier.</value>
        public int? NewsLetterId { get; set; }
        /// <summary>
        /// Gets or sets the news letter.
        /// </summary>
        /// <value>The news letter.</value>
        public virtual NewsLetter NewsLetter { get; set; }

        /// <summary>
        /// Gets or sets the subscriber identifier.
        /// </summary>
        /// <value>The subscriber identifier.</value>
        public int? SubscriberId { get; set; }
        /// <summary>
        /// Gets or sets the subscriber.
        /// </summary>
        /// <value>The subscriber.</value>
        public virtual Subscriber Subscriber { get; set; }

        /// <summary>
        /// Gets or sets the object.
        /// </summary>
        /// <value>The object.</value>
        [StringLength(255)]
        [SortingField]
        public string Object { get; set; }

        /// <summary>
        /// Gets or sets the object identifier.
        /// </summary>
        /// <value>The object identifier.</value>
        public int ObjectId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Message"/> is sent.
        /// </summary>
        /// <value><c>null</c> if [sent] contains no value, <c>true</c> if [sent]; otherwise, <c>false</c>.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Message_Sent")]
        [SortingField]
        public bool? Sent { get; set; }

        /// <summary>
        /// Gets or sets the sent date.
        /// </summary>
        /// <value>The sent date.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Message_SentDate")]
        public DateTime? SentDate { get; set; }

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
        [Index("IX_MessageUnique", 4, IsUnique = true)]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Message_CreateDate")]
        [SortingField]
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
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Message_LastModifiedDate")]
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
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Message_CreatedByUserName")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]//[dbo].[ufnGetUserName]([CreatedBy])
        public string CreatedByUserName { get; private set; }

        /// <summary>
        /// Gets the last name of the modified by user.
        /// </summary>
        /// <value>The last name of the modified by user.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Message_LastModifiedByUserName")]
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
        [DefaultValue(896991)]
        public int OwnerPermissions { get; set; }

        /// <summary>
        /// Gets a value indicating whether this instance is HTML.
        /// </summary>
        /// <value><c>true</c> if this instance is HTML; otherwise, <c>false</c>.</value>
        public bool IsHtml
        {
            get
            {
                if(!string.IsNullOrEmpty(Body))
                {
                    string pattern = @"<[^>]*?>";
                    return Regex.IsMatch(Body, pattern);
                }

                return false;
            }
        }
    }
}
