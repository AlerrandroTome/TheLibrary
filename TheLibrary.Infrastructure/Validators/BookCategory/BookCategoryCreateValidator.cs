using FluentValidation;
using TheLibrary.Core.DTOs.BookCategory;

namespace TheLibrary.Infrastructure.Validators.BookCategory
{
    public class BookCategoryCreateValidator : AbstractValidator<BookCategoryCreateDTO>
    {
        public BookCategoryCreateValidator()
        {
            RuleFor(w => w.Title).NotEmpty().Length(1, 100);
        }
    }
}
