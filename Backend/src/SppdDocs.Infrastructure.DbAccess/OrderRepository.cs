using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SppdDocs.Core.Entities.OrderAggregate;
using SppdDocs.Core.Interfaces;

namespace SppdDocs.Infrastructure.DbAccess
{
	public class OrderRepository : Repository<Order>, IOrderRepository
	{
		public OrderRepository(Context dbContext) : base(dbContext)
		{
		}

		public Order GetByIdWithItems(int id)
		{
			return DbContext.Orders
			                .Include(o => o.OrderItems)
			                .Include($"{nameof(Order.OrderItems)}.{nameof(OrderItem.ItemOrdered)}")
			                .FirstOrDefault();
		}

		public Task<Order> GetByIdWithItemsAsync(int id)
		{
			return DbContext.Orders
			                .Include(o => o.OrderItems)
			                .Include($"{nameof(Order.OrderItems)}.{nameof(OrderItem.ItemOrdered)}")
			                .FirstOrDefaultAsync();
		}
	}
}