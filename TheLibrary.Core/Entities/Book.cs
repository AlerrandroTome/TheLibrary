using System;
using System.Collections.Generic;
using TheLibrary.Core.Interfaces;

namespace TheLibrary.Core.Entities
{
    public class Book : EntityBase, IODataEntity
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Guid CategoryId { get; set; }
        public Guid AuthorId { get; set; }

        public Author Author { get; set; }
        public BookCategory Category { get; set; }
        public ICollection<BookRental> Rentals { get; set; } = new List<BookRental>();
    }
}
