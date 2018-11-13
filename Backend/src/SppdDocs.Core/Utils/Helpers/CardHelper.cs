using System.Collections.Generic;
using System.Linq;

using SppdDocs.Core.Domain.Objects;

namespace SppdDocs.Core.Utils.Helpers
{
    /// <summary>
    ///     Static helper class for cards
    /// </summary>
    public static class CardHelper
    {
        public const int NB_CARD_UPGRADE_LEVELS = 70;

        private static readonly IDictionary<int, int> s_upgradesForLevel;
        private static readonly IDictionary<int, int> s_cardLevelForCardUpgradeLevel;
        private static readonly IDictionary<int, CardUpgradeLevel> s_cardUpgradeLevelForCardUpgradeLevel;

        static CardHelper()
        {
            s_upgradesForLevel = new Dictionary<int, int>
                                 {
                                     {1, 5}, {2, 10}, {3, 10}, {4, 15}, {5, 15}, {6, 15}, {7, 0}
                                 };

            // Compute the values once to have a quick access to the cached values when needed
            s_cardLevelForCardUpgradeLevel = new Dictionary<int, int>();
            s_cardUpgradeLevelForCardUpgradeLevel = new Dictionary<int, CardUpgradeLevel>();
            for (var cardUpgradeLevel = 1; cardUpgradeLevel < NB_CARD_UPGRADE_LEVELS + s_upgradesForLevel.Count; cardUpgradeLevel++)
            {
                var cardLevel = GetCardLevelInternal(cardUpgradeLevel);
                var maximumInLevel = GetMaximumUpgradeLevelInLevel(cardLevel);
                var currentUpgradeLevel = cardUpgradeLevel - cardLevel + 1;

                s_cardLevelForCardUpgradeLevel.Add(cardUpgradeLevel, cardLevel);
                s_cardUpgradeLevelForCardUpgradeLevel.Add(cardUpgradeLevel, new CardUpgradeLevel
                                                                            {
                                                                                CurrentUpgradeLevel = currentUpgradeLevel,
                                                                                MaximumUpgradeLevelInLevel = maximumInLevel
                                                                            });
            }
        }

        /// <summary>
        ///     Gets the card level for the given internal card upgrade level.
        /// </summary>
        public static int GetCardLevel(int cardUpgradeLevelInternal)
        {
            return s_cardLevelForCardUpgradeLevel[cardUpgradeLevelInternal];
        }

        /// <summary>
        ///     Gets the card upgrade level containing the current upgrade level as well as the maximum upgrade level for the card
        ///     level for the given internal card upgrade level.
        /// </summary>
        public static CardUpgradeLevel GetCardUpgradeLevel(int cardUpgradeLevelInternal)
        {
            return s_cardUpgradeLevelForCardUpgradeLevel[cardUpgradeLevelInternal];
        }

        /// <summary>
        ///     Gets the card level for the (internal) card upgrade level.
        /// </summary>
        private static int GetCardLevelInternal(int cardUpgradeLevelInternal)
        {
            if (cardUpgradeLevelInternal < 6)
            {
                return 1;
            }

            if (cardUpgradeLevelInternal < 17)
            {
                return 2;
            }

            if (cardUpgradeLevelInternal < 28)
            {
                return 3;
            }

            if (cardUpgradeLevelInternal < 44)
            {
                return 4;
            }

            if (cardUpgradeLevelInternal < 60)
            {
                return 5;
            }

            if (cardUpgradeLevelInternal < 76)
            {
                return 6;
            }

            return 7;
        }

        /// <summary>
        ///     Gets the maximum upgrade level for the specified card level.
        /// </summary>
        private static int GetMaximumUpgradeLevelInLevel(int cardLevel)
        {
            return s_upgradesForLevel.Where(kv => kv.Key <= cardLevel).Sum(kv => kv.Value);
        }
    }
}