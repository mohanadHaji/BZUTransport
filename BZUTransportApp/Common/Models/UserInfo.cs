namespace BZUCommon.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    [BsonIgnoreExtraElements]
    public class UserInfo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;

        [BsonElement("emailAddress")]
        public string EmailAddress { get; set; } = string.Empty;

        [BsonElement("password")]
        public string Password { get; set; } = string.Empty;

        [BsonElement("phoneNumber")]
        public string PhoneNumber { get; set; } = string.Empty;

        [BsonElement("haveACar")]
        public bool IsCarOwner { get; set; }

        [BsonElement("carCapacity")]
        public int CarCapacity { get; set; }

        [BsonElement("carName")]
        public string CarName { get; set; } = string.Empty;

        [BsonElement("otherNotes")]
        public string OtherNotes { get; set; } = string.Empty;
    }
}
