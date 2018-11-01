using System.Collections.Generic;
using System.Linq;
using SppdDocs.Core.Domain.Entities;
using SppdDocs.Core.Domain.Objects;
using Xunit;

// ReSharper disable ParameterOnlyUsedForPreconditionCheck.Local
// ReSharper disable CompareOfFloatsByEqualityOperator
namespace SppdDocs.Core.Tests.Unit
{
    public class CardTests
    {
        /// <summary>
        ///     The constructor is being called before every test execution.
        /// </summary>
        public CardTests()
        {
            SetupPrivateFields();
        }

        private Card _card;
        private List<CardAttribute> _cardAttributes;
        private List<CardUpgradeCardAttributeValue> _cardUpgradeCardAttributeValues;
        private List<CardUpgrade> _cardUpgrades;

        private void SetupPrivateFields()
        {
            _cardAttributes = new List<CardAttribute>
                              {
                                  new CardAttribute {Name = new LocalizedText("CardAttribute1")},
                                  new CardAttribute {Name = new LocalizedText("CardAttribute2")},
                                  new CardAttribute {Name = new LocalizedText("CardAttribute3")},
                                  new CardAttribute {Name = new LocalizedText("CardAttribute4")}
                              };

            _cardUpgradeCardAttributeValues = new List<CardUpgradeCardAttributeValue>
                                              {
                                                  new CardUpgradeCardAttributeValue
                                                  {
                                                      CardAttribute = _cardAttributes[0],
                                                      Value = 7
                                                  },
                                                  new CardUpgradeCardAttributeValue
                                                  {
                                                      CardAttribute = _cardAttributes[1],
                                                      Value = 9
                                                  },
                                                  new CardUpgradeCardAttributeValue
                                                  {
                                                      CardAttribute = _cardAttributes[2],
                                                      Value = 12
                                                  },
                                                  new CardUpgradeCardAttributeValue
                                                  {
                                                      CardAttribute = _cardAttributes[3],
                                                      Value = 3
                                                  }
                                              };

            _cardUpgrades = new List<CardUpgrade>
                            {
                                new CardUpgrade
                                {
                                    UpgradeFrom = 0,
                                    UpgradeTo = 1,
                                    CardAttributeUpgrades = new[] {_cardUpgradeCardAttributeValues[0], _cardUpgradeCardAttributeValues[1]}
                                },
                                new CardUpgrade
                                {
                                    UpgradeFrom = 1,
                                    UpgradeTo = 2,
                                    CardAttributeUpgrades = new[] {_cardUpgradeCardAttributeValues[2], _cardUpgradeCardAttributeValues[3]}
                                },
                                new CardUpgrade
                                {
                                    UpgradeFrom = 2,
                                    UpgradeTo = 3,
                                    CardAttributeUpgrades = new[] {_cardUpgradeCardAttributeValues[2], _cardUpgradeCardAttributeValues[0]}
                                },
                                new CardUpgrade
                                {
                                    UpgradeFrom = 3,
                                    UpgradeTo = 4,
                                    CardAttributeUpgrades = new[] {_cardUpgradeCardAttributeValues[3], _cardUpgradeCardAttributeValues[1]}
                                },
                                new CardUpgrade
                                {
                                    UpgradeFrom = 4,
                                    UpgradeTo = 5,
                                    CardAttributeUpgrades = new[] {_cardUpgradeCardAttributeValues[1], _cardUpgradeCardAttributeValues[2]}
                                },
                                new CardUpgrade
                                {
                                    UpgradeFrom = 5,
                                    UpgradeTo = 6,
                                    CardAttributeUpgrades = new[] {_cardUpgradeCardAttributeValues[3], _cardUpgradeCardAttributeValues[1]}
                                }
                            };

            _card = new Card {CardUpgrades = _cardUpgrades};
        }

        private double GetCardUpgradeVale(CardAttribute cardAttribute, int internalUpgradeLevel)
        {
            return _cardUpgrades.Where(cu => cu.UpgradeFrom < internalUpgradeLevel)
                                .SelectMany(cu => cu.CardAttributeUpgrades)
                                .Where(c => c.CardAttribute == cardAttribute)
                                .Sum(c => c.Value);
        }

