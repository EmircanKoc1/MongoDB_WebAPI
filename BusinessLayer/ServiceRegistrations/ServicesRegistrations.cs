using BusinessLayer.Services.Abstracts;
using BusinessLayer.Services.Concretes;
using BusinessLayer.Validations.FluentValidation.DtoValidators;
using Core.Dtos.Product;
using Core.Dtos.User;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLayer.ServiceRegistrations
{
    public static class ServicesRegistrations
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
            => services
                .AddScoped<IProductService, ProductService>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<IValidator<ProductCreateDto>, ProductCreateDtoValidator>()
                .AddScoped<IValidator<ProductUpdateDto>, ProductUpdateDtoValidator>()
                .AddScoped<IValidator<UserUpdateDto>, UserUpdateDtoValidator>()
                .AddScoped<IValidator<UserCreateDto>, UserCreateDtoValidator>();


    }
}
