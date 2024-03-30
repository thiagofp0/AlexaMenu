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
            CreateMap<MenuDocumentModel, Menu>().ForMember(destination => destination.Id, cfg => cfg.Ignore())
                .ForMember(destination => destination.Date, cfg => cfg.MapFrom(source => DateTime.Parse(source.Date)))
                .ForMember(destination => destination.Meals, cfg => cfg.MapFrom(source => MapMealDocumentModelToMeal(source.Meals)));

            CreateMap<MealDocumentModel, Meal>().ForMember(destination => destination.Id, cfg => cfg.Ignore())
                .ForMember(destination => destination.StartTime, cfg => cfg.MapFrom(source => source.StartTime))
                .ForMember(destination => destination.EndTime, cfg => cfg.MapFrom(source => source.EndTime))
                .ForMember(destination => destination.Dishes, cfg => cfg.MapFrom(source => MapDishDocumentObjectToDish(source.Dishes)));

            CreateMap<DishDocumentModel, Dish>().ForMember(destination => destination.Id, cfg => cfg.Ignore());

            CreateMap<MenuSaveCommandObject, MenuDocumentModel>()
                .ForMember(destination => destination.Date, cfg => cfg.MapFrom(source => source.Date.ToShortDateString()))
                .ForMember(destination => destination.Meals, cfg => cfg.MapFrom(source => MapMealApiModelMealsToDocumentModel(source.Meals)))
                .ForMember(destination => destination.Id, cfg => cfg.Ignore());
        }
        static List<MealDocumentModel> MapMealApiModelMealsToDocumentModel(List<Meal> meals)
        {
            return meals.Select(item =>
            new MealDocumentModel
            {
                Name = item.Name,
                Restaurant = item.Restaurant,
                StartTime = item.StartTime,
                EndTime = item.EndTime,
                Dishes = MapDishApiModelDishToDocumentModel(item.Dishes)
            }).ToList();
        }

        static List<DishDocumentModel> MapDishApiModelDishToDocumentModel(List<Dish> dishes)
        {
            return dishes.Select(item =>
            new DishDocumentModel
            {
                Name = item.Name,
                Category = item.Category,
                Note = item.Note
            }).ToList();
        }

        static List<Meal> MapMealDocumentModelToMeal(List<MealDocumentModel> meals)
        {
            return meals.Select(item =>
            new Meal(item.Name, item.Restaurant, item.StartTime, item.EndTime, MapDishDocumentObjectToDish(item.Dishes))).ToList();
        }

        static List<Dish> MapDishDocumentObjectToDish(List<DishDocumentModel> dishes)
        {
            return dishes.Select(item =>
            new Dish(item.Name, item.Category, item.Note)).ToList();
        }
    }
}
