using BAP.Common;

namespace BAP.SelfSetup.Models
{
    public class OrganizationConfig : IBapOrganizationEntity
    {
        public string Name { get; set; } = "BAP Application";

        public string Description { get; set; }

        public string TaxId { get; set; }

        public string Status { get; set; } = "Final";

        public string TenantUnit { get; set; } = "Organization";

        public int? TenantUnitId { get; set; }

        public int OrganizationType { get; set; } = 1;

        public string AddressLine1 { get; set; } = "31 Ashgrove, Glencairin, Dooradoyle";
        
        public string AddressLine2 { get; set; }

        public string City { get; set; } = "Limerick";

        public string County { get; set; } = "Limerick";

        public string State { get; set; } = "Munster";

        public string Country { get; set; } = "Ireland";
        
        public string Zip { get; set; }

        public string PhoneNumber { get; set; } = "(555) 123-1212";

        public string PhoneExtension { get; set; }

        public string FaxNumber { get; set; }
        
        public string LogoPathUrl { get; set; }

        public string FacebookUrl { get; set; } = "http://facebook.com/bapsoftware";

        public string TwitterUrl { get; set; } = "http://twitter.com";

        public string LinkedinUrl { get; set; } = "http://linkedin.com";

        public string GoogleplusUrl { get; set; } = "http://plus.google.com";

        public string InstagramUrl { get; set; } = "https://www.instagram.com";

        public string Url { get; set; }

        public string BlogUrl { get; set; }

        public string ContactEmail { get; set; } = "info@app.bap-software.com";

        public string SupportEmail { get; set; } = "support@app.bap-software.com";

        public string ImplementedCulturesText { get; set; } = "en-US,fr-CA,uk-UA,ru-RU";

        public string HostName { get; set; } = "127.0.0.1";

        public string HostNameAliasesText { get; set; } =
            "localhost:50678,app.bap-software.comd,app-dev.bap-software.com";

        public string BapDefaultFromEmail { get; set; } = "support@yako-paddle.com";

        public string BapDefaultContactEmail { get; set; } = "info@yako-paddle.com";

        public string SmtpUserName { get; set; } = "support@bap-software.com";

        public string SmtpUserPassword { get; set; } = "Test$123";

        public string SmtpHostName { get; set; } = "mail.bap-software.com";

        public int SmtpPort { get; set; } = 8889;

        public bool SmtpUseSsl { get; set; } = false;

        public string reCaptchaSiteKey { get; set; } = "6LdeCwsUAAAAACxUJpxWB9Dfk036Rf8gEEccdOeI";

        public string reCaptchaSecretKey { get; set; } = "6LdeCwsUAAAAAP5SOPqX4_2m-BVMGfWJc43BDfgE";

        public bool GetBearrerTokenDuringLogin { get; set; } = true;

        public string AuthCookieName { get; set; } = "appbap-base-cookiie-name";

        public int AuthCookieExpirationTime { get; set; } = 20;

        public string WebApiPublicClientId { get; set; } = "appbap-web-api-client";

        public int BearerTokenExpirationTime { get; set; } = 14;

        public bool WebApiAllowInsecureHttp { get; set; } = true;

        public string PublicFolderText { get; set; } = "/Files/BapApplication/Public/";

        public string BaseFolderText { get; set; } = "/Files/BapApplication/";

        public bool CookiesPopupEnabled { get; set; }

        public bool GdprPopupEnabled { get; set; }
    }
}