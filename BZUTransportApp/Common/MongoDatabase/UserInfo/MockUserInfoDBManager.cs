namespace BZUCommon.MongoDatabase.UserInfo
{
    using System.Linq;
    using Models;

    public class MockUserInfoDBManager : IUserInfoDBManager
    {
        private static List<UserInfo> MockUsersList = new List<UserInfo>
        {
            new UserInfo
            {
                Name = "testName",
                CarCapacity = 4,
                CarName = "testCarName",
                EmailAddress = "testEmailAddress",
                Id = "testId",
                IsCarOwner = true,
                OtherNotes = "testOtherNotes",
                Password = "testPassword",
                PhoneNumber = "testPhoneNumber"
            }
        };

        /// <inheritdoc/>
        public UserInfo Create(UserInfo userInfo)
        {
            MockUsersList.Add(userInfo);
            return userInfo;
        }

        /// <inheritdoc/>
        public UserInfo GetUser(string Id)
        {
            return MockUsersList.Where(user => string.Equals(user.Id, Id))?.FirstOrDefault();
        }

        /// <inheritdoc/>
        public List<UserInfo> GetUsers()
        {
            return MockUsersList.Where(user => true).ToList();
        }

        /// <inheritdoc/>
        public void RemoveUser(string userId)
        {
            MockUsersList.Remove(this.GetUser(userId));
        }

        /// <inheritdoc/>
        public void UpdateUser(string userId, UserInfo newUserInfo)
        {
            for (int i = 0; i < MockUsersList.Count; i++)
            {
                if (string.Equals(MockUsersList[i].Id, userId))
                {
                    MockUsersList[i] = newUserInfo;
                }
            }
        }
    }
}
