using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace AlexaMenu.Infrastructure.Data.Models
{
    public class MealDocumentModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

        [BsonElement("name")]
        [BsonRequired]
        public string Name { get; set; } = string.Empty;

        [BsonElement("restaurant")]
        [BsonRequired]
        public string Restaurant { get; set; } = string.Empty;

        [BsonElement("startTime")]
        [BsonRequired]
        public DateTime StartTime { get; set; }

        [BsonElement("endTime")]
        [BsonRequired]
        public DateTime EndTime { get; set; }

        [BsonElement("dishes")]
        [BsonRequired]
        public List<DishDocumentModel> Dishes { get; set; } = new();
    }
}
