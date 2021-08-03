// ***********************************************************************
// Assembly         : BAP.Common
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="ILocalizedBL.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.Common
{
    /// <summary>
    /// BL class which works with localizable entities
    /// TODO: has to be refactored to work with new localization mechanism
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ILocalizedBL<T> where T : class, IBapEntity
    {
        /// <summary>
        /// Get full details of the single entity
        /// </summary>
        /// <param name="ofEntity">Passed entity is used as filter, method implementing ths feature should treat this oject apropriatly to call some method of BL class to read full details.</param>
        /// <returns>Entity instance</returns>
        T GetDetails(T ofEntity);

        /// <summary>
        /// Inserts given entity into DB
        /// </summary>
        /// <param name="entity">Entity to insert</param>
        void AddSingleEntity(T entity);
    }
}
