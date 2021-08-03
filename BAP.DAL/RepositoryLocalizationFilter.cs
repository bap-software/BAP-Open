// ***********************************************************************
// Assembly         : BAP.DAL
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="RepositoryLocalizationFilter.cs" company="BAP Software Ltd.">
//     Copyright © 2015 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Linq;
using System.Threading;
using System.Reflection;
using System.Collections.Generic;
using PagedList;
using BAP.Common;
using BAP.DAL.ResourceUtils;
using System;
using System.Data.Entity;
using System.Linq.Dynamic;

namespace BAP.DAL
{
    /// <summary>
    /// Injectable class to implement dynamic data localization. It's applied on localizable entities only.
    /// It works with custom resource manager getting localization data from there.
    /// </summary>
    public class RepositoryLocalizationFilter : IRepositoryFilter
    {
        /// <summary>
        /// The resource manager
        /// </summary>
        private readonly BapResourceManager _resManager;

        /// <summary>
        /// Prevents a default instance of the <see cref="RepositoryLocalizationFilter"/> class from being created.
        /// </summary>
        private RepositoryLocalizationFilter()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryLocalizationFilter"/> class.
        /// </summary>
        /// <param name="resManager">The resource manager.</param>
        public RepositoryLocalizationFilter(BapResourceManager resManager)
        {
            _resManager = resManager;
        }

        //TODO: use resource manager, think about other type of smart caching of data processed
        //This class may collect and cache some usage stistics about particular localizable objects and manage theirs cache.
        /// <summary>
        /// Filters the list.
        /// </summary>
        /// <param name="bapEntities">The bap entities.</param>
        /// <returns>IList&lt;IBapEntity&gt;.</returns>
        public IList<IBapEntity> FilterList(IList<IBapEntity> bapEntities)
        {
            if(_resManager == null || bapEntities == null || !bapEntities.Any() 
                || !bapEntities.First().GetType().GetInterfaces().Contains(typeof(ISupportLocalization)))
                return bapEntities;

            LocalizeArray(bapEntities);

            return bapEntities;
        }

        /// <summary>
        /// Filters the on create.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="repo">The repo.</param>
        /// <param name="entities">The entities.</param>
        public void FilterOnCreate<T>(IGenericDataRepository<T> repo, params T[] entities) where T : class, IBapEntity
        {
            var currCulture = Thread.CurrentThread.CurrentUICulture.Name;
            if (CultureHelper.DefaultImplementedCulture.Equals(currCulture, StringComparison.InvariantCultureIgnoreCase))
                return;

            if (_resManager == null || entities == null || !entities.Any() || !entities.First().GetType().GetInterfaces().Contains(typeof(ISupportLocalization)))
                return;

            //Insert of update resources if required
            var localazablePropertyNames = ((ISupportLocalization)entities.First()).LocalizedProperties;
            var resExtender = new BapResManagerExtender(_resManager, _resManager.ConfigHelper);
            foreach(var entity in entities)
            {
                resExtender.UpsertResourceStrings(repo.Context, GetEntityResourcesForUpsert(entity), typeof(RepositoryLocalizationFilter), entity.GetType().Name, entity.Id);                
            }            
        }

        /// <summary>
        /// Filters the on update.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="repo">The repo.</param>
        /// <param name="entities">The entities.</param>
        public void FilterOnUpdate<T>(IGenericDataRepository<T> repo, params T[] entities) where T : class, IBapEntity
        {
            var currCulture = Thread.CurrentThread.CurrentUICulture.Name;
            if (CultureHelper.DefaultImplementedCulture.Equals(currCulture, StringComparison.InvariantCultureIgnoreCase))
                return;

            if (_resManager == null || entities == null || !entities.Any() || !entities.First().GetType().GetInterfaces().Contains(typeof(ISupportLocalization)))
                return;

            //Insert of update resources if required
            var resExtender = new BapResManagerExtender(_resManager, _resManager.ConfigHelper);
            var localazablePropertyNames = ((ISupportLocalization)entities.First()).LocalizedProperties;
            foreach (var entity in entities)
            {
                repo.IsFilteringOn = false;
                var origEntity = repo.GetSingle(a => a.Id == entity.Id);
                repo.IsFilteringOn = true;

                resExtender.UpsertResourceStrings(repo.Context, GetEntityResourcesForUpsert(entity), typeof(RepositoryLocalizationFilter), entity.GetType().Name, entity.Id);
                foreach (var prop in localazablePropertyNames)
                {
                    PropertyInfo propInfo = typeof(T).GetProperty(prop);
                    propInfo.SetValue(entity, propInfo.GetValue(origEntity));                    
                }
            }
        }

