using FluentValidation;
using TheLibrary.Api.Validators.UserAddress;
using TheLibrary.Core.DTOs.User;

namespace TheLibrary.Api.Validators.User
{
    public class UserUpdateValidator : AbstractValidator<UserUpdateDTO>
    {
        public UserUpdateValidator()
        {
            RuleFor(w => w.Id).NotEmpty()
                              .NotNull();

            RuleFor(w => w.Login).NotEmpty()
                                 .NotNull()
                                 .MinimumLength(5);

            RuleFor(w => w.FirstName).NotEmpty()
                                     .WithMessage("O nome não pode ser vazio.")
                                     .NotNull()
                                     .WithMessage("O nome não pode ser nulo.");

            RuleFor(w => w.LastName).NotEmpty()
                                    .WithMessage("O sobrenome não pode ser vazio.")
                                    .NotNull()
                                    .WithMessage("o sobrenome não pode ser nulo.");

            RuleFor(w => w.Password).NotEmpty()
                                    .WithMessage("A senha não pode ser vazia.")
                                    .NotNull()
                                    .WithMessage("A senha não pode ser nula.")
                                    .Length(4, 8)
                                    .WithMessage("A senha tem que ter entre {MinLength} e {MaxLength}. Você digitou {TotalLength}.");

            RuleFor(w => w.Identification).NotEmpty()
                                          .WithMessage("O CPF não pode ser vazio.")
                                          .NotNull()
                                          .WithMessage("O CPF não pode ser nulo.");

            RuleFor(w => w.BirthDate).NotEmpty()
                                     .WithMessage("A data de nascimento não pode ser vazia.")
                                     .NotNull()
                                     .WithMessage("A data de nascimento não pode ser nulo.");

            RuleFor(w => w.Addresses.Count).LessThanOrEqualTo(0)
                                           .WithMessage("É necessário cadastrar pelo menos um endereço.");

            RuleForEach(w => w.Addresses).SetValidator(new UserAddressValidator());
        }
    }
}
