using SppdDocs.Core.Domain.Entities;
using SppdDocs.DTOs;

namespace SppdDocs.MappingProfiles
{
    internal class NamedEntityMappingProfile : MappingProfileBase
    {
        public NamedEntityMappingProfile()
        {
            // TODO: Map to correct user language
            CreateVersionedEntityToDtoMap<NamedEntity, NamedDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.En));
        }
    }
}