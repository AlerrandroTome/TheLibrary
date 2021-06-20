using TheLibrary.Core.DTOs.Author;
using TheLibrary.Core.Entities;

namespace TheLibrary.Core.Interfaces
{
    public interface IManageAuthorService : IBaseService<Author, AuthorCreateDTO, AuthorUpdateDTO>
    {
    }
}
