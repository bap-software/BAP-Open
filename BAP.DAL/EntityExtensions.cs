// ***********************************************************************
// Assembly         : BAP.DAL
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="EntityExtensions.cs" company="BAP Software Ltd.">
//     Copyright © 2015 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using BAP.Common;

namespace BAP.DAL
{
    /// <summary>
    /// Class EntityExtensions.
    /// </summary>
    internal static class EntityExtensions
    {
        /// <summary>
        /// Method is to assign entity instance with dates
        /// </summary>
        /// <param name="entity">Application entity instance (e.g. Organization, Property, etc.)</param>
        internal static void InitDates(this IBapEntity entity)
        {
            if(entity == null)
                return;

            if (!entity.CreateDate.HasValue)
            {
                entity.CreateDate = DateTime.Now; 
            }
                
            entity.LastModifiedDate = DateTime.Now;                       
        }       
    }
}
