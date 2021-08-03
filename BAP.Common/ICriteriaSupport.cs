// ***********************************************************************
// Assembly         : BAP.Common
// Author           : Victor Mamray
// Created          : 06-24-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-24-2020
// ***********************************************************************
// <copyright file="ICriteriaSupport.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace BAP.Common
{
    /// <summary>
    /// Enum CriteriaCompareOperator
    /// </summary>
    public enum CriteriaCompareOperator
    {
        /// <summary>
        /// The none
        /// </summary>
        [Display(ResourceType = typeof(Resources.Resources), Name = "EnumValue_CriteriaCompareOperator_None")]
        None = 0,
        /// <summary>
        /// The equal
        /// </summary>
        [Display(ResourceType = typeof(Resources.Resources), Name = "EnumValue_CriteriaCompareOperator_Equal")]
        Equal = 1,
        /// <summary>
        /// The not equal
        /// </summary>
        [Display(ResourceType = typeof(Resources.Resources), Name = "EnumValue_CriteriaCompareOperator_NotEqual")]
        NotEqual,
        /// <summary>
        /// The less
        /// </summary>
        [Display(ResourceType = typeof(Resources.Resources), Name = "EnumValue_CriteriaCompareOperator_Less")]
        Less,
        /// <summary>
        /// The more
        /// </summary>
        [Display(ResourceType = typeof(Resources.Resources), Name = "EnumValue_CriteriaCompareOperator_More")]
        More,
        /// <summary>
        /// The less equal
        /// </summary>
        [Display(ResourceType = typeof(Resources.Resources), Name = "EnumValue_CriteriaCompareOperator_LessEqual")]
        LessEqual,
        /// <summary>
        /// The more equal
        /// </summary>
        [Display(ResourceType = typeof(Resources.Resources), Name = "EnumValue_CriteriaCompareOperator_MoreEqual")]
        MoreEqual,
        /// <summary>
        /// The between
        /// </summary>
        [Display(ResourceType = typeof(Resources.Resources), Name = "EnumValue_CriteriaCompareOperator_Between")]
        Between,
        /// <summary>
        /// Determines whether this instance contains the object.
        /// </summary>
        [Display(ResourceType = typeof(Resources.Resources), Name = "EnumValue_CriteriaCompareOperator_Contains")]
        Contains,
        /// <summary>
        /// The start with
        /// </summary>
        [Display(ResourceType = typeof(Resources.Resources), Name = "EnumValue_CriteriaCompareOperator_StartWith")]
        StartWith,
        /// <summary>
        /// The end with
        /// </summary>
        [Display(ResourceType = typeof(Resources.Resources), Name = "EnumValue_CriteriaCompareOperator_EndWith")]
        EndWith,
        /// <summary>
        /// The is one of
        /// </summary>
        [Display(ResourceType = typeof(Resources.Resources), Name = "EnumValue_CriteriaCompareOperator_IsOneOf")]
        IsOneOf,
        /// <summary>
        /// The not one of
        /// </summary>
        [Display(ResourceType = typeof(Resources.Resources), Name = "EnumValue_CriteriaCompareOperator_NotOneOf")]
        NotOneOf,
        /// <summary>
        /// The custom
        /// </summary>
        [Display(ResourceType = typeof(Resources.Resources), Name = "EnumValue_CriteriaCompareOperator_Custom")]
        Custom = 99
    }

    /// <summary>
    /// Enum CriteriaFieldType
    /// </summary>
    public enum CriteriaFieldType
    {
        /// <summary>
        /// The property
        /// </summary>
        Property = 1,
        /// <summary>
        /// The object
        /// </summary>
        Object,
        /// <summary>
        /// The array
        /// </summary>
        Array
    }

    /// <summary>
    /// Enum CriteriaFieldDataType
    /// </summary>
    public enum CriteriaFieldDataType
    {
        /// <summary>
        /// The string
        /// </summary>
        String = 1,
        /// <summary>
        /// The number
        /// </summary>
        Number,
        /// <summary>
        /// The date
        /// </summary>
        Date
    }

    /// <summary>
    /// Class CriteriaField.
    /// </summary>
    public class CriteriaField
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets the parent.
        /// </summary>
        /// <value>The parent.</value>
        [JsonIgnore]
        public CriteriaField Parent { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="CriteriaField"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="type">The type.</param>
        public CriteriaField(string name, CriteriaFieldType type)
        {
            Name = name;
            FieldType = type;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; private set; }
        /// <summary>
        /// Gets or sets the caption.
        /// </summary>
        /// <value>The caption.</value>
        public string Caption { get; set; }
        /// <summary>
        /// Gets the type of the field.
        /// </summary>
        /// <value>The type of the field.</value>
        public CriteriaFieldType FieldType { get; private set; }
        /// <summary>
        /// Gets or sets the type of the data.
        /// </summary>
        /// <value>The type of the data.</value>
        public CriteriaFieldDataType DataType { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the object lookup items.
        /// </summary>
        /// <value>The object lookup items.</value>
        public List<LookupItem> ObjectLookupItems { get; set; }

        /// <summary>
        /// Gets or sets the entity field.
        /// </summary>
        /// <value>The entity field.</value>
        [JsonIgnore]
        public PropertyInfo EntityField { get; set; }
        /// <summary>
        /// Gets or sets the compare operator.
        /// </summary>
        /// <value>The compare operator.</value>
        public CriteriaCompareOperator CompareOperator { get; set; }
        /// <summary>
        /// Gets or sets the allowed operators.
        /// </summary>
        /// <value>The allowed operators.</value>
        public List<CriteriaCompareOperator> AllowedOperators { get; set; }
        /// <summary>
        /// Gets or sets the compare values.
        /// </summary>
        /// <value>The compare values.</value>
        public List<object> CompareValues { get; set; }

        /// <summary>
        /// Gets or sets the child fields.
        /// </summary>
        /// <value>The child fields.</value>
        public List<CriteriaField> ChildFields { get; set; }
    }

    /// <summary>
    /// Interface ICriteria
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICriteria<T> where T : class, IBapEntity
    {
        /// <summary>
        /// Gets the fields.
        /// </summary>
        /// <value>The fields.</value>
        List<CriteriaField> Fields { get; }
        /// <summary>
        /// Initializes from dto array.
        /// </summary>
        /// <param name="list">The list.</param>
        void InitFromDTOArray(List<CriteriaFieldDTO> list);
        /// <summary>
        /// Gets the <see cref="CriteriaField"/> with the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>CriteriaField.</returns>
        CriteriaField this[string name]
        {
            get;
        }

        /// <summary>
        /// Compares the specified field.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool Compare(CriteriaField field, object value);
    }
    /// <summary>
    /// Interface ICriteriaSupport
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICriteriaSupport<T> where T : class, IBapEntity
    {
        /// <summary>
        /// Searches the by criteria.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <returns>IList&lt;T&gt;.</returns>
        IList<T> SearchByCriteria(ICriteria<T> criteria);
        /// <summary>
        /// Meets the criteria.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="criteria">The criteria.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool MeetCriteria(T entity, ICriteria<T> criteria);
    }

    /// <summary>
    /// Class CriteriaFieldDTO.
    /// </summary>
    public class CriteriaFieldDTO
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets the name of the field.
        /// </summary>
        /// <value>The name of the field.</value>
        public string FieldName { get; set; }
        /// <summary>
        /// Gets or sets the operator.
        /// </summary>
        /// <value>The operator.</value>
        public CriteriaCompareOperator Operator { get; set; }
        /// <summary>
        /// Gets or sets the values.
        /// </summary>
        /// <value>The values.</value>
        public List<string> Values { get; set; }
    }
}


