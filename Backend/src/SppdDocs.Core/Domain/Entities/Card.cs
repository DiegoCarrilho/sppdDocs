using System;
using System.Collections.Generic;
using System.Linq;
using SppdDocs.Core.Domain.Objects;

namespace SppdDocs.Core.Domain.Entities
{
	public class Card : NamedEntity
	{
		private IEnumerable<CardUpgrade> _cardUpgrades;

		public LocalizedText DescriptionMarkdown { get; set; }

		public LocalizedText DescriptionOnCard { get; set; }

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

		public IEnumerable<CardUpgrade> CardUpgrades
		{
			get => _cardUpgrades ?? (_cardUpgrades = new List<CardUpgrade>());
			set => _cardUpgrades = value;
		}

		/// <summary>
		///     Gets all abilities configured for this <see cref="Card" /> sorted by <see cref="CardAttribute.SortIndex" />.
		/// </summary>
		public IEnumerable<CardAttribute> CardAttributes => CardUpgrades.SelectMany(lu => lu.CardAttributeUpgrades.Select(au => au.CardAttribute))
		                                                                .Distinct()
		                                                                .OrderBy(a => a.SortIndex);

		/// <summary>
		///     Gets all upgrade levels for this <see cref="Card" />.
		/// </summary>
		public IEnumerable<CardUpgradeLevelInfo> UpgradeLevels
		{
			get
			{
				if (CardUpgrades.Any())
				{
					for (var i = CardUpgrades.Min(lu => lu.UpgradeTo); i < CardUpgrades.Max(lu => lu.UpgradeTo) + 1; i++)
					{
						yield return GetCardLevel(i);
					}
				}
			}
		}

		/// <summary>
		///     Gets the card level for the specified level.
		/// </summary>
		public CardUpgradeLevelInfo GetCardLevel(int level)
		{
			return new CardUpgradeLevelInfo
			       {
				       InternalUpgradeLevel = level,
				       AttributeValues = CardUpgrades.Where(l => l.UpgradeFrom < level)
				                                     .SelectMany(l => l.CardAttributeUpgrades)
				                                     .GroupBy(v => v.CardAttribute)
				                                     .Select(g => new {CardAttribute = g.Key, LevelValue = g.Sum(v => v.Value)})
				                                     .OrderBy(o => o.CardAttribute.SortIndex)
				                                     .ToDictionary(o => o.CardAttribute, o => o.LevelValue),
				       AttributeUpgrades = CardUpgrades.SingleOrDefault(l => l.UpgradeFrom == level)?
				                                       .CardAttributeUpgrades
				                                       .ToDictionary(t => t.CardAttribute, t => t.Value)
			       };
		}
	}
}