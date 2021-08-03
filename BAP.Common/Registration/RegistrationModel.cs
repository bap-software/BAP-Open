// ***********************************************************************
// Assembly         : BAP.Common
// Author           : Victor Mamray
// Created          : 03-14-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-17-2020
// ***********************************************************************
// <copyright file="RegistrationModel.cs" company="BAP Software Ltd.">
//     Copyright © 2021 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace BAP.Common.Registration
{
    /// <summary>
    /// Describes data required for the registration inside system
    /// </summary>
    public class RegistrationModel
    {
        /// <summary>
        /// Assossiated ASP.Net user Id
        /// </summary>
        /// <value>The ASP net user identifier.</value>
        public string AspNetUserId { get; set; }

        /// <summary>
        /// User/organization email
        /// </summary>
        /// <value>The email.</value>
        public string Email { get; set; }

        /// <summary>
        /// Text representation of the registration type, used by registration engine then
        /// </summary>
        /// <value>The type of the registration.</value>
        public string RegistrationType { get; set; }

        /// <summary>
        /// Address line 1 of the user or organization
        /// </summary>
        /// <value>The address line1.</value>
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Address line 2 of the user or organization
        /// </summary>
        /// <value>The address line2.</value>
        public string AddressLine2 { get; set; }

        /// <summary>
        /// Address City of the user or organization
        /// </summary>
        /// <value>The city.</value>
        public string City { get; set; }

        /// <summary>
        /// Address County of the user or organization
        /// </summary>
        /// <value>The county.</value>
        public string County { get; set; }

        /// <summary>
        /// Address State of the user or organization
        /// </summary>
        /// <value>The state.</value>
        public string State { get; set; }

        /// <summary>
        /// Address Country of the user or organization
        /// </summary>
        /// <value>The country.</value>
        public string Country { get; set; }

        /// <summary>
        /// Address Postal Code of the user or organization
        /// </summary>
        /// <value>The zip.</value>
        public string Zip { get; set; }

        /// <summary>
        /// First name of the user or contant person of the organization
        /// </summary>
        /// <value>The first name.</value>
        public string FirstName { get; set; }
        /// <summary>
        /// Last name of the user or contant person of the organization
        /// </summary>
        /// <value>The last name.</value>
        public string LastName { get; set; }
        /// <summary>
        /// Middle name of the user or contant person of the organization
        /// </summary>
        /// <value>The name of the midle.</value>
        public string MidleName { get; set; }
        /// <summary>
        /// Work phone of the user or organization
        /// </summary>
        /// <value>The work phone.</value>
        public string WorkPhone { get; set; }
        /// <summary>
        /// Work phone extension of the user or organization
        /// </summary>
        /// <value>The work phone ext.</value>
        public string WorkPhoneExt { get; set; }
        /// <summary>
        /// Mobile phone number of the user or organization
        /// </summary>
        /// <value>The mobile phone.</value>
        public string MobilePhone { get; set; }
        /// <summary>
        /// Home phone number of the user or organization
        /// </summary>
        /// <value>The home phone.</value>
        public string HomePhone { get; set; }
        /// <summary>
        /// Fax number of the user or organization
        /// </summary>
        /// <value>The fax number.</value>
        public string FaxNumber { get; set; }
        /// <summary>
        /// Company registration number (some publically known number, given by state authorities)
        /// </summary>
        /// <value>The company number.</value>
        public string CompanyNumber { get; set; }
        /// <summary>
        /// Oficial organization name
        /// </summary>
        /// <value>The name of the company.</value>
        public string CompanyName { get; set; }
        /// <summary>
        /// Organization description
        /// </summary>
        /// <value>The company description.</value>
        public string CompanyDescription { get; set; }
        /// <summary>
        /// Tax number of the company (e.g. VAT number)
        /// </summary>
        /// <value>The tax number.</value>
        public string TaxNumber { get; set; }
        /// <summary>
        /// Licence number of the organization
        /// </summary>
        /// <value>The license number.</value>
        public string LicenseNumber { get; set; }
        /// <summary>
        /// Insurance number of the organization
        /// </summary>
        /// <value>The insurance number.</value>
        public string InsuranceNumber { get; set; }
        /// <summary>
        /// Web site URL of the user or organization
        /// </summary>
        /// <value>The URL.</value>
        public string Url { get; set; }
        /// <summary>
        /// Type of the subscription
        /// </summary>
        /// <value>The type of the subscription.</value>
        public string SubscriptionType { get; set; }
        /// <summary>
        /// Term of the subscription (e.g. month, annual)
        /// </summary>
        /// <value>The subscription term.</value>
        public string SubscriptionTerm { get; set; }
    }
}
