using System;
using System.Collections.Generic;
using SppdDocs.Core.Domain.Entities;
using SppdDocs.Core.Domain.Objects;
using SppdDocs.Core.Repositories;
using SppdDocs.Infrastructure.DbAccess.Utils.Extensions;

namespace SppdDocs.Infrastructure.DbAccess.Seeders
{
    internal class CardDbSeeder : IDbSeeder
    {
        private readonly IRepository<Card> _cardRepository;

        public CardDbSeeder(IRepository<Card> cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public int Priority => SeederConstants.DbSeederPriority.CARD_DATA;

        public void Seed()
        {
            _cardRepository.Add(new Card
                                {
                                    Id = new Guid(SeederConstants.Card.STAN_OF_MANY_MOONS_ID),
                                    Name = new LocalizedText("Stan of Many Moons"),
                                    DescriptionMarkdown = new LocalizedText(
                                        "Stan of many Moons is a 4-cost fighter from the Adventure theme who is available at rank 5 that deals damage to all enemy units on the battlefield with his effect."),
                                    DescriptionOnCard = new LocalizedText("Charged: Casts a fiery blast at all enemies."),
                                    EnergyCost = 4,
                                    Range = 0.6,
                                    UnlockedAtRank = 5,
                                    ThemeId = new Guid(SeederConstants.CardTheme.ADVENTURE_ID),
                                    RarityId = new Guid(SeederConstants.Rarity.LEGENDARY_ID),
                                    ClassId = new Guid(SeederConstants.CardClass.FIGHTER_ID),
                                    EffectId = new Guid(SeederConstants.CardEffect.CHARGED_ID),
                                    CastAreaId = new Guid(SeederConstants.CardCastArea.OWN_SIDE_ID),
                                    MaxVelocity = 0.675,
                                    TimeToReachMaxVelocitySec = 0.1,
                                    AgroRangeMultiplier = 3.33,
                                    AttackRange = 0.6,
                                    PreAttackDelay = 0,
                                    TimeInBetweenAttacksSec = 0.5,
                                    CardUpgrades = new List<CardUpgrade>
                                                   {
                                                       new CardUpgrade
                                                       {
                                                           UpgradeFrom = 0,
                                                           UpgradeTo = 1,
                                                           CardAttributeUpgrades = new List<CardUpgradeAttributeValue>
                                                                                   {
                                                                                       new CardUpgradeAttributeValue
                                                                                       {
                                                                                           CardAttributeId = new Guid(SeederConstants.CardAttribute.CARD_UPGRADES_ID),
                                                                                           Value = 5
                                                                                       },
                                                                                       new CardUpgradeAttributeValue
                                                                                       {
                                                                                           CardAttributeId = new Guid(SeederConstants.CardAttribute.HEALTH_ID),
                                                                                           Value = 272
                                                                                       },
                                                                                       new CardUpgradeAttributeValue
                                                                                       {
                                                                                           CardAttributeId = new Guid(SeederConstants.CardAttribute.ATTACK_ID),
                                                                                           Value = 60
                                                                                       },
                                                                                       new CardUpgradeAttributeValue
                                                                                       {
                                                                                           CardAttributeId = new Guid(SeederConstants.CardAttribute.DAMAGE_ALL_ID),
                                                                                           Value = 200
                                                                                       }
                                                                                   }
                                                       },
                                                       new CardUpgrade
                                                       {
                                                           UpgradeFrom = 1,
                                                           UpgradeTo = 2,
                                                           CardAttributeUpgrades = new List<CardUpgradeAttributeValue>
                                                                                   {
                                                                                       new CardUpgradeAttributeValue
                                                                                       {
                                                                                           CardAttributeId = new Guid(SeederConstants.CardAttribute.HEALTH_ID),
                                                                                           Value = 9
                                                                                       }
                                                                                   }
                                                       },
                                                       new CardUpgrade
                                                       {
                                                           UpgradeFrom = 2,
                                                           UpgradeTo = 3,
                                                           CardAttributeUpgrades = new List<CardUpgradeAttributeValue>
                                                                                   {
                                                                                       new CardUpgradeAttributeValue
                                                                                       {
                                                                                           CardAttributeId = new Guid(SeederConstants.CardAttribute.ATTACK_ID),
                                                                                           Value = 4
                                                                                       }
                                                                                   }
                                                       },
                                                       new CardUpgrade
                                                       {
                                                           UpgradeFrom = 3,
                                                           UpgradeTo = 4,
                                                           CardAttributeUpgrades = new List<CardUpgradeAttributeValue>
                                                                                   {
                                                                                       new CardUpgradeAttributeValue
                                                                                       {
                                                                                           CardAttributeId = new Guid(SeederConstants.CardAttribute.HEALTH_ID),
                                                                                           Value = 11
                                                                                       }
                                                                                   }
                                                       },
                                                       new CardUpgrade
                                                       {
                                                           UpgradeFrom = 4,
                                                           UpgradeTo = 5,
                                                           CardAttributeUpgrades = new List<CardUpgradeAttributeValue>
                                                                                   {
                                                                                       new CardUpgradeAttributeValue
                                                                                       {
                                                                                           CardAttributeId = new Guid(SeederConstants.CardAttribute.DAMAGE_ALL_ID),
                                                                                           Value = 36
                                                                                       }
                                                                                   }
                                                       },
                                                       new CardUpgrade
                                                       {
                                                           UpgradeFrom = 5,
                                                           UpgradeTo = 6,
                                                           CardAttributeUpgrades = new List<CardUpgradeAttributeValue>
                                                                                   {
                                                                                       new CardUpgradeAttributeValue
                                                                                       {
                                                                                           CardAttributeId = new Guid(SeederConstants.CardAttribute.CARD_UPGRADES_ID),
                                                                                           Value = 10
                                                                                       },
                                                                                       new CardUpgradeAttributeValue
                                                                                       {
                                                                                           CardAttributeId = new Guid(SeederConstants.CardAttribute.ATTACK_ID),
                                                                                           Value = 12
                                                                                       },
                                                                                       new CardUpgradeAttributeValue
                                                                                       {
                                                                                           CardAttributeId = new Guid(SeederConstants.CardAttribute.HEALTH_ID),
                                                                                           Value = 54
                                                                                       }
                                                                                   }
                                                       }
                                                   }
                                }.SetDefaultSeederProperties());
            _cardRepository.Add(new Card
                                {
                                    Id = new Guid(SeederConstants.Card.POISON_ID),
                                    Name = new LocalizedText("Poison"),
                                    DescriptionMarkdown = new LocalizedText(
                                        "Poison is a 3 cost spell from the Sci-Fi theme who is available at rank 5 that poisons all enemies in a target area."),
                                    DescriptionOnCard = new LocalizedText("Poisons enemies in target area."),
                                    EnergyCost = 3,
                                    UnlockedAtRank = 5,
                                    ThemeId = new Guid(SeederConstants.CardTheme.SCIFI_ID),
                                    RarityId = new Guid(SeederConstants.Rarity.COMMON_ID),
                                    ClassId = new Guid(SeederConstants.CardClass.SPELL_ID),
                                    StatusEffectId = new Guid(SeederConstants.CardStatusEffect.POISON_ID),
                                    CastAreaId = new Guid(SeederConstants.CardCastArea.ANYWHERE_ID),
                                    MaxVelocity = null,
                                    TimeToReachMaxVelocitySec = null,
                                    AgroRangeMultiplier = null,
                                    AttackRange = null,
                                    PreAttackDelay = null,
                                    TimeInBetweenAttacksSec = null
                                }.SetDefaultSeederProperties());
        }
    }
}