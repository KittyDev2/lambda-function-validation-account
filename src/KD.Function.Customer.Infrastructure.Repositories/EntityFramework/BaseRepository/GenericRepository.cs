using KD.Function.Customer.Infrastructure.Repositories.EntityFramework.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KD.Function.Customer.Infrastructure.Repositories.EntityFramework.BaseRepository
{
    [ExcludeFromCodeCoverage]
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DataContext _context;

        public GenericRepository(DataContext context)
        {
            _context = context;
        }

        #region Generics CRUD
        public async Task Insert(T entity)
        {
            _context.Set<T>().AsNoTracking();
            _context.Set<T>().Add(entity);

            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _context.Set<T>().AsNoTracking();
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes)
        {
            var query = _context.Set<T>().AsNoTracking().Where(expression);

            if (includes.Any())
                query = includes.Aggregate(query, (current, include) => current.Include(include));

            return await query?.ToListAsync();
        }

        public async Task<IEnumerable<T>> Get(params Expression<Func<T, object>>[] includes)
        {
            var query = _context.Set<T>().AsNoTracking().AsQueryable();

            if (includes.Any())
                query = includes.Aggregate(query, (current, include) => current.Include(include));

            return await query?.ToListAsync();
        }

        public IQueryable<T> GetByFilter(Expression<Func<T, bool>> expression = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query;

            if (expression.Parameters.Any())
                query = _context.Set<T>().Where(expression);
            else
                query = _context.Set<T>().AsQueryable();

            if (includes.Any())
                query = includes.Aggregate(query, (current, include) => current.Include(include));

            return query.AsNoTracking();
        }

        public async Task Delete(T entity)
        {
            
            _context.Set<T>().AsNoTracking();
            _context.Set<T>().Remove(entity);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteRange(IEnumerable<T> entities)
        {

            _context.Set<T>().AsNoTracking();
            _context.Set<T>().RemoveRange(entities);

            await _context.SaveChangesAsync();
        }
        #endregion
    }
}
