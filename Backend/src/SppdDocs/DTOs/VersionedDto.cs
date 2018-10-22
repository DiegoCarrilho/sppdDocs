using System;

namespace SppdDocs.DTOs
{
	/// <summary>
	///     Contains version information
	/// </summary>
	/// <seealso cref="SppdDocs.DTOs.EntityDto" />
	public class VersionedDto : EntityDto
	{
		/// <summary>
		///     The comment for the version.
		/// </summary>
		public string VersionComment { get; set; }

		/// <summary>
		///     The current identifier.
		/// </summary>
		public Guid CurrentId { get; set; }

		/// <summary>
		///     Indicates whether this is the current version.
		/// </summary>
		public bool IsCurrent { get; set; }
	}
}