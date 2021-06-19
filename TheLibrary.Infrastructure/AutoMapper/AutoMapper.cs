using AutoMapper;
using TheLibrary.Core.DTOs.BookCategory;
using TheLibrary.Core.DTOs.User;
using TheLibrary.Core.DTOs.UserAddress;
using TheLibrary.Core.Entities;
using TheLibrary.Infrastructure.Entities;

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
