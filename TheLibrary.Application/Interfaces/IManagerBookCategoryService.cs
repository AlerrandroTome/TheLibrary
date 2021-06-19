using TheLibrary.Core.Interfaces;
using TheLibrary.Infrastructure.DTOs.BookCategory;
using TheLibrary.Infrastructure.Entities;

namespace TheLibrary.Application.Interfaces
{
    public interface IManagerBookCategoryService : IBaseService<BookCategory, BookCategoryCreateDTO, BookCategoryUpdateDTO>
    {
    }
}
