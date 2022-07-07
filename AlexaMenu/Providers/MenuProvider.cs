using System.Net.Http.Headers;
using AlexaMenu.Domain;
using AlexaMenu.Interfaces;
using AlexaMenu.Models;
using AlexaMenu.Utils;
using Newtonsoft.Json;

namespace AlexaMenu.Providers
{
    public class MenuProvider : IMenuProvider
    {
        private static ClientBuilder client = new ClientBuilder();
        
        public async Task<ApiContent> RequestMenu(DateTime date)
        {
            if (date >= DateTime.Today)
            {
                HttpContent httpContent = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("data_selecionada", date.ToString("dd/MM/yyyy"))
                });
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                
                var response = await client.PostAsync(client.BaseAddress, httpContent);
                var content = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<ApiContent>(content);
                
                return json;
            }
            return null;
        }

        public Menu GetCurrentMenu()
        {
            var response = RequestMenu(DateTime.Now);
            Menu menu = MenuUtils.BuildMenu(response);
            
            return menu;
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