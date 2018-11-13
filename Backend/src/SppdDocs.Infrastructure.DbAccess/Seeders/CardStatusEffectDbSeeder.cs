using System;

using SppdDocs.Core.Domain.Entities;
using SppdDocs.Core.Domain.Objects;
using SppdDocs.Core.Repositories;
using SppdDocs.Infrastructure.DbAccess.Utils.Extensions;

namespace SppdDocs.Infrastructure.DbAccess.Seeders
{
    internal class CardStatusEffectDbSeeder : IDbSeeder
    {
        private readonly IRepository<CardStatusEffect> _cardStatusEffectRepository;

        public CardStatusEffectDbSeeder(IRepository<CardStatusEffect> cardStatusEffectRepository)
        {
            _cardStatusEffectRepository = cardStatusEffectRepository;
        }

        public int Priority => SeederConstants.DbSeederPriority.BASE_DATA;

        public void Seed()
        {
            _cardStatusEffectRepository.Add(new CardStatusEffect
                                            {
                                                Id = new Guid(SeederConstants.CardStatusEffect.FREEZE_ID),
                                                Name = new LocalizedText("Freeze")
                                            }.SetDefaultSeederProperties());
            _cardStatusEffectRepository.Add(new CardStatusEffect
                                            {
                                                Id = new Guid(SeederConstants.CardStatusEffect.POISON_ID),
                                                Name = new LocalizedText("Poison")
                                            }.SetDefaultSeederProperties());
            _cardStatusEffectRepository.Add(new CardStatusEffect
                                            {
                                                Id = new Guid(SeederConstants.CardStatusEffect.MIND_CONTROL_ID),
                                                Name = new LocalizedText("Mind Control")
                                            }.SetDefaultSeederProperties());
            _cardStatusEffectRepository.Add(new CardStatusEffect
                                            {
                                                Id = new Guid(SeederConstants.CardStatusEffect.BUFF_DEBUFF_ID),
                                                Name = new LocalizedText("Buff/Debuff")
                                            }.SetDefaultSeederProperties());
            _cardStatusEffectRepository.Add(new CardStatusEffect
                                            {
                                                Id = new Guid(SeederConstants.CardStatusEffect.TAUNT_ID),
                                                Name = new LocalizedText("Taunt")
                                            }.SetDefaultSeederProperties());
        }
    }
}