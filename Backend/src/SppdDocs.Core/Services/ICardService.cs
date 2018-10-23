using System;
using System.Collections.Generic;
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
        /// <param name="cardId">The card identifier.</param>
        /// <returns>The card if it could be found; otherwise <c>NULL</c></returns>
        Card GetCurrent(Guid cardId);

        /// <summary>
        ///     Gets all current cards.
        /// </summary>
        /// <returns>All current cards</returns>
        IEnumerable<Card> GetAllCurrent();
    }
}