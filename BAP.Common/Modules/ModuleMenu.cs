// ***********************************************************************
// Assembly         : BAP.Common
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-17-2020
// ***********************************************************************
// <copyright file="ModuleMenu.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.Common.Modules
{
    /// <summary>
    /// Base abstract class implementing IModuleMenu interface.
    /// </summary>
    public abstract class ModuleMenu : IModuleMenu
    {
        /// <summary>
        /// Where to put menu on the correspoding page
        /// </summary>
        /// <value>The position.</value>
        public virtual ModuleMenuPosition Position
        {
            get
            {
                return ModuleMenuPosition.Top;
            }            
        }

        /// <summary>
        /// Order number of the menu in the sequence of others.
        /// </summary>
        /// <value>The sort order.</value>
        public virtual int? SortOrder
        {
            get
            {
                return null;
            }            
        }
        /// <summary>
        /// Gets the menu.
        /// </summary>
        /// <returns>ModuleMenuNode[].</returns>
        public abstract ModuleMenuNode[] GetMenu();        
    }
}
