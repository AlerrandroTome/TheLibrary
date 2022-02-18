using System;
using System.Threading.Tasks;
using TheLibrary.Core.DTOs.Response;
using TheLibrary.Core.DTOs.User;
using TheLibrary.Core.Entities;

namespace TheLibrary.Core.Interfaces
{
    public interface IManageUserService : IBaseService<User, UserCreateDTO, UserUpdateDTO>
    {
        Task<Response<Guid>> BlockUser(Guid userId, Guid loggedUserId);
    }
}
