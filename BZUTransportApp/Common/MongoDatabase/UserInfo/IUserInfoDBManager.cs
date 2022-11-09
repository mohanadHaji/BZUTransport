namespace Common.MongoDatabase.UserInfo
{
    using Models;

    public interface IUserInfoDBManager
    {
        /// <summary>
        /// Add new user to the database collection
        /// </summary>
        /// <param name="userInfo">User information</param>
        /// <returns>The added user</returns>
        UserInfo Create(UserInfo userInfo);

        /// <summary>
        /// Gets the 1st user that matches the conidition
        /// </summary>
        /// <param name="Id">user Id</param>
        /// <returns>User information</returns>
        UserInfo GetUser(string Id);

        /// <summary>
        /// Gets a the lists of users
        /// </summary>
        /// <returns>List of all usres</returns>
        List<UserInfo> GetUsers();

        /// <summary>
        /// Remove one user based on user id
        /// </summary>
        /// <param name="userId">User id to be removed</param>
        void RemoveUser(string userId);

        /// <summary>
        /// Update one user based on user id
        /// </summary>
        /// <param name="userId">User id to update</param>
        /// <param name="newUserInfo">New data about the user</param>
        void UpdateUser(string userId, UserInfo newUserInfo);
    }
}