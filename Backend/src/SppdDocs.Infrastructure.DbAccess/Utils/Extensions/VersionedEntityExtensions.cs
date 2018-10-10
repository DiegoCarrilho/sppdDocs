using SppdDocs.Core.Domain.Entities;

namespace SppdDocs.Infrastructure.DbAccess.Utils.Extensions
{
	public static class VersionedEntityExtensions
	{
		/// <summary>
		///     Sets the default properties when seeding <see cref="VersionedEntity" />.
		/// </summary>
		public static TEntity SetDefaultSeederProperties<TEntity>(this TEntity versionedEntity)
			where TEntity : VersionedEntity
		{
			versionedEntity.VersionComment = "Initial creation by seeder";

			return versionedEntity;
		}
	}
}