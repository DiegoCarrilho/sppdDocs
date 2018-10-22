using SppdDocs.Core.Config;

namespace SppdDocs.Infrastructure.DbAccess.Config
{
	/// <summary>
	///     Defines configuration properties related to the database
	/// </summary>
	/// <seealso cref="SppdDocs.Core.Config.IConfig" />
	public class DatabaseConfig : IConfig
	{
		/// <summary>
		///     ConnectionString used for database connection.
		/// </summary>
		public string ConnectionString { get; set; }

		/// <summary>
		///     If set to true, the database will be recreated an seeded on every application start
		/// </summary>
		public bool ManageDatabase { get; set; }

		public string SqlUtcDateGetter { get; set; }

		public string SectionKey => "Database";
	}
}