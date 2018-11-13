using System.Collections.Generic;
using System.Threading.Tasks;
using SppdDocs.Core.Domain.Entities;

namespace SppdDocs.Core.Repositories
{
    public interface INamedEntityRepository<TEntity> : IVersionedEntityRepository<TEntity>
        where TEntity : NamedEntity
    {
        /// <summary>
        ///     Gets the friendly names of all <see cref="NamedEntity" /> which are current.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<string>> GetCurrentFriendlyNamesAsync();
    }
}