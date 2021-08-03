// ***********************************************************************
// Assembly         : BAP.Common
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="EntityHelper.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace BAP.Common
{
    /// <summary>
    /// Class EntityHelper.
    /// Implements the <see cref="BAP.Common.IEntityHelper{T}" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="BAP.Common.IEntityHelper{T}" />
    public class EntityHelper<T> : IEntityHelper<T> where T: class, IBapEntity
    {
        /// <summary>
        /// Return list of properties of the given entity instance
        /// </summary>
        /// <returns>IList&lt;PropertyInfo&gt;.</returns>
        public IList<PropertyInfo> GetEntityFields()
        {
            List<PropertyInfo> result = new List<PropertyInfo>();
            Type entityType = typeof(T);
            result.AddRange(entityType.GetProperties());

            return result;
        }

        /// <summary>
        /// Return list of sorting fields for the given entity
        /// </summary>
        /// <returns>IList&lt;SortingField&gt;.</returns>
        public IList<SortingField> GetSortFields()
        {
            List<SortingField> result = new List<SortingField>();
            Type entityType = typeof (T);
            PropertyInfo[] fieldInfo = entityType.GetProperties();
            foreach (PropertyInfo field in fieldInfo)
            {
                var attr = field.GetCustomAttribute<SortingFieldAttribute>();
                if (attr != null)
                {
                    var item = new SortingField
                    {
                        Label = field.Name,
                        Attribute = attr,
                        Field = field
                    };

                    var displayAttr = field.GetCustomAttribute<DisplayAttribute>();
                    if (displayAttr != null && !string.IsNullOrEmpty(displayAttr.GetName()))
                    {
                        item.Label = displayAttr.GetName();
                    }
                    result.Add(item);
                }
                    
            }

            return result;
        }

        /// <summary>
        /// Gets the sorting field.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns>SortingField.</returns>
        public SortingField GetSortingField(string fieldName)
        {
            SortingField result = null;
            Type entityType = typeof(T);
            PropertyInfo fieldInfo = entityType.GetProperty(fieldName);
            var attr = fieldInfo.GetCustomAttribute<SortingFieldAttribute>();
            if (attr != null)
            {
                result = new SortingField
                {
                    Label = fieldInfo.Name,
                    Attribute = attr,
                    Field = fieldInfo
                };

                var displayAttr = fieldInfo.GetCustomAttribute<DisplayAttribute>();
                if (displayAttr != null && !string.IsNullOrEmpty(displayAttr.GetName()))
                {
                    result.Label = displayAttr.GetName();
                }                
            }
            return result;
        }

        /// <summary>
        /// Gets the default sort expression.
        /// </summary>
        /// <returns>System.String.</returns>
        public string GetDefaultSortExpression()
        {
            var result = "Id";
            var sortFields = GetSortFields();
            var defaultSort = sortFields.LastOrDefault(f => f.Attribute.IsDefault);
            if (defaultSort != null)
            {
                result = defaultSort.Field.Name;
                if (!string.IsNullOrEmpty(defaultSort.Attribute.ChildFieldName))
                    result += "." + defaultSort.Attribute.ChildFieldName;
                if (defaultSort.Attribute.IsDefaultDesc)
                    result += " DESC";
            }

            return result;
        }

        /// <summary>
        /// Adjusts the sort expression.
        /// </summary>
        /// <param name="sortExpression">The sort expression.</param>
        /// <returns>System.String.</returns>
        public string AdjustSortExpression(string sortExpression)
        {
            var result = string.Empty;
            if (string.IsNullOrEmpty(sortExpression))
                return result;

            var parts = sortExpression.Split("-".ToCharArray());
            var sortField = GetSortingField(parts[0]);

            if(sortField != null)
            {
                result = parts[0];
                if (!string.IsNullOrEmpty(sortField.Attribute.ChildFieldName))
                    result += "." + sortField.Attribute.ChildFieldName;

                result += " " + parts[1];
            }
            return result;
        }

        /// <summary>
        /// Returns page size for the given entity. If no paging allowed returns -1
        /// </summary>
        /// <returns>System.Int32.</returns>
        public int GetEntityPageSize()
        {
            int result = -1;
            EntityPagingAttribute pageAttr = (EntityPagingAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(EntityPagingAttribute));
            if (pageAttr != null && pageAttr.Applied && pageAttr.PageSize > 0)
            {
                result = pageAttr.PageSize;
            }

            return result;
        }

        /// <summary>
        /// Returns list of criteria fields of the given BAP entity type
        /// </summary>
        /// <returns>List of class properties</returns>
        public IList<PropertyInfo> GetCriteriaFields()
        {
            Type entityType = typeof(T);
            return entityType.GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(CriteriaFieldAttribute))).ToList();            
        }
    }
}
