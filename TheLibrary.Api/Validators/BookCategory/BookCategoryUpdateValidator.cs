using FluentValidation;
using TheLibrary.Domain.DTOs.BookCategory;

namespace TheLibrary.Application.Validators.BookCategory
{
    public class BookCategoryUpdateValidator : AbstractValidator<BookCategoryUpdateDTO>
    {
        public BookCategoryUpdateValidator()
        {
            RuleFor(w => w.Id).NotNull().NotNull();
            RuleFor(w => w.Title).NotNull().NotEmpty().Length(1, 100);
        }
    }
}
