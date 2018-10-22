namespace SppdDocs.DTOs
{
	/// <summary>
	///     A <see cref="VersionedDto" /> having a name.
	/// </summary>
	/// <seealso cref="SppdDocs.DTOs.VersionedDto" />
	public class NamedDto : VersionedDto
	{
		/// <summary>
		///     The name.
		/// </summary>
		public string Name { get; set; }
	}
}