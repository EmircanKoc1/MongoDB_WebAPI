using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Abstract;
using DataAccessLayer.Repositories.Concretes.Base;
using Microsoft.Extensions.Options;

namespace DataAccessLayer.Repositories.Concretes
{
    public class ProductMongoRepository : BaseMongoRepository<Product>, IProductMongoRepository
    {
        public ProductMongoRepository(IOptions<Core.Models.SettingModels.MongoDB> options) : base(options)
        {
        }
    }
}
