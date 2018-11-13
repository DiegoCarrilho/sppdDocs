using Microsoft.EntityFrameworkCore;
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
        public void ConfigureVersionedEntity<TEntity>(EntityTypeBuilder<TEntity> builder)
            where TEntity : VersionedEntity
        {
            ConfigureBaseEntity(builder);

            builder.HasIndex(e => e.CurrentId);

            builder.Property(e => e.CurrentId)
                   .IsRequired();

            builder.Ignore(e => e.IsCurrent);
        }

        private void ConfigureBaseEntity<TEntity>(EntityTypeBuilder<TEntity> builder)
            where TEntity : BaseEntity
        {
            builder.Property(e => e.CreatedOnUtc)
                   .HasDefaultValueSql(_databaseConfig.Value.SqlUtcDateGetter)
                   .ValueGeneratedOnAdd()
                   .IsRequired();
            builder.Property(e => e.UpdatedOnUtc)
                   .HasDefaultValueSql(_databaseConfig.Value.SqlUtcDateGetter)
                   .ValueGeneratedOnAddOrUpdate()
                   .IsConcurrencyToken()
                   .IsRequired();
        }

        private void ConfigureCardLevelUpgrade(EntityTypeBuilder<CardUpgrade> builder)
        {
            ConfigureBaseEntity(builder);

            builder.HasMany(c => c.CardAttributeUpgrades)
                   .WithOne(c => c.CardUpgrade);
        }

        private void ConfigureNamedEntity<TEntity>(EntityTypeBuilder<TEntity> builder)
            where TEntity : NamedEntity
        {
            ConfigureVersionedEntity(builder);

            builder.OwnsOne(e => e.Name)
                   .Property(name => name.En)
                   .IsRequired();

            builder.HasIndex(e => e.FriendlyName)
                   .IsUnique();
            builder.Property(e => e.FriendlyName)
                   .IsRequired();
        }

        private void ConfigureCard<TEntity>(EntityTypeBuilder<TEntity> builder)
            where TEntity : Card
        {
            ConfigureNamedEntity(builder);

            builder.OwnsOne(card => card.DescriptionMarkdown)
                   .Property(description => description.En)
                   .IsRequired();

            builder.OwnsOne(card => card.DescriptionOnCard)
                   .Property(description => description.En)
                   .IsRequired();
        }
    }
}