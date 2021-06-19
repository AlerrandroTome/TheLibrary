using TheLibrary.Core.Interfaces;

namespace TheLibrary.Core.Entities
{
    public class BookCategory : EntityBase, IODataEntity
    {
        public string Title { get; set; }
    }
}
