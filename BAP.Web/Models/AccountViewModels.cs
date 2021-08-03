using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BAP.Web.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Login_Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Code_SelectedProvider")]
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Login_Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Login_RememberBrowser")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Login_Email")]
        [EmailAddress]
        public string Email { get; set; }
        public string Area { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Login_Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Login_Password")]
        public string Password { get; set; }

        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Login_RememberMe")]
        public bool RememberMe { get; set; }

        public string Area { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Login_Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "ErrorText_PasswordLength", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Login_Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Login_ConfirmPassword")]
        [Compare("Password", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "ErrorText_NewPasswordConfirmation")]
        public string ConfirmPassword { get; set; }

        [StringLength(20)]        
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Login_RegistrationType")]
        public string RegistrationType { get; set; }
        
        [StringLength(80)]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Login_AddressLine1")]
        public string AddressLine1 { get; set; }

        [StringLength(80)]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Login_AddressLine2")]
        public string AddressLine2 { get; set; }

        [StringLength(80)]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Login_City")]
        public string City { get; set; }

        [StringLength(80)]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Login_County")]
        public string County { get; set; }

		[StringLength(80)]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Login_State")]
        public string State { get; set; }

        [StringLength(80)]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Login_Country")]
        public string Country { get; set; }

        [StringLength(5)]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Login_Zip")]
        public string Zip { get; set; }

        [Required]
        [StringLength(50)]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Login_FirstName")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Login_LastName")]
        public string LastName { get; set; }

        [StringLength(50)]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Login_MiddleName")]
        public string MidleName { get; set; }
       
        [StringLength(12)]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Login_WorkPhone")]
        [Phone]
        public string WorkPhone { get; set; }

        [StringLength(6)]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Login_WorkPhoneEx")]
        public string WorkPhoneExt { get; set; }

        [StringLength(12)]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Login_MobilePhone")]
        [Phone]
        public string MobilePhone { get; set; }

        [StringLength(12)]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Login_HomePhone")]
        [Phone]
        public string HomePhone { get; set; }

        [StringLength(12)]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Login_FaxNumber")]
        public string FaxNumber { get; set; }

        [StringLength(50)]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Login_CompanyNumber")]
        public string CompanyNumber { get; set; }

        [StringLength(80)]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Login_CompanyName")]
        public string CompanyName { get; set; }

        [StringLength(255)]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Login_CompanyDescription")]
        public string CompanyDescription { get; set; }

        [StringLength(20)]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Login_TaxNumber")]
        public string TaxNumber { get; set; }

        [StringLength(20)]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Login_LicenceNumber")]
        public string LicenseNumber { get; set; }

        [StringLength(20)]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Login_InsuranceNumber")]
        public string InsuranceNumber { get; set; }

        [StringLength(255)]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Login_Url")]
        public string Url { get; set; }

        [StringLength(20)]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Login_SubscriptionType")]
        public string SubscriptionType { get; set; }

        [StringLength(50)]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Login_SubscriptionTerm")]
        public string SubscriptionTerm { get; set; }
        public string Area { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Login_Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "ErrorText_PasswordLength", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Login_Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Login_ConfirmPassword")]
        [Compare("Password", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "ErrorText_NewPasswordConfirmation")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(ResourceType = typeof(Resources.Resources), Name = "FieldLabel_Login_Email")]
        public string Email { get; set; }
        public string Area { get; set; }
    }
}
