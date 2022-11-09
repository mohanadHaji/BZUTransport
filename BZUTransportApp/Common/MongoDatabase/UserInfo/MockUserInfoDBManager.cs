namespace Common.MongoDatabase.UserInfo
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
        public UserInfo Create(UserInfo userInfo)
        {
            MockUsersList.Add(userInfo);
            return userInfo;
        }

        public UserInfo GetUser(string Id)
        {
            return MockUsersList.Where(user => string.Equals(user.Id, Id))?.FirstOrDefault();
        }

        public List<UserInfo> GetUsers()
        {
            return MockUsersList.Where(user => true).ToList();
        }

        public void RemoveUser(string userId)
        {
            MockUsersList.Remove(this.GetUser(userId));
        }

        public void UpdateUser(string userId, UserInfo newUserInfo)
        {
            var user = MockUsersList.FirstOrDefault(user => string.Equals(user.Id, userId));
            if (user != null)
            {
                user = newUserInfo;
            }
        }
    }
}
