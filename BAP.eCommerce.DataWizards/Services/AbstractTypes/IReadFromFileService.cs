// ***********************************************************************
// Assembly         : BAP.eCommerce.DataWizards
// Author           : Victor Mamray
// Created          : 05-24-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="IReadFromFileService.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using BAP.FileSystem;

namespace BAP.eCommerce.DataWizards.Services.AbstractTypes
{
    /// <summary>
    /// Interface IReadFromFileService
    /// </summary>
    public interface IReadFromFileService
    {

        // <summary> reads file and returns string
        /// <summary>
        /// Reads the file.
        /// </summary>
        /// <param name="bapFile">The bap file.</param>
        /// <returns>System.String.</returns>
        string ReadFile(BAPFileInfo bapFile);
    }
}
