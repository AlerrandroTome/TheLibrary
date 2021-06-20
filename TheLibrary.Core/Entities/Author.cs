using System.Collections.Generic;
using TheLibrary.Core.Interfaces;

namespace TheLibrary.Core.Entities
{
    public class Author : EntityBase, IODataEntity
    {
        //Criar no banco
        public string Name { get; set; }

        public ICollection<Book> Books = new List<Book>();
    }
}
