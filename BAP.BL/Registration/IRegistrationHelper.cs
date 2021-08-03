// ***********************************************************************
// Assembly         : BAP.BL
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-17-2020
// ***********************************************************************
// <copyright file="IRegistrationHelper.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using BAP.Common.Registration;

namespace BAP.BL.Registration
{
    /// <summary>
    /// Interface to describe injectable registration helper to be used in order to help registering users or tenant organizations
    /// </summary>
    public interface IRegistrationHelper
    {
        /// <summary>
        /// Gives instance of the particular registrator supporting IRegistrationEngine interface
        /// </summary>
        /// <param name="registrationType">Full or significant part of the name of registrator class</param>
        /// <returns>Registrator class instance supporting IRegistrationEngine interface</returns>
        IRegistrationEngine GetRegistrationEngine(string registrationType);
    }
}
