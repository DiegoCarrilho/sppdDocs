using System.Collections.Generic;

namespace SppdDocs.Core.Domain.Entities
{
	/// <summary>
	///     Defines which <see cref="CardAttributeUpgrades" /> are being improved when upgrading from
	///     <see cref="UpgradeFrom" /> to
	///     <see cref="UpgradeTo" />.
	/// </summary>
	/// <seealso cref="SppdDocs.Core.Domain.Entities.BaseEntity" />
	public class CardUpgrade : BaseEntity
	{
		private IEnumerable<CardUpgradeCardAttributeValue> _cardAttributeValues;

		/// <summary>
		///     Current upgrade level
		/// </summary>
		public int UpgradeFrom { get; set; }

		/// <summary>
		///     Upgrade level after having upgraded
		/// </summary>
		public int UpgradeTo { get; set; }

		/// <summary>
		///     CardAttributes which get improved when performing the upgrade
		/// </summary>
		public IEnumerable<CardUpgradeCardAttributeValue> CardAttributeUpgrades
		{
			get => _cardAttributeValues ?? (_cardAttributeValues = new List<CardUpgradeCardAttributeValue>());
			set => _cardAttributeValues = value;
		}
	}
}