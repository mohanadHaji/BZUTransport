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
        /// <param name="findByCondition">The condition ofr getting the user</param>
        /// <returns>User information</returns>
        UserInfo GetUser(Func<UserInfo, bool> findByCondition);

        /// <summary>
        /// Gets a list of students based on conidition
        /// </summary>
        /// <param name="findByCondition">Conidition to match with</param>
        /// <returns>List of matching User info</returns>
        List<UserInfo> GetUsers(Func<UserInfo, bool> findByCondition);

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