using DataAccessLayer.Context;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Abstract;
using DataAccessLayer.Repositories.Concretes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Concretes
{
    public class ProductMongoRepository : BaseMongoRepository<Product>, IProductMongoRepository
    {
        public ProductMongoRepository(MongoDBContext context) : base(context)
        {
        }
    }
}
