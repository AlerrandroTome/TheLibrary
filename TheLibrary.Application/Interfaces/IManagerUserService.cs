using System;
using System.Threading.Tasks;
using TheLibrary.Core.Interfaces;
using TheLibrary.Infrastructure.DTOs.User;
using TheLibrary.Infrastructure.Entities;

namespace TheLibrary.Application.Interfaces
{
    public interface IManagerUserService : IBaseService<User, UserCreateDTO, UserUpdateDTO>
    {
        Task BlockUser(Guid userId, Guid loggedUserId);
    }
}
