// ***********************************************************************
// Assembly         : BAP.Common
// Author           : Victor Mamray
// Created          : 06-11-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="MemoryPostedFile.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.IO;
using System.Web;

namespace BAP.Common
{
    /// <summary>
    /// Class MemoryPostedFile.
    /// Implements the <see cref="System.Web.HttpPostedFileBase" />
    /// </summary>
    /// <seealso cref="System.Web.HttpPostedFileBase" />
    public class MemoryPostedFile : HttpPostedFileBase
    {
        /// <summary>
        /// The file bytes
        /// </summary>
        private readonly byte[] fileBytes;
        /// <summary>
        /// The MIME type
        /// </summary>
        private string mimeType;

        /// <summary>
        /// Initializes a new instance of the <see cref="MemoryPostedFile"/> class.
        /// </summary>
        /// <param name="fileBytes">The file bytes.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="mimeType">Type of the MIME.</param>
        public MemoryPostedFile(byte[] fileBytes, string fileName = null, string mimeType = null)
        {
            this.fileBytes = fileBytes;
            this.FileName = fileName;
            this.mimeType = mimeType;
            this.InputStream = new MemoryStream(fileBytes);
        }

        /// <summary>
        /// When overridden in a derived class, gets the size of an uploaded file, in bytes.
        /// </summary>
        /// <value>The length of the content.</value>
        public override int ContentLength => fileBytes.Length;

        /// <summary>
        /// When overridden in a derived class, gets the fully qualified name of the file on the client.
        /// </summary>
        /// <value>The name of the file.</value>
        public override string FileName { get; }

        /// <summary>
        /// When overridden in a derived class, gets a <see cref="T:System.IO.Stream" /> object that points to an uploaded file to prepare for reading the contents of the file.
        /// </summary>
        /// <value>The input stream.</value>
        public override Stream InputStream { get; }

        /// <summary>
        /// When overridden in a derived class, gets the MIME content type of an uploaded file.
        /// </summary>
        /// <value>The type of the content.</value>
        public override string ContentType => mimeType;

        /// <summary>
        /// Saves as.
        /// </summary>
        /// <param name="filename">The filename.</param>
        public override void SaveAs(string filename)
        {
            File.WriteAllBytes(filename, fileBytes);
        }
    }
}
