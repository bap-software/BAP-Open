// ***********************************************************************
// Assembly         : BAP.Log4Net
// Author           : Victor Mamray
// Created          : 04-20-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="Logger.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using BAP.BL;
using BAP.Common;
using BAP.DAL;
using BAP.DAL.Entities;
using log4net;
using log4net.Config;
using Newtonsoft.Json;
using System;
using System.Data.Entity.Validation;
using System.Web;

namespace BAP.Log4Net
{
    /// <summary>
    /// Class Logger.
    /// Implements the <see cref="BAP.Log.ILogger" />
    /// Implements the <see cref="BAP.Common.ISupportCustomConfig" />
    /// </summary>
    /// <seealso cref="BAP.Log.ILogger" />
    /// <seealso cref="BAP.Common.ISupportCustomConfig" />
    public class Logger : Log.ILogger, ISupportCustomConfig
    {
        /// <summary>
        /// The settings
        /// </summary>
        IConfigHelper _settings;
        /// <summary>
        /// The authentication context
        /// </summary>
        IAuthorizationContext _authContext;
        /// <summary>
        /// The authentication helper
        /// </summary>
        IAuthorizationHelper<EventLog> _authHelper;
        /// <summary>
        /// The configuration
        /// </summary>
        private readonly LoggerConfig _config;
        /// <summary>
        /// The bl
        /// </summary>
        private readonly ICustomConfigurationBL _bl;
        /// <summary>
        /// The custom configuration
        /// </summary>
        private CustomConfiguration _customConfiguration;

        /// <summary>
        /// The log
        /// </summary>
        private static ILog log = LogManager.GetLogger("LOGGER");

        /// <summary>
        /// Gets a value indicating whether [supports custom configuration].
        /// </summary>
        /// <value><c>true</c> if [supports custom configuration]; otherwise, <c>false</c>.</value>
        public bool SupportsCustomConfig => true;

        /// <summary>
        /// Gets the custom configuration json example.
        /// </summary>
        /// <value>The custom configuration json example.</value>
        public string CustomConfigJsonExample => JsonConvert.SerializeObject(new LoggerConfig());

        /// <summary>
        /// Gets the type of the custom configuration.
        /// </summary>
        /// <value>The type of the custom configuration.</value>
        public Type CustomConfigType => typeof(LoggerConfig);

        /// <summary>
        /// Gets the current custom configuration json.
        /// </summary>
        /// <value>The current custom configuration json.</value>
        public string CurrentCustomConfigJson => _customConfiguration.CurrentConfiguration;

        /// <summary>
        /// Initializes a new instance of the <see cref="Logger"/> class.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="context">The context.</param>
        public Logger(IConfigHelper settings, IAuthorizationContext context)
        {
            _settings = settings;
            _authContext = context;
            _authHelper = new AuthorizationHelper<EventLog>(_settings, _authContext);
            InitLogger();
            _bl = new BusinessLayer(settings, context, this);
            var type = typeof(Logger);
            _customConfiguration = _bl.GetCustomConfigurationByName($"{type.Assembly.GetName().Name}_{type.Name}");
            if (_customConfiguration != null && !string.IsNullOrWhiteSpace(_customConfiguration.CurrentConfiguration))
                _config = JsonConvert.DeserializeObject<LoggerConfig>(_customConfiguration.CurrentConfiguration);
            if (_config == null)
                _config = new LoggerConfig();
        }

        /// <summary>
        /// Initializes the logger.
        /// </summary>
        public static void InitLogger()
        {
            XmlConfigurator.Configure();
        }

        /// <summary>
        /// Logs the text.
        /// </summary>
        /// <param name="textSource">The text source.</param>
        /// <param name="textCode">The text code.</param>
        /// <param name="text">The text.</param>
        /// <returns>System.Int32.</returns>
        public int LogText(string textSource, string textCode, string text)
        {
            return WriteEvent(LogLevel.INFO, textSource, textCode, text);
        }

        /// <summary>
        /// Logs the debug.
        /// </summary>
        /// <param name="textSource">The text source.</param>
        /// <param name="textCode">The text code.</param>
        /// <param name="text">The text.</param>
        /// <returns>System.Int32.</returns>
        public int LogDebug(string textSource, string textCode, string text)
        {
            return WriteEvent(LogLevel.DEBUG, textSource, textCode, text);
        }

        /// <summary>
        /// Logs the warning.
        /// </summary>
        /// <param name="textSource">The text source.</param>
        /// <param name="textCode">The text code.</param>
        /// <param name="text">The text.</param>
        /// <returns>System.Int32.</returns>
        public int LogWarning(string textSource, string textCode, string text)
        {
            return WriteEvent(LogLevel.WARN, textSource, textCode, text);
        }

