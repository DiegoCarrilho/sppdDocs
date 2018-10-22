using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SppdDocs.Core.Config;
using SppdDocs.Core.Domain.Entities;
using SppdDocs.Infrastructure.DbAccess.Config;
using SppdDocs.Infrastructure.DbAccess.EntityMetadataProviders;

namespace SppdDocs.Infrastructure.DbAccess
{
	internal partial class SppdContext : DbContext
	{
		private readonly IEnumerable<IEntityMetadataProvider> _entityMetadataProviders;
		private readonly Lazy<DatabaseConfig> _databaseConfig;

		public SppdContext(DbContextOptions<SppdContext> options, IEnumerable<IEntityMetadataProvider> entityMetadataProviders, IConfigProvider<DatabaseConfig> databaseConfigProvider)
			: base(options)
		{
			_entityMetadataProviders = entityMetadataProviders;
			_databaseConfig = new Lazy<DatabaseConfig>(() => databaseConfigProvider.Config);
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
			builder.Entity<CardTheme>(ConfigureNamedEntity);

			builder.Entity<CardAttribute>(ConfigureNamedEntity);
			builder.Entity<CardUpgrade>(ConfigureCardLevelUpgrade);
			builder.Entity<CardUpgradeCardAttributeValue>(ConfigureBaseEntity);

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