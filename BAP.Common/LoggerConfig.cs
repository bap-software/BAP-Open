// ***********************************************************************
// Assembly         : BAP.Common
// Author           : Victor Mamray
// Created          : 04-20-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="LoggerConfig.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.Common
{
    /// <summary>
    /// Class LoggerConfig.
    /// </summary>
    public class LoggerConfig
    {
        /// <summary>
        /// Gets or sets the inner exception format.
        /// </summary>
        /// <value>The inner exception format.</value>
        public string InnerExceptionFormat { get; set; } = "(Exception: {0}; Source: {1}; HelpLink: {2}; StackTrace: {3}\r\n)";

        /// <summary>
        /// Gets or sets the log level.
        /// </summary>
        /// <value>The log level.</value>
        public string LogLevel { get; set; } = "NONE | DEBUG | INFO | WARN | ERROR | FATAL | ALL";
    }

    /// <summary>
    /// Enum LogLevel
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// The none
        /// </summary>
        NONE,
        /// <summary>
        /// The debug
        /// </summary>
        DEBUG,
        /// <summary>
        /// The information
        /// </summary>
        INFO,
        /// <summary>
        /// The warn
        /// </summary>
        WARN,
        /// <summary>
        /// The error
        /// </summary>
        ERROR,
        /// <summary>
        /// The fatal
        /// </summary>
        FATAL,
        /// <summary>
        /// All
        /// </summary>
        ALL
    }
}
