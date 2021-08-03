// ***********************************************************************
// Assembly         : BAP.Workflow
// Author           : Victor Mamray
// Created          : 05-27-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="StageTransition.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;

using BAP.Common;
using BAP.DAL.Entities;

namespace BAP.Workflow
{
    /// <summary>
    /// Enum TransitionState
    /// </summary>
    public enum TransitionState
    {
        /// <summary>
        /// The none
        /// </summary>
        None = 0,   // transition is not yet visible/available in the workflow
        /// <summary>
        /// The available
        /// </summary>
        Available,  // transition is available to the user, but not yet ready to move (stage prerequisities are not met)
        /// <summary>
        /// The ready
        /// </summary>
        Ready,      // transition is ready to move over
        /// <summary>
        /// The done
        /// </summary>
        Done        // transtion performed already
    }
    /// <summary>
    /// Class TransitionAttachment.
    /// </summary>
    public class TransitionAttachment
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="TransitionAttachment"/> class.
        /// </summary>
        /// <param name="attachment">The attachment.</param>
        public TransitionAttachment(Attachment attachment)
        {
            if (attachment == null)
                return;
            AttachmentId = attachment.Id;
            Title = $"{attachment.Name} ({attachment.AttachmentType})";
            DownloadUrl = attachment.PathUrl;
            CreatedAt = attachment.CreateDate.GetValueOrDefault();
        }
        /// <summary>
        /// Gets or sets the attachment identifier.
        /// </summary>
        /// <value>The attachment identifier.</value>
        public int AttachmentId { get; set; }
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the download URL.
        /// </summary>
        /// <value>The download URL.</value>
        public string DownloadUrl { get; set; }
        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>The created at.</value>
        public DateTime CreatedAt { get; set; }
    }

    /// <summary>
    /// Class StageTransition.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class StageTransition<T> where T : class, IBapEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        /// <value>The unique identifier.</value>
        public string UniqueId { get; set; }
        /// <summary>
        /// Gets or sets the meta identifier.
        /// </summary>
        /// <value>The meta identifier.</value>
        public int MetaId { get; set; }
        /// <summary>
        /// Gets or sets the workflow.
        /// </summary>
        /// <value>The workflow.</value>
        public Workflow<T> Workflow { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the short description.
        /// </summary>
        /// <value>The short description.</value>
        public string ShortDescription { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets from stage.
        /// </summary>
        /// <value>From stage.</value>
        public WorkflowStage<T> FromStage { get; set; }
        /// <summary>
        /// Converts to stage.
        /// </summary>
        /// <value>To stage.</value>
        public WorkflowStage<T> ToStage { get; set; }
        /// <summary>
        /// Converts to stageactions.
        /// </summary>
        /// <value>To stage actions.</value>
        public List<WorkflowAction<T>> ToStageActions { get; set; }
        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        public TransitionState State { get; set; }
        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        /// <value>The comments.</value>
        public string Comments { get; set; }
        /// <summary>
        /// Gets or sets the transitioned at.
        /// </summary>
        /// <value>The transitioned at.</value>
        public DateTime TransitionedAt { get; set; }
        /// <summary>
        /// Gets or sets the name of the transitioned by user.
        /// </summary>
        /// <value>The name of the transitioned by user.</value>
        public string TransitionedByUserName { get; set; }
        /// <summary>
        /// Gets or sets the attachments.
        /// </summary>
        /// <value>The attachments.</value>
        public List<TransitionAttachment> Attachments { get; set; }
    }
}
