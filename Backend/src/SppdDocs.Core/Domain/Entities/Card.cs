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

        public Guid CastAreaId { get; set; }

        public CardCastArea CastArea { get; set; }

        public double? MaxVelocity { get; set; }

        public double? TimeToReachMaxVelocitySec { get; set; }

        public double? AgroRangeMultiplier { get; set; }

        public double? AttackRange { get; set; }

        public double? PreAttackDelay { get; set; }

        public double? TimeInBetweenAttacksSec { get; set; }

        public IEnumerable<CardUpgrade> CardUpgrades
        {
            get => _cardUpgrades ?? (_cardUpgrades = new List<CardUpgrade>());
            set => _cardUpgrades = value;
        }

        /// <summary>
        ///     Gets all card attributes configured for this <see cref="Card" /> sorted by <see cref="CardAttribute.SortIndex" />.
        /// </summary>
        public IEnumerable<CardAttribute> GetCardAttributes()
        {
            return CardUpgrades.SelectMany(lu => lu.CardAttributeUpgrades.Select(au => au.CardAttribute))
                               .Distinct()
                               .OrderBy(a => a.SortIndex);
        }

        /// <summary>
        ///     Gets the card level for the specified internal card upgrade level.
        /// </summary>
        public CardUpgradeLevelInfo GetCardUpgradeLevel(int cardUpgradeLevelInternal)
        {
            return new CardUpgradeLevelInfo
                   {
                       InternalUpgradeLevel = cardUpgradeLevelInternal,
                       AttributeValues = CardUpgrades.Where(l => l.UpgradeFrom < cardUpgradeLevelInternal)
                                                     .SelectMany(l => l.CardAttributeUpgrades)
                                                     .GroupBy(v => v.CardAttribute)
                                                     .Select(g => new {CardAttribute = g.Key, LevelValue = g.Sum(v => v.Value)})
                                                     .OrderBy(o => o.CardAttribute.SortIndex)
                                                     .ToDictionary(o => o.CardAttribute, o => o.LevelValue),
                       AttributeUpgrades = CardUpgrades.SingleOrDefault(l => l.UpgradeFrom == cardUpgradeLevelInternal)?
                                                       .CardAttributeUpgrades
                                                       .ToDictionary(t => t.CardAttribute, t => t.Value)
                   };
        }

        /// <summary>
        ///     Gets all upgrade levels for this <see cref="Card" />.
        /// </summary>
        public IEnumerable<CardUpgradeLevelInfo> GetUpgradeLevels()
        {
            if (CardUpgrades.Any())
            {
                for (var cardUpgradeLevelInternal = CardUpgrades.Min(lu => lu.UpgradeTo);
                    cardUpgradeLevelInternal < CardUpgrades.Max(lu => lu.UpgradeTo) + 1;
                    cardUpgradeLevelInternal++)
                {
                    yield return GetCardUpgradeLevel(cardUpgradeLevelInternal);
                }
            }
        }
    }
}