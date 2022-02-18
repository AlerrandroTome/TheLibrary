using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TheLibrary.Core.Entities;

namespace TheLibrary.Infrastructure.Repository
{
    public interface IRepository<T> where T : EntityBase
    {
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task Delete(T entity);
        Task<T> Get(Expression<Func<T, bool>> condiction, string[] includes = null);
        IQueryable<T> GetAll();
    }
}
