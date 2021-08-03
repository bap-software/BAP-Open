// ***********************************************************************
// Assembly         : BAP.Common
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-17-2020
// ***********************************************************************
// <copyright file="Attributes.cs" company="BAP Software Ltd.">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace BAP.Common
{
    /// <summary>
    /// Tenant level attribute to describe paging properties
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class EntityPagingAttribute : Attribute
    {
        /// <summary>
        /// The applied
        /// </summary>
        private readonly bool _applied;
        /// <summary>
        /// The page size
        /// </summary>
        private readonly int _pageSize;

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityPagingAttribute" /> class.
        /// </summary>
        /// <param name="applied">if set to <c>true</c> [applied].</param>
        /// <param name="pageSize">Size of the page.</param>
        public EntityPagingAttribute(bool applied = true, int pageSize = 20)
        {
            this._applied = applied;
            this._pageSize = pageSize;
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="EntityPagingAttribute" /> is applied.
        /// </summary>
        /// <value><c>true</c> if applied; otherwise, <c>false</c>.</value>
        public bool Applied
        {
            get
            {
                return _applied;
            }
        }

        /// <summary>
        /// Gets the size of the page.
        /// </summary>
        /// <value>The size of the page.</value>
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
        }
    }

    /// <summary>
    /// Attribute to mark entity field as available for sorting
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class SortingFieldAttribute : Attribute
    {
        /// <summary>
        /// The allow ask
        /// </summary>
        private readonly bool _allowAsk;
        /// <summary>
        /// The allow desc
        /// </summary>
        private readonly bool _allowDesc;
        /// <summary>
        /// The is default
        /// </summary>
        private readonly bool _isDefault;
        /// <summary>
        /// The is default desc
        /// </summary>
        private readonly bool _isDefaultDesc;
        /// <summary>
        /// The child field name
        /// </summary>
        private readonly string _childFieldName;

        /// <summary>
        /// Initializes a new instance of the <see cref="SortingFieldAttribute" /> class.
        /// </summary>
        /// <param name="allowAsc">if set to <c>true</c> [allow asc].</param>
        /// <param name="allowDesc">if set to <c>true</c> [allow desc].</param>
        /// <param name="isDefault">if set to <c>true</c> [is default].</param>
        /// <param name="isDefaultDesc">if set to <c>true</c> [is default desc].</param>
        /// <param name="childFieldName">Name of the child field.</param>
        public SortingFieldAttribute(bool allowAsc = true, bool allowDesc = true, bool isDefault = false, bool isDefaultDesc = false, string childFieldName = "")
        {
            _allowAsk = allowAsc;
            _allowDesc = allowDesc;
            _isDefault = isDefault;
            _isDefaultDesc = isDefaultDesc;
            _childFieldName = childFieldName;
        }

        /// <summary>
        /// Indicates whether ascending sorting is allowed.
        /// </summary>
        /// <value><c>true</c> if [allow ascending]; otherwise, <c>false</c>.</value>
        public bool AllowAscending
        {
            get { return _allowAsk; }
        }

        /// <summary>
        /// Gets a value indicating whether [allow descending].
        /// </summary>
        /// <value><c>true</c> if [allow descending]; otherwise, <c>false</c>.</value>
        public bool AllowDescending
        {
            get { return _allowDesc; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is default.
        /// </summary>
        /// <value><c>true</c> if this instance is default; otherwise, <c>false</c>.</value>
        public bool IsDefault
        {
            get { return _isDefault; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is default desc.
        /// </summary>
        /// <value><c>true</c> if this instance is default desc; otherwise, <c>false</c>.</value>
        public bool IsDefaultDesc
        {
            get { return _isDefaultDesc; }
        }

        /// <summary>
        /// Gets the name of the child field.
        /// </summary>
        /// <value>The name of the child field.</value>
        public string ChildFieldName
        {
            get { return _childFieldName; }
        }
    }

    /// <summary>
    /// Attribute to mark entity field as criteria participator
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class CriteriaFieldAttribute : Attribute
    {
        /// <summary>
        /// The allowed
        /// </summary>
        private readonly bool _allowed;
        /// <summary>
        /// The is class
        /// </summary>
        private readonly bool _isClass;
        /// <summary>
        /// The is array
        /// </summary>
        private readonly bool _isArray;
        /// <summary>
        /// The array member type
        /// </summary>
        private readonly Type _arrayMemberType;
        /// <summary>
        /// Initializes a new instance of the <see cref="CriteriaFieldAttribute" /> class.
        /// </summary>
        /// <param name="allowed">if set to <c>true</c> [allowed].</param>
        /// <param name="isClass">if set to <c>true</c> [is class].</param>
        /// <param name="isArray">if set to <c>true</c> [is array].</param>
        /// <param name="arrayMemberType">Type of the array member.</param>
        public CriteriaFieldAttribute(bool allowed = true, bool isClass = false, bool isArray = false, Type arrayMemberType = null)
        {
            _allowed = allowed;
            _isClass = isClass;
            _isArray = isArray;
            _arrayMemberType = arrayMemberType;
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="CriteriaFieldAttribute" /> is allowed.
        /// </summary>
        /// <value><c>true</c> if allowed; otherwise, <c>false</c>.</value>
        public bool Allowed
        {
            get { return _allowed; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is class.
        /// </summary>
        /// <value><c>true</c> if this instance is class; otherwise, <c>false</c>.</value>
        public bool IsClass
        {
            get { return _isClass; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is array.
        /// </summary>
        /// <value><c>true</c> if this instance is array; otherwise, <c>false</c>.</value>
        public bool IsArray
        {
            get { return _isArray; }
        }

        /// <summary>
        /// Gets the type of the array member.
        /// </summary>
        /// <value>The type of the array member.</value>
        public Type ArrayMemberType
        {
            get
            {
                return _arrayMemberType;
            }
        }
    }

    /// <summary>
    /// Attribute to mark entity field as file reference
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class FileFieldAttribute : Attribute
    {
        /// <summary>
        /// The MIME type
        /// </summary>
        private readonly string _mimeType;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileFieldAttribute" /> class.
        /// </summary>
        /// <param name="mimeType">Type of the MIME.</param>
        public FileFieldAttribute(string mimeType = "")
        {
            _mimeType = mimeType;
        }

        /// <summary>
        /// Gets the type of the MIME.
        /// </summary>
        /// <value>The type of the MIME.</value>
        public string MimeType
        {
            get
            {
                return _mimeType;
            }            
        }
    }

    /// <summary>
    /// Attribute to mark entity field as file reference
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ContentManagementAttribute : Attribute
    {
        /// <summary>
        /// The allowed
        /// </summary>
        private readonly bool _allowed;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContentManagementAttribute" /> class.
        /// </summary>
        /// <param name="allowed">if set to <c>true</c> [allowed].</param>
        public ContentManagementAttribute(bool allowed = true)
        {
            _allowed = allowed;
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="ContentManagementAttribute" /> is allowed.
        /// </summary>
        /// <value><c>true</c> if allowed; otherwise, <c>false</c>.</value>
        public bool Allowed
        {
            get
            {
                return _allowed;
            }
        }
    }
}
