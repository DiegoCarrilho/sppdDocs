namespace SppdDocs.Core.Entities.OrderAggregate
{
	public class OrderItem : BaseEntity
	{
		private OrderItem()
		{
			// required by EF
		}

		public OrderItem(CatalogItemOrdered itemOrdered, decimal unitPrice, int units)
		{
			ItemOrdered = itemOrdered;
			UnitPrice = unitPrice;
			Units = units;
		}

		public CatalogItemOrdered ItemOrdered { get; set; }
		public decimal UnitPrice { get; set; }
		public int Units { get; set; }
	}
}