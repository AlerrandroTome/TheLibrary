using System.Collections.Generic;
using TheLibrary.Core.Interfaces;

namespace TheLibrary.Core.Entities
{
    public class BookCategory : EntityBase, IODataEntity
    {
        public string Title { get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
