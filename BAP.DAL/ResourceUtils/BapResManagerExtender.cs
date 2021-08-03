// ***********************************************************************
// Assembly         : BAP.DAL
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="BapResManagerExtender.cs" company="BAP Software Ltd.">
//     Copyright © 2015 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Web.Mvc;
using System.Data.Entity;
using System.Collections.Generic;

using BAP.Common;
using BAP.DAL.Entities;

namespace BAP.DAL.ResourceUtils
{
    /// <summary>
    /// Class ResourceString.
    /// </summary>
    public class ResourceString
    {
        /// <summary>
        /// Gets or sets the locale.
        /// </summary>
        /// <value>The locale.</value>
        public string Locale { get; set; }
        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>The key.</value>
        public string Key { get; set; }
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public string Value { get; set; }
    }
    /// <summary>
    /// Class BapResManagerExtender.
    /// </summary>
    public class BapResManagerExtender 
    {
        /// <summary>
        /// The configuration helper
        /// </summary>
        private IConfigHelper _configHelper;
        /// <summary>
        /// The resource manager instance
        /// </summary>
        private BapResourceManager _resManagerInstance;

        /// <summary>
        /// Initializes a new instance of the <see cref="BapResManagerExtender"/> class.
        /// </summary>
        /// <param name="resManager">The resource manager.</param>
        /// <param name="configHelper">The configuration helper.</param>
        public BapResManagerExtender(BapResourceManager resManager, IConfigHelper configHelper) 
        {
            _configHelper = configHelper;
            _resManagerInstance = resManager;
        }

        /// <summary>
        /// Upserts the resource strings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="resources">The resources.</param>
        /// <param name="resourcesType">Type of the resources.</param>
        /// <param name="objectName">Name of the object.</param>
        /// <param name="objectId">The object identifier.</param>
        public void UpsertResourceStrings(DbContext context, List<ResourceString> resources, Type resourcesType = null, string objectName = null, int objectId = 0)
        {
            var resourceSet = _resManagerInstance.BaseName;
            if (string.IsNullOrEmpty(resourceSet) && resourcesType != null)
                resourceSet = resourcesType.FullName;

            //If resource set cannot be identified - we do nothing
            if (string.IsNullOrEmpty(resourceSet))
                return;

            var authContext = DependencyResolver.Current.GetService<IAuthorizationContext>();
            var localizationRepo = new GenericDataRepository<Localization>(context, new AuthorizationHelper<Localization>(_configHelper, authContext), _configHelper);
            foreach (var res in resources)
            {                
                var localization = localizationRepo.GetSingle(a => a.Name == res.Key && a.CultureCode == res.Locale && a.ResourceSet == resourceSet);
                
                //insert
                if (localization == null)
                {
                    localization = new Localization
                    {
                        CultureCode = res.Locale,
                        Name = res.Key,
                        Value = res.Value,
                        ResourceSet = resourceSet
                    };
                    if (objectName != null && objectId > 0)
                    {
                        localization.Object = objectName;
                        localization.ObjectId = objectId;
                    }
                    localizationRepo.Add(localization);
                    _resManagerInstance.UpsertLocalization(localization);
                }
                //update
                else if (!localization.Value.Equals(res.Value, StringComparison.InvariantCulture))
                {                    
                    //We allow to update value only, all other properties are set only once - on the insert
                    localization.Value = res.Value;
                    localizationRepo.Update(localization);
                    _resManagerInstance.UpsertLocalization(localization);
                }
            }            
        }
    }
}
