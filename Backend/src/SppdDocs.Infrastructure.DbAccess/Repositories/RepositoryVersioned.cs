using System;
using System.Linq;
using SppdDocs.Core.Domain.Entities;
using SppdDocs.Core.Domain.Repositories;

namespace SppdDocs.Infrastructure.DbAccess.Repositories
{
	public class RepositoryVersioned<TEntity> : Repository<TEntity>, IRepositoryVersioned<TEntity>
		where TEntity : VersionedEntity
	{
		public RepositoryVersioned(SppdContext sppdContext) : base(sppdContext)
		{
		}

		public IQueryable<TEntity> GetAllCurrent()
		{
			return Set.Where(entity => entity.IsCurrent);
		}

		public IQueryable<TEntity> GetHistory(Guid entityId)
		{
			return Set.Where(entity => entity.EntityId == entityId);
		}

		public TEntity GetCurrentByEntityId(Guid entityId)
		{
			return GetAllCurrent().SingleOrDefault(entity => entity.EntityId == entityId);
		}

		public TEntity Get(Guid entityId, Guid versionId)
		{
			return Set.SingleOrDefault(entity => entity.EntityId == entityId && entity.VersionId == versionId);
		}
	}
}