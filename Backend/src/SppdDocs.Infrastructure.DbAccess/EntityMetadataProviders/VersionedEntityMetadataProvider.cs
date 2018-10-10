using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SppdDocs.Core.Domain.Entities;

namespace SppdDocs.Infrastructure.DbAccess.EntityMetadataProviders
{
	internal class VersionedEntityMetadataProvider : EntityMetadataProviderBase<VersionedEntity>
	{
		public override int Priority => 200;

		public override void SetModifierMetadataProperties(EntityEntry<VersionedEntity> entry)
		{
			entry.Property(e => e.CurrentId).CurrentValue = entry.Property(e => e.Id).CurrentValue;

			switch (entry.State)
			{
				case EntityState.Modified:
					entry.Property(e => e.CreatedOnUtc).CurrentValue = DateTime.UtcNow;

					// TODO: create a copy of the VersionedEntity
					break;
			}
		}
	}
}