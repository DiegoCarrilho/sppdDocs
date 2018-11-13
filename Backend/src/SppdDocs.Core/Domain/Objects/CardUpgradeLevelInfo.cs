using System.Collections.Generic;

using SppdDocs.Core.Domain.Entities;
using SppdDocs.Core.Utils.Helpers;

namespace SppdDocs.Core.Domain.Objects
{
    /// <summary>
    /// </summary>
    public class CardUpgradeLevelInfo
    {
        private IDictionary<CardAttribute, double> _cardAttributeUpgradeValues;
        private IDictionary<CardAttribute, double> _cardAttributeValues;

        /// <summary>
        ///     The internal upgrade level of the card (1 to 81 with 81 = UpgradeLevel + CardLevels count).
        /// </summary>
        public int InternalUpgradeLevel { get; set; }

        /// <summary>
        ///     The level of the card (1 to 7).
        /// </summary>
        public int Level => CardHelper.GetCardLevel(InternalUpgradeLevel);

        /// <summary>
        ///     The upgrade level of the card (1 to 75).
        /// </summary>
        public CardUpgradeLevel UpgradeLevel => CardHelper.GetCardUpgradeLevel(InternalUpgradeLevel);

        /// <summary>
        ///     Indicates if this upgrade is a level upgrade. This is the case if for <see cref="UpgradeLevel" />,
        ///     <see cref="CardUpgradeLevel.CurrentUpgradeLevel" /> equals
        ///     <see cref="CardUpgradeLevel.MaximumUpgradeLevelInLevel" />
        /// </summary>
        public bool IsLevelUpgrade => UpgradeLevel != null && UpgradeLevel.CurrentUpgradeLevel == UpgradeLevel.MaximumUpgradeLevelInLevel;

        /// <summary>
        ///     The card attribute values for the upgrade level. E.g. Attack=45, Health=99, Range=2.<br />
        ///     Returns a dictionary with key=<see cref="CardAttribute" />; value=value.
        /// </summary>
        public IDictionary<CardAttribute, double> AttributeValues
        {
            get => _cardAttributeValues ?? (_cardAttributeValues = new Dictionary<CardAttribute, double>());
            set => _cardAttributeValues = value;
        }

        /// <summary>
        ///     The card attribute values for the upgrade level. E.g. Attack=+10, Health=+34.<br />
        ///     Returns a dictionary with key=<see cref="CardAttribute" />; value=value.
        /// </summary>
        public IDictionary<CardAttribute, double> AttributeUpgrades
        {
            get => _cardAttributeUpgradeValues ?? (_cardAttributeUpgradeValues = new Dictionary<CardAttribute, double>());
            set => _cardAttributeUpgradeValues = value;
        }
    }
}