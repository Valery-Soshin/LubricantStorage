using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace LubricantStorage.Core.Notifications
{
    public class TelegramToken : IEntity<string>
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string UserId { get; set; }

        public string Value { get; set; }

        public DateTimeOffset ExpiresAt { get; set; }
    }
}