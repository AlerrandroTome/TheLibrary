using TheLibrary.Core.DTOs.BookCategory;
using TheLibrary.Core.Entities;

namespace TheLibrary.Core.Interfaces
{
    public interface IManageBookCategoryService : IBaseService<BookCategory, BookCategoryCreateDTO, BookCategoryUpdateDTO>
    {
    }
}
