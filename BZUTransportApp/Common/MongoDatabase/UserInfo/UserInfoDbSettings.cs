namespace BZUCommon.MongoDatabase.UserInfo
{
    public class UserInfoDbSettings : IUserInfoDbSettings
    {
        public string UserInfoCollectionName { get; set; } = string.Empty;

        public string ConnectionString { get; set; } = string.Empty;

        public string DatabaseName { get; set; } = string.Empty;
    }
}
