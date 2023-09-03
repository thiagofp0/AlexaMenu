using System.Net.Http.Headers;
using AlexaMenu.Domain;
using AlexaMenu.Domain.Models;
using Newtonsoft.Json;

namespace AlexaMenu.Interfaces;

public interface IMenuRepository
{
    private static ClientBuilder client = new ClientBuilder();
    protected static async Task<ApiContent> RequestMenu(DateTime date)
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
    public Menu GetMenu(DateTime date);
}