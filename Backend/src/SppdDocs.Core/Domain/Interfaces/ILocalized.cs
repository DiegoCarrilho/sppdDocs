namespace SppdDocs.Core.Domain.Interfaces
{
	public interface ILocalized<out T>
	{
		/// <summary>
		///     English
		/// </summary>
		T En { get; }

		/// <summary>
		///     French
		/// </summary>
		T Fr { get; }

		/// <summary>
		///     German
		/// </summary>
		T De { get; }

		/// <summary>
		///     Italian
		/// </summary>
		T It { get; }

		/// <summary>
		///     Japanese
		/// </summary>
		T Ja { get; }

		/// <summary>
		///     Korean
		/// </summary>
		T Ko { get; }

		/// <summary>
		///     Russian
		/// </summary>
		T Ru { get; }

		/// <summary>
		///     Spanish
		/// </summary>
		T Es { get; }

		/// <summary>
		///     Chinese
		/// </summary>
		T Zh { get; }

		/// <summary>
		///     Portuguese
		/// </summary>
		T Pt { get; }

		/// <summary>
		///     Turkish
		/// </summary>
		T Tr { get; }

		/// <summary>
		///     Polish
		/// </summary>
		T Pl { get; }
	}
}