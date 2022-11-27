namespace BZUTransport.Utilities
{
    using Microsoft.Extensions.Logging;

    using InternalSchema = BZUCommon.Models; 
    using ApiSchema = BZUTransport.Models;

    public static class SchemaConverter
    {
        public static InternalSchema.UserInfo UserToInternalSchema(ApiSchema.User user) =>
            new InternalSchema.UserInfo
            {
                CarCapacity = user.CarCapacity,
                CarName = user.CarName,
                EmailAddress = user.EmailAddress,
                IsCarOwner = user.IsCarOwner,
                Name = user.Name,
                OtherNotes = user.OtherNotes,
                Password = user.Password,
                PhoneNumber = user.PhoneNumber,
            };

        public static ApiSchema.User UserToApiSchema(InternalSchema.UserInfo user, ILogger logger)
        {
            var userApiSchema = new ApiSchema.User(logger);
            userApiSchema.CarCapacity = user.CarCapacity;
            userApiSchema.CarName = user.CarName;
            userApiSchema.EmailAddress = user.EmailAddress;
            userApiSchema.Password = user.Password;
            userApiSchema.PhoneNumber = user.PhoneNumber;
            userApiSchema.IsCarOwner = user.IsCarOwner;
            userApiSchema.Name = user.Name;
            userApiSchema.OtherNotes = user.OtherNotes;
            userApiSchema.ConfirmPassword = user.Password;
            return userApiSchema;
        }
}
}
