using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using SppdDocs.Core.Domain.Entities;

namespace SppdDocs.Core.Repositories
{
    public interface IVersionedEntityRepository<TEntity> : IRepository<TEntity>
        where TEntity : VersionedEntity
    {
        /// <summary>
        ///     Gets all current entities.
        /// </summary>
        Task<IEnumerable<TEntity>> GetAllCurrentAsync();

        /// <summary>
        ///     Gets the history for the given entity.
        /// </summary>
        /// <param name="entityId">The entity identifier.</param>
        Task<IEnumerable<TEntity>> GetHistoryAsync(Guid entityId);

        /// <summary>
        ///     Gets the entity for the given IDs.
        /// </summary>
        /// <param name="entityId">The entity identifier.</param>
        /// <param name="versionId">The version identifier.</param>
        /// <returns></returns>
        Task<TEntity> GetAsync(Guid entityId, Guid versionId);

        /// <summary>
        ///     Gets the current entity.
        /// </summary>
        Task<TEntity> GetCurrentAsync(Guid entityId);
    }
}