using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SppdDocs.Core.Domain.Entities;
using SppdDocs.Core.Repositories;
using SppdDocs.Core.Specifications;

namespace SppdDocs.Infrastructure.DbAccess.Repositories
{
    /// <summary>
    ///     "There's some repetition here - couldn't we have some the sync methods call the async?"
    ///     https://blogs.msdn.microsoft.com/pfxteam/2012/04/13/should-i-expose-synchronous-wrappers-for-asynchronous-methods/
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    internal class Repository<TEntity> : IRepository<TEntity>, IAsyncRepository<TEntity>
        where TEntity : BaseEntity
    {
        public Repository(SppdContext sppdContext)
        {
            SppdContext = sppdContext;
        }

        protected DbSet<TEntity> Set => SppdContext.Set<TEntity>();

        protected SppdContext SppdContext { get; }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await SppdContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<List<TEntity>> ListAllAsync()
        {
            return await SppdContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            SppdContext.Set<TEntity>().Add(entity);
            await SppdContext.SaveChangesAsync();

            return entity;
        }

        public async Task UpdateAsync(TEntity entity)
        {
            SppdContext.Entry(entity).State = EntityState.Modified;
            await SppdContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            SppdContext.Set<TEntity>().Remove(entity);
            await SppdContext.SaveChangesAsync();
        }

        public virtual TEntity GetById(Guid id)
        {
            return SppdContext.Set<TEntity>().Find(id);
        }

        public TEntity GetSingleBySpec(ISpecification<TEntity> spec)
        {
            return List(spec).FirstOrDefault();
        }

        public IEnumerable<TEntity> ListAll()
        {
            return SppdContext.Set<TEntity>().AsEnumerable();
        }

        public IEnumerable<TEntity> List(ISpecification<TEntity> spec)
        {
            // fetch a Queryable that includes all expression-based includes
            var queryableResultWithIncludes = spec.Includes
                                                  .Aggregate(SppdContext.Set<TEntity>().AsQueryable(),
                                                      (current, include) => current.Include(include));

            // modify the IQueryable to include any string-based include statements
            var secondaryResult = spec.IncludeStrings
                                      .Aggregate(queryableResultWithIncludes,
                                          (current, include) => current.Include(include));

            // return the result of the query using the specification's criteria expression
            return secondaryResult
                   .Where(spec.Criteria)
                   .AsEnumerable();
        }

        public TEntity Add(TEntity entity)
        {
            SppdContext.Set<TEntity>().Add(entity);
            SppdContext.SaveChanges();

            return entity;
        }

        public void Update(TEntity entity)
        {
            SppdContext.Entry(entity).State = EntityState.Modified;
            SppdContext.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            SppdContext.Set<TEntity>().Remove(entity);
            SppdContext.SaveChanges();
        }

        public async Task<List<TEntity>> ListAsync(ISpecification<TEntity> spec)
        {
            // fetch a Queryable that includes all expression-based includes
            var queryableResultWithIncludes = spec.Includes
                                                  .Aggregate(SppdContext.Set<TEntity>().AsQueryable(),
                                                      (current, include) => current.Include(include));

            // modify the IQueryable to include any string-based include statements
            var secondaryResult = spec.IncludeStrings
                                      .Aggregate(queryableResultWithIncludes,
                                          (current, include) => current.Include(include));

            // return the result of the query using the specification's criteria expression
            return await secondaryResult
                         .Where(spec.Criteria)
                         .ToListAsync();
        }
    }
}