using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Abstract.Base
{
    public interface IBaseRepository<T>
    {
        Task AddAsync(T entity);
        Task<T> DeleteOneAsync(Expression<Func<T, bool>> filter);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(string id);
        Task<T> UpdateOneAsync(Expression<Func<T, bool>> filter, T entity);
        
    }
}
