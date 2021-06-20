using FluentValidation;
using TheLibrary.Core.DTOs.Author;

namespace TheLibrary.Api.Validators.Author
{
    public class AuthorUpdateValidator : AbstractValidator<AuthorUpdateDTO>
    {
        public AuthorUpdateValidator()
        {
            RuleFor(w => w.Id).NotNull()
                              .NotEmpty();

            RuleFor(w => w.Name).NotEmpty()
                                .WithMessage("É necessário informar o nome do autor.")
                                .NotNull()
                                .WithMessage("É necessário informar o nome do autor.");
        }
    }
}
