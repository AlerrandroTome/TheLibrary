using FluentValidation;
using TheLibrary.Core.DTOs.Book;

namespace TheLibrary.Api.Validators.Book
{
    public class BookCreateValidator : AbstractValidator<BookCreateDTO>
    {
        public BookCreateValidator()
        {
            RuleFor(w => w.Title).NotEmpty()
                                 .WithMessage("É necessário informar o titulo.")
                                 .NotNull()
                                 .WithMessage("É necessário informar o titulo.")
                                 .Length(1, 100)
                                 .WithMessage("O titulo precisa ter entre {MinLength} e {MaxLength} caracteres. Você digitou {TotalLength}.");

            RuleFor(w => w.Resume).NotEmpty()
                                  .WithMessage("É necessário informar o resumo.")
                                  .NotNull()
                                  .WithMessage("É necessário informar o resumo.")
                                  .Length(1, 700)
                                  .WithMessage("O resumo precisa ter entre {MinLength} e {MaxLength} caracteres. Você digitou {TotalLength}.");

            RuleFor(w => w.ReleaseDate).NotNull()
                                       .WithMessage("É necessário informa a data de lançamento.")
                                       .NotEmpty()
                                       .WithMessage("É necessário informar a data de lançamento.");

            RuleFor(w => w.CategoryId).NotNull()
                                      .WithMessage("É necessário informar a categoria.")
                                      .NotEmpty()
                                      .WithMessage("É necessário informar a categoria.");

            RuleFor(w => w.AuthorId).NotNull()
                                    .WithMessage("É necessário informar o autor.")
                                    .NotEmpty()
                                    .WithMessage("É necessário informar o autor.");
        }
    }
}
