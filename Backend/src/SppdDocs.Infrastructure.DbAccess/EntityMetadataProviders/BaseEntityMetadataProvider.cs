using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SppdDocs.Core.Domain.Entities;

namespace SppdDocs.Infrastructure.DbAccess.EntityMetadataProviders
{
	internal class BaseEntityMetadataProvider : EntityMetadataProviderBase<BaseEntity>
	{
		public override int Priority => 100;

		public override void SetModifierMetadataProperties(EntityEntry<BaseEntity> entry)
		{
			if (entry.State == EntityState.Added)
			{
				entry.Property(e => e.CreatedOnUtc).CurrentValue = DateTime.UtcNow;
			}
			else
			{
				entry.Property(e => e.CreatedOnUtc).IsModified = false;
			}
		}
	}
}