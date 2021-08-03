namespace BAP.Common
{
    public interface IBapOrganizationEntity
    {
        string Name { get; set; }
        string Description { get; set; }
        string TaxId { get; set; }
        string Status { get; set; }
        string TenantUnit { get; set; }
        int? TenantUnitId { get; set; }
        int OrganizationType { get; set; }
        string AddressLine1 { get; set; }
        string AddressLine2 { get; set; }
        string City { get; set; }
        string County { get; set; }
        string State { get; set; }
        string Country { get; set; }
        string Zip { get; set; }
        string PhoneNumber { get; set; }
        string PhoneExtension { get; set; }
        string FaxNumber { get; set; }
        string LogoPathUrl { get; set; }
        string FacebookUrl { get; set; }
        string TwitterUrl { get; set; }
        string LinkedinUrl { get; set; }
        string GoogleplusUrl { get; set; }
        string InstagramUrl { get; set; }
        string Url { get; set; }
        string BlogUrl { get; set; }
        string ContactEmail { get; set; }
        string SupportEmail { get; set; }
        string ImplementedCulturesText { get; set; }
        string HostName { get; set; }
        string HostNameAliasesText { get; set; }
        string BapDefaultFromEmail { get; set; }
        string BapDefaultContactEmail { get; set; }
        string SmtpUserName { get; set; }
        string SmtpUserPassword { get; set; }
        string SmtpHostName { get; set; }
        int SmtpPort { get; set; }
        bool SmtpUseSsl { get; set; }
        string reCaptchaSiteKey { get; set; }
        string reCaptchaSecretKey { get; set; }
        bool GetBearrerTokenDuringLogin { get; set; }
        string AuthCookieName { get; set; }
        int AuthCookieExpirationTime { get; set; }
        string WebApiPublicClientId { get; set; }
        int BearerTokenExpirationTime { get; set; }
        bool WebApiAllowInsecureHttp { get; set; }
        string PublicFolderText { get; set; }
        string BaseFolderText { get; set; }
        bool CookiesPopupEnabled { get; set; }
        bool GdprPopupEnabled { get; set; }
    }
}