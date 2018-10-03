using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SppdDocs.Core.Domain.Entities;

namespace SppdDocs.Infrastructure.DbAccess.EntityMetadataProviders
{
	public class BaseEntityMetadataProvider : IEntityMetadataProvider
	{
		public void SetModifierMetadataOnChangedEntities(ChangeTracker changeTracker)
		{
			var entriesToSetModifier = changeTracker.Entries<BaseEntity>().Where(e => HasToSetModifierMetadata(e.State)).ToList();

			if (entriesToSetModifier.Any())
			{
				var saveDate = DateTime.UtcNow;

				foreach (var entryToSetModifier in entriesToSetModifier)
				{
					SetModifierMetadataProperties(entryToSetModifier, saveDate);
				}
			}
		}

		private static bool HasToSetModifierMetadata(EntityState state)
		{
			return state == EntityState.Added || state == EntityState.Modified;
		}

		private static void SetModifierMetadataProperties(EntityEntry<BaseEntity> entry, DateTime saveDate)
		{
			if (entry.State == EntityState.Added)
			{
				entry.Property(e => e.CreatedOnUtc).CurrentValue = saveDate;
			}
			else
			{
				entry.Property(e => e.CreatedOnUtc).IsModified = false;
			}
		}
	}
}