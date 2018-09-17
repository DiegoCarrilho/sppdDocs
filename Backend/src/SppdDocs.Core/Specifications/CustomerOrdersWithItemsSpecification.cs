using SppdDocs.Core.Entities.OrderAggregate;

namespace SppdDocs.Core.Specifications
{
	public class CustomerOrdersWithItemsSpecification : BaseSpecification<Order>
	{
		public CustomerOrdersWithItemsSpecification(string buyerId)
			: base(o => o.BuyerId == buyerId)
		{
			AddInclude(o => o.OrderItems);
			AddInclude($"{nameof(Order.OrderItems)}.{nameof(OrderItem.ItemOrdered)}");
		}
	}
}