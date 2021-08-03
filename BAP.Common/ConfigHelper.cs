// ***********************************************************************
// Assembly         : BAP.Common
// Author           : Victor Mamray
// Created          : 06-26-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 07-23-2020
// ***********************************************************************
// <copyright file="ConfigHelper.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Configuration;

namespace BAP.Common
{
    /// <summary>
    /// Class ConfigHelper. This class cannot be inherited.
    /// Implements the <see cref="BAP.Common.IConfigHelper" />
    /// </summary>
    /// <seealso cref="BAP.Common.IConfigHelper" />
    public sealed class ConfigHelper : IConfigHelper
    {
        /// <summary>
        /// Prevents a default instance of the <see cref="ConfigHelper"/> class from being created.
        /// </summary>
        private ConfigHelper()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigHelper"/> class.
        /// </summary>
        /// <param name="bapConnName">Name of the bap connection.</param>
        /// <param name="jobBuiltInUser">The job built in user.</param>
        public ConfigHelper(string bapConnName, string jobBuiltInUser)
        {
            BuiltInJobUser = jobBuiltInUser;
            BapDbConnName = bapConnName;
        }

        /// <summary>
        /// Gets the built in job user.
        /// </summary>
        /// <value>The built in job user.</value>
        public string BuiltInJobUser { get; private set; } = "worker@app.bap-software.com";

        /// <summary>
        /// Gets the name of the bap database connection.
        /// </summary>
        /// <value>The name of the bap database connection.</value>
        public string BapDbConnName { get; private set; } = "DefaultConnection";

        /// <summary>
        /// Reads the string.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="defaultStr">The default string.</param>
        /// <returns>System.String.</returns>
        public string ReadString(string name, string defaultStr = "")
        {
            var str = ConfigurationManager.AppSettings[name];
            var result = defaultStr;
            if (!string.IsNullOrEmpty(str))
                result = str;

            return result;
        }

        /// <summary>
        /// Reads the int.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="defaultInt">The default int.</param>
        /// <returns>System.Int32.</returns>
        public int ReadInt(string name, int defaultInt = 0)
        {
            var str = ConfigurationManager.AppSettings[name];
            var result = defaultInt;
            if (!string.IsNullOrEmpty(str))
                Int32.TryParse(str, out result);

            return result;
        }

        /// <summary>
        /// Reads the boolean.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="defaultBool">if set to <c>true</c> [default bool].</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ReadBoolean(string name, bool defaultBool = false)
        {
            var str = ConfigurationManager.AppSettings[name];
            var result = defaultBool;
            if (!string.IsNullOrEmpty(str))
                Boolean.TryParse(str, out result);

            return result;
        }

        /// <summary>
        /// Gets the tenant database word.
        /// </summary>
        /// <value>The tenant database word.</value>
        public string TenantDbWord
        {
            get
            {
                return ReadString("BAP.Common.TenantDbWord", "Organization");
            }
        }

        /// <summary>
        /// Gets the default size of the page.
        /// </summary>
        /// <value>The default size of the page.</value>
        public int DefaultPageSize
        {
            get { return ReadInt("BAP.Common.DefaultPageSize", 20); }
        }

        /// <summary>
        /// Gets the size of the fake maximum page.
        /// </summary>
        /// <value>The size of the fake maximum page.</value>
        public int FakeMaxPageSize
        {
            get { return ReadInt("BAP.Common.FakeMaxPageSize", 65536); }
        }

        /// <summary>
        /// Gets the re captcha validate URL.
        /// </summary>
        /// <value>The re captcha validate URL.</value>
        public string reCaptchaValidateUrl
        {
            get
            {
                return ReadString("BAP.Common.reCaptchaValidateUrl", "https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}");
            }
        }

        /// <summary>
        /// Gets the allowed file extensions.
        /// </summary>
        /// <value>The allowed file extensions.</value>
        public string[] AllowedFileExtensions
        {
            get
            {
                var setting = ReadString("BAP.Common.AllowedFileExtensions");
                if (!string.IsNullOrEmpty(setting))
                    return setting.Split(",".ToCharArray());

                return new string[]
                {
                    ".ico",
                    ".png",
                    ".jpg",
                    ".jpeg",
                    ".pdf",
                    ".txt",
                    ".xls",
                    ".xlsx",
                    ".doc",
                    ".docx",
                    ".json",
                    ".cshtml",
                    ".htm",
                    ".html",
                    ".waw",
                    ".mp3",
                    ".mp4"
                };
            }
        }

        /// <summary>
        /// Gets a value indicating whether [use cache].
        /// </summary>
        /// <value><c>true</c> if [use cache]; otherwise, <c>false</c>.</value>
        public bool UseCache
        {
            get
            {
                return ReadBoolean("BAP.Common.UseCache", false);
            }
        }

        /// <summary>
        /// Gets a value indicating whether [redis cache eanbled].
        /// </summary>
        /// <value><c>true</c> if [redis cache eanbled]; otherwise, <c>false</c>.</value>
        public bool RedisCacheEanbled
		{
			get
			{
				return ReadBoolean("BAP.Common.RedisCacheEanbled", false);
			}
		}

        /// <summary>
        /// Gets the redis cache host.
        /// </summary>
        /// <value>The redis cache host.</value>
        public string RedisCacheHost
		{
			get
			{
				return ReadString("BAP.Common.RedisCacheHost", "localhost");
			}
		}


        /// <summary>
        /// Gets the cache expiration time.
        /// </summary>
        /// <value>The cache expiration time.</value>
        public int CacheExpirationTime
        {
            get
            {
                return ReadInt("BAP.Common.CacheExpirationTime", 86400);
            }
        }                      
    }
}
