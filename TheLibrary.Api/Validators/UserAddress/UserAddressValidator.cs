using FluentValidation;
using TheLibrary.Core.DTOs.UserAddress;

namespace TheLibrary.Api.Validators.UserAddress
{
    public class UserAddressValidator : AbstractValidator<UserAddressDTO>
    {
        public UserAddressValidator()
        {
            RuleFor(w => w.Address).NotEmpty()
                                   .WithMessage("O Endereço não pode ser vazio.")
                                   .NotNull()
                                   .WithMessage("O endereço não pode ser nulo.");

            RuleFor(w => w.IdentificationCode).NotNull()
                                              .WithMessage("O CEP não pode ser nulo.")
                                              .NotEmpty()
                                              .WithMessage("O CEP não pode ser vazio.");

            RuleFor(w => w.Number).NotNull()
                                  .WithMessage("O número não pode ser nulo.")
                                  .NotEmpty()
                                  .WithMessage("O número não pode ser vazio.");
        }
    }
}
