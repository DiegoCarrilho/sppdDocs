using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SppdDocs.Core.Domain.Entities;
using SppdDocs.Infrastructure.DbAccess.EntityMetadataProviders;

namespace SppdDocs.Infrastructure.DbAccess
{
	public class SppdContext : DbContext
	{
		private readonly IEnumerable<IEntityMetadataProvider> _entityMetadataProviders;

		public SppdContext(DbContextOptions<SppdContext> options, IEnumerable<IEntityMetadataProvider> entityMetadataProviders)
			: base(options)
		{
			_entityMetadataProviders = entityMetadataProviders;
		}

		public DbSet<Card> Cards { get; set; }
		public DbSet<Rarity> Rarity { get; set; }
		public DbSet<CardClass> CardClass { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<Rarity>();
			builder.Entity<CardClass>();

			builder.Entity<Card>();
		}

		public override int SaveChanges()
		{
			PrepareSaveChanges();
			return base.SaveChanges();
		}

		private void PrepareSaveChanges()
		{
			ChangeTracker.DetectChanges();
			SetModifierMetadataOnChangedEntities();
		}

		private void SetModifierMetadataOnChangedEntities()
		{
			foreach (var entityMetadataProvider in _entityMetadataProviders)
			{
				entityMetadataProvider.SetModifierMetadataOnChangedEntities(ChangeTracker);
			}
		}
	}
}