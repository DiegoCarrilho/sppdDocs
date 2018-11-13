using System;

using SppdDocs.Core.Domain.Entities;
using SppdDocs.Core.Domain.Objects;
using SppdDocs.Core.Repositories;
using SppdDocs.Infrastructure.DbAccess.Utils.Extensions;

namespace SppdDocs.Infrastructure.DbAccess.Seeders
{
    internal class CardClassDbSeeder : IDbSeeder
    {
        private readonly IRepository<CardClass> _cardClassRepository;

        public CardClassDbSeeder(IRepository<CardClass> cardClassRepository)
        {
            _cardClassRepository = cardClassRepository;
        }

        public int Priority => SeederConstants.DbSeederPriority.BASE_DATA;

        public void Seed()
        {
            _cardClassRepository.Add(new CardClass
                                     {
                                         Id = new Guid(SeederConstants.CardClass.FIGHTER_ID),
                                         Name = new LocalizedText("Fighter")
                                     }.SetDefaultSeederProperties());
            _cardClassRepository.Add(new CardClass
                                     {
                                         Id = new Guid(SeederConstants.CardClass.ASSASSIN_ID),
                                         Name = new LocalizedText("Assassin")
                                     }.SetDefaultSeederProperties());
            _cardClassRepository.Add(new CardClass
                                     {
                                         Id = new Guid(SeederConstants.CardClass.RANGED_ID),
                                         Name = new LocalizedText("Ranged")
                                     }.SetDefaultSeederProperties());
            _cardClassRepository.Add(new CardClass
                                     {
                                         Id = new Guid(SeederConstants.CardClass.SPELL_ID),
                                         Name = new LocalizedText("Spell")
                                     }.SetDefaultSeederProperties());
            _cardClassRepository.Add(new CardClass
                                     {
                                         Id = new Guid(SeederConstants.CardClass.TANK_ID),
                                         Name = new LocalizedText("Tank")
                                     }.SetDefaultSeederProperties());
            _cardClassRepository.Add(new CardClass
                                     {
                                         Id = new Guid(SeederConstants.CardClass.TOTEM_ID),
                                         Name = new LocalizedText("Totem")
                                     }.SetDefaultSeederProperties());
        }
    }
}