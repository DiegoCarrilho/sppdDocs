namespace SppdDocs.Core.Config
{
	/// <summary>
	///     Defines a custom object that can be populated with configuration values of the main config structure.
	/// </summary>
	public interface IConfig
	{
		/// <summary>
		///     Gets the section key which specifies the section in the configuration file.
		/// </summary>
		string SectionKey { get; }
	}
}