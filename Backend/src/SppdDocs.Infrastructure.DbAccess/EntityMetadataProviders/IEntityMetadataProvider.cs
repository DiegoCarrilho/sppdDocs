using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace SppdDocs.Infrastructure.DbAccess.EntityMetadataProviders
{
	public interface IEntityMetadataProvider
	{
		void SetModifierMetadataOnChangedEntities(ChangeTracker changeTracker);
	}
}