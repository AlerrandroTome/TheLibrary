using FluentValidation;
using TheLibrary.Api.Validators.UserAddress;
using TheLibrary.Core.DTOs.User;

namespace TheLibrary.Api.Validators.User
{
    public class UserUpdateValidator : AbstractValidator<UserUpdateDTO>
    {
        public UserUpdateValidator()
        {
            RuleFor(w => w.Login).NotEmpty()
                                 .NotNull()
                                 .MinimumLength(5);

            RuleFor(w => w.FirstName).NotEmpty()
                                     .WithMessage("É necessário informar o nome.")
                                     .NotNull()
                                     .WithMessage("É necessário informar o nome.");

            RuleFor(w => w.LastName).NotEmpty()
                                    .WithMessage("É necessário informar o sobrenome.")
                                    .NotNull()
                                    .WithMessage("É necessário informar o sobrenome.");

            RuleFor(w => w.Password).NotEmpty()
                                    .WithMessage("É necessário informar a senha.")
                                    .NotNull()
                                    .WithMessage("É necessário informar a senha.")
                                    .Length(4, 8)
                                    .WithMessage("A senha tem que ter entre {MinLength} e {MaxLength} caracteres. Você digitou {TotalLength}.");

            RuleFor(w => w.Identification).NotEmpty()
                                          .WithMessage("É necessário informar o CPF.")
                                          .NotNull()
                                          .WithMessage("É necessário informar o CPF.");

            RuleFor(w => w.BirthDate).NotEmpty()
                                     .WithMessage("É necessário informar a data de nascimento.")
                                     .NotNull()
                                     .WithMessage("É necessário informar a data de nascimento.");

            RuleFor(w => w.Addresses.Count).LessThanOrEqualTo(0)
                                           .WithMessage("É necessário cadastrar pelo menos um endereço.");

            RuleForEach(w => w.Addresses).SetValidator(new UserAddressValidator());
        }
    }
}
