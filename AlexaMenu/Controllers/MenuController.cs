using System.Threading.Tasks;
using Alexa.NET.Request;
using Alexa.NET.Response;
using AlexaMenu.Interfaces;
using AlexaMenu.Providers;
using Microsoft.AspNetCore.Mvc;

namespace AlexaMenu.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MenuController : Controller
    {
        
        [HttpPost, Route("/menu")] 
        public SkillResponse GetMenu(SkillRequest input)
        {
            SkillResponse output = new SkillResponse();
            output.Version = "1.0";
            output.Response = new ResponseBody();
            output.Response.OutputSpeech = new PlainTextOutputSpeech("Olá! Isso funciona!");
            return output;
        }
    }
}