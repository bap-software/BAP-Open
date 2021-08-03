// ***********************************************************************
// Assembly         : BAP.Email
// Author           : Victor Mamray
// Created          : 04-20-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="Mailer.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
///Base mailer class used by other BAP components
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

using BAP.Common;
using BAP.Log;
using BAP.DAL.Entities;
using Newtonsoft.Json;
using BAP.BL;
using BAP.DAL;

namespace BAP.Email
{
    /// <summary>
    /// Class Mailer.
    /// Implements the <see cref="BAP.Email.IMailer" />
    /// Implements the <see cref="System.IDisposable" />
    /// Implements the <see cref="BAP.Common.ISupportCustomConfig" />
    /// </summary>
    /// <seealso cref="BAP.Email.IMailer" />
    /// <seealso cref="System.IDisposable" />
    /// <seealso cref="BAP.Common.ISupportCustomConfig" />
    public class Mailer : IMailer, IDisposable, ISupportCustomConfig
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger _logger;
        /// <summary>
        /// The SMTP client
        /// </summary>
        private readonly SmtpClient _smtpClient;
        /// <summary>
        /// The configuration
        /// </summary>
        private readonly MailerConfig _config;
        /// <summary>
        /// The bl
        /// </summary>
        private readonly ICustomConfigurationBL _bl;
        /// <summary>
        /// The custom configuration
        /// </summary>
        private CustomConfiguration _customConfiguration;

        /// <summary>
        /// Gets the default from address.
        /// </summary>
        /// <value>The default from address.</value>
        public string DefaultFromAddress => _config.DefaultFromEmail;

        /// <summary>
        /// Gets a value indicating whether [supports custom configuration].
        /// </summary>
        /// <value><c>true</c> if [supports custom configuration]; otherwise, <c>false</c>.</value>
        public bool SupportsCustomConfig => true;

        /// <summary>
        /// Gets the custom configuration json example.
        /// </summary>
        /// <value>The custom configuration json example.</value>
        public string CustomConfigJsonExample => JsonConvert.SerializeObject(new MailerConfig());

        /// <summary>
        /// Gets the type of the custom configuration.
        /// </summary>
        /// <value>The type of the custom configuration.</value>
        public Type CustomConfigType => typeof(MailerConfig);

        /// <summary>
        /// Gets the current custom configuration json.
        /// </summary>
        /// <value>The current custom configuration json.</value>
        public string CurrentCustomConfigJson => _customConfiguration.CurrentConfiguration;

        /// <summary>
        /// Initializes a new instance of the <see cref="Mailer"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="context">The context.</param>
        public Mailer(ILogger logger, IConfigHelper settings, IAuthorizationContext context)
        {            
            _logger = logger;
            _smtpClient = new SmtpClient();
            _bl = new BusinessLayer(settings, context, logger);

            var type = typeof(Mailer);
            _customConfiguration = _bl.GetCustomConfigurationByName($"{type.Assembly.GetName().Name}_{type.Name}");
            if (_customConfiguration != null && !string.IsNullOrWhiteSpace(_customConfiguration.CurrentConfiguration))
                _config = JsonConvert.DeserializeObject<MailerConfig>(_customConfiguration.CurrentConfiguration);
            if (_config == null)
                _config = new MailerConfig();

            var credential = new NetworkCredential
            {
                UserName = _config.SmtpUserName,
                Password = _config.SmtpPassword
            };
            _smtpClient.Credentials = credential;
            _smtpClient.Host = _config.SmtpHost;
            _smtpClient.Port = _config.SmtpPort;
            _smtpClient.EnableSsl = _config.SmtpUseSSL;
        }

        /// <summary>
        /// Sends the email.
        /// </summary>
        /// <param name="fromAddress">From address.</param>
        /// <param name="toAddress">To address.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="body">The body.</param>
        /// <param name="isHtmlBody">if set to <c>true</c> [is HTML body].</param>
        public void SendEmail(string fromAddress, string toAddress, string subject, string body, bool isHtmlBody = true)
        {
            var message = PrepareMessage(fromAddress, toAddress, subject, body, isHtmlBody);
            
            _smtpClient.Send(message);            
            _logger.LogText("Mailer", "SendMail", $"Email has been sent from {fromAddress} to {toAddress}, subject is \"{subject}\"");
        }

        /// <summary>
        /// Sends the email asynchronous.
        /// </summary>
        /// <param name="fromAddress">From address.</param>
        /// <param name="toAddress">To address.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="body">The body.</param>
        /// <param name="isHtmlBody">if set to <c>true</c> [is HTML body].</param>
        /// <returns>Task.</returns>
        public Task SendEmailAsync(string fromAddress, string toAddress, string subject, string body, bool isHtmlBody = true)
        {
            var message = PrepareMessage(fromAddress, toAddress, subject, body, isHtmlBody);                       
            _logger.LogText("Mailer", "SendMail", $"Going to send email async from {fromAddress} to {toAddress}, subject is \"{subject}\"");
            return _smtpClient.SendMailAsync(message);           
        }

        /// <summary>
        /// Prepares the message.
        /// </summary>
        /// <param name="fromAddress">From address.</param>
        /// <param name="toAddress">To address.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="body">The body.</param>
        /// <param name="isHtmlBody">if set to <c>true</c> [is HTML body].</param>
        /// <returns>MailMessage.</returns>
        private MailMessage PrepareMessage(string fromAddress, string toAddress, string subject, string body, bool isHtmlBody = true)
        {            
            var message = new MailMessage { From = new MailAddress(_config.SmtpUserName) };
            message.To.Add(new MailAddress(toAddress));
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = isHtmlBody;            

            return message;
        }

        /// <summary>
        /// The disposed
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing && _smtpClient != null)
                {
                    _smtpClient.Dispose();
                }
            }
            this._disposed = true;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
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
