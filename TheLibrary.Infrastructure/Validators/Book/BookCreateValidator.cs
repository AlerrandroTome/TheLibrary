using FluentValidation;
using TheLibrary.Core.DTOs.Book;

namespace TheLibrary.Infrastructure.Validators.Book
{
    public class BookCreateValidator : AbstractValidator<BookCreateDTO>
    {
        public BookCreateValidator()
        {
            RuleFor(w => w.Title).NotEmpty()
                                 .Length(1, 100);

            RuleFor(w => w.Summary).NotEmpty()
                                  .Length(1, 700);

            RuleFor(w => w.ReleaseDate).NotEmpty();

            RuleFor(w => w.CategoryId).NotEmpty();

            RuleFor(w => w.AuthorId).NotEmpty();
        }
    }
}
