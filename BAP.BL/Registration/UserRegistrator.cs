// ***********************************************************************
// Assembly         : BAP.BL
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-17-2020
// ***********************************************************************
// <copyright file="UserRegistrator.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

using BAP.Common;
using BAP.Common.Registration;
using BAP.DAL.Entities;
using BAP.DAL;
using BAP.Log;

namespace BAP.BL.Registration
{
    /// <summary>
    /// User registration engine class, adds regular user to the system with the only role of User
    /// </summary>
    public class UserRegistrator : AbstractRegistrator, IRegistrationEngine
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRegistrator"/> class.
        /// </summary>
        /// <param name="configHelper">The configuration helper.</param>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        public UserRegistrator(IConfigHelper configHelper, IAuthorizationContext context, ILogger logger) : base(configHelper, context, logger)
        {

        }

        /// <summary>
        /// Registers the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>RegistrationResponse.</returns>
        /// <exception cref="Common.Exceptions.BAPNoDefaultOrganization"></exception>
        public RegistrationResponse Register(RegistrationModel model)
        {            
            var response = new RegistrationResponse();
            try
            {
                using (var bl = new BusinessLayer(_configHelper, _authContext, _logger))
                {
                    IOrganizationBL organizationBL = bl;
                    Organization organization = organizationBL.CurrentOrganzation();

                    if (organization == null)
                        throw new Common.Exceptions.BAPNoDefaultOrganization(Resources.Resources.ErrorText_NoDefaultOrganization);

                    var orgUser = new OrganizationUser()
                    {
                        Organization = organization,
                        AspNetUserId = model.AspNetUserId,
                        FirstName = model.FirstName,
                        MiddleName = model.MidleName,
                        LastName = model.LastName,
                        AddressLine1 = model.AddressLine1,
                        AddressLine2 = model.AddressLine2,
                        City = model.City,
                        County = model.County,
                        Country = model.Country,
                        State = model.State,
                        Zip = model.Zip,
                        PhoneNumber = model.HomePhone,
                        CellNumber = model.MobilePhone,
                        TenantUnit = "Organization",
                        TenantUnitId = organization.Id
                    };

                    IOrganizationUserBL orgUserBL = bl;
                    orgUserBL.AddOrganizationUser(orgUser);

                    if (orgUser != null && orgUser.Id > 0)
                    {
                        var authHelper = new AuthorizationHelper<OrganizationUser>(_configHelper, _authContext);
                        ISubscriptionBL subscriptionBL = bl;
                        var subscription = subscriptionBL.InitSubscription(model.SubscriptionType, model.SubscriptionTerm);
                        subscription.Organization = orgUser.Organization;
                        subscription.User = orgUser;
                        subscription.TenantUnit = "Organization";
                        subscription.TenantUnitId = orgUser.Organization.Id;
                        subscriptionBL.AddSubscription(subscription);

                        response.UserRoles = new[] { authHelper.BapUserRoleName };
                        response.Success = true;
                    }
                    else
                    {
                        response.Success = false;
                        response.Message = "Unable to register user under default organization";
                    }
                }                                
            }   
            catch(Exception exc)
            {
                response.Success = false;
                response.Message = "Exception occured:" + exc.Message;
                response.Exception = exc;
            }
            return response;     
        }       
    }
}
