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
        Task AddAsync(UserCreateDto dto);
        Task<UserReadDto> DeleteOneByIdAsync(string id);
        Task<UserReadDto> DeleteOneByIdAsync(UserDeleteDto dto);
        Task<IEnumerable<UserReadDto>> GetAllAsync();
        Task<UserReadDto> GetByIdAsync(string id);
        Task<UserReadDto> UpdateOneByIdAsync(string id, UserUpdateDto dto);
        IEnumerable<UserReadDto> GetAll();

    }
}
