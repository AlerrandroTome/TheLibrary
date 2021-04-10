using System;
using System.Linq;
using System.Threading.Tasks;
using TheLibrary.Core.Entities;

namespace TheLibrary.Core.Interfaces
{
    public interface IBaseService<Entity, CreateDTO, UpdateDTO> 
        where CreateDTO : class where UpdateDTO : class where Entity : EntityBase
    {
        Task Create(CreateDTO dto);
        Task  Update(UpdateDTO dto);
        Task Delete(Guid id);
        IQueryable<Entity> Get();
    }
}
