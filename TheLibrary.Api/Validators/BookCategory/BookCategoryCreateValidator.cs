using FluentValidation;
using TheLibrary.Infrastructure.DTOs.BookCategory;

namespace TheLibrary.Application.Validators.BookCategory
{
    public class BookCategoryCreateValidator : AbstractValidator<BookCategoryCreateDTO>
    {
        public BookCategoryCreateValidator()
        {
            RuleFor(w => w.Title).NotNull()
                                 .WithMessage("Titulo não pode ser nulo.")
                                 .NotEmpty()
                                 .WithMessage("O titulo não pode ser vazio.")
                                 .Length(1, 100)
                                 .WithMessage("O titulo tem que ter entre {MinLength} e {MaxLength} caractere. Você digitou {TotalLength}");
        }
    }
}
