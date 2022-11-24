using System.Text.RegularExpressions;

namespace BZUTransport.Models.ErrorModels
{
    public class UserRegisterError
    {
        public string Name { get; set; } = string.Empty;

        public string EmailAddress { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string ConfirmPassword { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;
    }
}
