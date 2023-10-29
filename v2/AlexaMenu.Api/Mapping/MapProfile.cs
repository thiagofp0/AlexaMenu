using AlexaMenu.Api.Models;
using AlexaMenu.Domain.CommandObject;
using AlexaMenu.Domain.Entities;
using AutoMapper;

namespace AlexaMenu.Api.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Dish, DishApiModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.Note, opt => opt.MapFrom(src => src.Note));

            CreateMap<Meal, MealApiModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Restaurant, opt => opt.MapFrom(src => src.Restaurant))
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartTime))
                .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndTime))
                .ForMember(dest => dest.Dishes, opt => opt.MapFrom(src => src.Dishes));
            
            CreateMap<Menu, MenuApiModel>()
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.Meals, opt => opt.MapFrom(src => src.Meals));

            CreateMap<DishApiModel, Dish>();
            CreateMap<MealApiModel, Meal>();
            CreateMap<MenuApiModel, Menu>();

            CreateMap<MenuApiModel, MenuSaveCommandObject>()
                .ConstructUsing(src => new MenuSaveCommandObject(MapMeals(src.Meals), src.Date))
                .ForAllMembers(opt => opt.Ignore());
        }
        List<Meal> MapMeals(List<MealApiModel> mealApiModel)
        {
            return mealApiModel.Select(item =>
                new Meal(item.Name, item.Restaurant, item.StartTime, item.EndTime, MapDishes(item.Dishes))).ToList();
        }

        List<Dish> MapDishes(List<DishApiModel> dishApiModel)
        {
            return dishApiModel.Select(item =>
                new Dish(item.Name, item.Category, item.Note)).ToList();
        }
    }
}
