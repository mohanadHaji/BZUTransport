namespace BZUTransport.RequestValidations.LoginRequest
{
    using BZUCommon.RequestValidiation;
    using BZUTransport.Models;
    using Microsoft.Extensions.Logging;

    public class LoginRequestValidation : LoginRequestBaseValidation
    {
        public LoginRequestValidation(ILogger logger) : base(logger)
        {
        }

        protected override void ValidateRequestInternal(User user, ILogger logger)
        {
        }
    }
}
