using FluentValidation;
using TheLibrary.Infrastructure.DTOs.UserAddress;

namespace TheLibrary.Api.Validators.UserAddress
{
    public class UserAddressValidator : AbstractValidator<UserAddressDTO>
    {
        public UserAddressValidator()
        {
            RuleFor(w => w.Address).NotNull().NotEmpty();
            RuleFor(w => w.IdentificationCode).NotNull().NotEmpty();
            RuleFor(w => w.Number).NotNull().NotEmpty();
        }
    }
}
