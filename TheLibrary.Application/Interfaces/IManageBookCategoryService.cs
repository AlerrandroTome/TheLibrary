using TheLibrary.Core.Interfaces;
using TheLibrary.Domain.DTOs.BookCategory;
using TheLibrary.Domain.Entities;

namespace TheLibrary.Application.Interfaces
{
    public interface IManageBookCategoryService : IBaseService<BookCategory, BookCategoryCreateDTO, BookCategoryUpdateDTO>
    {
    }
}
