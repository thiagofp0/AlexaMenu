using System.Net.Http.Headers;
using AlexaMenu.Domain;
using AlexaMenu.Domain.Models;
using AlexaMenu.Interfaces;
using Newtonsoft.Json;
using AlexaMenu.Repositories;
namespace AlexaMenu.Providers
{
    public class MenuProvider : IMenuProvider
    {
        private static Menu menu;
        private readonly IMenuRepository _menuRepository;
        public MenuProvider(IMenuRepository? menuRepository)
        {
            if (menuRepository == null)
            {
                menuRepository = new MenuRepository();
            }
            _menuRepository = menuRepository;
            if(menu == null || menu.Date != DateTime.Today)
            {
                menu = _menuRepository.GetMenu(DateTime.Now);
            }
        }
       public string GetCurrentMenu()
        {
            string breakfest = menu.Meals.Where(x => x.Id == 3).First().Dishes[4].Name;
            string lunch = menu.Meals.Where(x => x.Id == 4).First().Dishes.Where(x => x.Category.Equals("PRATO PRINCIPAL")).First().Name.TrimEnd();
            string dinner = menu.Meals.Where(x => x.Id == 5).First().Dishes.Where(x => x.Category.Equals("PRATO PRINCIPAL")).First().Name.TrimEnd();
            
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