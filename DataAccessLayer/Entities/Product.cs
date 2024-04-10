using DataAccessLayer.Entities.Base;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DataAccessLayer.Entities
{
    public class Product : BaseEntity
    {
        [BsonElement(Order = 2)]
        [BsonRepresentation(BsonType.String)]
        public string Name { get; set; }

        [BsonElement(Order = 3)]
        [BsonRepresentation(BsonType.Int32)]
        public int Price { get; set; }

        [BsonElement(Order = 4)]
        [BsonRepresentation(BsonType.Document)]
        public Category Category { get; set; }

    }
}
