using Core.Dtos.User;
using DataAccessLayer.Entities;
using FluentValidation;
using System.Drawing;

namespace BusinessLayer.Validations.FluentValidation.DtoValidators
{
    public class UserCreateDtoValidator : AbstractValidator<UserCreateDto>
    {
        public UserCreateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("isim alanı gereklidir")
                .NotNull()
                .WithMessage("isim alanı gereklidir")
                .Length(2, 30)
                .WithMessage("İsim en az 2 en fazla 30 karakter olmalı");

            RuleFor(x => x.Surname)
                .NotEmpty()
                .WithMessage("soyad alanı gereklidir")
                .NotNull()
                .WithMessage("soyad alanı gereklidir")
                .Length(2, 30)
                .WithMessage("Soyad en az 2 en fazla 30 karakter olmalıdır");

            RuleFor(x => x.Contact.Email)
                .NotEmpty()
                .WithMessage("email alanı gereklidir")
                .NotNull()
                .WithMessage("email alanı gereklidir")
                .EmailAddress()
                .WithMessage("Email adres geçerli değil");

            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage("kullanıcı adı boş olamaz")
                .NotNull()
                .WithMessage("kullanıcı adı boş olamaz")
                .Length(5, 30)
                .WithMessage("kullanıcı adı en az 5 karakter en fazla 30 karakter olabilir");

        }
    }

}
