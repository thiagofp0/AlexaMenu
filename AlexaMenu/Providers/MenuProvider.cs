using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using AlexaMenu.Domain;
using AlexaMenu.Interfaces;
using AlexaMenu.Models;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JsonConverter = Newtonsoft.Json.JsonConverter;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace AlexaMenu.Providers
{
    public class MenuProvider : IMenuProvider
    {
        private static ClientBuilder client = new ClientBuilder();
        
        private static Menu currentMenu;
        private static Menu lastMenu;
        private static Menu nextMenu;
        
        public async Task<object> RequestMenu(DateTime date)
        {
            if (currentMenu == null || lastMenu == null || nextMenu == null)
            {
                HttpContent httpContent = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("data_selecionada", date.ToString("dd/MM/yyyy"))
                });
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                
                var response = await client.PostAsync(client.BaseAddress, httpContent);
                var content = await response.Content.ReadAsStringAsync();
                var jsonContent = JObject.Parse(content);
                Menu menu = new Menu();

                if (jsonContent.ContainsKey("retorno") && jsonContent["retorno"].ToString() == "false")
                {
                    return "Não foi possível encontrar o menu para a data selecionada.";
                    menu = JsonConvert.DeserializeObject<Menu>(jsonContent["dados"].ToString());
                }

                return menu;
            }

            return null;
        }

        public Menu GetCurrentMenu()
        {
            this.RequestMenu(DateTime.Now);
            return new Menu();
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