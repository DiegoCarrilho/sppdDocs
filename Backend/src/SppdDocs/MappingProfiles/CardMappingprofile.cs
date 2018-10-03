using SppdDocs.Core.Domain.Entities;
using SppdDocs.DTOs;

namespace SppdDocs.MappingProfiles
{
	public class CardMappingProfile : MappingProfileBase
	{
		public CardMappingProfile()
		{
			CreateVersionedEntityToDtoMap<Card, CardFullDto>()
				.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
				.ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

			CreateVersionedDtoToEntityMap<CardFullDto, Card>()
				.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
				.ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
		}
	}
}