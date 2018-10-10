using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SppdDocs.Core.Domain.Entities;

namespace SppdDocs.Infrastructure.DbAccess
{
	/// <inheritdoc />
	/// <summary>
	///     Partial class containing the entity configurations
	/// </summary>
	/// <seealso cref="T:Microsoft.EntityFrameworkCore.DbContext" />
	internal partial class SppdContext
	{
		private static void ConfigureBaseEntity<TEntity>(EntityTypeBuilder<TEntity> builder)
			where TEntity : BaseEntity
		{
			builder.Property(e => e.Id)
			       .IsConcurrencyToken();
			builder.Property(e => e.CreatedOnUtc)
			       .IsRequired();
		}

		public static void ConfigureVersionedEntity<TEntity>(EntityTypeBuilder<TEntity> builder)
			where TEntity : VersionedEntity
		{
			ConfigureBaseEntity(builder);

			builder.HasIndex(e => e.CurrentId);

			builder.Property(e => e.CurrentId)
			       .IsRequired();

			builder.Ignore(e => e.IsCurrent);
		}

		private static void ConfigureNamedEntity<TEntity>(EntityTypeBuilder<TEntity> builder)
			where TEntity : NamedEntity
		{
			ConfigureVersionedEntity(builder);

			builder.OwnsOne(e => e.Name)
			       .Property(name => name.En)
			       .IsRequired();
		}

		private static void ConfigureCard<TEntity>(EntityTypeBuilder<TEntity> builder)
			where TEntity : Card
		{
			ConfigureNamedEntity(builder);

			builder.OwnsOne(card => card.Description)
			       .Property(description => description.En)
			       .IsRequired();
		}
	}
}