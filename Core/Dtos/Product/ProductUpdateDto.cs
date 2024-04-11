using Core.Dtos.Base;
using Core.Dtos.Internal;
using MongoDB.Bson;

namespace Core.Dtos.Product
{
    public class ProductUpdateDto : BaseDto
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public Category Category { get; set; }
    }

}
