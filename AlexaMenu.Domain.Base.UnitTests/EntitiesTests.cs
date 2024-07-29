using AlexaMenu.Domain.Base.Exceptions;
using AlexaMenu.Domain.Entities;

namespace AlexaMenu.Domain.UnitTests
{
    public class EntitiesTests
    {
        [Fact]
        public void NewDish_AllOK()
        {
            var dish = new Dish("Almôndega", "Carne", "");
            Assert.True(dish.Validated);
        }

        [Theory]
        [InlineData("", "", "")]
        [InlineData("", "Carne", "Teste")]
        public void NewDish_AllInvalid(string name, string category, string note)
        {
            var dish = new Dish(name, category, note);
            Assert.False(dish.Validated);
        }

        [Fact]
        public void NewMeal_Valid()
        {
            var dishes = new List<Dish>
            {
                new("Almôndega", "Carne", ""),
                new("Arroz", "Acompanhamento", ""),
                new("Feijão", "Acompanhamento", ""),
                new("Salada", "Acompanhamento", "")
            };

            var meal = new Meal("Almoço", "Restaurante", DateTime.Now, DateTime.Now.AddHours(1), dishes);

            Assert.True(meal.Validated);
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("", "Restaurante")]
        [InlineData("Almoço", "")]
        public void NewMeal_AllInvalid(string name, string restaurant)
        {
            var dishes = new List<Dish>
            {
                new("Almôndega", "Carne", ""),
                new("Arroz", "Acompanhamento", ""),
                new("Feijão", "Acompanhamento", ""),
                new("Salada", "Acompanhamento", "")
            };

            Assert.Throws<InvalidDomainStateException>(() => new Meal(name, restaurant, DateTime.Now, DateTime.Now, dishes));
        }

        [Fact]
        public void NewMenu_Valid()
        {
            var dishes = new List<Dish>
            {
                new("Almôndega", "Carne", ""),
                new("Arroz", "Acompanhamento", ""),
                new("Feijão", "Acompanhamento", ""),
                new("Salada", "Acompanhamento", "")
            };

            var meal = new Meal("Almoço", "Restaurante", DateTime.Now, DateTime.Now.AddHours(1), dishes);
            var meals = new List<Meal> { meal };
            var menu = new Menu(DateTime.Now, meals);

            Assert.True(menu.Validated);
        }

        [Fact]
        public void NewMenu_Invalid()
        {
            Assert.Throws<InvalidDomainStateException>(() => new Menu(DateTime.Now, new List<Meal>()));
        }
    }
}