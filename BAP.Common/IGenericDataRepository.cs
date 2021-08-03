// ***********************************************************************
// Assembly         : BAP.Common
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="IGenericDataRepository.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

using PagedList;
using System.Data.Entity;

namespace BAP.Common
{
    /// <summary>
    /// Interface IGenericDataRepository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericDataRepository<T> where T : class, IBapEntity
    {
        /// <summary>
        /// Executes the SQL.
        /// </summary>
        /// <param name="sql">The SQL.</param>
        /// <param name="parameters">The parameters.</param>
        void ExecSql(string sql, params object[] parameters);
        /// <summary>
        /// Executes the SQL asynchronous.
        /// </summary>
        /// <param name="sql">The SQL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Task.</returns>
        Task ExecSqlAsync(string sql, params object[] parameters);

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>IList&lt;T&gt;.</returns>
        IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties);
        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>Task&lt;IList&lt;T&gt;&gt;.</returns>
        Task<IList<T>> GetAllAsync(params Expression<Func<T, object>>[] navigationProperties);

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>IList&lt;T&gt;.</returns>
        IList<T> GetList(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties);
        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sortByExpression">The sort by expression.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>IList&lt;T&gt;.</returns>
        IList<T> GetList(Expression<Func<T, bool>> where = null, Func<IQueryable<T>, IOrderedQueryable<T>> sortByExpression = null, params Expression<Func<T, object>>[] navigationProperties);

        /// <summary>
        /// Gets the list asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>Task&lt;IList&lt;T&gt;&gt;.</returns>
        Task<IList<T>> GetListAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties);
        /// <summary>
        /// Gets the list asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sortByExpression">The sort by expression.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>Task&lt;IList&lt;T&gt;&gt;.</returns>
        Task<IList<T>> GetListAsync(Expression<Func<T, bool>> where = null, Func<IQueryable<T>, IOrderedQueryable<T>> sortByExpression = null, params Expression<Func<T, object>>[] navigationProperties);


        /// <summary>
        /// Gets the paged list.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="where">The where.</param>
        /// <param name="sortByExpression">The sort by expression.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>IPagedList&lt;T&gt;.</returns>
        IPagedList<T> GetPagedList(int page, int pageSize, Expression<Func<T, bool>> where = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> sortByExpression = null,
            params Expression<Func<T, object>>[] navigationProperties);

        /// <summary>
        /// Gets the paged list asynchronous.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="where">The where.</param>
        /// <param name="sortByExpression">The sort by expression.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>Task&lt;IPagedList&lt;T&gt;&gt;.</returns>
        Task<IPagedList<T>> GetPagedListAsync(int page, int pageSize, Expression<Func<T, bool>> where = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> sortByExpression = null,
            params Expression<Func<T, object>>[] navigationProperties);

        /// <summary>
        /// Counts the specified where.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <returns>System.Int32.</returns>
        int Count(Expression<Func<T, bool>> where = null);
        /// <summary>
        /// Counts the asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        Task<int> CountAsync(Expression<Func<T, bool>> where = null);

        /// <summary>
        /// Gets the single.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>T.</returns>
        T GetSingle(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties);
        /// <summary>
        /// Gets the single asynchronous.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        Task<T> GetSingleAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties);

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>T.</returns>
        T GetById(object id, params Expression<Func<T, object>>[] navigationProperties);
        /// <summary>
        /// Gets the by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        Task<T> GetByIdAsync(object id, params Expression<Func<T, object>>[] navigationProperties);

        /// <summary>
        /// Gets the current user identifier.
        /// </summary>
        /// <returns>System.String.</returns>
        string GetCurrentUserId();
        /// <summary>
        /// Initializes the entity data.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void InitEntityData(T entity);
        /// <summary>
        /// Adds the specified items.
        /// </summary>
        /// <param name="items">The items.</param>
        void Add(params T[] items);
        /// <summary>
        /// Updates the specified items.
        /// </summary>
        /// <param name="items">The items.</param>
        void Update(params T[] items);
        /// <summary>
        /// Removes the specified items.
        /// </summary>
        /// <param name="items">The items.</param>
        void Remove(params T[] items);

        /// <summary>
        /// Attaches if detached.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void AttachIfDetached(T entity);
        /// <summary>
        /// Detaches the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Detach(T entity);

        /// <summary>
        /// Determines whether [is allowed to read].
        /// </summary>
        /// <returns><c>true</c> if [is allowed to read]; otherwise, <c>false</c>.</returns>
        bool IsAllowedToRead();
        /// <summary>
        /// Determines whether [is allowed to write] [the specified entity].
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if [is allowed to write] [the specified entity]; otherwise, <c>false</c>.</returns>
        bool IsAllowedToWrite(T entity = null);
        /// <summary>
        /// Determines whether [is allowed to delete] [the specified entity].
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if [is allowed to delete] [the specified entity]; otherwise, <c>false</c>.</returns>
        bool IsAllowedToDelete(T entity = null);
        /// <summary>
        /// Permissions the appplied.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="flag">The flag.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool PermissionAppplied(T entity, int flag);
        /// <summary>
        /// Sets the permission.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="flag">The flag.</param>
        void SetPermission(T entity, int flag);
        /// <summary>
        /// Unsets the permission.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="flag">The flag.</param>
        void UnsetPermission(T entity, int flag);
        /// <summary>
        /// Fixes the state of the entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void FixEntityState(T entity);
        /// <summary>
        /// Disallows the modify.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="property">The property.</param>
        void DisallowModify(T entity, string property);
        /// <summary>
        /// Gets the context.
        /// </summary>
        /// <value>The context.</value>
        DbContext Context { get; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is filtering on.
        /// </summary>
        /// <value><c>true</c> if this instance is filtering on; otherwise, <c>false</c>.</value>
        bool IsFilteringOn { get; set; }
    }
}
