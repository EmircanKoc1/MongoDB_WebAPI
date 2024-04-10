using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DataAccessLayer.Entities
{
    public class Contact
    {
        public string PhoneNumber { get; set; }
        

        public string Email { get; set; }
        

    }
}
