using AutoMapper;
using SppdDocs.Core.Domain.Entities;
using SppdDocs.DTOs;

namespace SppdDocs.MappingProfiles
{
	public abstract class MappingProfileBase : Profile
	{
		protected IMappingExpression<TEntity, TDto> CreateEntityToDtoMap<TEntity, TDto>()
			where TEntity : BaseEntity
			where TDto : EntityDto
		{
			return CreateMap<TEntity, TDto>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
		}

		protected IMappingExpression<TDto, TEntity> CreateDtoToEntityMap<TDto, TEntity>()
			where TDto : EntityDto
			where TEntity : BaseEntity
		{
			return CreateMap<TDto, TEntity>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
		}

		protected IMappingExpression<TEntity, TDto> CreateVersionedEntityToDtoMap<TEntity, TDto>()
			where TEntity : VersionedEntity
			where TDto : VersionedEntityDto
		{
			return CreateEntityToDtoMap<TEntity, TDto>()
			       .ForMember(dest => dest.VersionId, opt => opt.MapFrom(src => src.Id))
			       .ForMember(dest => dest.VersionComment, opt => opt.MapFrom(src => src.VersionComment))
			       .ForMember(dest => dest.IsCurrent, opt => opt.MapFrom(src => src.IsCurrent))
			       .ForMember(dest => dest.EntityId, opt => opt.MapFrom(src => src.EntityId));
		}

		protected IMappingExpression<TDto, TEntity> CreateVersionedDtoToEntityMap<TDto, TEntity>()
			where TDto : VersionedEntityDto
			where TEntity : VersionedEntity
		{
			return CreateDtoToEntityMap<TDto, TEntity>()
			       .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.VersionId))
			       .ForMember(dest => dest.VersionComment, opt => opt.MapFrom(src => src.VersionComment))
			       .ForMember(dest => dest.IsCurrent, opt => opt.MapFrom(src => src.IsCurrent))
			       .ForMember(dest => dest.EntityId, opt => opt.MapFrom(src => src.EntityId));
		}
	}
}