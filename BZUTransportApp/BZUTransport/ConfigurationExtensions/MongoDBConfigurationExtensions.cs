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
            builder.Services.Configure<UserInfoDbSettings>(user => builder.Configuration.GetSection(nameof(UserInfoDbSettings)));
            builder.Services.AddSingleton<IUserInfoDbSettings>(sp => sp.GetRequiredService<IOptions<UserInfoDbSettings>>().Value);
#if DEBUG
            // add mocking data base
            builder.Services.AddSingleton<IMongoClient>(new MongoClient(builder.Configuration.GetValue<string>("UserInfoDbSettings:ConnectionString")));
            builder.Services.AddScoped<IUserInfoDBManager, UserInfoDBManager>();
#else
            // add the real client
            builder.Services.AddSingleton<IMongoClient>(new MongoClient(builder.Configuration.GetValue<string>("UserInfoDbSettings:ConnectionString")));
            builder.Services.AddScoped<IUserInfoDBManager, UserInfoDBManager>();
#endif
        }
    }
}
