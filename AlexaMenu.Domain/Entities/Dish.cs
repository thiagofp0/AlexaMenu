using AlexaMenu.Domain.Base.Models;

namespace AlexaMenu.Domain.Entities
{
    public class Dish : Validatable
    {
        public string Name { get; private set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;

        public Dish(string name, string category, string note)
        {
            if (string.IsNullOrWhiteSpace(name))
                AddNotification("Name is required.");
            
            Name = name;
            Category = category ?? string.Empty;
            Note = note ?? string.Empty;
        }
    }
}
