using System.Collections.Generic;
using System.Linq;
using SppdDocs.Core.Interfaces;

namespace SppdDocs.Core.Entities.BasketAggregate
{
	public class Basket : BaseEntity, IAggregateRoot
	{
		private readonly List<BasketItem> _items = new List<BasketItem>();
		public string BuyerId { get; set; }
		public IReadOnlyCollection<BasketItem> Items => _items.AsReadOnly();

		public void AddItem(int catalogItemId, decimal unitPrice, int quantity = 1)
		{
			if (!Items.Any(i => i.CatalogItemId == catalogItemId))
			{
				_items.Add(new BasketItem
				           {
					           CatalogItemId = catalogItemId,
					           Quantity = quantity,
					           UnitPrice = unitPrice
				           });
				return;
			}

			var existingItem = Items.FirstOrDefault(i => i.CatalogItemId == catalogItemId);
			existingItem.Quantity += quantity;
		}
	}
}