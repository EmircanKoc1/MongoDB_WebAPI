﻿using BusinessLayer.Services.Abstracts;
using Core.Dtos.User;
using Core.Enums;
using Core.Extensions;
using Core.Helper;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Abstract;
using FluentValidation;
using Mapster;
using MongoDB.Bson;

namespace BusinessLayer.Services.Concretes
{
    public class UserService : IUserService
    {
        IUserMongoRepository _repository;
        IValidator<UserCreateDto> _createValidator;
        IValidator<UserUpdateDto> _updateValidator;
        public UserService(IUserMongoRepository repository, IValidator<UserCreateDto> createValidator, IValidator<UserUpdateDto> updateValidator)
        {
            _repository = repository;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task AddAsync(UserCreateDto dto)
        {
            var validationResult = _createValidator.Validate(dto);

            if (!validationResult.IsValid)
            {

                ExceptionHelper.ThrowException(
                    exceptionType: ExceptionTypes.ModelValidationException,
                    message: validationResult.ErrorsToDictionary().Serialize());
            }


            var mongoEntity = dto.Adapt<User>();

            await _repository.AddAsync(mongoEntity);
        }

        public async Task<UserReadDto> DeleteOneByIdAsync(string id)
        {

            var foundedEntity = await _repository.GetByIdAsync(ObjectId.Parse(id));

            if (foundedEntity is null)
                ExceptionHelper.ThrowException(ExceptionTypes.EntityNotFoundException);

            await _repository.DeleteOneAsync(x => x.Id == foundedEntity.Id);

            return foundedEntity.Adapt<UserReadDto>();

        }

        public async Task<UserReadDto> DeleteOneByIdAsync(UserDeleteDto dto)
        {

            var foundedEntity = await _repository.GetByIdAsync(dto.Id);

            if (foundedEntity is null)
                ExceptionHelper.ThrowException(ExceptionTypes.EntityNotFoundException);

            await _repository.DeleteOneAsync(x => x.Id == foundedEntity.Id);

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
            var validationResult = await _updateValidator.ValidateAsync(dto);

            if (!validationResult.IsValid)
            {
                ExceptionHelper.ThrowException(
                    exceptionType: ExceptionTypes.ModelValidationException,
                    message: validationResult.ErrorsToDictionary().Serialize());
            }


            var mongoEntity = dto.Adapt<User>();

            mongoEntity.Id = ObjectId.Parse(id);

            var result = await _repository.UpdateOneAsync(x => x.Id == mongoEntity.Id, mongoEntity);

            return result.Adapt<UserReadDto>();
        }
    }
}
