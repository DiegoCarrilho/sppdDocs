using System.Collections.Generic;

namespace SppdDocs.DTOs
{
    /// <summary>
    ///     Data transfer object holding all information about a card upgrade.
    /// </summary>
    public class CardUpgradeDto
    {
        private IDictionary<string, double> _cardAttributeUpgradeValues;
        private IDictionary<string, double> _cardAttributeValues;

        /// <summary>
        ///     The internal upgrade level of the card (1 to 81 with 81 = UpgradeLevel + CardLevels count).
        /// </summary>
        public int InternalUpgradeLevel { get; set; }

        /// <summary>
        ///     The level of the card (1 to 7).
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        ///     The upgrade level of the card (1 to 75).
        /// </summary>
        public int UpgradeLevel { get; set; }

        /// <summary>
        ///     The maximum upgrade level for the <see cref="Level" /> (5, 10, 20, 35, 50, 75).
        /// </summary>
        public int MaximumUpgradeLevelInLevel { get; set; }

        /// <summary>
        ///     Indicates if this upgrade is a level upgrade. This is the case if <see cref="UpgradeLevel" /> equals
        ///     <see cref="MaximumUpgradeLevelInLevel" />.
        /// </summary>
        public bool IsLevelUpgrade { get; set; }

        /// <summary>
        ///     The card attribute values for the upgrade level. E.g. Attack=45, Health=99, Range=2.<br />
        ///     Returns a dictionary with key=AttributeId; value=value.
        /// </summary>
        public IDictionary<string, double> AttributeValues
        {
            get => _cardAttributeValues ?? (_cardAttributeValues = new Dictionary<string, double>());
            set => _cardAttributeValues = value;
        }

        /// <summary>
        ///     The card attribute values for the upgrade level. E.g. Attack=+10, Health=+34.<br />
        ///     Returns a dictionary with key=AttributeId; value=value.
        /// </summary>
        public IDictionary<string, double> AttributeUpgradeValues
        {
            get => _cardAttributeUpgradeValues ?? (_cardAttributeUpgradeValues = new Dictionary<string, double>());
            set => _cardAttributeUpgradeValues = value;
        }
    }
}