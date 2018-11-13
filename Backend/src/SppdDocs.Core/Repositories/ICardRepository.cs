using System.Threading.Tasks;
using SppdDocs.Core.Domain.Entities;

namespace SppdDocs.Core.Repositories
{
    public interface ICardRepository : INamedEntityRepository<Card>
    {
        /// <summary>
        ///     Gets the current card specified by <see cref="friendlyName" /> asynchronously.
        /// </summary>
        /// <param name="friendlyName">Name of the friendly.</param>
        /// <returns>The <see cref="Card" /> if it could be found; otherwise <c>null</c></returns>
        Task<Card> GetCurrentAsync(string friendlyName);
    }
}