using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AlexaMenu.Domain;
using AlexaMenu.Interfaces;
using AlexaMenu.Models;
using Newtonsoft.Json;

namespace AlexaMenu.Providers
{
    public class MenuProvider : IMenuProvider
    {
        private static Menu menu;
        private static ClientBuilder client = new ClientBuilder();
        
        public MenuProvider()
        {
            if(menu == null || menu.Date != DateTime.Today)
            {
                Task<ApiContent> response = RequestMenu(DateTime.Now);
                menu = MenuUtils.BuildMenu(response);
            }
        }
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

        public string GetCurrentMenuOutput()
        {
            Menu menu = GetCurrentMenu();
            
            string breakfest = menu.Meals.Where(x => x.Id == 3).First().Dishes[4].Name;
            string lunch = menu.Meals.Where(x => x.Id == 4).First().Dishes.Where(x => x.Category.Equals("PRATO PRINCIPAL")).First().Name;
            string dinner = menu.Meals.Where(x => x.Id == 5).First().Dishes.Where(x => x.Category.Equals("PRATO PRINCIPAL")).First().Name;
            
            if (menu.Meals.Count > 3)
            {
                string snackBreadStuffing = menu.Meals.Where(x => x.Id == 6).First().Dishes.Where(x => x.Category.Equals("RECHEIO PARA PÃO")).First().Name;
                string snackSoup = menu.Meals.Where(x => x.Id == 6).First().Dishes.Where(x => x.Category.Equals("SOPA")).First().Name;
                return $"Hoje no café teremos {breakfest}. No Almoço o prato principal é {lunch}. No jantar, o prato é {dinner}. Já no lanche o recheio do pão é {snackBreadStuffing} e a sopa é {snackSoup}.";
            }
            
            return $"Hoje no café teremos {breakfest}. No Almoço o prato principal é {lunch}. No jantar, o prato é {dinner}";
        }
    }
}