        /// <summary>
        /// Filters the paged list.
        /// </summary>
        /// <param name="bapEntities">The bap entities.</param>
        /// <returns>IPagedList&lt;IBapEntity&gt;.</returns>
        public IPagedList<IBapEntity> FilterPagedList(IPagedList<IBapEntity> bapEntities)
        {
            if (_resManager == null || bapEntities == null || !bapEntities.Any() || !bapEntities.First().GetType().GetInterfaces().Contains(typeof(ISupportLocalization)))
                return bapEntities;

            LocalizeArray(bapEntities);
            return bapEntities;
        }

        /// <summary>
        /// Filters the single entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>IBapEntity.</returns>
        public IBapEntity FilterSingleEntity(IBapEntity entity)
        {

            if (_resManager == null || entity == null || !entity.GetType().GetInterfaces().Contains(typeof(ISupportLocalization)))
                return entity;

            LocalizeSingleEntity(entity);
            return entity;
        }


        /// <summary>
        /// Localizes the array.
        /// </summary>
        /// <param name="bapEntities">The bap entities.</param>
        private void LocalizeArray(IEnumerable<IBapEntity> bapEntities)
        {
            foreach (var entity in bapEntities)
            {
                LocalizeSingleEntity(entity);
            }
        }

        /// <summary>
        /// Localizes the single entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        private void LocalizeSingleEntity(IBapEntity entity)
        {
            var localazablePropertyNames = ((ISupportLocalization)entity).LocalizedProperties;
            var entityType = entity.GetType();
            foreach (var prop in localazablePropertyNames)
            {
                PropertyInfo propInfo = entityType.GetProperty(prop);
                if (propInfo == null)
                    continue;

                if(typeof(IBapEntity).IsAssignableFrom(propInfo.PropertyType))
                {
                    var val = propInfo.GetValue(entity);
                    if(val != null)
                        LocalizeSingleEntity(val as IBapEntity);
                }
                else if(propInfo.PropertyType == typeof(string))
                {
                    var resourseKey = EntityPropertyResourceKey(entity, prop);
                    if (resourseKey == null)
                        continue;

                    var propTextVal = _resManager.GetString(resourseKey);
                    if (propTextVal != null)
                    {
                        propInfo.SetValue(entity, propTextVal);
                    }
                }                
            }            
        }

        /// <summary>
        /// Gets the entity resources.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>List&lt;ResourceString&gt;.</returns>
        private List<ResourceString> GetEntityResourcesForUpsert(IBapEntity entity)
        {
            var result = new List<ResourceString>();
            var localazablePropertyNames = ((ISupportLocalization)entity).LocalizedProperties;
            var entityType = entity.GetType();
            foreach (var prop in localazablePropertyNames)
            {
                var resourseKey = EntityPropertyResourceKey(entity, prop);
                if (resourseKey == null)
                    continue;

                PropertyInfo propInfo = entityType.GetProperty(prop);

                // if it's IBapEntity we are not going to upsert it
                if (typeof(IBapEntity).IsAssignableFrom(propInfo.PropertyType))
                    continue;

                // if it's not string type - we are not going to upsert it as well
                if (propInfo.PropertyType != typeof(string))
                    continue;

                var val = propInfo.GetValue(entity);
                if(val != null)
                {
                    result.Add(new ResourceString 
                    { 
                      Locale = Thread.CurrentThread.CurrentUICulture.Name,
                      Key = resourseKey,
                      Value = val.ToString()
                    });
                }
            }

            return result;
        }

        /// <summary>
        /// Entities the property resource key.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="property">The property.</param>
        /// <returns>System.String.</returns>
        private string EntityPropertyResourceKey(IBapEntity entity, string property)
        {
            if (entity == null || entity.Id == 0 || string.IsNullOrEmpty(property))
                return null;

            var entityType = entity.GetType();
            return "EntityProperty_" + entityType.Name + "_" + entity.Id.ToString() + "_" + property;
        }
    }
}
