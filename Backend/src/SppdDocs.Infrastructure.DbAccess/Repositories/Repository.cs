using System;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using SppdDocs.Core.Domain.Entities;
using SppdDocs.Core.Repositories;

namespace SppdDocs.Infrastructure.DbAccess.Repositories
{
    internal class Repository<TEntity> : IRepository<TEntity>
        where TEntity : BaseEntity
    {
        protected DbSet<TEntity> Set => SppdContext.Set<TEntity>();

        protected SppdContext SppdContext { get; }

        public Repository(SppdContext sppdContext)
        {
            SppdContext = sppdContext;
        }

        public virtual async Task<TEntity> GetAsync(Guid id)
        {
            return await SppdContext.Set<TEntity>().FindAsync(id);
        }

        public virtual TEntity Add(TEntity entity)
        {
            SppdContext.Set<TEntity>().Add(entity);
            SppdContext.SaveChanges();

            return entity;
        }

        public virtual TEntity Update(TEntity entity)
        {
            SppdContext.Entry(entity).State = EntityState.Modified;
            SppdContext.SaveChanges();

            return entity;
        }

        public virtual void Delete(TEntity entity)
        {
            SppdContext.Set<TEntity>().Remove(entity);
            SppdContext.SaveChanges();
        }
    }
}