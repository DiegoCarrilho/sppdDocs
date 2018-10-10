using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SppdDocs.Core.Domain.Entities;
using SppdDocs.Infrastructure.DbAccess.EntityMetadataProviders;

namespace SppdDocs.Infrastructure.DbAccess
{
	internal partial class SppdContext : DbContext
	{
		private readonly IEnumerable<IEntityMetadataProvider> _entityMetadataProviders;

		public SppdContext(DbContextOptions<SppdContext> options, IEnumerable<IEntityMetadataProvider> entityMetadataProviders)
			: base(options)
		{
			_entityMetadataProviders = entityMetadataProviders;
		}

		public override int SaveChanges()
		{
			PrepareSaveChanges();
			return base.SaveChanges();
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<Rarity>(ConfigureNamedEntity);
			builder.Entity<CardClass>(ConfigureNamedEntity);
			builder.Entity<CardEffect>(ConfigureNamedEntity);
			builder.Entity<CardStatusEffect>(ConfigureNamedEntity);

			builder.Entity<Card>(ConfigureCard);
		}

		private void PrepareSaveChanges()
		{
			ChangeTracker.DetectChanges();
			SetModifierMetadataOnChangedEntities();
		}

		private void SetModifierMetadataOnChangedEntities()
		{
			foreach (var entityMetadataProvider in _entityMetadataProviders.OrderByDescending(m => m.Priority))
			{
				entityMetadataProvider.SetModifierMetadataOnChangedEntities(ChangeTracker);
			}
		}
	}
}