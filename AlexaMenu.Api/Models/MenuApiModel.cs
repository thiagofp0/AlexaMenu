namespace AlexaMenu.Api.Models
{
    public class MenuApiModel
    {
        public DateTime Date { get; set; }
        public List<MealApiModel> Meals { get; set; } = new();
    }
}
