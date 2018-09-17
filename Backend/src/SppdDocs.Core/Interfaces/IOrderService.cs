using System.Threading.Tasks;
using SppdDocs.Core.Entities.OrderAggregate;

namespace SppdDocs.Core.Interfaces
{
	public interface IOrderService
	{
		Task CreateOrderAsync(int basketId, Address shippingAddress);
	}
}