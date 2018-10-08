using System;
using SppdDocs.Core.Domain.Entities;
using SppdDocs.Core.Domain.Repositories;
using SppdDocs.Infrastructure.DbAccess.Utils;

namespace SppdDocs.Infrastructure.DbAccess.Seeder
{
	internal class RarityDbSeeder : IDbSeeder
	{
		private readonly IRepository<Rarity> _rarityRepository;

		public RarityDbSeeder(IRepository<Rarity> rarityRepository)
		{
			_rarityRepository = rarityRepository;
		}

		public int Priority => 90;

		public void Seed()
		{
			_rarityRepository.Add(new Rarity
			                      {
				                      Id = new Guid(SeederConstants.Rarity.COMMON_ID),
				                      Name = "Common",
				                      Image = ImageHelper.GetImageFromFilePath("")
			});
			_rarityRepository.Add(new Rarity
			                      {
				                      Id = new Guid(SeederConstants.Rarity.RARE_ID),
				                      Name = "Rare",
				                      Image = ImageHelper.GetImageFromFilePath("")
			});
			_rarityRepository.Add(new Rarity
			                      {
				                      Id = new Guid(SeederConstants.Rarity.EPIC_ID),
				                      Name = "Epic",
				                      Image = ImageHelper.GetImageFromFilePath("")
			});
			_rarityRepository.Add(new Rarity
			                      {
				                      Id = new Guid(SeederConstants.Rarity.LEGENDARY_ID),
				                      Name = "Legendary",
				                      Image = ImageHelper.GetImageFromFilePath("")
			});
		}
	}
}