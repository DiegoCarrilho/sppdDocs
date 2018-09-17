using Ardalis.GuardClauses;
using SppdDocs.Core.Entities.BasketAggregate;

namespace SppdDocs.Core.Exceptions
{
	public static class BasketGuards
	{
		public static void NullBasket(this IGuardClause guardClause, int basketId, Basket basket)
		{
			if (basket == null)
			{
				throw new BasketNotFoundException(basketId);
			}
		}
	}
}