using FluentValidation;
using TheLibrary.Core.DTOs.Rental;

namespace TheLibrary.Infrastructure.Validators.Rental
{
    public class RentalUpdateValidator : AbstractValidator<RentalUpdateDto>
    {
        public RentalUpdateValidator()
        {
            RuleFor(p => p.Id).NotEmpty();
            RuleFor(p => p.UserId).NotEmpty();
            RuleFor(p => p.StartDate).NotEmpty();
            RuleFor(p => p.ReturnDate).NotEmpty();
        }
    }
}
