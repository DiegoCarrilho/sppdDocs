using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using SppdDocs.Core.Domain.Entities;
using SppdDocs.Core.Repositories;

namespace SppdDocs.Infrastructure.DbAccess.Repositories
{
    internal class CardRepository : NamedEntityRepository<Card>, ICardRepository
    {
        public CardRepository(SppdContext sppdContext)
            : base(sppdContext)
        {
        }

        public async Task<Card> GetCurrentAsync(string friendlyName)
        {
            return await GetAsync(friendlyName, IncludeAll);
        }

        private static IQueryable<Card> IncludeAll(IQueryable<Card> cards)
        {
            return cards.Include(card => card.Theme)
                        .Include(card => card.Rarity)
                        .Include(card => card.Class)
                        .Include(card => card.Effect)
                        .Include(card => card.StatusEffect)
                        .Include(card => card.CastArea)
                        .Include(card => card.CardUpgrades)
                        .ThenInclude(clu => clu.CardAttributeUpgrades)
                        .ThenInclude(av => av.CardAttribute);
        }
    }
}