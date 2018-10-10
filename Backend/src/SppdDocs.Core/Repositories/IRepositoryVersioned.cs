using System;
using System.Linq;
using SppdDocs.Core.Domain.Entities;

namespace SppdDocs.Core.Repositories
{
	public interface IRepositoryVersioned<TEntity> : IRepository<TEntity>
		where TEntity : VersionedEntity
	{
		/// <summary>
		///     Gets all current entities.
		/// </summary>
		IQueryable<TEntity> GetAllCurrent();

		/// <summary>
		///     Gets the history for the given entity.
		/// </summary>
		/// <param name="entityId">The entity identifier.</param>
		IQueryable<TEntity> GetHistory(Guid entityId);

		/// <summary>
		///     Gets the entity for the given IDs.
		/// </summary>
		/// <param name="entityId">The entity identifier.</param>
		/// <param name="versionId">The version identifier.</param>
		/// <returns></returns>
		TEntity Get(Guid entityId, Guid versionId);

		/// <summary>
		///     Gets the current entity.
		/// </summary>
		TEntity GetCurrent(Guid entityId);
	}
}