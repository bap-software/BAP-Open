// ***********************************************************************
// Assembly         : BAP.Common
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="ILogger.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace BAP.Log
{
    /// <summary>
    /// Interface ILogger
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Logs the debug.
        /// </summary>
        /// <param name="textSource">The text source.</param>
        /// <param name="textCode">The text code.</param>
        /// <param name="text">The text.</param>
        /// <returns>System.Int32.</returns>
        int LogDebug(string textSource, string textCode, string text); //Debug in Log4Net
        /// <summary>
        /// Logs the text.
        /// </summary>
        /// <param name="textSource">The text source.</param>
        /// <param name="textCode">The text code.</param>
        /// <param name="text">The text.</param>
        /// <returns>System.Int32.</returns>
        int LogText(string textSource, string textCode, string text); //Info in Log4Net
        /// <summary>
        /// Logs the warning.
        /// </summary>
        /// <param name="textSource">The text source.</param>
        /// <param name="textCode">The text code.</param>
        /// <param name="text">The text.</param>
        /// <returns>System.Int32.</returns>
        int LogWarning(string textSource, string textCode, string text); //Warn in Log4Net
        /// <summary>
        /// Logs the error.
        /// </summary>
        /// <param name="errorSource">The error source.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="error">The error.</param>
        /// <returns>System.Int32.</returns>
        int LogError(string errorSource, string errorCode, string error); //Error in Log4Net
        /// <summary>
        /// Logs the exception.
        /// </summary>
        /// <param name="excSource">The exc source.</param>
        /// <param name="excCode">The exc code.</param>
        /// <param name="exception">The exception.</param>
        /// <returns>System.Int32.</returns>
        int LogException(string excSource, string excCode, Exception exception); //Fatal in Log4Net
    }
}
