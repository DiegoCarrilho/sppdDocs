using System.Linq;
using SppdDocs.Core.Domain.Objects;
using SppdDocs.DTOs;

namespace SppdDocs.MappingProfiles
{
	internal class CardUpgradeLevelInfoMappingProfile : MappingProfileBase
	{
		public CardUpgradeLevelInfoMappingProfile()
		{
			CreateMap<CardUpgradeLevelInfo, CardUpgradeDto>()
				.ForMember(dest => dest.InternalUpgradeLevel, opt => opt.MapFrom(src => src.InternalUpgradeLevel))
				.ForMember(dest => dest.Level, opt => opt.MapFrom(src => src.Level))
				.ForMember(dest => dest.UpgradeLevel, opt => opt.MapFrom(src => src.UpgradeLevel.CurrentUpgradeLevel))
				.ForMember(dest => dest.MaximumUpgradeLevelInLevel, opt => opt.MapFrom(src => src.UpgradeLevel.MaximumUpgradeLevelInLevel))
				.ForMember(dest => dest.IsLevelUpgrade, opt => opt.MapFrom(src => src.IsLevelUpgrade))
				.ForMember(dest => dest.AttributeValues, opt => opt.MapFrom(src => src.AttributeValues.ToDictionary(k => k.Key.Id, k => k.Value)))
				.ForMember(dest => dest.AttributeUpgradeValues, opt => opt.MapFrom(src => src.AttributeUpgrades.ToDictionary(k => k.Key.Id, k => k.Value)));
		}
	}
}