        private void AssertCardUpgradeLevels(int internalUpgradeLevel, int upgradeLevel, int level, int maxUpgradeLevelInLevel, bool isLevelUpgrade,
            CardUpgradeLevelInfo cardUpgradeLevelInfo)
        {
            Assert.True(cardUpgradeLevelInfo.InternalUpgradeLevel == internalUpgradeLevel);
            Assert.True(cardUpgradeLevelInfo.Level == level);
            Assert.True(cardUpgradeLevelInfo.UpgradeLevel.CurrentUpgradeLevel == upgradeLevel);
            Assert.True(cardUpgradeLevelInfo.UpgradeLevel.MaximumUpgradeLevelInLevel == maxUpgradeLevelInLevel);
            Assert.True(cardUpgradeLevelInfo.IsLevelUpgrade == isLevelUpgrade);
            var cardUpgrade = _cardUpgrades.SingleOrDefault(cu => cu.UpgradeFrom == cardUpgradeLevelInfo.InternalUpgradeLevel);
            if (cardUpgrade != null)
            {
                foreach (var keyValue in cardUpgradeLevelInfo.AttributeUpgrades)
                {
                    var cardAttribute = keyValue.Key;
                    var value = keyValue.Value;
                    Assert.Equal(cardUpgrade.CardAttributeUpgrades.Single(c => c.CardAttribute == cardAttribute).Value, value);
                }
            }

            foreach (var keyValue in cardUpgradeLevelInfo.AttributeValues)
            {
                var cardAttribute = keyValue.Key;
                var value = keyValue.Value;
                Assert.Equal(GetCardUpgradeVale(cardAttribute, cardUpgradeLevelInfo.InternalUpgradeLevel), value);
            }
        }

        [Fact]
        public void GetCardAttributesTest()
        {
            // Arrange done in constructor

            // Act
            var retrievedCardAttributes = _card.GetCardAttributes().ToList();

            // Assert
            Assert.Equal(_cardAttributes.Count, retrievedCardAttributes.Count);
            Assert.Empty(_cardAttributes.Except(retrievedCardAttributes));
        }

        [Fact]
        public void GetCardUpgradeLevelTest()
        {
            // Arrange
            const int level1InternalUpgradeLevel = 1;
            const int level1UpgradeLevel = 1;
            const int level1Level = 1;
            const int level1MaxLevel = 5;
            const bool level1IsLevelUpgrade = false;

            const int level2InternalUpgradeLevel = 2;
            const int level2UpgradeLevel = 2;
            const int level2Level = 1;
            const int level2MaxLevel = 5;
            const bool level2IsLevelUpgrade = false;

            const int level5InternalUpgradeLevel = 5;
            const int level5UpgradeLevel = 5;
            const int level5Level = 1;
            const int level5MaxLevel = 5;
            const bool level5IsLevelUpgrade = true;

            const int level6InternalUpgradeLevel = 6;
            const int level6UpgradeLevel = 5;
            const int level6Level = 2;
            const int level6MaxLevel = 15;
            const bool level6IsLevelUpgrade = false;

            // Act
            var retrievedCardUpgradeLevel1 = _card.GetCardUpgradeLevel(level1InternalUpgradeLevel);
            var retrievedCardUpgradeLevel2 = _card.GetCardUpgradeLevel(level2InternalUpgradeLevel);
            var retrievedCardUpgradeLevel5 = _card.GetCardUpgradeLevel(level5InternalUpgradeLevel);
            var retrievedCardUpgradeLevel6 = _card.GetCardUpgradeLevel(level6InternalUpgradeLevel);

            // Assert
            AssertCardUpgradeLevels(level1InternalUpgradeLevel, level1UpgradeLevel, level1Level, level1MaxLevel, level1IsLevelUpgrade, retrievedCardUpgradeLevel1);
            AssertCardUpgradeLevels(level2InternalUpgradeLevel, level2UpgradeLevel, level2Level, level2MaxLevel, level2IsLevelUpgrade, retrievedCardUpgradeLevel2);
            AssertCardUpgradeLevels(level5InternalUpgradeLevel, level5UpgradeLevel, level5Level, level5MaxLevel, level5IsLevelUpgrade, retrievedCardUpgradeLevel5);
            AssertCardUpgradeLevels(level6InternalUpgradeLevel, level6UpgradeLevel, level6Level, level6MaxLevel, level6IsLevelUpgrade, retrievedCardUpgradeLevel6);
        }

        [Fact]
        public void GetUpgradeLevelsTest()
        {
            // Arrange done in constructor

            // Act
            var retrievedCardUpgradeLevels = _card.GetUpgradeLevels().ToList();

            // Assert
            Assert.Equal(_cardUpgrades.Min(cu => cu.UpgradeTo), retrievedCardUpgradeLevels.Min(cu => cu.UpgradeLevel.CurrentUpgradeLevel));
            Assert.Equal(_cardUpgrades.Max(cu => cu.UpgradeFrom), retrievedCardUpgradeLevels.Max(cu => cu.UpgradeLevel.CurrentUpgradeLevel));
            Assert.Equal(retrievedCardUpgradeLevels.Count, _cardUpgrades.Count);
        }
    }
}