using FluentValidation;
using TheLibrary.Infrastructure.DTOs.Login;

namespace TheLibrary.Api.Validators.Login
{
    public class LoginValidator : AbstractValidator<LoginDTO>
    {
        public LoginValidator()
        {
            RuleFor(w => w.Login).NotEmpty()
                                 .NotNull()
                                 .MinimumLength(5);

            RuleFor(w => w.Password).NotEmpty()
                                    .NotNull()
                                    .Length(4, 8);
        }
    }
}
