using FluentValidation;
using TheLibrary.Core.DTOs.BookCategory;

namespace TheLibrary.Application.Validators.BookCategory
{
    public class BookCategoryUpdateValidator : AbstractValidator<BookCategoryUpdateDTO>
    {
        public BookCategoryUpdateValidator()
        {
            RuleFor(w => w.Id).NotNull().NotNull();

            RuleFor(w => w.Title).NotNull()
                                 .WithMessage("É necessário informar o titulo.")
                                 .NotEmpty()
                                 .WithMessage("É necessário informar o titulo.")
                                 .Length(1, 100)
                                 .WithMessage("O titulo tem que ter entre {MinLength} e {MaxLength} caractere. Você digitou {TotalLength}");
        }
    }
}
