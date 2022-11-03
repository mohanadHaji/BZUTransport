namespace BZUTransport.Models
{
    using BZUTransport.RequestValidiation;
    using System.ComponentModel.DataAnnotations;

    public class UserLogin
    {
        [Required]
        [EmailAddress]
        [StringValidation(ErrorMessage = "البريد الاكتروني خاطئ", Regex = CommonStrings.EmailRegex)]
        public string EmailAddress { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
