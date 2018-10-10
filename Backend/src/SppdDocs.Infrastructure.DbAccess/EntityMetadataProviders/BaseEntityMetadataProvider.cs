using Microsoft.EntityFrameworkCore.ChangeTracking;
using SppdDocs.Core.Domain.Entities;

namespace SppdDocs.Infrastructure.DbAccess.EntityMetadataProviders
{
	internal class BaseEntityMetadataProvider : EntityMetadataProviderBase<BaseEntity>
	{
		public override int Priority => 100;

		public override void SetModifierMetadataProperties(EntityEntry<BaseEntity> entry)
		{
			// TODO: set properties (e.g. ApplicationUser) once implemented
		}
	}
}