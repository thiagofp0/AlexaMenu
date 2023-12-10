using System.Net.Http.Headers;
using AlexaMenu.Domain.Entities;
using AlexaMenu.Domain.Interfaces;
using AlexaMenu.Infrastructure.Configuration;
using System.Text.Json;
using AlexaMenu.Infrastructure.Data.Models;

namespace AlexaMenu.Infrastructure.Service
{
    public class UniversityService : IUniversityService
    {
        private static readonly ClientBuilder client = new();
        public async Task<Menu> GetMenu(DateTime date)
        {
            HttpContent httpContent = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
            {
                new("data_selecionada", date.ToString("dd/MM/yyyy"))
            });

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

            var response = await client.PostAsync(client.BaseAddress, httpContent);
            var content = await response.Content.ReadAsStringAsync();
            var json = JsonSerializer.Deserialize<ApiContentModel>(content);

            // Reorganizar essa função
            // Fazer o mapping e retornar o menu

            return new Menu(DateTime.Now, new List<Meal>());
        }
    }
}
