// ***********************************************************************
// Assembly         : BAP.DAL
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="GenericDataRepository.cs" company="BAP Software Ltd.">
//     Copyright © 2015 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Linq.Dynamic;
using System.Threading;
using System.Threading.Tasks;

using PagedList;
using PagedList.EntityFramework;

using BAP.Common;
using BAP.Common.Exceptions;

namespace BAP.DAL
{
    /// <summary>
    /// Class GenericDataRepository.
    /// Implements the <see cref="BAP.Common.IGenericDataRepository{T}" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="BAP.Common.IGenericDataRepository{T}" />
    public class GenericDataRepository<T> : IGenericDataRepository<T> where T : class, IBapEntity
    {
        /// <summary>
        /// The context
        /// </summary>
        internal DbContext _context;
        /// <summary>
        /// The database set
        /// </summary>
        internal DbSet<T> _dbSet;
        /// <summary>
        /// The authentication helper
        /// </summary>
        internal IAuthorizationHelper<T> _authHelper;
        /// <summary>
        /// The settings
        /// </summary>
        protected IConfigHelper _settings;

        /// <summary>
        /// Prevents a default instance of the <see cref="GenericDataRepository{T}"/> class from being created.
        /// </summary>
        private GenericDataRepository()
        {
            _context = null;
            _dbSet = null;
            _authHelper = null;
            _settings = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericDataRepository{T}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="authHelper">The authentication helper.</param>
        /// <param name="settings">The settings.</param>
        public GenericDataRepository(DbContext context, IAuthorizationHelper<T> authHelper, IConfigHelper settings)
        {
            _context = context;
            _dbSet = _context.Set<T>();
            _authHelper = authHelper;
            _settings = settings;
        }

        /// <summary>
        /// Executes the SQL.
        /// </summary>
        /// <param name="sql">The SQL.</param>
        /// <param name="parameters">The parameters.</param>
        public void ExecSql(string sql, params object[] parameters)
        {
            _context.Database.ExecuteSqlCommand(sql, parameters);
        }

        /// <summary>
        /// Gets the context.
        /// </summary>
        /// <value>The context.</value>
        public DbContext Context
        {
            get
            {
                return _context;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is filtering on.
        /// </summary>
        /// <value><c>true</c> if this instance is filtering on; otherwise, <c>false</c>.</value>
        public bool IsFilteringOn { get; set; } = true;

        /// <summary>
        /// execute SQL as an asynchronous operation.
        /// </summary>
        /// <param name="sql">The SQL.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Task.</returns>
        public async Task ExecSqlAsync(string sql, params object[] parameters)
        {
            await _context.Database.ExecuteSqlCommandAsync(sql, parameters);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>IList&lt;T&gt;.</returns>
        public virtual IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {            
            var result = GetAllQuery(navigationProperties).ToList<T>();            
            if (IsFilteringOn && _authHelper.RepositoryFilter != null)
            {
                result = _authHelper.RepositoryFilter.FilterList(result.Select(a => (IBapEntity)a).ToList()).Select(b => (T)b).ToList();
            }
                
            return result;
        }

        /// <summary>
        /// Gets all query.
        /// </summary>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>IQueryable&lt;T&gt;.</returns>
        protected IQueryable<T> GetAllQuery(params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = _dbSet;

            //Apply eager loading
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);

            dbQuery = dbQuery.AsNoTracking();//Don't track any changes for the selected item

            Expression<Func<T, bool>> tenancyFilter = GetTenancyFilter();
            if (tenancyFilter != null)
            {
                dbQuery = dbQuery.Where(tenancyFilter);
            }

            return dbQuery;
        }

        /// <summary>
        /// Gets all query.
        /// </summary>
        /// <param name="sortByExpression">The sort by expression.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>IQueryable&lt;T&gt;.</returns>
        protected IQueryable<T> GetAllQuery(Func<IQueryable<T>, IOrderedQueryable<T>> sortByExpression = null, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = _dbSet;

            //Apply eager loading
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);

            dbQuery = dbQuery.AsNoTracking();//Don't track any changes for the selected item

            Expression<Func<T, bool>> tenancyFilter = GetTenancyFilter();
            if (tenancyFilter != null)
            {
                dbQuery = dbQuery.Where(tenancyFilter);
            }
            
            if (sortByExpression != null)
            {
                dbQuery = sortByExpression(dbQuery);
            }

            return dbQuery;
        }

        /// <summary>
        /// is any as an asynchronous operation.
        /// </summary>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns><c>true</c> if [is any asynchronous] [the specified navigation properties]; otherwise, <c>false</c>.</returns>
        public virtual async Task<bool> IsAnyAsync(params Expression<Func<T, object>>[] navigationProperties)
        {
            return await GetAllQuery(navigationProperties).AnyAsync();
        }

        /// <summary>
        /// get all as an asynchronous operation.
        /// </summary>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>Task&lt;IList&lt;T&gt;&gt;.</returns>
        public virtual async Task<IList<T>> GetAllAsync(params Expression<Func<T, object>>[] navigationProperties)
        {           
            var result = await GetAllQuery(navigationProperties).ToListAsync<T>();
            if (_authHelper.RepositoryFilter != null)
            {
                result = _authHelper.RepositoryFilter.FilterList(result.Select(a => (IBapEntity)a).ToList()).Select(b => (T)b).ToList();
            }

            return result;
        }

        /// <summary>
        /// get all as an asynchronous operation.
        /// </summary>
        /// <param name="sortByExpression">The sort by expression.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>IList&lt;T&gt;.</returns>
        public virtual async Task<IList<T>> GetAllAsync(Func<IQueryable<T>, IOrderedQueryable<T>> sortByExpression = null, params Expression<Func<T, object>>[] navigationProperties)
        {
            var result = await GetAllQuery(sortByExpression, navigationProperties).ToListAsync<T>();
            if (_authHelper.RepositoryFilter != null)
            {
                result = _authHelper.RepositoryFilter.FilterList(result.Select(a => (IBapEntity)a).ToList()).Select(b => (T)b).ToList();
            }

            return result;
        }

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>IList&lt;T&gt;.</returns>
        public virtual IList<T> GetList(string where, params Expression<Func<T, object>>[] navigationProperties)
        {
            return GetList(where, null, navigationProperties);
        }

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sortByExpression">The sort by expression.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>IList&lt;T&gt;.</returns>
        public virtual IList<T> GetList(string where, string sortByExpression, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = GetListQuery(where, sortByExpression, navigationProperties);

            var result = dbQuery.ToList<T>();
            if (_authHelper.RepositoryFilter != null)
            {
                result = _authHelper.RepositoryFilter.FilterList(result.Select(a => (IBapEntity)a).ToList()).Select(b => (T)b).ToList();
            }

            return result;
        }


        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>IList&lt;T&gt;.</returns>
        public virtual IList<T> GetList(Expression<Func<T, bool>> where = null, params Expression<Func<T, object>>[] navigationProperties)
        {
            return GetList(where, null, navigationProperties);
        }

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sortByExpression">The sort by expression.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>IList&lt;T&gt;.</returns>
        public virtual IList<T> GetList(Expression<Func<T, bool>> where = null, Func<IQueryable<T>, IOrderedQueryable<T>> sortByExpression = null, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = GetListQuery(where, sortByExpression, navigationProperties);

            var result = dbQuery.ToList<T>();
            if (IsFilteringOn && _authHelper.RepositoryFilter != null)
            {
                result = _authHelper.RepositoryFilter.FilterList(result.Select(a => (IBapEntity)a).ToList()).Select(b => (T)b).ToList();
            }

            return result;
        }

        /// <summary>
        /// get list as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sortByExpression">The sort by expression.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>IList&lt;T&gt;.</returns>
        public async Task<IList<T>> GetListAsync(string where, string sortByExpression, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = GetListQuery(where, sortByExpression, navigationProperties);
            var result = await dbQuery.ToListAsync<T>();
            if (IsFilteringOn && _authHelper.RepositoryFilter != null)
            {
                result = _authHelper.RepositoryFilter.FilterList(result.Select(a => (IBapEntity)a).ToList()).Select(b => (T)b).ToList();
            }

            return result;
        }

        /// <summary>
        /// get list as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sortByExpression">The sort by expression.</param>
        /// <param name="top">The top.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>IList&lt;T&gt;.</returns>
        public async Task<IList<T>> GetListAsync(string where, string sortByExpression, int top, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = GetListQuery(where, sortByExpression, navigationProperties).Take(top);
            var result = await dbQuery.ToListAsync<T>();
            if (IsFilteringOn && _authHelper.RepositoryFilter != null)
            {
                result = _authHelper.RepositoryFilter.FilterList(result.Select(a => (IBapEntity)a).ToList()).Select(b => (T)b).ToList();
            }

            return result;
        }

        /// <summary>
        /// get list as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>Task&lt;IList&lt;T&gt;&gt;.</returns>
        public async Task<IList<T>> GetListAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            return await GetListAsync(where, "", navigationProperties);
        }

        /// <summary>
        /// get list as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sortByExpression">The sort by expression.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>IList&lt;T&gt;.</returns>
        public async Task<IList<T>> GetListAsync(Expression<Func<T, bool>> where, string sortByExpression = "", params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = GetListQuery(where, sortByExpression, navigationProperties);

            var result = await dbQuery.ToListAsync<T>();
            if (IsFilteringOn && _authHelper.RepositoryFilter != null)
            {
                result = _authHelper.RepositoryFilter.FilterList(result.Select(a => (IBapEntity)a).ToList()).Select(b => (T)b).ToList();
            }

            return result;
        }

        /// <summary>
        /// get list as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sortByExpression">The sort by expression.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>Task&lt;IList&lt;T&gt;&gt;.</returns>
        public async Task<IList<T>> GetListAsync(Expression<Func<T, bool>> where = null, Func<IQueryable<T>, IOrderedQueryable<T>> sortByExpression = null, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = GetListQuery(where, sortByExpression, navigationProperties);

            var result = await dbQuery.ToListAsync<T>();
            if (IsFilteringOn && _authHelper.RepositoryFilter != null)
            {
                result = _authHelper.RepositoryFilter.FilterList(result.Select(a => (IBapEntity)a).ToList()).Select(b => (T)b).ToList();
            }

            return result;
        }

        /// <summary>
        /// Gets the paged list.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="where">The where.</param>
        /// <param name="sortByExpression">The sort by expression.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>IPagedList&lt;T&gt;.</returns>
        public virtual IPagedList<T> GetPagedList(int page, int pageSize, Expression<Func<T, bool>> where = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> sortByExpression = null,
            params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = GetListQuery(where, sortByExpression, navigationProperties);
            var result = dbQuery.ToPagedList(page, pageSize);
            if (IsFilteringOn && _authHelper.RepositoryFilter != null)
            {                
                foreach(var item in result)
                {
                    _authHelper.RepositoryFilter.FilterSingleEntity(item);
                }                
            }

            return result;
        }

        /// <summary>
        /// get paged list as an asynchronous operation.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="where">The where.</param>
        /// <param name="sortByExpression">The sort by expression.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>Task&lt;IPagedList&lt;T&gt;&gt;.</returns>
        public async Task<IPagedList<T>> GetPagedListAsync(int page, int pageSize, Expression<Func<T, bool>> where = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> sortByExpression = null,
            params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = GetListQuery(where, sortByExpression, navigationProperties);
            var result = await dbQuery.ToPagedListAsync(page, pageSize);
            if (IsFilteringOn && _authHelper.RepositoryFilter != null)
            {
                foreach (var item in result)
                {
                    _authHelper.RepositoryFilter.FilterSingleEntity(item);
                }
            }
            return result;
        }


        /// <summary>
        /// Gets the paged list.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="where">The where.</param>
        /// <param name="sortByExpression">The sort by expression.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>IPagedList&lt;T&gt;.</returns>
        public virtual IPagedList<T> GetPagedList(int pageNumber, int pageSize, string where, string sortByExpression, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = GetListQuery(where, sortByExpression, navigationProperties);
            var result = dbQuery.ToPagedList(pageNumber, pageSize);
            if (IsFilteringOn && _authHelper.RepositoryFilter != null)
            {
                foreach (var item in result)
                {
                    _authHelper.RepositoryFilter.FilterSingleEntity(item);
                }
            }
            return result;
        }

        /// <summary>
        /// get paged list as an asynchronous operation.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="where">The where.</param>
        /// <param name="sortByExpression">The sort by expression.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>IPagedList&lt;T&gt;.</returns>
        public async virtual Task<IPagedList<T>> GetPagedListAsync(int pageNumber, int pageSize, string where, string sortByExpression, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = GetListQuery(where, sortByExpression, navigationProperties);
            var result = await dbQuery.ToPagedListAsync(pageNumber, pageSize);
            if (IsFilteringOn && _authHelper.RepositoryFilter != null)
            {
                foreach (var item in result)
                {
                    _authHelper.RepositoryFilter.FilterSingleEntity(item);
                }
            }
            return result;
        }

        /// <summary>
        /// Counts the specified where.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <returns>System.Int32.</returns>
        public virtual int Count(Expression<Func<T, bool>> where = null)
        {
            IQueryable<T> dbQuery = _dbSet;
            int result = 0;
            if (where != null)
                result = _dbSet.Where(where).Count();
            else
                result = _dbSet.Count();
            return result;
        }

        /// <summary>
        /// count as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public async Task<int> CountAsync(Expression<Func<T, bool>> where = null)
        {
            int result;
            if (where != null)
                result = await _dbSet.Where(where).CountAsync();
            else
                result = await _dbSet.CountAsync();
            return result;
        }

        /// <summary>
        /// Gets the list query.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sortByExpression">The sort by expression.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>IQueryable&lt;T&gt;.</returns>
        protected virtual IQueryable<T> GetListQuery(Expression<Func<T, bool>> where = null, Func<IQueryable<T>, IOrderedQueryable<T>> sortByExpression = null, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = _dbSet;

            //Apply eager loading
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);

            dbQuery = dbQuery.AsNoTracking();//Don't track any changes for the selected item

            Expression<Func<T, bool>> tenancyFilter = GetTenancyFilter();
            if (tenancyFilter != null)
            {
                dbQuery = dbQuery.Where(tenancyFilter);
            }
           
            if (where != null)
            {
                dbQuery = dbQuery.Where(where);
            }

            if (sortByExpression != null)
            {
                dbQuery = sortByExpression(dbQuery);
            }

            return dbQuery;
        }

