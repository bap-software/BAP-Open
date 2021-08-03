// ***********************************************************************
// Assembly         : BAP.FileSystem
// Author           : Victor Mamray
// Created          : 04-20-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="FileProcessorLocalConfig.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.Common
{
    /// <summary>
    /// Class FileProcessorLocalConfig.
    /// </summary>
    public class FileProcessorLocalConfig
    {
        /// <summary>
        /// Gets or sets the base folder.
        /// </summary>
        /// <value>The base folder.</value>
        public string BaseFolder { get; set; } = "/Files/BapApplication/";

        /// <summary>
        /// Gets or sets the public folder.
        /// </summary>
        /// <value>The public folder.</value>
        public string PublicFolder { get; set; } = "/Files/BapApplication/Public/";
    }
}
