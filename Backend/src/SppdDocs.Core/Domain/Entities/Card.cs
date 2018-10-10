using System;
using SppdDocs.Core.Domain.Objects;

namespace SppdDocs.Core.Domain.Entities
{
	public class Card : NamedEntity
	{
		public LocalizedText Description { get; set; }

		public int EnergyCost { get; set; }

		public double? Range { get; set; }

		public int UnlockedAtRank { get; set; }

		public Guid ThemeId { get; set; }

		public CardTheme Theme { get; set; }

		public Guid RarityId { get; set; }

		public Rarity Rarity { get; set; }

		public Guid ClassId { get; set; }

		public CardClass Class { get; set; }

		public Guid? EffectId { get; set; }

		public CardEffect Effect { get; set; }

		public Guid? StatusEffectId { get; set; }

		public CardStatusEffect StatusEffect { get; set; }
	}
}