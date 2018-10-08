using System;

namespace SppdDocs.Core.Domain.Entities
{
	public class Card : NamedEntity
	{
		public string Description { get; set; }

		public Guid RarityId { get; set; }

		public Rarity Rarity { get; set; }

		public Guid ClassId { get; set; }

		public CardClass Class { get; set; }
	}
}