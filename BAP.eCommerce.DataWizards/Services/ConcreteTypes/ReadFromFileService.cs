// ***********************************************************************
// Assembly         : BAP.eCommerce.DataWizards
// Author           : Victor Mamray
// Created          : 05-24-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="ReadFromFileService.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.IO;

using BAP.FileSystem;
using BAP.eCommerce.DataWizards.Services.AbstractTypes;

namespace BAP.eCommerce.DataWizards.Services.ConcreteTypes
{
    /// <summary>
    /// Class ReadFromFileService.
    /// Implements the <see cref="BAP.eCommerce.DataWizards.Services.AbstractTypes.IReadFromFileService" />
    /// </summary>
    /// <seealso cref="BAP.eCommerce.DataWizards.Services.AbstractTypes.IReadFromFileService" />
    public class ReadFromFileService : IReadFromFileService
    {
        // <summary> reads file and returns string
        /// <summary>
        /// Reads the file.
        /// </summary>
        /// <param name="bapFile">The bap file.</param>
        /// <returns>System.String.</returns>
        public string ReadFile(BAPFileInfo bapFile)
        {
            using (StreamReader sr = new StreamReader(bapFile.FileStream))
            {
                return sr.ReadToEnd();
            }
        }
    }
}
