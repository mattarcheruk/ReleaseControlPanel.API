using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ReleaseControlPanel.API.Models
{
    public class User
    {
        public ObjectId Id { get; set; }

        [BsonElement]
        public string CiBuildApiToken { get; set; }
        [BsonElement]
        public string CiBuildUserName { get; set; }
        [BsonElement]
        public string CiQaApiToken { get; set; }
        [BsonElement]
        public string CiQaUserName { get; set; }
        [BsonElement]
        public string CiStagingApiToken { get; set; }
        [BsonElement]
        public string CiStagingUserName { get; set; }
        [BsonElement]
        public string FullName { get; set; }
        [BsonElement]
        public string JiraPassword { get; set; }
        [BsonElement]
        public string JiraUserName { get; set; }
        [BsonElement]
        public string Password { get; set; }
        [BsonElement]
        public string PasswordSalt { get; set; }
        [BsonElement]
        public string UserName { get; set; }
        [BsonElement]
        public string UserSecret { get; set; }
    }
}