namespace BZUTransport.ConfigurationExtensions
{
    using Common.MongoDatabase.UserInfo;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Options;
    using MongoDB.Driver;

    public static class MongoDBConfigurationExtensions
    {
        public static void AddMongoDB(this MauiAppBuilder builder)
        {
            IUserInfoDbSettings userInfoDbSettings = new UserInfoDbSettings
            {
                ConnectionString = builder.Configuration.GetValue<string>("UserInfoDbSettings:ConnectionString"),
                DatabaseName = builder.Configuration.GetValue<string>("UserInfoDbSettings:DatabaseName"),
                UserInfoCollectionName = builder.Configuration.GetValue<string>("UserInfoDbSettings:UserInfoCollectionName")
            };

            builder.Services.AddSingleton<IUserInfoDbSettings>(userInfoDbSettings);
#if DEBUG
            // add mocking data base
            builder.Services.AddSingleton<IMongoClient>(new MongoClient());
            builder.Services.AddScoped<IUserInfoDBManager, MockUserInfoDBManager>();
#else
            // add the real client
            builder.Services.AddSingleton<IMongoClient>(new MongoClient(builder.Configuration.GetValue<string>("UserInfoDbSettings:ConnectionString")));
            builder.Services.AddScoped<IUserInfoDBManager, UserInfoDBManager>();
#endif
        }
    }
}
