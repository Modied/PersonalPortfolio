using Microsoft.EntityFrameworkCore;
using Portfolio.Business.Interfaces;
using Portfolio.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {

        private readonly PortfolioDBContext _dbContext;


        public BaseRepository(PortfolioDBContext dbContext)
        {
            _dbContext = dbContext;
        }


        /*********** Start Add Methods ************/

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.AddAsync(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbContext.AddRangeAsync(entities);
            _dbContext.SaveChanges();
            return entities;
        }

        /*********** End  Add Methods ************/

        /*********** Start Delete Methods ************/

        public async Task<T> DeleteAsync(T entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return entity;

        }

        public async Task<T> DeleteByIdAsync(int id)
        {
            _dbContext?.Remove(id);
            await _dbContext.SaveChangesAsync();
            throw new NotImplementedException();

        }

        /*********** End Delete Methods ************/

        /*********** Start Find Methods ************/

        public async Task<T> FindByExpAsync(Expression<Func<T, bool>> bResult)
        {
            return await _dbContext.Set<T>().SingleOrDefaultAsync(bResult);
        }

        public async Task<IEnumerable<T>> FindByExpIncludeAsync(Expression<Func<T, bool>> bResult, string[] includes)
        {
            IQueryable<T> query = _dbContext.Set<T>().Where(bResult);

            if (includes.Length > 0)
                foreach (var include in includes)
                    query = query.Include(include);

            return await query.ToListAsync();
        }

        /*********** End Find Methods ************/

        /*********** Start Get Methods ************/

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetFirstAsync()
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetAllIncludesAsync(string[] includes)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if (includes.Length > 0)
                foreach (var include in includes)
                    query = query.Include(include);
            return await query.ToListAsync();
        }

        public async Task<T> GetByIDAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        /*********** End Get Methods ************/

        /*********** Start Update Methods ************/


        public async Task<T> UpdateAsync(T entity, Expression<Func<T, bool>> criteria)
        {
            var exiestEntity = await _dbContext.Set<T>().FirstOrDefaultAsync(criteria);
            if (exiestEntity is not null)
            {
                _dbContext.Entry(exiestEntity).CurrentValues.SetValues(entity);
                await _dbContext.SaveChangesAsync();
                return exiestEntity;


            }
            return entity;
        }

        public async Task<IEnumerable<T>> UpdateRangeAsync(IEnumerable<T> entities, Expression<Func<T, bool>> criteria)
        {
            _dbContext.UpdateRange(entities);
            await _dbContext.SaveChangesAsync();
            return entities.ToList();
        }
        /*********** End Update Methods ************/
    }
}
