using AutoMapper;
using TheLibrary.Core.DTOs.Author;
using TheLibrary.Core.DTOs.Book;
using TheLibrary.Core.DTOs.BookCategory;
using TheLibrary.Core.DTOs.Rental;
using TheLibrary.Core.DTOs.User;
using TheLibrary.Core.DTOs.UserAddress;
using TheLibrary.Core.Entities;

namespace TheLibrary.Infrastructure.AutoMapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<BookCategory, BookCategoryCreateDTO>().ReverseMap();
            CreateMap<BookCategory, BookCategoryUpdateDTO>().ReverseMap();

            CreateMap<Author, AuthorCreateDTO>().ReverseMap();
            CreateMap<Author, AuthorUpdateDTO>().ReverseMap();

            CreateMap<Book, BookCreateDTO>().ReverseMap();
            CreateMap<Book, BookUpdateDTO>().ReverseMap();

            CreateMap<User, UserCreateDTO>().ForMember(p => p.Addresses, opt => opt.Ignore());
            CreateMap<UserCreateDTO, User>().ForMember(p => p.Addresses, opt => opt.Ignore());
            CreateMap<User, UserUpdateDTO>().ForMember(p => p.Addresses, opt => opt.Ignore());
            CreateMap<UserUpdateDTO, User>().ForMember(p => p.Addresses, opt => opt.Ignore());

            CreateMap<UserAddress, UserAddressDTO>().ReverseMap();

            CreateMap<Rental, RentalCreateDto>().ForMember(p => p.Books, opt => opt.Ignore());
            CreateMap<RentalCreateDto, Rental>().ForMember(p => p.Books, opt => opt.Ignore());

            CreateMap<Rental, RentalUpdateDto>().ForMember(p => p.Books, opt => opt.Ignore());
            CreateMap<RentalUpdateDto, Rental>().ForMember(p => p.Books, opt => opt.Ignore());
        }
    }
}
