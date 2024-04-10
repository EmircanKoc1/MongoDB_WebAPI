using DataAccessLayer.Entities.Base;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace DataAccessLayer.Context
{
    public class MongoDBContext
    {
        IMongoDatabase _database;

        public MongoDBContext(IConfiguration configuration)
        {
            IMongoClient client = new MongoClient(configuration.GetConnectionString("MongoDB"));
            _database = client.GetDatabase(configuration.GetConnectionString("DatabaseName"));
        }

        public virtual IMongoCollection<T> GetCollection<T>() where T : BaseEntity
            => _database.GetCollection<T>($"{typeof(T).Name.ToLowerInvariant()}s");

        public virtual IMongoDatabase GetDatabase() => _database;



    }

}
