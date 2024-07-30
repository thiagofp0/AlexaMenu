using AlexaMenu.Domain.Base.Models;
using AlexaMenu.Domain.Entities;

namespace AlexaMenu.Domain.CommandObject
{
    public class MenuSaveCommandObject : Validatable
    {
        public DateTime Date { get; set; }
        public List<Meal> Meals { get; set; }

        public MenuSaveCommandObject(List<Meal> meals, DateTime date)
        {
            if (meals == null || meals.Count == 0)
                AddNotification("Meals list can't be empty");
            
            if (string.IsNullOrEmpty(date.ToString()))
                AddNotification("Date can't be empy");

            Validate();
            
            Meals = meals!;
            Date = date;
        }
    }
}
