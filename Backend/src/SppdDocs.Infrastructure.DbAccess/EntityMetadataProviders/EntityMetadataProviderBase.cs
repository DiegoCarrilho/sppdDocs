using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SppdDocs.Core.Domain.Entities;

namespace SppdDocs.Infrastructure.DbAccess.EntityMetadataProviders
{
    internal abstract class EntityMetadataProviderBase<TEntity> : IEntityMetadataProvider
        where TEntity : BaseEntity
    {
        public abstract int Priority { get; }

        public void SetModifierMetadataOnChangedEntities(ChangeTracker changeTracker)
        {
            var entriesToSetModifier = changeTracker.Entries<TEntity>().Where(e => HasToSetModifierMetadata(e.State)).ToList();

            if (entriesToSetModifier.Any())
            {
                foreach (var entryToSetModifier in entriesToSetModifier)
                {
                    SetModifierMetadataProperties(entryToSetModifier);
                }
            }
        }

        protected virtual bool HasToSetModifierMetadata(EntityState state)
        {
            return state == EntityState.Added || state == EntityState.Modified;
        }

        public abstract void SetModifierMetadataProperties(EntityEntry<TEntity> entry);
    }
}