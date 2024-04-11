using Core.Dtos.Base;
using MongoDB.Bson;
namespace Core.Dtos.User
{
    public class UserDeleteDto : BaseDto
    {
        public ObjectId Id { get; set; }
    }
}
