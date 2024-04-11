using Core.Dtos.Base;
using Core.Dtos.Internal;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.User
{
    public class UserUpdateDto : BaseDto
    {
        public ObjectId ObjectId { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public Contact Contact { get; set; }
        ICollection<Address> Addresses { get; set; }
    }
}
