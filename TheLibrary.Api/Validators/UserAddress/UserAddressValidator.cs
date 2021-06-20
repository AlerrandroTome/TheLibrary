using FluentValidation;
using TheLibrary.Core.DTOs.UserAddress;

namespace TheLibrary.Api.Validators.UserAddress
{
    public class UserAddressValidator : AbstractValidator<UserAddressDTO>
    {
        public UserAddressValidator()
        {
            RuleFor(w => w.Address).NotEmpty()
                                   .WithMessage("É necessário informar o endereço.")
                                   .NotNull()
                                   .WithMessage("É necessário informar o endereço.");

            RuleFor(w => w.IdentificationCode).NotNull()
                                              .WithMessage("É necessário informar o CEP.")
                                              .NotEmpty()
                                              .WithMessage("É necessário informar o CEP.");

            RuleFor(w => w.Number).NotNull()
                                  .WithMessage("É necessário informar o número.")
                                  .NotEmpty()
                                  .WithMessage("É necessário informar o número.");
        }
    }
}
