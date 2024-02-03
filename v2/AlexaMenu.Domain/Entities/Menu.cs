using AlexaMenu.Domain.Base.Models;

namespace AlexaMenu.Domain.Entities
{
    public class Menu : Validatable
    {
        public DateTime Date { get; private set; }
        public List<Meal> Meals { get; private set; }

        public Menu(DateTime date, List<Meal> meals)
        {
            if (date == default)
                AddNotification("Date is required.");
            if (meals == null || !meals.Any())
            {
                AddNotification("Meals are required.");
                meals = new();
            }

            Validate();
            
            Date = date;
            Meals = meals;
        }
    }
}
