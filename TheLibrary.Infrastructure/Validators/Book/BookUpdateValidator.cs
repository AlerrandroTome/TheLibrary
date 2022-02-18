using FluentValidation;
using TheLibrary.Core.DTOs.Book;

namespace TheLibrary.Infrastructure.Validators.Book
{
    public class BookUpdateValidator : AbstractValidator<BookUpdateDTO>
    {
        public BookUpdateValidator()
        {
            _ = RuleFor(w => w.Id).NotNull()
                                  .NotEmpty();

            _ = RuleFor(w => w.Title).NotEmpty()
                                     .Length(1, 100);

            _ = RuleFor(w => w.Summary).NotEmpty()
                                      .Length(1, 700);

            _ = RuleFor(w => w.ReleaseDate).NotEmpty();

            _ = RuleFor(w => w.CategoryId).NotEmpty();

            _ = RuleFor(w => w.AuthorId).NotEmpty();
        }
    }
}
