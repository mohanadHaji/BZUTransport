namespace Common.MongoDatabase.UserInfo
{
    using Microsoft.Extensions.Logging;
    using Models;
    using MongoDB.Driver;

    public class UserInfoDBManager : IUserInfoDBManager
    {
        private readonly IMongoCollection<UserInfo> UsersCollection;
        private readonly ILogger<UserInfoDBManager> logger;

        /// <inheritdoc/>
        public UserInfoDBManager(IUserInfoDbSettings userInfoDbSettings, IMongoClient mongoClient, ILogger<UserInfoDBManager> logger)
        {
            this.UsersCollection = mongoClient.GetDatabase(userInfoDbSettings.DatabaseName)
                .GetCollection<UserInfo>(userInfoDbSettings.UserInfoCollectionName);
            this.logger = logger;
        }

        /// <inheritdoc/>
        public UserInfo Create(UserInfo userInfo)
        {
            this.UsersCollection.InsertOne(userInfo);
            this.logger.LogInformation($"user {userInfo.Id} was added successfully");
            return userInfo;
        }

        /// <inheritdoc/>
        public List<UserInfo> GetUsers(Func<UserInfo, bool> findByCondition)
        {
            var users = this.UsersCollection.Find(user => findByCondition(user)).ToList();
            this.logger.LogInformation($"Users where retrived successfully with count {users.Count} users");
            return users;
        }

        /// <inheritdoc/>
        public UserInfo GetUser(Func<UserInfo, bool> findByCondition)
        {
            var users = this.UsersCollection.Find(user => findByCondition(user)).FirstOrDefault();
            this.logger.LogInformation($"Users {users.Id} where retrived successfully");
            return users;
        }

        /// <inheritdoc/>
        public void RemoveUser(string userId)
        {
            this.UsersCollection.DeleteOne(user => string.Equals(user.Id, userId));
            this.logger.LogInformation($"Users {userId} where deleted successfully");
        }

        /// <inheritdoc/>
        public void UpdateUser(string userId, UserInfo newUserInfo)
        {
            this.UsersCollection.ReplaceOne(user => string.Equals(user.Id, userId), newUserInfo);
            this.logger.LogInformation($"Users {userId} where updated successfully");
        }
    }
}
