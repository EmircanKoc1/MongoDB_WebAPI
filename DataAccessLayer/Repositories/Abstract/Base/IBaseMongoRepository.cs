using DataAccessLayer.Entities.Base;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DataAccessLayer.Repositories.Abstract.Base
{
    public interface IBaseMongoRepository<T> : IBaseRepository<T>
        where T : BaseEntity, new()
    {
        Task<T> GetByIdAsync(ObjectId id);
        Task<long> UpdateManyAsync(FilterDefinition<T> filter, UpdateDefinition<T> update);
    }
}
