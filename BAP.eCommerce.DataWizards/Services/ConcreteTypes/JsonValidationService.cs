// ***********************************************************************
// Assembly         : BAP.eCommerce.DataWizards
// Author           : Victor Mamray
// Created          : 06-11-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="JsonValidationService.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Reflection;
using System.Web.Script.Serialization;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using BAP.eCommerce.DataWizards.Services.AbstractTypes;
using System;

namespace BAP.eCommerce.DataWizards.Services.ConcreteTypes
{
    /// <summary>
    /// Class JsonValidationService.
    /// Implements the <see cref="BAP.eCommerce.DataWizards.Services.AbstractTypes.IJsonValidationService" />
    /// </summary>
    /// <seealso cref="BAP.eCommerce.DataWizards.Services.AbstractTypes.IJsonValidationService" />
    public class JsonValidationService : IJsonValidationService
    {
        // <summary>  verifies if file is Json
        /// <summary>
        /// Files the is json.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>IJsonValidationService.</returns>
        public IJsonValidationService FileIsJson(string input)
        {
            input = input.Trim();
            bool IsWellFormed()
            {
                try
                {
                    JToken.Parse(input);
                }
                catch
                {
                    return false;
                }
                return true;
            }
            if ((input.StartsWith("{") && input.EndsWith("}")
                    || input.StartsWith("[") && input.EndsWith("]"))
                   && IsWellFormed())
            {
                return this;
            }
            return null;
        }

        // <summary>  Verifies if Json is deserializable to DataWizardProductCategory model
        /// <summary>
        /// Determines whether [is json correct model] [the specified json input].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonInput">The json input.</param>
        /// <returns><c>true</c> if [is json correct model] [the specified json input]; otherwise, <c>false</c>.</returns>
        public bool IsJsonCorrectModel<T>( string jsonInput)
        {
            try
            {
                var serializedObject = JsonConvert.DeserializeObject<T>(jsonInput);
                return !(serializedObject == null);
            }
            catch
            {
                var serializedObject = JsonConvert.DeserializeObject<List<T>>(jsonInput);
                return !(serializedObject == null);

            }
            
        }

        // <summary> Checks if json Scheme is correct
        /// <summary>
        /// Determines whether [is json scheme correct] [the specified json input].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonInput">The json input.</param>
        /// <returns>IJsonValidationService.</returns>
        public IJsonValidationService IsJsonSchemeCorrect<T>(string jsonInput)
        {
            
            bool res = true;
            //this is a .net object look for it in msdn
            //JsonSerializer ser = new JsonSerializer();
            //first serialize the string to object.
            try
            {
                var obj = JsonConvert.DeserializeObject<T>(jsonInput);
                var properties = typeof(T).GetProperties();
                //iterate on all properties and test.
                foreach (PropertyInfo info in properties)
                {
                    // i went on if null value then json string isnt schema complient but you can do what ever test you like her.
                    var valueOfProp = obj.GetType().GetProperty(info.Name).GetValue(obj, null);
                    if (valueOfProp == null)
                        res = false;
                }
                if (res)
                {
                    return this;
                }
                return null;
            }
            catch (Exception)
            {
                var obj = JsonConvert.DeserializeObject<List<T>>(jsonInput);
                foreach (var item in obj as List<T>)
                {
                    var properties = typeof(T).GetProperties();

                    foreach (PropertyInfo info in properties)
                    {
                        var valueOfProp = item.GetType().GetProperty(info.Name).GetValue(item, null);
                        if (valueOfProp == null)
                            res = false;
                    }
                }
                if (res)
                {
                    return this;
                }
                return null;
            }
           
        }
    }
}