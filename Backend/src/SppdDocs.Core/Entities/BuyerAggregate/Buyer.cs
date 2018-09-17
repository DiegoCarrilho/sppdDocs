using System.Collections.Generic;
using Ardalis.GuardClauses;
using SppdDocs.Core.Interfaces;

namespace SppdDocs.Core.Entities.BuyerAggregate
{
	public class Buyer : BaseEntity, IAggregateRoot
	{
		private readonly List<PaymentMethod> _paymentMethods = new List<PaymentMethod>();

		private Buyer()
		{
			// required by EF
		}

		public Buyer(string identity) : this()
		{
			Guard.Against.NullOrEmpty(identity, nameof(identity));
			IdentityGuid = identity;
		}

		public string IdentityGuid { get; }

		public IEnumerable<PaymentMethod> PaymentMethods => _paymentMethods.AsReadOnly();
	}
}