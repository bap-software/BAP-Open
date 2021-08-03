// ***********************************************************************
// Assembly         : BAP.Workflow
// Author           : Victor Mamray
// Created          : 06-03-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 07-24-2020
// ***********************************************************************
// <copyright file="WorkflowStage.cs" company="BAP Software Ltd.">
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
    //TODO: prerequisities have to be defined for the stage, these are particular values of the properties 
    //of the given assosiated entity or assosiated documents. When documents are required we may ask to type and count.
    //We may also ask other document (attachment) attributes like create data, revision date, min size or version.    
    /// <summary>
    /// Enum StageState
    /// </summary>
    public enum StageState
    {
        /// <summary>
        /// The none
        /// </summary>
        None = 0, // stage not yet available to the user
        /// <summary>
        /// The open
        /// </summary>
        Open,     // stage is available to the user via available transtion(s)
        /// <summary>
        /// The passed
        /// </summary>
        Passed    // stage has been passed
    }

    /// <summary>
    /// Class WorkflowStage.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class WorkflowStage<T> where T : class, IBapEntity
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
        /// Gets or sets the type of the stage.
        /// </summary>
        /// <value>The type of the stage.</value>
        public StageType StageType { get; set; }

        /// <summary>
        /// Gets or sets the required actions.
        /// </summary>
        /// <value>The required actions.</value>
        public List<WorkflowAction<T>> RequiredActions { get; set; }
        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        public StageState State { get; set; }

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
    }
}
