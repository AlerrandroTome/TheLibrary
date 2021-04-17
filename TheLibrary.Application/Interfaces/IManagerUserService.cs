using System;
using System.Threading.Tasks;
using TheLibrary.Core.Interfaces;
using TheLibrary.Domain.Entities;
using TheLibrary.Infrastructure.DTOs.User;

namespace TheLibrary.Application.Interfaces
{
    public interface IManagerUserService : IBaseService<User, UserCreateDTO, UserUpdateDTO>
    {
        Task BlockUser(Guid userId, Guid loggedUserId);
    }
}
