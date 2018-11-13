using System.Collections.Generic;
using System.Threading.Tasks;

using SppdDocs.Core.Domain.Entities;

namespace SppdDocs.Core.Services
{
    /// <summary>
    ///     Offers functionality related to cards
    /// </summary>
    public interface ICardService
    {
        /// <summary>
        ///     Gets the current card for the given card identifier.
        /// </summary>
        /// <param name="friendlyName">Friendly name of the card.</param>
        /// <returns>
        ///     The card if it could be found; otherwise <c>NULL</c>
        /// </returns>
        Task<Card> GetCurrentAsync(string friendlyName);

        /// <summary>
        ///     Gets the friendly names of all cards.
        /// </summary>
        Task<IEnumerable<string>> GetFriendlyNamesAsync();
    }
}