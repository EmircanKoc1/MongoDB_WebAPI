using DataAccessLayer.Context;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Abstract;
using DataAccessLayer.Repositories.Concretes.Base;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Concretes
{
    public class UserMongoRepository : BaseMongoRepository<User>, IUserMongoRepository
    {
        public UserMongoRepository(IOptions<Core.Models.SettingModels.MongoDB> options) : base(options)
        {
        }

    }
}
