using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace TransRoute.WebApi.Models
{
    // Models used as parameters to AccountController actions.

    public class AddExternalLoginBindingModel
    {
        [Required]
        [Display(Name = "External access token")]
        public string ExternalAccessToken { get; set; }
    }

    public class ChangePasswordBindingModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class PhoneModel
    {
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Enter your mobile number")]
        public string PhoneNo { get; set; }
    }

    public class RegisterBindingModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class RegisterModel : RegisterBindingModel
    {
        [Required]
        public string BankName { get; set; }
        [Required]
        [Display(Name = "Account Number")]
        public string AccountNo { get; set; }
        [Display(Name = "Bank Verification Number")]
        public string Bvn { get; set; }
        [Display(Name = "Corporate Name")]
        public string CorporateName { get; set; }
        [Display(Name = "Bn/Rc Number")]
        public string BnRcNumber { get; set; }
        [Display(Name = "CAC Certificate")]
        public string Certificate { get; set; }
        public AcctTypeEnum AcctType { get; set; }
        public bool CreateWithExistingEmail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNo { get; set; }
        public DateTime Dob { get; set; }
        public string Gender { get; set; }
       
    }

    public enum AcctTypeEnum
    {
        PersonalAccount = 1,
        LimitedLiabilityAccount,
        SoleProprietorshipAccount
    }

    public class RegisterExternalBindingModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class RemoveLoginBindingModel
    {
        [Required]
        [Display(Name = "Login provider")]
        public string LoginProvider { get; set; }

        [Required]
        [Display(Name = "Provider key")]
        public string ProviderKey { get; set; }
    }

    public class SetPasswordBindingModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
