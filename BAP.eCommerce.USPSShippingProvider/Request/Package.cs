// ***********************************************************************
// Assembly         : BAP.eCommerce.USPSShippingProvider
// Author           : Victor Mamray
// Created          : 05-30-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-18-2020
// ***********************************************************************
// <copyright file="Package.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace BAP.eCommerce.USPSShippingProvider.Request
{
    /// <summary>
    /// Class Package.
    /// </summary>
    [Serializable]
    public class Package
    {
        /// <summary>
        /// Gets or sets the type of the packaging.
        /// </summary>
        /// <value>The type of the packaging.</value>
        public PackagingType PackagingType { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the package weight.
        /// </summary>
        /// <value>The package weight.</value>
        public PackageWeight PackageWeight { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Package"/> class.
        /// </summary>
        public Package()
        {
            PackagingType = new PackagingType();
            PackageWeight = new PackageWeight();
        }
    }
}
