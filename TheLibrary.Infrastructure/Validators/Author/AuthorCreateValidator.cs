using FluentValidation;
using TheLibrary.Core.DTOs.Author;

namespace TheLibrary.Infrastructure.Validators.Author
{
    public class AuthorCreateValidator : AbstractValidator<AuthorCreateDTO>
    {
        public AuthorCreateValidator()
        {
            RuleFor(w => w.Name).NotEmpty();
        }
    }
}