        /// <summary>
        /// Gets the list query.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sortByExpression">The sort by expression.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>IQueryable&lt;T&gt;.</returns>
        protected virtual IQueryable<T> GetListQuery(string where, string sortByExpression, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = _dbSet;

            //Apply eager loading
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);

            dbQuery = dbQuery.AsNoTracking();//Don't track any changes for the selected item

            Expression<Func<T, bool>> tenancyFilter = GetTenancyFilter();
            if (tenancyFilter != null)
            {
                dbQuery = dbQuery.Where(tenancyFilter);
            }
            
            if (!string.IsNullOrEmpty(where))
            {
                dbQuery = dbQuery.Where(where);
            }

            if (!string.IsNullOrEmpty(sortByExpression))
            {
                dbQuery = dbQuery.OrderBy(sortByExpression);
            }

            return dbQuery;
        }

        /// <summary>
        /// Gets the list query.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sortByExpression">The sort by expression.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>IQueryable&lt;T&gt;.</returns>
        protected virtual IQueryable<T> GetListQuery(Expression<Func<T, bool>> where = null, string sortByExpression = "", params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = _dbSet;

            //Apply eager loading
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);

            dbQuery = dbQuery.AsNoTracking();//Don't track any changes for the selected item

            Expression<Func<T, bool>> tenancyFilter = GetTenancyFilter();
            if (tenancyFilter != null)
            {
                dbQuery = dbQuery.Where(tenancyFilter);
            }

