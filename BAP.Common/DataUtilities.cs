// ***********************************************************************
// Assembly         : BAP.Common
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="DataUtilities.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Data.Entity;

namespace BAP.Common
{
    /// <summary>
    /// Class DataUtilities.
    /// </summary>
    public static class DataUtilities
    {
        /// <summary>
        /// Converts the state.
        /// </summary>
        /// <param name="state">The state.</param>
        /// <returns>EntityState.</returns>
        public static EntityState ConvertState(BAPEntityState state)
        {
            switch (state)
            {
                case BAPEntityState.Added:
                    return EntityState.Added;
                case BAPEntityState.Modified:
                    return EntityState.Modified;
                case BAPEntityState.Deleted:
                    return EntityState.Deleted;
                default:
                    return EntityState.Unchanged;
            }
        }
    }
}
