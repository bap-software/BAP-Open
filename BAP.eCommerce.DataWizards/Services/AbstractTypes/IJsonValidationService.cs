// ***********************************************************************
// Assembly         : BAP.eCommerce.DataWizards
// Author           : Victor Mamray
// Created          : 05-24-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="IJsonValidationService.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.eCommerce.DataWizards.Services.AbstractTypes
{
    /// <summary>
    /// Interface IJsonValidationService
    /// </summary>
    public interface IJsonValidationService
    {

        // <summary>  verifies if file is Json
        /// <summary>
        /// Determines whether [is json scheme correct] [the specified json input].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonInput">The json input.</param>
        /// <returns>IJsonValidationService.</returns>
        IJsonValidationService IsJsonSchemeCorrect<T>(string jsonInput);


        // <summary>  Verifies if Json is deserializable to DataWizardProductCategory model
        /// <summary>
        /// Determines whether [is json correct model] [the specified json input].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonInput">The json input.</param>
        /// <returns><c>true</c> if [is json correct model] [the specified json input]; otherwise, <c>false</c>.</returns>
        bool IsJsonCorrectModel<T>(string jsonInput);

        // <summary> Checks if json Scheme is correct
        /// <summary>
        /// Files the is json.
        /// </summary>
        /// <param name="jsonInput">The json input.</param>
        /// <returns>IJsonValidationService.</returns>
        IJsonValidationService FileIsJson(string jsonInput);

    }
}
