using AlexaMenu.Domain.Base.Exceptions;
using AlexaMenu.Domain.CommandObject;
using AlexaMenu.Domain.Entities;

namespace AlexaMenu.Domain.UnitTests
{
    public class CommandObjectTests
    {
        [Fact]
        public void NewMenuSaveCommandObject_AllOK()
        {
            var dishes = new List<Dish>
            {
                new("Almôndega", "Carne", ""),
                new("Arroz", "Acompanhamento", ""),
                new("Feijão", "Acompanhamento", ""),
                new("Salada", "Acompanhamento", "")
            };

            var meals = new List<Meal>
            {
                new("Almoço", "Restaurante", DateTime.Now, DateTime.Now.AddHours(1), dishes)
            };

            var menuSaveCommandObject = new MenuSaveCommandObject(meals, DateTime.Now);

            Assert.True(menuSaveCommandObject.Validated);
        }

        [Theory]
        [InlineData(null, null)]
        public void NewMenuSaveCommandObject_AllInvalid(List<Meal> meals, DateTime date)
        {
            Assert.Throws<InvalidDomainStateException>(() => new MenuSaveCommandObject(meals, date));
        }
    }
}
