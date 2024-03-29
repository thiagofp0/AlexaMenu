namespace AlexaMenu.Domain.Models
{
    public class Menu
    {
        public DateTime Date { get; set; }
        public List<Meal> Meals { get; set; }

        public Menu()
        {
            this.Date = DateTime.Now;
            this.Meals = new List<Meal>(new Meal[0]);
        }
    }
}