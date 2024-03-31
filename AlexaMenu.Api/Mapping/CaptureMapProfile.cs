using AlexaMenu.Domain.CommandObject;
using AlexaMenu.Domain.Entities;
using AutoMapper;

namespace AlexaMenu.Api.Mapping
{
    public class CaptureMapProfile : Profile
    {
        public CaptureMapProfile()
        {
            CreateMap<Menu, MenuSaveCommandObject>()
                .ConstructUsing(src => new MenuSaveCommandObject(MapMeals(src.Meals), src.Date))
                .ForAllMembers(opt => opt.Ignore());
        }

        List<Meal> MapMeals(List<Meal> meal)
        {
            return meal.Select(item =>
                new Meal(item.Name, item.Restaurant, item.StartTime, item.EndTime, MapDishes(item.Dishes))).ToList();
        }

        List<Dish> MapDishes(List<Dish> dish)
        {
            return dish.Select(item =>
                new Dish(item.Name, item.Category, item.Note)).ToList();
        }
    }
}
