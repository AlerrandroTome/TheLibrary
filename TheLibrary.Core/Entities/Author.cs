using System.Collections.Generic;
using TheLibrary.Core.Interfaces;

namespace TheLibrary.Core.Entities
{
    public class Author : EntityBase, IODataEntity
    {
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}