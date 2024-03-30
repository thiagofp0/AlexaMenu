namespace AlexaMenu.Api.Models
{
    public class MealApiModel
    {
        public string Name { get; set; } = string.Empty;
        public string Restaurant { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<DishApiModel> Dishes { get; set; } = new();

    }
}
