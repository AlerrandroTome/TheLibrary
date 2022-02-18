using System;
using System.Linq;
using System.Threading.Tasks;
using TheLibrary.Core.DTOs.Response;
using TheLibrary.Core.Entities;

namespace TheLibrary.Core.Interfaces
{
    public interface IBaseService<Entity, CreateDTO, UpdateDTO> 
        where CreateDTO : class where UpdateDTO : class where Entity : EntityBase
    {
        Task<Response<Entity>> Create(CreateDTO dto);
        Task<Response<Entity>> Update(UpdateDTO dto);
        Task<Response<Guid>> Delete(Guid id);
        IQueryable<Entity> Get();
    }
}
