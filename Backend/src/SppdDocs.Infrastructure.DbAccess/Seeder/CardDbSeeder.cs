using System;
using SppdDocs.Core.Domain.Entities;
using SppdDocs.Core.Domain.Repositories;

namespace SppdDocs.Infrastructure.DbAccess.Seeder
{
	internal class CardDbSeeder : IDbSeeder
	{
		private readonly IRepository<Card> _cardRepository;

		public CardDbSeeder(IRepository<Card> cardRepository)
		{
			_cardRepository = cardRepository;
		}

		public int Priority => 100;

		public void Seed()
		{
			var card1 = new Card
			            {
				            Id = new Guid("0FE8F39B-D9F6-4438-ADF6-714DB80C3715"),
							EntityId = new Guid("2910626A-8A78-4570-8D02-1B35F17DBDC3"),
				            IsCurrent = true,
				            Name = "Stan of many moons",
				            Description = "That's the shit"
			            };
			_cardRepository.Add(card1);
		}
	}
}