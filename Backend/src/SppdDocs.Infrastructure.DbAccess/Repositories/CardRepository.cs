using System.Linq;
using Microsoft.EntityFrameworkCore;
using SppdDocs.Core.Domain.Entities;
using SppdDocs.Core.Repositories;

namespace SppdDocs.Infrastructure.DbAccess.Repositories
{
	public class CardRepository : RepositoryVersioned<Card>, ICardRepository
	{
		public CardRepository(SppdContext sppdContext)
			: base(sppdContext)
		{
		}

		public IQueryable<Card> GetCardsFull()
		{
			return GetAllCurrent()
			       .Include(card => card.Rarity)
			       .Include(card => card.Class);
		}
	}
}