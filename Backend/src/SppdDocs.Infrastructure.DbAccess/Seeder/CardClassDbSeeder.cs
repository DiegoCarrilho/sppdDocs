using System;
using SppdDocs.Core.Domain.Entities;
using SppdDocs.Core.Domain.Objects;
using SppdDocs.Core.Domain.Repositories;
using SppdDocs.Infrastructure.DbAccess.Utils.Helpers;

namespace SppdDocs.Infrastructure.DbAccess.Seeder
{
	internal class CardClassDbSeeder : IDbSeeder
	{
		private readonly IRepository<CardClass> _cardClassRepository;

		public CardClassDbSeeder(IRepository<CardClass> cardClassRepository)
		{
			_cardClassRepository = cardClassRepository;
		}

		public int Priority => 90;

		public void Seed()
		{
			_cardClassRepository.Add(new CardClass
			                         {
				                         Id = new Guid(SeederConstants.CardClass.FIGHTER_ID),
				                         Name = new LocalizedText("Fighter"),
				                         Image = ImageHelper.GetImageFromFilePath("")
			                         });
			_cardClassRepository.Add(new CardClass
			                         {
				                         Id = new Guid(SeederConstants.CardClass.ASSASSIN_ID),
				                         Name = new LocalizedText("Assassin"),
				                         Image = ImageHelper.GetImageFromFilePath("")
			                         });
			_cardClassRepository.Add(new CardClass
			                         {
				                         Id = new Guid(SeederConstants.CardClass.RANGED_ID),
				                         Name = new LocalizedText("Ranged"),
				                         Image = ImageHelper.GetImageFromFilePath("")
			                         });
			_cardClassRepository.Add(new CardClass
			                         {
				                         Id = new Guid(SeederConstants.CardClass.SPELL_ID),
				                         Name = new LocalizedText("Spell"),
				                         Image = ImageHelper.GetImageFromFilePath("")
			                         });
			_cardClassRepository.Add(new CardClass
			                         {
				                         Id = new Guid(SeederConstants.CardClass.TANK_ID),
				                         Name = new LocalizedText("Tank"),
				                         Image = ImageHelper.GetImageFromFilePath("")
			                         });
			_cardClassRepository.Add(new CardClass
			                         {
				                         Id = new Guid(SeederConstants.CardClass.TOTEM_ID),
				                         Name = new LocalizedText("Totem"),
				                         Image = ImageHelper.GetImageFromFilePath("")
			                         });
		}
	}
}