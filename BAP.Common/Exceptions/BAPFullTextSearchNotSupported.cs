// ***********************************************************************
// Assembly         : BAP.Common
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 06-26-2020
// ***********************************************************************
// <copyright file="BAPFullTextSearchNotSupported.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.Common.Exceptions
{
    /// <summary>
    /// Exception is raised when full text search is attempted on the entity where full text search is not supported.
    /// </summary>
    public class BAPFullTextSearchNotSupported : BAPException
    {
    }
}
