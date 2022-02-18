using FluentValidation;
using TheLibrary.Core.DTOs.BookCategory;

namespace TheLibrary.Infrastructure.Validators.BookCategory
{
    public class BookCategoryUpdateValidator : AbstractValidator<BookCategoryUpdateDTO>
    {
        public BookCategoryUpdateValidator()
        {
            RuleFor(w => w.Id).NotNull().NotNull();

            RuleFor(w => w.Title).NotEmpty().Length(1, 100);
        }
    }
}
