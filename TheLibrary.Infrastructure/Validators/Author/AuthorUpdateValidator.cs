using FluentValidation;
using TheLibrary.Core.DTOs.Author;

namespace TheLibrary.Infrastructure.Validators.Author
{
    public class AuthorUpdateValidator : AbstractValidator<AuthorUpdateDTO>
    {
        public AuthorUpdateValidator()
        {
            RuleFor(w => w.Id).NotEmpty();
            RuleFor(w => w.Name).NotEmpty();
        }
    }
}
