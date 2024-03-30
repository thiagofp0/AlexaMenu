using AlexaMenu.Domain.Base.Models;

namespace AlexaMenu.Domain.Entities
{
    public class Meal : Validatable
    {
        public string Name { get; private set; } = string.Empty;
        public string Restaurant { get; private set; } = string.Empty;
        public DateTime StartTime { get; private set; } 
        public DateTime EndTime { get; private set; }
        public List<Dish> Dishes { get; private set; } = new();

        public Meal(string name, string restaurant, DateTime startTime, DateTime endTime, List<Dish> dishes)
        {
            if (string.IsNullOrWhiteSpace(name))
                AddNotification("Name is required.");
            if (string.IsNullOrWhiteSpace(restaurant))
                AddNotification("Restaurant is required.");
            if (startTime == default)
                AddNotification("Start time is required.");
            if (endTime == default)
                AddNotification("End time is required.");
            if (startTime > endTime)
                AddNotification("Start time must be before end time.");
            if (dishes == null || dishes.Count == 0)
                AddNotification("Dishes are required.");

            Validate();

            Name = name;
            Restaurant = restaurant;
            StartTime = startTime;
            EndTime = endTime;
            Dishes = dishes;
        }
    }
}
