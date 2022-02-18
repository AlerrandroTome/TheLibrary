using FluentValidation;
using TheLibrary.Infrastructure.Validators.UserAddress;
using TheLibrary.Core.DTOs.User;

namespace TheLibrary.Infrastructure.Validators.User
{
    public class UserCreateValidator : AbstractValidator<UserUpdateDTO>
    {
        public UserCreateValidator()
        {
            RuleFor(w => w.Login).NotEmpty()
                                 .NotNull()
                                 .MinimumLength(5);
            
            RuleFor(w => w.FirstName).NotEmpty();

            RuleFor(w => w.LastName).NotEmpty();

            RuleFor(w => w.Password).NotEmpty().Length(4, 8);

            RuleFor(w => w.Identification).NotEmpty();

            RuleFor(w => w.BirthDate).NotEmpty();

            RuleFor(w => w.Addresses.Count).LessThanOrEqualTo(0);

            RuleForEach(w => w.Addresses).SetValidator(new UserAddressValidator());
        }
    }
}
