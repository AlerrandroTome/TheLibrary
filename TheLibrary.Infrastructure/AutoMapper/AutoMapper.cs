using AutoMapper;
using TheLibrary.Core.DTOs.BookCategory;
using TheLibrary.Domain.Entities;

namespace TheLibrary.Infrastructure.AutoMapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<BookCategory, BookCategoryCreateDTO>().ReverseMap();
            CreateMap<BookCategory, BookCategoryUpdateDTO>().ReverseMap();
        }
    }
}
