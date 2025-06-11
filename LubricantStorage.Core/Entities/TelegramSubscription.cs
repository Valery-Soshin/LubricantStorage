using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace LubricantStorage.Core.Entities
{
    public class TelegramSubscription : IEntity<string>
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public required string UserId { get; set; }

        public required long ChatId { get; set; }
    }
}