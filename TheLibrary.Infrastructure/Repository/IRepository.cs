using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TheLibrary.Core.Entities;

namespace TheLibrary.Infrastructure.Repository
{
    public interface IRepository<T> where T : EntityBase
    {
        Task<T> Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task DeleteRange(List<T> entities);
        Task<T> Get(Expression<Func<T, bool>> condiction, string[] includes = null);
        IQueryable<T> GetAll();
    }
}
