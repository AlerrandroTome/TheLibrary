using FluentValidation;
using TheLibrary.Core.DTOs.UserAddress;

namespace TheLibrary.Infrastructure.Validators.UserAddress
{
    public class UserAddressValidator : AbstractValidator<UserAddressDTO>
    {
        public UserAddressValidator()
        {
            RuleFor(w => w.Address).NotEmpty();

            RuleFor(w => w.IdentificationCode).NotEmpty();

            RuleFor(w => w.Number).NotEmpty();
        }
    }
}
