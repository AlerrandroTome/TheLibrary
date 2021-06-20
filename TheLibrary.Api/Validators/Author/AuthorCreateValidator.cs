using FluentValidation;
using TheLibrary.Core.DTOs.Author;

namespace TheLibrary.Api.Validators.Author
{
    public class AuthorCreateValidator : AbstractValidator<AuthorCreateDTO>
    {
        public AuthorCreateValidator()
        {
            RuleFor(w => w.Name).NotEmpty()
                                .WithMessage("É necessário informar o nome do autor.")
                                .NotNull()
                                .WithMessage("É necessário informar o nome do autor.");
        }
    }
}
