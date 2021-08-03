// ***********************************************************************
// Assembly         : BAP.Common
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-17-2020
// ***********************************************************************
// <copyright file="IRegistrationEngine.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.Common.Registration
{
    /// <summary>
    /// Interface to describe common registrator with the system. This is used but not limited to be user or tenant regsiration.
    /// </summary>
    public interface IRegistrationEngine
    {
        /// <summary>
        /// Does registratin formalities of the user or other enity inside the system.
        /// </summary>
        /// <param name="model">Registration data</param>
        /// <returns>Registration result</returns>
        RegistrationResponse Register(RegistrationModel model);
    }
}
