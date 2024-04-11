using Core.Dtos.Base;
using Core.Dtos.Internal;
using MongoDB.Bson;

namespace Core.Dtos.Product
{
    public class ProductReadDto : BaseDto
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public Category Category { get; set; }
    }
}
