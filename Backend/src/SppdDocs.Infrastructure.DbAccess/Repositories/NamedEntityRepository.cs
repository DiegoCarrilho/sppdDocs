using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using SppdDocs.Core.Domain.Entities;
using SppdDocs.Core.Repositories;

namespace SppdDocs.Infrastructure.DbAccess.Repositories
{
    internal class NamedEntityRepository<TEntity> : VersionedEntityRepository<TEntity>, INamedEntityRepository<TEntity>
        where TEntity : NamedEntity
    {
        public NamedEntityRepository(SppdContext sppdContext)
            : base(sppdContext)
        {
        }

        public async Task<IEnumerable<string>> GetCurrentFriendlyNamesAsync()
        {
            return await GetAllCurrent()
                         .Select(e => e.FriendlyName)
                         .ToListAsync();
        }

        protected async Task<TEntity> GetAsync(string friendlyName, Func<IQueryable<TEntity>, IQueryable<TEntity>> includes = null)
        {
            return await (includes == null
                    ? GetAllCurrent()
                    : includes(GetAllCurrent()))
                .SingleOrDefaultAsync(e => EF.Functions.Like(e.FriendlyName, friendlyName));
        }
    }
}