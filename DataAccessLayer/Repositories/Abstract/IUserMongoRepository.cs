using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Abstract.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Abstract
{
    public interface IUserMongoRepository : IBaseMongoRepository<User>
    {
    }
}
