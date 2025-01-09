using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace LubricantStorage.Core
{
    /// <summary>
    /// Масло
    /// </summary>
    public class Lubricant : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Характеристика масла
        /// </summary>
        public LubricantСharacteristics Сharacteristics { get; set; }

        /// <summary>
        /// Тип масла по области применения
        /// </summary>
        public LubricantApplicationType ApplicationType { get; set; }
    }
}