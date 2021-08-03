// ***********************************************************************
// Assembly         : BAP.DAL
// Author           : Victor Mamray
// Created          : 08-16-2020
//
// Last Modified By : Victor Mamray
// Last Modified On : 08-16-2020
// ***********************************************************************
// <copyright file="Organization.cs" company="BAP Software Ltd.">
//     Copyright © 2015 BAP Software Ltd.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Web;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using BAP.Common;

namespace BAP.DAL.Entities
{
    /// <summary>
    /// Class Organization.
    /// Implements the <see cref="BAP.Common.IBapEntity" />
    /// Implements the <see cref="BAP.Common.IBapEntityWithState" />
    /// Implements the <see cref="BAP.Common.ISupportLocalization" />
    /// </summary>
    /// <seealso cref="BAP.Common.IBapEntity" />
    /// <seealso cref="BAP.Common.IBapEntityWithState" />
    /// <seealso cref="BAP.Common.ISupportLocalization" />
    [Table("Organization")]
    public class Organization : IBapEntity, IBapOrganizationEntity, IBapEntityWithState, ISupportLocalization
    {
        /// <summary>
        /// State of the BAP entity in terms of EF context.
        /// </summary>
        /// <value>The state of the entity.</value>
        [NotMapped]
        public BAPEntityState EntityState { get; set; }

        /// <summary>
        /// To identify culture neutral entity and to gather identical but different by language entities
        /// </summary>
        /// <value>The localized properties.</value>
        [NotMapped]
        public string[] LocalizedProperties => new string[] { "Name", "Description" };


