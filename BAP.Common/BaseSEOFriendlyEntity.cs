// ***********************************************************************
// Assembly         : BAP.Common
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="BaseSEOFriendlyEntity.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace BAP.Common
{
    /// <summary>
    /// Class BaseSEOFriendlyEntity.
    /// Implements the <see cref="BAP.Common.ISEOFriendly{T}" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="BAP.Common.ISEOFriendly{T}" />
    public class BaseSEOFriendlyEntity<T> : ISEOFriendly<T> where T : class, IBapEntity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public virtual int Id { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public virtual string Name { get; set; }

        /// <summary>
        /// Bies the public identifier expression.
        /// </summary>
        /// <param name="pid">The pid.</param>
        /// <returns>Func&lt;T, System.Boolean&gt;.</returns>
        public virtual Expression<Func<T, bool>> ByPublicIdExpression(string pid)
        {
            var parts = pid.Split("-".ToCharArray());
            int id = 0;
            Int32.TryParse(parts[0], out id);
            return a => a.Id == id;
        }

        /// <summary>
        /// Gets the public identifier.
        /// </summary>
        /// <returns>System.String.</returns>
        public virtual string GetPublicId()
        {
            return GenerateSlug(Id, Name);
        }

        /// <summary>
        /// Generates the slug.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="text">The text.</param>
        /// <returns>System.String.</returns>
        protected string GenerateSlug(int id, string text)
        {
            string phrase = string.Format("{0}-{1}", id, text);

            string str = RemoveAccent(phrase).ToLower();
            // invalid chars           
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
            // convert multiple spaces into one space   
            str = Regex.Replace(str, @"\s+", " ").Trim();
            // cut and trim 
            str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim();
            str = Regex.Replace(str, @"\s", "-"); // hyphens   
            return str;
        }

        /// <summary>
        /// Removes the accent.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>System.String.</returns>
        protected string RemoveAccent(string text)
        {
            byte[] bytes = System.Text.Encoding.GetEncoding("Cyrillic").GetBytes(text);
            return System.Text.Encoding.ASCII.GetString(bytes);
        }
    }
}
