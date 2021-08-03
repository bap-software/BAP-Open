// ***********************************************************************
// Assembly         : BAP.UI
// Author           : Victor Mamray
// Created          : 07-20-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 07-20-2020
// ***********************************************************************
// <copyright file="ResourceManagerStringLocalizer.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Specialized;
using System.Resources;
using MvcSiteMapProvider.Globalization;

namespace BAP.UI
{
    /// <summary>
    /// Class ResourceManagerStringLocalizer.
    /// Implements the <see cref="MvcSiteMapProvider.Globalization.IStringLocalizer" />
    /// </summary>
    /// <seealso cref="MvcSiteMapProvider.Globalization.IStringLocalizer" />
    public class ResourceManagerStringLocalizer
        : IStringLocalizer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceManagerStringLocalizer"/> class.
        /// </summary>
        /// <param name="resourceManager">The resource manager.</param>
        /// <exception cref="ArgumentNullException">resourceManager</exception>
        public ResourceManagerStringLocalizer(ResourceManager resourceManager)
        {
            if (resourceManager == null)
                throw new ArgumentNullException("resourceManager");
            this.resourceManager = resourceManager;
        }
        /// <summary>
        /// The resource manager
        /// </summary>
        protected readonly ResourceManager resourceManager;

        /// <summary>
        /// Gets the localized text for the supplied attributeName.
        /// </summary>
        /// <param name="attributeName">The name of the attribute (as if it were in the original XML file).</param>
        /// <param name="value">The current object's value of the attribute.</param>
        /// <param name="enableLocalization">True if localization has been enabled, otherwise false.</param>
        /// <param name="classKey">The resource key from the ISiteMap class.</param>
        /// <param name="implicitResourceKey">The implicit resource key.</param>
        /// <param name="explicitResourceKeys">A <see cref="T:System.Collections.Specialized.NameValueCollection" /> containing the explicit resource keys.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="ArgumentNullException">attributeName</exception>
        public virtual string GetResourceString(string attributeName, string value, bool enableLocalization, string classKey, string implicitResourceKey, NameValueCollection explicitResourceKeys)
        {
            if (attributeName == null)
            {
                throw new ArgumentNullException("attributeName");
            }

            if (enableLocalization)
            {
                
                string result = string.Empty;
                if (explicitResourceKeys != null)
                {
                    string[] values = explicitResourceKeys.GetValues(attributeName);
                    if ((values == null) || (values.Length <= 1))
                    {
                        result = value;
                    }
                    else
                    {
                        try
                        {
                            result = this.resourceManager.GetString($"{values[0]}.{values[1]}");
                        }
                        catch (MissingManifestResourceException)
                        {
                            if (!string.IsNullOrEmpty(value))
                            {
                                result = value;
                            }
                        }
                    }
                }
                if (!string.IsNullOrEmpty(result))
                {
                    return result;
                }
            }
            if (!string.IsNullOrEmpty(value))
            {
                return value;
            }

            return string.Empty;
        }
    }
}