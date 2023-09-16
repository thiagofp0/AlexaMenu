using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace AlexaMenu.DataCapture
{
    public class RetroDataCapture
    {

        [Function("RetroDataCapture")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            //Se a requisição for post, pega a quantidade de dias retroativos informados no body e salva no mongo
            //Se a requisição for get, pega a quantidade de dias retroativos no appSettings e salva no mongo
            var response = req.CreateResponse(HttpStatusCode.Accepted);
            return response;
        }
    }
}
