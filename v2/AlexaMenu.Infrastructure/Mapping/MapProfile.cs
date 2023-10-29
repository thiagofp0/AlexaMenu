using AlexaMenu.Domain.CommandObject;
using AlexaMenu.Domain.Entities;
using AlexaMenu.Infrastructure.Data.Models;
using AutoMapper;

namespace AlexaMenu.Infrastructure.Mapping
{
	public class MapProfile : Profile
	{
		public MapProfile()
		{
            CreateMap<MenuDocumentModel, Menu>().ForMember(destination => destination.Id, cfg => cfg.Ignore());

            CreateMap<MenuSaveCommandObject, MenuDocumentModel>()
                .ForMember(destination => destination.Date, cfg => cfg.MapFrom(source => source.Date.ToShortDateString()))
                .ForMember(destination => destination.Meals, cfg => cfg.MapFrom(source => MapMeals(source.Meals)))
                .ForMember(destination => destination.Id, cfg => cfg.Ignore());
        }

        List<MealDocumentModel> MapMeals(List<Meal> meals)
        {
            return meals.Select(item =>
            new MealDocumentModel
            {
                Name = item.Name,
                Restaurant = item.Restaurant,
                StartTime = item.StartTime,
                EndTime = item.EndTime,
                Dishes = MapDishes(item.Dishes)
            }).ToList();
        }

        List<DishDocumentModel> MapDishes(List<Dish> dishes)
        {
            return dishes.Select(item =>
            new DishDocumentModel
            {
                Name = item.Name,
                Category = item.Category,
                Note = item.Note
            }).ToList();
        }
    }
}
