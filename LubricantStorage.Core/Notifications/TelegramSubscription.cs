using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace LubricantStorage.Core.Notifications
{
    public class TelegramSubscription : IEntity<string>
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string UserId { get; set; }

        public long ChatId { get; set; }
    }
}