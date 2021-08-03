// ***********************************************************************
// Assembly         : BAP.Common
// Author           : Victor Mamray
// Created          : 08-17-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-17-2020
// ***********************************************************************
// <copyright file="AttributeDirection.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.ComponentModel.DataAnnotations;

namespace BAP.Common
{
    /// <summary>
    /// Direction of workflow action attribute enum
    /// </summary>
    public enum AttributeDirection
    {
        /// <summary>
        /// The none
        /// </summary>
        [Display(ResourceType = typeof(Resources.Resources), Name = "EnumValue_AttributeDirection_None")]
        None = 0,
        /// <summary>
        /// The input
        /// </summary>
        [Display(ResourceType = typeof(Resources.Resources), Name = "EnumValue_AttributeDirection_Input")]
        Input,
        /// <summary>
        /// The output
        /// </summary>
        [Display(ResourceType = typeof(Resources.Resources), Name = "EnumValue_AttributeDirection_Output")]
        Output,
        /// <summary>
        /// The both
        /// </summary>
        [Display(ResourceType = typeof(Resources.Resources), Name = "EnumValue_AttributeDirection_Both")]
        Both
    }
}
