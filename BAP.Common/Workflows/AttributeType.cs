// ***********************************************************************
// Assembly         : BAP.Common
// Author           : Victor Mamray
// Created          : 08-17-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-17-2020
// ***********************************************************************
// <copyright file="AttributeType.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.ComponentModel.DataAnnotations;

namespace BAP.Common
{
    /// <summary>
    /// Data type of workflow action attribute enum
    /// </summary>
    public enum AttributeType
    {
        /// <summary>
        /// The none
        /// </summary>
        [Display(ResourceType = typeof(Resources.Resources), Name = "EnumValue_AttributeType_None")]
        None = 0,
        /// <summary>
        /// The text
        /// </summary>
        [Display(ResourceType = typeof(Resources.Resources), Name = "EnumValue_AttributeType_Text")]
        Text,
        /// <summary>
        /// The number
        /// </summary>
        [Display(ResourceType = typeof(Resources.Resources), Name = "EnumValue_AttributeType_Number")]
        Number,
        /// <summary>
        /// The currency
        /// </summary>
        [Display(ResourceType = typeof(Resources.Resources), Name = "EnumValue_AttributeType_Currency")]
        Currency,
        /// <summary>
        /// The date
        /// </summary>
        [Display(ResourceType = typeof(Resources.Resources), Name = "EnumValue_AttributeType_Date")]
        Date,
        /// <summary>
        /// The time
        /// </summary>
        [Display(ResourceType = typeof(Resources.Resources), Name = "EnumValue_AttributeType_Time")]
        Time,
        /// <summary>
        /// The date time
        /// </summary>
        [Display(ResourceType = typeof(Resources.Resources), Name = "EnumValue_AttributeType_DateTime")]
        DateTime,
        /// <summary>
        /// The file
        /// </summary>
        [Display(ResourceType = typeof(Resources.Resources), Name = "EnumValue_AttributeType_File")]
        File,
        /// <summary>
        /// The URL
        /// </summary>
        [Display(ResourceType = typeof(Resources.Resources), Name = "EnumValue_AttributeType_Url")]
        Url,
        /// <summary>
        /// The email
        /// </summary>
        [Display(ResourceType = typeof(Resources.Resources), Name = "EnumValue_AttributeType_Email")]
        Email
    }
}
