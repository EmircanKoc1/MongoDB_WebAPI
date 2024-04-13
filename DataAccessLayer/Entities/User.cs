using DataAccessLayer.Entities.Base;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DataAccessLayer.Entities
{
    public class User : BaseEntity
    {
        [BsonElement(Order = 2)]
        [BsonRepresentation(BsonType.String)]
        public string Username { get; set; }

        [BsonRepresentation(BsonType.String)]
        [BsonElement(Order = 3)]
        public string Name { get; set; }

        [BsonRepresentation(BsonType.String)]
        [BsonElement(Order = 4)]
        public string Surname { get; set; }

        [BsonElement(Order = 5)]
        public Contact Contact { get; set; }

        [BsonElement(Order = 6)]
        public ICollection<Address> Addresses { get; set; }
    }
}
