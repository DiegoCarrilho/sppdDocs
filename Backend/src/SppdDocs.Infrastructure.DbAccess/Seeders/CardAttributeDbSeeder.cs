using System;
using SppdDocs.Core.Domain.Entities;
using SppdDocs.Core.Domain.Objects;
using SppdDocs.Core.Repositories;
using SppdDocs.Infrastructure.DbAccess.Utils.Extensions;

namespace SppdDocs.Infrastructure.DbAccess.Seeders
{
	internal class CardAttributeDbSeeder : IDbSeeder
	{
		private readonly IRepository<CardAttribute> _cardAttributeRepository;

		public CardAttributeDbSeeder(IRepository<CardAttribute> cardAttributeRepository)
		{
			_cardAttributeRepository = cardAttributeRepository;
		}

		public int Priority => 90;

		public void Seed()
		{
			_cardAttributeRepository.Add(new CardAttribute
			                             {
				                             Id = new Guid(SeederConstants.CardAttribute.CARD_UPGRADES_ID),
				                             Name = new LocalizedText("Card Upgrades"),
				                             SortIndex = 1
			                             }.SetDefaultSeederProperties());
			_cardAttributeRepository.Add(new CardAttribute
			                             {
				                             Id = new Guid(SeederConstants.CardAttribute.ATTACK_ID),
				                             Name = new LocalizedText("Attack"),
				                             SortIndex = 2
			                             }.SetDefaultSeederProperties());
			_cardAttributeRepository.Add(new CardAttribute
			                             {
				                             Id = new Guid(SeederConstants.CardAttribute.HEALTH_ID),
				                             Name = new LocalizedText("Health"),
				                             SortIndex = 3
			                             }.SetDefaultSeederProperties());
			_cardAttributeRepository.Add(new CardAttribute
			                             {
				                             Id = new Guid(SeederConstants.CardAttribute.DAMAGE_ALL_ID),
				                             Name = new LocalizedText("Damage All"),
				                             SortIndex = 4
			                             }.SetDefaultSeederProperties());
		}
	}
}