using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KD.Function.Customer.ValidationAccounts.Infrastructure.Repositories.EntityFramework.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetByFilter(Expression<Func<T, bool>> expression = null, params Expression<Func<T, object>>[] includes);
        Task<IEnumerable<T>> Get(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes);
        Task<IEnumerable<T>> Get(params Expression<Func<T, object>>[] includes);
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
