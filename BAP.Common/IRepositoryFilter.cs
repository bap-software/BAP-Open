// ***********************************************************************
// Assembly         : BAP.Common
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="IRepositoryFilter.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using PagedList;
using System.Collections.Generic;

namespace BAP.Common
{
    /// <summary>
    /// Interface to describe filtering functionality required on basic operations of the repository pattern.
    /// This can be localization funtionality for example.
    /// </summary>
    public interface IRepositoryFilter
    {
        /// <summary>
        /// Filters the single entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>IBapEntity.</returns>
        IBapEntity FilterSingleEntity(IBapEntity entity);
        /// <summary>
        /// Filters the list.
        /// </summary>
        /// <param name="bapEntities">The bap entities.</param>
        /// <returns>IList&lt;IBapEntity&gt;.</returns>
        IList<IBapEntity> FilterList(IList<IBapEntity> bapEntities);
        /// <summary>
        /// Filters the paged list.
        /// </summary>
        /// <param name="bapEntities">The bap entities.</param>
        /// <returns>IPagedList&lt;IBapEntity&gt;.</returns>
        IPagedList<IBapEntity> FilterPagedList(IPagedList<IBapEntity> bapEntities);

        /// <summary>
        /// Filters the on create.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="repo">The repo.</param>
        /// <param name="entities">The entities.</param>
        void FilterOnCreate<T>(IGenericDataRepository<T> repo, params T[] entities) where T : class, IBapEntity;
        /// <summary>
        /// Filters the on update.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="repo">The repo.</param>
        /// <param name="entities">The entities.</param>
        void FilterOnUpdate<T>(IGenericDataRepository<T> repo, params T[] entities) where T : class, IBapEntity;
    }
}
