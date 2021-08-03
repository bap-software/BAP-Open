// ***********************************************************************
// Assembly         : BAP.Common
// Author           : Victor Mamray
// Created          : 08-17-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-17-2020
// ***********************************************************************
// <copyright file="IWorkflowAction.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.Common
{
    /// <summary>
    /// Public interface of the workflow action
    /// </summary>
    public interface IWorkflowAction
    {
        /// <summary>
        /// Indicates if action has custom attributes
        /// </summary>
        /// <value><c>true</c> if [require custom attributes]; otherwise, <c>false</c>.</value>
        bool RequireCustomAttributes { get; }

        /// <summary>
        /// Gives example of the JSON serialized string of the class with custom attributes of an action
        /// </summary>
        /// <value>The attributes example json.</value>
        string AttributesExampleJson { get; }
    }
}
