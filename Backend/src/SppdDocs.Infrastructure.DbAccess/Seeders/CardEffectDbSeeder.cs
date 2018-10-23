using System;
using SppdDocs.Core.Domain.Entities;
using SppdDocs.Core.Domain.Objects;
using SppdDocs.Core.Repositories;
using SppdDocs.Infrastructure.DbAccess.Utils.Extensions;

namespace SppdDocs.Infrastructure.DbAccess.Seeders
{
	internal class CardEffectDbSeeder : IDbSeeder
	{
		private readonly IRepository<CardEffect> _cardEffectRepository;

		public CardEffectDbSeeder(IRepository<CardEffect> cardEffectRepository)
		{
			_cardEffectRepository = cardEffectRepository;
		}

		public int Priority => SeederConstants.DbSeederPriority.BASE_DATA;

		public void Seed()
		{
			_cardEffectRepository.Add(new CardEffect
			                          {
				                          Id = new Guid(SeederConstants.CardEffect.CHARGED_ID),
				                          Name = new LocalizedText("Charged")
			                          }.SetDefaultSeederProperties());
			_cardEffectRepository.Add(new CardEffect
			                          {
				                          Id = new Guid(SeederConstants.CardEffect.WARCRY_ID),
				                          Name = new LocalizedText("Warcry")
			                          }.SetDefaultSeederProperties());
			_cardEffectRepository.Add(new CardEffect
			                          {
				                          Id = new Guid(SeederConstants.CardEffect.DEATHWISH_ID),
				                          Name = new LocalizedText("Deathwish")
			                          }.SetDefaultSeederProperties());
			_cardEffectRepository.Add(new CardEffect
			                          {
				                          Id = new Guid(SeederConstants.CardEffect.AURA_ID),
				                          Name = new LocalizedText("Aura")
			                          }.SetDefaultSeederProperties());
			_cardEffectRepository.Add(new CardEffect
			                          {
				                          Id = new Guid(SeederConstants.CardEffect.HEADHUNTER_ID),
				                          Name = new LocalizedText("Headhunter")
			                          }.SetDefaultSeederProperties());
			_cardEffectRepository.Add(new CardEffect
			                          {
				                          Id = new Guid(SeederConstants.CardEffect.ENRAGED_ID),
				                          Name = new LocalizedText("Enraged")
			                          }.SetDefaultSeederProperties());
		}
	}
}