using System;
using System.Collections.Generic;
using TheLibrary.Core.DTOs.Base;

namespace TheLibrary.Core.DTOs.Rental
{
    public class RentalUpdateDto : DtoUpdate
    {
        public DateTime StartDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public Guid UserId { get; set; }

        public ICollection<Guid> Books { get; set; }
    }
}
