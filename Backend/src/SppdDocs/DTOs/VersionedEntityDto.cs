using System;

namespace SppdDocs.DTOs
{
	public class VersionedEntityDto : EntityDto
	{
		/// <summary>
		///     Identifies the version.
		/// </summary>
		public Guid VersionId { get; set; }

		/// <summary>
		///     Specifies what changes have been made for this version
		/// </summary>
		public string VersionComment { get; set; }

		public Guid CurrentVersionId { get; set; }

		/// <summary>
		///     Specifies if this instance is the current version.
		/// </summary>
		public bool IsCurrent { get; set; }
	}
}