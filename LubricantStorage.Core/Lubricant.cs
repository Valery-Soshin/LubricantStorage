using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace LubricantStorage.Core
{
    /// <summary>
    /// Масло
    /// </summary>
    public class Lubricant : IEntity<string>
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        [Display(Name = "Наименование")]
        public string Name { get; set; }

        /// <summary>
        /// Характеристика масла
        /// </summary>
        [Display(Name = "Характеристика масла")]
        public LubricantСharacteristics Characteristics { get; set; }

        /// <summary>
        /// Тип масла по области применения
        /// </summary>
        [Display(Name = "Тип масла по области применения")]
        public LubricantApplicationType ApplicationType { get; set; }
    }
}