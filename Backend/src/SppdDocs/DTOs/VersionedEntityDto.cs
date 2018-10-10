using System;

namespace SppdDocs.DTOs
{
	public class VersionedEntityDto : EntityDto
	{
		/// <summary>
		///     Specifies what changes have been made for this version
		/// </summary>
		public string VersionComment { get; set; }

		/// <summary>
		///     Gets or sets the identifier of the current version.
		/// </summary>
		public Guid CurrentId { get; set; }

		/// <summary>
		///     Specifies if this is the current version.
		/// </summary>
		public bool IsCurrent => Id == CurrentId;
	}
}