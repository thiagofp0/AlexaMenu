using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace AlexaMenu.Domain
{
    public class ClientBuilder : HttpClient
    {
        public ClientBuilder()
        {
            this.BaseAddress = new Uri(Constants.BaseAddress);
            this.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
        }
    }
}