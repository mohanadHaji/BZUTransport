using BZUTransport.RequestValidiation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BZUTransport.Models
{
    public class UserRegister
    {
        [Required]
        [StringValidation(ErrorMessage = "الاسم لا يجب ان يكون فارغا", Regex = "" )]
        public string Name { get; set; }

        [Required]
        [StringValidation(ErrorMessage = "البريد الاكتروني خاطئ", Regex = CommonStrings.EmailRegex)]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        [StringValidation(ErrorMessage = CommonStrings.BadPassWordMessage, Regex = CommonStrings.StrongPasswordRegex)]
        public string Password { get; set; }

        [Required]
        [StringValidation(ErrorMessage = CommonStrings.BadPassWordMessage, Regex = CommonStrings.StrongPasswordRegex)]
        public string ConfirmPassword{ get; set; }

        [Required]
        [StringValidation(ErrorMessage = "رقم خاطئ", Regex = CommonStrings.PhoneRegex)]
        [Phone]
        public string PhoneNumber { get; set; }

        public bool IsCarOwner{ get; set; }

        public int CarCapacity { get; set; }

        public string CarName { get; set; }

        public string OtherNotes { get; set; }
    }
}
