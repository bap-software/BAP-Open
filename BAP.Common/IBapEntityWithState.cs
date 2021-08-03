// ***********************************************************************
// Assembly         : BAP.Common
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="IBapEntityWithState.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.Common
{
    /// <summary>
    /// Enumerates possible states of disconnected BAP entity.
    /// </summary>
    public enum BAPEntityState
    {
        /// <summary>
        /// The unchanged
        /// </summary>
        Unchanged,
        /// <summary>
        /// The added
        /// </summary>
        Added,
        /// <summary>
        /// The modified
        /// </summary>
        Modified,
        /// <summary>
        /// The deleted
        /// </summary>
        Deleted,
        /// <summary>
        /// The processed
        /// </summary>
        Processed
    }

    /// <summary>
    /// Interface applied to those BAP entities where explicit manipulation with EF entity status is required.
    /// </summary>
    public interface IBapEntityWithState
    {
        /// <summary>
        /// State of the BAP entity in terms of EF context.
        /// </summary>
        /// <value>The state of the entity.</value>
        BAPEntityState EntityState { get; set; }
    }
}
