using System;
using TheLibrary.Core.Interfaces;

namespace TheLibrary.Core.Entities
{
    public class Book : EntityBase, IODataEntity
    {
        //Criar no banco
        public string Title { get; set; }
        public string Resume { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Guid CategoryId { get; set; }
        public Guid AuthorId { get; set; }

        public Author Author { get; set; }
        public BookCategory Category { get; set; }
    }
}
