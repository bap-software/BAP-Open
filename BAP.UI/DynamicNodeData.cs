// ***********************************************************************
// Assembly         : BAP.UI
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="DynamicNodeData.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using BAP.Common.Modules;

namespace BAP.UI
{
    /// <summary>
    /// Class DynamicNodeData.
    /// </summary>
    public static class DynamicNodeData
    {
        /// <summary>
        /// The data processed
        /// </summary>
        static bool _dataProcessed = false;
        /// <summary>
        /// The nodes
        /// </summary>
        static List<ModuleMenuNode> _nodes = new List<ModuleMenuNode>();

        /// <summary>
        /// Gets the menu nodes.
        /// </summary>
        /// <value>The menu nodes.</value>
        public static List<ModuleMenuNode> MenuNodes
        {
            get
            {
                return _nodes;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [data processed].
        /// </summary>
        /// <value><c>true</c> if [data processed]; otherwise, <c>false</c>.</value>
        public static bool DataProcessed
        {
            get
            {
                return _dataProcessed;
            }
            set
            {
                _dataProcessed = value;
            }
        }
    }
}