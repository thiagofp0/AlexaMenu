using System;
using System.Linq;
using System.Threading.Tasks;
using AlexaMenu.Models;

public class MenuUtils
{
    public static Menu BuildMenu(Task<ApiContent> content)
    {
        Menu menu = new Menu();
        menu.Date = DateTime.Now;
        var groups = content.Result.dados.GroupBy(x => x.refeicao_id);
        foreach (var group in groups)
        {
            Meal meal = new Meal();
            meal.Id = group.Key;
            meal.Name = group.First().refeicao;
            meal.Restaurant = group.First().Refeitorio;
            
            if (group.First().data.DayOfWeek == DayOfWeek.Saturday || group.First().data.DayOfWeek == DayOfWeek.Sunday)
            {
                meal.StartTime = group.First().Horario_inicio_finaldeSemana;
                meal.EndTime = group.First().Horario_fim_finaldeSemana;
            }
            else
            {
                meal.StartTime = group.First().horario_inicio;
                meal.EndTime = group.First().horario_fim;
            }
            
            foreach (var item in group)
            {
                Dish dish = new Dish();
                dish.Name = item.composicao;
                dish.Category = item.categoria;
                dish.Note = item.obs_composicao;
                meal.Dishes.Add(dish);
            }
            
            menu.Meals.Add(meal);
        }

        return menu;
    }
}