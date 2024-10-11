using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Music.Market.Core.Repositories
{
    public  interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        IEnumerable<T> Find(Expression<Func<T, bool>> filter);
        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> filter);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void  RemoveAsync(T entity);
        void RemoveRangeAsync(IEnumerable<T> entities);

    }
}
