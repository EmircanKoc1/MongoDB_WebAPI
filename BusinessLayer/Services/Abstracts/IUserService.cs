using Core.Dtos.Product;
using Core.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Abstracts
{
    public interface IUserService
    {
        Task AddAsync(UserCreateDto entity);
        Task<UserReadDto> DeleteOneByIdAsync();
        Task<IEnumerable<UserReadDto>> GetAllAsync();
        Task<UserReadDto> GetByIdAsync(string id);
        Task<UserReadDto> UpdateOneByIdAsync();
        Task<UserReadDto> UpdateOneByNameAsync();
        IEnumerable<UserReadDto> GetAll();
    }
}
