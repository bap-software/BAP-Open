using System.ComponentModel.DataAnnotations.Schema;
using BAP.Common;

namespace BAP.SelfSetup.Db
{
    [Table("Organization")]
    public class SetupOrganization : IBapOrganizationEntity
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }

        public string TaxId { get; set; }

        public string Status { get; set; }

        public string TenantUnit { get; set; }

        public int? TenantUnitId { get; set; }

        public int OrganizationType { get; set; }

        public string AddressLine1 { get; set; }
        
        public string AddressLine2 { get; set; }

        public string City { get; set; }

        public string County { get; set; }

        public string State { get; set; }

        public string Country { get; set; }
        
        public string Zip { get; set; }

        public string PhoneNumber { get; set; }

        public string PhoneExtension { get; set; }

        public string FaxNumber { get; set; }
        
        public string LogoPathUrl { get; set; }

        public string FacebookUrl { get; set; }

        public string TwitterUrl { get; set; }

        public string LinkedinUrl { get; set; }

        public string GoogleplusUrl { get; set; }

        public string InstagramUrl { get; set; }

        public string Url { get; set; }

        public string BlogUrl { get; set; }

        public string ContactEmail { get; set; }

        public string SupportEmail { get; set; }

        public string ImplementedCulturesText { get; set; }

        public string HostName { get; set; }

        public string HostNameAliasesText { get; set; }

        public string BapDefaultFromEmail { get; set; }

        public string BapDefaultContactEmail { get; set; }

        public string SmtpUserName { get; set; }

        public string SmtpUserPassword { get; set; }

        public string SmtpHostName { get; set; }

        public int SmtpPort { get; set; }

        public bool SmtpUseSsl { get; set; }

        public string reCaptchaSiteKey { get; set; }

        public string reCaptchaSecretKey { get; set; }

        public bool GetBearrerTokenDuringLogin { get; set; }

        public string AuthCookieName { get; set; }
        
        public int AuthCookieExpirationTime { get; set; }

        public string WebApiPublicClientId { get; set; }

        public int BearerTokenExpirationTime { get; set; }

        public bool WebApiAllowInsecureHttp { get; set; }

        public string PublicFolderText { get; set; }

        public string BaseFolderText { get; set; }

        public bool CookiesPopupEnabled { get; set; }

        public bool GdprPopupEnabled { get; set; }
    }
}