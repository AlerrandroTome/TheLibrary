using System;

namespace TheLibrary.Core.Entities
{
    public class BookRental
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid BookId { get; set; }
        public Guid RentalId { get; set; }

        public Book Book { get; set; }
        public Rental Rental { get; set; }
    }
}
