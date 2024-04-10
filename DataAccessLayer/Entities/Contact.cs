using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DataAccessLayer.Entities
{
   
    public class Contact
    {
        [BsonRepresentation(BsonType.String)]
        public string PhoneNumber { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string Email { get; set; }
        
    }
}
