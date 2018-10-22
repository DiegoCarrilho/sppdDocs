namespace SppdDocs.Core.Domain.Objects
{
	/// <summary>
	///     Specifies the current level as well as the maximum upgrade level for the card level.
	/// </summary>
	public class CardUpgradeLevel
	{
		/// <summary>
		///     The current level.
		/// </summary>
		public int CurrentUpgradeLevel { get; set; }

		/// <summary>
		///     The maximum upgrade level for the current level.
		/// </summary>
		public int MaximumUpgradeLevelInLevel { get; set; }

		public override string ToString()
		{
			return $"CurrentUpgradeLevel={CurrentUpgradeLevel}; MaximumUpgradeLevelInLevel={MaximumUpgradeLevelInLevel}";
		}
	}
}