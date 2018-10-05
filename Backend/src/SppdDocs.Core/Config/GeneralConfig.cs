namespace SppdDocs.Core.Config
{
	public class GeneralConfig : IConfig
	{
		/// <summary>
		///     If set true, swagger UI is available for testing
		/// </summary>
		public bool EnableSwaggerUI { get; set; }

		public string SectionKey => "General";
	}
}