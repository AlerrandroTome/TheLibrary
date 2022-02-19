using System;
using System.Collections.Generic;
using TheLibrary.Core.Interfaces;

namespace TheLibrary.Core.Entities
{
    public class Rental : EntityBase, IODataEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public Guid UserId { get; set; }

        public User User { get; set; }
        public ICollection<BookRental> Books { get; set; } = new List<BookRental>();
    }
}
