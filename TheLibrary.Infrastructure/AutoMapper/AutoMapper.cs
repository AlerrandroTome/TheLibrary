using AutoMapper;
using TheLibrary.Domain.Entities;
using TheLibrary.Infrastructure.DTOs.BookCategory;
using TheLibrary.Infrastructure.DTOs.User;
using TheLibrary.Infrastructure.DTOs.UserAddress;

namespace TheLibrary.Infrastructure.AutoMapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<BookCategory, BookCategoryCreateDTO>().ReverseMap();
            CreateMap<BookCategory, BookCategoryUpdateDTO>().ReverseMap();

            CreateMap<User, UserCreateDTO>().ForMember(p => p.Addresses, opt => opt.Ignore());
            CreateMap<UserCreateDTO, User>().ForMember(p => p.Addresses, opt => opt.Ignore());
            CreateMap<User, UserUpdateDTO>().ForMember(p => p.Addresses, opt => opt.Ignore());
            CreateMap<UserUpdateDTO, User>().ForMember(p => p.Addresses, opt => opt.Ignore());

            CreateMap<UserAddress, UserAddressDTO>().ReverseMap();
        }
    }
}