        /// <summary>
        /// Logs the error.
        /// </summary>
        /// <param name="errorSource">The error source.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="error">The error.</param>
        /// <returns>System.Int32.</returns>
        public int LogError(string errorSource, string errorCode, string error)
        {
            return WriteEvent(LogLevel.ERROR, errorSource, errorCode, error);
        }

        /// <summary>
        /// Logs the exception.
        /// </summary>
        /// <param name="excSource">The exc source.</param>
        /// <param name="excCode">The exc code.</param>
        /// <param name="exception">The exception.</param>
        /// <returns>System.Int32.</returns>
        public int LogException(string excSource, string excCode, Exception exception)
        {
            var excDescription = string.Empty;
            var exc = exception;
            while (exc != null)
            {
                if (exc != exception)
                    excDescription += "Inner Exception. ";

                excDescription += string.Format(_config.InnerExceptionFormat, exc.Message, exc.Source, exc.HelpLink, exc.StackTrace);

                exc = exc.InnerException;
            }

            if (exception != null && exception is DbEntityValidationException)
            {
                var e = (DbEntityValidationException)exception;
                excDescription += "\r\nData validation errors:";
                foreach (var eve in e.EntityValidationErrors)
                {
                    excDescription += string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:\r\n",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);

                    foreach (var ve in eve.ValidationErrors)
                    {
                        excDescription += string.Format("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                        ve.PropertyName,
                        eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                        ve.ErrorMessage);
                    }
                }
            }

            return WriteEvent(LogLevel.FATAL, excSource, excCode, excDescription);
        }

        /// <summary>
        /// Writes the event.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="source">The source.</param>
        /// <param name="code">The code.</param>
        /// <param name="message">The message.</param>
        /// <returns>System.Int32.</returns>
        /// <exception cref="Exception">Cannot write into log, DB is not accessible looks like.</exception>
        private int WriteEvent(LogLevel type, string source, string code, string message)
        {
            Enum.TryParse(_config.LogLevel, out LogLevel logLevel);
            if (type > logLevel)
                return -1;

            int result;
            try
            {
                LogicalThreadContext.Properties["EventType"] = type;
                LogicalThreadContext.Properties["EventSource"] = source;
                LogicalThreadContext.Properties["EventCode"] = code;
                LogicalThreadContext.Properties["IpAddress"] = HttpContext.Current?.Request?.UserHostAddress;
                LogicalThreadContext.Properties["EventUrl"] = HttpContext.Current?.Request?.Url?.AbsolutePath;
                LogicalThreadContext.Properties["EventMachineName"] = HttpContext.Current?.Request?.UserHostName;
                LogicalThreadContext.Properties["EventUserAgent"] = HttpContext.Current?.Request?.UserAgent;
                LogicalThreadContext.Properties["EventUrlReferrer"] = HttpContext.Current?.Request?.UrlReferrer?.AbsolutePath;
                
                var userId = _authHelper.GetCurrentUserId();
                if (string.IsNullOrEmpty(userId))
                    userId = _authHelper.PublicUserName;

                var orgId = _authHelper.GetCurrentOrganizationId();
                LogicalThreadContext.Properties["TenantUnit"] = _settings.TenantDbWord;
                LogicalThreadContext.Properties["TenantUnitId"] = orgId;
                LogicalThreadContext.Properties["OwnerGroup"] = _authHelper.GetDefaultRoles();
                LogicalThreadContext.Properties["OwnerPermissions"] = _authHelper.GetDefaultPermissions();
                LogicalThreadContext.Properties["CreatedBy"] = LogicalThreadContext.Properties["CreatedByUserName"] = userId;
                LogicalThreadContext.Properties["LastModifiedBy"] = LogicalThreadContext.Properties["LastModifiedByUserName"] = userId;

                switch (type)
                {
                    case LogLevel.INFO:
                        log.Info(message);
                        break;
                    case LogLevel.DEBUG:
                        log.Debug(message);
                        break;
                    case LogLevel.WARN:
                        log.Warn(message);
                        break;
                    case LogLevel.ERROR:
                        log.Error(message);
                        break;
                    case LogLevel.FATAL:
                        log.Fatal(message);
                        break;
                }

                result = 1;
            }
            catch (Exception exc)
            {
                throw new Exception("Cannot write into log, DB is not accessible looks like.", exc);
            }
            return result;
        }

        /// <summary>
        /// Updates the configuration.
        /// </summary>
        /// <param name="json">The json.</param>
        public void UpdateConfig(string json)
        {
            _customConfiguration.CurrentConfiguration = json;
            _bl.UpdateCustomConfiguration(_customConfiguration);
        }

        /// <summary>
        /// Resets to default.
        /// </summary>
        public void ResetToDefault()
        {
            _customConfiguration.CurrentConfiguration = _customConfiguration.DefaultConfiguration;
            _bl.UpdateCustomConfiguration(_customConfiguration);
        }
    }
}
