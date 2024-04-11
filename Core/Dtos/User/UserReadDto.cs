using Core.Dtos.Base;
using Core.Dtos.Internal;
using MongoDB.Bson;

namespace Core.Dtos.User
{
    public class UserReadDto : BaseDto
    {
        public ObjectId Id { get; set; }
        public string  Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public Contact Contact{ get; set; }
        ICollection<Address> Addresses { get; set; }
    }

  

}
