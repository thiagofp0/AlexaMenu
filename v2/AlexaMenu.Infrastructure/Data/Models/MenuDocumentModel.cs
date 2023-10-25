using System;
using AlexaMenu.Domain.Entities;
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
        public DateTime Date { get; set; }

        [BsonElement("meals")]
        [BsonRequired]
        public List<Meal> Meals { get; set; } = new();
    }
}
