using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TheLibrary.Core.Entities;

namespace TheLibrary.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        private readonly DbContext _context;

        public Repository(DbContext context)
        {
            this._context = context;
        }

        public async Task<T> Create(T entity)
        {
            _ = _context ?? throw new ArgumentNullException(nameof(_context));
            entity.InclusionDate = DateTime.Now;
            entity.Active = true;

            var result = _context.Add(entity);
            await  _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task Delete(T entity)
        {
            _ = _context ?? throw new ArgumentNullException(nameof(_context));
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> Get(Expression<Func<T, bool>> condiction, string[] includes = null)
        {
            var query = GetAll().Where(condiction);

            if(includes != null && includes.Length > 0)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            return await query.FirstOrDefaultAsync();
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking().AsQueryable();
        }

        public async Task<T> Update(T entity)
        {
            _ = _context ?? throw new ArgumentNullException(nameof(_context));
            entity.LastChangeDate = DateTime.Now;
            var result = _context.Update(entity);

            await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}
