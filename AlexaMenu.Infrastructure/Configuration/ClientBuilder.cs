using System.Net.Http.Headers;

namespace AlexaMenu.Infrastructure.Configuration
{
    public class ClientBuilder : HttpClient
    {
        public ClientBuilder()
        {
            this.BaseAddress = new Uri("http://cardapio.ufv.br/~Cevutaisdotantencharamautapas23usdenusjatepro/ajaxBuscaCardapioPorData.php");
            this.DefaultRequestHeaders.Accept.Clear();
            this.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
        }
    }
}
