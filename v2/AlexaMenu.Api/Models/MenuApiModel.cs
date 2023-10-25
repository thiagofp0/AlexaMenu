using AlexaMenu.Domain.Entities;

namespace AlexaMenu.Api.Models
{
    public class MenuApiModel
    {
        public DateTime Date { get; set; }
        public List<Meal> Meals { get; set; } = new();
    }
}
