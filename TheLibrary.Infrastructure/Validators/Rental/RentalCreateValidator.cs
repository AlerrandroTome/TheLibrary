using FluentValidation;
using System.Linq;
using TheLibrary.Core.DTOs.Rental;

namespace TheLibrary.Infrastructure.Validators.Rental
{
    public class RentalCreateValidator : AbstractValidator<RentalCreateDto>
    {
        public RentalCreateValidator()
        {
            RuleFor(p => p.UserId).NotEmpty();
            RuleFor(p => p.StartDate).NotEmpty();
            RuleFor(p => p.ReturnDate).NotEmpty();
        }
    }
}
