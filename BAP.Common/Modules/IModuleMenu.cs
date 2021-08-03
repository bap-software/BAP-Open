// ***********************************************************************
// Assembly         : BAP.Common
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-17-2020
// ***********************************************************************
// <copyright file="IModuleMenu.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.Common.Modules
{
    /// <summary>
    /// Describes position of the module menu (top, bottom, left and right) on the correspoding page.
    /// </summary>
    public enum ModuleMenuPosition
    {
        /// <summary>
        /// The top
        /// </summary>
        Top = 1,
        /// <summary>
        /// The bottom
        /// </summary>
        Bottom = 2,
        /// <summary>
        /// The left
        /// </summary>
        Left = 3,
        /// <summary>
        /// The right
        /// </summary>
        Right = 4
    }

    /// <summary>
    /// Interface is used to describe module specific menu. Module means significantly large an isolated part of functionality (e.g. eCommerce, Reporting, Marketing).
    /// </summary>
    public interface IModuleMenu
    {
        /// <summary>
        /// Where to put menu on the correspoding page
        /// </summary>
        /// <value>The position.</value>
        ModuleMenuPosition Position { get; }

        /// <summary>
        /// Order number of the menu in the sequence of others.
        /// </summary>
        /// <value>The sort order.</value>
        int? SortOrder { get; }

        /// <summary>
        /// Array of menu items returned by the interface for the given module.
        /// </summary>
        /// <returns>ModuleMenuNode[].</returns>
        ModuleMenuNode[] GetMenu();
    }
}
