using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace LubricantStorage.Core.Notifications
{
    public class NotificationSubscription : IEntity<string>
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string UserId { get; set; }

        public long ExternalSystemKey { get; set; }

        public NotificationType NotificationType { get; set; }

        public bool IsConfirmed { get; set; }
    }
}