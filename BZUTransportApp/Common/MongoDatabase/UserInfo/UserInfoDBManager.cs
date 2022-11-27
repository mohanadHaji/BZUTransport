namespace BZUCommon.MongoDatabase.UserInfo
{
    using BZUCommon.RequestValidiation;
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
            Ensure.IsNotNull(userInfo, nameof(userInfo));
            this.UsersCollection.InsertOne(userInfo);
            this.logger.LogInformation($"user {userInfo.Id} was added successfully");
            return userInfo;
        }

        /// <inheritdoc/>
        public List<UserInfo> GetUsers()
        {
            var users = this.UsersCollection.Find(user => true)?.ToList();
            this.logger.LogInformation($"Users where retrived successfully with count {users?.Count} users");
            return users;
        }

        /// <inheritdoc/>
        public UserInfo GetUser(string userId)
        {
            Ensure.StringIsNullOrWhiteSpace(userId, nameof(userId));
            var users = this.UsersCollection.Find(user => string.Equals(user.Id, userId))?.FirstOrDefault();
            this.logger.LogInformation($"Users {users?.Id} where retrived successfully");
            return users;
        }

        /// <inheritdoc/>
        public UserInfo GetUserByEmail(string email)
        {
            Ensure.StringIsNullOrWhiteSpace(email, nameof(email));
            var users = this.UsersCollection.Find(user => string.Equals(user.EmailAddress, email))?.FirstOrDefault();
            this.logger.LogInformation($"Users {users?.Id} where retrived successfully");
            return users;
        }

        /// <inheritdoc/>
        public void RemoveUser(string userId)
        {
            Ensure.StringIsNullOrWhiteSpace(userId, nameof(userId));
            var deleteResults = this.UsersCollection.DeleteOne(user => string.Equals(user.Id, userId));
            if (deleteResults.DeletedCount == 0)
            {
                this.logger.LogInformation($"Users {userId} was not found");
            }
            else
            {
                this.logger.LogInformation($"Users {userId} where deleted successfully");
            }
        }

        /// <inheritdoc/>
        public void UpdateUser(string userId, UserInfo newUserInfo)
        {
            Ensure.IsNotNull(newUserInfo, nameof(newUserInfo));
            Ensure.StringIsNullOrWhiteSpace(userId, nameof(userId));
            var replaceResults = this.UsersCollection.ReplaceOne(user => string.Equals(user.Id, userId), newUserInfo);
            if (replaceResults.ModifiedCount == 0)
            {
                this.logger.LogInformation($"Users {userId} was not found");
            }
            else
            {
                this.logger.LogInformation($"Users {userId} where updated successfully");
            }
        }
    }
}
