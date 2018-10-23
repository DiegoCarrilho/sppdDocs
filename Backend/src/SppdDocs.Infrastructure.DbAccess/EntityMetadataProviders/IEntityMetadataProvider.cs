using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace SppdDocs.Infrastructure.DbAccess.EntityMetadataProviders
{
    public interface IEntityMetadataProvider
    {
        /// <summary>
        ///     Gets the priority. <see cref="IEntityMetadataProvider" /> with a higher priority will be called first
        /// </summary>
        int Priority { get; }

        /// <summary>
        ///     Sets the modifier metadata on changed entities.
        /// </summary>
        /// <param name="changeTracker">The change tracker.</param>
        void SetModifierMetadataOnChangedEntities(ChangeTracker changeTracker);
    }
}