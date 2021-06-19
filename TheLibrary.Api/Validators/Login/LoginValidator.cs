using FluentValidation;
using TheLibrary.Infrastructure.DTOs.Login;

namespace TheLibrary.Api.Validators.Login
{
    public class LoginValidator : AbstractValidator<LoginDTO>
    {
        public LoginValidator()
        {
            RuleFor(w => w.Login).NotEmpty().NotNull().MinimumLength(5);
            RuleFor(w => w.Password).NotEmpty()
                                    .WithMessage("A senha não pode ser vazia.")
                                    .NotNull()
                                    .WithMessage("A senha não pode ser nula.")
                                    .Length(4, 8)
                                    .WithMessage("A senha tem que ter entre {MinLength} e {MaxLength}. Você digitou {TotalLength}.");
        }
    }
}
