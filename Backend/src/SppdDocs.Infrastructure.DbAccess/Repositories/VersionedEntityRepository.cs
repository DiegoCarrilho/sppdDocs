using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SppdDocs.Core.Domain.Entities;
using SppdDocs.Core.Repositories;

namespace SppdDocs.Infrastructure.DbAccess.Repositories
{
    internal class VersionedEntityRepository<TEntity> : Repository<TEntity>, IVersionedEntityRepository<TEntity>
        where TEntity : VersionedEntity
    {
        public VersionedEntityRepository(SppdContext sppdContext)
            : base(sppdContext)
        {
        }

        public async Task<IEnumerable<TEntity>> GetAllCurrentAsync()
        {
            return await GetAllCurrent().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetHistoryAsync(Guid entityId)
        {
            return await Set.Where(entity => entity.CurrentId == entityId)
                            .OrderByDescending(e => e.CreatedOnUtc)
                            .ToListAsync();
        }

        public async Task<TEntity> GetAsync(Guid entityId, Guid versionId)
        {
            return await Set.SingleOrDefaultAsync(entity => entity.CurrentId == entityId && entity.Id == versionId);
        }

        public async Task<TEntity> GetCurrentAsync(Guid entityId)
        {
            return await GetAsync(entityId);
        }

        protected IQueryable<TEntity> GetAllCurrent()
        {
            return Set.Where(entity => entity.IsCurrent);
        }
    }
}