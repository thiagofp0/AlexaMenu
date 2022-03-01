using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using AlexaMenu.Domain;
using AlexaMenu.Interfaces;
using AlexaMenu.Models;

namespace AlexaMenu.Providers
{
    public class MenuProvider : IMenuProvider
    {
        private static HttpClient client = new ClientBuilder();
        
        private static Menu currentMenu;
        private static Menu lastMenu;
        private static Menu nextMenu;
        
        public MenuProvider()
        {
            Init();
        }
        public async Task Init()
        {
            
            if (currentMenu == null || lastMenu == null || nextMenu == null)
            {
                var objeto = new {data_selecionada = DateTime.Today};
                var response = await client.PostAsJsonAsync(client.BaseAddress, objeto);
            }
        }

        public Menu GetCurrentMenu()
        {
            throw new NotImplementedException();
        }

        public Menu GetNextMenu()
        {
            throw new NotImplementedException();
        }

        public Menu GetLastMenu()
        {
            throw new NotImplementedException();
        }

        public Menu GetMenu(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Meal GetMeal(int mealCode, DateTime date)
        {
            throw new NotImplementedException();
        }

        public Dish GetMainDish(int mealCode, DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}