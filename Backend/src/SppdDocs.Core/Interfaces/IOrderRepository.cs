using System.Threading.Tasks;
using SppdDocs.Core.Entities.OrderAggregate;

namespace SppdDocs.Core.Interfaces
{
	public interface IOrderRepository : IRepository<Order>, IAsyncRepository<Order>
	{
		Order GetByIdWithItems(int id);
		Task<Order> GetByIdWithItemsAsync(int id);
	}
}