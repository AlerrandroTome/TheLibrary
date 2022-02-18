using System;
using TheLibrary.Core.DTOs.Base;

namespace TheLibrary.Core.DTOs.Book
{
    public class BookUpdateDTO : DtoUpdate
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Guid CategoryId { get; set; }
        public Guid AuthorId { get; set; }
    }
}