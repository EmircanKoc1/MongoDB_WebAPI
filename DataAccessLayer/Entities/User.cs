using DataAccessLayer.Entities.Base;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DataAccessLayer.Entities
{
    public class User : BaseEntity
    {
        [BsonElement(Order = 2)]
        public string UserName { get; set; }

        [BsonElement(Order = 3)]
        public string Name { get; set; }

        [BsonElement(Order = 4)]
        public string Surname { get; set; }

        [BsonElement(Order = 5)]
        [BsonRepresentation(BsonType.Document)]
        public Contact Contact { get; set; }

        [BsonElement(Order = 6)]
        [BsonRepresentation(BsonType.Document)]
        public ICollection<Address> Addresses { get; set; }
    }
}
