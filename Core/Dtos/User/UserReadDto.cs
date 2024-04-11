using Core.Dtos.Base;
using MongoDB.Bson;

namespace Core.Dtos.User
{
    public class UserReadDto : BaseDto
    {
        public ObjectId ObjectId { get; set; }
        public string  Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public Contact Contact{ get; set; }
        ICollection<Address> Addresses { get; set; }
    }

    public class Contact
    {
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
    public class Address
    {
        public string Title { get; set; }
        public string City { get; set; }
        public string Town { get; set; }
    }

}
