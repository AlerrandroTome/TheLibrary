using FluentValidation;
using TheLibrary.Core.DTOs.BookCategory;

namespace TheLibrary.Application.Validators.BookCategory
{
    public class BookCategoryCreateValidator : AbstractValidator<BookCategoryCreateDTO>
    {
        public BookCategoryCreateValidator()
        {
            RuleFor(w => w.Title).NotNull().NotEmpty().Length(1, 100);
        }
    }
}
