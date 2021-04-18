using FluentValidation;
using TheLibrary.Infrastructure.DTOs.User;

namespace TheLibrary.Api.Validators.User
{
    public class UserUpdateValidator : AbstractValidator<UserUpdateDTO>
    {
        public UserUpdateValidator()
        {
            RuleFor(w => w.Id).NotEmpty().NotNull();
            RuleFor(w => w.Login).NotEmpty().NotNull().MinimumLength(5);
            RuleFor(w => w.FirstName).NotEmpty().NotNull();
            RuleFor(w => w.LastName).NotEmpty().NotNull();
            RuleFor(w => w.Password).NotEmpty().NotNull().Length(4, 8);
            RuleFor(w => w.Identification).NotEmpty().NotEmpty();
            RuleFor(w => w.BirthDate).NotEmpty().NotEmpty();
        }
    }
}
