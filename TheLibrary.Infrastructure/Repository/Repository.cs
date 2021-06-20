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

        public async Task Create(T entity)
        {
            if(_context != null)
            {
                entity.InclusionDate = DateTime.Now;
                entity.Active = true;

                _context.Add(entity);
                await  _context.SaveChangesAsync();
            }
        }

        public async Task Delete(T entity)
        {
            if (_context != null)
            {
                _context.Remove(entity);
                await _context.SaveChangesAsync();
            }
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

        public async Task Update(T entity)
        {
            if (_context != null)
            {
                entity.LastChangeDate = DateTime.Now;
                _context.Update(entity);

                await _context.SaveChangesAsync();
            }
        }
    }
}
