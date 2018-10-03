using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SppdDocs.Core.Domain.Entities;
using SppdDocs.Infrastructure.DbAccess.EntityMetadataProviders;

namespace SppdDocs.Infrastructure.DbAccess
{
	public class SppdContext : DbContext
	{
		private readonly IEnumerable<IEntityMetadataProvider> _entityMetadataProviders;

		public SppdContext(DbContextOptions<SppdContext> options, IEnumerable<IEntityMetadataProvider> entityMetadataProviders) : base(options)
		{
			_entityMetadataProviders = entityMetadataProviders;
		}

		public DbSet<Card> Cards { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<Card>(ConfigureCard);
		}

		public override int SaveChanges()
		{
			PrepareSaveChanges();
			return base.SaveChanges();
		}

		private void ConfigureCard(EntityTypeBuilder<Card> builder)
		{
			// TODO: implement
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