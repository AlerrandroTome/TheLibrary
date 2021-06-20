using FluentValidation;
using TheLibrary.Core.DTOs.BookCategory;

namespace TheLibrary.Application.Validators.BookCategory
{
    public class BookCategoryCreateValidator : AbstractValidator<BookCategoryCreateDTO>
    {
        public BookCategoryCreateValidator()
        {
            RuleFor(w => w.Title).NotNull()
                                 .WithMessage("É necessário informar o titulo.")
                                 .NotEmpty()
                                 .WithMessage("É necessário informar o titulo.")
                                 .Length(1, 100)
                                 .WithMessage("O titulo tem que ter entre {MinLength} e {MaxLength} caractere. Você digitou {TotalLength}");
        }
    }
}
