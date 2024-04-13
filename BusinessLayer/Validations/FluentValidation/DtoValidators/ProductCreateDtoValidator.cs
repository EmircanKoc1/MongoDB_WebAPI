using Core.Dtos.Product;
using DataAccessLayer.Entities;
using FluentValidation;

namespace BusinessLayer.Validations.FluentValidation.DtoValidators
{
    public class ProductCreateDtoValidator : AbstractValidator<ProductCreateDto>
    {
        public ProductCreateDtoValidator()
        {
            RuleFor(x => x.Price)
                .Must(x => x >= 0)
                .WithMessage("Ürün fiyatı en az 0 olabilir");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("ürün adı gereklidir")
                .NotNull()
                .WithMessage("ürün adı gereklidir")
                .MinimumLength(3)
                .WithMessage("ürün adı en az 3 karakter olmalıdır")
                .MaximumLength(100)
                .WithMessage("ürün adı en fazla 100 karakter olmalıdır");

          
        }

    }
}
