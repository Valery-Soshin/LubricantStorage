using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace LubricantStorage.Core.Notifications
{
    public class NotificationToken : IEntity<string>
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public required string UserId { get; init; }

        public required string Value { get; init; }

        public required DateTimeOffset ExpiresAt { get; init; }

        public required NotificationType NotificationType { get; set; }
    }
}