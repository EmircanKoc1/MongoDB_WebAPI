using Core.Models.SettingModels;
using DataAccessLayer.Entities.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DataAccessLayer.Context
{
    public class MongoDBContext
    {
        private readonly IMongoDatabase _database;

        public MongoDBContext(IOptions<Core.Models.SettingModels.MongoDB> options)
        {
            IMongoClient client = new MongoClient(options.Value.ConnectionString);
            _database = client.GetDatabase(options.Value.DatabaseName);
        }

        public virtual IMongoCollection<T> GetCollection<T>() where T : BaseEntity
            => _database.GetCollection<T>($"{typeof(T).Name.ToLowerInvariant()}s");

        public virtual IMongoDatabase GetDatabase() => _database;



    }

}
