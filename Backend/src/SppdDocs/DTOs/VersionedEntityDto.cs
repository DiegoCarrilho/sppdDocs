﻿using System;

namespace SppdDocs.DTOs
{
	public class VersionedEntityDto : EntityDto
	{

		/// <summary>
		///     Identifies the entity instance. This property holds the same value for all its versions
		/// </summary>
		public Guid EntityId { get; set; }

		/// <summary>
		///     Identifies the version.
		/// </summary>
		public Guid VersionId { get; set; }

		/// <summary>
		///     Specifies what changes have been made for this version
		/// </summary>
		public string VersionComment { get; set; }

		/// <summary>
		///     Specifies if this instance is the current version.
		///     Note that for a given <see cref="EntityId" /> exactly 1 instance has this value set to <c>true</c>
		/// </summary>
		public bool IsCurrent { get; set; }
	}
}