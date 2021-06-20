using TheLibrary.Core.DTOs.Book;
using TheLibrary.Core.Entities;

namespace TheLibrary.Core.Interfaces
{
    public interface IManageBookService : IBaseService<Book, BookCreateDTO, BookUpdateDTO>
    {
    }
}