            if (where != null)
            {
                dbQuery = dbQuery.Where(where);
            }

            if (!string.IsNullOrEmpty(sortByExpression))
            {
                dbQuery = dbQuery.OrderBy(sortByExpression);
            }

            return dbQuery;
        }

        /// <summary>
        /// Gets the single.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>T.</returns>
        public virtual T GetSingle(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {                        
            var result = GetSingleQuery(where, navigationProperties).FirstOrDefault(where); //Apply where clause;
            if(IsFilteringOn && _authHelper.RepositoryFilter != null)
                return (T)_authHelper.RepositoryFilter.FilterSingleEntity(result);

            return result;
        }

        /// <summary>
        /// Gets the single query.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>IQueryable&lt;T&gt;.</returns>
        protected IQueryable<T> GetSingleQuery(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = _dbSet;

            //Apply eager loading
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);

            dbQuery = dbQuery.AsNoTracking();//Don't track any changes for the selected item

            Expression<Func<T, bool>> tenancyFilter = GetTenancyFilter();
            if (tenancyFilter != null)
            {
                dbQuery = dbQuery.Where(tenancyFilter);
            }

            if (where != null)
            {
                dbQuery = dbQuery.Where(where);
            }

            return dbQuery;
        }

        /// <summary>
        /// get single as an asynchronous operation.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {            
            var result = await GetSingleQuery(where, navigationProperties).FirstOrDefaultAsync(where);
            if (IsFilteringOn && _authHelper.RepositoryFilter != null)
                return (T)_authHelper.RepositoryFilter.FilterSingleEntity(result);
            return result;
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>T.</returns>
        public virtual T GetById(object id, params Expression<Func<T, object>>[] navigationProperties)
        {
            if (id != null)
            {
                int i = 0;
                int.TryParse(id.ToString(), out i);
                var result = GetByIdQuery(id, navigationProperties).SingleOrDefault(a => a.Id == i);
                if (IsFilteringOn && _authHelper.RepositoryFilter != null)
                    return (T)_authHelper.RepositoryFilter.FilterSingleEntity(result);
                return result;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Gets the by identifier query.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>IQueryable&lt;T&gt;.</returns>
        IQueryable<T> GetByIdQuery(object id, params Expression<Func<T, object>>[] navigationProperties)
        {
            int i = 0;
            int.TryParse(id.ToString(), out i);
            IQueryable<T> dbQuery = _dbSet;

            //Apply eager loading
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);

            //Don't track any changes for the selected item
            dbQuery = dbQuery.AsNoTracking();

            //Tenancy filter is the must
            Expression<Func<T, bool>> tenancyFilter = GetTenancyFilter();
            if (tenancyFilter != null)
            {
                dbQuery = dbQuery.Where(tenancyFilter);
            }

            return dbQuery;
        }

        /// <summary>
        /// get by identifier as an asynchronous operation.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="navigationProperties">The navigation properties.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async virtual Task<T> GetByIdAsync(object id, params Expression<Func<T, object>>[] navigationProperties)
        {
            if (id != null)
            {
                int i = 0;
                int.TryParse(id.ToString(), out i);
                var result = await GetByIdQuery(id, navigationProperties).SingleOrDefaultAsync(a => a.Id == i);
                if (IsFilteringOn && _authHelper.RepositoryFilter != null)
                    return (T)_authHelper.RepositoryFilter.FilterSingleEntity(result);
                return result;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the current user identifier.
        /// </summary>
        /// <returns>System.String.</returns>
        public virtual string GetCurrentUserId()
        {
            return _authHelper.GetCurrentUserId();
        }

        /// <summary>
        /// Initializes the entity data.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void InitEntityData(T entity)
        {
            if (entity != null)
            {
                entity.InitDates();
                InitEntityUserData(entity);               
            }
        }

        /// <summary>
        /// Initializes the entity user data.
        /// </summary>
        /// <param name="entity">The entity.</param>
        protected virtual void InitEntityUserData(T entity)
        {
            if (entity == null)
                return;

            var userId = _authHelper.GetCurrentUserId();
            if (string.IsNullOrEmpty(userId))
                userId = _authHelper.PublicUserName;

            //If creating entity
            if (string.IsNullOrEmpty(entity.CreatedBy))
            {
                entity.CreatedBy = userId;

                if (string.IsNullOrEmpty(entity.TenantUnit))
                {
                    var orgId = _authHelper.GetCurrentOrganizationId();
                    entity.TenantUnit = _settings.TenantDbWord;
                    entity.TenantUnitId = orgId;
                }

                if (entity.OwnerGroup == 0)
                    entity.OwnerGroup = _authHelper.GetDefaultRoles();

                if (entity.OwnerPermissions == 0)
                    entity.OwnerPermissions = _authHelper.GetDefaultPermissions();
            }

            entity.LastModifiedBy = userId;
        }

        /// <summary>
        /// Adds the specified items.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <exception cref="BAPAuthorizationException">User is not allowed to add this type of data</exception>
        public virtual void Add(params T[] items)
        {
            //check if legal to proceed
            if (!_authHelper.IsAllowedToWrite())
                throw new BAPAuthorizationException("User is not allowed to add this type of data");

            foreach (T item in items)
            {
                if (typeof(T).GetInterfaces().Contains(typeof(IBapEntityWithState)))
                {
                    var entity = item as IBapEntityWithState;
                    if(entity.EntityState != BAPEntityState.Added && item.Id == 0)
                    {
                        entity.EntityState = BAPEntityState.Added;
                    }
                }
                InitEntityData(item);                
                _context.Entry(item).State = EntityState.Added;
                _dbSet.Add(item);
                if (IsFilteringOn && _authHelper.RepositoryFilter != null)
                    _authHelper.RepositoryFilter.FilterOnCreate<T>(this, item);
            }
        }

        /// <summary>
        /// Updates the specified items.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <exception cref="BAPAuthorizationException">User is not allowed to update this data</exception>
        public virtual void Update(params T[] items)
        {
            foreach (T item in items)
            {
                //check if legal to proceed
                if (!_authHelper.IsAllowedToWrite(item))
                    throw new BAPAuthorizationException("User is not allowed to update this data");

                if (typeof(T).GetInterfaces().Contains(typeof(IBapEntityWithState)))
                {
                    var entity = item as IBapEntityWithState;
                    if (entity.EntityState != BAPEntityState.Modified && item.Id > 0)
                    {
                        entity.EntityState = BAPEntityState.Modified;
                    }
                }
                InitEntityData(item);                
                _context.Entry(item).State = EntityState.Modified;
                if (IsFilteringOn && _authHelper.RepositoryFilter != null)
                    _authHelper.RepositoryFilter.FilterOnUpdate<T>(this, item);
            }
        }

        /// <summary>
        /// Removes the specified items.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <exception cref="BAPAuthorizationException">User is not allowed to delete data</exception>
        public virtual void Remove(params T[] items)
        {
            foreach (T item in items)
            {
                //check if legal to proceed
                if (!_authHelper.IsAllowedToDelete(item))
                    throw new BAPAuthorizationException("User is not allowed to delete data");

                if (typeof(T).GetInterfaces().Contains(typeof(IBapEntityWithState)))
                {
                    var entity = item as IBapEntityWithState;
                    if (entity.EntityState != BAPEntityState.Deleted && item.Id > 0)
                    {
                        entity.EntityState = BAPEntityState.Deleted;
                    }
                }
                _context.Entry(item).State = EntityState.Deleted;
                _dbSet.Remove(item);
            }
        }

        /// <summary>
        /// Attaches if detached.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void AttachIfDetached(T entity)
        {
            if (_context.Entry<T>(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
        }

        /// <summary>
        /// Detaches the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Detach(T entity)
        {
            if (_context.Entry<T>(entity).State != EntityState.Detached)
            {
                _context.Entry<T>(entity).State = EntityState.Detached;
            }
        }

        /// <summary>
        /// Gets the state of the entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>EntityState.</returns>
        public EntityState GetEntityState(T entity)
        {
            return _context.Entry<T>(entity).State;
        }

        /// <summary>
        /// Fixes the state of the entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void FixEntityState(T entity)
        {
            if (typeof(T).GetInterfaces().Contains(typeof(IBapEntityWithState)))
            {
                var entityWithState = entity as IBapEntityWithState;
                _context.Entry<T>(entity).State = DataUtilities.ConvertState(entityWithState.EntityState);
            }
        }

        /// <summary>
        /// Disallows the modify.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="property">The property.</param>
        public void DisallowModify(T entity, string property)
        {
            _context.Entry<T>(entity).Property(property).IsModified = false;
        }

        /// <summary>
        /// Determines whether [is allowed to read].
        /// </summary>
        /// <returns><c>true</c> if [is allowed to read]; otherwise, <c>false</c>.</returns>
        public bool IsAllowedToRead()
        {
            return _authHelper.IsAllowedToRead();
        }

        /// <summary>
        /// Determines whether [is allowed to write] [the specified entity].
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if [is allowed to write] [the specified entity]; otherwise, <c>false</c>.</returns>
        public bool IsAllowedToWrite(T entity = null)
        {
            return _authHelper.IsAllowedToWrite(entity);
        }
        /// <summary>
        /// Determines whether [is allowed to delete] [the specified entity].
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><c>true</c> if [is allowed to delete] [the specified entity]; otherwise, <c>false</c>.</returns>
        public bool IsAllowedToDelete(T entity = null)
        {
            return _authHelper.IsAllowedToDelete(entity);
        }

        /// <summary>
        /// Gets the tenancy filter.
        /// </summary>
        /// <returns>Expression&lt;Func&lt;T, System.Boolean&gt;&gt;.</returns>
        internal Expression<Func<T, bool>> GetTenancyFilter()
        {
            return _authHelper.GetTenancyFilter(_context);
        }

        /// <summary>
        /// Throws if entity does not match filter.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="BAPAuthorizationException">User is not allowed to read data to proceed with this data modification operation.</exception>
        internal void ThrowIfEntityDoesNotMatchFilter(T entity)
        {
            var tenancyFilter = GetTenancyFilter();
            if (tenancyFilter != null)
            {
                var func = tenancyFilter.Compile();
                if (!func(entity))
                    throw new BAPAuthorizationException("User is not allowed to read data to proceed with this data modification operation.");
            }
        }

        /// <summary>
        /// Permissions the appplied.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="flag">The flag.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool PermissionAppplied(T entity, int flag)
        {
            return _authHelper.PermissionAppplied(entity, flag);
        }

        /// <summary>
        /// Sets the permission.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="flag">The flag.</param>
        public void SetPermission(T entity, int flag)
        {
            _authHelper.SetPermission(entity, flag);
        }

        /// <summary>
        /// Unsets the permission.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="flag">The flag.</param>
        public void UnsetPermission(T entity, int flag)
        {
            _authHelper.UnsetPermission(entity, flag);
        }
    }
}
