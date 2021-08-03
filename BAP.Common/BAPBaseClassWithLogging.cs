// ***********************************************************************
// Assembly         : BAP.Common
// Author           : Victor Mamray
// Created          : 04-13-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-17-2020
// ***********************************************************************
// <copyright file="BAPBaseClassWithLogging.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Diagnostics;
using System.Reflection;

using BAP.Log;

namespace BAP.Common
{
    /// <summary>
    /// Base abstract class with extra logging methods added
    /// </summary>
    public abstract class BAPBaseClassWithLogging
    {
        /// <summary>
        /// The logger
        /// </summary>
        protected readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="BAPBaseClassWithLogging"/> class.
        /// </summary>
        public BAPBaseClassWithLogging()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BAPBaseClassWithLogging"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public BAPBaseClassWithLogging(ILogger logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Logs the text.
        /// </summary>
        /// <param name="text">The text.</param>
        protected void LogText(string text)
        {
            if (_logger != null)
            {
                var callerMethod = MethodBase.GetCurrentMethod().Name;
                StackTrace stackTrace = new StackTrace();
                if (stackTrace != null)
                {
                    var frame = stackTrace.GetFrame(1);
                    if (frame != null)
                        callerMethod = frame.GetMethod().Name;
                }

                _logger.LogText(this.GetType().Name, callerMethod, text);
            }
        }

        /// <summary>
        /// Logs the debug.
        /// </summary>
        /// <param name="text">The text.</param>
        protected void LogDebug(string text)
        {
            if (_logger != null)
            {
                var callerMethod = MethodBase.GetCurrentMethod().Name;
                StackTrace stackTrace = new StackTrace();
                if (stackTrace != null)
                {
                    var frame = stackTrace.GetFrame(1);
                    if (frame != null)
                        callerMethod = frame.GetMethod().Name;
                }

                _logger.LogDebug(this.GetType().Name, callerMethod, text);
            }
        }

        /// <summary>
        /// Logs the warning.
        /// </summary>
        /// <param name="text">The text.</param>
        protected void LogWarning(string text)
        {
            if (_logger != null)
            {
                var callerMethod = MethodBase.GetCurrentMethod().Name;
                StackTrace stackTrace = new StackTrace();
                if (stackTrace != null)
                {
                    var frame = stackTrace.GetFrame(1);
                    if (frame != null)
                        callerMethod = frame.GetMethod().Name;
                }

                _logger.LogWarning(this.GetType().Name, callerMethod, text);
            }
        }

        /// <summary>
        /// Logs the error.
        /// </summary>
        /// <param name="error">The error.</param>
        protected void LogError(string error)
        {
            if (_logger != null)
            {
                var callerMethod = MethodBase.GetCurrentMethod().Name;
                StackTrace stackTrace = new StackTrace();
                if (stackTrace != null)
                {
                    var frame = stackTrace.GetFrame(1);
                    if (frame != null)
                        callerMethod = frame.GetMethod().Name;
                }

                _logger.LogError(this.GetType().Name, callerMethod, error);
            }
        }

        /// <summary>
        /// Logs the exception.
        /// </summary>
        /// <param name="exc">The exc.</param>
        protected void LogException(Exception exc)
        {
            if (_logger != null)
            {
                var callerMethod = MethodBase.GetCurrentMethod().Name;
                StackTrace stackTrace = new StackTrace();
                if (stackTrace != null)
                {
                    var frame = stackTrace.GetFrame(1);
                    if (frame != null)
                        callerMethod = frame.GetMethod().Name;
                }

                _logger.LogException(this.GetType().Name, callerMethod, exc);
            }
        }
    }
}
