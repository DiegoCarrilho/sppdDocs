using System;
using SppdDocs.Core.Domain.Entities;
using SppdDocs.Core.Domain.Objects;
using SppdDocs.Core.Repositories;
using SppdDocs.Infrastructure.DbAccess.Utils.Extensions;

namespace SppdDocs.Infrastructure.DbAccess.Seeders
{
	internal class CardThemeDbSeeder : IDbSeeder
	{
		private readonly IRepository<CardTheme> _cardThemeRepository;

		public CardThemeDbSeeder(IRepository<CardTheme> cardThemeRepository)
		{
			_cardThemeRepository = cardThemeRepository;
		}

		public int Priority => SeederConstants.DbSeederPriority.BASE_DATA;

		public void Seed()
		{
			_cardThemeRepository.Add(new CardTheme
			                         {
				                         Id = new Guid(SeederConstants.CardTheme.ADVENTURE_ID),
				                         Name = new LocalizedText("Adventure")
			                         }.SetDefaultSeederProperties());
			_cardThemeRepository.Add(new CardTheme
			                         {
				                         Id = new Guid(SeederConstants.CardTheme.SCIFI_ID),
				                         Name = new LocalizedText("Sci-Fy")
			                         }.SetDefaultSeederProperties());
			_cardThemeRepository.Add(new CardTheme
			                         {
				                         Id = new Guid(SeederConstants.CardTheme.FANTASY_ID),
				                         Name = new LocalizedText("Fantasy")
			                         }.SetDefaultSeederProperties());
			_cardThemeRepository.Add(new CardTheme
			                         {
				                         Id = new Guid(SeederConstants.CardTheme.MYSTICAL_ID),
				                         Name = new LocalizedText("Mystical")
			                         }.SetDefaultSeederProperties());
			_cardThemeRepository.Add(new CardTheme
			                         {
				                         Id = new Guid(SeederConstants.CardTheme.NEUTRAL_ID),
				                         Name = new LocalizedText("Neutral")
			                         }.SetDefaultSeederProperties());
		}
	}
}