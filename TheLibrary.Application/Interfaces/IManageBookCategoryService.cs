using System;
using TheLibrary.Core.DTOs.BookCategory;
using TheLibrary.Core.Interfaces;
using TheLibrary.Domain.Entities;

namespace TheLibrary.Application.Interfaces
{
    public interface IManageBookCategoryService : IBaseService<BookCategory, BookCategoryCreateDTO, BookCategoryUpdateDTO>
    {
    }
}
