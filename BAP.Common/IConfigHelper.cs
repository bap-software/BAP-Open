// ***********************************************************************
// Assembly         : BAP.Common
// Author           : Victor Mamray
// Created          : 06-26-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-26-2020
// ***********************************************************************
// <copyright file="IConfigHelper.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.Common
{
    /// <summary>
    /// Interface IConfigHelper
    /// </summary>
    public interface IConfigHelper
    {
        /// <summary>
        /// Gets the name of the bap database connection.
        /// </summary>
        /// <value>The name of the bap database connection.</value>
        string BapDbConnName { get; }

        //Configuration methods
        /// <summary>
        /// Reads the string.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="defaultStr">The default string.</param>
        /// <returns>System.String.</returns>
        string ReadString(string name, string defaultStr = "");
        /// <summary>
        /// Reads the int.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="defaultInt">The default int.</param>
        /// <returns>System.Int32.</returns>
        int ReadInt(string name, int defaultInt = 0);
        /// <summary>
        /// Reads the boolean.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="defaultBool">if set to <c>true</c> [default bool].</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool ReadBoolean(string name, bool defaultBool = false);

        //Tenancy settings
        /// <summary>
        /// Gets the tenant database word.
        /// </summary>
        /// <value>The tenant database word.</value>
        string TenantDbWord { get; }

        //Paging settings
        /// <summary>
        /// Gets the default size of the page.
        /// </summary>
        /// <value>The default size of the page.</value>
        int DefaultPageSize { get; }
        /// <summary>
        /// Gets the size of the fake maximum page.
        /// </summary>
        /// <value>The size of the fake maximum page.</value>
        int FakeMaxPageSize { get; }

        //Captcha settings        
        /// <summary>
        /// Gets the re captcha validate URL.
        /// </summary>
        /// <value>The re captcha validate URL.</value>
        string reCaptchaValidateUrl { get; }

        //Others
        /// <summary>
        /// Gets the allowed file extensions.
        /// </summary>
        /// <value>The allowed file extensions.</value>
        string[] AllowedFileExtensions { get; }
        /// <summary>
        /// Gets a value indicating whether [use cache].
        /// </summary>
        /// <value><c>true</c> if [use cache]; otherwise, <c>false</c>.</value>
        bool UseCache { get; }
        /// <summary>
        /// Gets a value indicating whether [redis cache eanbled].
        /// </summary>
        /// <value><c>true</c> if [redis cache eanbled]; otherwise, <c>false</c>.</value>
        bool RedisCacheEanbled { get; }
        /// <summary>
        /// Gets the redis cache host.
        /// </summary>
        /// <value>The redis cache host.</value>
        string RedisCacheHost { get; }
        /// <summary>
        /// Gets the cache expiration time.
        /// </summary>
        /// <value>The cache expiration time.</value>
        int CacheExpirationTime { get; }

        /// <summary>
        /// Gets the built in job user.
        /// </summary>
        /// <value>The built in job user.</value>
        string BuiltInJobUser { get; }
    }
}
