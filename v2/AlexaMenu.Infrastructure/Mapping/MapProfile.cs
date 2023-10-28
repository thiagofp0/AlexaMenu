using AlexaMenu.Domain.Entities;
using AlexaMenu.Infrastructure.Data.Models;
using AutoMapper;

namespace AlexaMenu.Infrastructure.Mapping
{
	public class MapProfile : Profile
	{
		public MapProfile()
		{
			CreateMap<MenuDocumentModel, Menu>()
                .ForMember(destination => destination.Date, cfg => cfg.MapFrom(source => source.Date))
                .ForMember(destination => destination.Meals, cfg => cfg.MapFrom(source => source.Meals))
                .ForMember(destination => destination.Id, cfg => cfg.Ignore());
        }
	}
}
