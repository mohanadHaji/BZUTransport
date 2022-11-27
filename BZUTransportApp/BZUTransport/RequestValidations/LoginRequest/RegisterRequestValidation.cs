namespace BZUTransport.RequestValidations.LoginRequest
{
    using BZUCommon.RequestValidiation;
    using BZUTransport.Models;
    using Microsoft.Extensions.Logging;

    public class RegisterRequestValidation : LoginRequestBaseValidation
    {
        public RegisterRequestValidation(ILogger logger) : base(logger)
        {
        }

        protected override void ValidateRequestInternal(User user, ILogger logger)
        {
            Ensure.StringIsNullOrWhiteSpace(user.Name, nameof(user.Name));
            if (!Ensure.StringRegexValidation(user.PhoneNumber, CommonStrings.PhoneRegex, logger))
            {
                throw new ArgumentException(nameof(user.PhoneNumber));
            }

            if (!string.Equals(user.Password, user.ConfirmPassword))
            {
                throw new ArgumentException(nameof(user.ConfirmPassword));
            }
        }
    }
}
