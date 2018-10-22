using System;

namespace SppdDocs.Core.Domain.Entities
{
	/// <summary>
	///     Holds the value for a card upgrade.
	/// </summary>
	/// <seealso cref="SppdDocs.Core.Domain.Entities.BaseEntity" />
	public class CardUpgradeCardAttributeValue : BaseEntity
	{
		/// <summary>
		///     The <see cref="Entities.CardUpgrade" /> holding a reference to this <see cref="CardUpgradeCardAttributeValue" />.
		/// </summary>
		public CardUpgrade CardUpgrade { get; set; }

		/// <summary>
		///     The ID of <see cref="CardAttribute" /> (used as foreign key reference).
		/// </summary>
		public Guid CardAttributeId { get; set; }

		/// <summary>
		///     The <see cref="CardAttribute" /> for which a value is being defined.
		/// </summary>
		public CardAttribute CardAttribute { get; set; }

		/// <summary>
		///     The numerical value.
		/// </summary>
		public double Value { get; set; }
	}
}