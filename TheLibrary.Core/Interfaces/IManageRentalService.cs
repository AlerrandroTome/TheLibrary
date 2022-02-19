using TheLibrary.Core.DTOs.Rental;
using TheLibrary.Core.Entities;

namespace TheLibrary.Core.Interfaces
{
    public interface IManageRentalService : IBaseService<Rental, RentalCreateDto, RentalUpdateDto>
    {
    }
}
