using System;
using System.Collections.Generic;

namespace TheLibrary.Core.DTOs.Rental
{
    public class RentalCreateDto
    {
        public DateTime StartDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public Guid UserId { get; set; }

        public List<Guid> Books { get; set; } = new List<Guid>();
    }
}
