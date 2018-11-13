using System;
using SppdDocs.Core.Domain.Entities;
using SppdDocs.Core.Domain.Objects;
using SppdDocs.Core.Repositories;
using SppdDocs.Infrastructure.DbAccess.Utils.Extensions;
using SppdDocs.Infrastructure.DbAccess.Utils.Helpers;

namespace SppdDocs.Infrastructure.DbAccess.Seeders
{
    internal class RarityDbSeeder : IDbSeeder
    {
        private readonly IRepository<Rarity> _rarityRepository;

        public RarityDbSeeder(IRepository<Rarity> rarityRepository)
        {
            _rarityRepository = rarityRepository;
        }

        public int Priority => SeederConstants.DbSeederPriority.BASE_DATA;

        public void Seed()
        {
            _rarityRepository.Add(new Rarity
                                  {
                                      Id = new Guid(SeederConstants.Rarity.COMMON_ID),
                                      Name = new LocalizedText("Common")
                                  }.SetDefaultSeederProperties());
            _rarityRepository.Add(new Rarity
                                  {
                                      Id = new Guid(SeederConstants.Rarity.RARE_ID),
                                      Name = new LocalizedText("Rare")
                                  }.SetDefaultSeederProperties());
            _rarityRepository.Add(new Rarity
                                  {
                                      Id = new Guid(SeederConstants.Rarity.EPIC_ID),
                                      Name = new LocalizedText("Epic")
                                  }.SetDefaultSeederProperties());
            _rarityRepository.Add(new Rarity
                                  {
                                      Id = new Guid(SeederConstants.Rarity.LEGENDARY_ID),
                                      Name = new LocalizedText("Legendary")
                                  }.SetDefaultSeederProperties());
        }
    }
}