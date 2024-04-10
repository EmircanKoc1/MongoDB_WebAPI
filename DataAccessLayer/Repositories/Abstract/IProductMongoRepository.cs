using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Abstract.Base;

namespace DataAccessLayer.Repositories.Abstract
{
    public interface IProductMongoRepository : IBaseMongoRepository<Product>
    {
    }
}
