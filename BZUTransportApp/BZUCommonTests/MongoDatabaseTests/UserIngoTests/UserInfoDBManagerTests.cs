namespace BZUCommonTests.MongoDatabaseTests.UserIngoTests
{
    using NSubstitute;
    using BZUCommon.MongoDatabase.UserInfo;
    using NUnit.Framework.Internal;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MongoDB.Driver;
    using Microsoft.Extensions.Logging;
    using BZUCommon.Models;

    [TestClass]
    public class UserInfoDBManagerTests
    {
        private IUserInfoDbSettings MockUserInfoDbSettings;
        private IMongoClient MockMongoClient;
        private ILogger<UserInfoDBManager> MockLogger;
        private IMongoCollection<UserInfo> MockUsersCollection;
        private UserInfoDBManager UserInfoDBManager;

        private UserInfo MockUser;

        private const string MockUserId = "testId";
        private const string MockUserName = "testName";
        private const string MockUserEmailAddress = "testEmailAddress";
        private const string MockUserCarName = "testCarName";
        private const string MockUserOtherNotes= "testOtherNotes";
        private const string MockUserPassword = "testPassword";
        private const string MockUserPhoneNumber = "testPhoneNumber";
        private const int MockUserCarCapacity = 4;
        private const bool MockUserIsCarOwner = true;

        [TestInitialize]
        public void TestInitialization()
        {
            this.MockUserInfoDbSettings = Substitute.For<IUserInfoDbSettings>();
            this.MockLogger = Substitute.For<ILogger<UserInfoDBManager>>();
            this.MockMongoClient = Substitute.For<IMongoClient>();
            this.MockUsersCollection = Substitute.For<IMongoCollection<UserInfo>>();
            this.MockMongoClient.GetDatabase(Arg.Any<string>()).GetCollection<UserInfo>(Arg.Any<string>()).Returns(this.MockUsersCollection);

            this.MockUser = new UserInfo
            {
                Name = MockUserName,
                CarCapacity = MockUserCarCapacity,
                CarName = MockUserCarName,
                EmailAddress = MockUserEmailAddress,
                Id = MockUserId,
                IsCarOwner = MockUserIsCarOwner,
                OtherNotes = MockUserOtherNotes,
                Password = MockUserPassword,
                PhoneNumber = MockUserPhoneNumber
            };

            this.UserInfoDBManager = new UserInfoDBManager(this.MockUserInfoDbSettings, this.MockMongoClient, this.MockLogger);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateUserBadInput()
        {
            this.UserInfoDBManager.Create(null);
        }

        [TestMethod]
        public void CreateUserHappyFlow()
        {
            var response = this.UserInfoDBManager.Create(MockUser);
            this.MockUsersCollection.Received(1).InsertOne(MockUser);

            Assert.AreEqual(MockUser, response);
        }

        [TestMethod]
        public void GetUsersHappyFlow()
        {
            var response = this.UserInfoDBManager.GetUsers();

            CollectionAssert.AreEqual(new List<UserInfo> { }, response);
        }

        [TestMethod]
        public void GetUserHappyFlow()
        {
            var response = this.UserInfoDBManager.GetUser(MockUserId);

            Assert.AreEqual(null, response);
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow("    ")]
        [DataRow(null)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetUserBadInput(string badInput)
        {
            this.UserInfoDBManager.GetUser(badInput);
        }

        [TestMethod]
        public void RemoveUserHappyFlow()
        {
            this.UserInfoDBManager.RemoveUser(MockUserId);
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow("    ")]
        [DataRow(null)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoveUserBadInput(string badInput)
        {
            this.UserInfoDBManager.RemoveUser(badInput);
        }

        [TestMethod]
        public void UpdateUserHappyFlow()
        {
            this.UserInfoDBManager.UpdateUser(MockUserId, MockUser);
        }

        [TestMethod]
        public void UpdateUserBadInput()
        {
            Assert.ThrowsException<ArgumentNullException>(() => this.UserInfoDBManager.UpdateUser("", MockUser));
            Assert.ThrowsException<ArgumentNullException>(() => this.UserInfoDBManager.UpdateUser("   ", MockUser));
            Assert.ThrowsException<ArgumentNullException>(() => this.UserInfoDBManager.UpdateUser(null, MockUser));
            Assert.ThrowsException<ArgumentNullException>(() => this.UserInfoDBManager.UpdateUser(MockUserId, null));
        }
    }
}
