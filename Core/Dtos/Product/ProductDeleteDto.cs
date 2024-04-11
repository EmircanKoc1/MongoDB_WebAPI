using Core.Dtos.Base;
using MongoDB.Bson;

namespace Core.Dtos.Product
{
    public class ProductDeleteDto : BaseDto
    {
        public ObjectId Id { get; set; }
    }
}
