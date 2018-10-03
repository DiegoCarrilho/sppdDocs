using System;
using System.Linq;
using SppdDocs.Core.Domain.Entities;

namespace SppdDocs.Core.Domain.Repositories
{
	public interface IRepositoryVersioned<TEntity> : IRepository<TEntity>
		where TEntity : VersionedEntity
	{
		IQueryable<TEntity> GetAllCurrent();

		IQueryable<TEntity> GetHistory(Guid entityId);

		TEntity Get(Guid entityId, Guid versionId);

		TEntity GetCurrentByEntityId(Guid entityId);
	}
}