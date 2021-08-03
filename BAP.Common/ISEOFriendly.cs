// ***********************************************************************
// Assembly         : BAP.Common
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="ISEOFriendly.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq.Expressions;

namespace BAP.Common
{
    /// <summary>
    /// Interface ISEOFriendly
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISEOFriendly<T> where T : class, IBapEntity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        int Id { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        string Name { get; set; }
        /// <summary>
        /// Gets the public identifier.
        /// </summary>
        /// <returns>System.String.</returns>
        string GetPublicId();
        /// <summary>
        /// Bies the public identifier expression.
        /// </summary>
        /// <param name="pid">The pid.</param>
        /// <returns>Func&lt;T, System.Boolean&gt;.</returns>
        Expression<Func<T, bool>> ByPublicIdExpression(string pid);
    }
}
