
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace AlexaMenu.Infrastructure.Data.Models
{
    public class DishDocumentModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

        [BsonElement("name")]
        [BsonRequired]
        public string Name { get; set; } = string.Empty;

        [BsonElement("category")]
        [BsonRequired]
        public string Category { get; set; } = string.Empty;

        [BsonElement("note")]
        [BsonRequired]
        public string Note{ get; set; } = string.Empty;
    }
}
