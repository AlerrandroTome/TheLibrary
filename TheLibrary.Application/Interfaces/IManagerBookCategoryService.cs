using TheLibrary.Core.Interfaces;
using TheLibrary.Domain.Entities;
using TheLibrary.Infrastructure.DTOs.BookCategory;

namespace TheLibrary.Application.Interfaces
{
    public interface IManagerBookCategoryService : IBaseService<BookCategory, BookCategoryCreateDTO, BookCategoryUpdateDTO>
    {
    }
}
