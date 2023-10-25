using AlexaMenu.Api.Models;
using AlexaMenu.Domain.Entities;
using AutoMapper;

namespace AlexaMenu.Api.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Menu, MenuApiModel>()
                .ForMember(destination => destination.Meals, cfg => cfg.MapFrom(source => source.Meals))
                .ForMember(destination => destination.Date, cfg => cfg.MapFrom(source => source.Date));
        }
    }
}
