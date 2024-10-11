using Microsoft.EntityFrameworkCore;
using Music.Market.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Music.Market.Data.Repositories
{
    public class Repository<T>:IRepository<T> where T : class

    {
        protected readonly DbContext context;

        public Repository(DbContext _context)
        {
            this.context = _context;
        }

        public async Task AddAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await context.Set<T>().AddRangeAsync(entities);        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> filter)
        {
            return context.Set<T>().Where(filter);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public void RemoveAsync(T entity)
        {
            context.Set<T>().Remove(entity);
            
        }

        public void RemoveRangeAsync(IEnumerable<T> entities)
        {
            context.Set<T>().RemoveRange(entities);
        }

        public Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> filter)
        {
            return context.Set<T>().SingleOrDefaultAsync(filter);
        }
    }
}
