using AlexaMenu.Domain.Entities;
using AlexaMenu.Infrastructure.Data.Models;

namespace AlexaMenu.Infrastructure.Mapping
{
    public class MappingUtils
    {
        public static Menu BuildMenu(ApiContentModel content)
        {
            var groups = content.Dados.GroupBy(x => x.refeicao_id);
            var meals = new List<Meal>();
            //Tem coisa errada aqui. Só debugar que entenderemos
            //Basicamente estamos tratando Dish como meal
            
            foreach (var group in groups)
            {
                meals.Add(GetMealfromGroup(group));
            }

            var menu = new Menu(groups.First().First().data, meals);

            return menu;
        }
        private static Tuple<DateTime, DateTime> GetMealTime(ApiDataObject group)
        {
            var startTime = new DateTime();
            var endTime = new DateTime();

            if (group.data.DayOfWeek == DayOfWeek.Saturday || group.data.DayOfWeek == DayOfWeek.Sunday)
            {
                startTime = group.Horario_inicio_finaldeSemana;
                endTime = group.Horario_fim_finaldeSemana;
            }
            else
            {
                startTime = group.horario_inicio;
                endTime = group.horario_fim;
            }
            return new Tuple<DateTime, DateTime>(startTime, endTime);
        }

        private static Meal GetMealfromGroup(IGrouping<int, ApiDataObject> group)
        {
            var first = group.First();
            var dates = GetMealTime(first);

            var meal = new Meal(
                first.refeicao,
                first.Refeitorio,
                dates.Item1,
                dates.Item2,
                GetDishesFromMeal(group)
                );

            return meal;
        }

        private static List<Dish> GetDishesFromMeal(IGrouping<int, ApiDataObject> group)
        {
            var dishes = new List<Dish>();
            foreach(var item in group)
            {
                var dish = new Dish(
                        item.composicao,
                        item.categoria,
                        item.obs_composicao
                    );
                dishes.Add(dish);
            }
            return dishes;
        }
    }
}
