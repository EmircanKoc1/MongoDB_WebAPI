using DataAccessLayer.Entities.Base;
using MongoDB.Bson.Serialization.Attributes;

namespace DataAccessLayer.Entities
{
    public class Product : BaseEntity
    {
        [BsonElement("Name", Order = 2)]
        public string Name { get; set; }

        [BsonElement("Price", Order = 3)]
        public int Price { get; set; }

        [BsonElement("Category", Order = 4)]
        public Category Category { get; set; }

    }
}
