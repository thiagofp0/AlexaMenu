using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AlexaMenu.Infrastructure.Data.Models
{
    public class MenuDocumentModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

        [BsonElement("date")]
        [BsonRequired]
        public string Date { get; set; } = string.Empty;

        [BsonElement("meals")]
        [BsonRequired]
        public List<MealDocumentModel> Meals { get; set; } = new();
    }
}
