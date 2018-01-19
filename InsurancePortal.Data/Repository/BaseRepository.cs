﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace InsurancePortal.Data
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly InsurancePortalEntities _dbContext;

        private DbSet<T> _entitySet;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _dbContext;
            }
        }


        public BaseRepository(InsurancePortalEntities dbContext)
        {
            _dbContext = dbContext;
            _entitySet = _dbContext.Set<T>();
        }

        public virtual T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        //public T GetSingleBySpec(ISpecification<T> spec)
        //{
        //    return List(spec).FirstOrDefault();
        //}
        

        public IEnumerable<T> ListAll()
        {
            return _dbContext.Set<T>().AsEnumerable();
        }
        

        //public IEnumerable<T> List(ISpecification<T> spec)
        //{
        //    // fetch a Queryable that includes all expression-based includes
        //    var queryableResultWithIncludes = spec.Includes
        //        .Aggregate(_dbContext.Set<T>().AsQueryable(),
        //            (current, include) => current.Include(include));

        //    // modify the IQueryable to include any string-based include statements
        //    var secondaryResult = spec.IncludeStrings
        //        .Aggregate(queryableResultWithIncludes,
        //            (current, include) => current.Include(include));

        //    // return the result of the query using the specification's criteria expression
        //    return secondaryResult
        //                    .Where(spec.Criteria)
        //                    .AsEnumerable();
        //}
        //public async Task<List<T>> ListAsync(ISpecification<T> spec)
        //{
        //    // fetch a Queryable that includes all expression-based includes
        //    var queryableResultWithIncludes = spec.Includes
        //        .Aggregate(_dbContext.Set<T>().AsQueryable(),
        //            (current, include) => current.Include(include));

        //    // modify the IQueryable to include any string-based include statements
        //    var secondaryResult = spec.IncludeStrings
        //        .Aggregate(queryableResultWithIncludes,
        //            (current, include) => current.Include(include));

        //    // return the result of the query using the specification's criteria expression
        //    return await secondaryResult
        //                    .Where(spec.Criteria)
        //                    .ToListAsync();
        //}

        public T Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public void AddRange(List<T> entities)
        {
            _dbContext.Set<T>().AddRange(entities);
            _dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void UpdateRange(List<T> entities)
        {
            foreach (var entity in entities)
            {
                Update(entity);
            }
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public void DeleteRange(List<T> entities)
        {
            _dbContext.Set<T>().RemoveRange(entities);
            _dbContext.SaveChanges();
        }


        #region Async methods
        //public virtual async Task<T> GetByIdAsync(int id)
        //{
        //    return await _dbContext.Set<T>().FindAsync(id);
        //}

        //public async Task<List<T>> ListAllAsync()
        //{
        //    return await _dbContext.Set<T>().ToListAsync();
        //}

        //public async Task<T> AddAsync(T entity)
        //{
        //    _dbContext.Set<T>().Add(entity);
        //    //await _dbContext.SaveChangesAsync();
        //    return entity;
        //}

        //public async Task AddRangeAsync(List<T> entities)
        //{
        //    _dbContext.Set<T>().AddRange(entities);
        //}

        //public async Task UpdateAsync(T entity)
        //{
        //    _dbContext.Entry(entity).State = EntityState.Modified;
        //    //await _dbContext.SaveChangesAsync();
        //}

        //public async Task UpdateRangeAsync(List<T> entities)
        //{
        //    foreach (var entity in entities)
        //    {
        //        await UpdateAsync(entity);
        //    }
        //}

        //public async Task DeleteAsync(T entity)
        //{
        //    _dbContext.Set<T>().Remove(entity);
        //    //await _dbContext.SaveChangesAsync();
        //}
        //public async Task DeleteRangeAsync(List<T> entities)
        //{
        //    _dbContext.Set<T>().RemoveRange(entities);
        //    //await _dbContext.SaveChangesAsync();
        //}

        //public async Task SaveChangesAsync()
        //{
        //    await this._dbContext.SaveChangesAsync();
        //}
        #endregion
    }
}
