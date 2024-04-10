using DataAccessLayer.Context;
using DataAccessLayer.Entities.Base;
using DataAccessLayer.Repositories.Abstract.Base;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories.Concretes.Base
{
    public abstract class BaseMongoRepository<T> : IBaseMongoRepository<T>
        where T : BaseEntity, new()
    {
        private readonly MongoDBContext _context;
        protected IMongoCollection<T> _collection => _context.GetCollection<T>();

        public BaseMongoRepository(MongoDBContext context)
        => _context = context;

        public async Task AddAsync(T entity)
        => await _collection.InsertOneAsync(entity);


        public async Task<T> DeleteAsync(Expression<Func<T, bool>> filter)
        {
            var result = await _collection.FindOneAndDeleteAsync(filter);

            return result;
        }

        public async Task<IEnumerable<T>> DeleteManyAsync(Expression<Func<T, bool>> filter)
        {
            var foundedEntities = await _collection.FindAsync(filter).Result.ToListAsync();

            await _collection.DeleteManyAsync(filter);

            return foundedEntities;

        }

        public async Task<T> DeleteOneAsync(Expression<Func<T, bool>> filter)
        => await _collection.FindOneAndDeleteAsync(filter);

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            //return await _collection.Find(FilterDefinition<T>.Empty).ToListAsync();

            return await _collection.AsQueryable().ToListAsync();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _collection.FindAsync(x => x.ObjectId == ObjectId.Parse(id)).Result.FirstOrDefaultAsync();
        }

        public async Task<T> GetByIdAsync(ObjectId id)
        {
            return await _collection.FindAsync(x => x.ObjectId == id).Result.FirstOrDefaultAsync();
        }


        public async Task<T> UpdateOneAsync(Expression<Func<T, bool>> filter, T entity)
        {
            var result = await _collection.FindOneAndReplaceAsync(
                filter: filter,
                replacement: entity);


            return result;
        }

        public async Task<long> UpdateManyAsync(FilterDefinition<T> filter, UpdateDefinition<T> update)
        {
            var updateResult = await _collection.UpdateManyAsync(filter, update);

            return updateResult.ModifiedCount;
        }
    }
}
