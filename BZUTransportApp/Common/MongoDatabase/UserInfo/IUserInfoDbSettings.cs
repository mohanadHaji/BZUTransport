namespace Common.MongoDatabase.UserInfo
{
    public interface IUserInfoDbSettings
    {
        string ConnectionString { get; set; }

        string DatabaseName { get; set; }

        string UserInfoCollectionName { get; set; }
    }
}