        /// <summary>
        /// Internal identifier of the entity, also identity field in DB.
        /// </summary>
        /// <value>The identifier.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Name of the entity, in most of the cases it has to be unique within given tenant scope.
        /// </summary>
        /// <value>The name.</value>
        [Index("IX_OrganizationName", 1, IsUnique = true)]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_Name")]
        [StringLength(80)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_Description")]
        [StringLength(255)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the tax identifier.
        /// </summary>
        /// <value>The tax identifier.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_TaxId")]
        [StringLength(80)]
        public string TaxId { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_Status")]
        [StringLength(80)]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the status date.
        /// </summary>
        /// <value>The status date.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_StatusDate")]
        public DateTime StatusDate { get; set; }

        /// <summary>
        /// Type of tenant, currently only Organization is supported.
        /// </summary>
        /// <value>The tenant unit.</value>
        [StringLength(50)]
        [Index("IX_Tenant", 1)]
        public string TenantUnit { get; set; }

        /// <summary>
        /// Tenant identifier, in fact Organization Id for a moment.
        /// </summary>
        /// <value>The tenant unit identifier.</value>
        [Index("IX_Tenant", 2)]
        public int? TenantUnitId { get; set; }

        /// <summary>
        /// Date and time when entity was first inserted into system's DB.
        /// </summary>
        /// <value>The create date.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_CreateDate")]
        public DateTime? CreateDate { get; set; }

        /// <summary>
        /// Identifier of the user wh created an entity.
        /// </summary>
        /// <value>The created by.</value>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Date and time when entity was last modified.
        /// </summary>
        /// <value>The last modified date.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_LastModifiedDate")]
        public DateTime? LastModifiedDate { get; set; }

        /// <summary>
        /// Identifier of the user who modified entity last time.
        /// </summary>
        /// <value>The last modified by.</value>
        public string LastModifiedBy { get; set; }

        /// <summary>
        /// Timestamp assigned when entity was last modified, concurrency identificator.
        /// </summary>
        /// <value>The time stamp.</value>
        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] TimeStamp { get; set; }

        /// <summary>
        /// Gets the name of the created by user.
        /// </summary>
        /// <value>The name of the created by user.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_CreatedByUserName")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]//[dbo].[ufnGetUserName]([CreatedBy])
        public string CreatedByUserName { get; private set; }

        /// <summary>
        /// Gets the last name of the modified by user.
        /// </summary>
        /// <value>The last name of the modified by user.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_LastModifiedByUserName")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]//[dbo].[ufnGetUserName]([LastModifiedBy])
        public string LastModifiedByUserName { get; private set; }

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>The users.</value>
        public List<OrganizationUser> Users { get; set; }

        /// <summary>
        /// Gets or sets the subscriptions.
        /// </summary>
        /// <value>The subscriptions.</value>
        public List<Subscription> Subscriptions { get; set; }

        /// <summary>
        /// Gets or sets the type of the organization.
        /// </summary>
        /// <value>The type of the organization.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_OrganizationType")]        
        public int OrganizationType { get; set; }

        /// <summary>
        /// Gets or sets the address line1.
        /// </summary>
        /// <value>The address line1.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_AddressLine1")]
        [StringLength(80)]
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Gets or sets the address line2.
        /// </summary>
        /// <value>The address line2.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_AddressLine2")]
        [StringLength(80)]
        public string AddressLine2 { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>The city.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_City")]
        [StringLength(80)]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the county.
        /// </summary>
        /// <value>The county.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_County")]
        [StringLength(80)]
        public string County { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_State")]
        [StringLength(80)]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>The country.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_Country")]
        [StringLength(80)]
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the zip.
        /// </summary>
        /// <value>The zip.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_Zip")]
        [StringLength(5)]
        public string Zip { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        /// <value>The phone number.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_PhoneNumber")]
        [StringLength(20)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the phone extension.
        /// </summary>
        /// <value>The phone extension.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_PhoneExtension")]
        [StringLength(5)]
        public string PhoneExtension { get; set; }

        /// <summary>
        /// Gets or sets the fax number.
        /// </summary>
        /// <value>The fax number.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_FaxNumber")]
        [StringLength(20)]
        public string FaxNumber { get; set; }

        /// <summary>
        /// Bitmask holding data what roles are allowed to access this type of entity.
        /// </summary>
        /// <value>The owner group.</value>
        [Index]
        [DefaultValue(127)]
        public int OwnerGroup { get; set; }
        /// <summary>
        /// Bitmask holding data what types of permissions are allowed over this types of entity.
        /// </summary>
        /// <value>The owner permissions.</value>
        [Index]
        [DefaultValue(310991)]
        public int OwnerPermissions { get; set; }

        /// <summary>
        /// Gets or sets the logo file.
        /// </summary>
        /// <value>The logo file.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_LogoFile")]
        [NotMapped]
        public HttpPostedFileBase LogoFile { get; set; }

        /// <summary>
        /// Gets or sets the logo path URL.
        /// </summary>
        /// <value>The logo path URL.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_LogoPathUrl")]
        [StringLength(255)]
        public string LogoPathUrl { get; set; }

        /// <summary>
        /// Gets or sets the facebook URL.
        /// </summary>
        /// <value>The facebook URL.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_FacebookUrl")]
        [StringLength(255)]
        public string FacebookUrl { get; set; }

        /// <summary>
        /// Gets or sets the twitter URL.
        /// </summary>
        /// <value>The twitter URL.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_TwitterUrl")]
        [StringLength(255)]
        public string TwitterUrl { get; set; }

        /// <summary>
        /// Gets or sets the linkedin URL.
        /// </summary>
        /// <value>The linkedin URL.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_LinkedinUrl")]
        [StringLength(255)]
        public string LinkedinUrl { get; set; }

        /// <summary>
        /// Gets or sets the googleplus URL.
        /// </summary>
        /// <value>The googleplus URL.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_GoogleplusUrl")]
        [StringLength(255)]
        public string GoogleplusUrl { get; set; }

        /// <summary>
        /// Gets or sets the instagram URL.
        /// </summary>
        /// <value>The instagram URL.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_InstagramUrl")]
        [StringLength(255)]
        public string InstagramUrl { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>The URL.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_Url")]
        [StringLength(255)]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the blog URL.
        /// </summary>
        /// <value>The blog URL.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_BlogUrl")]
        [StringLength(255)]
        public string BlogUrl { get; set; }

        /// <summary>
        /// Gets or sets the contact email.
        /// </summary>
        /// <value>The contact email.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_ContactEmail")]
        [StringLength(255)]
        public string ContactEmail { get; set; }

        /// <summary>
        /// Gets or sets the support email.
        /// </summary>
        /// <value>The support email.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_SupportEmail")]
        [StringLength(255)]
        public string SupportEmail { get; set; }

        // New fields 09032017
        /// <summary>
        /// Gets or sets the implemented cultures text.
        /// </summary>
        /// <value>The implemented cultures text.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_ImplementedCulturesText")]
        [StringLength(255)]
        public string ImplementedCulturesText { get; set; }

        /// <summary>
        /// Gets the implemented cultures.
        /// </summary>
        /// <value>The implemented cultures.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_ImplementedCultures")]
        [NotMapped]
        public string[] ImplementedCultures
        {
            get
            {
                if (!string.IsNullOrEmpty(ImplementedCulturesText))
                    return ImplementedCulturesText.Split(",".ToCharArray());

                return null;
            }
        }

        /// <summary>
        /// Gets or sets the name of the host.
        /// </summary>
        /// <value>The name of the host.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_HostName")]
        [StringLength(255)]
        public string HostName { get; set; }

        /// <summary>
        /// Gets or sets the host name aliases text.
        /// </summary>
        /// <value>The host name aliases text.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_HostNameAliasesText")]
        [StringLength(2048)]
        public string HostNameAliasesText { get; set; }

        /// <summary>
        /// Gets the host name aliases.
        /// </summary>
        /// <value>The host name aliases.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_HostNameAliases")]
        [NotMapped]
        public string[] HostNameAliases
        {
            get
            {
                if (!string.IsNullOrEmpty(HostNameAliasesText))
                    return HostNameAliasesText.Split(",".ToCharArray());

                return null;
            }
        }

        /// <summary>
        /// Gets or sets the bap default from email.
        /// </summary>
        /// <value>The bap default from email.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_BapDefaultFromEmail")]
        [StringLength(255)]
        public string BapDefaultFromEmail { get; set; }

        /// <summary>
        /// Gets or sets the bap default contact email.
        /// </summary>
        /// <value>The bap default contact email.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_BapDefaultContactEmail")]
        [StringLength(255)]
        public string BapDefaultContactEmail { get; set; }

        /// <summary>
        /// Gets or sets the name of the SMTP user.
        /// </summary>
        /// <value>The name of the SMTP user.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_SmtpUserName")]
        [StringLength(255)]
        public string SmtpUserName { get; set; }

        /// <summary>
        /// Gets or sets the SMTP user password.
        /// </summary>
        /// <value>The SMTP user password.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_SmtpUserPassword")]
        [StringLength(255)]
        public string SmtpUserPassword { get; set; }

        /// <summary>
        /// Gets or sets the name of the SMTP host.
        /// </summary>
        /// <value>The name of the SMTP host.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_SmtpHostName")]
        [StringLength(255)]
        public string SmtpHostName { get; set; }

        /// <summary>
        /// Gets or sets the SMTP port.
        /// </summary>
        /// <value>The SMTP port.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_SmtpPort")]        
        public int SmtpPort { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [SMTP use SSL].
        /// </summary>
        /// <value><c>true</c> if [SMTP use SSL]; otherwise, <c>false</c>.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_SmtpUseSsl")]
        public bool SmtpUseSsl { get; set; }

        /// <summary>
        /// Gets or sets the re captcha site key.
        /// </summary>
        /// <value>The re captcha site key.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_reCaptchaSiteKey")]
        [StringLength(255)]
        public string reCaptchaSiteKey { get; set; }

        /// <summary>
        /// Gets or sets the re captcha secret key.
        /// </summary>
        /// <value>The re captcha secret key.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_reCaptchaSecretKey")]
        [StringLength(255)]
        public string reCaptchaSecretKey { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [get bearrer token during login].
        /// </summary>
        /// <value><c>true</c> if [get bearrer token during login]; otherwise, <c>false</c>.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_GetBearrerTokenDuringLogin")]        
        public bool GetBearrerTokenDuringLogin { get; set; }

        /// <summary>
        /// Gets or sets the name of the authentication cookie.
        /// </summary>
        /// <value>The name of the authentication cookie.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_AuthCookieName")]
        [StringLength(255)]
        public string AuthCookieName { get; set; }

        /// <summary>
        /// Gets or sets the authentication cookie expiration time.
        /// </summary>
        /// <value>The authentication cookie expiration time.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_AuthCookieExpirationTime")]        
        public int AuthCookieExpirationTime { get; set; }

        /// <summary>
        /// Gets or sets the web API public client identifier.
        /// </summary>
        /// <value>The web API public client identifier.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_WebApiPublicClientId")]
        [StringLength(255)]
        public string WebApiPublicClientId { get; set; }

        /// <summary>
        /// Gets or sets the bearer token expiration time.
        /// </summary>
        /// <value>The bearer token expiration time.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_BearerTokenExpirationTime")]
        public int BearerTokenExpirationTime { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [web API allow insecure HTTP].
        /// </summary>
        /// <value><c>true</c> if [web API allow insecure HTTP]; otherwise, <c>false</c>.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_WebApiAllowInsecureHttp")]
        public bool WebApiAllowInsecureHttp { get; set; }

        /// <summary>
        /// Gets or sets the public folder text.
        /// </summary>
        /// <value>The public folder text.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_PublicFolderText")]
        [StringLength(255)]
        public string PublicFolderText { get; set; }

        /// <summary>
        /// Gets the public folder.
        /// </summary>
        /// <value>The public folder.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_PublicFolder")]
        [NotMapped]
        public string PublicFolder
        {
            get
            {
                if (!string.IsNullOrEmpty(PublicFolderText))
                    return PublicFolderText;

                return "/Files/BapApplication/Public/";
            }
        }

        /// <summary>
        /// Gets or sets the base folder text.
        /// </summary>
        /// <value>The base folder text.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_BaseFolderText")]
        [StringLength(255)]
        public string BaseFolderText { get; set; }

        /// <summary>
        /// Gets the base folder.
        /// </summary>
        /// <value>The base folder.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_BaseFolder")]
        [NotMapped]
        public string BaseFolder
        {
            get
            {
                
                if (!string.IsNullOrEmpty(BaseFolderText))
                    return BaseFolderText;

                return "/Files/BapApplication/";
            }
        }

        /// <summary>
        /// Gets or sets the organization modules.
        /// </summary>
        /// <value>The organization modules.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_OrganizationModules")]
        public virtual List<OrganizationModule> OrganizationModules { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [cookies popup enabled].
        /// </summary>
        /// <value><c>true</c> if [cookies popup enabled]; otherwise, <c>false</c>.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_CookiesPopupEnabled")]
        public bool CookiesPopupEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [GDPR popup enabled].
        /// </summary>
        /// <value><c>true</c> if [GDPR popup enabled]; otherwise, <c>false</c>.</value>
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Organization_GdprPopupEnabled")]
        public bool GdprPopupEnabled { get; set; }
    }
}
