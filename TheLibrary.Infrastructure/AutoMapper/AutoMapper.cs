using AutoMapper;
using TheLibrary.Domain.Entities;
using TheLibrary.Infrastructure.DTOs.BookCategory;
using TheLibrary.Infrastructure.DTOs.User;

namespace TheLibrary.Infrastructure.AutoMapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<BookCategory, BookCategoryCreateDTO>().ReverseMap();
            CreateMap<BookCategory, BookCategoryUpdateDTO>().ReverseMap();

            CreateMap<User, UserCreateDTO>().ReverseMap();
            CreateMap<User, UserUpdateDTO>().ReverseMap();
        }
    }
}
