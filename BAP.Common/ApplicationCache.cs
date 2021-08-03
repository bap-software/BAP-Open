// ***********************************************************************
// Assembly         : BAP.Common
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-17-2020
// ***********************************************************************
// <copyright file="ApplicationCache.cs" company="BAP Software Ltd.">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Web.Mvc;
using System.Web.Caching;
using System.Collections.Generic;

using Newtonsoft.Json;
using StackExchange.Redis;
using System.Web;
using System.Reflection;

namespace BAP.Common
{
    /// <summary>
    /// Class RedisKeyNames.
    /// </summary>
    public class RedisKeyNames
    {
        /// <summary>
        /// The parent key prefix
        /// </summary>
        internal static string ParentKeyPrefix = "BAP.";
        /// <summary>
        /// The cache key
        /// </summary>
        public static string CacheKey = ParentKeyPrefix + "cache";
    }

    public interface IApplicationCache
    {
        object GetItem(string key);
        void SetItem(string key, object value);
        void ClearAll();
        void Clear(string key);
    }

    /// <summary>
    /// Class ApplicationCache.
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class ApplicationCache : IDisposable, IApplicationCache
    {
        /// <summary>
        /// Class CacheItem.
        /// </summary>
        private class CacheItem
        {
            /// <summary>
            /// Gets or sets the key.
            /// </summary>
            /// <value>The key.</value>
            public string Key { get; set; }
            /// <summary>
            /// Gets or sets the last saved.
            /// </summary>
            /// <value>The last saved.</value>
            public DateTime LastSaved { get; set; }
            /// <summary>
            /// Gets or sets the item.
            /// </summary>
            /// <value>The item.</value>
            public object Item { get; set; }
        }

        /// <summary>
        /// The configuration helper
        /// </summary>
        IConfigHelper _configHelper;
        /// <summary>
        /// The cache
        /// </summary>
        Cache _cache = null;
        /// <summary>
        /// The is cache
        /// </summary>
        bool _isCache = false;
        /// <summary>
        /// The is redis cache
        /// </summary>
        bool _isRedisCache = false;
        /// <summary>
        /// The redis connection
        /// </summary>
        ConnectionMultiplexer _redisConnection;
        /// <summary>
        /// The redis database
        /// </summary>
        IDatabase _redisDatabase;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationCache" /> class.
        /// </summary>
        /// <param name="configHelper">The configuration helper.</param>
        public ApplicationCache(IConfigHelper configHelper)
        {
			_configHelper = configHelper;
			if (_configHelper == null)
				_configHelper = DependencyResolver.Current.GetService<IConfigHelper>();

			if (_configHelper == null || !_configHelper.UseCache)
				return;

			_isCache = _configHelper.UseCache;

			if(_configHelper != null && _configHelper.RedisCacheEanbled)
			{
				_redisConnection = ConnectionMultiplexer.Connect(_configHelper.RedisCacheHost);
				_redisDatabase = _redisConnection.GetDatabase();
				_isRedisCache = true;				
			}
			else
			{
                if(HttpContext.Current != null && HttpContext.Current.Cache != null)
                    _cache = HttpContext.Current.Cache;
                else
				    _cache = new Cache();
			}
            
        }

        public object GetItem(string key)
        {
            if (!_isCache)
                return null;

            if (_isRedisCache)
            {
                var dbValue = _redisDatabase.HashGet(RedisKeyNames.CacheKey, key);
                return ((CacheItem)dbValue.Box()).Item;
            }
            else
            {
                var cacheItem = (CacheItem)_cache[key];
                if (cacheItem != null)
                {
                    if (DateTime.Now.Subtract(cacheItem.LastSaved).TotalSeconds <= _configHelper.CacheExpirationTime)
                        return cacheItem.Item;
                    else
                        _cache.Remove(key);
                }
            }

            return null;
        }

        public void SetItem(string key, object value)
        {
            if (!_isCache)
                return;

            if (_isRedisCache)
            {
                var cacheItem = (CacheItem)(_redisDatabase.HashGet(RedisKeyNames.CacheKey, key).Box());
                if (cacheItem == null)
                    cacheItem = new CacheItem();

                cacheItem.Key = key;
                cacheItem.LastSaved = DateTime.Now;
                cacheItem.Item = value;

                HashEntry entry = new HashEntry(key, JsonConvert.SerializeObject(value));
                _redisDatabase.HashSet(RedisKeyNames.CacheKey, new HashEntry[] { entry });
            }
            else
            {
                var cacheItem = (CacheItem)_cache[key];
                if (cacheItem == null)
                    cacheItem = new CacheItem();

                cacheItem.Key = key;
                cacheItem.LastSaved = DateTime.Now;
                cacheItem.Item = value;

                _cache.Add(key, cacheItem, null, DateTime.Now.AddSeconds(_configHelper.CacheExpirationTime), Cache.NoSlidingExpiration, CacheItemPriority.High, null);
            }

        }

        /// <summary>
        /// Gets or sets the <see cref="System.Object" /> with the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>System.Object.</returns>
        public object this[string key]
        {
            get
            {
                return GetItem(key);
            }
            set
            {
                SetItem(key, value);
            }
        }

        /// <summary>
        /// Clears all items from the cache.
        /// </summary>
        public void ClearAll()
        {
			if (!_isCache)
				return;

			if (_isRedisCache)
			{
				var server = _redisConnection.GetServer(_configHelper.RedisCacheHost);
				if(server != null)
				{
					server.FlushDatabase();
				}
			}
			else
			{                
                var runtimeType = typeof(System.Web.Caching.Cache);

                var ci = runtimeType.GetProperty(
                   "InternalCache",
                   BindingFlags.Instance | BindingFlags.NonPublic);

                var cache = ci.GetValue(HttpRuntime.Cache) as System.Web.Caching.CacheStoreProvider;
                var enumerator = cache.GetEnumerator();
                var keys = new List<string>();
                while (enumerator.MoveNext())
                {
                    keys.Add(enumerator.Key.ToString());
                }
                foreach (string k in keys)
                {
                    cache.Remove(k);
                }
            }            
        }

        /// <summary>
        /// Clears the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        public void Clear(string key)
        {
			if (!_isCache)
				return;

			if (_isRedisCache)
			{
				_redisDatabase.KeyDelete(key);
			}
			else
			{
				var item = _cache[key];
				if (item != null && item is CacheItem && ((CacheItem)item).Key == key)
				{
					_cache.Remove(key);
				}                
            }            
        }

        /// <summary>
        /// The disposed
        /// </summary>
        private bool _disposed = false;
        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
		{
			if (!this._disposed)
			{
				if (disposing)
				{
					if (_redisConnection != null)
						_redisConnection.Dispose();					
				}
			}
			this._disposed = true;
		}

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
