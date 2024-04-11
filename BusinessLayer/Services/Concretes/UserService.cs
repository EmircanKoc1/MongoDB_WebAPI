using BusinessLayer.Services.Abstracts;
using Core.Dtos.User;
using Core.Enums;
using Core.Helper;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Abstract;
using Mapster;
using MongoDB.Bson;

namespace BusinessLayer.Services.Concretes
{
    public class UserService : IUserService
    {
        IUserMongoRepository _repository;

        public UserService(IUserMongoRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(UserCreateDto dto)
        {
            var mongoEntity = dto.Adapt<User>();

            await _repository.AddAsync(mongoEntity);
        }

        public async Task<UserReadDto> DeleteOneByIdAsync(string id)
        {

            var foundedEntity = await _repository.GetByIdAsync(ObjectId.Parse(id));

            if (foundedEntity is null)
                ExceptionHelper.ThrowException(ExceptionTypes.EntityNotFoundException);

            await _repository.DeleteOneAsync(x => x.ObjectId == foundedEntity.ObjectId);

            return foundedEntity.Adapt<UserReadDto>();

        }

        public IEnumerable<UserReadDto> GetAll()
        {
            var result = _repository.GetAll(x => true);

            if (result is null || result.Count() <= 0)
                ExceptionHelper.ThrowException(ExceptionTypes.EntityNotFoundException);

            return result.Adapt<IEnumerable<UserReadDto>>();
        }

        public async Task<IEnumerable<UserReadDto>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();

            if (result is null || result.Count() <= 0)
                ExceptionHelper.ThrowException(ExceptionTypes.EntityNotFoundException);

            return result.Adapt<IEnumerable<UserReadDto>>();
        }

        public async Task<UserReadDto> GetByIdAsync(string id)
        {
            var result = await _repository.GetByIdAsync(id);

            return result.Adapt<UserReadDto>();
        }

        public async Task<UserReadDto> UpdateOneByIdAsync(string id, UserUpdateDto dto)
        {
            var mongoEntity = dto.Adapt<User>();
            
            mongoEntity.ObjectId = ObjectId.Parse(id);

            var result = await _repository.UpdateOneAsync(x => x.ObjectId == mongoEntity.ObjectId, mongoEntity);

            return result.Adapt<UserReadDto>();
        }
    }
}
