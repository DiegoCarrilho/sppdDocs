using System;
using SppdDocs.Core.Domain.Entities;
using SppdDocs.Core.Domain.Objects;
using SppdDocs.Core.Repositories;
using SppdDocs.Infrastructure.DbAccess.Utils.Extensions;

namespace SppdDocs.Infrastructure.DbAccess.Seeders
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
			_cardRepository.Add(new Card
			                    {
				                    Id = new Guid(SeederConstants.Card.STAN_OF_MANY_MOONS_ID),
				                    Name = new LocalizedText("Stan of Many Moons"),
				                    Description =
					                    new LocalizedText(
						                    "Stan of many Moons is a 4-cost fighter from the Adventure theme who is available at rank 5 that deals damage to all enemy units on the battlefield with his effect."),
				                    RarityId = new Guid(SeederConstants.Rarity.LEGENDARY_ID),
				                    ClassId = new Guid(SeederConstants.CardClass.FIGHTER_ID),
				                    EffectId = new Guid(SeederConstants.CardEffect.CHARGED_ID)
			                    }.SetDefaultSeederProperties());
			_cardRepository.Add(new Card
			                    {
				                    Id = new Guid(SeederConstants.Card.POISON_ID),
				                    Name = new LocalizedText("Poison"),
				                    Description = new LocalizedText(
					                    "Poison is a 3 cost spell from the Sci-Fi theme who is available at rank 5 that poisons all enemies in a target area."),
				                    RarityId = new Guid(SeederConstants.Rarity.COMMON_ID),
				                    ClassId = new Guid(SeederConstants.CardClass.SPELL_ID),
				                    StatusEffectId = new Guid(SeederConstants.CardStatusEffect.POISON_ID)
			                    }.SetDefaultSeederProperties());
		}
	}
}