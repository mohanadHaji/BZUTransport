namespace BZUTransport.DBManager
{
    using BZUCommon.Exceptions;
    using BZUCommon.MongoDatabase.UserInfo;
    using BZUCommon.RequestValidiation;
    using BZUTransport.Models;
    using BZUTransport.Utilities;
    using Microsoft.Extensions.Logging;

    public class UserManager
    {
        private readonly ILogger<UserManager> logger;
        private readonly IUserInfoDBManager userInfoDBManager;

        public UserManager(ILogger<UserManager> logger, IUserInfoDBManager userInfoDBManager)
        {
            this.logger = logger;
            this.userInfoDBManager = userInfoDBManager;
        }

        public void CreateNewUser(User user)
        {
            Ensure.IsNotNull(user, nameof(user));
            Ensure.StringIsNullOrWhiteSpace(user.Name, nameof(user.Name));
            if (!Ensure.StringRegexValidation(user.EmailAddress, CommonStrings.EmailRegex, logger))
            {
                throw new ArgumentException(nameof(user.EmailAddress));
            }

            if (!Ensure.StringRegexValidation(user.Password, CommonStrings.StrongPasswordRegex, logger))
            {
                throw new ArgumentException(nameof(user.EmailAddress));
            }

            if (!Ensure.StringRegexValidation(user.PhoneNumber, CommonStrings.PhoneRegex, logger))
            {
                throw new ArgumentException(nameof(user.EmailAddress));
            }

            if (this.userInfoDBManager.GetUserByEmail(user.EmailAddress) != null)
            {
                logger.LogWarning("An existing email was found, breaking the proccess");
                throw new UserExistsException();
            }
            var internalSchemaUser = this.userInfoDBManager.Create(SchemaConverter.UserToInternalSchema(user));
            logger.LogInformation($"User was created successfully with id {internalSchemaUser.Id}");
        }

        public void AuthenticateUser(User user)
        {

        }
    }
}
