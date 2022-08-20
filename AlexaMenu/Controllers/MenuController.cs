using System;
using System.Linq;
using System.Threading.Tasks;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using AlexaMenu.Interfaces;
using AlexaMenu.Providers;
using AlexaMenu.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AlexaMenu.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MenuController : Controller
    {
        private static IMenuRepository _menuRepository;
        private MenuProvider _menuProvider = new MenuProvider(_menuRepository);
        
        [HttpPost, Route("/menu")] 
        public SkillResponse GetMenu(SkillRequest input)
        {
            SkillResponse output = new SkillResponse();
            output.Version = "1.0";
            output.Response = new ResponseBody();
            

            if (input.Request.Type == "LaunchRequest")
            {
                string menuOutput = _menuProvider.GetCurrentMenu();
                output.Response.OutputSpeech = new PlainTextOutputSpeech(menuOutput);
                output.Response.ShouldEndSession = true;

            }
            else if (input.Request.Type == "IntentRequest")
            {
                IntentRequest intentRequest = (IntentRequest) input.Request;
                string intentType = intentRequest.Intent.Name;
                output.Response.OutputSpeech = new PlainTextOutputSpeech(SwitchIntent(intentType));
                output.Response.ShouldEndSession = true;
            }
            return output;
        }

        private string SwitchIntent(string intentType)
        {
            if (intentType == "GetCurrentMenu")
            {
                return _menuProvider.GetCurrentMenu();
            }
            return null;
        }
    }
}