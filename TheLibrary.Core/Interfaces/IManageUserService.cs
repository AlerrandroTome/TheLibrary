using System;
using System.Threading.Tasks;
using TheLibrary.Core.DTOs.User;
using TheLibrary.Infrastructure.Entities;

namespace TheLibrary.Core.Interfaces
{
    public interface IManageUserService : IBaseService<User, UserCreateDTO, UserUpdateDTO>
    {
        Task BlockUser(Guid userId, Guid loggedUserId);
    }
}
