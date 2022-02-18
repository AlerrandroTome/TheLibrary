using System;

namespace TheLibrary.Core.DTOs.Book
{
    public class BookCreateDTO
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Guid CategoryId { get; set; }
        public Guid AuthorId { get; set; }
    }
}
