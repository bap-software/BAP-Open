// ***********************************************************************
// Assembly         : BAP.Workflow
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="WorkflowAction.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using BAP.Common;

namespace BAP.Workflow
{
    /// <summary>
    /// Enum ActionType
    /// </summary>
    public enum ActionType
    {
        /// <summary>
        /// The none
        /// </summary>
        None = 0,
        /// <summary>
        /// The initialize
        /// </summary>
        Initialize,
        /// <summary>
        /// The work
        /// </summary>
        Work,
        /// <summary>
        /// The complete
        /// </summary>
        Complete,
        /// <summary>
        /// The cancel
        /// </summary>
        Cancel
    }

    /// <summary>
    /// Enum ActionState
    /// </summary>
    public enum ActionState
    {
        /// <summary>
        /// The none
        /// </summary>
        None = 0,
        /// <summary>
        /// The open
        /// </summary>
        Open,
        /// <summary>
        /// The completed
        /// </summary>
        Completed,
        /// <summary>
        /// The failed
        /// </summary>
        Failed
    }

    /// <summary>
    /// Class WorkflowAction.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class WorkflowAction<T> where T : class, IBapEntity
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
        /// Gets or sets the action assembly.
        /// </summary>
        /// <value>The action assembly.</value>
        public string ActionAssembly { get; set; }
        /// <summary>
        /// Gets or sets the action class.
        /// </summary>
        /// <value>The action class.</value>
        public string ActionClass { get; set; }

        /// <summary>
        /// Gets or sets the type of the action.
        /// </summary>
        /// <value>The type of the action.</value>
        public ActionType ActionType { get; set; }
        /// <summary>
        /// Gets or sets the attributes.
        /// </summary>
        /// <value>The attributes.</value>
        public List<ActionAttribute<T>> Attributes { get; set; }
        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        public ActionState State { get; set; }
        /// <summary>
        /// Gets or sets the opened at.
        /// </summary>
        /// <value>The opened at.</value>
        public DateTime OpenedAt { get; set; }
        /// <summary>
        /// Gets or sets the completed at.
        /// </summary>
        /// <value>The completed at.</value>
        public DateTime CompletedAt { get; set; }
        /// <summary>
        /// Gets or sets the last complete error.
        /// </summary>
        /// <value>The last complete error.</value>
        public string LastCompleteError { get; set; }
    }
}
