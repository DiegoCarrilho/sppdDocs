using System.Linq;
using Microsoft.EntityFrameworkCore;
using SppdDocs.Core.Domain.Entities;
using SppdDocs.Core.Repositories;

namespace SppdDocs.Infrastructure.DbAccess.Repositories
{
    internal class CardRepository : RepositoryVersioned<Card>, ICardRepository
    {
        public CardRepository(SppdContext sppdContext)
            : base(sppdContext)
        {
        }

        public IQueryable<Card> GetCardsFull()
        {
            return GetAllCurrent()
                   .Include(card => card.Theme)
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