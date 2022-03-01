using System;
using System.Threading.Tasks;
using AlexaMenu.Models;

namespace AlexaMenu.Interfaces
{
    public interface IMenuProvider
    {
        public Task Init();
        public Menu GetCurrentMenu();
        public Menu GetNextMenu();
        public Menu GetLastMenu();
        public Menu GetMenu(DateTime date);
        public Meal GetMeal(int mealCode, DateTime date);
        public Dish GetMainDish(int mealCode, DateTime date);
    }
}