using System;

namespace SppdDocs.DTOs
{
	public abstract class EntityDto
	{
		public Guid Id { get; set; }

		public DateTime CreatedOnUtc { get; set; }

		public DateTime UpdatedOnUtc { get; set; }
	}
}