using BusinessLayer.Services.Abstracts;
using Core.Dtos.Product;
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
    public class ProductService : IProductService
    {
        IProductMongoRepository _repository;
        IValidator<ProductCreateDto> _createValidator;
        IValidator<ProductUpdateDto> _updateValidator;
        public ProductService(IProductMongoRepository repository, IValidator<ProductCreateDto> createValidator, IValidator<ProductUpdateDto> updateValidator)
        {
            _repository = repository;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task AddAsync(ProductCreateDto dto)
        {
            var validationResult = await _createValidator.ValidateAsync(dto);

            if (!validationResult.IsValid)
            {
                ExceptionHelper.ThrowException(
                    exceptionType: ExceptionTypes.ModelValidationException,
                    message: validationResult.ErrorsToDictionary().Serialize());
            }


            var mongoentity = dto.Adapt<Product>();

            await _repository.AddAsync(mongoentity);
        }

        public async Task<ProductReadDto> DeleteOneByIdAsync(string id)
        {
            var mongoEntity = await _repository.GetByIdAsync(id);

            if (mongoEntity is null)
                ExceptionHelper.ThrowException(ExceptionTypes.EntityNotFoundException);


            var responseEntity = await _repository.DeleteOneAsync(x => x.Id == ObjectId.Parse(id));

            return responseEntity.Adapt<ProductReadDto>();
        }

        public async Task<ProductReadDto> DeleteOneByIdAsync(ProductDeleteDto dto)
        {
            var mongoEntity = await _repository.GetByIdAsync(dto.Id);

            if (mongoEntity is null)
                ExceptionHelper.ThrowException(ExceptionTypes.EntityNotFoundException);


            var responseEntity = await _repository.DeleteOneAsync(x => x.Id == mongoEntity.Id);

            return responseEntity.Adapt<ProductReadDto>();
        }

        public IEnumerable<ProductReadDto> GetAll()
        {
            var result = _repository.GetAll(x => true);

            if (result is null || result.Count() <= 0)
                ExceptionHelper.ThrowException(ExceptionTypes.EntityNotFoundException);

            return result.Adapt<IEnumerable<ProductReadDto>>();
        }

        public async Task<IEnumerable<ProductReadDto>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();

            if (result is null || result.Count() <= 0)
                ExceptionHelper.ThrowException(ExceptionTypes.EntityNotFoundException);

            return result.Adapt<IEnumerable<ProductReadDto>>();
        }

        public async Task<ProductReadDto> GetByIdAsync(string id)
        {
            var result = await _repository.GetByIdAsync(ObjectId.Parse(id));

            if (result is null)
                ExceptionHelper.ThrowException(ExceptionTypes.EntityNotFoundException);

            return result.Adapt<ProductReadDto>();
        }

        public async Task<ProductReadDto> UpdateOneByIdAsync(string id, ProductUpdateDto dto)
        {
            var validationResult = await _updateValidator.ValidateAsync(dto);

            if (!validationResult.IsValid)
            {
                ExceptionHelper.ThrowException(
                    exceptionType: ExceptionTypes.ModelValidationException,
                    message: validationResult.ErrorsToDictionary().Serialize());
            }

            var foundedEntity = await _repository.GetByIdAsync(id);

            if (foundedEntity is null)
                ExceptionHelper.ThrowException(ExceptionTypes.EntityNotFoundException);

            var parsedId = ObjectId.Parse(id);

            var mongoEntity = dto.Adapt<Product>();
            mongoEntity.Id = foundedEntity.Id;

            var oldEntity = await _repository.UpdateOneAsync(x => x.Id == parsedId, mongoEntity);

            return oldEntity.Adapt<ProductReadDto>();
        }


    }
}
