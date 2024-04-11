using DataAccessLayer.Entities.Base;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Abstract.Base
{
    public interface IBaseMongoRepository<T> : IBaseRepository<T>
        where T : BaseEntity, new()
    {
        Task<T> GetByIdAsync(ObjectId id);
        Task<long> UpdateManyAsync(FilterDefinition<T> filter, UpdateDefinition<T> update);
        Task<long> GetDocumentCount();
        Task<long> GetDocumentCount(Expression<Func<T, bool>> filter);

        Task<IEnumerable<T>> GetAllOrdered(FilterDefinition<T> filter,
            SortDefinition<T> sortDefinition);

    }
}
