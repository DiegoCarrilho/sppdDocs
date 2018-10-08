using System.Linq;
using SppdDocs.Core.Domain.Entities;

namespace SppdDocs.Core.Domain.Repositories
{
	public interface ICardRepository : IRepositoryVersioned<Card>
	{
		IQueryable<Card> GetCardsFull();
	}
}