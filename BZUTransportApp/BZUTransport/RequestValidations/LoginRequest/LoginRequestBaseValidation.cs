namespace BZUTransport.RequestValidations.LoginRequest
{
    using BZUCommon.RequestValidiation;
    using BZUTransport.Models;
    using Microsoft.Extensions.Logging;

    public abstract class LoginRequestBaseValidation
    {
        private readonly ILogger logger;

        protected LoginRequestBaseValidation(ILogger logger)
        {
            this.logger = logger;
        }

        public virtual void ValidateRequest(User user, Action action)
        {

            try
            {
                Ensure.StringIsNullOrWhiteSpace(user.EmailAddress, nameof(user.EmailAddress));
                Ensure.StringIsNullOrWhiteSpace(user.Password, nameof(user.Password));
                if (!Ensure.StringRegexValidation(user.EmailAddress, CommonStrings.EmailRegex, logger))
                {
                    throw new ArgumentException(nameof(user.EmailAddress));
                }

                if (!Ensure.StringRegexValidation(user.Password, CommonStrings.StrongPasswordRegex, logger))
                {
                    throw new ArgumentException(nameof(user.Password));
                }

                this.ValidateRequestInternal(user, logger);
            }
            catch (Exception e)
            {
                logger.LogError($"error while validating the login request with Message:\n{e.Message}");
                return;
            }

            try
            {
                action.Invoke();
            }
            catch (Exception e)
            {

                logger.LogError($"failed to proccess the request, Message:\n{e.Message}");
            }
        }

        protected abstract void ValidateRequestInternal(User user, ILogger logger);
    }
}
