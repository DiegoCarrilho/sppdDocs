using System;

using SppdDocs.Core.Domain.Entities;
using SppdDocs.Core.Domain.Objects;
using SppdDocs.Core.Repositories;
using SppdDocs.Infrastructure.DbAccess.Utils.Extensions;

namespace SppdDocs.Infrastructure.DbAccess.Seeders
{
    internal class CardCastAreaDbSeeder : IDbSeeder
    {
        private readonly IRepository<CardCastArea> _cardCastAreaRepository;

        public CardCastAreaDbSeeder(IRepository<CardCastArea> cardCastAreaRepository)
        {
            _cardCastAreaRepository = cardCastAreaRepository;
        }

        public int Priority => SeederConstants.DbSeederPriority.BASE_DATA;

        public void Seed()
        {
            _cardCastAreaRepository.Add(new CardCastArea
                                        {
                                            Id = new Guid(SeederConstants.CardCastArea.ANYWHERE_ID),
                                            Name = new LocalizedText("Anywhere")
                                        }.SetDefaultSeederProperties());
            _cardCastAreaRepository.Add(new CardCastArea
                                        {
                                            Id = new Guid(SeederConstants.CardCastArea.OWN_SIDE_ID),
                                            Name = new LocalizedText("Own Side")
                                        }.SetDefaultSeederProperties());
        }
    }
}