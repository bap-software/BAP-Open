// ***********************************************************************
// Assembly         : BAP.BL
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="CriteriaHelper.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Newtonsoft.Json;

using BAP.Common;
using BAP.DAL;
using BAP.Log;
using System.ComponentModel.DataAnnotations;

namespace BAP.BL.CriteriaEngine
{
    /// <summary>
    /// Class Criteria.
    /// Implements the <see cref="BAP.Common.ICriteria{T}" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="BAP.Common.ICriteria{T}" />
    public class Criteria<T> : ICriteria<T> where T : class, IBapEntity
    {
        /// <summary>
        /// The settings
        /// </summary>
        protected readonly IConfigHelper _settings;
        /// <summary>
        /// The authentication context
        /// </summary>
        protected readonly IAuthorizationContext _authContext;
        /// <summary>
        /// The logger
        /// </summary>
        protected readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="Criteria{T}"/> class.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="authContext">The authentication context.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="initFields">if set to <c>true</c> [initialize fields].</param>
        public Criteria(IConfigHelper settings, IAuthorizationContext authContext, ILogger logger, bool initFields = false)
        {
            _settings = settings;
            _authContext = authContext;
            _logger = logger;

            Fields = new List<CriteriaField>();
            if (initFields)
                InitFieldsList();
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="Criteria{T}"/> class from being created.
        /// </summary>
        private Criteria()
        {
            Fields = new List<CriteriaField>();
        }

        /// <summary>
        /// Gets the fields.
        /// </summary>
        /// <value>The fields.</value>
        public List<CriteriaField> Fields { get; private set; }

        /// <summary>
        /// Gets the <see cref="CriteriaField"/> with the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>CriteriaField.</returns>
        public CriteriaField this[string name]
        {
            get
            {
                return Fields.SingleOrDefault(a => a.EntityField.Name == name);
            }
        }

        /// <summary>
        /// Froms the string.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="authContext">The authentication context.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="json">The json.</param>
        /// <returns>ICriteria&lt;T&gt;.</returns>
        public static ICriteria<T> FromString(IConfigHelper settings, IAuthorizationContext authContext, ILogger logger, string json)
        {
            var input = JsonConvert.DeserializeObject<Criteria<T>>(json);
            var inputFieldList = input.FieldsPlainList;
            var result = new Criteria<T>(settings, authContext, logger, true);
            foreach (var field in result.FieldsPlainList)
            {
                var inputField = inputFieldList.FirstOrDefault(a => a.Id == field.Id);
                if (inputField != null)
                {
                    if (inputField != null && inputField.CompareOperator != CriteriaCompareOperator.None && inputField.CompareValues != null)
                    {
                        field.CompareOperator = inputField.CompareOperator;
                        field.CompareValues = inputField.CompareValues;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Gets the fields plain list.
        /// </summary>
        /// <value>The fields plain list.</value>
        [JsonIgnore]
        public List<CriteriaField> FieldsPlainList
        {
            get
            {
                if (Fields == null)
                    return null;

                List<CriteriaField> plainList = new List<CriteriaField>();
                PlainTree(Fields, plainList);
                return plainList;
            }
        }

        /// <summary>
        /// Initializes from dto array.
        /// </summary>
        /// <param name="list">The list.</param>
        public void InitFromDTOArray(List<CriteriaFieldDTO> list)
        {
            if (Fields == null || list == null)
                return;

            var plainList = FieldsPlainList;
            foreach (var field in plainList)
            {
                var dto = list.SingleOrDefault(a => a.Id == field.Id);
                if (dto != null)
                {
                    field.CompareOperator = dto.Operator;
                    field.CompareValues = dto.Values.Select(a => (object)a).ToList();
                }
                else
                {
                    field.CompareOperator = CriteriaCompareOperator.None;
                    field.CompareValues = null;
                }
            }
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        /// <summary>
        /// Compares the specified field.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public virtual bool Compare(CriteriaField field, object value)
        {
            bool result = true;
            if (field.FieldType == CriteriaFieldType.Object)
            {
                var entity = (IBapEntity)value;
                List<int> ids = new List<int>();
                foreach (var a in field.CompareValues)
                {
                    ids.Add(Convert.ToInt32(a));
                }

                switch (field.CompareOperator)
                {
                    case CriteriaCompareOperator.Equal:
                        result = (entity.Id == ids[0]);
                        break;
                    case CriteriaCompareOperator.NotEqual:
                        result = (entity.Id != ids[0]);
                        break;
                    case CriteriaCompareOperator.IsOneOf:
                        result = ids.Any(a => a == entity.Id);
                        break;
                    case CriteriaCompareOperator.NotOneOf:
                        result = !ids.Any(a => a == entity.Id);
                        break;
                        /* these will be implemented later
                        case CriteriaCompareOperator.EndWith:
                            result = entity.Name.ToLower().EndsWith(CompareValues[0].ToString().ToLower());
                            break;
                        case CriteriaCompareOperator.Contains:
                            result = entity.Name.ToLower().Contains(CompareValues[0].ToString().ToLower());
                            break;
                        case CriteriaCompareOperator.StartWith:
                            result = entity.Name.ToLower().StartsWith(CompareValues[0].ToString().ToLower());
                            break;                    */
                }
            }
            else if (field.FieldType == CriteriaFieldType.Property)
            {
                switch (field.CompareOperator)
                {
                    case CriteriaCompareOperator.Equal:
                        result = (field.CompareValues != null && field.CompareValues.Count > 0 && value == field.CompareValues[0]);
                        break;
                    case CriteriaCompareOperator.NotEqual:
                        result = (field.CompareValues != null && field.CompareValues.Count > 0 && value != field.CompareValues[0]);
                        break;
                    case CriteriaCompareOperator.Less:
                        if (field.DataType == CriteriaFieldDataType.Date)
                            result = (field.CompareValues != null && field.CompareValues.Count > 0 && Convert.ToDateTime(value) < Convert.ToDateTime(field.CompareValues[0]));
                        else
                            result = (field.CompareValues != null && field.CompareValues.Count > 0 && Convert.ToDouble(value) < Convert.ToDouble(field.CompareValues[0]));
                        break;
                    case CriteriaCompareOperator.More:
                        if (field.DataType == CriteriaFieldDataType.Date)
                            result = (field.CompareValues != null && field.CompareValues.Count > 0 && Convert.ToDateTime(value) > Convert.ToDateTime(field.CompareValues[0]));
                        else
                            result = (field.CompareValues != null && field.CompareValues.Count > 0 && Convert.ToDouble(value) > Convert.ToDouble(field.CompareValues[0]));
                        break;
                    case CriteriaCompareOperator.MoreEqual:
                        if (field.DataType == CriteriaFieldDataType.Date)
                            result = (field.CompareValues != null && field.CompareValues.Count > 0 && Convert.ToDateTime(value) >= Convert.ToDateTime(field.CompareValues[0]));
                        else
                            result = (field.CompareValues != null && field.CompareValues.Count > 0 && Convert.ToDouble(value) >= Convert.ToDouble(field.CompareValues[0]));
                        break;
                    case CriteriaCompareOperator.LessEqual:
                        if (field.DataType == CriteriaFieldDataType.Date)
                            result = (field.CompareValues != null && field.CompareValues.Count > 0 && Convert.ToDateTime(value) <= Convert.ToDateTime(field.CompareValues[0]));
                        else
                            result = (field.CompareValues != null && field.CompareValues.Count > 0 && Convert.ToDouble(value) <= Convert.ToDouble(field.CompareValues[0]));
                        break;
                    case CriteriaCompareOperator.EndWith:
                        result = (field.CompareValues != null && field.CompareValues.Count > 0 && value.ToString().ToLower().EndsWith(field.CompareValues[0].ToString().ToLower()));
                        break;
                    case CriteriaCompareOperator.Contains:
                        result = (field.CompareValues != null && field.CompareValues.Count > 0 && value.ToString().ToLower().Contains(field.CompareValues[0].ToString().ToLower()));
                        break;
                    case CriteriaCompareOperator.StartWith:
                        result = (field.CompareValues != null && field.CompareValues.Count > 0 && value.ToString().ToLower().StartsWith(field.CompareValues[0].ToString().ToLower()));
                        break;
                    case CriteriaCompareOperator.Between:
                        if (field.CompareValues == null || field.CompareValues.Count < 2)
                            result = false;
                        else
                        {
                            if (field.DataType == CriteriaFieldDataType.Date)
                            {
                                var minVal = Convert.ToDateTime(field.CompareValues[0]);
                                var maxVal = Convert.ToDateTime(field.CompareValues[1]);
                                var thisVal = Convert.ToDateTime(value);
                                result = thisVal >= minVal && thisVal <= maxVal;
                            }
                            else
                            {
                                var minVal = Convert.ToDouble(field.CompareValues[0]);
                                var maxVal = Convert.ToDouble(field.CompareValues[1]);
                                var thisVal = Convert.ToDouble(value);
                                result = thisVal >= minVal && thisVal <= maxVal;
                            }
                        }
                        break;
                    case CriteriaCompareOperator.IsOneOf:
                        if (field.CompareValues == null || field.CompareValues.Count < 1)
                            result = false;
                        else
                            result = field.CompareValues.Any(a => a == value);
                        break;
                    case CriteriaCompareOperator.NotOneOf:
                        if (field.CompareValues == null || field.CompareValues.Count < 1)
                            result = true;
                        else
                            result = !field.CompareValues.Any(a => a == value);
                        break;
                }
            }
            else if (field.FieldType == CriteriaFieldType.Array)
            {
                if (field.ChildFields != null && field.ChildFields.Count > 0)
                {
                    var list = value as System.Collections.IList;
                    if (list != null)
                    {
                        foreach (var childField in field.ChildFields)
                        {
                            if (childField.Name.ToLowerInvariant() != "count") 
                                continue;
                            switch (childField.CompareOperator)
                            {
                                case CriteriaCompareOperator.Equal:
                                    result = (childField.CompareValues != null && childField.CompareValues.Count > 0 && list.Count == Convert.ToDouble(childField.CompareValues[0]));
                                    break;
                                case CriteriaCompareOperator.NotEqual:
                                    result = (childField.CompareValues != null && childField.CompareValues.Count > 0 && list.Count != Convert.ToDouble(childField.CompareValues[0]));
                                    break;
                                case CriteriaCompareOperator.Less:
                                    result = (childField.CompareValues != null && childField.CompareValues.Count > 0 && list.Count < Convert.ToDouble(childField.CompareValues[0]));
                                    break;
                                case CriteriaCompareOperator.LessEqual:
                                    result = (childField.CompareValues != null && childField.CompareValues.Count > 0 && list.Count <= Convert.ToDouble(childField.CompareValues[0]));
                                    break;
                                case CriteriaCompareOperator.More:
                                    result = (childField.CompareValues != null && childField.CompareValues.Count > 0 && list.Count > Convert.ToDouble(childField.CompareValues[0]));
                                    break;
                                case CriteriaCompareOperator.MoreEqual:
                                    result = (childField.CompareValues != null && childField.CompareValues.Count > 0 && list.Count >= Convert.ToDouble(childField.CompareValues[0]));
                                    break;
                            }
                        }
                    }
                }
            }

            return result;
        }

        #region private methods
        /// <summary>
        /// Plains the tree.
        /// </summary>
        /// <param name="treeNodes">The tree nodes.</param>
        /// <param name="plainList">The plain list.</param>
        private void PlainTree(List<CriteriaField> treeNodes, List<CriteriaField> plainList)
        {
            if (treeNodes == null || plainList == null)
                return;

            foreach (var node in treeNodes)
            {
                plainList.Add(node);
                if (node.ChildFields != null)
                    PlainTree(node.ChildFields, plainList);
            }
        }

        /// <summary>
        /// Initializes the fields list.
        /// </summary>
        /// <param name="entityType">Type of the entity.</param>
        /// <param name="parentField">The parent field.</param>
        private void InitFieldsList(Type entityType = null, CriteriaField parentField = null)
        {
            var thisEntityType = entityType;
            if (thisEntityType == null)
                thisEntityType = typeof(T);
            var fields = thisEntityType.GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(CriteriaFieldAttribute))).ToList();
            if (fields != null && fields.Any())
            {
                List<CriteriaField> criteriaFields = null;
                if (parentField != null)
                {
                    criteriaFields = parentField.ChildFields;
                }
                else
                {
                    criteriaFields = Fields;
                }

                foreach (var field in fields)
                {
                    var displayAttr = field.GetCustomAttribute<DisplayAttribute>();
                    var attr = field.GetCustomAttribute<CriteriaFieldAttribute>();
                    var fieldType = CriteriaFieldType.Property;
                    if (attr.IsClass)
                        fieldType = CriteriaFieldType.Object;
                    if (attr.IsArray)
                        fieldType = CriteriaFieldType.Array;

                    var id = field.Name;
                    if (parentField == null)
                    {
                        id = field.ReflectedType.Name + "." + id;
                    }
                    else
                    {
                        id = parentField.Id + "." + id;
                    }

                    CriteriaField criteriaField = new CriteriaField(field.Name, fieldType)
                    {
                        Id = id,
                        Parent = parentField,
                        EntityField = field,
                        CompareValues = new List<object>()
                    };

                    if (displayAttr != null)
                    {
                        criteriaField.Caption = displayAttr.GetName();
                    }
                    else
                    {
                        criteriaField.Caption = criteriaField.Name;
                    }

                    if (criteriaField.FieldType != CriteriaFieldType.Property)
                    {
                        criteriaField.ChildFields = new List<CriteriaField>();
                    }

                    if (attr.IsArray)
                    {
                        InitFieldsList(attr.ArrayMemberType, criteriaField);
                    }
                    else if (attr.IsClass)
                    {
                        InitFieldsList(field.PropertyType, criteriaField);
                    }

                    //Init extra field data
                    InitAllowedOperators(criteriaField);
                    InitFieldDataType(criteriaField);
                    if (attr.IsClass)
                    {
                        InitFieldLookup(criteriaField);
                    }

                    criteriaFields.Add(criteriaField);
                }
            }
        }

        /// <summary>
        /// Initializes the field lookup.
        /// </summary>
        /// <param name="criteriaField">The criteria field.</param>
        private void InitFieldLookup(CriteriaField criteriaField)
        {
            var type = typeof(ISupportLookup);
            var types = AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.Contains("BAP"))
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && p.Name == criteriaField.EntityField.PropertyType.Name + "BL");
            if (types != null && types.Count() > 0)
            {
                ISupportLookup classInstance = (ISupportLookup)Activator.CreateInstance(types.First(), _settings, _authContext, _logger);
                if (classInstance != null)
                {
                    var list = classInstance.GetLookupItems("Id", "Name");
                    criteriaField.ObjectLookupItems = new List<LookupItem>();
                    criteriaField.ObjectLookupItems.AddRange(list);
                }
            }
        }

        /// <summary>
        /// Initializes the type of the field data.
        /// </summary>
        /// <param name="field">The field.</param>
        private void InitFieldDataType(CriteriaField field)
        {
            if (field == null || field.FieldType != CriteriaFieldType.Property)
                return;
            var propType = field.EntityField.PropertyType;
            if (IsNumericType(propType))
                field.DataType = CriteriaFieldDataType.Number;
            else if (IsDateType(propType))
                field.DataType = CriteriaFieldDataType.Date;
            else if (IsStringType(propType))
                field.DataType = CriteriaFieldDataType.String;
        }

        /// <summary>
        /// Initializes the allowed operators.
        /// </summary>
        /// <param name="field">The field.</param>
        private void InitAllowedOperators(CriteriaField field)
        {
            if (field == null)
                return;

            field.AllowedOperators = new List<CriteriaCompareOperator>();
            if (field.FieldType == CriteriaFieldType.Object)
            {
                //field.AllowedOperators.Add(CriteriaCompareOperator.Equal);
                //field.AllowedOperators.Add(CriteriaCompareOperator.NotEqual);
                field.AllowedOperators.Add(CriteriaCompareOperator.IsOneOf);
                field.AllowedOperators.Add(CriteriaCompareOperator.NotOneOf);
                //These will be implemented later
                //field.AllowedOperators.Add(CriteriaCompareOperator.EndWith);
                //field.AllowedOperators.Add(CriteriaCompareOperator.Contains);
                //field.AllowedOperators.Add(CriteriaCompareOperator.StartWith);                
            }
            else if (field.FieldType == CriteriaFieldType.Property)
            {
                var propType = field.EntityField.PropertyType;
                if (IsNumericType(propType) || IsDateType(propType))
                {
                    field.AllowedOperators.Add(CriteriaCompareOperator.Equal);
                    field.AllowedOperators.Add(CriteriaCompareOperator.NotEqual);
                    field.AllowedOperators.Add(CriteriaCompareOperator.Between);
                    field.AllowedOperators.Add(CriteriaCompareOperator.Less);
                    field.AllowedOperators.Add(CriteriaCompareOperator.LessEqual);
                    field.AllowedOperators.Add(CriteriaCompareOperator.More);
                    field.AllowedOperators.Add(CriteriaCompareOperator.MoreEqual);
                }
                else if (IsStringType(propType))
                {
                    field.AllowedOperators.Add(CriteriaCompareOperator.Equal);
                    field.AllowedOperators.Add(CriteriaCompareOperator.EndWith);
                    field.AllowedOperators.Add(CriteriaCompareOperator.Contains);
                    field.AllowedOperators.Add(CriteriaCompareOperator.StartWith);
                }
            }
        }

        /// <summary>
        /// Determines whether [is numeric type] [the specified type].
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns><c>true</c> if [is numeric type] [the specified type]; otherwise, <c>false</c>.</returns>
        private bool IsNumericType(Type type)
        {
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;
                case TypeCode.Object:
                    if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        return IsNumericType(Nullable.GetUnderlyingType(type));
                    }
                    return false;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Determines whether [is date type] [the specified type].
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns><c>true</c> if [is date type] [the specified type]; otherwise, <c>false</c>.</returns>
        private bool IsDateType(Type type)
        {
            return Type.GetTypeCode(type) == TypeCode.DateTime;
        }
        /// <summary>
        /// Determines whether [is string type] [the specified type].
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns><c>true</c> if [is string type] [the specified type]; otherwise, <c>false</c>.</returns>
        private bool IsStringType(Type type)
        {
            return Type.GetTypeCode(type) == TypeCode.String;
        }

        #endregion
    }
}
