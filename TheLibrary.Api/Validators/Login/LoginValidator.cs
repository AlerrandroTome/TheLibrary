using FluentValidation;
using TheLibrary.Core.DTOs.Login;

namespace TheLibrary.Api.Validators.Login
{
    public class LoginValidator : AbstractValidator<LoginDTO>
    {
        public LoginValidator()
        {
            RuleFor(w => w.Login).NotEmpty().NotNull().MinimumLength(5);
            RuleFor(w => w.Password).NotEmpty()
                                    .WithMessage("É necessário informar a senha.")
                                    .NotNull()
                                    .WithMessage("É necessário informar a senha.")
                                    .Length(4, 8)
                                    .WithMessage("A senha tem que ter entre {MinLength} e {MaxLength} caracteres. Você digitou {TotalLength}.");
        }
    }
}
