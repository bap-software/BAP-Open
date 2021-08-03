// ***********************************************************************
// Assembly         : BAP.DAL
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="BapResourceManager.cs" company="BAP Software Ltd.">
//     Copyright © 2015 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;

using BAP.Common;
using BAP.DAL.Entities;

namespace BAP.DAL.ResourceUtils
{
    /// <summary>
    /// BAP custom resource manager, it works using Database instead of XML files
    /// TODO: implement real caching with ability to invalidate it.
    /// </summary>
    public class BapResourceManager : System.Resources.ResourceManager, IDisposable
    {
        /// <summary>
        /// The bap database connectionname
        /// </summary>
        protected readonly string _bapDbConnectionname;
        /// <summary>
        /// The localizations
        /// </summary>
        protected List<Localization> _localizations;
        /// <summary>
        /// The configuration helper
        /// </summary>
        protected readonly IConfigHelper _configHelper;
        /// <summary>
        /// The cache
        /// </summary>
        protected readonly ApplicationCache _cache;

        /// <summary>
        /// Using this constructor initates also application usage, others are cacheless.
        /// </summary>
        /// <param name="configHelper">Injectable instance of ConfigHelper class.</param>
        public BapResourceManager(IConfigHelper configHelper)
            : base()
        {
            _configHelper = configHelper;
            _bapDbConnectionname = _configHelper.BapDbConnName;
            _cache = new ApplicationCache(configHelper);
            Init();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BapResourceManager"/> class.
        /// </summary>
        /// <param name="resourceSource">The resource source.</param>
        /// <param name="dbConnectionName">Name of the database connection.</param>
        public BapResourceManager(Type resourceSource, string dbConnectionName) 
            : base(resourceSource)
        {
            _bapDbConnectionname = dbConnectionName;
            Init(resourceSource.FullName);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BapResourceManager"/> class.
        /// </summary>
        /// <param name="baseName">Name of the base.</param>
        /// <param name="assembly">The assembly.</param>
        /// <param name="dbConnectionName">Name of the database connection.</param>
        public BapResourceManager(string baseName, Assembly assembly, string dbConnectionName) 
            : base(baseName, assembly)
        {
            _bapDbConnectionname = dbConnectionName;
            Init(baseName);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BapResourceManager"/> class.
        /// </summary>
        /// <param name="baseName">Name of the base.</param>
        /// <param name="assembly">The assembly.</param>
        /// <param name="usingResourceSet">The using resource set.</param>
        /// <param name="dbConnectionName">Name of the database connection.</param>
        public BapResourceManager(string baseName, Assembly assembly, Type usingResourceSet, string dbConnectionName) 
            : base(baseName, assembly, usingResourceSet)
        {
            _bapDbConnectionname = dbConnectionName;
            Init(baseName);
        }


        /// <summary>
        /// Initializes the specified base name.
        /// </summary>
        /// <param name="baseName">Name of the base.</param>
        protected void Init(string baseName = null)
        {
            try
            {
                using (var context = new BapDb("name=" + _bapDbConnectionname))
                {
                    if (!string.IsNullOrEmpty(baseName))
                        _localizations = context.Localizations.Where(a => a.ResourceSet.Equals(baseName, StringComparison.InvariantCultureIgnoreCase)).ToList();
                    else
                        _localizations = context.Localizations.ToList();
                }
            }
            catch
            {
                _localizations = new List<Localization>();
            }
        }

        /// <summary>
        /// Gets the configuration helper.
        /// </summary>
        /// <value>The configuration helper.</value>
        public IConfigHelper ConfigHelper
        {
            get
            {
                return _configHelper;
            }
        }

        /// <summary>
        /// Upserts the localization.
        /// </summary>
        /// <param name="localization">The localization.</param>
        public void UpsertLocalization(Localization localization)
        {
            if (_localizations == null)
                Init(this.BaseName);

            var target = _localizations.SingleOrDefault(a => a.Name == localization.Name && a.ResourceSet == localization.ResourceSet && a.CultureCode == localization.CultureCode);
            if(target != null)
            {
                target.Value = localization.Value;
            }
            else
            {
                _localizations.Add(localization);
            }
        }

        /// <summary>
        /// Returns the value of the specified string resource.
        /// </summary>
        /// <param name="name">The name of the resource to retrieve.</param>
        /// <returns>The value of the resource localized for the caller's current UI culture, or <see langword="null" /> if <paramref name="name" /> cannot be found in a resource set.</returns>
        public override string GetString(string name)
        {            
            return GetString(name, Thread.CurrentThread.CurrentUICulture);
        }

        /// <summary>
        /// Returns the value of the string resource localized for the specified culture.
        /// </summary>
        /// <param name="name">The name of the resource to retrieve.</param>
        /// <param name="culture">An object that represents the culture for which the resource is localized.</param>
        /// <returns>The value of the resource localized for the specified culture, or <see langword="null" /> if <paramref name="name" /> cannot be found in a resource set.</returns>
        public override string GetString(string name, CultureInfo culture)
        {
            if (_localizations == null)
                Init(this.BaseName);

            if (!string.IsNullOrEmpty(name) &&_localizations != null && _localizations.Any())
            {
                if(culture == null)
                    culture = Thread.CurrentThread.CurrentUICulture;
                var cultureCode = culture.Name;

                Localization cultureInDb = null;

                if(!name.Contains("."))
                {
                    cultureInDb = _localizations.SingleOrDefault(a => a.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase) && !string.IsNullOrEmpty(a.CultureCode) && a.CultureCode.Equals(cultureCode, StringComparison.InvariantCultureIgnoreCase));
                    if (cultureInDb == null)
                        cultureInDb = _localizations.SingleOrDefault(a => a.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase) && (string.IsNullOrEmpty(a.CultureCode) || a.CultureCode.Equals(CultureHelper.DefaultImplementedCulture, StringComparison.InvariantCultureIgnoreCase)));
                }
                else
                {
                    var resSetName = name.Substring(0, name.LastIndexOf("."));
                    var resourceName = name.Substring(name.LastIndexOf(".") + 1);
                    cultureInDb = _localizations.SingleOrDefault(a => a.Name.Equals(resourceName, StringComparison.InvariantCultureIgnoreCase) && a.ResourceSet.Equals(resSetName, StringComparison.InvariantCultureIgnoreCase) && !string.IsNullOrEmpty(a.CultureCode) && a.CultureCode.Equals(cultureCode, StringComparison.InvariantCultureIgnoreCase));
                    if (cultureInDb == null)
                        cultureInDb = _localizations.SingleOrDefault(a => a.Name.Equals(resourceName, StringComparison.InvariantCultureIgnoreCase) && a.ResourceSet.Equals(resSetName, StringComparison.InvariantCultureIgnoreCase) && (string.IsNullOrEmpty(a.CultureCode) || a.CultureCode.Equals(CultureHelper.DefaultImplementedCulture, StringComparison.InvariantCultureIgnoreCase)));
                }

                if (cultureInDb != null)
                    return cultureInDb.Value;
            }
            return null;
        }

        /// <summary>
        /// Tells the resource manager to call the <see cref="M:System.Resources.ResourceSet.Close" /> method on all <see cref="T:System.Resources.ResourceSet" /> objects and release all resources.
        /// </summary>
        public override void ReleaseAllResources()
        {
            _localizations = null;
        }

        /// <summary>
        /// The disposed
        /// </summary>
        private bool _disposed = false;
        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    if (_cache != null)
                        _cache.Dispose();
                }
            }
            this._disposed = true;
        }

        /// <summary>
        /// Disposes this instance.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
