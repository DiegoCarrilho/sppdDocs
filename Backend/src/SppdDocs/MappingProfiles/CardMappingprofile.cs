using SppdDocs.Core.Domain.Entities;
using SppdDocs.DTOs;

namespace SppdDocs.MappingProfiles
{
	internal class CardMappingProfile : MappingProfileBase
	{
		public CardMappingProfile()
		{
			// TODO: Map to correct user language
			CreateVersionedEntityToDtoMap<Card, CardFullDto>()
				.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.En))
				.ForMember(dest => dest.DescriptionMarkdown, opt => opt.MapFrom(src => src.DescriptionMarkdown.En))
				.ForMember(dest => dest.DescriptionOnCard, opt => opt.MapFrom(src => src.DescriptionOnCard.En))
				.ForMember(dest => dest.EnergyCost, opt => opt.MapFrom(src => src.EnergyCost))
				.ForMember(dest => dest.UnlockedAtRank, opt => opt.MapFrom(src => src.UnlockedAtRank))
				.ForMember(dest => dest.Range, opt => opt.MapFrom(src => src.Range))
				.ForMember(dest => dest.ThemeName, opt => opt.MapFrom(src => src.Theme.Name.En))
				.ForMember(dest => dest.RarityName, opt => opt.MapFrom(src => src.Rarity.Name.En))
				.ForMember(dest => dest.ClassName, opt => opt.MapFrom(src => src.Class.Name.En))
				.ForMember(dest => dest.EffectName, opt => opt.MapFrom(src => src.EffectId.HasValue ? src.Effect.Name.En : null))
				.ForMember(dest => dest.StatusEffectName, opt => opt.MapFrom(src => src.StatusEffectId.HasValue ? src.StatusEffect.Name.En : null))
				.ForMember(dest => dest.CardUpgrades, opt => opt.MapFrom(src => src.UpgradeLevels))
				.ForMember(dest => dest.CardAttributes, opt => opt.MapFrom(src => src.CardAttributes));
		}
	}
}