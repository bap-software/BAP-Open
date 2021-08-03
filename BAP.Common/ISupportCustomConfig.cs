// ***********************************************************************
// Assembly         : BAP.Common
// Author           : Victor Mamray
// Created          : 04-20-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="ISupportCustomConfig.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace BAP.Common
{
    /// <summary>
    /// Interface ISupportCustomConfig
    /// </summary>
    public interface ISupportCustomConfig
    {
        /// <summary>
        /// Gets a value indicating whether [supports custom configuration].
        /// </summary>
        /// <value><c>true</c> if [supports custom configuration]; otherwise, <c>false</c>.</value>
        bool SupportsCustomConfig { get; }

        /// <summary>
        /// Gets the custom configuration json example.
        /// </summary>
        /// <value>The custom configuration json example.</value>
        string CustomConfigJsonExample { get; }

        /// <summary>
        /// Updates the configuration.
        /// </summary>
        /// <param name="json">The json.</param>
        void UpdateConfig(string json);

        /// <summary>
        /// Resets to default.
        /// </summary>
        void ResetToDefault();

        /// <summary>
        /// Gets the type of the custom configuration.
        /// </summary>
        /// <value>The type of the custom configuration.</value>
        Type CustomConfigType { get; }

        /// <summary>
        /// Gets the current custom configuration json.
        /// </summary>
        /// <value>The current custom configuration json.</value>
        string CurrentCustomConfigJson { get; }
    }
}
