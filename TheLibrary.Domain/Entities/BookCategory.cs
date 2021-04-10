using TheLibrary.Core.Entities;
using TheLibrary.Core.Interfaces;

namespace TheLibrary.Domain.Entities
{
    public class BookCategory : EntityBase, IODataEntity
    {
        public string Title { get; set; }
    }
}
