using System;
using System.Net.Http;

namespace AlexaMenu.Domain
{
    public class ClientBuilder : HttpClient
    {
        public ClientBuilder()
        {
            HttpClient client = new HttpClient();
            
            client.BaseAddress = new Uri(Constants.BaseAddress);
            
            client.DefaultRequestHeaders.Add("Host", "cardapio.ufv.br");
            client.DefaultRequestHeaders.Add("Accept", "application/json, text/javascript, */*; q=0.01");
            client.DefaultRequestHeaders.Add("Accept-Language", "pt-BR,pt;q=0.8,en-US;q=0.5,en;q=0.3");
            client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate");
            client.DefaultRequestHeaders.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");
            client.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");
            client.DefaultRequestHeaders.Add("Content-Length", "31");
            client.DefaultRequestHeaders.Add("Origin", "http://cardapio.ufv.br");
            client.DefaultRequestHeaders.Add("Connection", "keep-alive");
            client.DefaultRequestHeaders.Add("Referer", "http://cardapio.ufv.br/");
            client.DefaultRequestHeaders.Add("Cookie", "_ga_3GKTCB3HHS=GS1.1.1629082690.2.0.1629082690.0; _ga=GA1.1.1832076623.1629051520; PHPSESSID=4178ke3eus5jvr6uhgc6eeqku5");
            client.DefaultRequestHeaders.Add("Cache-Control", "max-age=0");

        }
    }
}