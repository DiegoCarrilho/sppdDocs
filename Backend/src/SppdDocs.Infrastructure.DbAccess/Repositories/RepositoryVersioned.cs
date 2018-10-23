using System;
using System.Linq;
using SppdDocs.Core.Domain.Entities;
using SppdDocs.Core.Repositories;

namespace SppdDocs.Infrastructure.DbAccess.Repositories
{
    internal class RepositoryVersioned<TEntity> : Repository<TEntity>, IRepositoryVersioned<TEntity>
        where TEntity : VersionedEntity
    {
        public RepositoryVersioned(SppdContext sppdContext)
            : base(sppdContext)
        {
        }

        public IQueryable<TEntity> GetAllCurrent()
        {
            return Set.Where(entity => entity.IsCurrent);
        }

        public IQueryable<TEntity> GetHistory(Guid entityId)
        {
            return Set.Where(entity => entity.CurrentId == entityId);
        }

        public TEntity GetCurrent(Guid entityId)
        {
            return GetAllCurrent().SingleOrDefault(entity => entity.CurrentId == entityId);
        }

        public TEntity Get(Guid entityId, Guid versionId)
        {
            return Set.SingleOrDefault(entity => entity.CurrentId == entityId && entity.Id == versionId);
        }
    }
}